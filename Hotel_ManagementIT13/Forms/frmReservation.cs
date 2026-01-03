using Hotel_ManagementIT13.Data.Managers;
using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
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
        private ReservationManager _reservationManager;
        private GuestManager _guestManager;
        private GuestRepository _guestRepo;
        private RoomRepository _roomRepo;
        private ReservationRepository _reservationRepo;
        private List<Guest> _searchResults;
        private List<Room> _availableRooms;
        private Guest _selectedGuest;
        private List<int> _selectedRoomIds;

        // Status IDs from your database
        private const int STATUS_AVAILABLE = 1;
        private const int STATUS_OCCUPIED = 2;
        private const int STATUS_RESERVED = 3;
        private const int STATUS_UNDER_MAINTENANCE = 4;
        private const int STATUS_OUT_OF_SERVICE = 5;
        private const int STATUS_CLEANING_IN_PROGRESS = 6;
        private const int STATUS_READY_FOR_CHECKIN = 7;
        private const int STATUS_CLOSED = 8;

        // Bookable statuses (rooms that can be reserved)
        private readonly int[] BOOKABLE_STATUSES = { STATUS_AVAILABLE, STATUS_READY_FOR_CHECKIN };

        // Current logged in user (you'll need to get this from your login system)
        private int _currentUserId = 1; // Default to admin user, change this based on your login system

        public frmReservation()
        {
            InitializeComponent();

            _reservationManager = new ReservationManager();
            _guestManager = new GuestManager();
            _guestRepo = new GuestRepository();
            _roomRepo = new RoomRepository();
            _reservationRepo = new ReservationRepository();
            _searchResults = new List<Guest>();
            _availableRooms = new List<Room>();
            _selectedRoomIds = new List<int>();
        }

        private void frmReservation_Load(object sender, EventArgs e)
        {
            InitializeForm();
            LoadAllGuests();
            LoadAvailableRoomsFromDatabase();
            LoadReservationHistory();
        }

        private void InitializeForm()
        {
            // Set default dates
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);

            // Load room types from database
            LoadRoomTypesFromDatabase();

            // Load special requests
            LoadSpecialRequests();

            // Initialize data grids
            InitializeDataGrids();

            // Initialize tab controls
            InitializeTabControls();

            // Initialize UI state
            lblSelectedGuest.Text = "No guest selected";
            lblSelectedGuest.ForeColor = Color.Red;
            lblTotalAmount.Text = "$0.00";

            // Initialize labels
            lblSearchResults.Text = "Found 0 guest(s)";
            lblAvailableRooms.Text = "Available: 0 room(s)";

            // Disable booking controls initially
            EnableBookingControls(false);
        }

        private void InitializeTabControls()
        {
            // Clear existing controls in tab pages
            tabPage1.Controls.Clear();
            tabPage2.Controls.Clear();

            // New Reservation tab (already has all controls)
            // Reservation History tab setup
            SetupReservationHistoryTab();
        }

        private void SetupReservationHistoryTab()
        {
            // Create DataGridView for reservation history
            DataGridView dgvReservationHistory = new DataGridView();
            dgvReservationHistory.Dock = DockStyle.Fill;
            dgvReservationHistory.Name = "dgvReservationHistory";
            dgvReservationHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservationHistory.ReadOnly = true;
            dgvReservationHistory.AllowUserToAddRows = false;
            dgvReservationHistory.AllowUserToDeleteRows = false;
            dgvReservationHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Add columns
            dgvReservationHistory.Columns.Add("BookingReference", "Booking #");
            dgvReservationHistory.Columns.Add("GuestName", "Guest Name");
            dgvReservationHistory.Columns.Add("CheckInDate", "Check-in");
            dgvReservationHistory.Columns.Add("CheckOutDate", "Check-out");
            dgvReservationHistory.Columns.Add("Rooms", "Rooms");
            dgvReservationHistory.Columns.Add("TotalAmount", "Total");
            dgvReservationHistory.Columns.Add("StatusName", "Status");
            dgvReservationHistory.Columns.Add("CreatedAt", "Booking Date");

            // Format columns
            dgvReservationHistory.Columns["CheckInDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvReservationHistory.Columns["CheckOutDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvReservationHistory.Columns["CreatedAt"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
            dgvReservationHistory.Columns["TotalAmount"].DefaultCellStyle.Format = "C";
            dgvReservationHistory.Columns["TotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Add refresh button
            Button btnRefreshHistory = new Button();
            btnRefreshHistory.Text = "Refresh";
            btnRefreshHistory.Location = new Point(10, 10);
            btnRefreshHistory.Size = new Size(100, 30);
            btnRefreshHistory.Click += BtnRefreshHistory_Click;

            // Add date filter controls
            Label lblFromDate = new Label();
            lblFromDate.Text = "From:";
            lblFromDate.Location = new Point(120, 15);
            lblFromDate.Size = new Size(40, 20);

            DateTimePicker dtpFromDate = new DateTimePicker();
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Value = DateTime.Today.AddMonths(-1);
            dtpFromDate.Location = new Point(165, 10);
            dtpFromDate.Size = new Size(120, 20);

            Label lblToDate = new Label();
            lblToDate.Text = "To:";
            lblToDate.Location = new Point(295, 15);
            lblToDate.Size = new Size(30, 20);

            DateTimePicker dtpToDate = new DateTimePicker();
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Value = DateTime.Today.AddDays(30);
            dtpToDate.Location = new Point(330, 10);
            dtpToDate.Size = new Size(120, 20);

            Button btnFilterHistory = new Button();
            btnFilterHistory.Text = "Filter";
            btnFilterHistory.Location = new Point(460, 10);
            btnFilterHistory.Size = new Size(80, 30);
            btnFilterHistory.Click += BtnFilterHistory_Click;

            // Add controls to tab page
            Panel filterPanel = new Panel();
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Height = 50;
            filterPanel.BackColor = SystemColors.Control;

            filterPanel.Controls.Add(btnRefreshHistory);
            filterPanel.Controls.Add(lblFromDate);
            filterPanel.Controls.Add(dtpFromDate);
            filterPanel.Controls.Add(lblToDate);
            filterPanel.Controls.Add(dtpToDate);
            filterPanel.Controls.Add(btnFilterHistory);

            tabPage2.Controls.Add(filterPanel);
            tabPage2.Controls.Add(dgvReservationHistory);

            // Set DataGridView to be below filter panel
            dgvReservationHistory.Top = filterPanel.Height;
            dgvReservationHistory.Height = tabPage2.Height - filterPanel.Height;
        }

        private void LoadReservationHistory()
        {
            try
            {
                // Get controls from tab page 2
                DataGridView dgvReservationHistory = tabPage2.Controls.OfType<DataGridView>().FirstOrDefault();
                DateTimePicker dtpFromDate = tabPage2.Controls.OfType<DateTimePicker>().FirstOrDefault(d => d.Name == "dtpFromDate");
                DateTimePicker dtpToDate = tabPage2.Controls.OfType<DateTimePicker>().FirstOrDefault(d => d.Name == "dtpToDate");

                if (dgvReservationHistory == null) return;

                DateTime fromDate = dtpFromDate?.Value ?? DateTime.Today.AddMonths(-1);
                DateTime toDate = dtpToDate?.Value ?? DateTime.Today.AddDays(30);

                // Get reservations from database
                var reservations = _reservationRepo.GetReservationsByDateRange(fromDate, toDate);

                // Clear existing rows
                dgvReservationHistory.Rows.Clear();

                // Add rows
                foreach (var reservation in reservations)
                {
                    string roomNumbers = string.Join(", ", reservation.Rooms.Select(r => r.RoomNumber));

                    dgvReservationHistory.Rows.Add(
                        reservation.BookingReference,
                        reservation.GuestName,
                        reservation.CheckInDate,
                        reservation.CheckOutDate,
                        roomNumbers,
                        reservation.TotalAmount,
                        reservation.StatusName,
                        reservation.CreatedAt
                    );
                }

                // Add row coloring based on status
                foreach (DataGridViewRow row in dgvReservationHistory.Rows)
                {
                    string status = row.Cells["StatusName"].Value?.ToString();
                    if (!string.IsNullOrEmpty(status))
                    {
                        row.DefaultCellStyle.BackColor = GetStatusColorForHistory(status);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservation history: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Color GetStatusColorForHistory(string status)
        {
            switch (status.ToLower())
            {
                case "confirmed":
                case "checked-in":
                    return Color.LightGreen;
                case "pending payment":
                    return Color.LightYellow;
                case "cancelled":
                    return Color.LightGray;
                case "no-show":
                    return Color.LightPink;
                default:
                    return Color.White;
            }
        }

        private void BtnRefreshHistory_Click(object sender, EventArgs e)
        {
            LoadReservationHistory();
        }

        private void BtnFilterHistory_Click(object sender, EventArgs e)
        {
            LoadReservationHistory();
        }

        private void LoadAllGuests()
        {
            try
            {
                // Show loading message
                lblSearchResults.Text = "Loading guests...";
                Application.DoEvents();

                // Get all guests from database using GuestRepository
                var allGuests = _guestRepo.GetAllGuests();

                if (allGuests != null && allGuests.Count > 0)
                {
                    _searchResults = allGuests;
                    DisplayGuestResults();
                    lblSearchResults.Text = $"Loaded {allGuests.Count} guest(s) from database";
                }
                else
                {
                    lblSearchResults.Text = "No guests found in database";
                    _searchResults = new List<Guest>();
                    DisplayGuestResults();
                }
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
                // Show loading message
                lblAvailableRooms.Text = "Loading rooms...";
                Application.DoEvents();

                // Clear existing rooms
                _availableRooms.Clear();

                // Load ALL rooms from database
                var allRooms = _roomRepo.GetAllRooms();

                if (allRooms != null && allRooms.Count > 0)
                {
                    // Filter to show only bookable rooms
                    var bookableRooms = allRooms
                        .Where(r => BOOKABLE_STATUSES.Contains(r.StatusId))
                        .ToList();

                    lblAvailableRooms.Text = $"Loaded {allRooms.Count} rooms, {bookableRooms.Count} available";

                    // Add only bookable rooms
                    _availableRooms.AddRange(bookableRooms);

                    // Display available rooms
                    DisplayAvailableRooms();
                }
                else
                {
                    lblAvailableRooms.Text = "No rooms found in database";
                }
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

                // Get unique room types from available rooms
                if (_availableRooms != null && _availableRooms.Count > 0)
                {
                    var uniqueTypes = _availableRooms
                        .Where(r => !string.IsNullOrEmpty(r.RoomTypeName))
                        .Select(r => r.RoomTypeName)
                        .Distinct()
                        .OrderBy(t => t)
                        .ToList();

                    foreach (var type in uniqueTypes)
                    {
                        cmbRoomType.Items.Add(type);
                    }
                }

                // If no types loaded, try to get from all rooms in database
                if (cmbRoomType.Items.Count <= 1)
                {
                    try
                    {
                        var allRooms = _roomRepo.GetAllRooms();
                        if (allRooms != null)
                        {
                            var uniqueTypes = allRooms
                                .Where(r => !string.IsNullOrEmpty(r.RoomTypeName))
                                .Select(r => r.RoomTypeName)
                                .Distinct()
                                .OrderBy(t => t)
                                .ToList();

                            foreach (var type in uniqueTypes)
                            {
                                cmbRoomType.Items.Add(type);
                            }
                        }
                    }
                    catch
                    {
                        // If still no types, add defaults
                        cmbRoomType.Items.Add("Standard");
                        cmbRoomType.Items.Add("Deluxe");
                        cmbRoomType.Items.Add("Suite");
                        cmbRoomType.Items.Add("Presidential");
                        cmbRoomType.Items.Add("Executive");
                        cmbRoomType.Items.Add("Family");
                    }
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
            clbSpecialRequests.Items.Clear();

            string[] requests = {
                "Early Check-in (before 2 PM)",
                "Late Check-out (after 12 PM)",
                "Extra Bed",
                "Crib/Child Bed",
                "Non-smoking Room",
                "High Floor",
                "Adjoining Rooms",
                "Airport Transfer"
            };

            foreach (var request in requests)
            {
                clbSpecialRequests.Items.Add(request);
            }
        }

        private void InitializeDataGrids()
        {
            try
            {
                // Clear grids
                dgvGuestResults.Columns.Clear();
                dgvGuestResults.Rows.Clear();
                dgvAvailableRooms.Columns.Clear();
                dgvAvailableRooms.Rows.Clear();

                // Setup Guest Results Grid
                SetupGuestGrid();

                // Setup Available Rooms Grid
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
            // Guest ID column
            DataGridViewTextBoxColumn guestIdCol = new DataGridViewTextBoxColumn();
            guestIdCol.Name = "GuestId";
            guestIdCol.HeaderText = "ID";
            guestIdCol.Visible = false;
            dgvGuestResults.Columns.Add(guestIdCol);

            // Name column
            DataGridViewTextBoxColumn nameCol = new DataGridViewTextBoxColumn();
            nameCol.Name = "Name";
            nameCol.HeaderText = "Name";
            nameCol.Width = 150;
            dgvGuestResults.Columns.Add(nameCol);

            // Phone column
            DataGridViewTextBoxColumn phoneCol = new DataGridViewTextBoxColumn();
            phoneCol.Name = "Phone";
            phoneCol.HeaderText = "Phone";
            phoneCol.Width = 100;
            dgvGuestResults.Columns.Add(phoneCol);

            // Email column
            DataGridViewTextBoxColumn emailCol = new DataGridViewTextBoxColumn();
            emailCol.Name = "Email";
            emailCol.HeaderText = "Email";
            emailCol.Width = 150;
            dgvGuestResults.Columns.Add(emailCol);

            // Type column
            DataGridViewTextBoxColumn typeCol = new DataGridViewTextBoxColumn();
            typeCol.Name = "Type";
            typeCol.HeaderText = "Type";
            typeCol.Width = 80;
            dgvGuestResults.Columns.Add(typeCol);

            // Add a "Select" button column
            DataGridViewButtonColumn selectCol = new DataGridViewButtonColumn();
            selectCol.Name = "SelectAction";
            selectCol.HeaderText = "Action";
            selectCol.Text = "Select";
            selectCol.UseColumnTextForButtonValue = true;
            selectCol.Width = 70;
            dgvGuestResults.Columns.Add(selectCol);
        }

        private void SetupRoomsGrid()
        {
            // Checkbox column for selection
            DataGridViewCheckBoxColumn checkCol = new DataGridViewCheckBoxColumn();
            checkCol.Name = "Select";
            checkCol.HeaderText = "Select";
            checkCol.Width = 50;
            dgvAvailableRooms.Columns.Add(checkCol);

            // Room ID column (hidden)
            dgvAvailableRooms.Columns.Add("RoomId", "ID");
            dgvAvailableRooms.Columns["RoomId"].Visible = false;

            // Room Number column
            dgvAvailableRooms.Columns.Add("RoomNumber", "Room #");
            dgvAvailableRooms.Columns["RoomNumber"].Width = 70;

            // Room Type column
            dgvAvailableRooms.Columns.Add("Type", "Type");
            dgvAvailableRooms.Columns["Type"].Width = 80;

            // Floor column
            dgvAvailableRooms.Columns.Add("Floor", "Floor");
            dgvAvailableRooms.Columns["Floor"].Width = 50;

            // View column
            dgvAvailableRooms.Columns.Add("View", "View");
            dgvAvailableRooms.Columns["View"].Width = 80;

            // Status column
            dgvAvailableRooms.Columns.Add("Status", "Status");
            dgvAvailableRooms.Columns["Status"].Width = 100;

            // Rate column
            dgvAvailableRooms.Columns.Add("Rate", "Rate/Night");
            dgvAvailableRooms.Columns["Rate"].Width = 90;

            // Setup checkbox handling
            dgvAvailableRooms.CurrentCellDirtyStateChanged += dgvAvailableRooms_CurrentCellDirtyStateChanged;
            dgvAvailableRooms.CellValueChanged += dgvAvailableRooms_CellValueChanged;
            dgvGuestResults.CellClick += dgvGuestResults_CellClick;
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
                // If search is empty, show all guests
                LoadAllGuests();
                return;
            }

            try
            {
                // Show searching message
                lblSearchResults.Text = "Searching...";
                Application.DoEvents();

                // Use GuestManager for search
                var searchResult = _guestManager.SearchGuests(searchTerm);

                if (searchResult.Success)
                {
                    _searchResults = searchResult.Guests;
                    DisplayGuestResults();
                }
                else
                {
                    MessageBox.Show(searchResult.Message, "Search Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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

                    // Add "Select" button text
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
                    // Check if the click is on the Select button column
                    if (e.ColumnIndex == dgvGuestResults.Columns["SelectAction"].Index)
                    {
                        SelectGuestFromRow(e.RowIndex);
                    }
                    else
                    {
                        // Regular cell click - also select the guest
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

                // Highlight the selected row
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

                // Show searching message
                lblAvailableRooms.Text = "Searching available rooms...";
                Application.DoEvents();

                // Get available rooms from database based on dates
                List<Room> availableRooms = new List<Room>();

                try
                {
                    availableRooms = _roomRepo.GetAvailableRooms(checkIn, checkOut, 0);

                    if (availableRooms != null && availableRooms.Count > 0)
                    {
                        // Additional filter to ensure only bookable rooms
                        availableRooms = availableRooms
                            .Where(r => BOOKABLE_STATUSES.Contains(r.StatusId))
                            .ToList();

                        lblAvailableRooms.Text = $"Found {availableRooms.Count} available rooms";
                    }
                    else
                    {
                        // If repository returns nothing, use current available rooms
                        availableRooms = _availableRooms.ToList();
                        lblAvailableRooms.Text = $"Showing {availableRooms.Count} available rooms";
                    }
                }
                catch (Exception dbEx)
                {
                    MessageBox.Show($"Database error: {dbEx.Message}. Using loaded available rooms.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    availableRooms = _availableRooms.ToList();
                    lblAvailableRooms.Text = $"Showing {availableRooms.Count} rooms";
                }

                // Filter by room type if specified
                if (selectedType != "All Types" && !string.IsNullOrEmpty(selectedType))
                {
                    availableRooms = availableRooms.Where(r => r.RoomTypeName == selectedType).ToList();
                    lblAvailableRooms.Text = $"Found {availableRooms.Count} {selectedType} rooms";
                }

                // Update the available rooms list
                _availableRooms = availableRooms;
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
                    // Get status display text
                    string statusDisplay = GetStatusDisplayText(room.StatusId);

                    // Color code based on status
                    Color statusColor = GetStatusColor(room.StatusId);

                    // Add row
                    int rowIndex = dgvAvailableRooms.Rows.Add(
                        false, // Checkbox
                        room.RoomId,
                        room.RoomNumber ?? "",
                        room.RoomTypeName ?? "Unknown",
                        room.Floor,
                        room.ViewName ?? "",
                        statusDisplay,
                        room.BaseRate.ToString("C")
                    );

                    // Set status cell color
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

        private string GetStatusDisplayText(int statusId)
        {
            switch (statusId)
            {
                case STATUS_AVAILABLE: return "Available";
                case STATUS_OCCUPIED: return "Occupied";
                case STATUS_RESERVED: return "Reserved";
                case STATUS_UNDER_MAINTENANCE: return "Under Maintenance";
                case STATUS_OUT_OF_SERVICE: return "Out of Service";
                case STATUS_CLEANING_IN_PROGRESS: return "Cleaning";
                case STATUS_READY_FOR_CHECKIN: return "Ready for Check-in";
                case STATUS_CLOSED: return "Closed";
                default: return "Unknown";
            }
        }

        private Color GetStatusColor(int statusId)
        {
            switch (statusId)
            {
                case STATUS_AVAILABLE: return Color.Green;
                case STATUS_READY_FOR_CHECKIN: return Color.Blue;
                case STATUS_OCCUPIED: return Color.Red;
                case STATUS_RESERVED: return Color.Orange;
                case STATUS_UNDER_MAINTENANCE: return Color.Purple;
                case STATUS_OUT_OF_SERVICE: return Color.Gray;
                case STATUS_CLEANING_IN_PROGRESS: return Color.DarkCyan;
                case STATUS_CLOSED: return Color.DarkRed;
                default: return Color.Black;
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
                    lblTotalAmount.Text = "$0.00";
                    return;
                }

                DateTime checkIn = dtpCheckIn.Value;
                DateTime checkOut = dtpCheckOut.Value;

                if (checkOut <= checkIn)
                {
                    lblTotalAmount.Text = "$0.00";
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

                // Apply loyalty discount if applicable
                var guestHistory = _guestManager.GetGuestHistory(_selectedGuest.GuestId);
                if (guestHistory != null && guestHistory.TotalReservations > 0)
                {
                    totalAmount = totalAmount * 0.95m; // 5% discount for returning guests
                }

                lblTotalAmount.Text = totalAmount.ToString("C");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating total: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTotalAmount.Text = "$0.00";
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (!ValidateBooking()) return;

            try
            {
                // Get special requests
                string specialRequests = GetSpecialRequests();

                // Create reservation object
                var reservation = new Reservation
                {
                    GuestId = _selectedGuest.GuestId,
                    UserId = _currentUserId, // Current logged in user
                    CompanyId = null, // You can add company selection if needed
                    StatusId = 1, // Confirmed (adjust based on your status IDs)
                    ReservationTypeId = 1, // Standard reservation (adjust based on your types)
                    BookingReference = _reservationRepo.GenerateBookingReference(),
                    CheckInDate = dtpCheckIn.Value,
                    CheckOutDate = dtpCheckOut.Value,
                    Adults = (int)nudAdults.Value,
                    Children = (int)nudChildren.Value,
                    SpecialRequests = specialRequests,
                    TotalAmount = decimal.Parse(lblTotalAmount.Text.Replace("$", "").Replace(",", "")),
                    CreatedAt = DateTime.Now
                };

                // Add selected rooms
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

                // Save reservation to database
                int reservationId = _reservationRepo.CreateReservation(reservation);

                if (reservationId > 0)
                {
                    // Show success message
                    string roomNumbers = string.Join(", ", reservation.Rooms.Select(r => r.RoomNumber));
                    string confirmationMessage = $"RESERVATION CONFIRMED!\n\n" +
                                               $"Booking Reference: {reservation.BookingReference}\n" +
                                               $"Reservation ID: {reservationId}\n" +
                                               $"Guest: {_selectedGuest.FullName}\n" +
                                               $"Check-in: {reservation.CheckInDate:yyyy-MM-dd}\n" +
                                               $"Check-out: {reservation.CheckOutDate:yyyy-MM-dd}\n" +
                                               $"Rooms: {roomNumbers}\n" +
                                               $"Total: {lblTotalAmount.Text}\n\n" +
                                               $"Reservation has been saved to database.";

                    MessageBox.Show(confirmationMessage, "Booking Confirmed",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Switch to reservation history tab
                    tabReservation.SelectedTab = tabPage2;

                    // Refresh reservation history
                    LoadReservationHistory();

                    // Reset form for next reservation
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Failed to save reservation. Please try again.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating reservation: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateBooking()
        {
            if (_selectedGuest == null)
            {
                MessageBox.Show("Please select a guest", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_selectedRoomIds.Count == 0)
            {
                MessageBox.Show("Please select at least one room", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpCheckOut.Value <= dtpCheckIn.Value)
            {
                MessageBox.Show("Check-out date must be after check-in date", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (nudAdults.Value < 1)
            {
                MessageBox.Show("At least 1 adult is required", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Additional validation: Check if selected rooms are still available
            foreach (int roomId in _selectedRoomIds)
            {
                var room = _availableRooms.FirstOrDefault(r => r.RoomId == roomId);
                if (room != null && !BOOKABLE_STATUSES.Contains(room.StatusId))
                {
                    MessageBox.Show($"Room {room.RoomNumber} is no longer available for booking. Status: {room.StatusName}",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
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
                // Clear search but keep guests displayed
                txtGuestSearch.Clear();

                // Keep guests loaded but clear selection
                _selectedGuest = null;
                _selectedRoomIds.Clear();

                // Clear room selection but keep rooms loaded
                dgvAvailableRooms.Rows.Clear();

                // Reset UI state
                lblSelectedGuest.Text = "No guest selected";
                lblSelectedGuest.ForeColor = Color.Red;
                lblTotalAmount.Text = "$0.00";
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

                // Reload available rooms from database
                LoadAvailableRoomsFromDatabase();

                // Clear guest selection highlight
                foreach (DataGridViewRow row in dgvGuestResults.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }

                // Switch back to new reservation tab
                tabReservation.SelectedTab = tabPage1;
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
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Checkbox column
            {
                try
                {
                    var row = dgvAvailableRooms.Rows[e.RowIndex];
                    bool isChecked = Convert.ToBoolean(row.Cells[0].Value);
                    int roomId = Convert.ToInt32(row.Cells[1].Value);

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
            if (dgvAvailableRooms.IsCurrentCellDirty)
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
                    // Refresh the guest list after adding new guest
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
            // When switching to Reservation History tab, refresh the data
            if (tabReservation.SelectedTab == tabPage2)
            {
                LoadReservationHistory();
            }
        }
    }
}