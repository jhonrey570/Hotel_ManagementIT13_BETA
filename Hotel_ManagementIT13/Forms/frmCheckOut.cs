using Hotel_ManagementIT13.Data.Managers;
using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
using Hotel_ManagementIT13.Utilities;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_ManagementIT13.Forms
{
    public partial class frmCheckOut : Form
    {
        private CheckOutManager _checkOutManager;
        private ReservationRepository _reservationRepo;
        private BillingRepository _billingRepo;
        private Reservation _selectedReservation;

        public frmCheckOut()
        {
            InitializeComponent();
            _checkOutManager = new CheckOutManager();
            _reservationRepo = new ReservationRepository();
            _billingRepo = new BillingRepository();

            // Initialize data grids FIRST
            InitializeDataGrids();

            // Then initialize the rest of the form
            InitializeForm();
        }

        private string FormatPeso(decimal amount)
        {
            return "₱" + amount.ToString("N2");
        }

        private void InitializeForm()
        {
            dtpActualCheckOut.Value = DateTime.Now;
            InitializePaymentMethods();

            // Wire up events
            dgvTodayDepartures.CellClick += dgvTodayDepartures_CellClick;
            dgvTodayDepartures.SelectionChanged += dgvTodayDepartures_SelectionChanged;

            // Disable buttons until guest is selected
            btnProcessCheckOut.Enabled = false;
            btnPrintInvoice.Enabled = false;
            btnAddCharge.Enabled = false;

            // Load data LAST
            LoadCurrentlyCheckedIn();
        }

        private void InitializePaymentMethods()
        {
            cmbPaymentMethod.Items.Clear();
            cmbPaymentMethod.Items.AddRange(new string[]
            {
                "Cash", "Credit Card", "Debit Card", "Bank Transfer", "Check"
            });
            cmbPaymentMethod.SelectedIndex = 0;
        }

        private void InitializeDataGrids()
        {
            // Clear existing columns if any
            dgvTodayDepartures.Columns.Clear();
            dgvBillingItems.Columns.Clear();

            // Today's departures grid - FIXED COLUMN NAMES
            // Create columns with proper names
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.Name = "colBookingRef";
            col1.HeaderText = "Booking #";
            col1.Width = 120;
            dgvTodayDepartures.Columns.Add(col1);

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.Name = "colGuestName";
            col2.HeaderText = "Guest Name";
            col2.Width = 200;
            dgvTodayDepartures.Columns.Add(col2);

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.Name = "colRoom";
            col3.HeaderText = "Room";
            col3.Width = 100;
            dgvTodayDepartures.Columns.Add(col3);

            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.Name = "colAmount";
            col4.HeaderText = "Total Amount";
            col4.Width = 120;
            dgvTodayDepartures.Columns.Add(col4);

            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.Name = "colCheckInTime";
            col5.HeaderText = "Check-in Time";
            col5.Width = 120;
            dgvTodayDepartures.Columns.Add(col5);

            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            col6.Name = "colDepartureTime";
            col6.HeaderText = "Departure";
            col6.Width = 100;
            dgvTodayDepartures.Columns.Add(col6);

            // Add status column
            DataGridViewTextBoxColumn col7 = new DataGridViewTextBoxColumn();
            col7.Name = "colStatus";
            col7.HeaderText = "Status";
            col7.Width = 100;
            dgvTodayDepartures.Columns.Add(col7);

            // Billing items grid
            DataGridViewTextBoxColumn col8 = new DataGridViewTextBoxColumn();
            col8.Name = "colDescription";
            col8.HeaderText = "Description";
            col8.Width = 600;
            dgvBillingItems.Columns.Add(col8);

            DataGridViewTextBoxColumn col9 = new DataGridViewTextBoxColumn();
            col9.Name = "colAmount";
            col9.HeaderText = "Amount";
            col9.Width = 250;
            dgvBillingItems.Columns.Add(col9);

            // Set selection modes
            dgvTodayDepartures.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTodayDepartures.MultiSelect = false;
        }

        private void LoadCurrentlyCheckedIn()
        {
            dgvTodayDepartures.Rows.Clear();
            _selectedReservation = null;
            btnProcessCheckOut.Enabled = false;
            btnAddCharge.Enabled = false;
            btnPrintInvoice.Enabled = false;

            try
            {
                var checkedInGuests = _reservationRepo.GetCurrentlyCheckedIn();

                foreach (var reservation in checkedInGuests)
                {
                    string roomNumbers = string.Join(", ",
                        reservation.Rooms.Select(r => r.RoomNumber));

                    // Get check-in time separately
                    var checkInTime = _reservationRepo.GetCheckInTime(reservation.ReservationId);
                    string checkInTimeStr = checkInTime.HasValue
                        ? checkInTime.Value.ToString("hh:mm tt")
                        : "N/A";

                    string departureTime = reservation.CheckOutDate.ToString("hh:mm tt");

                    int rowIndex = dgvTodayDepartures.Rows.Add(
                        reservation.BookingReference,
                        reservation.GuestName,
                        roomNumbers,
                        FormatPeso(reservation.TotalAmount),
                        checkInTimeStr,
                        departureTime,
                        reservation.StatusName
                    );

                    // Store the reservation in the row tag for easy access
                    dgvTodayDepartures.Rows[rowIndex].Tag = reservation;

                    // Color code based on status
                    if (reservation.StatusId == 3) // Checked-in
                        dgvTodayDepartures.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                    else if (reservation.StatusId == 4) // Checked-out
                        dgvTodayDepartures.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                    else if (reservation.StatusId == 1) // Confirmed
                        dgvTodayDepartures.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                }

                lblDeparturesCount.Text = $"{checkedInGuests.Count} guest(s) currently checked in";
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error loading checked-in guests: {ex.Message}");
            }
        }

        private void dgvTodayDepartures_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvTodayDepartures.Rows.Count)
            {
                string bookingRef = dgvTodayDepartures.Rows[e.RowIndex].Cells["colBookingRef"].Value?.ToString();
                if (!string.IsNullOrEmpty(bookingRef))
                {
                    LoadReservationDetails(bookingRef);
                    Helper.HighlightRow(dgvTodayDepartures, e.RowIndex);
                }
            }
        }

        private void dgvTodayDepartures_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTodayDepartures.SelectedRows.Count > 0)
            {
                string bookingRef = dgvTodayDepartures.SelectedRows[0].Cells["colBookingRef"].Value?.ToString();
                if (!string.IsNullOrEmpty(bookingRef))
                {
                    LoadReservationDetails(bookingRef);
                    Helper.HighlightRow(dgvTodayDepartures, dgvTodayDepartures.SelectedRows[0].Index);
                }
            }
            else
            {
                // Clear selection if nothing is selected
                _selectedReservation = null;
                btnProcessCheckOut.Enabled = false;
                btnAddCharge.Enabled = false;
                btnPrintInvoice.Enabled = false;
            }
        }

        private void LoadReservationDetails(string bookingReference)
        {
            try
            {
                _selectedReservation = _reservationRepo.GetReservationByReference(bookingReference);

                if (_selectedReservation != null)
                {
                    // Display guest information
                    lblGuestName.Text = _selectedReservation.GuestName;
                    lblRoomNumber.Text = string.Join(", ",
                        _selectedReservation.Rooms.Select(r => r.RoomNumber));

                    // Load billing information
                    var billing = _billingRepo.GetBillingByReservationId(_selectedReservation.ReservationId);

                    if (billing != null)
                    {
                        lblTotalBill.Text = FormatPeso(billing.TotalAmount);
                        lblAmountPaid.Text = FormatPeso(billing.PaidAmount);
                        lblBalance.Text = FormatPeso(billing.Balance);

                        // Display billing items
                        DisplayBillingItems(billing);

                        // Set payment amount to remaining balance
                        txtPaymentAmount.Text = billing.Balance.ToString("0.00");
                    }
                    else
                    {
                        lblTotalBill.Text = FormatPeso(_selectedReservation.TotalAmount);
                        lblAmountPaid.Text = "₱0.00";
                        lblBalance.Text = FormatPeso(_selectedReservation.TotalAmount);
                        txtPaymentAmount.Text = _selectedReservation.TotalAmount.ToString("0.00");
                    }

                    // Calculate late checkout fee
                    CalculateLateFee();

                    // Enable/disable buttons based on status
                    if (_selectedReservation.StatusId == 3) // Checked-in
                    {
                        btnProcessCheckOut.Enabled = true;
                        btnAddCharge.Enabled = true;
                        btnPrintInvoice.Enabled = true;
                    }
                    else if (_selectedReservation.StatusId == 4) // Already checked-out
                    {
                        btnProcessCheckOut.Enabled = false;
                        btnAddCharge.Enabled = false;
                        btnPrintInvoice.Enabled = true;
                        MessageBox.Show("This reservation is already checked out.",
                                        "Information",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        btnProcessCheckOut.Enabled = false;
                        btnAddCharge.Enabled = false;
                        btnPrintInvoice.Enabled = false;
                        MessageBox.Show($"This reservation is not checked in. Current status: {_selectedReservation.StatusName}",
                                        "Information",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                }
                else
                {
                    Helper.ShowError($"Reservation with reference '{bookingReference}' not found");
                    _selectedReservation = null;
                    btnProcessCheckOut.Enabled = false;
                    btnAddCharge.Enabled = false;
                    btnPrintInvoice.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error loading reservation: {ex.Message}");
                _selectedReservation = null;
                btnProcessCheckOut.Enabled = false;
                btnAddCharge.Enabled = false;
                btnPrintInvoice.Enabled = false;
            }
        }

        private void DisplayBillingItems(Billing billing)
        {
            dgvBillingItems.Rows.Clear();

            if (_selectedReservation == null) return;

            // Add room charges
            foreach (var room in _selectedReservation.Rooms)
            {
                int nights = (_selectedReservation.CheckOutDate - _selectedReservation.CheckInDate).Days;
                decimal roomTotal = _selectedReservation.TotalAmount / _selectedReservation.Rooms.Count;

                dgvBillingItems.Rows.Add(
                    $"Room {room.RoomNumber} - {nights} night(s)",
                    FormatPeso(roomTotal)
                );
            }

            // Add additional billing items
            if (billing.Items != null)
            {
                foreach (var item in billing.Items)
                {
                    dgvBillingItems.Rows.Add(
                        item.Description,
                        FormatPeso(item.Amount)
                    );
                }
            }
        }

        private void CalculateLateFee()
        {
            if (_selectedReservation == null) return;

            DateTime standardCheckOut = _selectedReservation.CheckOutDate.Date.AddHours(12);
            DateTime actualCheckOut = dtpActualCheckOut.Value;

            if (actualCheckOut > standardCheckOut)
            {
                TimeSpan lateDuration = actualCheckOut - standardCheckOut;
                int lateHours = (int)Math.Ceiling(lateDuration.TotalHours);

                decimal lateFee = lateHours <= 1 ? 50 : 50 + ((lateHours - 1) * 25);
                lblLateFee.Text = FormatPeso(lateFee);
                nudLateCheckoutHours.Value = lateHours;
            }
            else
            {
                lblLateFee.Text = "₱0.00";
                nudLateCheckoutHours.Value = 0;
            }
        }

        private void btnProcessCheckOut_Click(object sender, EventArgs e)
        {
            // First, check if a row is selected in the DataGridView
            if (dgvTodayDepartures.SelectedRows.Count == 0 && _selectedReservation == null)
            {
                Helper.ShowError("Please select a reservation from the list");
                return;
            }

            // If _selectedReservation is null but a row is selected, load it
            if (_selectedReservation == null && dgvTodayDepartures.SelectedRows.Count > 0)
            {
                string bookingRef = dgvTodayDepartures.SelectedRows[0].Cells["colBookingRef"].Value?.ToString();
                if (!string.IsNullOrEmpty(bookingRef))
                {
                    LoadReservationDetails(bookingRef);
                }

                if (_selectedReservation == null)
                {
                    Helper.ShowError("Please select a valid reservation");
                    return;
                }
            }

            // Check if already checked out
            if (_selectedReservation.StatusId == 4)
            {
                Helper.ShowError("This reservation is already checked out");
                return;
            }

            // Check if not checked in
            if (_selectedReservation.StatusId != 3)
            {
                Helper.ShowError("This reservation is not checked in. Status: " + _selectedReservation.StatusName);
                return;
            }

            if (!decimal.TryParse(txtPaymentAmount.Text, out decimal paymentAmount))
            {
                Helper.ShowError("Invalid payment amount");
                txtPaymentAmount.Focus();
                return;
            }

            if (paymentAmount < 0)
            {
                Helper.ShowError("Payment amount cannot be negative");
                txtPaymentAmount.Focus();
                return;
            }

            // Get current user
            var currentUser = ApplicationContext.CurrentUser;
            if (currentUser == null)
            {
                Helper.ShowError("No user logged in. Please login first.");
                return;
            }

            // Confirm check-out
            DialogResult confirm = MessageBox.Show(
                $"Check-out {_selectedReservation.GuestName} from room(s): {lblRoomNumber.Text}?\n\n" +
                $"Check-out Time: {dtpActualCheckOut.Value:yyyy-MM-dd HH:mm}\n" +
                $"Payment Amount: {FormatPeso(paymentAmount)}\n" +
                $"Payment Method: {cmbPaymentMethod.SelectedItem}\n\n" +
                $"Late Fee: {lblLateFee.Text}",
                "Confirm Check-out",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                // Show processing message
                Cursor = Cursors.WaitCursor;
                btnProcessCheckOut.Enabled = false;

                var result = _checkOutManager.ProcessCheckOut(
                    _selectedReservation.BookingReference,
                    currentUser.UserId,
                    dtpActualCheckOut.Value,
                    paymentAmount,
                    cmbPaymentMethod.SelectedItem?.ToString() ?? "Cash",
                    $"Check-out processed by {currentUser.FullName}");

                if (result.Success)
                {
                    Helper.ShowSuccess($"{result.Message}\nReceipt Number: {result.ReceiptNumber}");

                    // Print invoice if requested
                    if (MessageBox.Show("Check-out successful! Print invoice?",
                        "Print Invoice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PrintInvoice(result);
                    }

                    ResetForm();
                }
                else
                {
                    Helper.ShowError(result.Message);
                    btnProcessCheckOut.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error processing check-out: {ex.Message}");
                btnProcessCheckOut.Enabled = true;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnAddCharge_Click(object sender, EventArgs e)
        {
            if (_selectedReservation == null)
            {
                Helper.ShowError("Please select a reservation");
                return;
            }

            if (_selectedReservation.StatusId != 3)
            {
                Helper.ShowError("Cannot add charges. Reservation is not checked in.");
                return;
            }

            // Open dialog to add charge
            using (var dialog = new Form())
            {
                dialog.Text = "Add Additional Charge";
                dialog.Size = new Size(400, 250);
                dialog.StartPosition = FormStartPosition.CenterParent;

                var lblDescription = new Label { Text = "Description:", Left = 20, Top = 20, Width = 100 };
                var txtDescription = new TextBox { Left = 130, Top = 20, Width = 230 };

                var lblAmount = new Label { Text = "Amount:", Left = 20, Top = 70, Width = 100 };
                var txtAmount = new TextBox { Left = 130, Top = 70, Width = 230 };

                var btnOk = new Button { Text = "Add", Left = 130, Top = 120, Width = 100 };
                var btnCancel = new Button { Text = "Cancel", Left = 250, Top = 120, Width = 100 };

                btnOk.Click += (s, ev) => {
                    if (!decimal.TryParse(txtAmount.Text, out decimal amount))
                    {
                        MessageBox.Show("Invalid amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (amount <= 0)
                    {
                        MessageBox.Show("Amount must be greater than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var billing = _billingRepo.GetBillingByReservationId(_selectedReservation.ReservationId);
                    if (billing != null)
                    {
                        _billingRepo.AddBillingItem(billing.BillingId, txtDescription.Text, amount);
                        LoadReservationDetails(_selectedReservation.BookingReference);
                    }

                    dialog.DialogResult = DialogResult.OK;
                };

                btnCancel.Click += (s, ev) => dialog.DialogResult = DialogResult.Cancel;

                dialog.Controls.AddRange(new Control[] { lblDescription, txtDescription, lblAmount, txtAmount, btnOk, btnCancel });

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadReservationDetails(_selectedReservation.BookingReference);
                }
            }
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            if (_selectedReservation == null)
            {
                Helper.ShowError("Please select a reservation");
                return;
            }

            PrintInvoice(null);
        }

        private void PrintInvoice(CheckOutResult checkOutResult = null)
        {
            try
            {
                if (_selectedReservation == null) return;

                // Get check-in time
                var checkInTime = _reservationRepo.GetCheckInTime(_selectedReservation.ReservationId);
                string checkInTimeStr = checkInTime.HasValue
                    ? checkInTime.Value.ToString("yyyy-MM-dd HH:mm")
                    : _selectedReservation.CheckInDate.ToString("yyyy-MM-dd");

                // Simple invoice printing (can be enhanced with ReportViewer)
                string invoiceText = $"========================================\n" +
                                   $"HOTEL MANAGEMENT SYSTEM - INVOICE\n" +
                                   $"========================================\n" +
                                   $"Guest: {_selectedReservation.GuestName}\n" +
                                   $"Booking Reference: {_selectedReservation.BookingReference}\n" +
                                   $"Room(s): {string.Join(", ", _selectedReservation.Rooms.Select(r => r.RoomNumber))}\n" +
                                   $"Check-in: {checkInTimeStr}\n" +
                                   $"Check-out: {dtpActualCheckOut.Value:yyyy-MM-dd HH:mm}\n" +
                                   $"Status: {_selectedReservation.StatusName}\n" +
                                   $"----------------------------------------\n" +
                                   $"BILLING ITEMS:\n";

                var billing = _billingRepo.GetBillingByReservationId(_selectedReservation.ReservationId);
                if (billing != null)
                {
                    foreach (var item in billing.Items)
                    {
                        invoiceText += $"{item.Description}: {FormatPeso(item.Amount)}\n";
                    }

                    invoiceText += $"----------------------------------------\n" +
                                 $"Total: {FormatPeso(billing.TotalAmount)}\n" +
                                 $"Paid: {FormatPeso(billing.PaidAmount)}\n" +
                                 $"Balance: {FormatPeso(billing.Balance)}\n";
                }

                if (checkOutResult != null)
                {
                    invoiceText += $"----------------------------------------\n" +
                                 $"Receipt #: {checkOutResult.ReceiptNumber}\n" +
                                 $"Late Fee: {FormatPeso(checkOutResult.LateFee)}\n" +
                                 $"Processed by: {ApplicationContext.CurrentUser?.FullName}\n" +
                                 $"Date: {DateTime.Now:yyyy-MM-dd HH:mm}\n";
                }

                invoiceText += $"========================================\n" +
                             $"Thank you for staying with us!\n" +
                             $"========================================\n";

                // Show preview
                var previewForm = new Form();
                previewForm.Text = "Invoice Preview";
                previewForm.Size = new Size(500, 600);
                previewForm.StartPosition = FormStartPosition.CenterScreen;

                var textBox = new RichTextBox();
                textBox.Text = invoiceText;
                textBox.Font = new Font("Courier New", 10);
                textBox.Dock = DockStyle.Fill;
                textBox.ReadOnly = true;

                var btnPrint = new Button { Text = "Print", Dock = DockStyle.Bottom, Height = 40 };
                btnPrint.Click += (s, ev) => {
                    // Actual printing logic would go here
                    Helper.ShowSuccess("Invoice sent to printer");
                    previewForm.Close();
                };

                previewForm.Controls.Add(textBox);
                previewForm.Controls.Add(btnPrint);
                previewForm.ShowDialog();
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error printing invoice: {ex.Message}");
            }
        }

        private void ResetForm()
        {
            _selectedReservation = null;

            lblGuestName.Text = "---";
            lblRoomNumber.Text = "---";
            lblTotalBill.Text = "₱0.00";
            lblAmountPaid.Text = "₱0.00";
            lblBalance.Text = "₱0.00";
            lblLateFee.Text = "₱0.00";
            txtPaymentAmount.Clear();
            dgvBillingItems.Rows.Clear();
            nudLateCheckoutHours.Value = 0;
            dtpActualCheckOut.Value = DateTime.Now;

            btnProcessCheckOut.Enabled = false;
            btnAddCharge.Enabled = false;
            btnPrintInvoice.Enabled = false;

            LoadCurrentlyCheckedIn();
        }

        private void dtpActualCheckOut_ValueChanged(object sender, EventArgs e)
        {
            CalculateLateFee();
        }

        private void nudLateCheckoutHours_ValueChanged(object sender, EventArgs e)
        {
            if (_selectedReservation == null) return;

            int lateHours = (int)nudLateCheckoutHours.Value;
            decimal lateFee = lateHours <= 0 ? 0 : (lateHours <= 1 ? 50 : 50 + ((lateHours - 1) * 25));
            lblLateFee.Text = FormatPeso(lateFee);

            // Update check-out time
            DateTime standardCheckOut = _selectedReservation.CheckOutDate.Date.AddHours(12);
            dtpActualCheckOut.Value = standardCheckOut.AddHours(lateHours);
        }

        private void frmCheckOut_Load(object sender, EventArgs e)
        {
            // Form load event - already initialized in constructor
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCurrentlyCheckedIn();
            ResetForm();
        }

        private void dgvTodayDepartures_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Double-click also triggers check-out
            if (e.RowIndex >= 0 && e.RowIndex < dgvTodayDepartures.Rows.Count)
            {
                dgvTodayDepartures_CellClick(sender, e);

                // Auto-process check-out if a reservation is selected
                if (_selectedReservation != null && btnProcessCheckOut.Enabled)
                {
                    btnProcessCheckOut_Click(sender, e);
                }
            }
        }

        private void dgvTodayDepartures_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Auto-size columns after data binding
            foreach (DataGridViewColumn column in dgvTodayDepartures.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        public frmCheckOut(bool designMode = false) : this()
        {
            if (designMode)
            {
                // Constructor for designer support
            }
        }

        private void frmCheckOut_Load_1(object sender, EventArgs e)
        {

        }
    }
}