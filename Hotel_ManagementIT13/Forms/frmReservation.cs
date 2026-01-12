using Hotel_ManagementIT13.Data.Managers;
using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Services;
using Hotel_ManagementIT13.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_ManagementIT13.Forms
{
    public partial class frmReservation : Form
    {
        private ReservationService _reservationService;
        private GuestService _guestService;
        private RoomService _roomService;
        private HistoryTabService _historyTabService;
        private List<Guest> _searchResults;
        private List<Room> _availableRooms;
        private Guest _selectedGuest;
        private List<int> _selectedRoomIds;

        private const int _currentUserId = 1;
        private bool _historyTabInitialized = false;
        private bool _historyDataLoaded = false;

        public frmReservation()
        {
            InitializeComponent();
            InitializeServices();
            _searchResults = new List<Guest>();
            _availableRooms = new List<Room>();
            _selectedRoomIds = new List<int>();
        }

        private void InitializeServices()
        {
            _reservationService = new ReservationService();
            _guestService = new GuestService();
            _roomService = new RoomService();
            _historyTabService = new HistoryTabService();
        }

        private void frmReservation_Load(object sender, EventArgs e)
        {
            InitializeForm();
            LoadAllGuests();
            LoadAvailableRoomsFromDatabase();
        }

        private void InitializeForm()
        {
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);

            LoadRoomTypesFromDatabase();
            LoadSpecialRequests();
            InitializeDataGrids();

            lblSelectedGuest.Text = "No guest selected";
            lblSelectedGuest.ForeColor = Color.Red;
            lblTotalAmount.Text = "₱0.00";
            lblSearchResults.Text = "Found 0 guest(s)";
            lblAvailableRooms.Text = "Available: 0 room(s)";

            EnableBookingControls(false);
        }

        private void LoadAllGuests()
        {
            try
            {
                lblSearchResults.Text = "Loading guests...";
                Application.DoEvents();

                var result = _guestService.LoadAllGuests();
                _searchResults = result.Guests;
                lblSearchResults.Text = result.Message;

                DisplayGuestResults();
            }
            catch (Exception ex)
            {
                lblSearchResults.Text = "Error loading guests";
                MessageBox.Show($"Error loading guests from database: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _searchResults = new List<Guest>();
                DisplayGuestResults();
            }
        }

        private void LoadAvailableRoomsFromDatabase()
        {
            try
            {
                lblAvailableRooms.Text = "Loading rooms...";
                Application.DoEvents();

                var result = _roomService.LoadAvailableRooms();
                _availableRooms = result.Rooms;
                lblAvailableRooms.Text = result.Message;

                DisplayAvailableRooms();
            }
            catch (Exception ex)
            {
                lblAvailableRooms.Text = "Error loading rooms";
                MessageBox.Show($"Error loading rooms from database: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRoomTypesFromDatabase()
        {
            try
            {
                cmbRoomType.Items.Clear();
                cmbRoomType.Items.Add("All Types");

                var roomTypes = _roomService.GetRoomTypes(_availableRooms);
                foreach (var type in roomTypes)
                {
                    cmbRoomType.Items.Add(type);
                }

                cmbRoomType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading room types: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbRoomType.Items.Add("All Types");
                cmbRoomType.SelectedIndex = 0;
            }
        }

        private void LoadSpecialRequests()
        {
            try
            {
                clbSpecialRequests.Items.Clear();
                var result = _reservationService.LoadSpecialRequests();

                if (result.Success)
                {
                    foreach (var amenity in result.Amenities)
                    {
                        clbSpecialRequests.Items.Add(amenity.AmenityName, false);
                    }
                }
                else
                {
                    MessageBox.Show(result.Message, "No Amenities",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading amenities from database: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeDataGrids()
        {
            try
            {
                dgvGuestResults.Columns.Clear();
                dgvGuestResults.Rows.Clear();
                dgvAvailableRooms.Columns.Clear();
                dgvAvailableRooms.Rows.Clear();

                SetupGuestGrid();
                SetupRoomsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing grids: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupGuestGrid()
        {
            _guestService.SetupGuestGrid(dgvGuestResults);
        }

        private void SetupRoomsGrid()
        {
            _roomService.SetupRoomsGrid(dgvAvailableRooms);
            dgvAvailableRooms.CurrentCellDirtyStateChanged += dgvAvailableRooms_CurrentCellDirtyStateChanged;
            dgvAvailableRooms.CellValueChanged += dgvAvailableRooms_CellValueChanged;
        }

        private void btnSearchGuest_Click(object sender, EventArgs e)
        {
            SearchGuests();
        }

        private void SearchGuests()
        {
            string searchTerm = txtGuestSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                LoadAllGuests();
                return;
            }

            try
            {
                lblSearchResults.Text = "Searching...";
                Application.DoEvents();

                var result = _guestService.SearchGuests(searchTerm);
                _searchResults = result.Guests;
                lblSearchResults.Text = result.Message;

                if (!result.Success)
                {
                    MessageBox.Show(result.Message, "Search Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                DisplayGuestResults();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching guests: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _searchResults = new List<Guest>();
                DisplayGuestResults();
            }
        }

        private void DisplayGuestResults()
        {
            try
            {
                dgvGuestResults.Rows.Clear();

                foreach (var guest in _searchResults)
                {
                    int rowIndex = dgvGuestResults.Rows.Add(
                        guest.GuestId,
                        guest.FullName ?? "",
                        guest.Phone ?? "",
                        guest.Email ?? "",
                        guest.GuestTypeName ?? ""
                    );

                    dgvGuestResults.Rows[rowIndex].Cells["SelectAction"].Value = "Select";
                }

                lblSearchResults.Text = $"Found {_searchResults.Count} guest(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying guests: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvGuestResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvGuestResults.Rows.Count)
            {
                try
                {
                    if (e.ColumnIndex == dgvGuestResults.Columns["SelectAction"].Index)
                    {
                        SelectGuestFromRow(e.RowIndex);
                    }
                    else
                    {
                        SelectGuestFromRow(e.RowIndex);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error selecting guest: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SelectGuestFromRow(int rowIndex)
        {
            var row = dgvGuestResults.Rows[rowIndex];
            int guestId = Convert.ToInt32(row.Cells["GuestId"].Value);
            _selectedGuest = _searchResults.FirstOrDefault(g => g.GuestId == guestId);

            if (_selectedGuest != null)
            {
                DisplaySelectedGuest();

                foreach (DataGridViewRow r in dgvGuestResults.Rows)
                {
                    r.DefaultCellStyle.BackColor = Color.White;
                }
                row.DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void DisplaySelectedGuest()
        {
            if (_selectedGuest != null)
            {
                lblSelectedGuest.Text = $"Selected: {_selectedGuest.FullName}";
                lblSelectedGuest.ForeColor = Color.Green;
                EnableBookingControls(true);
                SearchAvailableRooms();
            }
        }

        private void EnableBookingControls(bool enable)
        {
            dtpCheckIn.Enabled = enable;
            dtpCheckOut.Enabled = enable;
            nudAdults.Enabled = enable;
            nudChildren.Enabled = enable;
            cmbRoomType.Enabled = enable;
            btnCalculate.Enabled = enable;
            btnBook.Enabled = enable;
        }

        private void SearchAvailableRooms()
        {
            if (_selectedGuest == null) return;

            DateTime checkIn = dtpCheckIn.Value;
            DateTime checkOut = dtpCheckOut.Value;

            if (checkOut <= checkIn)
            {
                MessageBox.Show("Check-out date must be after check-in date", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string selectedType = cmbRoomType.SelectedItem?.ToString();
                lblAvailableRooms.Text = "Searching available rooms...";
                Application.DoEvents();

                var result = _roomService.SearchAvailableRooms(checkIn, checkOut, selectedType, _availableRooms);
                _availableRooms = result.Rooms;
                lblAvailableRooms.Text = result.Message;

                DisplayAvailableRooms();
                _selectedRoomIds.Clear();
                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching rooms: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayAvailableRooms()
        {
            try
            {
                dgvAvailableRooms.Rows.Clear();

                if (_availableRooms == null || _availableRooms.Count == 0)
                {
                    lblAvailableRooms.Text = "Available: 0 room(s)";
                    return;
                }

                foreach (var room in _availableRooms)
                {
                    string statusDisplay = StatusHelper.GetStatusDisplayText(room.StatusId);
                    Color statusColor = StatusHelper.GetStatusColor(room.StatusId);

                    int rowIndex = dgvAvailableRooms.Rows.Add(
                        false,
                        room.RoomId,
                        room.RoomNumber ?? "",
                        room.RoomTypeName ?? "Unknown",
                        room.Floor,
                        room.ViewName ?? "",
                        statusDisplay,
                        room.BaseRate.ToString("C").Replace("$", "₱")
                    );

                    if (rowIndex >= 0)
                    {
                        dgvAvailableRooms.Rows[rowIndex].Cells["Status"].Style.ForeColor = statusColor;
                    }
                }

                lblAvailableRooms.Text = $"Available: {_availableRooms.Count} room(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying rooms: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            try
            {
                if (_selectedGuest == null || _selectedRoomIds.Count == 0)
                {
                    lblTotalAmount.Text = "₱0.00";
                    return;
                }

                DateTime checkIn = dtpCheckIn.Value;
                DateTime checkOut = dtpCheckOut.Value;

                if (checkOut <= checkIn)
                {
                    lblTotalAmount.Text = "₱0.00";
                    return;
                }

                int nights = (checkOut - checkIn).Days;
                decimal totalAmount = 0;

                foreach (int roomId in _selectedRoomIds)
                {
                    var room = _availableRooms.FirstOrDefault(r => r.RoomId == roomId);
                    if (room != null)
                    {
                        totalAmount += room.BaseRate * nights;
                    }
                }

                int selectedAmenitiesCount = 0;
                for (int i = 0; i < clbSpecialRequests.Items.Count; i++)
                {
                    if (clbSpecialRequests.GetItemChecked(i))
                    {
                        selectedAmenitiesCount++;
                    }
                }

                decimal amenityFees = selectedAmenitiesCount * _reservationService.GetAmenityFee();
                totalAmount += amenityFees;

                lblTotalAmount.Text = totalAmount.ToString("₱0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating total: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTotalAmount.Text = "₱0.00";
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (!ValidateBooking()) return;

            try
            {
                string specialRequests = GetSpecialRequests();

                var reservation = new Reservation
                {
                    GuestId = _selectedGuest.GuestId,
                    UserId = _currentUserId,
                    CompanyId = null,
                    StatusId = 1,
                    ReservationTypeId = 1,
                    BookingReference = _reservationService.GenerateBookingReference(),
                    CheckInDate = dtpCheckIn.Value,
                    CheckOutDate = dtpCheckOut.Value,
                    Adults = (int)nudAdults.Value,
                    Children = (int)nudChildren.Value,
                    SpecialRequests = specialRequests,
                    TotalAmount = decimal.Parse(lblTotalAmount.Text.Replace("₱", "").Replace(",", "")),
                    CreatedAt = DateTime.Now
                };

                foreach (int roomId in _selectedRoomIds)
                {
                    var room = _availableRooms.FirstOrDefault(r => r.RoomId == roomId);
                    if (room != null)
                    {
                        reservation.Rooms.Add(new ReservationRoom
                        {
                            RoomId = room.RoomId,
                            RoomNumber = room.RoomNumber,
                            RoomTypeName = room.RoomTypeName,
                            RoomRate = room.BaseRate
                        });
                    }
                }

                var result = _reservationService.CreateReservation(reservation);

                if (result.Success)
                {
                    string roomNumbers = string.Join(", ", reservation.Rooms.Select(r => r.RoomNumber));
                    string confirmationMessage = $"RESERVATION CONFIRMED!\n\n" +
                                               $"Booking Reference: {reservation.BookingReference}\n" +
                                               $"Reservation ID: {result.ReservationId}\n" +
                                               $"Guest: {_selectedGuest.FullName}\n" +
                                               $"Check-in: {reservation.CheckInDate:yyyy-MM-dd}\n" +
                                               $"Check-out: {reservation.CheckOutDate:yyyy-MM-dd}\n" +
                                               $"Rooms: {roomNumbers}\n" +
                                               $"Total: {lblTotalAmount.Text}\n\n" +
                                               $"Reservation has been saved to database.";

                    MessageBox.Show(confirmationMessage, "Booking Confirmed",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ResetForm();

                    _reservationService.RefreshDatabaseConnection();

                    tabReservation.SelectedTab = tabPage2;

                    ForceRefreshReservationHistory();
                }
                else
                {
                    MessageBox.Show(result.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating reservation: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ForceRefreshReservationHistory()
        {
            try
            {
                _historyTabInitialized = false;
                _historyDataLoaded = false;

                tabPage2.Controls.Clear();

                Application.DoEvents();
                System.Threading.Thread.Sleep(200);

                LoadReservationHistory();

                tabPage2.Refresh();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing history: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateBooking()
        {
            return _reservationService.ValidateBooking(_selectedGuest, _selectedRoomIds, _availableRooms,
                dtpCheckIn.Value, dtpCheckOut.Value, (int)nudAdults.Value);
        }

        private string GetSpecialRequests()
        {
            List<string> requests = new List<string>();

            for (int i = 0; i < clbSpecialRequests.Items.Count; i++)
            {
                if (clbSpecialRequests.GetItemChecked(i))
                {
                    requests.Add(clbSpecialRequests.Items[i].ToString());
                }
            }

            if (!string.IsNullOrWhiteSpace(rtbNotes.Text))
            {
                requests.Add($"Notes: {rtbNotes.Text}");
            }

            return string.Join("; ", requests);
        }

        private void ResetForm()
        {
            try
            {
                txtGuestSearch.Clear();
                _selectedGuest = null;
                _selectedRoomIds.Clear();
                dgvAvailableRooms.Rows.Clear();

                lblSelectedGuest.Text = "No guest selected";
                lblSelectedGuest.ForeColor = Color.Red;
                lblTotalAmount.Text = "₱0.00";
                lblAvailableRooms.Text = "Available: 0 room(s)";

                dtpCheckIn.Value = DateTime.Today;
                dtpCheckOut.Value = DateTime.Today.AddDays(1);
                nudAdults.Value = 1;
                nudChildren.Value = 0;
                cmbRoomType.SelectedIndex = 0;

                for (int i = 0; i < clbSpecialRequests.Items.Count; i++)
                {
                    clbSpecialRequests.SetItemChecked(i, false);
                }

                rtbNotes.Clear();
                EnableBookingControls(false);
                LoadAvailableRoomsFromDatabase();

                foreach (DataGridViewRow row in dgvGuestResults.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error resetting form: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheckOut.Value <= dtpCheckIn.Value)
            {
                dtpCheckOut.Value = dtpCheckIn.Value.AddDays(1);
            }

            if (_selectedGuest != null)
            {
                SearchAvailableRooms();
            }
        }

        private void dtpCheckOut_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheckOut.Value <= dtpCheckIn.Value)
            {
                dtpCheckIn.Value = dtpCheckOut.Value.AddDays(-1);
            }

            if (_selectedGuest != null)
            {
                SearchAvailableRooms();
            }
        }

        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectedGuest != null)
            {
                SearchAvailableRooms();
            }
        }

        private void dgvAvailableRooms_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                try
                {
                    var row = dgvAvailableRooms.Rows[e.RowIndex];
                    bool isChecked = false;

                    if (row.Cells["Select"].Value != null)
                    {
                        isChecked = Convert.ToBoolean(row.Cells["Select"].Value);
                    }

                    int roomId = Convert.ToInt32(row.Cells["RoomId"].Value);

                    if (isChecked)
                    {
                        if (!_selectedRoomIds.Contains(roomId))
                            _selectedRoomIds.Add(roomId);
                    }
                    else
                    {
                        _selectedRoomIds.Remove(roomId);
                    }

                    CalculateTotal();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating selection: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvAvailableRooms_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvAvailableRooms.IsCurrentCellDirty && dgvAvailableRooms.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvAvailableRooms.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnNewGuest_Click(object sender, EventArgs e)
        {
            try
            {
                frmGuestManagement guestForm = new frmGuestManagement();
                if (guestForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAllGuests();
                    MessageBox.Show("Guest added successfully! The guest list has been refreshed.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening guest form: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel? Unsaved changes will be lost.",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_selectedGuest == null || _selectedRoomIds.Count == 0)
            {
                MessageBox.Show("No booking to print", "Print",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string roomNumbers = string.Join(", ",
                _selectedRoomIds.Select(id =>
                    _availableRooms.FirstOrDefault(r => r.RoomId == id)?.RoomNumber ?? "Unknown"));

            string printContent = $"HOTEL MANAGEMENT SYSTEM - RESERVATION CONFIRMATION\n" +
                                $"====================================================\n\n" +
                                $"Guest Information:\n" +
                                $"  Name: {_selectedGuest.FullName}\n" +
                                $"  Email: {_selectedGuest.Email}\n" +
                                $"  Phone: {_selectedGuest.Phone}\n" +
                                $"  Guest Type: {_selectedGuest.GuestTypeName}\n\n" +
                                $"Reservation Details:\n" +
                                $"  Check-in: {dtpCheckIn.Value:dddd, MMMM dd, yyyy}\n" +
                                $"  Check-out: {dtpCheckOut.Value:dddd, MMMM dd, yyyy}\n" +
                                $"  Duration: {(dtpCheckOut.Value - dtpCheckIn.Value).Days} nights\n" +
                                $"  Rooms: {roomNumbers}\n" +
                                $"  Adults: {nudAdults.Value}, Children: {nudChildren.Value}\n\n" +
                                $"Financial Summary:\n" +
                                $"  Total Amount: {lblTotalAmount.Text}\n" +
                                $"  Booking Date: {DateTime.Now:yyyy-MM-dd HH:mm}\n\n" +
                                $"Special Requests:\n{GetSpecialRequests()}\n\n" +
                                $"Thank you for choosing our hotel!";

            MessageBox.Show(printContent, "Booking Confirmation - Printable",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtGuestSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SearchGuests();
                e.Handled = true;
            }
        }

        private void dgvGuestResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvGuestResults.Rows.Count)
            {
                SelectGuestFromRow(e.RowIndex);
            }
        }

        private void tabReservation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabReservation.SelectedTab == tabPage2)
            {
                LoadReservationHistory();
            }
        }

        private void SetupReservationHistoryTab()
        {
            if (_historyTabInitialized && tabPage2.Controls.Count > 0)
            {
                return;
            }

            tabPage2.Controls.Clear();
            _historyTabService.SetupReservationHistoryTab(tabPage2);

            var btnRefreshHistory = tabPage2.Controls.Find("btnRefreshHistory", true).FirstOrDefault() as Button;
            var btnCancelReservation = tabPage2.Controls.Find("btnCancelReservation", true).FirstOrDefault() as Button;
            var btnNoShow = tabPage2.Controls.Find("btnNoShow", true).FirstOrDefault() as Button;
            var btnFilterHistory = tabPage2.Controls.Find("btnFilterHistory", true).FirstOrDefault() as Button;

            if (btnRefreshHistory != null) btnRefreshHistory.Click += BtnRefreshHistory_Click;
            if (btnCancelReservation != null) btnCancelReservation.Click += BtnCancelReservation_Click;
            if (btnNoShow != null) btnNoShow.Click += BtnNoShow_Click;
            if (btnFilterHistory != null) btnFilterHistory.Click += BtnFilterHistory_Click;

            _historyTabInitialized = true;
        }

        private void LoadReservationHistory()
        {
            if (_historyDataLoaded && _historyTabInitialized)
            {
                return;
            }

            try
            {
                if (!_historyTabInitialized)
                {
                    SetupReservationHistoryTab();
                }

                DataGridView dgvReservationHistory = null;
                DateTimePicker dtpFromDate = null;
                DateTimePicker dtpToDate = null;

                foreach (Control control in tabPage2.Controls)
                {
                    if (control is DataGridView dgv)
                    {
                        dgvReservationHistory = dgv;
                    }
                    else if (control is Panel panel)
                    {
                        foreach (Control panelControl in panel.Controls)
                        {
                            if (panelControl is DateTimePicker dtp)
                            {
                                if (panelControl.Name == "dtpFromDate")
                                    dtpFromDate = dtp;
                                else if (panelControl.Name == "dtpToDate")
                                    dtpToDate = dtp;
                            }
                        }
                    }
                }

                if (dgvReservationHistory == null)
                {
                    SetupReservationHistoryTab();
                    LoadReservationHistory();
                    return;
                }

                var result = _historyTabService.LoadReservationHistory(dtpFromDate?.Value, dtpToDate?.Value);
                _historyTabService.DisplayReservationHistory(dgvReservationHistory, result.Reservations);

                if (!_historyDataLoaded && result.Reservations.Count > 0)
                {
                    MessageBox.Show($"Successfully loaded {result.Reservations.Count} reservation(s)", "History Loaded",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _historyDataLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservation history: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _historyDataLoaded = false;
            }
        }

        private void BtnRefreshHistory_Click(object sender, EventArgs e)
        {
            _historyDataLoaded = false;
            LoadReservationHistory();
        }

        private void BtnFilterHistory_Click(object sender, EventArgs e)
        {
            _historyDataLoaded = false;
            LoadReservationHistory();
        }

        private void BtnCancelReservation_Click(object sender, EventArgs e)
        {
            DataGridView dgvReservationHistory = null;
            foreach (Control control in tabPage2.Controls)
            {
                if (control is DataGridView dgv)
                {
                    dgvReservationHistory = dgv;
                    break;
                }
            }

            if (dgvReservationHistory == null || dgvReservationHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a reservation to cancel.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvReservationHistory.SelectedRows[0];
            string bookingReference = selectedRow.Cells["BookingReference"].Value?.ToString();
            string guestName = selectedRow.Cells["GuestName"].Value?.ToString();
            string currentStatus = selectedRow.Cells["StatusName"].Value?.ToString();

            if (MessageBox.Show($"Are you sure you want to cancel reservation {bookingReference} for {guestName}?",
                "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = _historyTabService.CancelReservation(bookingReference, currentStatus);

                if (result.Success)
                {
                    MessageBox.Show(result.Message, "Cancellation Successful",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _historyDataLoaded = false;
                    LoadReservationHistory();
                }
                else
                {
                    MessageBox.Show(result.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnNoShow_Click(object sender, EventArgs e)
        {
            DataGridView dgvReservationHistory = null;
            foreach (Control control in tabPage2.Controls)
            {
                if (control is DataGridView dgv)
                {
                    dgvReservationHistory = dgv;
                    break;
                }
            }

            if (dgvReservationHistory == null || dgvReservationHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a reservation to mark as No Show.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvReservationHistory.SelectedRows[0];
            string bookingReference = selectedRow.Cells["BookingReference"].Value?.ToString();
            string guestName = selectedRow.Cells["GuestName"].Value?.ToString();
            string currentStatus = selectedRow.Cells["StatusName"].Value?.ToString();
            DateTime checkInDate = Convert.ToDateTime(selectedRow.Cells["CheckInDate"].Value);

            if (MessageBox.Show($"Are you sure you want to mark reservation {bookingReference} for {guestName} as No Show?",
                "Confirm No Show", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = _historyTabService.MarkAsNoShow(bookingReference, currentStatus, checkInDate);

                if (result.Success)
                {
                    MessageBox.Show(result.Message, "No Show Marked",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _historyDataLoaded = false;
                    LoadReservationHistory();
                }
                else
                {
                    MessageBox.Show(result.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblChckOut_Click(object sender, EventArgs e) { }
        private void lblchckIn_Click(object sender, EventArgs e) { }
        private void pnlGuestInfo_Paint(object sender, PaintEventArgs e) { }

        private void clbSpecialRequests_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            BeginInvoke((Action)(() => CalculateTotal()));
        }
    }
}