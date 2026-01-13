using MySql.Data.MySqlClient;
using Hotel_ManagementIT13.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Hotel_ManagementIT13.Data.Repositories
{
    public class BillingRepository
    {
        public Billing GetBillingByReservationId(int reservationId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_GetBillingByReservationId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_reservation_id", reservationId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var billing = new Billing
                            {
                                BillingId = Convert.ToInt32(reader["billing_id"]),
                                ReservationId = Convert.ToInt32(reader["reservation_id"]),
                                TotalAmount = Convert.ToDecimal(reader["total_amount"]),
                                PaidAmount = Convert.ToDecimal(reader["paid_amount"]),
                                Balance = Convert.ToDecimal(reader["balance"]),
                                BillingDate = Convert.ToDateTime(reader["billing_date"])
                            };

                            billing.Items = GetBillingItems(billing.BillingId);

                            return billing;
                        }
                    }
                }
            }

            return null;
        }

        public List<BillingItem> GetBillingItems(int billingId)
        {
            var items = new List<BillingItem>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_GetBillingItems", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_billing_id", billingId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new BillingItem
                            {
                                ItemId = Convert.ToInt32(reader["item_id"]),
                                BillingId = Convert.ToInt32(reader["billing_id"]),
                                Description = reader["description"].ToString(),
                                Amount = Convert.ToDecimal(reader["amount"])
                            };

                            if (reader.GetSchemaTable().Select("ColumnName = 'created_at'").Length > 0)
                            {
                                item.CreatedAt = Convert.ToDateTime(reader["created_at"]);
                            }
                            else
                            {
                                item.CreatedAt = DateTime.Now;
                            }

                            items.Add(item);
                        }
                    }
                }
            }

            return items;
        }

        public bool AddBillingItem(int billingId, string description, decimal amount)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_AddBillingItem", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_billing_id", billingId);
                    cmd.Parameters.AddWithValue("@p_description", description);
                    cmd.Parameters.AddWithValue("@p_amount", amount);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool AddBillingItemByReservation(int reservationId, string description, decimal amount)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_AddBillingItemByReservation", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_reservation_id", reservationId);
                    cmd.Parameters.AddWithValue("@p_description", description);
                    cmd.Parameters.AddWithValue("@p_amount", amount);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool CreateBilling(int reservationId, decimal totalAmount)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_CreateBilling", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_reservation_id", reservationId);
                    cmd.Parameters.AddWithValue("@p_total_amount", totalAmount);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public Billing GetBillingById(int billingId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_GetBillingById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_billing_id", billingId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Billing
                            {
                                BillingId = Convert.ToInt32(reader["billing_id"]),
                                ReservationId = Convert.ToInt32(reader["reservation_id"]),
                                TotalAmount = Convert.ToDecimal(reader["total_amount"]),
                                PaidAmount = Convert.ToDecimal(reader["paid_amount"]),
                                Balance = Convert.ToDecimal(reader["balance"]),
                                BillingDate = Convert.ToDateTime(reader["billing_date"])
                            };
                        }
                    }
                }
            }

            return null;
        }

        public bool UpdateBillingTotals(int billingId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_UpdateBillingTotals", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_billing_id", billingId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool AddRoomCharge(int reservationId, string roomNumber, int nights, decimal nightlyRate)
        {
            decimal totalCharge = nightlyRate * nights;
            string description = $"Room {roomNumber} - {nights} night(s) @ {nightlyRate:₱0.00}/night";

            return AddBillingItemByReservation(reservationId, description, totalCharge);
        }
    }
}