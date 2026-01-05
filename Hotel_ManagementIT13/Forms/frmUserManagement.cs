using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;

namespace Hotel_ManagementIT13.Forms
{
    public partial class frmUserManagement : Form
    {
        private UserRepository _userRepository;
        private List<User> _users;
        private User _currentUser;
        private bool _isEditMode = false;
        private Label lblStatus;

        public frmUserManagement()
        {
            InitializeComponent();
            _userRepository = new UserRepository();
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            InitializeForm();
            LoadUsers();
            SetFormState(false);
        }

        private void InitializeForm()
        {
            // Initialize ComboBox with roles
            cmbRole.Items.Clear();
            cmbRole.Items.AddRange(new string[] { "Admin", "Manager", "FrontDesk" });
            cmbRole.SelectedIndex = 0;

            // Configure DataGridView columns
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;

            // Clear existing columns and add proper ones
            dgvUsers.Columns.Clear();

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UserId",
                HeaderText = "ID",
                DataPropertyName = "UserId",
                Width = 50
            });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Username",
                HeaderText = "Username",
                DataPropertyName = "Username",
                Width = 150
            });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FullName",
                HeaderText = "Full Name",
                DataPropertyName = "FullName",
                Width = 200
            });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 200
            });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Role",
                HeaderText = "Role",
                DataPropertyName = "Role",
                Width = 100
            });
            dgvUsers.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "IsActive",
                HeaderText = "Active",
                DataPropertyName = "IsActive",
                Width = 60
            });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreatedAt",
                HeaderText = "Created",
                DataPropertyName = "CreatedAt",
                Width = 100
            });

            // Add status label if not in designer
            lblStatus = new Label
            {
                Location = new Point(40, 720),
                Size = new Size(900, 30),
                Font = new Font("Microsoft Sans Serif", 10F),
                ForeColor = Color.DarkBlue
            };
            this.Controls.Add(lblStatus);

            // Wire up event handlers
            btnAddUser.Click += btnAddUser_Click;
            btnEditUser.Click += btnEditUser_Click;
            btnDeleteUser.Click += btnDeleteUser_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            btnResetPassword.Click += btnResetPassword_Click;
            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;

            // REMOVED PASSWORD HASHING: Set password field to show plain text when typing
            txtPassword.PasswordChar = '\0'; // This makes password visible when typing

            // Add Enter/Leave events for placeholder text effect
            SetupPlaceholderText();
        }

        private void SetupPlaceholderText()
        {
            // Set initial placeholder text
            SetPlaceholder(txtUsername, "Username");
            SetPlaceholder(txtPassword, "Password");
            SetPlaceholder(txtFirstName, "First Name");
            SetPlaceholder(txtLastName, "Last Name");
            SetPlaceholder(txtEmail, "Email Address");

            // Add event handlers for placeholder effect
            txtUsername.Enter += (s, e) => ClearPlaceholder(txtUsername, "Username");
            txtUsername.Leave += (s, e) => SetPlaceholder(txtUsername, "Username");

            txtPassword.Enter += (s, e) => ClearPlaceholder(txtPassword, "Password");
            txtPassword.Leave += (s, e) => SetPlaceholder(txtPassword, "Password");

            txtFirstName.Enter += (s, e) => ClearPlaceholder(txtFirstName, "First Name");
            txtFirstName.Leave += (s, e) => SetPlaceholder(txtFirstName, "First Name");

            txtLastName.Enter += (s, e) => ClearPlaceholder(txtLastName, "Last Name");
            txtLastName.Leave += (s, e) => SetPlaceholder(txtLastName, "Last Name");

            txtEmail.Enter += (s, e) => ClearPlaceholder(txtEmail, "Email Address");
            txtEmail.Leave += (s, e) => SetPlaceholder(txtEmail, "Email Address");
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
            }
        }

        private void ClearPlaceholder(TextBox textBox, string placeholder)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        private void LoadUsers()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _users = _userRepository.GetAllUsers();

                // Convert to display list
                var displayList = _users.Select(u => new
                {
                    u.UserId,
                    u.Username,
                    FullName = u.FullName,
                    u.Email,
                    Role = u.GetRole(),
                    u.IsActive,
                    CreatedAt = u.CreatedAt.ToString("yyyy-MM-dd")
                }).ToList();

                dgvUsers.DataSource = displayList;

                lblStatus.Text = $"Loaded {_users.Count} users";
                lblStatus.ForeColor = Color.DarkGreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Error: {ex.Message}";
                lblStatus.ForeColor = Color.Red;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void SetFormState(bool isEditing)
        {
            _isEditMode = isEditing;

            // Button states
            btnAddUser.Enabled = !isEditing;
            btnEditUser.Enabled = !isEditing && dgvUsers.SelectedRows.Count > 0;
            btnDeleteUser.Enabled = !isEditing && dgvUsers.SelectedRows.Count > 0;
            btnResetPassword.Enabled = !isEditing && dgvUsers.SelectedRows.Count > 0;
            btnSave.Enabled = isEditing;
            btnCancel.Enabled = isEditing;

            // Form fields
            txtUsername.Enabled = isEditing;
            txtPassword.Enabled = isEditing;
            txtFirstName.Enabled = isEditing;
            txtLastName.Enabled = isEditing;
            txtEmail.Enabled = isEditing;
            cmbRole.Enabled = isEditing;
            chkIsActive.Enabled = isEditing;

            // DataGridView
            dgvUsers.Enabled = !isEditing;

            // Update button text
            btnSave.Text = _isEditMode ? "UPDATE USER" : "SAVE USER";
            btnSave.Font = new Font(btnSave.Font, _isEditMode ? FontStyle.Regular : FontStyle.Bold);
        }

        private void ClearForm()
        {
            txtUsername.Text = "Username";
            txtUsername.ForeColor = Color.Gray;

            txtPassword.Text = "Password";
            txtPassword.ForeColor = Color.Gray;
            txtPassword.PasswordChar = '\0'; // Plain text

            txtFirstName.Text = "First Name";
            txtFirstName.ForeColor = Color.Gray;

            txtLastName.Text = "Last Name";
            txtLastName.ForeColor = Color.Gray;

            txtEmail.Text = "Email Address";
            txtEmail.ForeColor = Color.Gray;

            cmbRole.SelectedIndex = 0;
            chkIsActive.Checked = true;
            _currentUser = null;
        }

        private void LoadUserToForm(User user)
        {
            if (user == null) return;

            txtUsername.Text = user.Username;
            txtUsername.ForeColor = Color.Black;

            txtPassword.Text = ""; // Don't show password
            txtPassword.ForeColor = Color.Black;
            txtPassword.PasswordChar = '\0'; // Plain text

            txtFirstName.Text = user.FirstName;
            txtFirstName.ForeColor = Color.Black;

            txtLastName.Text = user.LastName;
            txtLastName.ForeColor = Color.Black;

            txtEmail.Text = user.Email;
            txtEmail.ForeColor = Color.Black;

            // Set role in combo box
            string role = user.GetRole();
            cmbRole.SelectedItem = role;

            chkIsActive.Checked = user.IsActive;
            _currentUser = user;
        }

        private User CreateUserFromForm()
        {
            string role = cmbRole.SelectedItem?.ToString();
            User user = null;

            switch (role)
            {
                case "Admin":
                    user = new Admin();
                    break;
                case "Manager":
                    user = new Manager();
                    break;
                case "FrontDesk":
                    user = new FrontDeskStaff();
                    break;
            }

            if (user != null)
            {
                if (_currentUser != null)
                    user.UserId = _currentUser.UserId;

                user.Username = GetTextBoxValue(txtUsername, "Username");
                user.Password = GetTextBoxValue(txtPassword, "Password"); // Stored as plain text
                user.FirstName = GetTextBoxValue(txtFirstName, "First Name");
                user.LastName = GetTextBoxValue(txtLastName, "Last Name");
                user.Email = GetTextBoxValue(txtEmail, "Email Address");
                user.IsActive = chkIsActive.Checked;
                user.CreatedAt = _currentUser?.CreatedAt ?? DateTime.Now;
            }

            return user;
        }

        private string GetTextBoxValue(TextBox textBox, string placeholder)
        {
            if (textBox.Text == placeholder && textBox.ForeColor == Color.Gray)
                return "";
            return textBox.Text.Trim();
        }

        private bool ValidateForm()
        {
            string username = GetTextBoxValue(txtUsername, "Username");
            string password = GetTextBoxValue(txtPassword, "Password");
            string firstName = GetTextBoxValue(txtFirstName, "First Name");
            string lastName = GetTextBoxValue(txtLastName, "Last Name");
            string email = GetTextBoxValue(txtEmail, "Email Address");

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                ClearPlaceholder(txtUsername, "Username");
                return false;
            }

            if (!_isEditMode && string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password is required for new users.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                ClearPlaceholder(txtPassword, "Password");
                return false;
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("First name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                ClearPlaceholder(txtFirstName, "First Name");
                return false;
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Last name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                ClearPlaceholder(txtLastName, "Last Name");
                return false;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                ClearPlaceholder(txtEmail, "Email Address");
                return false;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                ClearPlaceholder(txtEmail, "Email Address");
                return false;
            }

            // Check unique username (skip for current user when editing)
            bool usernameExists = _userRepository.UsernameExists(
                username,
                _currentUser?.UserId);

            if (usernameExists)
            {
                MessageBox.Show("Username already exists. Please choose a different username.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                ClearPlaceholder(txtUsername, "Username");
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // ===== EVENT HANDLERS =====

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            ClearForm();
            SetFormState(true);
            txtUsername.Focus();
            ClearPlaceholder(txtUsername, "Username");
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to edit.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserId"].Value);
            _currentUser = _userRepository.GetUserById(selectedId);

            if (_currentUser != null)
            {
                LoadUserToForm(_currentUser);
                SetFormState(true);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserId"].Value);
            var username = dgvUsers.SelectedRows[0].Cells["Username"].Value.ToString();

            var result = MessageBox.Show($"Are you sure you want to delete user '{username}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    bool success = _userRepository.DeleteUser(selectedId);
                    if (success)
                    {
                        MessageBox.Show("User deleted successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting user: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                Cursor = Cursors.WaitCursor;
                User user = CreateUserFromForm();
                if (user == null)
                {
                    MessageBox.Show("Invalid user role selected.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool success;
                string action;

                if (_isEditMode && _currentUser != null)
                {
                    // Update existing user
                    success = _userRepository.UpdateUser(user);
                    action = "updated";
                }
                else
                {
                    // Add new user
                    success = _userRepository.AddUser(user);
                    action = "added";
                }

                if (success)
                {
                    MessageBox.Show($"User {action} successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    SetFormState(false);
                    LoadUsers();
                }
                else
                {
                    MessageBox.Show($"Failed to save user.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving user: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            SetFormState(false);
            LoadUsers(); // Refresh to show any changes
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to reset password.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserId"].Value);
            var username = dgvUsers.SelectedRows[0].Cells["Username"].Value.ToString();

            using (var resetForm = new Form())
            {
                resetForm.Text = $"Reset Password - {username}";
                resetForm.Size = new Size(400, 200);
                resetForm.StartPosition = FormStartPosition.CenterParent;
                resetForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                resetForm.MaximizeBox = false;
                resetForm.MinimizeBox = false;

                var lblNewPassword = new Label
                {
                    Text = "New Password:",
                    Left = 20,
                    Top = 30,
                    Width = 120,
                    Font = new Font("Microsoft Sans Serif", 10F)
                };

                var txtNewPassword = new TextBox
                {
                    Left = 150,
                    Top = 27,
                    Width = 200,
                    Font = new Font("Microsoft Sans Serif", 10F),
                    PasswordChar = '\0' // Plain text for password reset
                };

                var btnConfirm = new Button
                {
                    Text = "Reset",
                    Left = 150,
                    Top = 70,
                    Width = 100,
                    Font = new Font("Microsoft Sans Serif", 10F)
                };

                var btnCancelReset = new Button
                {
                    Text = "Cancel",
                    Left = 260,
                    Top = 70,
                    Width = 100,
                    Font = new Font("Microsoft Sans Serif", 10F)
                };

                btnConfirm.Click += (s, ev) =>
                {
                    if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
                    {
                        MessageBox.Show("Please enter a new password.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        bool success = _userRepository.ResetPassword(selectedId, txtNewPassword.Text);
                        if (success)
                        {
                            MessageBox.Show("Password reset successfully.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            resetForm.DialogResult = DialogResult.OK;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error resetting password: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                };

                btnCancelReset.Click += (s, ev) => resetForm.DialogResult = DialogResult.Cancel;

                resetForm.Controls.AddRange(new Control[] { lblNewPassword, txtNewPassword, btnConfirm, btnCancelReset });

                if (resetForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUsers(); // Refresh list
                }
            }
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            // Update Edit/Delete/Reset buttons based on selection
            bool hasSelection = dgvUsers.SelectedRows.Count > 0;
            btnEditUser.Enabled = !_isEditMode && hasSelection;
            btnDeleteUser.Enabled = !_isEditMode && hasSelection;
            btnResetPassword.Enabled = !_isEditMode && hasSelection;

            // If not in edit mode, show selected user details in form (read-only)
            if (!_isEditMode && hasSelection)
            {
                var selectedId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserId"].Value);
                _currentUser = _userRepository.GetUserById(selectedId);
                if (_currentUser != null)
                {
                    LoadUserToForm(_currentUser);
                    // Make form fields read-only visually
                    txtUsername.BackColor = SystemColors.Control;
                    txtPassword.BackColor = SystemColors.Control;
                    txtFirstName.BackColor = SystemColors.Control;
                    txtLastName.BackColor = SystemColors.Control;
                    txtEmail.BackColor = SystemColors.Control;
                }
            }
            else if (!_isEditMode)
            {
                // Clear form when no selection
                ClearForm();
                txtUsername.BackColor = Color.White;
                txtPassword.BackColor = Color.White;
                txtFirstName.BackColor = Color.White;
                txtLastName.BackColor = Color.White;
                txtEmail.BackColor = Color.White;
            }
        }

        // Clean up event handlers when form closes
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Remove event handlers to prevent memory leaks
            btnAddUser.Click -= btnAddUser_Click;
            btnEditUser.Click -= btnEditUser_Click;
            btnDeleteUser.Click -= btnDeleteUser_Click;
            btnSave.Click -= btnSave_Click;
            btnCancel.Click -= btnCancel_Click;
            btnResetPassword.Click -= btnResetPassword_Click;
            dgvUsers.SelectionChanged -= dgvUsers_SelectionChanged;
        }
    }
}