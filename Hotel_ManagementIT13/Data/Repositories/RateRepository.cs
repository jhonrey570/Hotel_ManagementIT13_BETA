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
                string query = @"
                    SELECT rc.rate_amount
                    FROM rate_configurations rc
                    WHERE rc.room_type_id = @roomTypeId
                    AND rc.start_date <= CURDATE()
                    AND rc.end_date >= CURDATE()
                    ORDER BY rc.start_date DESC
                    LIMIT 1";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomTypeId", roomTypeId);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        decimal baseRate = Convert.ToDecimal(result);

                        // Apply guest type discount
                        return ApplyGuestTypeDiscount(baseRate, guestTypeId);
                    }
                }
            }

            // Default rate if none found
            return GetDefaultRate(roomTypeId);
        }

        private decimal ApplyGuestTypeDiscount(decimal baseRate, int guestTypeId)
        {
            decimal discount = 0;

            // Use if-else instead of switch for safety
            if (guestTypeId == 2) // VIP
                discount = 0.10m;
            else if (guestTypeId == 3) // Corporate
                discount = 0.15m;
            else if (guestTypeId == 4) // Travel Agency
                discount = 0.20m;

            return baseRate * (1 - discount);
        }

        private decimal GetDefaultRate(int roomTypeId)
        {
            // Use if-else instead of switch expression for compatibility
            if (roomTypeId == 1) return 100;     // Single
            else if (roomTypeId == 2) return 150; // Double
            else if (roomTypeId == 3) return 200; // Twin
            else if (roomTypeId == 4) return 300; // Suite
            else if (roomTypeId == 5) return 400; // Deluxe
            else if (roomTypeId == 6) return 1000; // Presidential
            else return 100; // Default
        }

        public List<RateConfiguration> GetRateConfigurations()
        {
            var rates = new List<RateConfiguration>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT rc.*, rt.type_name, rp.plan_name
                    FROM rate_configurations rc
                    JOIN room_types rt ON rc.room_type_id = rt.room_type_id
                    JOIN rate_plans rp ON rc.rate_plan_id = rp.rate_plan_id
                    ORDER BY rc.start_date DESC, rt.type_name";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
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
                    }
                }
            }

            return rates;
        }

        public bool AddRateConfiguration(RateConfiguration rate)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    INSERT INTO rate_configurations 
                    (room_type_id, rate_plan_id, rate_amount, start_date, end_date)
                    VALUES 
                    (@roomTypeId, @ratePlanId, @rateAmount, @startDate, @endDate)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomTypeId", rate.RoomTypeId);
                    cmd.Parameters.AddWithValue("@ratePlanId", rate.RatePlanId);
                    cmd.Parameters.AddWithValue("@rateAmount", rate.RateAmount);
                    cmd.Parameters.AddWithValue("@startDate", rate.StartDate);
                    cmd.Parameters.AddWithValue("@endDate", rate.EndDate);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateRateConfiguration(RateConfiguration rate)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    UPDATE rate_configurations SET
                    room_type_id = @roomTypeId,
                    rate_plan_id = @ratePlanId,
                    rate_amount = @rateAmount,
                    start_date = @startDate,
                    end_date = @endDate
                    WHERE rate_id = @rateId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@rateId", rate.RateId);
                    cmd.Parameters.AddWithValue("@roomTypeId", rate.RoomTypeId);
                    cmd.Parameters.AddWithValue("@ratePlanId", rate.RatePlanId);
                    cmd.Parameters.AddWithValue("@rateAmount", rate.RateAmount);
                    cmd.Parameters.AddWithValue("@startDate", rate.StartDate);
                    cmd.Parameters.AddWithValue("@endDate", rate.EndDate);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<RoomType> GetRoomTypes()
        {
            var roomTypes = new List<RoomType>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM room_types ORDER BY type_name";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roomTypes.Add(new RoomType
                            {
                                RoomTypeId = Convert.ToInt32(reader["room_type_id"]),
                                TypeName = reader["type_name"].ToString(),
                                BaseRate = Convert.ToDecimal(reader["base_rate"]),
                                MaxOccupancy = Convert.ToInt32(reader["max_occupancy"])
                            });
                        }
                    }
                }
            }

            return roomTypes;
        }

        public List<RatePlan> GetRatePlans()
        {
            var ratePlans = new List<RatePlan>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM rate_plans ORDER BY plan_name";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ratePlans.Add(new RatePlan
                            {
                                RatePlanId = Convert.ToInt32(reader["rate_plan_id"]),
                                PlanName = reader["plan_name"].ToString(),
                                Description = reader["description"].ToString()
                            });
                        }
                    }
                }
            }

            return ratePlans;
        }
    }

    public class RateConfiguration
    {
        public int RateId { get; set; }
        public int RoomTypeId { get; set; }
        public int RatePlanId { get; set; }
        public decimal RateAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RoomTypeName { get; set; }
        public string PlanName { get; set; }

        public bool IsActive()
        {
            DateTime today = DateTime.Today;
            return StartDate <= today && EndDate >= today;
        }
    }

    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string TypeName { get; set; }
        public decimal BaseRate { get; set; }
        public int MaxOccupancy { get; set; }
    }

    public class RatePlan
    {
        public int RatePlanId { get; set; }
        public string PlanName { get; set; }
        public string Description { get; set; }
    }
}