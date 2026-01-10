using Hotel_ManagementIT13.Data;
using Hotel_ManagementIT13.Data.Managers;
using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
using Hotel_ManagementIT13.Utilities;
using MySql.Data.MySqlClient;
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
        private AmenityRepository _amenityRepo;
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

        // Current logged in user
        private int _currentUserId = 1;

        // Track if reservation history tab has been initialized
        private bool _historyTabInitialized = false;
        private bool _historyDataLoaded = false;

        // Amenity fee per selected amenity
        private const decimal AMENITY_FEE = 100m;

        public frmReservation()
        {
            InitializeComponent();

            _reservationManager = new ReservationManager();
            _guestManager = new GuestManager();
            _guestRepo = new GuestRepository();
            _roomRepo = new RoomRepository();
            _reservationRepo = new ReservationRepository();
            _amenityRepo = new AmenityRepository();
            _searchResults = new List<Guest>();
            _availableRooms = new List<Room>();
            _selectedRoomIds = new List<int>();
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
            lblTotalAmount.Text = "₱0.00"; // Changed from $ to ₱
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
                lblAvailableRooms.Text = "Loading rooms...";
                Application.DoEvents();

                _availableRooms.Clear();
                var allRooms = _roomRepo.GetAllRooms();

                if (allRooms != null && allRooms.Count > 0)
                {
                    var bookableRooms = allRooms
                        .Where(r => BOOKABLE_STATUSES.Contains(r.StatusId))
                        .ToList();

                    lblAvailableRooms.Text = $"Loaded {allRooms.Count} rooms, {bookableRooms.Count} available";
                    _availableRooms.AddRange(bookableRooms);
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
                        cmbRoomType.Items.Add("Standard");
                        cmbRoomType.Items.Add("Deluxe");
                        cmbRoomType.Items.Add("Suite");
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
            try
            {
                clbSpecialRequests.Items.Clear();

                // Get amenities from database
                var amenities = _amenityRepo.GetAllAmenities();

                if (amenities != null && amenities.Count > 0)
                {
                    // Add each amenity to the CheckedListBox
                    foreach (var amenity in amenities)
                    {
                        clbSpecialRequests.Items.Add(amenity.AmenityName, false);
                    }
                }
                else
                {
                    // If no amenities in database, show message
                    MessageBox.Show("No amenities found in the database. Please add amenities to the amenities table.",
                        "No Amenities", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DataGridViewTextBoxColumn guestIdCol = new DataGridViewTextBoxColumn();
            guestIdCol.Name = "GuestId";
            guestIdCol.HeaderText = "ID";
            guestIdCol.Visible = false;
            dgvGuestResults.Columns.Add(guestIdCol);

            DataGridViewTextBoxColumn nameCol = new DataGridViewTextBoxColumn();
            nameCol.Name = "Name";
            nameCol.HeaderText = "Name";
            nameCol.Width = 150;
            dgvGuestResults.Columns.Add(nameCol);

            DataGridViewTextBoxColumn phoneCol = new DataGridViewTextBoxColumn();
            phoneCol.Name = "Phone";
            phoneCol.HeaderText = "Phone";
            phoneCol.Width = 100;
            dgvGuestResults.Columns.Add(phoneCol);

            DataGridViewTextBoxColumn emailCol = new DataGridViewTextBoxColumn();
            emailCol.Name = "Email";
            emailCol.HeaderText = "Email";
            emailCol.Width = 150;
            dgvGuestResults.Columns.Add(emailCol);

            DataGridViewTextBoxColumn typeCol = new DataGridViewTextBoxColumn();
            typeCol.Name = "Type";
            typeCol.HeaderText = "Type";
            typeCol.Width = 80;
            dgvGuestResults.Columns.Add(typeCol);

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
            // Clear existing columns
            dgvAvailableRooms.Columns.Clear();
            dgvAvailableRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAvailableRooms.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAvailableRooms.RowHeadersVisible = false;
            dgvAvailableRooms.ReadOnly = false; // IMPORTANT: Make the grid editable
            dgvAvailableRooms.AllowUserToAddRows = false;
            dgvAvailableRooms.AllowUserToDeleteRows = false;
            dgvAvailableRooms.EditMode = DataGridViewEditMode.EditOnEnter; // Allow editing

            // Create columns with proper FillWeight for equal sizing
            DataGridViewCheckBoxColumn checkCol = new DataGridViewCheckBoxColumn();
            checkCol.Name = "Select";
            checkCol.HeaderText = "Select";
            checkCol.FillWeight = 8; // 8% of total width
            checkCol.ReadOnly = false; // Make checkbox editable
            checkCol.TrueValue = true;
            checkCol.FalseValue = false;
            dgvAvailableRooms.Columns.Add(checkCol);

            DataGridViewTextBoxColumn roomIdCol = new DataGridViewTextBoxColumn();
            roomIdCol.Name = "RoomId";
            roomIdCol.HeaderText = "ID";
            roomIdCol.Visible = false;
            roomIdCol.ReadOnly = true;
            dgvAvailableRooms.Columns.Add(roomIdCol);

            DataGridViewTextBoxColumn roomNumCol = new DataGridViewTextBoxColumn();
            roomNumCol.Name = "RoomNumber";
            roomNumCol.HeaderText = "Room #";
            roomNumCol.FillWeight = 12; // 12% of total width
            roomNumCol.ReadOnly = true;
            dgvAvailableRooms.Columns.Add(roomNumCol);

            DataGridViewTextBoxColumn typeCol = new DataGridViewTextBoxColumn();
            typeCol.Name = "Type";
            typeCol.HeaderText = "Type";
            typeCol.FillWeight = 15; // 15% of total width
            typeCol.ReadOnly = true;
            dgvAvailableRooms.Columns.Add(typeCol);

            DataGridViewTextBoxColumn floorCol = new DataGridViewTextBoxColumn();
            floorCol.Name = "Floor";
            floorCol.HeaderText = "Floor";
            floorCol.FillWeight = 10; // 10% of total width
            floorCol.ReadOnly = true;
            dgvAvailableRooms.Columns.Add(floorCol);

            DataGridViewTextBoxColumn viewCol = new DataGridViewTextBoxColumn();
            viewCol.Name = "View";
            viewCol.HeaderText = "View";
            viewCol.FillWeight = 15; // 15% of total width
            viewCol.ReadOnly = true;
            dgvAvailableRooms.Columns.Add(viewCol);

            DataGridViewTextBoxColumn statusCol = new DataGridViewTextBoxColumn();
            statusCol.Name = "Status";
            statusCol.HeaderText = "Status";
            statusCol.FillWeight = 20; // 20% of total width
            statusCol.ReadOnly = true;
            dgvAvailableRooms.Columns.Add(statusCol);

            DataGridViewTextBoxColumn rateCol = new DataGridViewTextBoxColumn();
            rateCol.Name = "Rate";
            rateCol.HeaderText = "Rate/Night";
            rateCol.FillWeight = 20; // 20% of total width
            rateCol.ReadOnly = true;
            dgvAvailableRooms.Columns.Add(rateCol);

            // Subscribe to events
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

                List<Room> availableRooms = new List<Room>();

                try
                {
                    availableRooms = _roomRepo.GetAvailableRooms(checkIn, checkOut, 0);

                    if (availableRooms != null && availableRooms.Count > 0)
                    {
                        availableRooms = availableRooms
                            .Where(r => BOOKABLE_STATUSES.Contains(r.StatusId))
                            .ToList();

                        lblAvailableRooms.Text = $"Found {availableRooms.Count} available rooms";
                    }
                    else
                    {
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

                if (selectedType != "All Types" && !string.IsNullOrEmpty(selectedType))
                {
                    availableRooms = availableRooms.Where(r => r.RoomTypeName == selectedType).ToList();
                    lblAvailableRooms.Text = $"Found {availableRooms.Count} {selectedType} rooms";
                }

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
                    string statusDisplay = GetStatusDisplayText(room.StatusId);
                    Color statusColor = GetStatusColor(room.StatusId);

                    int rowIndex = dgvAvailableRooms.Rows.Add(
                        false,
                        room.RoomId,
                        room.RoomNumber ?? "",
                        room.RoomTypeName ?? "Unknown",
                        room.Floor,
                        room.ViewName ?? "",
                        statusDisplay,
                        room.BaseRate.ToString("C").Replace("$", "₱") // Changed from $ to ₱
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

                // Calculate room costs
                foreach (int roomId in _selectedRoomIds)
                {
                    var room = _availableRooms.FirstOrDefault(r => r.RoomId == roomId);
                    if (room != null)
                    {
                        totalAmount += room.BaseRate * nights;
                    }
                }

                // Calculate amenity fees - ₱100 for each selected amenity
                int selectedAmenitiesCount = 0;
                for (int i = 0; i < clbSpecialRequests.Items.Count; i++)
                {
                    if (clbSpecialRequests.GetItemChecked(i))
                    {
                        selectedAmenitiesCount++;
                    }
                }

                decimal amenityFees = selectedAmenitiesCount * AMENITY_FEE;
                totalAmount += amenityFees;

                // REMOVED: Returning guest discount (5% discount removed)
                // No discount applied anymore

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
                    StatusId = 1, // Confirmed status
                    ReservationTypeId = 1, // Standard reservation
                    BookingReference = _reservationRepo.GenerateBookingReference(),
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

                // Save reservation to database
                int reservationId = _reservationRepo.CreateReservation(reservation);

                if (reservationId > 0)
                {
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

                    // IMPORTANT: Reset form FIRST before switching tabs
                    ResetForm();

                    // Force immediate refresh of the database connection
                    RefreshDatabaseConnection();

                    // Now switch to history tab and reload
                    tabReservation.SelectedTab = tabPage2;

                    // Force a complete refresh of the history tab
                    ForceRefreshReservationHistory();
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

        private void RefreshDatabaseConnection()
        {
            try
            {
                // Force a fresh database connection
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Just test the connection
                    using (var cmd = new MySqlCommand("SELECT 1", conn))
                    {
                        cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database refresh error: {ex.Message}");
            }
        }

        private void ForceRefreshReservationHistory()
        {
            try
            {
                // Clear the history tab flag to force reinitialization
                _historyTabInitialized = false;
                _historyDataLoaded = false;

                // Clear existing controls in tabPage2
                tabPage2.Controls.Clear();

                // Add a small delay to ensure UI updates
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);

                // Now load the reservation history
                LoadReservationHistory();

                // Force UI refresh
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
            // Check if the changed cell is the Select checkbox column
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // Column 0 is the Select checkbox
            {
                try
                {
                    var row = dgvAvailableRooms.Rows[e.RowIndex];
                    bool isChecked = false;

                    // Safely get the checkbox value
                    if (row.Cells["Select"].Value != null)
                    {
                        isChecked = Convert.ToBoolean(row.Cells["Select"].Value);
                    }

                    // Get the RoomId from the "RoomId" column (column 1)
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
            // Only create controls once
            if (_historyTabInitialized && tabPage2.Controls.Count > 0)
            {
                return;
            }

            tabPage2.Controls.Clear();

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

            // Changed from "C" format to peso format
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

            Button btnRefreshHistory = new Button();
            btnRefreshHistory.Text = "Refresh";
            btnRefreshHistory.Location = new Point(10, 10);
            btnRefreshHistory.Size = new Size(100, 30);
            btnRefreshHistory.Click += BtnRefreshHistory_Click;

            Label lblFromDate = new Label();
            lblFromDate.Text = "From:";
            lblFromDate.Location = new Point(120, 15);
            lblFromDate.Size = new Size(40, 20);

            DateTimePicker dtpFromDate = new DateTimePicker();
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Value = DateTime.Today.AddYears(-5);
            dtpFromDate.Location = new Point(165, 10);
            dtpFromDate.Size = new Size(120, 20);

            Label lblToDate = new Label();
            lblToDate.Text = "To:";
            lblToDate.Location = new Point(295, 15);
            lblToDate.Size = new Size(30, 20);

            DateTimePicker dtpToDate = new DateTimePicker();
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Value = DateTime.Today.AddYears(5);
            dtpToDate.Location = new Point(330, 10);
            dtpToDate.Size = new Size(120, 20);

            Button btnFilterHistory = new Button();
            btnFilterHistory.Text = "Filter";
            btnFilterHistory.Location = new Point(460, 10);
            btnFilterHistory.Size = new Size(80, 30);
            btnFilterHistory.Click += BtnFilterHistory_Click;

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

            _historyTabInitialized = true;
        }

        private void LoadReservationHistory()
        {
            // Check if data has already been loaded
            if (_historyDataLoaded && _historyTabInitialized)
            {
                // Data already loaded, just return
                return;
            }

            try
            {
                // Ensure tab is initialized
                if (!_historyTabInitialized)
                {
                    SetupReservationHistoryTab();
                }

                // Find controls
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
                    // Recursive call to load data after setup
                    LoadReservationHistory();
                    return;
                }

                // Get ALL reservations
                var reservations = GetAllReservationsDirectly();

                // Clear and reload the grid
                dgvReservationHistory.Rows.Clear();

                if (reservations != null && reservations.Count > 0)
                {
                    // Sort by creation date descending (newest first)
                    var sortedReservations = reservations.OrderByDescending(r => r.CreatedAt).ToList();

                    foreach (var reservation in sortedReservations)
                    {
                        string roomNumbers = "No rooms";
                        if (reservation.Rooms != null && reservation.Rooms.Count > 0)
                        {
                            roomNumbers = string.Join(", ", reservation.Rooms.Select(r => r.RoomNumber));
                        }

                        // Format the total amount with peso sign
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

                    // Add row coloring
                    foreach (DataGridViewRow row in dgvReservationHistory.Rows)
                    {
                        string status = row.Cells["StatusName"].Value?.ToString();
                        if (!string.IsNullOrEmpty(status))
                        {
                            row.DefaultCellStyle.BackColor = GetStatusColorForHistory(status);
                        }
                    }

                    dgvReservationHistory.ClearSelection();

                    // Mark data as loaded
                    _historyDataLoaded = true;

                    // Show success message only on first load
                    if (!_historyDataLoaded)
                    {
                        MessageBox.Show($"Successfully loaded {reservations.Count} reservation(s)", "History Loaded",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (!_historyDataLoaded)
                    {
                        MessageBox.Show("No reservations found in the database.", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    _historyDataLoaded = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservation history: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _historyDataLoaded = false;
            }
        }

        private List<Reservation> GetAllReservationsDirectly()
        {
            var reservations = new List<Reservation>();

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Get ALL reservations - NO DATE FILTERING
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
                                ELSE 'Confirmed'
                            END as status_name,
                            'Standard' as reservation_type,
                            NULL as company_name,
                            'System' as user_name
                        FROM reservations r
                        LEFT JOIN guests g ON r.guest_id = g.guest_id
                        ORDER BY r.created_at DESC";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
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

                                    // Load rooms for this reservation
                                    reservation.Rooms = GetReservationRoomsDirectly(reservation.ReservationId);
                                    reservations.Add(reservation);
                                }
                                catch (Exception rowEx)
                                {
                                    Console.WriteLine($"Error loading reservation: {rowEx.Message}");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservations: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception ex)
            {
                // Silent fail
            }

            return rooms;
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
            // Reset the loaded flag to force a refresh
            _historyDataLoaded = false;
            LoadReservationHistory();
        }

        private void BtnFilterHistory_Click(object sender, EventArgs e)
        {
            // Reset the loaded flag to force a refresh with filters
            _historyDataLoaded = false;
            LoadReservationHistory();
        }

        private void lblChckOut_Click(object sender, EventArgs e)
        {

        }

        private void lblchckIn_Click(object sender, EventArgs e)
        {

        }

        private void pnlGuestInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        // Add event handler for amenity selection changes
        private void clbSpecialRequests_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Schedule the CalculateTotal to run after the check state has been updated
            BeginInvoke((Action)(() => CalculateTotal()));
        }
    }
}