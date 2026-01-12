using Hotel_ManagementIT13.Data.Managers;
using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
using Hotel_ManagementIT13.Services;
using Hotel_ManagementIT13.Utilities;
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
        private RoomOperationService _roomService;
        private DatabaseAccessService _databaseService;
        private FormValidationService _validationService;
        private UIStateManagementService _uiStateService;

        private List<Room> _allRooms;
        private List<string> _roomTypes;
        private List<string> _roomStatuses;
        private List<string> _roomViews;
        private List<Amenity> _allAmenities;
        private Room _selectedRoom;
        private bool _isAddingNew;

        public frmRoomManagement()
        {
            InitializeComponent();

            _roomManager = new RoomManager();
            _amenityRepo = new AmenityRepository();
            _bedRepo = new BedRepository();
            _roomService = new RoomOperationService();
            _databaseService = new DatabaseAccessService();
            _validationService = new FormValidationService();
            _uiStateService = new UIStateManagementService();

            _allRooms = new List<Room>();
            _roomTypes = new List<string>();
            _roomStatuses = new List<string>();
            _roomViews = new List<string>();
            _allAmenities = new List<Amenity>();
        }

        private void frmRoomManagement_Load(object sender, EventArgs e)
        {
            try
            {
                if (!_databaseService.TestDatabaseConnection())
                {
                    MessageBox.Show("Cannot connect to database", "Database Connection Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoadFormData();
                LoadRooms();
                ResetRoomForm();
                SetupUIState();
                SetupFilterControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading form: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupUIState()
        {
            _uiStateService.SetPlaceholderText(txtSearch, "Search rooms...");
            _uiStateService.SetPlaceholderText(txtRoomNumber, "Room Number");
        }

        private void LoadFormData()
        {
            _roomTypes = _databaseService.GetRoomTypes();
            cmbRoomType.Items.Clear();
            cmbRoomType.Items.AddRange(_roomTypes.ToArray());

            _roomStatuses = _databaseService.GetRoomStatuses();
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(_roomStatuses.ToArray());

            _roomViews = _databaseService.GetRoomViews();
            cmbView.Items.Clear();
            cmbView.Items.AddRange(_roomViews.ToArray());

            LoadAmenities();
        }

        private void LoadAmenities()
        {
            try
            {
                _allAmenities = _amenityRepo.GetAllAmenities();
                clbAmenities.Items.Clear();

                foreach (var amenity in _allAmenities)
                {
                    clbAmenities.Items.Add($"{amenity.AmenityName} (+₱100)", false);
                }
            }
            catch
            {
                LoadDefaultAmenities();
            }
        }

        private void LoadDefaultAmenities()
        {
            clbAmenities.Items.Clear();
            clbAmenities.Items.AddRange(new string[]
            {
                "Wi-Fi (+₱100)", "TV (+₱100)", "Mini Bar (+₱100)", "Air Conditioning (+₱100)",
                "Balcony (+₱100)", "Jacuzzi (+₱100)", "Kitchenette (+₱100)", "Safe (+₱100)",
                "Hairdryer (+₱100)", "Iron (+₱100)", "Coffee Maker (+₱100)", "Refrigerator (+₱100)"
            });
        }

        private void SetupFilterControls()
        {
            _uiStateService.InitializeFilterComboBox(cmbFilterType, "All Types", _roomTypes);
            _uiStateService.InitializeFilterComboBox(cmbFilterStatus, "All Status", _roomStatuses);
            _uiStateService.InitializeFilterComboBox(cmbFilterView, "All Views", _roomViews);
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
                decimal totalRate = CalculateTotalRate(room.BaseRate, room.Amenities?.Count ?? 0);

                dgvRooms.Rows.Add(
                    room.RoomId,
                    room.RoomNumber,
                    room.RoomTypeName ?? "N/A",
                    room.Floor,
                    room.StatusName ?? "N/A",
                    room.ViewName ?? "N/A",
                    FormatCurrency(totalRate),
                    room.MaxOccupancy
                );
            }

            lblRoomCount.Text = $"{rooms.Count} room(s) found";
        }

        private decimal CalculateTotalRate(decimal baseRate, int amenityCount)
        {
            return baseRate + (amenityCount * 100m);
        }

        private string FormatCurrency(decimal amount)
        {
            return "₱" + amount.ToString("N2");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            if (_validationService.IsPlaceholderText(searchTerm, "Search rooms..."))
            {
                DisplayRooms(_allRooms);
                return;
            }

            try
            {
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

            if (cmbFilterStatus.SelectedIndex > 0)
            {
                string selectedStatus = cmbFilterStatus.SelectedItem.ToString();
                filteredRooms = filteredRooms.Where(r => r.StatusName == selectedStatus).ToList();
            }

            if (cmbFilterType.SelectedIndex > 0)
            {
                string selectedType = cmbFilterType.SelectedItem.ToString();
                filteredRooms = filteredRooms.Where(r => r.RoomTypeName == selectedType).ToList();
            }

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

            if (!string.IsNullOrEmpty(room.RoomTypeName))
            {
                int index = cmbRoomType.FindStringExact(room.RoomTypeName);
                if (index >= 0)
                    cmbRoomType.SelectedIndex = index;
            }

            if (!string.IsNullOrEmpty(room.StatusName))
            {
                int index = cmbStatus.FindStringExact(room.StatusName);
                if (index >= 0)
                    cmbStatus.SelectedIndex = index;
            }

            if (!string.IsNullOrEmpty(room.ViewName))
            {
                int index = cmbView.FindStringExact(room.ViewName);
                if (index >= 0)
                    cmbView.SelectedIndex = index;
            }

            nudFloor.Value = room.Floor;

            SetAmenitiesForRoom(room);
            LoadRoomBeds(room.RoomId);
            UpdateRateDisplay();

            _isAddingNew = false;
            btnSaveRoom.Text = "Update Room";
            pnlRoomDetails.Enabled = true;
        }

        private void SetAmenitiesForRoom(Room room)
        {
            for (int i = 0; i < clbAmenities.Items.Count; i++)
            {
                clbAmenities.SetItemChecked(i, false);
            }

            if (room.Amenities != null && room.Amenities.Count > 0)
            {
                foreach (var roomAmenity in room.Amenities)
                {
                    string cleanAmenityName = roomAmenity.AmenityName;

                    for (int i = 0; i < clbAmenities.Items.Count; i++)
                    {
                        string displayedAmenity = clbAmenities.Items[i].ToString();
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

        private void UpdateRateDisplay()
        {
            if (cmbRoomType.SelectedIndex >= 0 && !string.IsNullOrEmpty(cmbRoomType.SelectedItem.ToString()))
            {
                string roomTypeName = cmbRoomType.SelectedItem.ToString();
                Room sampleRoom = CreateRoomByType(roomTypeName);

                int selectedAmenityCount = clbAmenities.CheckedItems.Count;
                decimal totalRate = CalculateTotalRate(sampleRoom.BaseRate, selectedAmenityCount);
            }
        }

        private Room CreateRoomByType(string roomTypeName)
        {
            var room = new ConcreteRoom();

            if (roomTypeName == "Standard Single")
            {
                room.BaseRate = 3000.00m;
                room.MaxOccupancy = 1;
                room.Beds = new List<RoomBed>
                {
                    new RoomBed { BedTypeId = 1, BedTypeName = "Single", Quantity = 1 }
                };
            }
            else if (roomTypeName == "Standard Double")
            {
                room.BaseRate = 500.00m;
                room.MaxOccupancy = 2;
                room.Beds = new List<RoomBed>
                {
                    new RoomBed { BedTypeId = 2, BedTypeName = "Double", Quantity = 1 }
                };
            }
            else if (roomTypeName == "Deluxe King")
            {
                room.BaseRate = 12122.00m;
                room.MaxOccupancy = 2;
                room.Beds = new List<RoomBed>
                {
                    new RoomBed { BedTypeId = 4, BedTypeName = "King", Quantity = 1 }
                };
            }
            else if (roomTypeName == "Family Suite")
            {
                room.BaseRate = 400.00m;
                room.MaxOccupancy = 4;
                room.Beds = new List<RoomBed>
                {
                    new RoomBed { BedTypeId = 6, BedTypeName = "Bunk Bed", Quantity = 2 }
                };
            }
            else if (roomTypeName == "Executive Suite")
            {
                room.BaseRate = 250.00m;
                room.MaxOccupancy = 2;
                room.Beds = new List<RoomBed>
                {
                    new RoomBed { BedTypeId = 3, BedTypeName = "Queen", Quantity = 1 }
                };
            }
            else if (roomTypeName == "Penthouse")
            {
                room.BaseRate = 400.00m;
                room.MaxOccupancy = 4;
                room.Beds = new List<RoomBed>
                {
                    new RoomBed { BedTypeId = 4, BedTypeName = "King", Quantity = 1 }
                };
            }
            else if (roomTypeName == "Junior Suite")
            {
                room.BaseRate = 180.00m;
                room.MaxOccupancy = 3;
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
            if (!_validationService.ValidateRoomForm(txtRoomNumber.Text, cmbRoomType, cmbStatus, cmbView))
            {
                Helper.ShowError("Please fill all required fields");
                return;
            }

            try
            {
                string roomTypeName = cmbRoomType.SelectedItem?.ToString();
                Room room = CreateRoomByType(roomTypeName);

                room.RoomNumber = txtRoomNumber.Text.Trim();
                room.Floor = (int)nudFloor.Value;
                room.RoomTypeName = roomTypeName;
                room.StatusName = cmbStatus.SelectedItem?.ToString();
                room.ViewName = cmbView.SelectedItem?.ToString();
                room.Amenities = GetSelectedAmenities();

                int selectedAmenityCount = room.Amenities?.Count ?? 0;
                room.BaseRate += (selectedAmenityCount * 100m);

                bool success;

                if (_isAddingNew)
                {
                    bool duplicateExists = _allRooms.Any(r =>
                        r.RoomNumber.Equals(room.RoomNumber, StringComparison.OrdinalIgnoreCase));

                    if (duplicateExists)
                    {
                        Helper.ShowError($"Room number {room.RoomNumber} already exists!");
                        return;
                    }

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
                    if (_selectedRoom == null)
                    {
                        Helper.ShowError("No room selected for update.");
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
                Helper.ShowError($"Error saving room: {ex.Message}");
            }
        }

        private List<Amenity> GetSelectedAmenities()
        {
            var selectedAmenities = new List<Amenity>();

            foreach (var checkedItem in clbAmenities.CheckedItems)
            {
                string displayedAmenity = checkedItem.ToString();
                string amenityName = displayedAmenity.Replace(" (+₱100)", "");

                var amenity = _allAmenities.FirstOrDefault(a =>
                    a.AmenityName.Equals(amenityName, StringComparison.OrdinalIgnoreCase));

                if (amenity != null)
                {
                    selectedAmenities.Add(amenity);
                }
                else
                {
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

        private void ResetRoomForm()
        {
            _uiStateService.SetPlaceholderText(txtRoomNumber, "Room Number");

            cmbRoomType.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            cmbView.SelectedIndex = -1;
            nudFloor.Value = 1;

            for (int i = 0; i < clbAmenities.Items.Count; i++)
            {
                clbAmenities.SetItemChecked(i, false);
            }

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

            cmbFilterType.SelectedIndex = 0;
            cmbFilterStatus.SelectedIndex = 0;
            cmbFilterView.SelectedIndex = 0;

            _uiStateService.SetPlaceholderText(txtSearch, "Search rooms...");
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            ResetRoomForm();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            _uiStateService.ClearPlaceholderOnEnter(txtSearch);
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            _uiStateService.RestorePlaceholderOnLeave(txtSearch);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }
        }

        private void txtRoomNumber_Enter(object sender, EventArgs e)
        {
            _uiStateService.ClearPlaceholderOnEnter(txtRoomNumber);
        }

        private void txtRoomNumber_Leave(object sender, EventArgs e)
        {
            _uiStateService.RestorePlaceholderOnLeave(txtRoomNumber);
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
            MessageBox.Show("Amenity management feature can be added here.",
                          "Manage Amenities",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }

        private void clbAmenities_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate {
                UpdateRateDisplay();
            });
        }

        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRateDisplay();
        }
    }
}