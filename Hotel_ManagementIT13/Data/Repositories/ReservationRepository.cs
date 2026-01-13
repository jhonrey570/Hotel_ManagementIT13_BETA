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
                        // Convert rooms list to comma-separated string
                        string roomIds = "";
                        if (reservation.Rooms != null && reservation.Rooms.Count > 0)
                        {
                            List<string> idList = new List<string>();
                            foreach (var room in reservation.Rooms)
                            {
                                idList.Add(room.RoomId.ToString());
                            }
                            roomIds = string.Join(",", idList);
                        }

                        using (var cmd = new MySqlCommand("sp_CreateReservation", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@p_guest_id", reservation.GuestId);
                            cmd.Parameters.AddWithValue("@p_user_id", reservation.UserId);
                            cmd.Parameters.AddWithValue("@p_company_id", reservation.CompanyId);
                            cmd.Parameters.AddWithValue("@p_status_id", reservation.StatusId);
                            cmd.Parameters.AddWithValue("@p_reservation_type_id", reservation.ReservationTypeId);
                            cmd.Parameters.AddWithValue("@p_booking_reference", reservation.BookingReference);
                            cmd.Parameters.AddWithValue("@p_check_in_date", reservation.CheckInDate);
                            cmd.Parameters.AddWithValue("@p_check_out_date", reservation.CheckOutDate);
                            cmd.Parameters.AddWithValue("@p_adults", reservation.Adults);
                            cmd.Parameters.AddWithValue("@p_children", reservation.Children);
                            cmd.Parameters.AddWithValue("@p_special_requests", reservation.SpecialRequests);
                            cmd.Parameters.AddWithValue("@p_total_amount", reservation.TotalAmount);
                            cmd.Parameters.AddWithValue("@p_room_ids", string.IsNullOrEmpty(roomIds) ? null : roomIds);

                            var outputParam = new MySqlParameter("@p_reservation_id", MySqlDbType.Int32);
                            outputParam.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(outputParam);

                            cmd.ExecuteNonQuery();

                            int reservationId = outputParam.Value != DBNull.Value ? Convert.ToInt32(outputParam.Value) : 0;

                            transaction.Commit();
                            return reservationId;
                        }
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

                using (var cmd = new MySqlCommand("sp_UpdateReservationStatus", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_reservation_id", reservationId);
                    cmd.Parameters.AddWithValue("@p_status_id", statusId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool RecordCheckIn(int reservationId, int processedBy, int statusId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_RecordCheckIn", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_reservation_id", reservationId);
                    cmd.Parameters.AddWithValue("@p_processed_by", processedBy);
                    cmd.Parameters.AddWithValue("@p_status_id", statusId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool RecordCheckOut(int reservationId, int processedBy, int statusId, DateTime checkOutTime)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_RecordCheckOut", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_reservation_id", reservationId);
                    cmd.Parameters.AddWithValue("@p_processed_by", processedBy);
                    cmd.Parameters.AddWithValue("@p_status_id", statusId);
                    cmd.Parameters.AddWithValue("@p_check_out_time", checkOutTime);

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

                using (var cmd = new MySqlCommand("sp_GetTodaysArrivals", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

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

                using (var cmd = new MySqlCommand("sp_GetTodaysDepartures", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

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

                using (var cmd = new MySqlCommand("sp_GetCurrentlyCheckedIn", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

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

        public DateTime? GetCheckInTime(int reservationId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_GetCheckInTime", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_reservation_id", reservationId);

                    var resultParam = new MySqlParameter("@p_check_in_time", MySqlDbType.DateTime);
                    resultParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(resultParam);

                    cmd.ExecuteNonQuery();

                    if (resultParam.Value != DBNull.Value)
                    {
                        return Convert.ToDateTime(resultParam.Value);
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

                using (var cmd = new MySqlCommand("sp_GetCheckOutTime", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_reservation_id", reservationId);

                    var resultParam = new MySqlParameter("@p_check_out_time", MySqlDbType.DateTime);
                    resultParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(resultParam);

                    cmd.ExecuteNonQuery();

                    if (resultParam.Value != DBNull.Value)
                    {
                        return Convert.ToDateTime(resultParam.Value);
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

                using (var cmd = new MySqlCommand("sp_GetReservationsByDateRange", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_start_date", startDate);
                    cmd.Parameters.AddWithValue("@p_end_date", endDate);

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

                using (var cmd = new MySqlCommand("sp_GetReservationByReference", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_booking_reference", bookingReference);

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

                using (var cmd = new MySqlCommand("sp_GetReservationRooms", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_reservation_id", reservationId);

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

                using (var cmd = new MySqlCommand("sp_GetCheckInOutHistory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_reservation_id", reservationId);

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
}