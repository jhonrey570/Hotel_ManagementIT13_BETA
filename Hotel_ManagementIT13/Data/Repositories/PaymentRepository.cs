using MySql.Data.MySqlClient;
using Hotel_ManagementIT13.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Hotel_ManagementIT13.Data.Repositories
{
    public class PaymentRepository
    {
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
                        // Insert payment record
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

                        // Update billing table
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

        public List<Payment> GetPaymentsByDateRange(DateTime startDate, DateTime endDate)
        {
            var payments = new List<Payment>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT p.*, ps.status_name, r.booking_reference, 
                           CONCAT(g.first_name, ' ', g.last_name) as guest_name
                    FROM payments p
                    JOIN payment_statuses ps ON p.payment_status_id = ps.payment_status_id
                    JOIN reservations r ON p.reservation_id = r.reservation_id
                    JOIN guests g ON r.guest_id = g.guest_id
                    WHERE DATE(p.payment_date) BETWEEN @startDate AND @endDate
                    ORDER BY p.payment_date DESC";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);

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
                                StatusName = reader["status_name"].ToString(),
                                BookingReference = reader["booking_reference"].ToString(),
                                GuestName = reader["guest_name"].ToString()
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