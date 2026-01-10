using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel_ManagementIT13.Data.Managers;
using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;

namespace Hotel_ManagementIT13.Forms
{
    public partial class frmRateManagement : Form
    {
        private RateManager _rateManager;
        private RateRepository _rateRepo;
        private List<RateConfiguration> _rateConfigurations;
        private List<RoomType> _roomTypes;
        private List<RatePlan> _ratePlans;
        private bool _isEditing = false;
        private int _currentRateId = 0;

        public frmRateManagement()
        {
            InitializeComponent();
            _rateManager = new RateManager();
            _rateRepo = new RateRepository();
        }

        private string FormatPeso(decimal amount)
        {
            return "₱" + amount.ToString("N2");
        }

        private void frmRateManagement_Load(object sender, EventArgs e)
        {
            Console.WriteLine("DEBUG: Form loading...");
            InitializeForm();
            LoadAllData();
        }

        private void InitializeForm()
        {
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today.AddDays(30);
            ClearForm();
            btnEditRate.Enabled = false;
            btnDeleteRate.Enabled = false;

            dgvRates.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRates.MultiSelect = false;
            dgvRates.AllowUserToResizeRows = false;

            SetupDataGridViewColumns();
        }

        private void SetupDataGridViewColumns()
        {
            dgvRates.Columns.Clear();

            dgvRates.Columns.Add("RoomType", "Room Type");
            dgvRates.Columns.Add("RatePlan", "Rate Plan");
            dgvRates.Columns.Add("RateAmount", "Rate Amount");
            dgvRates.Columns.Add("StartDate", "Start Date");
            dgvRates.Columns.Add("EndDate", "End Date");
            dgvRates.Columns.Add("Status", "Status");
            dgvRates.Columns.Add("RateId", "Rate ID");

            dgvRates.Columns["RateId"].Visible = false;
            dgvRates.Columns["RateAmount"].DefaultCellStyle.Format = "N2"; // Changed from "C2" to "N2"
            dgvRates.Columns["StartDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            dgvRates.Columns["EndDate"].DefaultCellStyle.Format = "yyyy-MM-dd";

            // Set column widths
            dgvRates.Columns["RoomType"].Width = 200;
            dgvRates.Columns["RatePlan"].Width = 150;
            dgvRates.Columns["RateAmount"].Width = 120;
            dgvRates.Columns["StartDate"].Width = 100;
            dgvRates.Columns["EndDate"].Width = 100;
            dgvRates.Columns["Status"].Width = 80;
        }

        private void LoadAllData()
        {
            try
            {
                Console.WriteLine("DEBUG: Loading all data...");

                // Load room types
                Console.WriteLine("DEBUG: Loading room types...");
                _roomTypes = _rateManager.GetAvailableRoomTypes();
                cmbRoomType.Items.Clear();

                if (_roomTypes == null || _roomTypes.Count == 0)
                {
                    Console.WriteLine("WARNING: No room types found");
                    cmbRoomType.Items.Add("-- No Room Types --");
                }
                {
                    Console.WriteLine($"DEBUG: Found {_roomTypes.Count} room types");
                    cmbRoomType.Items.Add("-- Select Room Type --");
                    foreach (var roomType in _roomTypes)
                    {
                        cmbRoomType.Items.Add(roomType.TypeName);
                    }
                }
                cmbRoomType.SelectedIndex = 0;

                // Load rate plans
                Console.WriteLine("DEBUG: Loading rate plans...");
                _ratePlans = _rateManager.GetAvailableRatePlans();
                cmbRatePlan.Items.Clear();

                if (_ratePlans == null || _ratePlans.Count == 0)
                {
                    Console.WriteLine("WARNING: No rate plans found");
                    cmbRatePlan.Items.Add("-- No Rate Plans --");
                }
                else
                {
                    Console.WriteLine($"DEBUG: Found {_ratePlans.Count} rate plans");
                    cmbRatePlan.Items.Add("-- Select Rate Plan --");
                    foreach (var ratePlan in _ratePlans)
                    {
                        cmbRatePlan.Items.Add(ratePlan.PlanName);
                    }
                }
                cmbRatePlan.SelectedIndex = 0;

                // Load ALL rate configurations (not just active ones)
                Console.WriteLine("DEBUG: Loading ALL rate configurations...");
                LoadRateConfigurations();

                Console.WriteLine("DEBUG: Data loading completed");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR in LoadAllData: {ex.Message}");
                MessageBox.Show($"Error loading data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRateConfigurations()
        {
            try
            {
                // Get ALL rates from repository directly (not just active ones)
                _rateConfigurations = _rateRepo.GetRateConfigurations();
                dgvRates.Rows.Clear();

                Console.WriteLine($"DEBUG: Got {_rateConfigurations?.Count ?? 0} rate configurations");

                if (_rateConfigurations != null && _rateConfigurations.Count > 0)
                {
                    Console.WriteLine($"DEBUG: Loading {_rateConfigurations.Count} rate configurations into grid");

                    foreach (var rate in _rateConfigurations)
                    {
                        int rowIndex = dgvRates.Rows.Add();
                        dgvRates.Rows[rowIndex].Cells["RoomType"].Value = rate.RoomTypeName;
                        dgvRates.Rows[rowIndex].Cells["RatePlan"].Value = rate.PlanName;
                        dgvRates.Rows[rowIndex].Cells["RateAmount"].Value = FormatPeso(rate.RateAmount); // Use FormatPeso
                        dgvRates.Rows[rowIndex].Cells["StartDate"].Value = rate.StartDate;
                        dgvRates.Rows[rowIndex].Cells["EndDate"].Value = rate.EndDate;
                        dgvRates.Rows[rowIndex].Cells["RateId"].Value = rate.RateId;

                        // Determine status
                        string status = rate.IsActive() ? "Active" : "Inactive";
                        dgvRates.Rows[rowIndex].Cells["Status"].Value = status;

                        // Color code based on status
                        if (rate.IsActive())
                        {
                            dgvRates.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkGreen;
                            dgvRates.Rows[rowIndex].DefaultCellStyle.Font = new Font(dgvRates.Font, FontStyle.Bold);
                        }
                        else
                        {
                            dgvRates.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                            dgvRates.Rows[rowIndex].DefaultCellStyle.Font = new Font(dgvRates.Font, FontStyle.Italic);
                        }
                    }

                    Console.WriteLine($"DEBUG: Added {dgvRates.Rows.Count} rows to DataGridView");
                }
                else
                {
                    Console.WriteLine("DEBUG: No rate configurations found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR in LoadRateConfigurations: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                MessageBox.Show($"Error loading rates: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            if (cmbRoomType.Items.Count > 0)
                cmbRoomType.SelectedIndex = 0;
            if (cmbRatePlan.Items.Count > 0)
                cmbRatePlan.SelectedIndex = 0;
            txtRateAmount.Text = "";
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today.AddDays(30);

            _isEditing = false;
            _currentRateId = 0;
            btnSave.Text = "SAVE RATE";
            btnCancel.Visible = false;

            btnEditRate.Enabled = false;
            btnDeleteRate.Enabled = false;

            pnlRateForm.BackColor = SystemColors.ControlLight;
        }

        private void btnAddRate_Click(object sender, EventArgs e)
        {
            Console.WriteLine("DEBUG: Add Rate button clicked");
            ClearForm();
            _isEditing = false;
            btnSave.Text = "ADD RATE";
            btnCancel.Visible = true;
            pnlRateForm.BackColor = Color.LightBlue;
        }

        private void btnEditRate_Click(object sender, EventArgs e)
        {
            if (dgvRates.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a rate to edit.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                DataGridViewRow selectedRow = dgvRates.SelectedRows[0];
                _currentRateId = Convert.ToInt32(selectedRow.Cells["RateId"].Value);
                Console.WriteLine($"DEBUG: Editing rate ID: {_currentRateId}");

                var rate = _rateManager.GetRateConfigurationById(_currentRateId);
                if (rate == null)
                {
                    MessageBox.Show("Selected rate not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cmbRoomType.SelectedItem = rate.RoomTypeName;
                cmbRatePlan.SelectedItem = rate.PlanName;
                txtRateAmount.Text = rate.RateAmount.ToString("F2");
                dtpStartDate.Value = rate.StartDate;
                dtpEndDate.Value = rate.EndDate;

                _isEditing = true;
                btnSave.Text = "UPDATE RATE";
                btnCancel.Visible = true;
                pnlRateForm.BackColor = Color.LightGreen;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR in btnEditRate: {ex.Message}");
                MessageBox.Show($"Error loading rate for editing: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteRate_Click(object sender, EventArgs e)
        {
            if (dgvRates.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a rate to delete.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                DataGridViewRow selectedRow = dgvRates.SelectedRows[0];
                int rateId = Convert.ToInt32(selectedRow.Cells["RateId"].Value);
                string roomType = selectedRow.Cells["RoomType"].Value.ToString();
                string ratePlan = selectedRow.Cells["RatePlan"].Value.ToString();

                Console.WriteLine($"DEBUG: Deleting rate ID: {rateId}");

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete the rate for {roomType} - {ratePlan}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool success = _rateManager.DeleteRateConfiguration(rateId);

                    if (success)
                    {
                        MessageBox.Show("Rate deleted successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRateConfigurations();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete rate.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR in btnDeleteRate: {ex.Message}");
                MessageBox.Show($"Error deleting rate: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Console.WriteLine("DEBUG: Save button clicked - Starting validation");

            if (!ValidateRateForm())
            {
                Console.WriteLine("DEBUG: Form validation failed");
                return;
            }

            try
            {
                int roomTypeId = GetSelectedRoomTypeId();
                int ratePlanId = GetSelectedRatePlanId();

                Console.WriteLine($"DEBUG: Selected RoomTypeId: {roomTypeId}, RatePlanId: {ratePlanId}");

                if (roomTypeId == 0)
                {
                    Console.WriteLine("ERROR: Invalid room type ID");
                    MessageBox.Show("Please select a valid room type.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ratePlanId == 0)
                {
                    Console.WriteLine("ERROR: Invalid rate plan ID");
                    MessageBox.Show("Please select a valid rate plan.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Parse rate amount
                if (!decimal.TryParse(txtRateAmount.Text, out decimal rateAmount))
                {
                    MessageBox.Show("Please enter a valid rate amount.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRateAmount.Focus();
                    return;
                }

                var rateConfig = new RateConfiguration
                {
                    RateId = _currentRateId,
                    RoomTypeId = roomTypeId,
                    RatePlanId = ratePlanId,
                    RateAmount = rateAmount,
                    StartDate = dtpStartDate.Value.Date,
                    EndDate = dtpEndDate.Value.Date,
                    RoomTypeName = cmbRoomType.SelectedItem.ToString(),
                    PlanName = cmbRatePlan.SelectedItem.ToString()
                };

                Console.WriteLine($"DEBUG: Saving rate config - RoomTypeId: {rateConfig.RoomTypeId}, RatePlanId: {rateConfig.RatePlanId}, Amount: {rateConfig.RateAmount}");

                bool success;
                string message;

                if (_isEditing)
                {
                    Console.WriteLine("DEBUG: Updating existing rate configuration");
                    success = _rateManager.UpdateRateConfiguration(rateConfig);
                    message = success ? "Rate updated successfully AND base rate changed" : "Failed to update rate";
                }
                else
                {
                    Console.WriteLine("DEBUG: Adding new rate configuration");
                    var result = _rateManager.AddRateConfiguration(rateConfig);
                    success = result.Success;
                    message = result.Message;
                }

                if (success)
                {
                    MessageBox.Show(message, "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // RELOAD ROOM TYPES TO SHOW UPDATED BASE RATES
                    Console.WriteLine("DEBUG: Reloading room types to show updated base rates");
                    _roomTypes = _rateManager.GetAvailableRoomTypes();

                    LoadRateConfigurations();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show(message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR in btnSave: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                MessageBox.Show($"Error saving rate: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private bool ValidateRateForm()
        {
            if (cmbRoomType.SelectedIndex <= 0 || cmbRoomType.SelectedItem.ToString().Contains("--"))
            {
                MessageBox.Show("Please select a room type.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRoomType.Focus();
                return false;
            }

            if (cmbRatePlan.SelectedIndex <= 0 || cmbRatePlan.SelectedItem.ToString().Contains("--"))
            {
                MessageBox.Show("Please select a rate plan.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRatePlan.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRateAmount.Text) ||
                !decimal.TryParse(txtRateAmount.Text, out decimal amount) ||
                amount <= 0)
            {
                MessageBox.Show("Please enter a valid rate amount (greater than 0).", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRateAmount.Focus();
                txtRateAmount.SelectAll();
                return false;
            }

            if (dtpStartDate.Value >= dtpEndDate.Value)
            {
                MessageBox.Show("End date must be after start date.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpEndDate.Focus();
                return false;
            }

            return true;
        }

        private int GetSelectedRoomTypeId()
        {
            if (cmbRoomType.SelectedIndex > 0 && _roomTypes != null)
            {
                string selectedType = cmbRoomType.SelectedItem.ToString();
                var roomType = _roomTypes.FirstOrDefault(rt => rt.TypeName == selectedType);
                if (roomType != null)
                {
                    Console.WriteLine($"DEBUG: Found room type ID: {roomType.RoomTypeId} for '{selectedType}'");
                    return roomType.RoomTypeId;
                }
            }
            Console.WriteLine($"DEBUG: No room type ID found for selection");
            return 0;
        }

        private int GetSelectedRatePlanId()
        {
            if (cmbRatePlan.SelectedIndex > 0 && _ratePlans != null)
            {
                string selectedPlan = cmbRatePlan.SelectedItem.ToString();
                var ratePlan = _ratePlans.FirstOrDefault(rp => rp.PlanName == selectedPlan);
                if (ratePlan != null)
                {
                    Console.WriteLine($"DEBUG: Found rate plan ID: {ratePlan.RatePlanId} for '{selectedPlan}'");
                    return ratePlan.RatePlanId;
                }
            }
            Console.WriteLine($"DEBUG: No rate plan ID found for selection");
            return 0;
        }

        private void dgvRates_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dgvRates.SelectedRows.Count > 0;
            btnEditRate.Enabled = hasSelection;
            btnDeleteRate.Enabled = hasSelection;
        }

        private void txtRateAmount_Enter(object sender, EventArgs e)
        {
            if (txtRateAmount.Text == "Rate Amount")
            {
                txtRateAmount.Text = "";
                txtRateAmount.ForeColor = SystemColors.WindowText;
            }
        }

        private void txtRateAmount_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRateAmount.Text))
            {
                txtRateAmount.Text = "Rate Amount";
                txtRateAmount.ForeColor = SystemColors.GrayText;
            }
        }

        private void cmbRoomType_Enter(object sender, EventArgs e)
        {
            if (cmbRoomType.Text == "Room Type")
            {
                cmbRoomType.Text = "";
                cmbRoomType.ForeColor = SystemColors.WindowText;
            }
        }

        private void cmbRoomType_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbRoomType.Text))
            {
                cmbRoomType.Text = "Room Type";
                cmbRoomType.ForeColor = SystemColors.GrayText;
            }
        }

        private void cmbRatePlan_Enter(object sender, EventArgs e)
        {
            if (cmbRatePlan.Text == "Rate Plan")
            {
                cmbRatePlan.Text = "";
                cmbRatePlan.ForeColor = SystemColors.WindowText;
            }
        }

        private void cmbRatePlan_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbRatePlan.Text))
            {
                cmbRatePlan.Text = "Rate Plan";
                cmbRatePlan.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtPlanName_Enter(object sender, EventArgs e)
        {
            if (txtPlanName.Text == "Rate Plan Name")
            {
                txtPlanName.Text = "";
                txtPlanName.ForeColor = SystemColors.WindowText;
            }
        }

        private void txtPlanName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlanName.Text))
            {
                txtPlanName.Text = "Rate Plan Name";
                txtPlanName.ForeColor = SystemColors.GrayText;
            }
        }

        private void rtbPlanDescription_Enter(object sender, EventArgs e)
        {
            if (rtbPlanDescription.Text == "Rate Plan Description...")
            {
                rtbPlanDescription.Text = "";
                rtbPlanDescription.ForeColor = SystemColors.WindowText;
            }
        }

        private void rtbPlanDescription_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbPlanDescription.Text))
            {
                rtbPlanDescription.Text = "Rate Plan Description...";
                rtbPlanDescription.ForeColor = SystemColors.GrayText;
            }
        }
    }
}