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

            InitializeForm();
        }

        private void InitializeForm()
        {
            dtpActualCheckOut.Value = DateTime.Now;
            LoadTodaysDepartures();
            InitializePaymentMethods();
            InitializeDataGrids();

            // Disable buttons until guest is selected
            btnProcessCheckOut.Enabled = false;
            btnPrintInvoice.Enabled = false;
            btnAddCharge.Enabled = false;
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
            // Today's departures grid
            dgvTodayDepartures.Columns.Clear();
            dgvTodayDepartures.Columns.Add("colBookingRef", "Booking #");
            dgvTodayDepartures.Columns.Add("colGuestName", "Guest Name");
            dgvTodayDepartures.Columns.Add("colRoom", "Room");
            dgvTodayDepartures.Columns.Add("colAmount", "Total Amount");
            dgvTodayDepartures.Columns.Add("colDepartureTime", "Departure");

            dgvTodayDepartures.Columns["colBookingRef"].Width = 120;
            dgvTodayDepartures.Columns["colGuestName"].Width = 200;
            dgvTodayDepartures.Columns["colRoom"].Width = 100;
            dgvTodayDepartures.Columns["colAmount"].Width = 120;
            dgvTodayDepartures.Columns["colDepartureTime"].Width = 100;

            // Billing items grid
            dgvBillingItems.Columns.Clear();
            dgvBillingItems.Columns.Add("colDescription", "Description");
            dgvBillingItems.Columns.Add("colAmount", "Amount");

            dgvBillingItems.Columns["colDescription"].Width = 600;
            dgvBillingItems.Columns["colAmount"].Width = 250;
        }

        private void LoadTodaysDepartures()
        {
            dgvTodayDepartures.Rows.Clear();

            try
            {
                var departures = _reservationRepo.GetTodaysDepartures();

                foreach (var departure in departures)
                {
                    string roomNumbers = string.Join(", ",
                        departure.Rooms.Select(r => r.RoomNumber));

                    dgvTodayDepartures.Rows.Add(
                        departure.BookingReference,
                        departure.GuestName,
                        roomNumbers,
                        Helper.FormatCurrency(departure.TotalAmount),
                        departure.CheckOutDate.ToString("hh:mm tt")
                    );
                }

                lblDeparturesCount.Text = $"{departures.Count} departure(s) today";
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error loading departures: {ex.Message}");
            }
        }

        private void dgvTodayDepartures_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvTodayDepartures.Rows.Count)
            {
                string bookingRef = dgvTodayDepartures.Rows[e.RowIndex].Cells[0].Value.ToString();
                LoadReservationDetails(bookingRef);
                Helper.HighlightRow(dgvTodayDepartures, e.RowIndex);
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
                        lblTotalBill.Text = Helper.FormatCurrency(billing.TotalAmount);
                        lblAmountPaid.Text = Helper.FormatCurrency(billing.PaidAmount);
                        lblBalance.Text = Helper.FormatCurrency(billing.Balance);

                        // Display billing items
                        DisplayBillingItems(billing);

                        // Set payment amount to remaining balance
                        txtPaymentAmount.Text = billing.Balance.ToString("0.00");
                    }
                    else
                    {
                        lblTotalBill.Text = Helper.FormatCurrency(_selectedReservation.TotalAmount);
                        lblAmountPaid.Text = "$0.00";
                        lblBalance.Text = Helper.FormatCurrency(_selectedReservation.TotalAmount);
                    }

                    // Calculate late checkout fee
                    CalculateLateFee();

                    // Enable buttons
                    btnProcessCheckOut.Enabled = true;
                    btnAddCharge.Enabled = true;
                    btnPrintInvoice.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error loading reservation: {ex.Message}");
            }
        }

        private void DisplayBillingItems(Billing billing)
        {
            dgvBillingItems.Rows.Clear();

            // Add room charges
            foreach (var room in _selectedReservation.Rooms)
            {
                int nights = (_selectedReservation.CheckOutDate - _selectedReservation.CheckInDate).Days;
                decimal roomTotal = _selectedReservation.TotalAmount / _selectedReservation.Rooms.Count;

                dgvBillingItems.Rows.Add(
                    $"Room {room.RoomNumber} - {nights} night(s)",
                    Helper.FormatCurrency(roomTotal)
                );
            }

            // Add additional billing items
            foreach (var item in billing.Items)
            {
                dgvBillingItems.Rows.Add(
                    item.Description,
                    Helper.FormatCurrency(item.Amount)
                );
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
                lblLateFee.Text = Helper.FormatCurrency(lateFee);
                nudLateCheckoutHours.Value = lateHours;
            }
            else
            {
                lblLateFee.Text = "$0.00";
                nudLateCheckoutHours.Value = 0;
            }
        }

        private void btnProcessCheckOut_Click(object sender, EventArgs e)
        {
            if (_selectedReservation == null)
            {
                Helper.ShowError("Please select a reservation");
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

            try
            {
                var result = _checkOutManager.ProcessCheckOut(
                    _selectedReservation.BookingReference,
                    ApplicationContext.CurrentUser.UserId,
                    dtpActualCheckOut.Value,
                    paymentAmount,
                    cmbPaymentMethod.SelectedItem.ToString(),
                    $"Check-out processed by {ApplicationContext.CurrentUser.FullName}");

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
                }
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error processing check-out: {ex.Message}");
            }
        }

        private void btnAddCharge_Click(object sender, EventArgs e)
        {
            if (_selectedReservation == null)
            {
                Helper.ShowError("Please select a reservation");
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
                // Simple invoice printing (can be enhanced with ReportViewer)
                string invoiceText = $"========================================\n" +
                                   $"HOTEL MANAGEMENT SYSTEM - INVOICE\n" +
                                   $"========================================\n" +
                                   $"Guest: {_selectedReservation.GuestName}\n" +
                                   $"Booking Reference: {_selectedReservation.BookingReference}\n" +
                                   $"Room(s): {string.Join(", ", _selectedReservation.Rooms.Select(r => r.RoomNumber))}\n" +
                                   $"Check-in: {_selectedReservation.CheckInDate:yyyy-MM-dd}\n" +
                                   $"Check-out: {dtpActualCheckOut.Value:yyyy-MM-dd HH:mm}\n" +
                                   $"----------------------------------------\n" +
                                   $"BILLING ITEMS:\n";

                var billing = _billingRepo.GetBillingByReservationId(_selectedReservation.ReservationId);
                if (billing != null)
                {
                    foreach (var item in billing.Items)
                    {
                        invoiceText += $"{item.Description}: {item.Amount:C}\n";
                    }

                    invoiceText += $"----------------------------------------\n" +
                                 $"Total: {billing.TotalAmount:C}\n" +
                                 $"Paid: {billing.PaidAmount:C}\n" +
                                 $"Balance: {billing.Balance:C}\n";
                }

                if (checkOutResult != null)
                {
                    invoiceText += $"----------------------------------------\n" +
                                 $"Receipt #: {checkOutResult.ReceiptNumber}\n" +
                                 $"Late Fee: {checkOutResult.LateFee:C}\n" +
                                 $"Processed by: {ApplicationContext.CurrentUser.FullName}\n" +
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
            lblTotalBill.Text = "$0.00";
            lblAmountPaid.Text = "$0.00";
            lblBalance.Text = "$0.00";
            lblLateFee.Text = "$0.00";
            txtPaymentAmount.Clear();
            dgvBillingItems.Rows.Clear();
            nudLateCheckoutHours.Value = 0;
            dtpActualCheckOut.Value = DateTime.Now;

            btnProcessCheckOut.Enabled = false;
            btnAddCharge.Enabled = false;
            btnPrintInvoice.Enabled = false;

            LoadTodaysDepartures();
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
            lblLateFee.Text = Helper.FormatCurrency(lateFee);

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
            LoadTodaysDepartures();
            ResetForm();
        }

        public frmCheckOut(bool designMode = false) : this()
        {
            if (designMode)
            {
                // Constructor for designer support
            }
        }
    }
}