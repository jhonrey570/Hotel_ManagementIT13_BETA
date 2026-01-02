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
        private RoomRepository _roomRepo;
        private List<Guest> _searchResults;
        private List<Room> _availableRooms;
        private Guest _selectedGuest;
        private List<int> _selectedRoomIds;

        public frmReservation()
        {
            // InitializeComponent MUST be called first
            InitializeComponent();

            InitializeFields();
        }

        private void InitializeFields()
        {
            _reservationManager = new ReservationManager();
            _guestManager = new GuestManager();
            _roomRepo = new RoomRepository();
            _searchResults = new List<Guest>();
            _availableRooms = new List<Room>();
            _selectedRoomIds = new List<int>();
        }

        private void frmReservation_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Set default dates
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);

            // Load room types
            LoadRoomTypes();

            // Load special requests
            LoadSpecialRequests();

            // Initialize data grids
            InitializeDataGrids();

            // Calculate initial total
            CalculateTotal();

            // Initialize UI state
            lblSelectedGuest.Text = "No guest selected";
            lblSelectedGuest.ForeColor = Color.Red;
            lblTotalAmount.Text = "$0.00";

            // Disable booking controls initially
            EnableBookingControls(false);
        }

        private void LoadRoomTypes()
        {
            cmbRoomType.Items.Clear();
            cmbRoomType.Items.Add("All Types");

            // In real implementation, load from database
            cmbRoomType.Items.Add("Single");
            cmbRoomType.Items.Add("Double");
            cmbRoomType.Items.Add("Twin");
            cmbRoomType.Items.Add("Suite");
            cmbRoomType.Items.Add("Deluxe");
            cmbRoomType.Items.Add("Presidential");

            cmbRoomType.SelectedIndex = 0;
        }

        private void LoadSpecialRequests()
        {
            clbSpecialRequests.Items.Clear();

            clbSpecialRequests.Items.Add("Early Check-in (before 2 PM)");
            clbSpecialRequests.Items.Add("Late Check-out (after 12 PM)");
            clbSpecialRequests.Items.Add("Extra Bed");
            clbSpecialRequests.Items.Add("Crib/Child Bed");
            clbSpecialRequests.Items.Add("Non-smoking Room");
            clbSpecialRequests.Items.Add("High Floor");
            clbSpecialRequests.Items.Add("Adjoining Rooms");
            clbSpecialRequests.Items.Add("Airport Transfer");
        }

        private void InitializeDataGrids()
        {
            // Guest results grid
            dgvGuestResults.Columns.Clear();
            dgvGuestResults.Columns.Add("colGuestId", "ID");
            dgvGuestResults.Columns.Add("colName", "Name");
            dgvGuestResults.Columns.Add("colPhone", "Phone");
            dgvGuestResults.Columns.Add("colEmail", "Email");
            dgvGuestResults.Columns.Add("colType", "Type");

            dgvGuestResults.Columns["colGuestId"].Visible = false;
            dgvGuestResults.Columns["colName"].Width = 150;
            dgvGuestResults.Columns["colPhone"].Width = 100;
            dgvGuestResults.Columns["colEmail"].Width = 150;
            dgvGuestResults.Columns["colType"].Width = 80;

            // Available rooms grid
            dgvAvailableRooms.Columns.Clear();
            dgvAvailableRooms.Columns.Add("colSelect", "Select");
            dgvAvailableRooms.Columns.Add("colRoomId", "ID");
            dgvAvailableRooms.Columns.Add("colRoomNumber", "Room #");
            dgvAvailableRooms.Columns.Add("colType", "Type");
            dgvAvailableRooms.Columns.Add("colFloor", "Floor");
            dgvAvailableRooms.Columns.Add("colView", "View");
            dgvAvailableRooms.Columns.Add("colRate", "Rate/Night");

            dgvAvailableRooms.Columns["colSelect"].Width = 50;
            dgvAvailableRooms.Columns["colRoomId"].Visible = false;
            dgvAvailableRooms.Columns["colRoomNumber"].Width = 70;
            dgvAvailableRooms.Columns["colType"].Width = 80;
            dgvAvailableRooms.Columns["colFloor"].Width = 50;
            dgvAvailableRooms.Columns["colView"].Width = 80;
            dgvAvailableRooms.Columns["colRate"].Width = 90;

            // Make the select column a checkbox
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Select";
            checkBoxColumn.Name = "colSelectCheck";

            // Remove the old select column and add checkbox column
            if (dgvAvailableRooms.Columns.Contains("colSelect"))
            {
                dgvAvailableRooms.Columns.Remove("colSelect");
            }

            // Insert at beginning
            dgvAvailableRooms.Columns.Insert(0, checkBoxColumn);

            // Ensure checkbox column is first
            checkBoxColumn.DisplayIndex = 0;
        }

        private void btnSearchGuest_Click(object sender, EventArgs e)
        {
            string searchTerm = txtGuestSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                MessageBox.Show("Please enter search term",
                              "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = _guestManager.SearchGuests(searchTerm);

            if (result.Success)
            {
                _searchResults = result.Guests;
                DisplayGuestResults();
            }
            else
            {
                MessageBox.Show(result.Message,
                              "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DisplayGuestResults()
        {
            dgvGuestResults.Rows.Clear();

            foreach (var guest in _searchResults)
            {
                dgvGuestResults.Rows.Add(
                    guest.GuestId,
                    guest.FullName,
                    guest.Phone,
                    guest.Email,
                    guest.GuestTypeName
                );
            }

            lblSearchResults.Text = $"Found {_searchResults.Count} guest(s)";
        }

        private void dgvGuestResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _searchResults.Count)
            {
                _selectedGuest = _searchResults[e.RowIndex];
                DisplaySelectedGuest();
            }
        }

        private void DisplaySelectedGuest()
        {
            if (_selectedGuest != null)
            {
                lblSelectedGuest.Text = $"Selected: {_selectedGuest.FullName}";
                lblSelectedGuest.ForeColor = Color.Green;

                // Enable booking controls
                EnableBookingControls(true);

                // Search for available rooms
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
            if (_selectedGuest == null)
                return;

            DateTime checkIn = dtpCheckIn.Value;
            DateTime checkOut = dtpCheckOut.Value;

            if (!Validator.ValidateDateRange(checkIn, checkOut))
                return;

            try
            {
                // Get available rooms
                int roomTypeId = cmbRoomType.SelectedIndex; // 0 = All
                _availableRooms = _roomRepo.GetAvailableRooms(checkIn, checkOut, roomTypeId);

                DisplayAvailableRooms();

                // Clear previous selections
                _selectedRoomIds.Clear();
                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching rooms: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayAvailableRooms()
        {
            dgvAvailableRooms.Rows.Clear();

            foreach (var room in _availableRooms)
            {
                int rowIndex = dgvAvailableRooms.Rows.Add(
                    false, // Checkbox
                    room.RoomId,
                    room.RoomNumber,
                    room.RoomTypeName,
                    room.Floor,
                    room.ViewName,
                    Helper.FormatCurrency(room.BaseRate)
                );
            }

            lblAvailableRooms.Text = $"Available: {_availableRooms.Count} room(s)";
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            if (_selectedGuest == null || _selectedRoomIds.Count == 0)
            {
                lblTotalAmount.Text = "$0.00";
                return;
            }

            DateTime checkIn = dtpCheckIn.Value;
            DateTime checkOut = dtpCheckOut.Value;

            if (!Validator.ValidateDateRange(checkIn, checkOut))
                return;

            try
            {
                decimal totalAmount = _reservationManager.CalculateReservationAmount(
                    checkIn, checkOut, _selectedRoomIds, _selectedGuest.GuestTypeId);

                lblTotalAmount.Text = Helper.FormatCurrency(totalAmount);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating total: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (!ValidateBooking())
                return;

            try
            {
                // Get special requests
                string specialRequests = GetSpecialRequests();

                // Create reservation
                string result = _reservationManager.CreateReservation(
                    _selectedGuest.GuestId,
                    ApplicationContext.CurrentUser.UserId,
                    dtpCheckIn.Value,
                    dtpCheckOut.Value,
                    _selectedRoomIds,
                    (int)nudAdults.Value,
                    (int)nudChildren.Value,
                    specialRequests);

                if (result.Contains("successfully"))
                {
                    MessageBox.Show(result,
                                  "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset form
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(result,
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating reservation: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateBooking()
        {
            if (_selectedGuest == null)
            {
                MessageBox.Show("Please select a guest",
                              "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_selectedRoomIds.Count == 0)
            {
                MessageBox.Show("Please select at least one room",
                              "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Validator.ValidateDateRange(dtpCheckIn.Value, dtpCheckOut.Value))
                return false;

            if (!Validator.ValidateNumber(nudAdults, "Adults"))
                return false;

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

            // Add custom notes
            if (!string.IsNullOrWhiteSpace(rtbNotes.Text))
            {
                requests.Add($"Notes: {rtbNotes.Text}");
            }

            return string.Join("; ", requests);
        }

        private void ResetForm()
        {
            // Clear all inputs
            txtGuestSearch.Clear();
            _selectedGuest = null;
            _searchResults.Clear();
            _availableRooms.Clear();
            _selectedRoomIds.Clear();

            dgvGuestResults.Rows.Clear();
            dgvAvailableRooms.Rows.Clear();

            lblSelectedGuest.Text = "No guest selected";
            lblSelectedGuest.ForeColor = Color.Red;
            lblTotalAmount.Text = "$0.00";

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
                bool isChecked = false;
                var cellValue = dgvAvailableRooms.Rows[e.RowIndex].Cells[0].Value;

                if (cellValue != null)
                {
                    isChecked = Convert.ToBoolean(cellValue);
                }

                int roomId = Convert.ToInt32(
                    dgvAvailableRooms.Rows[e.RowIndex].Cells[1].Value);

                if (isChecked)
                {
                    if (!_selectedRoomIds.Contains(roomId))
                    {
                        _selectedRoomIds.Add(roomId);
                    }
                }
                else
                {
                    _selectedRoomIds.Remove(roomId);
                }

                CalculateTotal();
            }
        }

        private void btnNewGuest_Click(object sender, EventArgs e)
        {
            // Open guest registration form
            frmGuestManagement guestForm = new frmGuestManagement();
            guestForm.ShowDialog();

            // Refresh search if needed
            if (!string.IsNullOrEmpty(txtGuestSearch.Text))
            {
                btnSearchGuest.PerformClick();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Helper.ConfirmAction("Are you sure you want to cancel? Unsaved changes will be lost.")
                == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // Event handlers for data grid view
        private void dgvAvailableRooms_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvAvailableRooms.IsCurrentCellDirty)
            {
                dgvAvailableRooms.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}