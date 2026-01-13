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
                        using (var cmd = new MySqlCommand("sp_ProcessPayment", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@p_reservation_id", reservationId);
                            cmd.Parameters.AddWithValue("@p_amount", amount);
                            cmd.Parameters.AddWithValue("@p_payment_method", paymentMethod);
                            cmd.Parameters.AddWithValue("@p_notes", notes ?? "");

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Payment processing failed: {ex.Message}", ex);
                    }
                }
            }
        }

        public bool UpdateBillingTotal(int reservationId, decimal roomCharge)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (var cmd = new MySqlCommand("sp_UpdateBillingTotal", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@p_reservation_id", reservationId);
                            cmd.Parameters.AddWithValue("@p_room_charge", roomCharge);

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

                using (var cmd = new MySqlCommand("sp_GetPaymentsByReservation", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_reservation_id", reservationId);

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

                using (var cmd = new MySqlCommand("sp_GetPaymentsByDateRange", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_start_date", startDate);
                    cmd.Parameters.AddWithValue("@p_end_date", endDate);

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

                using (var cmd = new MySqlCommand("sp_GetTotalRevenue", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_start_date", startDate);
                    cmd.Parameters.AddWithValue("@p_end_date", endDate);

                    var resultParam = new MySqlParameter("@p_total_revenue", MySqlDbType.Decimal);
                    resultParam.Precision = 10;
                    resultParam.Scale = 2;
                    resultParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(resultParam);

                    cmd.ExecuteNonQuery();

                    return resultParam.Value != DBNull.Value ? Convert.ToDecimal(resultParam.Value) : 0;
                }
            }
        }
    }
}