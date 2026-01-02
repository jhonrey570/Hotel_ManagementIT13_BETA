using MySql.Data.MySqlClient;
using Hotel_ManagementIT13.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Hotel_ManagementIT13.Data.Repositories
{
    public class ReservationRepository
    {
        public string GenerateBookingReference()
        {
            return "RES" + DateTime.Now.ToString("yyMMddHHmmss") + new Random().Next(100, 999);
        }

        public int CreateReservation(Reservation reservation)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Insert reservation
                        string query = @"
                            INSERT INTO reservations 
                            (guest_id, user_id, company_id, status_id, reservation_type_id, 
                             booking_reference, check_in_date, check_out_date, adults, children, 
                             special_requests, total_amount)
                            VALUES 
                            (@guestId, @userId, @companyId, @statusId, @reservationTypeId,
                             @bookingRef, @checkIn, @checkOut, @adults, @children, 
                             @specialRequests, @totalAmount);
                            SELECT LAST_INSERT_ID();";

                        int reservationId;

                        using (var cmd = new MySqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@guestId", reservation.GuestId);
                            cmd.Parameters.AddWithValue("@userId", reservation.UserId);
                            cmd.Parameters.AddWithValue("@companyId", reservation.CompanyId);
                            cmd.Parameters.AddWithValue("@statusId", reservation.StatusId);
                            cmd.Parameters.AddWithValue("@reservationTypeId", reservation.ReservationTypeId);
                            cmd.Parameters.AddWithValue("@bookingRef", reservation.BookingReference);
                            cmd.Parameters.AddWithValue("@checkIn", reservation.CheckInDate);
                            cmd.Parameters.AddWithValue("@checkOut", reservation.CheckOutDate);
                            cmd.Parameters.AddWithValue("@adults", reservation.Adults);
                            cmd.Parameters.AddWithValue("@children", reservation.Children);
                            cmd.Parameters.AddWithValue("@specialRequests", reservation.SpecialRequests);
                            cmd.Parameters.AddWithValue("@totalAmount", reservation.TotalAmount);

                            reservationId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Insert reservation rooms
                        foreach (var room in reservation.Rooms)
                        {
                            string roomQuery = @"
                                INSERT INTO reservation_rooms (reservation_id, room_id)
                                VALUES (@reservationId, @roomId);
                                UPDATE rooms SET status_id = 3 WHERE room_id = @roomId"; // Set to Reserved

                            using (var roomCmd = new MySqlCommand(roomQuery, conn, transaction))
                            {
                                roomCmd.Parameters.AddWithValue("@reservationId", reservationId);
                                roomCmd.Parameters.AddWithValue("@roomId", room.RoomId);
                                roomCmd.ExecuteNonQuery();
                            }
                        }

                        // Create billing record
                        string billingQuery = @"
                            INSERT INTO billings (reservation_id, total_amount, paid_amount, balance)
                            VALUES (@reservationId, @totalAmount, 0, @totalAmount)";

                        using (var billingCmd = new MySqlCommand(billingQuery, conn, transaction))
                        {
                            billingCmd.Parameters.AddWithValue("@reservationId", reservationId);
                            billingCmd.Parameters.AddWithValue("@totalAmount", reservation.TotalAmount);
                            billingCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return reservationId;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<Reservation> GetReservationsByDateRange(DateTime startDate, DateTime endDate)
        {
            var reservations = new List<Reservation>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT r.*, g.first_name, g.last_name, 
                           rs.status_name, rt.type_name as reservation_type,
                           c.company_name, u.username as user_name
                    FROM reservations r
                    JOIN guests g ON r.guest_id = g.guest_id
                    JOIN reservation_statuses rs ON r.status_id = rs.status_id
                    JOIN reservation_types rt ON r.reservation_type_id = rt.reservation_type_id
                    LEFT JOIN companies c ON r.company_id = c.company_id
                    JOIN users u ON r.user_id = u.user_id
                    WHERE r.check_in_date <= @endDate AND r.check_out_date >= @startDate
                    ORDER BY r.check_in_date";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reservations.Add(CreateReservationFromReader(reader));
                        }
                    }
                }
            }

            return reservations;
        }

        public Reservation GetReservationByReference(string bookingReference)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT r.*, g.first_name, g.last_name, 
                           rs.status_name, rt.type_name as reservation_type,
                           c.company_name, u.username as user_name
                    FROM reservations r
                    JOIN guests g ON r.guest_id = g.guest_id
                    JOIN reservation_statuses rs ON r.status_id = rs.status_id
                    JOIN reservation_types rt ON r.reservation_type_id = rt.reservation_type_id
                    LEFT JOIN companies c ON r.company_id = c.company_id
                    JOIN users u ON r.user_id = u.user_id
                    WHERE r.booking_reference = @bookingRef";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bookingRef", bookingReference);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return CreateReservationFromReader(reader);
                        }
                    }
                }
            }

            return null;
        }

        private Reservation CreateReservationFromReader(MySqlDataReader reader)
        {
            var reservation = new Reservation
            {
                ReservationId = Convert.ToInt32(reader["reservation_id"]),
                GuestId = Convert.ToInt32(reader["guest_id"]),
                UserId = Convert.ToInt32(reader["user_id"]),
                CompanyId = reader["company_id"] != DBNull.Value ? Convert.ToInt32(reader["company_id"]) : (int?)null,
                StatusId = Convert.ToInt32(reader["status_id"]),
                ReservationTypeId = Convert.ToInt32(reader["reservation_type_id"]),
                BookingReference = reader["booking_reference"].ToString(),
                CheckInDate = Convert.ToDateTime(reader["check_in_date"]),
                CheckOutDate = Convert.ToDateTime(reader["check_out_date"]),
                Adults = Convert.ToInt32(reader["adults"]),
                Children = Convert.ToInt32(reader["children"]),
                SpecialRequests = reader["special_requests"].ToString(),
                TotalAmount = Convert.ToDecimal(reader["total_amount"]),
                CreatedAt = Convert.ToDateTime(reader["created_at"]),
                GuestName = $"{reader["first_name"]} {reader["last_name"]}",
                StatusName = reader["status_name"].ToString(),
                ReservationTypeName = reader["reservation_type"].ToString(),
                CompanyName = reader["company_name"]?.ToString(),
                UserName = reader["user_name"].ToString()
            };

            return reservation;
        }
    }
}