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

                using (var cmd = new MySqlCommand("sp_GetAllRooms", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

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

                using (var cmd = new MySqlCommand("sp_GetRoomById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_room_id", roomId);

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

                using (var cmd = new MySqlCommand("sp_GetRoomByNumber", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_room_number", roomNumber);

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

                using (var cmd = new MySqlCommand("sp_SearchRooms", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_search_term", $"%{searchTerm}%");

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

        public List<Room> GetAvailableRooms(DateTime checkIn, DateTime checkOut, int roomTypeId = 0)
        {
            var rooms = new List<Room>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_GetAvailableRooms", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_check_in", checkIn);
                    cmd.Parameters.AddWithValue("@p_check_out", checkOut);
                    cmd.Parameters.AddWithValue("@p_room_type_id", roomTypeId);

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
                        // Convert beds list to comma-separated string
                        string bedData = "";
                        if (room.Beds != null && room.Beds.Count > 0)
                        {
                            List<string> bedList = new List<string>();
                            foreach (var bed in room.Beds)
                            {
                                bedList.Add($"{bed.BedTypeId}:{bed.Quantity}");
                            }
                            bedData = string.Join(",", bedList);
                        }

                        // Convert amenities list to comma-separated string
                        string amenityIds = "";
                        if (room.Amenities != null && room.Amenities.Count > 0)
                        {
                            List<string> idList = new List<string>();
                            foreach (var amenity in room.Amenities)
                            {
                                idList.Add(amenity.AmenityId.ToString());
                            }
                            amenityIds = string.Join(",", idList);
                        }

                        using (var cmd = new MySqlCommand("sp_AddRoom", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@p_room_type_name", room.RoomTypeName);
                            cmd.Parameters.AddWithValue("@p_status_name", room.StatusName);
                            cmd.Parameters.AddWithValue("@p_view_name", room.ViewName);
                            cmd.Parameters.AddWithValue("@p_room_number", room.RoomNumber);
                            cmd.Parameters.AddWithValue("@p_floor", room.Floor);
                            cmd.Parameters.AddWithValue("@p_bed_data", string.IsNullOrEmpty(bedData) ? null : bedData);
                            cmd.Parameters.AddWithValue("@p_amenity_ids", string.IsNullOrEmpty(amenityIds) ? null : amenityIds);

                            var outputParam = new MySqlParameter("@p_new_room_id", MySqlDbType.Int32);
                            outputParam.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(outputParam);

                            cmd.ExecuteNonQuery();

                            int newRoomId = outputParam.Value != DBNull.Value ? Convert.ToInt32(outputParam.Value) : 0;

                            if (newRoomId == 0)
                            {
                                throw new Exception("Failed to add room: No room ID returned.");
                            }

                            transaction.Commit();
                            return newRoomId;
                        }
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
                        // Convert beds list to comma-separated string
                        string bedData = "";
                        if (room.Beds != null)
                        {
                            List<string> bedList = new List<string>();
                            foreach (var bed in room.Beds)
                            {
                                bedList.Add($"{bed.BedTypeId}:{bed.Quantity}");
                            }
                            bedData = string.Join(",", bedList);
                        }

                        // Convert amenities list to comma-separated string
                        string amenityIds = "";
                        if (room.Amenities != null)
                        {
                            List<string> idList = new List<string>();
                            foreach (var amenity in room.Amenities)
                            {
                                idList.Add(amenity.AmenityId.ToString());
                            }
                            amenityIds = string.Join(",", idList);
                        }

                        using (var cmd = new MySqlCommand("sp_UpdateRoom", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@p_room_id", room.RoomId);
                            cmd.Parameters.AddWithValue("@p_room_type_name", room.RoomTypeName);
                            cmd.Parameters.AddWithValue("@p_status_name", room.StatusName);
                            cmd.Parameters.AddWithValue("@p_view_name", room.ViewName);
                            cmd.Parameters.AddWithValue("@p_room_number", room.RoomNumber);
                            cmd.Parameters.AddWithValue("@p_floor", room.Floor);
                            cmd.Parameters.AddWithValue("@p_bed_data", string.IsNullOrEmpty(bedData) ? null : bedData);
                            cmd.Parameters.AddWithValue("@p_amenity_ids", string.IsNullOrEmpty(amenityIds) ? null : amenityIds);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected == 0)
                            {
                                transaction.Rollback();
                                return false;
                            }

                            transaction.Commit();
                            return true;
                        }
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
                        using (var cmd = new MySqlCommand("sp_DeleteRoom", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@p_room_id", roomId);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                transaction.Commit();
                                return true;
                            }
                            else
                            {
                                transaction.Rollback();
                                return false;
                            }
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

                using (var cmd = new MySqlCommand("sp_UpdateRoomStatus", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_room_id", roomId);
                    cmd.Parameters.AddWithValue("@p_status_id", statusId);

                    return cmd.ExecuteNonQuery() > 0;
                }
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
    }
}