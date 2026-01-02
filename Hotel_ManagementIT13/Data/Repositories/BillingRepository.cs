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
                string query = @"
                    SELECT b.*
                    FROM billings b
                    WHERE b.reservation_id = @reservationId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@reservationId", reservationId);

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

                            // Load billing items
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
                string query = @"
                    SELECT * FROM billing_items 
                    WHERE billing_id = @billingId
                    ORDER BY item_id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@billingId", billingId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new BillingItem
                            {
                                ItemId = Convert.ToInt32(reader["item_id"]),
                                BillingId = Convert.ToInt32(reader["billing_id"]),
                                Description = reader["description"].ToString(),
                                Amount = Convert.ToDecimal(reader["amount"]),
                                CreatedAt = Convert.ToDateTime(reader["created_at"])
                            });
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
                // UPDATED: Added created_at column with NOW()
                string query = @"
                    INSERT INTO billing_items (billing_id, description, amount, created_at)
                    VALUES (@billingId, @description, @amount, NOW());
                    UPDATE billings SET 
                    total_amount = total_amount + @amount,
                    balance = balance + @amount
                    WHERE billing_id = @billingId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@billingId", billingId);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@amount", amount);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool CreateBilling(int reservationId, decimal totalAmount)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    INSERT INTO billings (reservation_id, total_amount, paid_amount, balance, billing_date)
                    VALUES (@reservationId, @totalAmount, 0, @totalAmount, NOW())";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@reservationId", reservationId);
                    cmd.Parameters.AddWithValue("@totalAmount", totalAmount);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Additional useful method to get billing by billing ID
        public Billing GetBillingById(int billingId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT b.*
                    FROM billings b
                    WHERE b.billing_id = @billingId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@billingId", billingId);

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

        // Method to update billing totals (useful for recalculations)
        public bool UpdateBillingTotals(int billingId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    UPDATE billings b
                    SET 
                        total_amount = (SELECT COALESCE(SUM(amount), 0) FROM billing_items WHERE billing_id = @billingId),
                        balance = total_amount - paid_amount
                    WHERE b.billing_id = @billingId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@billingId", billingId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}