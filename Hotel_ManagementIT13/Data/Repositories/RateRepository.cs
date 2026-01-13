using MySql.Data.MySqlClient;
using Hotel_ManagementIT13.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Hotel_ManagementIT13.Data.Repositories
{
    public class RateRepository
    {
        public decimal GetCurrentRate(int roomTypeId, int guestTypeId = 1)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_GetCurrentRate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_room_type_id", roomTypeId);
                    cmd.Parameters.AddWithValue("@p_guest_type_id", guestTypeId);

                    var resultParam = new MySqlParameter("@p_current_rate", MySqlDbType.Decimal);
                    resultParam.Precision = 10;
                    resultParam.Scale = 2;
                    resultParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(resultParam);

                    cmd.ExecuteNonQuery();

                    if (resultParam.Value != DBNull.Value)
                    {
                        return Convert.ToDecimal(resultParam.Value);
                    }
                }
            }

            return GetDefaultRate(roomTypeId);
        }

        private decimal ApplyGuestTypeDiscount(decimal baseRate, int guestTypeId)
        {
            decimal discount = 0;
            if (guestTypeId == 2) discount = 0.10m;
            else if (guestTypeId == 3) discount = 0.15m;
            else if (guestTypeId == 4) discount = 0.20m;
            return baseRate * (1 - discount);
        }

        private decimal GetDefaultRate(int roomTypeId)
        {
            if (roomTypeId == 1) return 100;
            else if (roomTypeId == 2) return 150;
            else if (roomTypeId == 3) return 200;
            else if (roomTypeId == 4) return 300;
            else if (roomTypeId == 5) return 400;
            else if (roomTypeId == 6) return 1000;
            else return 100;
        }

        public List<RateConfiguration> GetRateConfigurations()
        {
            var rates = new List<RateConfiguration>();

            try
            {
                Console.WriteLine("DEBUG: Loading rate configurations...");

                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand("sp_GetRateConfigurations", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (var reader = cmd.ExecuteReader())
                        {
                            int count = 0;
                            while (reader.Read())
                            {
                                count++;
                                rates.Add(new RateConfiguration
                                {
                                    RateId = Convert.ToInt32(reader["rate_id"]),
                                    RoomTypeId = Convert.ToInt32(reader["room_type_id"]),
                                    RatePlanId = Convert.ToInt32(reader["rate_plan_id"]),
                                    RateAmount = Convert.ToDecimal(reader["rate_amount"]),
                                    StartDate = Convert.ToDateTime(reader["start_date"]),
                                    EndDate = Convert.ToDateTime(reader["end_date"]),
                                    RoomTypeName = reader["type_name"].ToString(),
                                    PlanName = reader["plan_name"].ToString()
                                });
                            }
                            Console.WriteLine($"DEBUG: Loaded {count} rate configurations");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR in GetRateConfigurations: {ex.Message}");
                throw;
            }

            return rates;
        }

        public bool AddRateConfiguration(RateConfiguration rate)
        {
            try
            {
                Console.WriteLine($"DEBUG: Adding rate configuration - RoomTypeId: {rate.RoomTypeId}, RatePlanId: {rate.RatePlanId}, Amount: {rate.RateAmount}");

                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand("sp_AddRateConfiguration", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_room_type_id", rate.RoomTypeId);
                        cmd.Parameters.AddWithValue("@p_rate_plan_id", rate.RatePlanId);
                        cmd.Parameters.AddWithValue("@p_rate_amount", rate.RateAmount);
                        cmd.Parameters.AddWithValue("@p_start_date", rate.StartDate);
                        cmd.Parameters.AddWithValue("@p_end_date", rate.EndDate);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine($"DEBUG: Added rate configuration, rows affected: {rowsAffected}");
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR in AddRateConfiguration: {ex.Message}");
                throw;
            }
        }

        public bool UpdateRateConfiguration(RateConfiguration rate)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_UpdateRateConfiguration", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_rate_id", rate.RateId);
                    cmd.Parameters.AddWithValue("@p_room_type_id", rate.RoomTypeId);
                    cmd.Parameters.AddWithValue("@p_rate_plan_id", rate.RatePlanId);
                    cmd.Parameters.AddWithValue("@p_rate_amount", rate.RateAmount);
                    cmd.Parameters.AddWithValue("@p_start_date", rate.StartDate);
                    cmd.Parameters.AddWithValue("@p_end_date", rate.EndDate);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteRateConfiguration(int rateId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_DeleteRateConfiguration", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_rate_id", rateId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public RateConfiguration GetRateConfigurationById(int rateId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_GetRateConfigurationById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_rate_id", rateId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new RateConfiguration
                            {
                                RateId = Convert.ToInt32(reader["rate_id"]),
                                RoomTypeId = Convert.ToInt32(reader["room_type_id"]),
                                RatePlanId = Convert.ToInt32(reader["rate_plan_id"]),
                                RateAmount = Convert.ToDecimal(reader["rate_amount"]),
                                StartDate = Convert.ToDateTime(reader["start_date"]),
                                EndDate = Convert.ToDateTime(reader["end_date"]),
                                RoomTypeName = reader["type_name"].ToString(),
                                PlanName = reader["plan_name"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<RoomType> GetRoomTypes()
        {
            var roomTypes = new List<RoomType>();

            try
            {
                Console.WriteLine("DEBUG: Loading room types...");

                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand("sp_GetRoomTypes", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (var reader = cmd.ExecuteReader())
                        {
                            int count = 0;
                            while (reader.Read())
                            {
                                count++;
                                roomTypes.Add(new RoomType
                                {
                                    RoomTypeId = Convert.ToInt32(reader["room_type_id"]),
                                    TypeName = reader["type_name"].ToString(),
                                    BaseRate = Convert.ToDecimal(reader["base_rate"]),
                                    MaxOccupancy = Convert.ToInt32(reader["max_occupancy"])
                                });
                            }
                            Console.WriteLine($"DEBUG: Loaded {count} room types");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR in GetRoomTypes: {ex.Message}");
                throw;
            }

            return roomTypes;
        }

        public List<RatePlan> GetRatePlans()
        {
            var ratePlans = new List<RatePlan>();

            try
            {
                Console.WriteLine("DEBUG: Loading rate plans...");

                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand("sp_GetRatePlans", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (var reader = cmd.ExecuteReader())
                        {
                            int count = 0;
                            while (reader.Read())
                            {
                                count++;
                                Console.WriteLine($"DEBUG: Found rate plan: {reader["plan_name"]}");

                                ratePlans.Add(new RatePlan
                                {
                                    RatePlanId = Convert.ToInt32(reader["rate_plan_id"]),
                                    PlanName = reader["plan_name"].ToString(),
                                    Description = reader["description"].ToString()
                                });
                            }
                            Console.WriteLine($"DEBUG: Loaded {count} rate plans");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR in GetRatePlans: {ex.Message}");
                throw;
            }

            return ratePlans;
        }

        public bool UpdateRoomTypeBaseRate(int roomTypeId, decimal newBaseRate)
        {
            try
            {
                Console.WriteLine($"DEBUG: Updating room type {roomTypeId} base rate to {newBaseRate}");

                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand("sp_UpdateRoomTypeBaseRate", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_room_type_id", roomTypeId);
                        cmd.Parameters.AddWithValue("@p_base_rate", newBaseRate);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine($"DEBUG: Updated base rate, rows affected: {rowsAffected}");
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR in UpdateRoomTypeBaseRate: {ex.Message}");
                return false;
            }
        }
    }
}