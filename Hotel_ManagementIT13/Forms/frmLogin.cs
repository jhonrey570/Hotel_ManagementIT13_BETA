using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
using System;
using System.Windows.Forms;

namespace Hotel_ManagementIT13.Forms
{
    public partial class frmLogin : Form
    {
        private UserRepository _userRepo;

        public frmLogin()
        {
            InitializeComponent();
            _userRepo = new UserRepository();
        }

      
        private void frmLogin_Load(object sender, EventArgs e)
        {
            
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password",
                              "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                User user = _userRepo.Authenticate(username, password);

                if (user != null)
                {

                    ApplicationContext.CurrentUser = user;

                    frmMainDashboard dashboard = new frmMainDashboard();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password",
                                  "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}",
                              "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnLogin.PerformClick();
            }
        }
    }

    
    public static class ApplicationContext
    {
        public static User CurrentUser { get; set; }
        public static DateTime CurrentDate => DateTime.Now;
    }
}