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

        public frmCheckIn()
        {
            InitializeComponent();

            _checkInManager = new CheckInManager();
            _reservationRepo = new ReservationRepository();
            _roomRepo = new RoomRepository();
            _guestManager = new GuestManager();

            InitializeForm();
        }

        private void frmCheckIn_Load(object sender, EventArgs e)
        {
            InitializeDataGridViews();
            LoadTodaysArrivals();
            LoadWalkInAvailableRooms();

            // Wire up events
            dgvTodayArrivals.CellClick += dgvTodayArrivals_CellClick;
            dgvTodayArrivals.SelectionChanged += dgvTodayArrivals_SelectionChanged;
            dgvWalkInAvailable.CellClick += dgvWalkInAvailable_CellClick;
            dgvWalkInAvailable.SelectionChanged += dgvWalkInAvailable_SelectionChanged;
        }

        private void InitializeForm()
        {
            // Set current date/time
            dtpActualCheckIn.Value = DateTime.Now;
            dtpWalkInCheckOut.Value = DateTime.Today.AddDays(1);

            // Initialize payment method dropdowns
            if (cmbPaymentMethod.Items.Count == 0)
            {
                string[] paymentMethods = { "Cash", "Credit Card", "Debit Card", "Bank Transfer", "Check" };
                cmbPaymentMethod.Items.AddRange(paymentMethods);
                cmbPaymentMethod.SelectedIndex = 0;

                cmbWalkInPaymentMethod.Items.AddRange(paymentMethods);
                cmbWalkInPaymentMethod.SelectedIndex = 0;
            }

            // Initialize walk-in controls
            nudWalkInAdults.Value = 1;
            nudWalkInChildren.Value = 0;
            nudWalkInDeposit.Value = 0;
            nudWalkInPaymentAmount.Value = 0;
            chkPrintWalkInKeyCard.Checked = true;

            InitializeDataGridViews();
        }

        private void InitializeDataGridViews()
        {
            // Today's arrivals grid
            dgvTodayArrivals.Columns.Clear();

            // Create columns with proper names
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.Name = "colBookingRef";
            col1.HeaderText = "Booking #";
            col1.Width = 100;
            dgvTodayArrivals.Columns.Add(col1);

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.Name = "colGuestName";
            col2.HeaderText = "Guest Name";
            col2.Width = 150;
            dgvTodayArrivals.Columns.Add(col2);

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.Name = "colRoom";
            col3.HeaderText = "Room";
            col3.Width = 100;
            dgvTodayArrivals.Columns.Add(col3);

            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.Name = "colType";
            col4.HeaderText = "Type";
            col4.Width = 100;
            dgvTodayArrivals.Columns.Add(col4);

            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.Name = "colStatus";
            col5.HeaderText = "Status";
            col5.Width = 120;
            dgvTodayArrivals.Columns.Add(col5);

            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            col6.Name = "colArrivalTime";
            col6.HeaderText = "Arrival";
            col6.Width = 80;
            dgvTodayArrivals.Columns.Add(col6);

            // Walk-in available rooms grid
            dgvWalkInAvailable.Columns.Clear();

            DataGridViewTextBoxColumn col7 = new DataGridViewTextBoxColumn();
            col7.Name = "colRoomNumber";
            col7.HeaderText = "Room #";
            col7.Width = 70;
            dgvWalkInAvailable.Columns.Add(col7);

            DataGridViewTextBoxColumn col8 = new DataGridViewTextBoxColumn();
            col8.Name = "colType";
            col8.HeaderText = "Type";
            col8.Width = 100;
            dgvWalkInAvailable.Columns.Add(col8);

            DataGridViewTextBoxColumn col9 = new DataGridViewTextBoxColumn();
            col9.Name = "colFloor";
            col9.HeaderText = "Floor";
            col9.Width = 60;
            dgvWalkInAvailable.Columns.Add(col9);

            DataGridViewTextBoxColumn col10 = new DataGridViewTextBoxColumn();
            col10.Name = "colView";
            col10.HeaderText = "View";
            col10.Width = 100;
            dgvWalkInAvailable.Columns.Add(col10);

            DataGridViewTextBoxColumn col11 = new DataGridViewTextBoxColumn();
            col11.Name = "colRate";
            col11.HeaderText = "Rate/Night";
            col11.Width = 100;
            dgvWalkInAvailable.Columns.Add(col11);

            DataGridViewTextBoxColumn col12 = new DataGridViewTextBoxColumn();
            col12.Name = "colMaxOccupancy";
            col12.HeaderText = "Max Guests";
            col12.Width = 90;
            dgvWalkInAvailable.Columns.Add(col12);

            // Set selection mode
            dgvWalkInAvailable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTodayArrivals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Allow only single selection
            dgvTodayArrivals.MultiSelect = false;
            dgvWalkInAvailable.MultiSelect = false;
        }

        private void LoadTodaysArrivals()
        {
            dgvTodayArrivals.Rows.Clear();
            _selectedReservation = null; // Clear current selection
            btnProcessCheckIn.Enabled = false;
            btnPrintKeyCard.Enabled = false;

            try
            {
                var arrivals = _reservationRepo.GetTodaysArrivals();

                foreach (var arrival in arrivals)
                {
                    string roomNumbers = string.Join(", ",
                        arrival.Rooms.Select(r => r.RoomNumber));

                    int rowIndex = dgvTodayArrivals.Rows.Add(
                        arrival.BookingReference,
                        arrival.GuestName,
                        roomNumbers,
                        arrival.ReservationTypeName,
                        arrival.StatusName,
                        arrival.CheckInDate.ToString("hh:mm tt")
                    );

                    // Store the reservation ID in the row tag for easy access
                    dgvTodayArrivals.Rows[rowIndex].Tag = arrival;
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
                    // Format room rate with peso sign
                    string formattedRate = FormatCurrencyPeso(room.BaseRate);

                    dgvWalkInAvailable.Rows.Add(
                        room.RoomNumber,
                        room.RoomTypeName,
                        room.Floor,
                        room.ViewName,
                        formattedRate,
                        room.MaxOccupancy
                    );
                }

                lblWalkInRoomsCount.Text = $"{availableRooms.Count} room(s) available for walk-in";
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error loading available rooms: {ex.Message}");
            }
        }

        private void dgvTodayArrivals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Make sure it's a valid row click (not header)
            if (e.RowIndex >= 0 && e.RowIndex < dgvTodayArrivals.Rows.Count)
            {
                string bookingRef = dgvTodayArrivals.Rows[e.RowIndex].Cells["colBookingRef"].Value?.ToString();

                if (!string.IsNullOrEmpty(bookingRef))
                {
                    LoadReservationDetails(bookingRef, e.RowIndex);

                    // Also store the selected row index
                    dgvTodayArrivals.Rows[e.RowIndex].Selected = true;
                }
                else
                {
                    Helper.ShowError("No booking reference found for selected row");
                }
            }
        }

        private void dgvTodayArrivals_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTodayArrivals.SelectedRows.Count > 0)
            {
                string bookingRef = dgvTodayArrivals.SelectedRows[0].Cells["colBookingRef"].Value?.ToString();
                if (!string.IsNullOrEmpty(bookingRef))
                {
                    // Find the row index
                    int rowIndex = dgvTodayArrivals.SelectedRows[0].Index;
                    LoadReservationDetails(bookingRef, rowIndex);
                }
            }
            else
            {
                // Clear selection if nothing is selected
                _selectedReservation = null;
                btnProcessCheckIn.Enabled = false;
                btnPrintKeyCard.Enabled = false;
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

                    // Calculate amount due - format with peso sign
                    decimal amountDue = _selectedReservation.TotalAmount;
                    lblAmountDue.Text = FormatCurrencyPeso(amountDue);

                    // Enable check-in button
                    btnProcessCheckIn.Enabled = true;
                    btnPrintKeyCard.Enabled = true;

                    // Highlight the row
                    Helper.HighlightRow(dgvTodayArrivals, rowIndex);

                    // Set the deposit to a default value (e.g., 20% of total)
                    decimal defaultDeposit = amountDue * 0.2m;
                    nudDeposit.Value = Math.Min(defaultDeposit, nudDeposit.Maximum);
                }
                else
                {
                    Helper.ShowError($"Reservation with reference '{bookingReference}' not found");
                    _selectedReservation = null;
                    btnProcessCheckIn.Enabled = false;
                    btnPrintKeyCard.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error loading reservation: {ex.Message}");
                _selectedReservation = null;
                btnProcessCheckIn.Enabled = false;
                btnPrintKeyCard.Enabled = false;
            }
        }

        private void btnProcessCheckIn_Click(object sender, EventArgs e)
        {
            // First, check if a row is selected in the DataGridView
            if (dgvTodayArrivals.SelectedRows.Count == 0 && _selectedReservation == null)
            {
                Helper.ShowError("Please select a reservation from the list");
                return;
            }

            // If _selectedReservation is null but a row is selected, load it
            if (_selectedReservation == null && dgvTodayArrivals.SelectedRows.Count > 0)
            {
                string bookingRef = dgvTodayArrivals.SelectedRows[0].Cells["colBookingRef"].Value?.ToString();
                if (!string.IsNullOrEmpty(bookingRef))
                {
                    LoadReservationDetails(bookingRef, dgvTodayArrivals.SelectedRows[0].Index);
                }

                if (_selectedReservation == null)
                {
                    Helper.ShowError("Please select a valid reservation");
                    return;
                }
            }

            decimal depositAmount = nudDeposit.Value;

            if (depositAmount < 0)
            {
                Helper.ShowError("Deposit amount cannot be negative");
                nudDeposit.Focus();
                return;
            }

            // Format deposit amount with peso sign
            string formattedDeposit = FormatCurrencyPeso(depositAmount);

            // Confirm check-in
            DialogResult confirm = MessageBox.Show(
                $"Check-in {_selectedReservation.GuestName} to room(s): {lblRoomNumber.Text}?\n\n" +
                $"Deposit: {formattedDeposit}\n" +
                $"Payment Method: {cmbPaymentMethod.SelectedItem}",
                "Confirm Check-in",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                // Show processing message
                Cursor = Cursors.WaitCursor;
                btnProcessCheckIn.Enabled = false;

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
                    if (true) // You can add another checkbox for regular check-ins
                    {
                        PrintKeyCard(result.Reservation);
                    }

                    // Reset form
                    ResetCheckInForm();
                }
                else
                {
                    Helper.ShowError(result.Message);
                    btnProcessCheckIn.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error processing check-in: {ex.Message}");
                btnProcessCheckIn.Enabled = true;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnWalkInCheckIn_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (dgvWalkInAvailable.SelectedRows.Count == 0)
            {
                Helper.ShowError("Please select a room from the available rooms list");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtWalkInFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtWalkInLastName.Text))
            {
                Helper.ShowError("Please enter guest first and last name");
                txtWalkInFirstName.Focus();
                return;
            }

            decimal depositAmount = nudWalkInDeposit.Value;
            decimal paymentAmount = nudWalkInPaymentAmount.Value;

            if (depositAmount < 0)
            {
                Helper.ShowError("Deposit amount cannot be negative");
                nudWalkInDeposit.Focus();
                return;
            }

            if (paymentAmount < 0)
            {
                Helper.ShowError("Payment amount cannot be negative");
                nudWalkInPaymentAmount.Focus();
                return;
            }

            try
            {
                // Get selected room
                string roomNumber = dgvWalkInAvailable.SelectedRows[0].Cells["colRoomNumber"].Value?.ToString();
                var room = _roomRepo.GetRoomByNumber(roomNumber);

                if (room == null)
                {
                    Helper.ShowError("Selected room not found");
                    return;
                }

                // Create walk-in guest
                var walkInGuest = new Guest
                {
                    FirstName = txtWalkInFirstName.Text.Trim(),
                    LastName = txtWalkInLastName.Text.Trim(),
                    Phone = string.IsNullOrWhiteSpace(txtWalkInPhone.Text) ? "000-000-0000" : txtWalkInPhone.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtWalkInEmail.Text) ? "walkin@hotel.com" : txtWalkInEmail.Text.Trim(),
                    GuestTypeId = 1, // Regular
                    CreatedAt = DateTime.Now
                };

                // Get payment method
                string paymentMethod = cmbWalkInPaymentMethod.SelectedItem?.ToString() ?? "Cash";

                // Format amounts with peso sign
                string formattedDeposit = FormatCurrencyPeso(depositAmount);
                string formattedPayment = FormatCurrencyPeso(paymentAmount);

                // Confirm walk-in check-in
                DialogResult confirm = MessageBox.Show(
                    $"Check-in walk-in guest:\n\n" +
                    $"Name: {walkInGuest.FirstName} {walkInGuest.LastName}\n" +
                    $"Room: {room.RoomNumber}\n" +
                    $"Check-out: {dtpWalkInCheckOut.Value:yyyy-MM-dd}\n" +
                    $"Guests: {nudWalkInAdults.Value} adults, {nudWalkInChildren.Value} children\n" +
                    $"Deposit: {formattedDeposit}\n" +
                    $"Payment: {formattedPayment} ({paymentMethod})",
                    "Confirm Walk-in Check-in",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

                // Show processing message
                Cursor = Cursors.WaitCursor;
                btnWalkInCheckIn.Enabled = false;

                // Process walk-in check-in
                var result = _checkInManager.ProcessWalkInCheckIn(
                    walkInGuest,
                    DateTime.Now,
                    dtpWalkInCheckOut.Value,
                    room.RoomId,
                    (int)nudWalkInAdults.Value,
                    (int)nudWalkInChildren.Value,
                    ApplicationContext.CurrentUser?.UserId ?? 1,
                    depositAmount,
                    paymentAmount,
                    paymentMethod);

                if (result.Success)
                {
                    Helper.ShowSuccess(result.Message);

                    // Print key card if requested
                    if (chkPrintWalkInKeyCard.Checked && result.Reservation != null)
                    {
                        PrintKeyCard(result.Reservation);
                    }

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
            finally
            {
                Cursor = Cursors.Default;
                btnWalkInCheckIn.Enabled = true;
            }
        }

        private void PrintKeyCard(Reservation reservation)
        {
            try
            {
                // Simple key card printing simulation
                string rooms = string.Join(", ", reservation.Rooms.Select(r => r.RoomNumber));
                string formattedTotal = FormatCurrencyPeso(reservation.TotalAmount);

                string message = $"KEY CARD PRINTED\n\n" +
                               $"Guest: {reservation.GuestName}\n" +
                               $"Room(s): {rooms}\n" +
                               $"Check-in: {DateTime.Now:yyyy-MM-dd HH:mm}\n" +
                               $"Check-out: {reservation.CheckOutDate:yyyy-MM-dd}\n" +
                               $"Booking Ref: {reservation.BookingReference}\n" +
                               $"Total Amount: {formattedTotal}";

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
            lblAmountDue.Text = "₱0.00";

            nudDeposit.Value = 0;
            cmbPaymentMethod.SelectedIndex = 0;
            rtbCheckInNotes.Clear();

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
            txtWalkInFirstName.Clear();
            txtWalkInLastName.Clear();
            txtWalkInPhone.Clear();
            txtWalkInEmail.Clear();
            dtpWalkInCheckOut.Value = DateTime.Today.AddDays(1);
            nudWalkInAdults.Value = 1;
            nudWalkInChildren.Value = 0;
            nudWalkInDeposit.Value = 0;
            nudWalkInPaymentAmount.Value = 0;
            cmbWalkInPaymentMethod.SelectedIndex = 0;

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

        private void dgvWalkInAvailable_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvWalkInAvailable.SelectedRows.Count > 0)
            {
                string roomNumber = dgvWalkInAvailable.SelectedRows[0].Cells["colRoomNumber"].Value?.ToString();
                if (!string.IsNullOrEmpty(roomNumber))
                {
                    Helper.HighlightRow(dgvWalkInAvailable, dgvWalkInAvailable.SelectedRows[0].Index);
                }
            }
        }

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

        private void dgvTodayArrivals_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Double-click also triggers check-in
            if (e.RowIndex >= 0 && e.RowIndex < dgvTodayArrivals.Rows.Count)
            {
                dgvTodayArrivals_CellClick(sender, e);

                // Auto-process check-in if a reservation is selected
                if (_selectedReservation != null && btnProcessCheckIn.Enabled)
                {
                    btnProcessCheckIn_Click(sender, e);
                }
            }
        }

        private void pnlReservationDetails_Paint(object sender, PaintEventArgs e)
        {
            // Optional: Add custom painting if needed
        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void pnlWalkIn_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblWalkInEmail_Click(object sender, EventArgs e)
        {

        }

        // Helper method to format currency with peso sign
        private string FormatCurrencyPeso(decimal amount)
        {
            return amount.ToString("₱0.00");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}