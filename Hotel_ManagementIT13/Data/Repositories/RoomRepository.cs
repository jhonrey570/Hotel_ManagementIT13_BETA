using MySql.Data.MySqlClient;
using Hotel_ManagementIT13.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Hotel_ManagementIT13.Data.Repositories
{
    public class RoomRepository
    {
        private readonly AmenityRepository _amenityRepo;

        public RoomRepository()
        {
            _amenityRepo = new AmenityRepository();
        }

        // Nested concrete class since Room is abstract
        private class ConcreteRoom : Room
        {
            public override string GetRoomCategory()
            {
                if (this.RoomTypeName.Contains("Standard"))
                    return "Standard";
                else if (this.RoomTypeName.Contains("Deluxe"))
                    return "Deluxe";
                else if (this.RoomTypeName.Contains("Suite") || this.RoomTypeName.Contains("Penthouse") || this.RoomTypeName.Contains("Executive"))
                    return "Suite";
                else
                    return "Standard";
            }

            public override decimal CalculateRate(int nights, int guestType)
            {
                // Simple calculation based on base rate
                decimal rate = this.BaseRate * nights;

                // Apply guest type discount (if any)
                if (guestType == 2) // Regular guest
                    rate *= 0.9m; // 10% discount
                else if (guestType == 3) // VIP guest
                    rate *= 0.85m; // 15% discount

                return rate;
            }
        }

        public List<Room> GetAllRooms()
        {
            var rooms = new List<Room>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT r.*, rt.type_name, rt.base_rate, rt.max_occupancy, 
                           rs.status_name, rv.view_name
                    FROM rooms r
                    JOIN room_types rt ON r.room_type_id = rt.room_type_id
                    JOIN room_statuses rs ON r.status_id = rs.status_id
                    JOIN room_views rv ON r.view_id = rv.view_id
                    ORDER BY r.floor, r.room_number";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var room = CreateRoomFromReader(reader);
                            // Load amenities for this room
                            room.Amenities = _amenityRepo.GetAmenitiesForRoom(room.RoomId);
                            rooms.Add(room);
                        }
                    }
                }
            }

            return rooms;
        }

        public Room GetRoomById(int roomId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT r.*, rt.type_name, rt.base_rate, rt.max_occupancy, 
                           rs.status_name, rv.view_name
                    FROM rooms r
                    JOIN room_types rt ON r.room_type_id = rt.room_type_id
                    JOIN room_statuses rs ON r.status_id = rs.status_id
                    JOIN room_views rv ON r.view_id = rv.view_id
                    WHERE r.room_id = @roomId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomId", roomId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var room = CreateRoomFromReader(reader);
                            // Load amenities for this room
                            room.Amenities = _amenityRepo.GetAmenitiesForRoom(roomId);
                            return room;
                        }
                    }
                }
            }

            return null;
        }

        public Room GetRoomByNumber(string roomNumber)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT r.*, rt.type_name, rt.base_rate, rt.max_occupancy, 
                           rs.status_name, rv.view_name
                    FROM rooms r
                    JOIN room_types rt ON r.room_type_id = rt.room_type_id
                    JOIN room_statuses rs ON r.status_id = rs.status_id
                    JOIN room_views rv ON r.view_id = rv.view_id
                    WHERE r.room_number = @roomNumber";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomNumber", roomNumber);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var room = CreateRoomFromReader(reader);
                            // Load amenities for this room
                            room.Amenities = _amenityRepo.GetAmenitiesForRoom(room.RoomId);
                            return room;
                        }
                    }
                }
            }

            return null;
        }

        public List<Room> SearchRooms(string searchTerm)
        {
            var rooms = new List<Room>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT r.*, rt.type_name, rt.base_rate, rt.max_occupancy, 
                           rs.status_name, rv.view_name
                    FROM rooms r
                    JOIN room_types rt ON r.room_type_id = rt.room_type_id
                    JOIN room_statuses rs ON r.status_id = rs.status_id
                    JOIN room_views rv ON r.view_id = rv.view_id
                    WHERE r.room_number LIKE @search 
                       OR rt.type_name LIKE @search
                       OR rs.status_name LIKE @search
                       OR rv.view_name LIKE @search
                       OR CAST(r.floor AS CHAR) LIKE @search
                    ORDER BY r.floor, r.room_number";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", $"%{searchTerm}%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var room = CreateRoomFromReader(reader);
                            // Load amenities for this room
                            room.Amenities = _amenityRepo.GetAmenitiesForRoom(room.RoomId);
                            rooms.Add(room);
                        }
                    }
                }
            }

            return rooms;
        }

        // ADDED METHOD - GetAvailableRooms
        public List<Room> GetAvailableRooms(DateTime checkIn, DateTime checkOut, int roomTypeId = 0)
        {
            var rooms = new List<Room>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT r.*, rt.type_name, rt.base_rate, rt.max_occupancy, 
                           rs.status_name, rv.view_name
                    FROM rooms r
                    JOIN room_types rt ON r.room_type_id = rt.room_type_id
                    JOIN room_statuses rs ON r.status_id = rs.status_id
                    JOIN room_views rv ON r.view_id = rv.view_id
                    WHERE r.status_id = 1 -- Available
                    AND r.room_id NOT IN (
                        SELECT rr.room_id 
                        FROM reservation_rooms rr
                        JOIN reservations res ON rr.reservation_id = res.reservation_id
                        WHERE res.status_id IN (1, 2, 3) -- Confirmed, Pending Payment, Checked-in
                        AND NOT (res.check_out_date <= @checkIn OR res.check_in_date >= @checkOut)
                    )";

                if (roomTypeId > 0)
                {
                    query += " AND r.room_type_id = @roomTypeId";
                }

                query += " ORDER BY r.floor, r.room_number";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@checkIn", checkIn);
                    cmd.Parameters.AddWithValue("@checkOut", checkOut);

                    if (roomTypeId > 0)
                    {
                        cmd.Parameters.AddWithValue("@roomTypeId", roomTypeId);
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var room = CreateRoomFromReader(reader);
                            // Load amenities for this room
                            room.Amenities = _amenityRepo.GetAmenitiesForRoom(room.RoomId);
                            rooms.Add(room);
                        }
                    }
                }
            }

            return rooms;
        }

        public int AddRoom(Room room)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Get IDs based on names
                        int roomTypeId = GetRoomTypeIdByName(room.RoomTypeName, conn);
                        int statusId = GetStatusIdByName(room.StatusName, conn);
                        int viewId = GetViewIdByName(room.ViewName, conn);

                        if (roomTypeId == 0)
                        {
                            throw new Exception($"Room type '{room.RoomTypeName}' not found in database.");
                        }

                        if (statusId == 0)
                        {
                            throw new Exception($"Status '{room.StatusName}' not found in database.");
                        }

                        if (viewId == 0)
                        {
                            throw new Exception($"View type '{room.ViewName}' not found in database.");
                        }

                        string query = @"
                            INSERT INTO rooms (room_type_id, status_id, view_id, room_number, floor)
                            VALUES (@typeId, @statusId, @viewId, @roomNumber, @floor);
                            SELECT LAST_INSERT_ID();";

                        int newRoomId;

                        using (var cmd = new MySqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@typeId", roomTypeId);
                            cmd.Parameters.AddWithValue("@statusId", statusId);
                            cmd.Parameters.AddWithValue("@viewId", viewId);
                            cmd.Parameters.AddWithValue("@roomNumber", room.RoomNumber);
                            cmd.Parameters.AddWithValue("@floor", room.Floor);

                            newRoomId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Save beds if any
                        if (room.Beds != null && room.Beds.Count > 0)
                        {
                            SaveRoomBeds(newRoomId, room.Beds, conn, transaction);
                        }

                        // Save amenities if any - PASS THE TRANSACTION
                        if (room.Amenities != null && room.Amenities.Count > 0)
                        {
                            _amenityRepo.SaveRoomAmenities(newRoomId, room.Amenities, conn, transaction);
                        }

                        transaction.Commit();
                        return newRoomId;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Error adding room: {ex.Message}", ex);
                    }
                }
            }
        }

        public bool UpdateRoom(Room room)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Get IDs based on names
                        int roomTypeId = GetRoomTypeIdByName(room.RoomTypeName, conn);
                        int statusId = GetStatusIdByName(room.StatusName, conn);
                        int viewId = GetViewIdByName(room.ViewName, conn);

                        if (roomTypeId == 0)
                        {
                            throw new Exception($"Room type '{room.RoomTypeName}' not found in database.");
                        }

                        if (statusId == 0)
                        {
                            throw new Exception($"Status '{room.StatusName}' not found in database.");
                        }

                        if (viewId == 0)
                        {
                            throw new Exception($"View type '{room.ViewName}' not found in database.");
                        }

                        string query = @"
                            UPDATE rooms SET
                            room_type_id = @typeId,
                            status_id = @statusId,
                            view_id = @viewId,
                            room_number = @roomNumber,
                            floor = @floor
                            WHERE room_id = @roomId";

                        using (var cmd = new MySqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@roomId", room.RoomId);
                            cmd.Parameters.AddWithValue("@typeId", roomTypeId);
                            cmd.Parameters.AddWithValue("@statusId", statusId);
                            cmd.Parameters.AddWithValue("@viewId", viewId);
                            cmd.Parameters.AddWithValue("@roomNumber", room.RoomNumber);
                            cmd.Parameters.AddWithValue("@floor", room.Floor);

                            bool success = cmd.ExecuteNonQuery() > 0;

                            if (!success)
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }

                        // Update beds if any
                        if (room.Beds != null)
                        {
                            UpdateRoomBeds(room.RoomId, room.Beds, conn, transaction);
                        }

                        // Update amenities if any - PASS THE TRANSACTION
                        if (room.Amenities != null)
                        {
                            _amenityRepo.SaveRoomAmenities(room.RoomId, room.Amenities, conn, transaction);
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Error updating room: {ex.Message}", ex);
                    }
                }
            }
        }

        public bool DeleteRoom(int roomId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // First check if room has any reservations
                        string checkQuery = "SELECT COUNT(*) FROM reservation_rooms WHERE room_id = @roomId";
                        using (var checkCmd = new MySqlCommand(checkQuery, conn, transaction))
                        {
                            checkCmd.Parameters.AddWithValue("@roomId", roomId);
                            int reservationCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                            if (reservationCount > 0)
                            {
                                throw new InvalidOperationException("Cannot delete room with existing reservations.");
                            }
                        }

                        // Delete room amenities first
                        string deleteAmenitiesQuery = "DELETE FROM room_amenities WHERE room_id = @roomId";
                        using (var amenitiesCmd = new MySqlCommand(deleteAmenitiesQuery, conn, transaction))
                        {
                            amenitiesCmd.Parameters.AddWithValue("@roomId", roomId);
                            amenitiesCmd.ExecuteNonQuery();
                        }

                        // Delete room beds first
                        string deleteBedsQuery = "DELETE FROM room_beds WHERE room_id = @roomId";
                        using (var bedsCmd = new MySqlCommand(deleteBedsQuery, conn, transaction))
                        {
                            bedsCmd.Parameters.AddWithValue("@roomId", roomId);
                            bedsCmd.ExecuteNonQuery();
                        }

                        string query = "DELETE FROM rooms WHERE room_id = @roomId";

                        using (var cmd = new MySqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@roomId", roomId);
                            bool success = cmd.ExecuteNonQuery() > 0;

                            if (success)
                            {
                                transaction.Commit();
                            }
                            else
                            {
                                transaction.Rollback();
                            }

                            return success;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Error deleting room: {ex.Message}", ex);
                    }
                }
            }
        }

        public bool UpdateRoomStatus(int roomId, int statusId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE rooms SET status_id = @statusId WHERE room_id = @roomId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomId", roomId);
                    cmd.Parameters.AddWithValue("@statusId", statusId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        private int GetRoomTypeIdByName(string typeName, MySqlConnection conn)
        {
            string query = "SELECT room_type_id FROM room_types WHERE type_name = @typeName";
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@typeName", typeName);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        private int GetStatusIdByName(string statusName, MySqlConnection conn)
        {
            string query = "SELECT status_id FROM room_statuses WHERE status_name = @statusName";
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@statusName", statusName);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        private int GetViewIdByName(string viewName, MySqlConnection conn)
        {
            string query = "SELECT view_id FROM room_views WHERE view_name = @viewName";
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@viewName", viewName);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        private Room CreateRoomFromReader(MySqlDataReader reader)
        {
            var room = new ConcreteRoom();

            room.RoomId = Convert.ToInt32(reader["room_id"]);
            room.RoomTypeId = Convert.ToInt32(reader["room_type_id"]);
            room.StatusId = Convert.ToInt32(reader["status_id"]);
            room.ViewId = Convert.ToInt32(reader["view_id"]);
            room.RoomNumber = reader["room_number"].ToString();
            room.Floor = Convert.ToInt32(reader["floor"]);
            room.RoomTypeName = reader["type_name"].ToString();
            room.StatusName = reader["status_name"].ToString();
            room.ViewName = reader["view_name"].ToString();
            room.BaseRate = Convert.ToDecimal(reader["base_rate"]);
            room.MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]);

            return room;
        }

        private void SaveRoomBeds(int roomId, List<RoomBed> beds, MySqlConnection conn, MySqlTransaction transaction = null)
        {
            foreach (var bed in beds)
            {
                string query = @"
                    INSERT INTO room_beds (room_id, bed_type_id, quantity)
                    VALUES (@roomId, @bedTypeId, @quantity)";

                using (var cmd = transaction != null
                    ? new MySqlCommand(query, conn, transaction)
                    : new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomId", roomId);
                    cmd.Parameters.AddWithValue("@bedTypeId", bed.BedTypeId);
                    cmd.Parameters.AddWithValue("@quantity", bed.Quantity);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void UpdateRoomBeds(int roomId, List<RoomBed> beds, MySqlConnection conn, MySqlTransaction transaction = null)
        {
            // First delete existing beds
            string deleteQuery = "DELETE FROM room_beds WHERE room_id = @roomId";
            using (var deleteCmd = transaction != null
                ? new MySqlCommand(deleteQuery, conn, transaction)
                : new MySqlCommand(deleteQuery, conn))
            {
                deleteCmd.Parameters.AddWithValue("@roomId", roomId);
                deleteCmd.ExecuteNonQuery();
            }

            // Add new beds
            SaveRoomBeds(roomId, beds, conn, transaction);
        }
    }
}