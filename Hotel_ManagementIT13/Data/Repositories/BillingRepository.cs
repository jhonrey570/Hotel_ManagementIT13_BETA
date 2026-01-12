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
                string query = @"
                    INSERT INTO billing_items (billing_id, description, amount)
                    VALUES (@billingId, @description, @amount);
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

        public bool AddBillingItemByReservation(int reservationId, string description, decimal amount)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string getBillingIdQuery = "SELECT billing_id FROM billings WHERE reservation_id = @reservationId";
                int billingId = 0;

                using (var cmd = new MySqlCommand(getBillingIdQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@reservationId", reservationId);
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        billingId = Convert.ToInt32(result);
                    }
                }

                if (billingId == 0)
                {
                    string createQuery = @"
                        INSERT INTO billings (reservation_id, total_amount, paid_amount, balance, billing_date)
                        VALUES (@reservationId, 0, 0, 0, NOW());
                        SELECT LAST_INSERT_ID();";

                    using (var createCmd = new MySqlCommand(createQuery, conn))
                    {
                        createCmd.Parameters.AddWithValue("@reservationId", reservationId);
                        billingId = Convert.ToInt32(createCmd.ExecuteScalar());
                    }
                }

                string addItemQuery = @"
                    INSERT INTO billing_items (billing_id, description, amount)
                    VALUES (@billingId, @description, @amount);
                    UPDATE billings SET 
                    total_amount = total_amount + @amount,
                    balance = balance + @amount
                    WHERE billing_id = @billingId";

                using (var cmd = new MySqlCommand(addItemQuery, conn))
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

        public bool AddRoomCharge(int reservationId, string roomNumber, int nights, decimal nightlyRate)
        {
            decimal totalCharge = nightlyRate * nights;
            string description = $"Room {roomNumber} - {nights} night(s) @ {nightlyRate:₱0.00}/night";

            return AddBillingItemByReservation(reservationId, description, totalCharge);
        }
    }
}