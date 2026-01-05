using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_ManagementIT13.Forms
{
    public partial class frmSearch : Form
    {
        // Store references to open forms to prevent multiple instances
        private Dictionary<string, Form> openForms = new Dictionary<string, Form>();

        public frmSearch()
        {
            InitializeComponent();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            // Maximize the window for full screen
            this.WindowState = FormWindowState.Maximized;

            // Update status label
            toolStripStatusLabel.Text = "Ready - Main Menu";
        }

        // Generic method to open forms as separate windows (like frmMainDashboard)
        private void OpenFormWindow<T>() where T : Form, new()
        {
            string formTypeName = typeof(T).Name;

            // Check if form is already open
            if (openForms.ContainsKey(formTypeName))
            {
                Form existingForm = openForms[formTypeName];
                if (!existingForm.IsDisposed)
                {
                    existingForm.Focus(); // Bring to front if already open
                    return;
                }
                else
                {
                    openForms.Remove(formTypeName); // Clean up disposed form
                }
            }

            // Create and show new form
            T newForm = new T();
            newForm.FormClosed += (s, args) =>
            {
                // Remove from dictionary when form is closed
                if (openForms.ContainsKey(formTypeName))
                {
                    openForms.Remove(formTypeName);
                }
            };

            openForms.Add(formTypeName, newForm);
            newForm.Show();
            newForm.Focus();
        }

        // Method to open forms with specific constructors if needed
        private void OpenFormWindow(Form form)
        {
            string formTypeName = form.GetType().Name;

            // Check if form is already open
            if (openForms.ContainsKey(formTypeName))
            {
                Form existingForm = openForms[formTypeName];
                if (!existingForm.IsDisposed)
                {
                    existingForm.Focus(); // Bring to front if already open
                    return;
                }
                else
                {
                    openForms.Remove(formTypeName); // Clean up disposed form
                }
            }

            form.FormClosed += (s, args) =>
            {
                // Remove from dictionary when form is closed
                if (openForms.ContainsKey(formTypeName))
                {
                    openForms.Remove(formTypeName);
                }
            };

            openForms.Add(formTypeName, form);
            form.Show();
            form.Focus();
        }

        private void btnQuickSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if you need to pass any parameters to the form constructor
                // For now, assuming parameterless constructor
                OpenFormWindow<frmSearchContent>();
                toolStripStatusLabel.Text = "Search form opened";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Search form: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuickRateManagement_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFormWindow<frmRateManagement>();
                toolStripStatusLabel.Text = "Rate Management form opened";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Rate Management form: {ex.Message}\n\n" +
                    "Please make sure the frmRateManagement class exists.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuickUserManagement_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if user has admin privileges like in frmMainDashboard
                // You might need to add: using Hotel_ManagementIT13.Data.Models;
                // and check ApplicationContext.CurrentUser is Admin

                OpenFormWindow<frmUserManagement>();
                toolStripStatusLabel.Text = "User Management form opened";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening User Management form: {ex.Message}\n\n" +
                    "Please make sure the frmUserManagement class exists.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuickReports_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFormWindow<frmReports>();
                toolStripStatusLabel.Text = "Reports form opened";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Reports form: {ex.Message}\n\n" +
                    "Please make sure the frmReports class exists.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRoomCreation_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFormWindow<frmRoomManagement>();
                toolStripStatusLabel.Text = "Room Management form opened";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Room Management form: {ex.Message}\n\n" +
                    "Please make sure the frmRoomManagement class exists.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
                "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Close all open child forms first (like frmMainDashboard does)
                foreach (var form in openForms.Values)
                {
                    if (!form.IsDisposed)
                    {
                        form.Close();
                    }
                }

                Application.Exit();
            }
        }

        // You might want to add a FormClosing event handler like in frmMainDashboard
        private void frmSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Clean up any resources if needed
        }
    }

    // Keep the frmSearchContent class if you still need it
    public class frmSearchContent : Form
    {
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvResults;
        private Color placeholderColor = Color.Gray;
        private Color normalColor = Color.Black;
        private string placeholderText = "Search guests, rooms, reservations...";

        public frmSearchContent()
        {
            this.Text = "Search";
            this.Size = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            InitializeSearchComponents();
        }

        private void InitializeSearchComponents()
        {
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.dgvResults = new DataGridView();

            // Setup search textbox
            txtSearch.Location = new Point(30, 30);
            txtSearch.Size = new Size(600, 25);
            txtSearch.ForeColor = placeholderColor;
            txtSearch.Text = placeholderText;

            // Handle focus events for placeholder effect
            txtSearch.GotFocus += TxtSearch_GotFocus;
            txtSearch.LostFocus += TxtSearch_LostFocus;

            // Setup search button
            btnSearch.Location = new Point(650, 30);
            btnSearch.Size = new Size(150, 25);
            btnSearch.Text = "Search";
            btnSearch.BackColor = Color.FromArgb(41, 128, 185);
            btnSearch.ForeColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Click += BtnSearch_Click;

            // Setup results datagridview
            dgvResults.Location = new Point(30, 80);
            dgvResults.Size = new Size(1140, 540);
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.BackgroundColor = Color.White;
            dgvResults.RowHeadersWidth = 50;

            // Add columns (example columns for hotel management)
            dgvResults.Columns.Add("GuestName", "Guest Name");
            dgvResults.Columns.Add("RoomNumber", "Room No");
            dgvResults.Columns.Add("CheckIn", "Check-In Date");
            dgvResults.Columns.Add("CheckOut", "Check-Out Date");
            dgvResults.Columns.Add("Status", "Status");
            dgvResults.Columns.Add("Phone", "Phone Number");
            dgvResults.Columns.Add("Email", "Email Address");

            // Make grid look better
            dgvResults.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvResults.RowHeadersVisible = true;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.MultiSelect = false;
            dgvResults.ReadOnly = true;
            dgvResults.AllowUserToAddRows = false;

            // Add Enter key support for search
            txtSearch.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnSearch_Click(btnSearch, EventArgs.Empty);
                }
            };

            // Add controls to form
            this.Controls.Add(txtSearch);
            this.Controls.Add(btnSearch);
            this.Controls.Add(dgvResults);

            // Handle form resize
            this.Resize += (sender, e) =>
            {
                // Adjust controls based on form size
                int formWidth = this.ClientSize.Width;
                int formHeight = this.ClientSize.Height;

                // Adjust search textbox width
                int availableWidth = formWidth - 220; // Leave space for button and margins
                txtSearch.Width = Math.Min(600, availableWidth);
                btnSearch.Location = new Point(txtSearch.Right + 20, 30);

                // Adjust datagridview size
                dgvResults.Width = formWidth - 60;
                dgvResults.Height = formHeight - 120;
            };
        }

        private void TxtSearch_GotFocus(object sender, EventArgs e)
        {
            if (txtSearch.Text == placeholderText)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = normalColor;
            }
        }

        private void TxtSearch_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = placeholderText;
                txtSearch.ForeColor = placeholderColor;
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;

            // Clear placeholder if it's still there
            if (searchText == placeholderText)
            {
                searchText = "";
            }

            // Show message that this is a demo
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show($"Search functionality would look for: '{searchText}'\n\n" +
                    "This is a demo interface. Actual search implementation would connect to your database.",
                    "Search Demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter search criteria", "Search",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}