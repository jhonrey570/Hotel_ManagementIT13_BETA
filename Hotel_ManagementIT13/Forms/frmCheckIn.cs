using Hotel_ManagementIT13.Data.Managers;
using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
using Hotel_ManagementIT13.Utilities;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_ManagementIT13.Forms
{
    public partial class frmCheckIn : Form
    {
        private CheckInManager _checkInManager;
        private ReservationRepository _reservationRepo;
        private RoomRepository _roomRepo;
        private GuestManager _guestManager;

        private Reservation _selectedReservation;

        // Missing controls
        private Label lblArrivalsCount;
        private Label lblWalkInRooms;
        private DateTimePicker dtpWalkInCheckOut;
        private NumericUpDown nudWalkInAdults;
        private NumericUpDown nudWalkInChildren;
        private NumericUpDown nudWalkInDeposit;
        private CheckBox chkPrintKeyCard;
        private Button btnRefresh;

        public frmCheckIn()
        {
            InitializeComponent();
            InitializeMissingControls();

            _checkInManager = new CheckInManager();
            _reservationRepo = new ReservationRepository();
            _roomRepo = new RoomRepository();
            _guestManager = new GuestManager();

            InitializeForm();
        }

        private void InitializeMissingControls()
        {
            // Labels for counts
            lblArrivalsCount = new Label
            {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                Location = new Point(40, 20),
                Name = "lblArrivalsCount",
                Size = new Size(150, 20),
                Text = "0 arrival(s) today"
            };

            lblWalkInRooms = new Label
            {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold),
                ForeColor = Color.DarkGreen,
                Location = new Point(40, 460),
                Name = "lblWalkInRooms",
                Size = new Size(200, 20),
                Text = "0 room(s) available for walk-in"
            };

            // Walk-in controls
            dtpWalkInCheckOut = new DateTimePicker
            {
                Font = new Font("Microsoft Sans Serif", 12F),
                Location = new Point(1480, 500),
                Name = "dtpWalkInCheckOut",
                Size = new Size(200, 30),
                Value = DateTime.Today.AddDays(1)
            };

            nudWalkInAdults = new NumericUpDown
            {
                Font = new Font("Microsoft Sans Serif", 12F),
                Location = new Point(1480, 550),
                Minimum = 1,
                Maximum = 10,
                Value = 2,
                Name = "nudWalkInAdults",
                Size = new Size(100, 30)
            };

            nudWalkInChildren = new NumericUpDown
            {
                Font = new Font("Microsoft Sans Serif", 12F),
                Location = new Point(1600, 550),
                Minimum = 0,
                Maximum = 10,
                Value = 0,
                Name = "nudWalkInChildren",
                Size = new Size(100, 30)
            };

            nudWalkInDeposit = new NumericUpDown
            {
                Font = new Font("Microsoft Sans Serif", 12F),
                DecimalPlaces = 2,
                Minimum = 0,
                Maximum = 10000,
                Value = 0,
                Location = new Point(1720, 550),
                Name = "nudWalkInDeposit",
                Size = new Size(150, 30)
            };

            chkPrintKeyCard = new CheckBox
            {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 12F),
                Location = new Point(1480, 600),
                Name = "chkPrintKeyCard",
                Size = new Size(200, 29),
                Text = "Print Key Card",
                Checked = true
            };

            btnRefresh = new Button
            {
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold),
                Location = new Point(1700, 20),
                Name = "btnRefresh",
                Size = new Size(150, 40),
                Text = "REFRESH",
                BackColor = Color.LightBlue
            };
            btnRefresh.Click += btnRefresh_Click;

            // Add controls to form
            this.Controls.Add(lblArrivalsCount);
            this.Controls.Add(lblWalkInRooms);
            this.Controls.Add(dtpWalkInCheckOut);
            this.Controls.Add(nudWalkInAdults);
            this.Controls.Add(nudWalkInChildren);
            this.Controls.Add(nudWalkInDeposit);
            this.Controls.Add(chkPrintKeyCard);
            this.Controls.Add(btnRefresh);
        }

        private void frmCheckIn_Load(object sender, EventArgs e)
        {
            InitializeDataGridViews();
            LoadTodaysArrivals();
            LoadWalkInAvailableRooms();
        }

        private void InitializeForm()
        {
            // Set current date/time
            dtpActualCheckIn.Value = DateTime.Now;

            // Initialize payment method dropdown
            if (cmbPaymentMethod.Items.Count == 0)
            {
                cmbPaymentMethod.Items.AddRange(new string[]
                {
                    "Cash", "Credit Card", "Debit Card", "Bank Transfer", "Check"
                });
                cmbPaymentMethod.SelectedIndex = 0;
            }

            InitializeDataGridViews();
        }

        private void InitializeDataGridViews()
        {
            // Today's arrivals grid - FIXED COLUMNS
            dgvTodayArrivals.Columns.Clear();
            dgvTodayArrivals.Columns.Add("colBookingRef", "Booking #");
            dgvTodayArrivals.Columns.Add("colGuestName", "Guest Name");
            dgvTodayArrivals.Columns.Add("colRoom", "Room");
            dgvTodayArrivals.Columns.Add("colType", "Type");
            dgvTodayArrivals.Columns.Add("colStatus", "Status");
            dgvTodayArrivals.Columns.Add("colArrivalTime", "Arrival");

            dgvTodayArrivals.Columns["colBookingRef"].Width = 100;
            dgvTodayArrivals.Columns["colGuestName"].Width = 150;
            dgvTodayArrivals.Columns["colRoom"].Width = 100;
            dgvTodayArrivals.Columns["colType"].Width = 100;
            dgvTodayArrivals.Columns["colStatus"].Width = 120;
            dgvTodayArrivals.Columns["colArrivalTime"].Width = 80;

            // Walk-in available rooms grid - FIXED COLUMNS
            dgvWalkInAvailable.Columns.Clear();
            dgvWalkInAvailable.Columns.Add("colRoomNumber", "Room #");
            dgvWalkInAvailable.Columns.Add("colType", "Type");
            dgvWalkInAvailable.Columns.Add("colFloor", "Floor");
            dgvWalkInAvailable.Columns.Add("colView", "View");
            dgvWalkInAvailable.Columns.Add("colRate", "Rate/Night");
            dgvWalkInAvailable.Columns.Add("colMaxOccupancy", "Max Guests");

            dgvWalkInAvailable.Columns["colRoomNumber"].Width = 70;
            dgvWalkInAvailable.Columns["colType"].Width = 100;
            dgvWalkInAvailable.Columns["colFloor"].Width = 60;
            dgvWalkInAvailable.Columns["colView"].Width = 100;
            dgvWalkInAvailable.Columns["colRate"].Width = 100;
            dgvWalkInAvailable.Columns["colMaxOccupancy"].Width = 90;

            // Set selection mode
            dgvWalkInAvailable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTodayArrivals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadTodaysArrivals()
        {
            dgvTodayArrivals.Rows.Clear();

            try
            {
                // Use GetTodaysArrivals method from repository
                var arrivals = _reservationRepo.GetTodaysArrivals();

                foreach (var arrival in arrivals)
                {
                    string roomNumbers = string.Join(", ",
                        arrival.Rooms.Select(r => r.RoomNumber));

                    dgvTodayArrivals.Rows.Add(
                        arrival.BookingReference,
                        arrival.GuestName,
                        roomNumbers,
                        arrival.ReservationTypeName,
                        arrival.StatusName,
                        arrival.CheckInDate.ToString("hh:mm tt")
                    );
                }

                lblArrivalsCount.Text = $"{arrivals.Count} arrival(s) today";
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error loading arrivals: {ex.Message}");
            }
        }

        private void LoadWalkInAvailableRooms()
        {
            dgvWalkInAvailable.Rows.Clear();

            try
            {
                DateTime checkIn = DateTime.Today;
                DateTime checkOut = DateTime.Today.AddDays(1);

                var availableRooms = _roomRepo.GetAvailableRooms(checkIn, checkOut);

                foreach (var room in availableRooms)
                {
                    dgvWalkInAvailable.Rows.Add(
                        room.RoomNumber,
                        room.RoomTypeName,
                        room.Floor,
                        room.ViewName,
                        Helper.FormatCurrency(room.BaseRate),
                        room.MaxOccupancy
                    );
                }

                lblWalkInRooms.Text = $"{availableRooms.Count} room(s) available for walk-in";
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error loading available rooms: {ex.Message}");
            }
        }

        private void dgvTodayArrivals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvTodayArrivals.Rows.Count)
            {
                string bookingRef = dgvTodayArrivals.Rows[e.RowIndex].Cells[0].Value?.ToString();
                if (!string.IsNullOrEmpty(bookingRef))
                {
                    LoadReservationDetails(bookingRef, e.RowIndex);
                }
            }
        }

        private void LoadReservationDetails(string bookingReference, int rowIndex)
        {
            try
            {
                _selectedReservation = _reservationRepo.GetReservationByReference(bookingReference);

                if (_selectedReservation != null)
                {
                    // Display reservation details
                    lblGuestName.Text = _selectedReservation.GuestName;
                    lblBookingRef.Text = _selectedReservation.BookingReference;

                    string roomNumbers = string.Join(", ",
                        _selectedReservation.Rooms.Select(r => r.RoomNumber));
                    lblRoomNumber.Text = roomNumbers;

                    // Calculate amount due
                    decimal amountDue = _selectedReservation.TotalAmount;
                    lblAmountDue.Text = Helper.FormatCurrency(amountDue);

                    // Enable check-in button
                    btnProcessCheckIn.Enabled = true;
                    btnPrintKeyCard.Enabled = true;

                    // Highlight the row
                    Helper.HighlightRow(dgvTodayArrivals, rowIndex);
                }
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error loading reservation: {ex.Message}");
            }
        }

        private void btnProcessCheckIn_Click(object sender, EventArgs e)
        {
            if (_selectedReservation == null)
            {
                Helper.ShowError("Please select a reservation");
                return;
            }

            decimal depositAmount = nudDeposit.Value;

            if (depositAmount < 0)
            {
                Helper.ShowError("Deposit amount cannot be negative");
                return;
            }

            try
            {
                var result = _checkInManager.ProcessCheckIn(
                    _selectedReservation.BookingReference,
                    ApplicationContext.CurrentUser?.UserId ?? 1,
                    depositAmount,
                    cmbPaymentMethod.SelectedItem?.ToString() ?? "Cash"
                );

                if (result.Success)
                {
                    Helper.ShowSuccess(result.Message);

                    // Print key card if requested
                    if (chkPrintKeyCard.Checked)
                    {
                        PrintKeyCard(result.Reservation);
                    }

                    // Reset form
                    ResetCheckInForm();
                }
                else
                {
                    Helper.ShowError(result.Message);
                }
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error processing check-in: {ex.Message}");
            }
        }

        private void btnWalkInCheckIn_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (dgvWalkInAvailable.SelectedRows.Count == 0)
            {
                Helper.ShowError("Please select a room");
                return;
            }

            try
            {
                // Get selected room
                string roomNumber = dgvWalkInAvailable.SelectedRows[0].Cells[0].Value?.ToString();
                var room = _roomRepo.GetRoomByNumber(roomNumber);

                if (room == null)
                {
                    Helper.ShowError("Selected room not found");
                    return;
                }

                // Create a simple walk-in guest
                var walkInGuest = new Guest
                {
                    FirstName = "Walk-in",
                    LastName = "Guest",
                    Phone = "000-000-0000",
                    Email = "walkin@hotel.com",
                    GuestTypeId = 1 // Regular
                };

                // Process walk-in check-in
                var result = _checkInManager.ProcessWalkInCheckIn(
                    walkInGuest,
                    dtpActualCheckIn.Value,
                    dtpWalkInCheckOut.Value,
                    room.RoomId,
                    (int)nudWalkInAdults.Value,
                    (int)nudWalkInChildren.Value,
                    ApplicationContext.CurrentUser?.UserId ?? 1,
                    nudWalkInDeposit.Value);

                if (result.Success)
                {
                    Helper.ShowSuccess(result.Message);

                    // Reset form
                    ResetWalkInForm();

                    // Reload data
                    LoadTodaysArrivals();
                    LoadWalkInAvailableRooms();
                }
                else
                {
                    Helper.ShowError(result.Message);
                }
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error processing walk-in check-in: {ex.Message}");
            }
        }

        private void PrintKeyCard(Reservation reservation)
        {
            try
            {
                // Simple key card printing simulation
                string rooms = string.Join(", ", reservation.Rooms.Select(r => r.RoomNumber));
                string message = $"KEY CARD PRINTED\n\n" +
                               $"Guest: {reservation.GuestName}\n" +
                               $"Room(s): {rooms}\n" +
                               $"Check-in: {DateTime.Now:yyyy-MM-dd HH:mm}\n" +
                               $"Check-out: {reservation.CheckOutDate:yyyy-MM-dd}";

                MessageBox.Show(message, "Key Card Printed",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error printing key card: {ex.Message}");
            }
        }

        private void ResetCheckInForm()
        {
            _selectedReservation = null;

            lblGuestName.Text = "---";
            lblBookingRef.Text = "---";
            lblRoomNumber.Text = "---";
            lblAmountDue.Text = "$0.00";

            nudDeposit.Value = 0;
            cmbPaymentMethod.SelectedIndex = 0;
            rtbCheckInNotes.Clear();
            chkPrintKeyCard.Checked = true;

            btnProcessCheckIn.Enabled = false;
            btnPrintKeyCard.Enabled = false;

            // Clear selection
            dgvTodayArrivals.ClearSelection();

            // Reload arrivals
            LoadTodaysArrivals();
        }

        private void ResetWalkInForm()
        {
            // Reset walk-in form controls
            dtpWalkInCheckOut.Value = DateTime.Today.AddDays(1);
            nudWalkInAdults.Value = 2;
            nudWalkInChildren.Value = 0;
            nudWalkInDeposit.Value = 0;

            // Clear selection
            dgvWalkInAvailable.ClearSelection();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTodaysArrivals();
            LoadWalkInAvailableRooms();
        }

        private void btnPrintKeyCard_Click(object sender, EventArgs e)
        {
            if (_selectedReservation != null)
            {
                PrintKeyCard(_selectedReservation);
            }
            else
            {
                Helper.ShowError("Please select a reservation to print key card");
            }
        }

        private void dgvWalkInAvailable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Highlight selected row for walk-in
                Helper.HighlightRow(dgvWalkInAvailable, e.RowIndex);
            }
        }

        // Add this if not already in designer
        private void dgvTodayArrivals_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Auto-size columns after data binding
            foreach (DataGridViewColumn column in dgvTodayArrivals.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void dgvWalkInAvailable_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Auto-size columns after data binding
            foreach (DataGridViewColumn column in dgvWalkInAvailable.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
    }
}