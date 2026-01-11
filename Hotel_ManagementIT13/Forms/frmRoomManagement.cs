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
    public partial class frmRoomManagement : Form
    {
        private RoomManager _roomManager;
        private AmenityRepository _amenityRepo;
        private BedRepository _bedRepo;
        private List<Room> _allRooms;
        private List<string> _roomTypes;
        private List<string> _roomStatuses;
        private List<string> _roomViews;
        private List<Amenity> _allAmenities;
        private Room _selectedRoom;
        private bool _isAddingNew;

        // Nested concrete class for Room implementation
        private class ConcreteRoom : Room
        {
            public override string GetRoomCategory()
            {
                if (this.RoomTypeName.Contains("Standard"))
                    return "Standard";
                else if (this.RoomTypeName.Contains("Deluxe"))
                    return "Deluxe";
                else if (this.RoomTypeName.Contains("Suite") || this.RoomTypeName.Contains("Penthouse") || this.RoomTypeName.Contains("Executive"))
                    return "Suite";
                else
                    return "Standard";
            }

            public override decimal CalculateRate(int nights, int guestType)
            {
                // Calculate base rate
                decimal rate = this.BaseRate * nights;

                // Add ₱100 for each amenity
                if (this.Amenities != null)
                {
                    rate += (this.Amenities.Count * 100m) * nights;
                }

                // Apply guest type discount (if any)
                if (guestType == 2) // Regular guest
                    rate *= 0.9m; // 10% discount
                else if (guestType == 3) // VIP guest
                    rate *= 0.85m; // 15% discount

                return rate;
            }
        }

        public frmRoomManagement()
        {
            InitializeComponent();
            _roomManager = new RoomManager();
            _amenityRepo = new AmenityRepository();
            _bedRepo = new BedRepository();
            _allRooms = new List<Room>();
            _roomTypes = new List<string>();
            _roomStatuses = new List<string>();
            _roomViews = new List<string>();
            _allAmenities = new List<Amenity>();
        }

        private string FormatPeso(decimal amount)
        {
            return "₱" + amount.ToString("N2");
        }

        private void frmRoomManagement_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading form: {ex.Message}\n\n{ex.StackTrace}",
                              "Form Load Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void InitializeForm()
        {
            try
            {
                // Test database connection
                if (!TestDatabaseConnection())
                {
                    return;
                }

                LoadFormData();
                LoadRooms();
                ResetRoomForm();
                SetPlaceholderText();
                InitializeFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing form: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool TestDatabaseConnection()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot connect to database:\n\n{ex.Message}",
                              "Database Connection Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void LoadFormData()
        {
            try
            {
                // Load room types from database
                _roomTypes = GetRoomTypesFromDatabase();
                cmbRoomType.Items.Clear();
                foreach (var type in _roomTypes)
                {
                    cmbRoomType.Items.Add(type);
                }

                // Load status types from database
                _roomStatuses = GetRoomStatusesFromDatabase();
                cmbStatus.Items.Clear();
                foreach (var status in _roomStatuses)
                {
                    cmbStatus.Items.Add(status);
                }

                // Load view types from database
                _roomViews = GetRoomViewsFromDatabase();
                cmbView.Items.Clear();
                foreach (var view in _roomViews)
                {
                    cmbView.Items.Add(view);
                }

                // Load amenities from database
                LoadAmenitiesFromDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading form data: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAmenitiesFromDatabase()
        {
            try
            {
                _allAmenities = _amenityRepo.GetAllAmenities();
                clbAmenities.Items.Clear();

                // Store Amenity objects in the Tag property for easy retrieval
                foreach (var amenity in _allAmenities)
                {
                    // Add ₱100 indicator to each amenity name
                    clbAmenities.Items.Add($"{amenity.AmenityName} (+₱100)", false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading amenities: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Fallback to hardcoded amenities if database fails
                LoadDefaultAmenities();
            }
        }

        private void LoadDefaultAmenities()
        {
            // Fallback method if database fails
            clbAmenities.Items.Clear();
            clbAmenities.Items.AddRange(new string[]
            {
                "Wi-Fi (+₱100)", "TV (+₱100)", "Mini Bar (+₱100)", "Air Conditioning (+₱100)",
                "Balcony (+₱100)", "Jacuzzi (+₱100)", "Kitchenette (+₱100)", "Safe (+₱100)",
                "Hairdryer (+₱100)", "Iron (+₱100)", "Coffee Maker (+₱100)", "Refrigerator (+₱100)"
            });
        }

        private List<string> GetRoomTypesFromDatabase()
        {
            var roomTypes = new List<string>();

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT type_name FROM room_types ORDER BY room_type_id";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roomTypes.Add(reader["type_name"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading room types: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return roomTypes;
        }

        private List<string> GetRoomStatusesFromDatabase()
        {
            var statuses = new List<string>();

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT status_name FROM room_statuses ORDER BY status_id";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            statuses.Add(reader["status_name"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading room statuses: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return statuses;
        }

        private List<string> GetRoomViewsFromDatabase()
        {
            var views = new List<string>();

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT view_name FROM room_views ORDER BY view_id";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            views.Add(reader["view_name"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading room views: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return views;
        }

        private void InitializeFilters()
        {
            try
            {
                // Load filter options for room types from database
                cmbFilterType.Items.Clear();
                cmbFilterType.Items.Add("All Types");
                foreach (var type in _roomTypes)
                {
                    cmbFilterType.Items.Add(type);
                }
                cmbFilterType.SelectedIndex = 0;

                // Load filter options for room statuses from database
                cmbFilterStatus.Items.Clear();
                cmbFilterStatus.Items.Add("All Status");
                foreach (var status in _roomStatuses)
                {
                    cmbFilterStatus.Items.Add(status);
                }
                cmbFilterStatus.SelectedIndex = 0;

                // Load filter options for room views from database
                cmbFilterView.Items.Clear();
                cmbFilterView.Items.Add("All Views");
                foreach (var view in _roomViews)
                {
                    cmbFilterView.Items.Add(view);
                }
                cmbFilterView.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing filters: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetPlaceholderText()
        {
            txtSearch.Tag = "Search rooms...";
            txtRoomNumber.Tag = "Room Number";

            txtSearch.ForeColor = SystemColors.GrayText;
            txtRoomNumber.ForeColor = SystemColors.GrayText;
        }

        private void LoadRooms()
        {
            try
            {
                _allRooms = _roomManager.GetAllRooms();
                DisplayRooms(_allRooms);
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error loading rooms: {ex.Message}");
            }
        }

        private void DisplayRooms(List<Room> rooms)
        {
            dgvRooms.Rows.Clear();

            foreach (var room in rooms)
            {
                // Calculate total rate including amenities
                decimal totalRate = room.BaseRate;
                if (room.Amenities != null)
                {
                    totalRate += (room.Amenities.Count * 100m);
                }

                dgvRooms.Rows.Add(
                    room.RoomId,
                    room.RoomNumber,
                    room.RoomTypeName ?? "N/A",
                    room.Floor,
                    room.StatusName ?? "N/A",
                    room.ViewName ?? "N/A",
                    FormatPeso(totalRate), // Display total rate with amenities
                    room.MaxOccupancy
                );
            }

            lblRoomCount.Text = $"{rooms.Count} room(s) found";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            // Skip if placeholder text
            if (searchTerm == "Search rooms..." || string.IsNullOrWhiteSpace(searchTerm))
            {
                DisplayRooms(_allRooms);
                return;
            }

            try
            {
                // Use RoomManager to search rooms
                var filteredRooms = _roomManager.SearchRooms(searchTerm);

                if (filteredRooms.Count > 0)
                {
                    DisplayRooms(filteredRooms);
                }
                else
                {
                    MessageBox.Show("No rooms found matching your search criteria.",
                                  "Search Results",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    DisplayRooms(_allRooms);
                }
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error searching rooms: {ex.Message}");
            }
        }

        private void ApplyFilters()
        {
            var filteredRooms = _allRooms;

            // Apply status filter
            if (cmbFilterStatus.SelectedIndex > 0)
            {
                string selectedStatus = cmbFilterStatus.SelectedItem.ToString();
                filteredRooms = filteredRooms.Where(r => r.StatusName == selectedStatus).ToList();
            }

            // Apply type filter
            if (cmbFilterType.SelectedIndex > 0)
            {
                string selectedType = cmbFilterType.SelectedItem.ToString();
                filteredRooms = filteredRooms.Where(r => r.RoomTypeName == selectedType).ToList();
            }

            // Apply view filter
            if (cmbFilterView.SelectedIndex > 0)
            {
                string selectedView = cmbFilterView.SelectedItem.ToString();
                filteredRooms = filteredRooms.Where(r => r.ViewName == selectedView).ToList();
            }

            DisplayRooms(filteredRooms);
        }

        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvRooms.Rows.Count)
            {
                try
                {
                    var roomIdCell = dgvRooms.Rows[e.RowIndex].Cells["colRoomId"];
                    if (roomIdCell.Value != null)
                    {
                        int roomId = Convert.ToInt32(roomIdCell.Value);
                        _selectedRoom = _roomManager.GetRoomById(roomId);

                        if (_selectedRoom != null)
                        {
                            DisplayRoomDetails(_selectedRoom);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Helper.ShowError($"Error loading room details: {ex.Message}");
                }
            }
        }

        private void DisplayRoomDetails(Room room)
        {
            txtRoomNumber.Text = room.RoomNumber;
            txtRoomNumber.ForeColor = SystemColors.ControlText;

            // Set room type
            if (!string.IsNullOrEmpty(room.RoomTypeName))
            {
                int index = cmbRoomType.FindStringExact(room.RoomTypeName);
                if (index >= 0)
                    cmbRoomType.SelectedIndex = index;
            }

            // Set status
            if (!string.IsNullOrEmpty(room.StatusName))
            {
                int index = cmbStatus.FindStringExact(room.StatusName);
                if (index >= 0)
                    cmbStatus.SelectedIndex = index;
            }

            // Set view
            if (!string.IsNullOrEmpty(room.ViewName))
            {
                int index = cmbView.FindStringExact(room.ViewName);
                if (index >= 0)
                    cmbView.SelectedIndex = index;
            }

            nudFloor.Value = room.Floor;

            // Set amenities
            SetAmenitiesForRoom(room);

            // Load beds for this room
            LoadRoomBeds(room.RoomId);

            // Update rate display with amenities
            UpdateRateDisplay();

            _isAddingNew = false;
            btnSaveRoom.Text = "Update Room";
            pnlRoomDetails.Enabled = true;
        }

        private void SetAmenitiesForRoom(Room room)
        {
            // First, uncheck all items
            for (int i = 0; i < clbAmenities.Items.Count; i++)
            {
                clbAmenities.SetItemChecked(i, false);
            }

            // Then check the amenities that belong to this room
            if (room.Amenities != null && room.Amenities.Count > 0)
            {
                foreach (var roomAmenity in room.Amenities)
                {
                    // Find the index of this amenity in the checklist
                    // We need to match without the (+₱100) suffix
                    string cleanAmenityName = roomAmenity.AmenityName;

                    for (int i = 0; i < clbAmenities.Items.Count; i++)
                    {
                        string displayedAmenity = clbAmenities.Items[i].ToString();
                        // Remove the (+₱100) suffix for comparison
                        string baseAmenityName = displayedAmenity.Replace(" (+₱100)", "");

                        if (baseAmenityName.Equals(cleanAmenityName, StringComparison.OrdinalIgnoreCase))
                        {
                            clbAmenities.SetItemChecked(i, true);
                            break;
                        }
                    }
                }
            }
        }

        // NEW METHOD: Update rate display when amenities are checked/unchecked
        private void UpdateRateDisplay()
        {
            if (cmbRoomType.SelectedIndex >= 0 && !string.IsNullOrEmpty(cmbRoomType.SelectedItem.ToString()))
            {
                string roomTypeName = cmbRoomType.SelectedItem.ToString();
                Room sampleRoom = CreateRoomByType(roomTypeName);

                // Get count of checked amenities
                int selectedAmenityCount = clbAmenities.CheckedItems.Count;

                // Calculate total rate: base rate + ₱100 per selected amenity
                decimal totalRate = sampleRoom.BaseRate + (selectedAmenityCount * 100m);

                // Update display (you might want to add a label for this)
                // For now, we'll show it in a message or update the room display
                // You could add a label like lblTotalRate.Text = $"Total Rate: {FormatPeso(totalRate)}";
            }
        }

        // NEW METHOD: Load beds for a room from database
        private void LoadRoomBeds(int roomId)
        {
            try
            {
                var beds = _bedRepo.GetBedsForRoom(roomId);
                DisplayRoomBeds(beds);
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error loading beds: {ex.Message}");
            }
        }

        // NEW METHOD: Display beds in dgvBeds
        private void DisplayRoomBeds(List<RoomBed> beds)
        {
            dgvBeds.Rows.Clear();

            foreach (var bed in beds)
            {
                int rowIndex = dgvBeds.Rows.Add();
                dgvBeds.Rows[rowIndex].Cells["colBedType"].Value = bed.BedTypeName;
                dgvBeds.Rows[rowIndex].Cells["colQuantity"].Value = bed.Quantity;
            }
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            ResetRoomForm();
            _isAddingNew = true;
            btnSaveRoom.Text = "Add Room";
            pnlRoomDetails.Enabled = true;
            txtRoomNumber.Focus();
        }

        private void btnSaveRoom_Click(object sender, EventArgs e)
        {
            if (!ValidateRoomForm())
                return;

            try
            {
                // Get selected room type
                string roomTypeName = cmbRoomType.SelectedItem?.ToString();
                Room room = CreateRoomByType(roomTypeName);

                // Set common properties
                room.RoomNumber = txtRoomNumber.Text.Trim();
                room.Floor = (int)nudFloor.Value;
                room.RoomTypeName = roomTypeName;
                room.StatusName = cmbStatus.SelectedItem?.ToString();
                room.ViewName = cmbView.SelectedItem?.ToString();

                // Get selected amenities from database
                room.Amenities = GetSelectedAmenities();

                // Calculate and update base rate with amenity surcharge
                int selectedAmenityCount = room.Amenities?.Count ?? 0;
                room.BaseRate += (selectedAmenityCount * 100m);

                // Note: Beds are already set in CreateRoomByType method
                // RoomRepository will save them automatically

                bool success;

                if (_isAddingNew)
                {
                    // Check for duplicate room number
                    bool duplicateExists = _allRooms.Any(r =>
                        r.RoomNumber.Equals(room.RoomNumber, StringComparison.OrdinalIgnoreCase));

                    if (duplicateExists)
                    {
                        Helper.ShowError($"Room number {room.RoomNumber} already exists!");
                        return;
                    }

                    // Add new room
                    success = _roomManager.AddRoom(room);

                    if (success)
                    {
                        Helper.ShowSuccess("Room added successfully!");
                    }
                    else
                    {
                        Helper.ShowError("Failed to add room.");
                        return;
                    }
                }
                else
                {
                    // Update existing room
                    if (_selectedRoom == null)
                    {
                        Helper.ShowError("No room selected for update. Please select a room to edit.");
                        return;
                    }

                    room.RoomId = _selectedRoom.RoomId;
                    success = _roomManager.UpdateRoom(room);

                    if (success)
                    {
                        Helper.ShowSuccess("Room updated successfully!");
                    }
                    else
                    {
                        Helper.ShowError("Failed to update room.");
                        return;
                    }
                }

                if (success)
                {
                    LoadRooms();
                    ResetRoomForm();
                }
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error saving room: {ex.Message}\n\n{ex.StackTrace}");
            }
        }

        private List<Amenity> GetSelectedAmenities()
        {
            var selectedAmenities = new List<Amenity>();

            // Get checked items and find corresponding Amenity objects
            foreach (var checkedItem in clbAmenities.CheckedItems)
            {
                string displayedAmenity = checkedItem.ToString();
                // Remove the (+₱100) suffix to get the original amenity name
                string amenityName = displayedAmenity.Replace(" (+₱100)", "");

                // Find the amenity in our list
                var amenity = _allAmenities.FirstOrDefault(a =>
                    a.AmenityName.Equals(amenityName, StringComparison.OrdinalIgnoreCase));

                if (amenity != null)
                {
                    selectedAmenities.Add(amenity);
                }
                else
                {
                    // If not found in database, create a new one (for fallback scenario)
                    selectedAmenities.Add(new Amenity
                    {
                        AmenityName = amenityName,
                        Category = "General",
                        IsStandard = true
                    });
                }
            }

            return selectedAmenities;
        }

        private Room CreateRoomByType(string roomTypeName)
        {
            // Create a concrete instance
            var room = new ConcreteRoom();

            // Set properties based on room type
            if (roomTypeName == "Standard Single")
            {
                room.BaseRate = 3000.00m;
                room.MaxOccupancy = 1;
                // This room should have 1 Single bed (bed_type_id = 1)
                room.Beds = new List<RoomBed>
                {
                    new RoomBed { BedTypeId = 1, BedTypeName = "Single", Quantity = 1 }
                };
            }
            else if (roomTypeName == "Standard Double")
            {
                room.BaseRate = 500.00m;
                room.MaxOccupancy = 2;
                // This room should have 1 Double bed (bed_type_id = 2)
                room.Beds = new List<RoomBed>
                {
                    new RoomBed { BedTypeId = 2, BedTypeName = "Double", Quantity = 1 }
                };
            }
            else if (roomTypeName == "Deluxe King")
            {
                room.BaseRate = 12122.00m;
                room.MaxOccupancy = 2;
                // This room should have 1 King bed (bed_type_id = 4)
                room.Beds = new List<RoomBed>
                {
                    new RoomBed { BedTypeId = 4, BedTypeName = "King", Quantity = 1 }
                };
            }
            else if (roomTypeName == "Family Suite")
            {
                room.BaseRate = 400.00m;
                room.MaxOccupancy = 4;
                // This room should have 2 Bunk Beds (bed_type_id = 6)
                room.Beds = new List<RoomBed>
                {
                    new RoomBed { BedTypeId = 6, BedTypeName = "Bunk Bed", Quantity = 2 }
                };
            }
            else if (roomTypeName == "Executive Suite")
            {
                room.BaseRate = 250.00m;
                room.MaxOccupancy = 2;
                // This room should have 1 Queen bed (bed_type_id = 3)
                room.Beds = new List<RoomBed>
                {
                    new RoomBed { BedTypeId = 3, BedTypeName = "Queen", Quantity = 1 }
                };
            }
            else if (roomTypeName == "Penthouse")
            {
                room.BaseRate = 400.00m;
                room.MaxOccupancy = 4;
                // This room should have 1 King bed (bed_type_id = 4)
                room.Beds = new List<RoomBed>
                {
                    new RoomBed { BedTypeId = 4, BedTypeName = "King", Quantity = 1 }
                };
            }
            else if (roomTypeName == "Junior Suite")
            {
                room.BaseRate = 180.00m;
                room.MaxOccupancy = 3;
                // This room should have 1 Single bed (bed_type_id = 1)
                room.Beds = new List<RoomBed>
                {
                    new RoomBed { BedTypeId = 1, BedTypeName = "Single", Quantity = 1 }
                };
            }
            else
            {
                room.BaseRate = 100.00m;
                room.MaxOccupancy = 2;
                room.Beds = new List<RoomBed>();
            }

            return room;
        }

        private bool ValidateRoomForm()
        {
            // Check for placeholder text
            if (txtRoomNumber.Text == "Room Number" || string.IsNullOrWhiteSpace(txtRoomNumber.Text))
            {
                Helper.ShowError("Room number is required");
                txtRoomNumber.Focus();
                return false;
            }

            if (cmbRoomType.SelectedIndex == -1)
            {
                Helper.ShowError("Room type is required");
                cmbRoomType.Focus();
                return false;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
                Helper.ShowError("Status is required");
                cmbStatus.Focus();
                return false;
            }

            if (cmbView.SelectedIndex == -1)
            {
                Helper.ShowError("View type is required");
                cmbView.Focus();
                return false;
            }

            return true;
        }

        private void ResetRoomForm()
        {
            txtRoomNumber.Text = "Room Number";
            txtRoomNumber.ForeColor = SystemColors.GrayText;

            cmbRoomType.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            cmbView.SelectedIndex = -1;
            nudFloor.Value = 1;

            // Clear amenities selection
            for (int i = 0; i < clbAmenities.Items.Count; i++)
            {
                clbAmenities.SetItemChecked(i, false);
            }

            // Clear beds display
            dgvBeds.Rows.Clear();

            _selectedRoom = null;
            _isAddingNew = false;
            pnlRoomDetails.Enabled = false;
            btnSaveRoom.Text = "Save Room";
        }

        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            if (_selectedRoom != null)
            {
                pnlRoomDetails.Enabled = true;
                btnSaveRoom.Text = "Update Room";
                txtRoomNumber.Focus();
            }
            else
            {
                Helper.ShowError("Please select a room to edit");
            }
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (_selectedRoom == null)
            {
                Helper.ShowError("Please select a room to delete");
                return;
            }

            if (Helper.ConfirmAction($"Are you sure you want to delete room {_selectedRoom.RoomNumber}?")
                == DialogResult.Yes)
            {
                try
                {
                    bool success = _roomManager.DeleteRoom(_selectedRoom.RoomId);

                    if (success)
                    {
                        Helper.ShowSuccess("Room deleted successfully!");
                        LoadRooms();
                        ResetRoomForm();
                    }
                    else
                    {
                        Helper.ShowError("Failed to delete room.");
                    }
                }
                catch (Exception ex)
                {
                    Helper.ShowError($"Error deleting room: {ex.Message}");
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRooms();
            ResetRoomForm();

            // Reset filters
            cmbFilterType.SelectedIndex = 0;
            cmbFilterStatus.SelectedIndex = 0;
            cmbFilterView.SelectedIndex = 0;

            // Reset search
            txtSearch.Text = "Search rooms...";
            txtSearch.ForeColor = SystemColors.GrayText;
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            ResetRoomForm();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search rooms...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = SystemColors.ControlText;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search rooms...";
                txtSearch.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Enter key
            {
                btnSearch.PerformClick();
            }
        }

        private void txtRoomNumber_Enter(object sender, EventArgs e)
        {
            if (txtRoomNumber.Text == "Room Number")
            {
                txtRoomNumber.Text = "";
                txtRoomNumber.ForeColor = SystemColors.ControlText;
            }
        }

        private void txtRoomNumber_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoomNumber.Text))
            {
                txtRoomNumber.Text = "Room Number";
                txtRoomNumber.ForeColor = SystemColors.GrayText;
            }
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbFilterView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnViewStatistics_Click(object sender, EventArgs e)
        {
            try
            {
                var statistics = _roomManager.GetRoomStatistics();
                var occupancyRate = _roomManager.GetOccupancyRate();

                string statsText = $"Room Statistics:\n\n" +
                                 $"Total Rooms: {statistics["Total"]}\n" +
                                 $"Available: {statistics["Available"]}\n" +
                                 $"Occupied: {statistics["Occupied"]}\n" +
                                 $"Reserved: {statistics["Reserved"]}\n" +
                                 $"Maintenance: {statistics["Maintenance"]}\n\n" +
                                 $"Occupancy Rate: {occupancyRate:F2}%";

                MessageBox.Show(statsText, "Room Statistics",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error loading statistics: {ex.Message}");
            }
        }

        private void btnManageAmenities_Click(object sender, EventArgs e)
        {
            // Optional: Add a button to open a form for managing amenities
            MessageBox.Show("Amenity management feature can be added here.\n\n" +
                          "You could create a separate form to add/edit/delete amenities in the database.",
                          "Manage Amenities",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }

        // Test method to check if dgvBeds is working
        private void btnTestDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                // Test 1: Check if dgvBeds is accessible
                MessageBox.Show($"dgvBeds exists: {dgvBeds != null}\n" +
                               $"Column count: {dgvBeds.Columns.Count}\n" +
                               $"Visible: {dgvBeds.Visible}",
                               "dgvBeds Status");

                // Test 2: Try to add data directly
                dgvBeds.Rows.Clear();

                // Test if we can add rows
                int rowIndex = dgvBeds.Rows.Add();
                dgvBeds.Rows[rowIndex].Cells["colBedType"].Value = "TEST BED";
                dgvBeds.Rows[rowIndex].Cells["colQuantity"].Value = "99";

                MessageBox.Show("Test data added. Can you see 'TEST BED' in dgvBeds?",
                               "Manual Test");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in test: {ex.Message}\n\n{ex.StackTrace}",
                               "Test Error");
            }
        }

        // ADD THIS METHOD to debug bed loading
        private void btnDebugBeds_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedRoom != null)
                {
                    // Test direct database query
                    using (var conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        string query = @"
                            SELECT rb.*, bt.bed_type_name 
                            FROM room_beds rb 
                            LEFT JOIN bed_types bt ON rb.bed_type_id = bt.bed_type_id 
                            WHERE rb.room_id = @roomId";

                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@roomId", _selectedRoom.RoomId);

                            using (var reader = cmd.ExecuteReader())
                            {
                                List<string> results = new List<string>();
                                while (reader.Read())
                                {
                                    string bedTypeName = reader["bed_type_name"]?.ToString() ?? "Unknown";
                                    int quantity = Convert.ToInt32(reader["quantity"]);
                                    results.Add($"{quantity} x {bedTypeName}");
                                }

                                if (results.Count > 0)
                                {
                                    MessageBox.Show($"Found beds for room {_selectedRoom.RoomNumber}:\n\n{string.Join("\n", results)}",
                                                  "Direct DB Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show($"No beds found for room {_selectedRoom.RoomNumber} (ID: {_selectedRoom.RoomId})",
                                                  "Direct DB Test", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a room first", "Debug",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // NEW EVENT HANDLER: Update rate display when amenities change
        private void clbAmenities_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Use BeginInvoke to update after the check state has changed
            BeginInvoke((MethodInvoker)delegate {
                UpdateRateDisplay();
            });
        }

        // NEW EVENT HANDLER: Update rate display when room type changes
        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRateDisplay();
        }
    }
}