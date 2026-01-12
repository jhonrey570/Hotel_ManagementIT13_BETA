using Hotel_ManagementIT13.Data;
using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_ManagementIT13.Services
{
    public class HistoryTabService
    {
        private readonly RoomRepository _roomRepo;

        public HistoryTabService()
        {
            _roomRepo = new RoomRepository();
        }

        public void SetupReservationHistoryTab(TabPage tabPage)
        {
            DataGridView dgvReservationHistory = new DataGridView();
            dgvReservationHistory.Dock = DockStyle.Fill;
            dgvReservationHistory.Name = "dgvReservationHistory";
            dgvReservationHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservationHistory.ReadOnly = true;
            dgvReservationHistory.AllowUserToAddRows = false;
            dgvReservationHistory.AllowUserToDeleteRows = false;
            dgvReservationHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservationHistory.RowHeadersVisible = false;

            dgvReservationHistory.Columns.Add("BookingReference", "Booking #");
            dgvReservationHistory.Columns.Add("GuestName", "Guest Name");
            dgvReservationHistory.Columns.Add("CheckInDate", "Check-in");
            dgvReservationHistory.Columns.Add("CheckOutDate", "Check-out");
            dgvReservationHistory.Columns.Add("Rooms", "Rooms");

            DataGridViewTextBoxColumn totalAmountCol = new DataGridViewTextBoxColumn();
            totalAmountCol.Name = "TotalAmount";
            totalAmountCol.HeaderText = "Total";
            totalAmountCol.DefaultCellStyle.Format = "₱0.00";
            totalAmountCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvReservationHistory.Columns.Add(totalAmountCol);

            dgvReservationHistory.Columns.Add("StatusName", "Status");
            dgvReservationHistory.Columns.Add("CreatedAt", "Booking Date");

            dgvReservationHistory.Columns["CheckInDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvReservationHistory.Columns["CheckOutDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvReservationHistory.Columns["CreatedAt"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";

            Panel filterPanel = new Panel();
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Height = 50;
            filterPanel.BackColor = SystemColors.Control;

            Button btnRefreshHistory = UIHelper.CreateStyledButton("Refresh", 10, 10);
            btnRefreshHistory.Name = "btnRefreshHistory";

            Button btnCancelReservation = UIHelper.CreateStyledButton("Cancel", 120, 10);
            btnCancelReservation.Name = "btnCancelReservation";

            Button btnNoShow = UIHelper.CreateStyledButton("No Show", 230, 10);
            btnNoShow.Name = "btnNoShow";

            Label lblFromDate = new Label();
            lblFromDate.Text = "From:";
            lblFromDate.Location = new Point(340, 18);
            lblFromDate.Size = new Size(40, 20);
            lblFromDate.Font = new Font("Calibri", 10);

            DateTimePicker dtpFromDate = new DateTimePicker();
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Value = DateTime.Today.AddYears(-5);
            dtpFromDate.Location = new Point(385, 15);
            dtpFromDate.Size = new Size(120, 20);
            dtpFromDate.Font = new Font("Calibri", 10);

            Label lblToDate = new Label();
            lblToDate.Text = "To:";
            lblToDate.Location = new Point(515, 18);
            lblToDate.Size = new Size(30, 20);
            lblToDate.Font = new Font("Calibri", 10);

            DateTimePicker dtpToDate = new DateTimePicker();
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Value = DateTime.Today.AddYears(5);
            dtpToDate.Location = new Point(550, 15);
            dtpToDate.Size = new Size(120, 20);
            dtpToDate.Font = new Font("Calibri", 10);

            Button btnFilterHistory = UIHelper.CreateStyledButton("Filter", 680, 10);
            btnFilterHistory.Name = "btnFilterHistory";

            filterPanel.Controls.Add(btnRefreshHistory);
            filterPanel.Controls.Add(btnCancelReservation);
            filterPanel.Controls.Add(btnNoShow);
            filterPanel.Controls.Add(lblFromDate);
            filterPanel.Controls.Add(dtpFromDate);
            filterPanel.Controls.Add(lblToDate);
            filterPanel.Controls.Add(dtpToDate);
            filterPanel.Controls.Add(btnFilterHistory);

            tabPage.Controls.Add(filterPanel);
            tabPage.Controls.Add(dgvReservationHistory);
        }

        public HistoryServiceResult LoadReservationHistory(DateTime? fromDate = null, DateTime? toDate = null)
        {
            var result = new HistoryServiceResult();

            try
            {
                var reservations = GetAllReservationsDirectly(fromDate, toDate);
                result.Reservations = reservations;
                result.Message = $"Loaded {reservations.Count} reservation(s)";
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Reservations = new List<Reservation>();
                result.Message = $"Error loading reservation history: {ex.Message}";
                result.Success = false;
            }

            return result;
        }

        public void DisplayReservationHistory(DataGridView dgvReservationHistory, List<Reservation> reservations)
        {
            dgvReservationHistory.Rows.Clear();

            if (reservations != null && reservations.Count > 0)
            {
                var sortedReservations = reservations.OrderByDescending(r => r.CreatedAt).ToList();

                foreach (var reservation in sortedReservations)
                {
                    string roomNumbers = "No rooms";
                    if (reservation.Rooms != null && reservation.Rooms.Count > 0)
                    {
                        roomNumbers = string.Join(", ", reservation.Rooms.Select(r => r.RoomNumber));
                    }

                    string formattedTotal = reservation.TotalAmount.ToString("₱0.00");

                    dgvReservationHistory.Rows.Add(
                        reservation.BookingReference,
                        reservation.GuestName,
                        reservation.CheckInDate,
                        reservation.CheckOutDate,
                        roomNumbers,
                        formattedTotal,
                        reservation.StatusName,
                        reservation.CreatedAt
                    );
                }

                foreach (DataGridViewRow row in dgvReservationHistory.Rows)
                {
                    string status = row.Cells["StatusName"].Value?.ToString();
                    if (!string.IsNullOrEmpty(status))
                    {
                        row.DefaultCellStyle.BackColor = StatusHelper.GetStatusColorForHistory(status);
                    }
                }

                dgvReservationHistory.ClearSelection();
            }
        }

        public HistoryActionResult CancelReservation(string bookingReference, string currentStatus)
        {
            var result = new HistoryActionResult();

            if (currentStatus?.ToLower() == "cancelled" || currentStatus?.ToLower() == "checked-out")
            {
                result.Message = $"This reservation is already {currentStatus}. Cannot cancel.";
                result.Success = false;
                return result;
            }

            try
            {
                int reservationId = GetReservationIdFromReference(bookingReference);
                if (reservationId > 0)
                {
                    bool success = UpdateReservationStatus(reservationId, 5, "Cancelled");
                    if (success)
                    {
                        result.Message = $"Reservation {bookingReference} has been cancelled successfully. Rooms have been set to Available status.";
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = "Failed to update reservation status in the database.";
                        result.Success = false;
                    }
                }
                else
                {
                    result.Message = "Could not find reservation in the database.";
                    result.Success = false;
                }
            }
            catch (Exception ex)
            {
                result.Message = $"Error cancelling reservation: {ex.Message}";
                result.Success = false;
            }

            return result;
        }

        public HistoryActionResult MarkAsNoShow(string bookingReference, string currentStatus, DateTime checkInDate)
        {
            var result = new HistoryActionResult();

            if (currentStatus?.ToLower() == "no-show" || currentStatus?.ToLower() == "checked-out" || currentStatus?.ToLower() == "cancelled")
            {
                result.Message = $"This reservation is already {currentStatus}. Cannot mark as No Show.";
                result.Success = false;
                return result;
            }

            if (checkInDate.Date > DateTime.Today)
            {
                result.Message = "Cannot mark as No Show before the check-in date.";
                result.Success = false;
                return result;
            }

            try
            {
                int reservationId = GetReservationIdFromReference(bookingReference);
                if (reservationId > 0)
                {
                    bool success = UpdateReservationStatus(reservationId, 6, "No-Show");
                    if (success)
                    {
                        result.Message = $"Reservation {bookingReference} has been marked as No Show. Rooms have been set to Available status.";
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = "Failed to update reservation status in the database.";
                        result.Success = false;
                    }
                }
                else
                {
                    result.Message = "Could not find reservation in the database.";
                    result.Success = false;
                }
            }
            catch (Exception ex)
            {
                result.Message = $"Error marking reservation as No Show: {ex.Message}";
                result.Success = false;
            }

            return result;
        }

        private List<Reservation> GetAllReservationsDirectly(DateTime? fromDate = null, DateTime? toDate = null)
        {
            var reservations = new List<Reservation>();

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            r.*, 
                            COALESCE(g.first_name, 'Unknown') as first_name, 
                            COALESCE(g.last_name, 'Guest') as last_name,
                            CASE 
                                WHEN r.status_id = 1 THEN 'Confirmed'
                                WHEN r.status_id = 2 THEN 'Pending Payment'
                                WHEN r.status_id = 3 THEN 'Checked-in'
                                WHEN r.status_id = 4 THEN 'Checked-out'
                                WHEN r.status_id = 5 THEN 'Cancelled'
                                WHEN r.status_id = 6 THEN 'No-Show'
                                ELSE 'Confirmed'
                            END as status_name,
                            'Standard' as reservation_type,
                            NULL as company_name,
                            'System' as user_name
                        FROM reservations r
                        LEFT JOIN guests g ON r.guest_id = g.guest_id
                        WHERE (@fromDate IS NULL OR r.created_at >= @fromDate)
                          AND (@toDate IS NULL OR r.created_at <= @toDate)
                        ORDER BY r.created_at DESC";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fromDate", fromDate ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@toDate", toDate ?? (object)DBNull.Value);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
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
                                        SpecialRequests = reader["special_requests"]?.ToString() ?? "",
                                        TotalAmount = Convert.ToDecimal(reader["total_amount"]),
                                        CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                        GuestName = $"{reader["first_name"]} {reader["last_name"]}",
                                        StatusName = reader["status_name"].ToString(),
                                        ReservationTypeName = reader["reservation_type"].ToString(),
                                        CompanyName = reader["company_name"]?.ToString(),
                                        UserName = reader["user_name"].ToString()
                                    };

                                    reservation.Rooms = GetReservationRoomsDirectly(reservation.ReservationId);
                                    reservations.Add(reservation);
                                }
                                catch
                                {
                                    // Skip problematic rows
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                // Error handled by caller
            }

            return reservations;
        }

        private List<ReservationRoom> GetReservationRoomsDirectly(int reservationId)
        {
            var rooms = new List<ReservationRoom>();

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT rr.*, 
                               COALESCE(r.room_number, 'Unknown') as room_number, 
                               COALESCE(rt.type_name, 'Standard') as room_type_name
                        FROM reservation_rooms rr
                        LEFT JOIN rooms r ON rr.room_id = r.room_id
                        LEFT JOIN room_types rt ON r.room_type_id = rt.room_type_id
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
                                    RoomNumber = reader["room_number"]?.ToString() ?? "Unknown",
                                    RoomTypeName = reader["room_type_name"]?.ToString() ?? "Standard"
                                });
                            }
                        }
                    }
                }
            }
            catch
            {
                // Return empty list on error
            }

            return rooms;
        }

        private int GetReservationIdFromReference(string bookingReference)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT reservation_id FROM reservations WHERE booking_reference = @bookingReference";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@bookingReference", bookingReference);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        private bool UpdateReservationStatus(int reservationId, int statusId, string statusName)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Update the reservation status
                        string updateReservationQuery = "UPDATE reservations SET status_id = @statusId WHERE reservation_id = @reservationId";
                        using (var reservationCmd = new MySqlCommand(updateReservationQuery, conn, transaction))
                        {
                            reservationCmd.Parameters.AddWithValue("@statusId", statusId);
                            reservationCmd.Parameters.AddWithValue("@reservationId", reservationId);
                            int reservationRowsAffected = reservationCmd.ExecuteNonQuery();

                            if (reservationRowsAffected <= 0)
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }

                        // 2. Get all room IDs from this reservation
                        List<int> roomIds = new List<int>();
                        string getRoomsQuery = "SELECT room_id FROM reservation_rooms WHERE reservation_id = @reservationId";
                        using (var roomsCmd = new MySqlCommand(getRoomsQuery, conn, transaction))
                        {
                            roomsCmd.Parameters.AddWithValue("@reservationId", reservationId);

                            using (var reader = roomsCmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    roomIds.Add(Convert.ToInt32(reader["room_id"]));
                                }
                            }
                        }

                        // 3. Update each room's status to Available (status_id = 1)
                        foreach (int roomId in roomIds)
                        {
                            bool roomUpdated = _roomRepo.UpdateRoomStatus(roomId, 1); // 1 = Available

                            if (!roomUpdated)
                            {
                                // Log warning but continue
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
    }
}