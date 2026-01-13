using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Hotel_ManagementIT13.Data.Repositories
{
    public class AmenityRepository
    {
        public List<Amenity> GetAllAmenities()
        {
            var amenities = new List<Amenity>();

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand("sp_GetAllAmenities", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var amenity = new Amenity
                                {
                                    AmenityId = Convert.ToInt32(reader["amenity_id"]),
                                    AmenityName = reader["amenity_name"].ToString(),
                                    
                                    Category = "General",
                                    IsStandard = true
                                };
                                amenities.Add(amenity);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading amenities: {ex.Message}", ex);
            }

            return amenities;
        }

        public List<Amenity> GetAmenitiesForRoom(int roomId)
        {
            var amenities = new List<Amenity>();

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                   
                    using (var cmd = new MySqlCommand("sp_GetAmenitiesForRoom", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_room_id", roomId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var amenity = new Amenity
                                {
                                    AmenityId = Convert.ToInt32(reader["amenity_id"]),
                                    AmenityName = reader["amenity_name"].ToString(),
                                    Category = "General",
                                    IsStandard = true
                                };
                                amenities.Add(amenity);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading room amenities: {ex.Message}", ex);
            }

            return amenities;
        }

        public void SaveRoomAmenities(int roomId, List<Amenity> amenities, MySqlConnection conn = null, MySqlTransaction transaction = null)
        {
            bool isExternalConnection = conn != null;

            try
            {
                if (!isExternalConnection)
                {
                    conn = DatabaseHelper.GetConnection();
                    conn.Open();
                }

               
                string amenityIds = "";
                if (amenities != null && amenities.Count > 0)
                {
                    List<string> idList = new List<string>();
                    foreach (var amenity in amenities)
                    {
                        idList.Add(amenity.AmenityId.ToString());
                    }
                    amenityIds = string.Join(",", idList);
                }

               
                using (var cmd = transaction != null
                    ? new MySqlCommand("sp_SaveRoomAmenities", conn, transaction)
                    : new MySqlCommand("sp_SaveRoomAmenities", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_room_id", roomId);
                    cmd.Parameters.AddWithValue("@p_amenity_ids", string.IsNullOrEmpty(amenityIds) ? null : amenityIds);

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (!isExternalConnection && conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}