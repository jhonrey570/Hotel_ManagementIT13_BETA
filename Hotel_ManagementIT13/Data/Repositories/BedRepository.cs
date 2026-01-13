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

                using (var cmd = new MySqlCommand("sp_GetBedsForRoom", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_room_id", roomId);

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

                using (var cmd = new MySqlCommand("sp_GetAllBedTypes", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

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
            }

            return bedTypes;
        }

        public BedType GetBedTypeById(int bedTypeId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_GetBedTypeById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_bed_type_id", bedTypeId);

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

                using (var cmd = transaction != null
                    ? new MySqlCommand("sp_AddRoomBed", conn, transaction)
                    : new MySqlCommand("sp_AddRoomBed", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_room_id", roomBed.RoomId);
                    cmd.Parameters.AddWithValue("@p_bed_type_id", roomBed.BedTypeId);
                    cmd.Parameters.AddWithValue("@p_quantity", roomBed.Quantity);

                    var outputParam = new MySqlParameter("@p_new_id", MySqlDbType.Int32);
                    outputParam.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParam);

                    cmd.ExecuteNonQuery();

                    if (outputParam.Value != DBNull.Value)
                    {
                        roomBed.RoomBedId = Convert.ToInt32(outputParam.Value);
                        return roomBed.RoomBedId > 0;
                    }

                    return false;
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

                using (var cmd = transaction != null
                    ? new MySqlCommand("sp_UpdateRoomBed", conn, transaction)
                    : new MySqlCommand("sp_UpdateRoomBed", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_room_bed_id", roomBed.RoomBedId);
                    cmd.Parameters.AddWithValue("@p_bed_type_id", roomBed.BedTypeId);
                    cmd.Parameters.AddWithValue("@p_quantity", roomBed.Quantity);

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

                using (var cmd = transaction != null
                    ? new MySqlCommand("sp_DeleteRoomBed", conn, transaction)
                    : new MySqlCommand("sp_DeleteRoomBed", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_room_bed_id", roomBedId);

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

                using (var cmd = transaction != null
                    ? new MySqlCommand("sp_DeleteAllBedsForRoom", conn, transaction)
                    : new MySqlCommand("sp_DeleteAllBedsForRoom", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_room_id", roomId);

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

                using (var cmd = new MySqlCommand("sp_BedTypeExistsInRoom", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_room_id", roomId);
                    cmd.Parameters.AddWithValue("@p_bed_type_id", bedTypeId);

                    var resultParam = new MySqlParameter("@p_exists", MySqlDbType.Int32);
                    resultParam.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(resultParam);

                    cmd.ExecuteNonQuery();

                    if (resultParam.Value != DBNull.Value)
                    {
                        return Convert.ToInt32(resultParam.Value) > 0;
                    }

                    return false;
                }
            }
        }

        public BedType GetBedTypeByName(string typeName)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_GetBedTypeByName", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_type_name", typeName);

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