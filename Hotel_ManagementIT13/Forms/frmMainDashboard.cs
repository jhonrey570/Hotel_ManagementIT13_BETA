using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Forms.Services;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Hotel_ManagementIT13.Forms
{
    public partial class frmMainDashboard : Form
    {
        private Timer _dashboardTimer;
        private CultureInfo _phCulture;

        // Services
        private DashboardDataService _dataService;
        private ChartService _chartService;
        private RolePermissionService _roleService;
        private MenuService _menuService;
        private QuickActionService _quickActionService;
        private StatusStripService _statusStripService;

        public frmMainDashboard()
        {
            InitializeComponent();  // This must be called first!

            // Initialize services AFTER the form controls are created
            InitializeServices();
        }

        private void InitializeServices()
        {
            try
            {
                _phCulture = CultureInfo.CreateSpecificCulture("en-PH");
                _roleService = new RolePermissionService();
                _dataService = new DashboardDataService();
                _chartService = new ChartService();
                _menuService = new MenuService();
                _quickActionService = new QuickActionService(_roleService);
                _statusStripService = new StatusStripService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing services: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void frmMainDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                SetupUI();
                LoadDashboardData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard: {ex.Message}\n\nStackTrace: {ex.StackTrace}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupUI()
        {
            try
            {
                // Set welcome message
                if (ApplicationContext.CurrentUser != null)
                {
                    lblWelcome.Text = $"Welcome, {ApplicationContext.CurrentUser.FirstName} {ApplicationContext.CurrentUser.LastName}";
                }
                else
                {
                    lblWelcome.Text = "Welcome, Guest";
                }

                // Setup menu
                _menuService.SetupMainMenu(mainMenu, menuItem_Click);

                // Setup quick actions
                _quickActionService.SetupQuickActions(flpQuickActions, quickActionButton_Click);

                // Apply role-based restrictions
                _roleService.ApplyRoleBasedUIRestrictions(flpQuickActions.Controls, mainMenu);

                // Setup event handlers
                btnLogout.Click += btnLogout_Click;
                btnRefreshDashboard.Click += btnRefreshDashboard_Click;
                this.FormClosing += frmMainDashboard_FormClosing;

                // Initialize dashboard timer
                _dashboardTimer = new Timer();
                _dashboardTimer.Interval = 300000; // 5 minutes
                _dashboardTimer.Tick += Timer_Tick;
                _dashboardTimer.Start();

                // Update status strip
                _statusStripService.UpdateStatusStrip(statusStrip);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error setting up UI: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDashboardData()
        {
            try
            {
                var dashboardData = _dataService.LoadDashboardData();

                if (!string.IsNullOrEmpty(dashboardData.ErrorMessage))
                {
                    MessageBox.Show(dashboardData.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update UI with data
                UpdateTodaysArrivals(dashboardData.TodaysArrivals);
                UpdateTodaysDepartures(dashboardData.TodaysDepartures);
                UpdateRoomStatistics(dashboardData.RoomStatistics);
                UpdateRevenue(dashboardData.TodaysRevenue);
                UpdateCharts(dashboardData);
                _statusStripService.UpdateStatusStrip(statusStrip);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTodaysArrivals(string[] arrivals)
        {
            try
            {
                dgvTodaysArrivals.Rows.Clear();
                foreach (var arrival in arrivals)
                {
                    var parts = arrival.Split(',');
                    if (parts.Length >= 4)
                    {
                        dgvTodaysArrivals.Rows.Add(parts[0], parts[1], parts[2], parts[3]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating arrivals: {ex.Message}");
            }
        }

        private void UpdateTodaysDepartures(string[] departures)
        {
            try
            {
                dgvTodaysDepartures.Rows.Clear();
                foreach (var departure in departures)
                {
                    var parts = departure.Split(',');
                    if (parts.Length >= 4)
                    {
                        dgvTodaysDepartures.Rows.Add(parts[0], parts[1], parts[2], parts[3]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating departures: {ex.Message}");
            }
        }

        private void UpdateRoomStatistics(RoomStatistics stats)
        {
            try
            {
                lblAvailableRoomsValue.Text = stats.AvailableRooms.ToString();
                lblOccupiedRoomsValue.Text = stats.OccupiedRooms.ToString();
                lblPendingValue.Text = stats.ReservedRooms.ToString();

                if (stats.TotalRooms > 0)
                {
                    lblOccupancyRate.Text = $"{stats.OccupancyRate:F1}%";
                    UpdateOccupancyRateColor(stats.OccupancyRate);
                }
                else
                {
                    lblOccupancyRate.Text = "0%";
                    lblOccupancyRate.ForeColor = Color.Gray;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating room statistics: {ex.Message}");
            }
        }

        private void UpdateOccupancyRateColor(decimal occupancyRate)
        {
            try
            {
                if (occupancyRate > 80)
                {
                    lblOccupancyRate.ForeColor = Color.FromArgb(192, 57, 43);
                }
                else if (occupancyRate > 60)
                {
                    lblOccupancyRate.ForeColor = Color.FromArgb(243, 156, 18);
                }
                else
                {
                    lblOccupancyRate.ForeColor = Color.FromArgb(39, 174, 96);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating occupancy color: {ex.Message}");
            }
        }

        private void UpdateRevenue(decimal todaysRevenue)
        {
            try
            {
                lblRevenueValue.Text = todaysRevenue.ToString("₱#,##0.00", _phCulture);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating revenue: {ex.Message}");
            }
        }

        private void UpdateCharts(DashboardData data)
        {
            try
            {
                _chartService.UpdateOccupancyChart(chartOccupancy, data.OccupancyData, DateTime.Today);
                _chartService.UpdateRevenueChart(chartRevenue, data.RevenueChartData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating charts: {ex.Message}");
            }
        }

        // Event Handlers
        private void Timer_Tick(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error during logout: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDashboardData();
                MessageBox.Show("Dashboard refreshed successfully!", "Refresh",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing dashboard: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void quickActionButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is Button button)
                {
                    var form = _quickActionService.HandleQuickActionClick(button.Tag?.ToString());
                    if (form != null)
                    {
                        form.Show();
                        form.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error handling quick action: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is ToolStripMenuItem menuItem)
                {
                    if (menuItem.Name == "menuLogout")
                    {
                        btnLogout_Click(sender, e);
                        return;
                    }
                    else if (menuItem.Name == "menuExit")
                    {
                        Application.Exit();
                        return;
                    }

                    var form = _menuService.HandleMenuItemClick(menuItem.Name, _roleService);
                    if (form != null)
                    {
                        form.Show();
                        form.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error handling menu item: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMainDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_dashboardTimer != null)
                {
                    _dashboardTimer.Stop();
                    _dashboardTimer.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error disposing timer: {ex.Message}");
            }
        }

        // Designer-generated event handlers
        private void lblRevenueToday_Click(object sender, EventArgs e) { }
        private void mainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
    }
}