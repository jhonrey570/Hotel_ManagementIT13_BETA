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
                    SELECT b.*, 
                           SUM(CASE WHEN p.payment_status_id = 2 THEN p.amount ELSE 0 END) as paid_amount
                    FROM billings b
                    LEFT JOIN payments p ON b.reservation_id = p.reservation_id
                    WHERE b.reservation_id = @reservationId
                    GROUP BY b.billing_id";

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

                            // Load payments
                            billing.Payments = GetPaymentsByReservation(reservationId);

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

        public bool ProcessPayment(int reservationId, decimal amount,
                                 string paymentMethod, string notes = "")
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Insert payment
                        string paymentQuery = @"
                            INSERT INTO payments 
                            (reservation_id, payment_status_id, amount, payment_method, notes)
                            VALUES 
                            (@reservationId, 2, @amount, @paymentMethod, @notes)";

                        using (var cmd = new MySqlCommand(paymentQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@reservationId", reservationId);
                            cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);
                            cmd.Parameters.AddWithValue("@notes", notes);
                            cmd.ExecuteNonQuery();
                        }

                        // Update billing
                        string billingQuery = @"
                            UPDATE billings SET 
                            paid_amount = paid_amount + @amount,
                            balance = total_amount - (paid_amount + @amount)
                            WHERE reservation_id = @reservationId";

                        using (var cmd = new MySqlCommand(billingQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@reservationId", reservationId);
                            cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<Payment> GetPaymentsByReservation(int reservationId)
        {
            var payments = new List<Payment>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT p.*, ps.status_name
                    FROM payments p
                    JOIN payment_statuses ps ON p.payment_status_id = ps.payment_status_id
                    WHERE p.reservation_id = @reservationId
                    ORDER BY p.payment_date DESC";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@reservationId", reservationId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            payments.Add(new Payment
                            {
                                PaymentId = Convert.ToInt32(reader["payment_id"]),
                                ReservationId = Convert.ToInt32(reader["reservation_id"]),
                                PaymentStatusId = Convert.ToInt32(reader["payment_status_id"]),
                                Amount = Convert.ToDecimal(reader["amount"]),
                                PaymentMethod = reader["payment_method"].ToString(),
                                PaymentDate = Convert.ToDateTime(reader["payment_date"]),
                                Notes = reader["notes"].ToString(),
                                StatusName = reader["status_name"].ToString()
                            });
                        }
                    }
                }
            }

            return payments;
        }

        public decimal GetTotalRevenue(DateTime startDate, DateTime endDate)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT COALESCE(SUM(amount), 0) as total_revenue
                    FROM payments 
                    WHERE payment_status_id = 2 -- Paid
                    AND DATE(payment_date) BETWEEN @startDate AND @endDate";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }
    }
}