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

        public bool UpdateReservationStatus(int reservationId, int statusId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE reservations SET status_id = @statusId WHERE reservation_id = @reservationId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@reservationId", reservationId);
                    cmd.Parameters.AddWithValue("@statusId", statusId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool RecordCheckIn(int reservationId, int processedBy, int statusId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    INSERT INTO check_in_out (reservation_id, processed_by, status_id, check_in_time)
                    VALUES (@reservationId, @processedBy, @statusId, NOW())";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@reservationId", reservationId);
                    cmd.Parameters.AddWithValue("@processedBy", processedBy);
                    cmd.Parameters.AddWithValue("@statusId", statusId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool RecordCheckOut(int reservationId, int processedBy, int statusId, DateTime checkOutTime)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    UPDATE check_in_out 
                    SET status_id = @statusId, check_out_time = @checkOutTime 
                    WHERE reservation_id = @reservationId
                    AND check_out_time IS NULL";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@reservationId", reservationId);
                    cmd.Parameters.AddWithValue("@processedBy", processedBy);
                    cmd.Parameters.AddWithValue("@statusId", statusId);
                    cmd.Parameters.AddWithValue("@checkOutTime", checkOutTime);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Reservation> GetTodaysArrivals()
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
                    WHERE DATE(r.check_in_date) = CURDATE()
                    AND r.status_id IN (1, 2) -- Confirmed, Pending Payment (reservation_statuses)
                    ORDER BY r.check_in_date";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var reservation = CreateReservationFromReader(reader);
                            reservation.Rooms = GetReservationRooms(reservation.ReservationId);
                            reservations.Add(reservation);
                        }
                    }
                }
            }

            return reservations;
        }

        public List<Reservation> GetTodaysDepartures()
        {
            var reservations = new List<Reservation>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT DISTINCT r.*, g.first_name, g.last_name, 
                           rs.status_name, rt.type_name as reservation_type,
                           c.company_name, u.username as user_name,
                           cio.check_in_time, cio.check_out_time
                    FROM reservations r
                    JOIN guests g ON r.guest_id = g.guest_id
                    JOIN reservation_statuses rs ON r.status_id = rs.status_id
                    JOIN reservation_types rt ON r.reservation_type_id = rt.reservation_type_id
                    LEFT JOIN companies c ON r.company_id = c.company_id
                    JOIN users u ON r.user_id = u.user_id
                    LEFT JOIN check_in_out cio ON r.reservation_id = cio.reservation_id
                    WHERE (DATE(r.check_out_date) = CURDATE() 
                           OR cio.check_out_time IS NULL) -- Currently checked in
                    AND r.status_id = 3 -- Checked-in (reservation_statuses)
                    AND (cio.check_out_time IS NULL OR cio.status_id = 1) -- Currently checked in
                    ORDER BY r.check_out_date, cio.check_in_time DESC";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var reservation = CreateReservationFromReader(reader);
                            reservation.Rooms = GetReservationRooms(reservation.ReservationId);
                            reservations.Add(reservation);
                        }
                    }
                }
            }

            return reservations;
        }

        public List<Reservation> GetCurrentlyCheckedIn()
        {
            var reservations = new List<Reservation>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT DISTINCT r.*, g.first_name, g.last_name, 
                           rs.status_name, rt.type_name as reservation_type,
                           c.company_name, u.username as user_name,
                           cio.check_in_time
                    FROM reservations r
                    JOIN guests g ON r.guest_id = g.guest_id
                    JOIN reservation_statuses rs ON r.status_id = rs.status_id
                    JOIN reservation_types rt ON r.reservation_type_id = rt.reservation_type_id
                    LEFT JOIN companies c ON r.company_id = c.company_id
                    JOIN users u ON r.user_id = u.user_id
                    JOIN check_in_out cio ON r.reservation_id = cio.reservation_id
                    WHERE r.status_id = 3 -- Checked-in (reservation_statuses)
                    AND cio.check_out_time IS NULL -- Not checked out yet
                    AND cio.status_id = 1 -- Checked-in status
                    ORDER BY cio.check_in_time DESC";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var reservation = CreateReservationFromReader(reader);
                            reservation.Rooms = GetReservationRooms(reservation.ReservationId);

                            // Store check-in time in a custom field in the Tag property
                            DateTime checkInTime = reader["check_in_time"] != DBNull.Value
                                ? Convert.ToDateTime(reader["check_in_time"])
                                : DateTime.MinValue;

                            // We'll handle this differently in the form
                            reservations.Add(reservation);
                        }
                    }
                }
            }

            return reservations;
        }

        public DateTime? GetCheckInTime(int reservationId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT check_in_time 
                    FROM check_in_out 
                    WHERE reservation_id = @reservationId 
                    AND check_out_time IS NULL
                    ORDER BY check_in_time DESC 
                    LIMIT 1";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@reservationId", reservationId);

                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDateTime(result);
                    }
                }
            }

            return null;
        }

        public DateTime? GetCheckOutTime(int reservationId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT check_out_time 
                    FROM check_in_out 
                    WHERE reservation_id = @reservationId 
                    AND check_out_time IS NOT NULL
                    ORDER BY check_out_time DESC 
                    LIMIT 1";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@reservationId", reservationId);

                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDateTime(result);
                    }
                }
            }

            return null;
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
                            var reservation = CreateReservationFromReader(reader);
                            reservation.Rooms = GetReservationRooms(reservation.ReservationId);
                            reservations.Add(reservation);
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
                            var reservation = CreateReservationFromReader(reader);
                            reservation.Rooms = GetReservationRooms(reservation.ReservationId);
                            return reservation;
                        }
                    }
                }
            }

            return null;
        }

        public List<ReservationRoom> GetReservationRooms(int reservationId)
        {
            var rooms = new List<ReservationRoom>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT rr.*, r.room_number, rt.type_name as room_type_name
                    FROM reservation_rooms rr
                    JOIN rooms r ON rr.room_id = r.room_id
                    JOIN room_types rt ON r.room_type_id = rt.room_type_id
                    WHERE rr.reservation_id = @reservationId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@reservationId", reservationId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rooms.Add(new ReservationRoom
                            {
                                ResRoomId = Convert.ToInt32(reader["res_room_id"]),
                                ReservationId = Convert.ToInt32(reader["reservation_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                RoomNumber = reader["room_number"].ToString(),
                                RoomTypeName = reader["room_type_name"].ToString()
                            });
                        }
                    }
                }
            }

            return rooms;
        }

        public List<CheckInOutRecord> GetCheckInOutHistory(int reservationId)
        {
            var records = new List<CheckInOutRecord>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT cio.*, u.username as processed_by_name, cis.status_name
                    FROM check_in_out cio
                    JOIN users u ON cio.processed_by = u.user_id
                    JOIN check_in_statuses cis ON cio.status_id = cis.status_id
                    WHERE cio.reservation_id = @reservationId
                    ORDER BY cio.check_in_time DESC";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@reservationId", reservationId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            records.Add(new CheckInOutRecord
                            {
                                CheckId = Convert.ToInt32(reader["check_id"]),
                                ReservationId = Convert.ToInt32(reader["reservation_id"]),
                                ProcessedBy = Convert.ToInt32(reader["processed_by"]),
                                ProcessedByName = reader["processed_by_name"].ToString(),
                                StatusId = Convert.ToInt32(reader["status_id"]),
                                StatusName = reader["status_name"].ToString(),
                                CheckInTime = Convert.ToDateTime(reader["check_in_time"]),
                                CheckOutTime = reader["check_out_time"] != DBNull.Value
                                    ? Convert.ToDateTime(reader["check_out_time"])
                                    : (DateTime?)null
                            });
                        }
                    }
                }
            }

            return records;
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

    public class CheckInOutRecord
    {
        public int CheckId { get; set; }
        public int ReservationId { get; set; }
        public int ProcessedBy { get; set; }
        public string ProcessedByName { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
    }
}