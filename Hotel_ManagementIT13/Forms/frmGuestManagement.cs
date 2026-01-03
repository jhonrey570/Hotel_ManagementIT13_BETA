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
    public partial class frmGuestManagement : Form
    {
        private GuestManager _guestManager;
        private GuestRepository _guestRepo;
        private Guest _selectedGuest;
        private bool _isAddingNew;

        public frmGuestManagement()
        {
            InitializeComponent();
            _guestManager = new GuestManager();
            _guestRepo = new GuestRepository();

            // Add the Load event handler
            this.Load += new System.EventHandler(this.frmGuestManagement_Load);
        }

        private void frmGuestManagement_Load(object sender, EventArgs e)
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
            LoadFormData();
            LoadGuests();
            ResetGuestForm();

            // Set placeholder tags for textboxes
            txtFirstName.Tag = "First Name";
            txtLastName.Tag = "Last Name";
            txtEmail.Tag = "Email Address";
            txtPhone.Tag = "Phone Number";
            txtAddress.Tag = "Address";
            txtIDNumber.Tag = "ID Number";
            txtSearch.Tag = "Search guests by name, email, or phone...";

            // Set initial placeholder colors
            txtSearch.ForeColor = SystemColors.GrayText;
            txtFirstName.ForeColor = SystemColors.GrayText;
            txtLastName.ForeColor = SystemColors.GrayText;
            txtEmail.ForeColor = SystemColors.GrayText;
            txtPhone.ForeColor = SystemColors.GrayText;
            txtAddress.ForeColor = SystemColors.GrayText;
            txtIDNumber.ForeColor = SystemColors.GrayText;
        }

        private void LoadFormData()
        {
            // Load guest types
            cmbGuestType.Items.Clear();
            cmbGuestType.Items.Add("Regular");
            cmbGuestType.Items.Add("VIP");
            cmbGuestType.Items.Add("Corporate");
            cmbGuestType.Items.Add("Travel Agency");
            cmbGuestType.SelectedIndex = 0;

            // Load ID types
            cmbIDType.Items.Clear();
            cmbIDType.Items.Add("Passport");
            cmbIDType.Items.Add("Driver's License");
            cmbIDType.Items.Add("National ID");
            cmbIDType.Items.Add("Other");
            cmbIDType.SelectedIndex = 0;

            // Load nationalities
            cmbNationality.Items.Clear();
            cmbNationality.Items.AddRange(new string[]
            {
                "Filipino", "American", "Chinese", "Japanese", "Korean",
                "Australian", "British", "Canadian", "German", "French"
            });
            cmbNationality.SelectedIndex = 0;
        }

        private void LoadGuests()
        {
            try
            {
                var guests = _guestRepo.GetAllGuests();
                DisplayGuests(guests);
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error loading guests: {ex.Message}");
            }
        }

        private void DisplayGuests(System.Collections.Generic.List<Guest> guests)
        {
            dgvGuests.Rows.Clear();

            foreach (var guest in guests)
            {
                dgvGuests.Rows.Add(
                    guest.GuestId,
                    guest.FullName,
                    guest.Phone,
                    guest.Email,
                    guest.Nationality,
                    guest.GuestTypeName,
                    guest.CreatedAt.ToString("yyyy-MM-dd")
                );
            }

            lblGuestCount.Text = $"{guests.Count} guest(s) found";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            // Skip if placeholder text
            if (searchTerm == "Search guests by name, email, or phone..." ||
                string.IsNullOrWhiteSpace(searchTerm))
            {
                LoadGuests();
                return;
            }

            try
            {
                // Directly use repository for search
                var guests = _guestRepo.SearchGuests(searchTerm);

                if (guests.Count > 0)
                {
                    DisplayGuests(guests);
                }
                else
                {
                    MessageBox.Show("No guests found matching your search criteria.",
                                  "Search Results",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    LoadGuests();
                }
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error searching guests: {ex.Message}");
            }
        }

        private void dgvGuests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int guestId = Convert.ToInt32(dgvGuests.Rows[e.RowIndex].Cells[0].Value);
                LoadGuestDetails(guestId);
                Helper.HighlightRow(dgvGuests, e.RowIndex);
            }
        }

        private void LoadGuestDetails(int guestId)
        {
            try
            {
                _selectedGuest = _guestRepo.GetGuestById(guestId);

                if (_selectedGuest != null)
                {
                    // Fill form with guest data
                    txtFirstName.Text = _selectedGuest.FirstName;
                    txtLastName.Text = _selectedGuest.LastName;
                    txtPhone.Text = _selectedGuest.Phone;
                    txtEmail.Text = _selectedGuest.Email;
                    txtAddress.Text = _selectedGuest.Address;
                    txtIDNumber.Text = _selectedGuest.IdNumber;

                    // Set ComboBox selections
                    cmbNationality.SelectedItem = _selectedGuest.Nationality;
                    cmbIDType.SelectedItem = _selectedGuest.IdType;
                    cmbGuestType.SelectedItem = _selectedGuest.GuestTypeName;

                    // Set date
                    dtpDOB.Value = _selectedGuest.DateOfBirth ?? DateTime.Today.AddYears(-30);

                    // Update form state
                    _isAddingNew = false;
                    btnSaveGuest.Text = "Update Guest";
                    pnlGuestForm.Enabled = true;

                    // Change text colors to indicate real data
                    txtFirstName.ForeColor = SystemColors.ControlText;
                    txtLastName.ForeColor = SystemColors.ControlText;
                    txtPhone.ForeColor = SystemColors.ControlText;
                    txtEmail.ForeColor = SystemColors.ControlText;
                    txtAddress.ForeColor = SystemColors.ControlText;
                    txtIDNumber.ForeColor = SystemColors.ControlText;
                }
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error loading guest details: {ex.Message}");
            }
        }

        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            ResetGuestForm();
            _isAddingNew = true;
            btnSaveGuest.Text = "Add Guest";
            pnlGuestForm.Enabled = true;
            txtFirstName.Focus();
        }

        private void btnSaveGuest_Click(object sender, EventArgs e)
        {
            if (!ValidateGuestForm())
                return;

            try
            {
                var guest = new Guest
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Nationality = cmbNationality.Text,
                    DateOfBirth = dtpDOB.Value,
                    IdType = cmbIDType.Text,
                    IdNumber = txtIDNumber.Text.Trim(),
                    GuestTypeName = cmbGuestType.Text
                };

                // Set guest type ID based on selection
                guest.GuestTypeId = cmbGuestType.SelectedIndex + 1;

                bool success;

                if (_isAddingNew)
                {
                    // Check for duplicate guest (same name and phone)
                    var existingGuest = CheckDuplicateGuest(guest.FirstName, guest.LastName, guest.Phone);

                    if (existingGuest != null)
                    {
                        if (DialogResult.Yes == MessageBox.Show(
                            $"Guest '{guest.FullName}' already exists. Use existing guest?",
                            "Duplicate Guest",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question))
                        {
                            LoadGuestDetails(existingGuest.GuestId);
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }

                    // Add new guest
                    int newGuestId = _guestRepo.AddGuest(guest);
                    success = newGuestId > 0;

                    if (success)
                    {
                        guest.GuestId = newGuestId;
                        Helper.ShowSuccess("Guest added successfully!");
                    }
                    else
                    {
                        Helper.ShowError("Failed to add guest.");
                        return;
                    }
                }
                else
                {
                    // Update existing guest
                    if (_selectedGuest == null)
                    {
                        Helper.ShowError("No guest selected for update. Please select a guest to edit.");
                        return;
                    }
                    guest.GuestId = _selectedGuest.GuestId;
                    success = _guestRepo.UpdateGuest(guest);

                    if (success)
                    {
                        Helper.ShowSuccess("Guest updated successfully!");
                    }
                    else
                    {
                        Helper.ShowError("Failed to update guest.");
                        return;
                    }
                }

                if (success)
                {
                    LoadGuests();
                    ResetGuestForm();
                }
            }
            catch (Exception ex)
            {
                Helper.ShowError($"Error saving guest: {ex.Message}\n\n{ex.StackTrace}");
            }
        }

        private Guest CheckDuplicateGuest(string firstName, string lastName, string phone)
        {
            try
            {
                var guests = _guestRepo.SearchGuests($"{firstName} {lastName}");
                return guests.FirstOrDefault(g =>
                    g.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                    g.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase) &&
                    g.Phone == phone);
            }
            catch
            {
                return null;
            }
        }

        private bool ValidateGuestForm()
        {
            // Check for placeholder text
            if (txtFirstName.Text == "First Name" || string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                Helper.ShowError("First name is required");
                txtFirstName.Focus();
                return false;
            }

            if (txtLastName.Text == "Last Name" || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                Helper.ShowError("Last name is required");
                txtLastName.Focus();
                return false;
            }

            if (txtPhone.Text == "Phone Number" || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                Helper.ShowError("Phone number is required");
                txtPhone.Focus();
                return false;
            }

            string phoneDigits = new string(txtPhone.Text.Where(char.IsDigit).ToArray());
            if (phoneDigits.Length < 10)
            {
                Helper.ShowError("Phone number must be at least 10 digits");
                txtPhone.Focus();
                return false;
            }

            if (txtEmail.Text != "Email Address" && !string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                {
                    Helper.ShowError("Invalid email format");
                    txtEmail.Focus();
                    return false;
                }
            }

            // Age validation (must be at least 18)
            if (dtpDOB.Value > DateTime.Today.AddYears(-18))
            {
                Helper.ShowError("Guest must be at least 18 years old");
                dtpDOB.Focus();
                return false;
            }

            // Validate ID number if ID type is selected
            if (cmbIDType.SelectedIndex >= 0 && cmbIDType.Text != "Other")
            {
                if (txtIDNumber.Text == "ID Number" || string.IsNullOrWhiteSpace(txtIDNumber.Text))
                {
                    Helper.ShowError("ID Number is required for selected ID Type");
                    txtIDNumber.Focus();
                    return false;
                }
            }

            return true;
        }

        private void ResetGuestForm()
        {
            // Reset text boxes to placeholder text
            txtFirstName.Text = "First Name";
            txtLastName.Text = "Last Name";
            txtPhone.Text = "Phone Number";
            txtEmail.Text = "Email Address";
            txtAddress.Text = "Address";
            txtIDNumber.Text = "ID Number";

            // Reset colors to placeholder gray
            txtFirstName.ForeColor = SystemColors.GrayText;
            txtLastName.ForeColor = SystemColors.GrayText;
            txtPhone.ForeColor = SystemColors.GrayText;
            txtEmail.ForeColor = SystemColors.GrayText;
            txtAddress.ForeColor = SystemColors.GrayText;
            txtIDNumber.ForeColor = SystemColors.GrayText;

            // Reset combo boxes
            cmbNationality.SelectedIndex = 0;
            cmbIDType.SelectedIndex = 0;
            cmbGuestType.SelectedIndex = 0;

            // Reset date
            dtpDOB.Value = DateTime.Today.AddYears(-30);

            // Reset form state
            _selectedGuest = null;
            _isAddingNew = false;
            pnlGuestForm.Enabled = false;
            btnSaveGuest.Text = "Save Guest";
        }

        private void btnEditGuest_Click(object sender, EventArgs e)
        {
            if (_selectedGuest != null)
            {
                pnlGuestForm.Enabled = true;
                btnSaveGuest.Text = "Update Guest";
                txtFirstName.Focus();
            }
            else
            {
                Helper.ShowError("Please select a guest to edit");
            }
        }

        private void btnDeleteGuest_Click(object sender, EventArgs e)
        {
            if (_selectedGuest == null)
            {
                Helper.ShowError("Please select a guest to delete");
                return;
            }

            if (Helper.ConfirmAction($"Are you sure you want to delete {_selectedGuest.FullName}?")
                == DialogResult.Yes)
            {
                try
                {
                    // Check if guest has reservations
                    bool hasReservations = _guestRepo.GuestHasReservations(_selectedGuest.GuestId);

                    if (hasReservations)
                    {
                        Helper.ShowError("Cannot delete guest with existing reservations");
                        return;
                    }

                    // Delete guest
                    bool success = _guestRepo.DeleteGuest(_selectedGuest.GuestId);

                    if (success)
                    {
                        Helper.ShowSuccess("Guest deleted successfully!");
                        LoadGuests();
                        ResetGuestForm();
                    }
                    else
                    {
                        Helper.ShowError("Failed to delete guest.");
                    }
                }
                catch (Exception ex)
                {
                    Helper.ShowError($"Error deleting guest: {ex.Message}");
                }
            }
        }

        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            if (_selectedGuest != null)
            {
                try
                {
                    // You might want to create a separate method or repository for this
                    var history = _guestManager.GetGuestHistory(_selectedGuest.GuestId);

                    string historyText = $"Guest: {_selectedGuest.FullName}\n\n" +
                                       $"Total Reservations: {history.TotalReservations}\n" +
                                       $"Total Nights: {history.TotalNights}\n" +
                                       $"Total Spent: {Helper.FormatCurrency(history.TotalSpent)}\n" +
                                       $"Average Stay: {history.AverageStayLength:F1} nights";

                    MessageBox.Show(historyText, "Guest History",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Helper.ShowError($"Error loading guest history: {ex.Message}");
                }
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Enter key
            {
                btnSearch.PerformClick();
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search guests by name, email, or phone...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = SystemColors.ControlText;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search guests by name, email, or phone...";
                txtSearch.ForeColor = SystemColors.GrayText;
            }
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // Clear placeholder text when entering textbox
                string placeholder = textBox.Tag as string ?? "";
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = SystemColors.ControlText;
                }
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // Restore placeholder text if empty
                string placeholder = textBox.Tag as string ?? "";
                if (string.IsNullOrWhiteSpace(textBox.Text) && !string.IsNullOrEmpty(placeholder))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = SystemColors.GrayText;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetGuestForm();
        }
    }
}