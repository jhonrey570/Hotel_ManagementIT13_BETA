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
                    string query = "SELECT amenity_id, amenity_name FROM amenities ORDER BY amenity_name";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var amenity = new Amenity
                            {
                                AmenityId = Convert.ToInt32(reader["amenity_id"]),
                                AmenityName = reader["amenity_name"].ToString(),
                                // Database doesn't have these fields, so we'll set defaults
                                Category = "General",
                                IsStandard = true
                            };
                            amenities.Add(amenity);
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
                    string query = @"
                        SELECT a.amenity_id, a.amenity_name
                        FROM amenities a
                        INNER JOIN room_amenities ra ON a.amenity_id = ra.amenity_id
                        WHERE ra.room_id = @roomId
                        ORDER BY a.amenity_name";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@roomId", roomId);

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

                // First, delete existing amenities for this room
                string deleteQuery = "DELETE FROM room_amenities WHERE room_id = @roomId";
                using (var deleteCmd = transaction != null
                    ? new MySqlCommand(deleteQuery, conn, transaction)
                    : new MySqlCommand(deleteQuery, conn))
                {
                    deleteCmd.Parameters.AddWithValue("@roomId", roomId);
                    deleteCmd.ExecuteNonQuery();
                }

                // Then insert new amenities
                if (amenities != null && amenities.Count > 0)
                {
                    string insertQuery = "INSERT INTO room_amenities (room_id, amenity_id) VALUES (@roomId, @amenityId)";

                    foreach (var amenity in amenities)
                    {
                        using (var insertCmd = transaction != null
                            ? new MySqlCommand(insertQuery, conn, transaction)
                            : new MySqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@roomId", roomId);
                            insertCmd.Parameters.AddWithValue("@amenityId", amenity.AmenityId);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
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