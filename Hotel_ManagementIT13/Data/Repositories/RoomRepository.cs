using MySql.Data.MySqlClient;
using Hotel_ManagementIT13.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Hotel_ManagementIT13.Data.Repositories
{
    public class RoomRepository
    {
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
                            return CreateRoomFromReader(reader);
                        }
                    }
                }
            }

            return null;
        }

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
                            rooms.Add(room);
                        }
                    }
                }
            }

            return rooms;
        }

        public bool AddRoom(Room room)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    INSERT INTO rooms (room_type_id, status_id, view_id, room_number, floor)
                    VALUES (@typeId, @statusId, @viewId, @roomNumber, @floor);
                    SELECT LAST_INSERT_ID();";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@typeId", room.RoomTypeId);
                    cmd.Parameters.AddWithValue("@statusId", room.StatusId);
                    cmd.Parameters.AddWithValue("@viewId", room.ViewId);
                    cmd.Parameters.AddWithValue("@roomNumber", room.RoomNumber);
                    cmd.Parameters.AddWithValue("@floor", room.Floor);

                    int roomId = Convert.ToInt32(cmd.ExecuteScalar());

                    // Add beds
                    foreach (var bed in room.Beds)
                    {
                        string bedQuery = @"
                            INSERT INTO room_beds (room_id, bed_type_id, quantity)
                            VALUES (@roomId, @bedTypeId, @quantity)";

                        using (var bedCmd = new MySqlCommand(bedQuery, conn))
                        {
                            bedCmd.Parameters.AddWithValue("@roomId", roomId);
                            bedCmd.Parameters.AddWithValue("@bedTypeId", bed.BedTypeId);
                            bedCmd.Parameters.AddWithValue("@quantity", bed.Quantity);
                            bedCmd.ExecuteNonQuery();
                        }
                    }

                    // Add amenities
                    foreach (var amenity in room.Amenities)
                    {
                        string amenityQuery = @"
                            INSERT INTO room_amenities (room_id, amenity_id)
                            VALUES (@roomId, @amenityId)";

                        using (var amenityCmd = new MySqlCommand(amenityQuery, conn))
                        {
                            amenityCmd.Parameters.AddWithValue("@roomId", roomId);
                            amenityCmd.Parameters.AddWithValue("@amenityId", amenity.AmenityId);
                            amenityCmd.ExecuteNonQuery();
                        }
                    }

                    return true;
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

        private Room CreateRoomFromReader(MySqlDataReader reader)
        {
            Room room;
            string typeName = reader["type_name"].ToString();

            switch (typeName.ToLower())
            {
                case "deluxe":
                    room = new DeluxeRoom();
                    break;
                case "suite":
                    room = new Suite();
                    break;
                default:
                    room = new StandardRoom();
                    break;
            }

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
    }
}