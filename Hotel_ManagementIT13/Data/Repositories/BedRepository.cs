using Hotel_ManagementIT13.Data.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Hotel_ManagementIT13.Data.Repositories
{
    public class BedRepository
    {
        public List<RoomBed> GetBedsForRoom(int roomId)
        {
            var beds = new List<RoomBed>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT rb.*, bt.bed_type_name
                    FROM room_beds rb
                    LEFT JOIN bed_types bt ON rb.bed_type_id = bt.bed_type_id
                    WHERE rb.room_id = @roomId
                    ORDER BY rb.room_bed_id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomId", roomId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var roomBed = new RoomBed
                            {
                                RoomBedId = Convert.ToInt32(reader["room_bed_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                BedTypeId = Convert.ToInt32(reader["bed_type_id"]),
                                Quantity = Convert.ToInt32(reader["quantity"]),
                                BedTypeName = reader["bed_type_name"]?.ToString() ?? "Unknown"
                            };

                            beds.Add(roomBed);
                        }
                    }
                }
            }

            return beds;
        }

        public List<BedType> GetAllBedTypes()
        {
            var bedTypes = new List<BedType>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM bed_types ORDER BY bed_type_id";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var bedType = new BedType
                        {
                            BedTypeId = Convert.ToInt32(reader["bed_type_id"]),
                            TypeName = reader["bed_type_name"].ToString()
                        };

                        bedTypes.Add(bedType);
                    }
                }
            }

            return bedTypes;
        }

        public BedType GetBedTypeById(int bedTypeId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM bed_types WHERE bed_type_id = @bedTypeId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bedTypeId", bedTypeId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new BedType
                            {
                                BedTypeId = Convert.ToInt32(reader["bed_type_id"]),
                                TypeName = reader["bed_type_name"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }

        public bool AddRoomBed(RoomBed roomBed, MySqlConnection conn = null, MySqlTransaction transaction = null)
        {
            bool shouldCloseConnection = false;

            try
            {
                if (conn == null)
                {
                    conn = DatabaseHelper.GetConnection();
                    conn.Open();
                    shouldCloseConnection = true;
                }

                string query = @"
                    INSERT INTO room_beds (room_id, bed_type_id, quantity)
                    VALUES (@roomId, @bedTypeId, @quantity);
                    SELECT LAST_INSERT_ID();";

                using (var cmd = transaction != null
                    ? new MySqlCommand(query, conn, transaction)
                    : new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomId", roomBed.RoomId);
                    cmd.Parameters.AddWithValue("@bedTypeId", roomBed.BedTypeId);
                    cmd.Parameters.AddWithValue("@quantity", roomBed.Quantity);

                    roomBed.RoomBedId = Convert.ToInt32(cmd.ExecuteScalar());
                    return roomBed.RoomBedId > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding room bed: {ex.Message}", ex);
            }
            finally
            {
                if (shouldCloseConnection && conn != null)
                {
                    conn.Close();
                }
            }
        }

        public bool UpdateRoomBed(RoomBed roomBed, MySqlConnection conn = null, MySqlTransaction transaction = null)
        {
            bool shouldCloseConnection = false;

            try
            {
                if (conn == null)
                {
                    conn = DatabaseHelper.GetConnection();
                    conn.Open();
                    shouldCloseConnection = true;
                }

                string query = @"
                    UPDATE room_beds 
                    SET bed_type_id = @bedTypeId, 
                        quantity = @quantity
                    WHERE room_bed_id = @roomBedId";

                using (var cmd = transaction != null
                    ? new MySqlCommand(query, conn, transaction)
                    : new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomBedId", roomBed.RoomBedId);
                    cmd.Parameters.AddWithValue("@bedTypeId", roomBed.BedTypeId);
                    cmd.Parameters.AddWithValue("@quantity", roomBed.Quantity);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating room bed: {ex.Message}", ex);
            }
            finally
            {
                if (shouldCloseConnection && conn != null)
                {
                    conn.Close();
                }
            }
        }

        public bool DeleteRoomBed(int roomBedId, MySqlConnection conn = null, MySqlTransaction transaction = null)
        {
            bool shouldCloseConnection = false;

            try
            {
                if (conn == null)
                {
                    conn = DatabaseHelper.GetConnection();
                    conn.Open();
                    shouldCloseConnection = true;
                }

                string query = "DELETE FROM room_beds WHERE room_bed_id = @roomBedId";

                using (var cmd = transaction != null
                    ? new MySqlCommand(query, conn, transaction)
                    : new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomBedId", roomBedId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting room bed: {ex.Message}", ex);
            }
            finally
            {
                if (shouldCloseConnection && conn != null)
                {
                    conn.Close();
                }
            }
        }

        public bool DeleteAllBedsForRoom(int roomId, MySqlConnection conn = null, MySqlTransaction transaction = null)
        {
            bool shouldCloseConnection = false;

            try
            {
                if (conn == null)
                {
                    conn = DatabaseHelper.GetConnection();
                    conn.Open();
                    shouldCloseConnection = true;
                }

                string query = "DELETE FROM room_beds WHERE room_id = @roomId";

                using (var cmd = transaction != null
                    ? new MySqlCommand(query, conn, transaction)
                    : new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomId", roomId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting beds for room: {ex.Message}", ex);
            }
            finally
            {
                if (shouldCloseConnection && conn != null)
                {
                    conn.Close();
                }
            }
        }

        public bool BedTypeExistsInRoom(int roomId, int bedTypeId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT COUNT(*) FROM room_beds 
                    WHERE room_id = @roomId AND bed_type_id = @bedTypeId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomId", roomId);
                    cmd.Parameters.AddWithValue("@bedTypeId", bedTypeId);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        // Get bed type by name
        public BedType GetBedTypeByName(string typeName)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM bed_types WHERE bed_type_name = @typeName";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@typeName", typeName);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new BedType
                            {
                                BedTypeId = Convert.ToInt32(reader["bed_type_id"]),
                                TypeName = reader["bed_type_name"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}