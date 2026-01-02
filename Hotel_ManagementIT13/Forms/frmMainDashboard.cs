using Hotel_ManagementIT13.Data.Managers;
using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_ManagementIT13.Forms
{
    public partial class frmMainDashboard : Form
    {
        private ReservationManager _reservationManager;
        private RoomRepository _roomRepo;

        public frmMainDashboard()
        {
            InitializeComponent();
            _reservationManager = new ReservationManager();
            _roomRepo = new RoomRepository();

            InitializeDashboard();
        }

        private void InitializeDashboard()
        {
            // Set welcome message
            lblWelcome.Text = $"Welcome, {ApplicationContext.CurrentUser.FirstName} {ApplicationContext.CurrentUser.LastName}";

            // Load dashboard data
            LoadDashboardData();

            // Set up timer for real-time updates
            Timer timer = new Timer();
            timer.Interval = 300000; // 5 minutes
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void LoadDashboardData()
        {
            try
            {
                DateTime today = DateTime.Today;

                // Load today's arrivals
                LoadTodaysArrivals(today);

                // Load today's departures
                LoadTodaysDepartures(today);

                // Load room statistics
                LoadRoomStatistics();

                // Load revenue data
                LoadRevenueData(today);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMainDashboard_Load(object sender, EventArgs e)
        {

        }
        private void LoadTodaysArrivals(DateTime today)
        {
            // Implementation to load today's arrivals
            dgvTodaysArrivals.Rows.Clear();

            // Sample data - replace with actual database call
            dgvTodaysArrivals.Rows.Add(
                "RES231201001", "John Doe", "101", "Standard", "Confirmed");
            dgvTodaysArrivals.Rows.Add(
                "RES231201002", "Jane Smith", "201", "Deluxe", "Confirmed");
        }

        private void LoadTodaysDepartures(DateTime today)
        {
            // Implementation to load today's departures
            dgvTodaysDepartures.Rows.Clear();

            // Sample data - replace with actual database call
            dgvTodaysDepartures.Rows.Add(
                "RES231125001", "Bob Johnson", "102", "Standard", "10:00 AM");
            dgvTodaysDepartures.Rows.Add(
                "RES231125002", "Alice Brown", "202", "Suite", "12:00 PM");
        }

        private void LoadRoomStatistics()
        {
            try
            {
                var rooms = _roomRepo.GetAllRooms();

                int totalRooms = rooms.Count;
                int availableRooms = rooms.Count(r => r.StatusId == 1);
                int occupiedRooms = rooms.Count(r => r.StatusId == 2);
                int reservedRooms = rooms.Count(r => r.StatusId == 3);

                lblAvailableRooms.Text = availableRooms.ToString();
                lblOccupiedRooms.Text = occupiedRooms.ToString();
                lblPendingReservations.Text = reservedRooms.ToString();

                // Calculate occupancy rate
                if (totalRooms > 0)
                {
                    decimal occupancyRate = (decimal)occupiedRooms / totalRooms * 100;
                    lblOccupancyRate.Text = $"{occupancyRate:F1}%";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading room statistics: {ex.Message}");
            }
        }

        private void LoadRevenueData(DateTime today)
        {
            // Implementation to load revenue data
            lblRevenueToday.Text = "$1,250.00"; // Sample data
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
                                                "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ApplicationContext.CurrentUser = null;

                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Close();
            }
        }

        private void quickActionButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn?.Tag?.ToString())
            {
                case "NewReservation":
                    OpenForm(new frmReservation());
                    break;
                case "CheckIn":
                    OpenForm(new frmCheckIn());
                    break;
                case "CheckOut":
                    OpenForm(new frmCheckOut());
                    break;
                case "RoomManagement":
                    OpenForm(new frmRoomManagement());
                    break;
                case "GuestManagement":
                    OpenForm(new frmGuestManagement());
                    break;
            }
        }

        private void OpenForm(Form form)
        {
            form.MdiParent = this;
            form.Show();
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            switch (menuItem?.Name)
            {
                case "menuReservations":
                    OpenForm(new frmReservation());
                    break;
                case "menuCheckIn":
                    OpenForm(new frmCheckIn());
                    break;
                case "menuCheckOut":
                    OpenForm(new frmCheckOut());
                    break;
                case "menuRooms":
                    OpenForm(new frmRoomManagement());
                    break;
                case "menuGuests":
                    OpenForm(new frmGuestManagement());
                    break;
                case "menuBilling":
                    OpenForm(new frmBilling());
                    break;
                case "menuReports":
                    OpenForm(new frmReports());
                    break;
                case "menuUsers":
                    if (ApplicationContext.CurrentUser is Admin)
                    {
                        OpenForm(new frmUserManagement());
                    }
                    else
                    {
                        MessageBox.Show("Access denied. Admin privileges required.",
                                      "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                case "menuLogout":
                    btnLogout_Click(sender, e);
                    break;
                case "menuExit":
                    Application.Exit();
                    break;
            }
        }
    }
}

    
