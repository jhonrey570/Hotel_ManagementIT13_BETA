using Hotel_ManagementIT13.Data;
using Hotel_ManagementIT13.Data.Managers;
using Hotel_ManagementIT13.Data.Models;
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
        private List<Room> _allRooms;
        private List<string> _roomTypes;
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
                // Simple calculation based on base rate
                decimal rate = this.BaseRate * nights;

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
            _allRooms = new List<Room>();
            _roomTypes = new List<string>();
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

                // Load status types
                cmbStatus.Items.Clear();
                cmbStatus.Items.AddRange(new string[] { "Available", "Occupied", "Reserved", "Maintenance" });

                // Load view types
                cmbView.Items.Clear();
                cmbView.Items.AddRange(new string[] { "City View", "Garden View", "Pool View", "Ocean View" });

                // Load amenities
                clbAmenities.Items.Clear();
                clbAmenities.Items.AddRange(new string[]
                {
                    "Wi-Fi", "TV", "Mini Bar", "Air Conditioning",
                    "Balcony", "Jacuzzi", "Kitchenette", "Safe",
                    "Hairdryer", "Iron", "Coffee Maker", "Refrigerator"
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading form data: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                cmbFilterStatus.Items.Clear();
                cmbFilterStatus.Items.Add("All Status");
                cmbFilterStatus.Items.AddRange(new string[] { "Available", "Occupied", "Reserved", "Maintenance" });
                cmbFilterStatus.SelectedIndex = 0;

                cmbFilterView.Items.Clear();
                cmbFilterView.Items.Add("All Views");
                cmbFilterView.Items.AddRange(new string[] { "City View", "Garden View", "Pool View", "Ocean View" });
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
                dgvRooms.Rows.Add(
                    room.RoomId,
                    room.RoomNumber,
                    room.RoomTypeName ?? "N/A",
                    room.Floor,
                    room.StatusName ?? "N/A",
                    room.ViewName ?? "N/A",
                    Helper.FormatCurrency(room.BaseRate),
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
                    var roomIdCell = dgvRooms.Rows[e.RowIndex].Cells[0];
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

            if (!string.IsNullOrEmpty(room.RoomTypeName))
                cmbRoomType.SelectedItem = room.RoomTypeName;

            if (!string.IsNullOrEmpty(room.StatusName))
                cmbStatus.SelectedItem = room.StatusName;

            if (!string.IsNullOrEmpty(room.ViewName))
                cmbView.SelectedItem = room.ViewName;

            nudFloor.Value = room.Floor;

            // Set amenities
            for (int i = 0; i < clbAmenities.Items.Count; i++)
            {
                string amenity = clbAmenities.Items[i].ToString();
                clbAmenities.SetItemChecked(i, room.Amenities?.Any(a => a.AmenityName == amenity) ?? false);
            }

            _isAddingNew = false;
            btnSaveRoom.Text = "Update Room";
            pnlRoomDetails.Enabled = true;
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

                // Get selected amenities
                room.Amenities = new List<Amenity>();
                foreach (var item in clbAmenities.CheckedItems)
                {
                    room.Amenities.Add(new Amenity
                    {
                        AmenityName = item.ToString(),
                        Category = "General",
                        IsStandard = true
                    });
                }

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

        private Room CreateRoomByType(string roomTypeName)
        {
            // Create a concrete instance
            var room = new ConcreteRoom();
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
    }
}