using Hotel_ManagementIT13.Data.Managers;
using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_ManagementIT13.Forms
{
    public partial class frmMainDashboard : Form
    {
        private ReservationManager _reservationManager;
        private RoomRepository _roomRepo;
        private PaymentRepository _paymentRepo;
        private RoomManager _roomManager;
        private Timer _dashboardTimer;

        public frmMainDashboard()
        {
            InitializeComponent();
            InitializeManagers();
            SetupMenu();
            SetupQuickActions();
            SetupEventHandlers();
            InitializeDashboard();
        }

        private void frmMainDashboard_Load(object sender, EventArgs e)
        {
            // Ensure data is loaded on form load
            LoadDashboardData();
        }

        private void InitializeManagers()
        {
            _reservationManager = new ReservationManager();
            _roomRepo = new RoomRepository();
            _paymentRepo = new PaymentRepository();
            _roomManager = new RoomManager();
        }

        private void SetupMenu()
        {
            var fileMenu = new ToolStripMenuItem("File");
            var reservationsMenu = new ToolStripMenuItem("Reservations");
            var operationsMenu = new ToolStripMenuItem("Operations");
            var managementMenu = new ToolStripMenuItem("Management");
            var reportsMenu = new ToolStripMenuItem("Reports");
            var adminMenu = new ToolStripMenuItem("Admin");
            var helpMenu = new ToolStripMenuItem("Help");

            fileMenu.DropDownItems.Add("Logout", null, menuItem_Click).Name = "menuLogout";
            fileMenu.DropDownItems.Add("Exit", null, menuItem_Click).Name = "menuExit";

            reservationsMenu.DropDownItems.Add("New Reservation", null, menuItem_Click).Name = "menuReservations";
            reservationsMenu.DropDownItems.Add("View Reservations", null, menuItem_Click).Name = "menuViewReservations";

            operationsMenu.DropDownItems.Add("Check-In", null, menuItem_Click).Name = "menuCheckIn";
            operationsMenu.DropDownItems.Add("Check-Out", null, menuItem_Click).Name = "menuCheckOut";

            managementMenu.DropDownItems.Add("Room Management", null, menuItem_Click).Name = "menuRooms";
            managementMenu.DropDownItems.Add("Guest Management", null, menuItem_Click).Name = "menuGuests";
            managementMenu.DropDownItems.Add("Billing", null, menuItem_Click).Name = "menuBilling";

            reportsMenu.DropDownItems.Add("Daily Report", null, menuItem_Click).Name = "menuDailyReport";
            reportsMenu.DropDownItems.Add("Monthly Report", null, menuItem_Click).Name = "menuMonthlyReport";
            reportsMenu.DropDownItems.Add("Financial Report", null, menuItem_Click).Name = "menuFinancialReport";

            adminMenu.DropDownItems.Add("User Management", null, menuItem_Click).Name = "menuUsers";
            adminMenu.DropDownItems.Add("System Settings", null, menuItem_Click).Name = "menuSettings";

            mainMenu.Items.AddRange(new ToolStripItem[] {
                fileMenu, reservationsMenu, operationsMenu,
                managementMenu, reportsMenu, adminMenu, helpMenu
            });
        }

        private void SetupQuickActions()
        {
            string[] actions = new[] { "NewReservation", "CheckIn", "CheckOut", "RoomManagement", "GuestManagement" };
            string[] texts = new[] { "New Reservation", "Check-In", "Check-Out", "Rooms", "Guests" };
            Color[] colors = new[] { Color.FromArgb(46, 204, 113), Color.FromArgb(52, 152, 219),
                                   Color.FromArgb(231, 76, 60), Color.FromArgb(155, 89, 182),
                                   Color.FromArgb(241, 196, 15) };

            for (int i = 0; i < actions.Length; i++)
            {
                Button btn = new Button
                {
                    Text = texts[i],
                    Tag = actions[i],
                    Size = new Size(180, 80),
                    BackColor = colors[i],
                    ForeColor = Color.White,
                    Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Margin = new Padding(15, 10, 15, 10),
                    Cursor = Cursors.Hand
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = ControlPaint.Dark(colors[i], 0.1f);
                btn.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(colors[i], 0.2f);

                btn.Click += quickActionButton_Click;
                flpQuickActions.Controls.Add(btn);
            }
        }

        private void SetupEventHandlers()
        {
            btnLogout.Click += btnLogout_Click;
            this.FormClosing += frmMainDashboard_FormClosing;
        }

        private void InitializeDashboard()
        {
            if (ApplicationContext.CurrentUser != null)
            {
                lblWelcome.Text = $"Welcome, {ApplicationContext.CurrentUser.FirstName} {ApplicationContext.CurrentUser.LastName}";
            }
            else
            {
                lblWelcome.Text = "Welcome, Guest";
            }

            LoadDashboardData();

            _dashboardTimer = new Timer();
            _dashboardTimer.Interval = 300000;
            _dashboardTimer.Tick += Timer_Tick;
            _dashboardTimer.Start();

            UpdateStatusStrip();
        }

        private void LoadDashboardData()
        {
            try
            {
                DateTime today = DateTime.Today;

                LoadTodaysArrivals(today);
                LoadTodaysDepartures(today);
                LoadRoomStatistics();
                LoadRevenueData(today);
                UpdateCharts();
                UpdateStatusStrip();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTodaysArrivals(DateTime today)
        {
            /*dgvTodaysArrivals.Rows.Clear();
            try
            {
                var arrivals = _reservationManager.GetTodaysArrivals(today);
                if (arrivals != null && arrivals.Any())
                {
                    foreach (var arrival in arrivals)
                    {
                        dgvTodaysArrivals.Rows.Add(
                            arrival.ReservationNumber,
                            arrival.GuestName,
                            arrival.RoomNumber,
                            arrival.RoomType,
                            arrival.Status
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading arrivals: {ex.Message}");
            }*/
        }

        private void LoadTodaysDepartures(DateTime today)
        {
            /*dgvTodaysDepartures.Rows.Clear();
            try
            {
                var departures = _reservationManager.GetTodaysDepartures(today);
                if (departures != null && departures.Any())
                {
                    foreach (var departure in departures)
                    {
                        dgvTodaysDepartures.Rows.Add(
                            departure.ReservationNumber,
                            departure.GuestName,
                            departure.RoomNumber,
                            departure.RoomType,
                            departure.CheckoutTime.ToString("hh:mm tt")
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading departures: {ex.Message}");
            }*/
        }

        private void LoadRoomStatistics()
        {
            try
            {
                // Get all rooms
                var rooms = _roomManager.GetAllRooms();

                if (rooms != null && rooms.Count > 0)
                {
                    // Count rooms by status
                    int availableRooms = rooms.Count(r => r.StatusId == RoomManager.STATUS_AVAILABLE);
                    int occupiedRooms = rooms.Count(r => r.StatusId == RoomManager.STATUS_OCCUPIED);
                    int reservedRooms = rooms.Count(r => r.StatusId == RoomManager.STATUS_RESERVED);
                    int totalRooms = rooms.Count;

                    // Update the VALUE labels (the large colored numbers)
                    lblAvailableRoomsValue.Text = availableRooms.ToString();
                    lblOccupiedRoomsValue.Text = occupiedRooms.ToString();
                    lblPendingValue.Text = reservedRooms.ToString();

                    if (totalRooms > 0)
                    {
                        decimal occupancyRate = (decimal)occupiedRooms / totalRooms * 100;
                        lblOccupancyRate.Text = $"{occupancyRate:F1}%";
                        UpdateOccupancyRateColor(occupancyRate);
                    }
                    else
                    {
                        lblOccupancyRate.Text = "0%";
                        lblOccupancyRate.ForeColor = Color.Gray;
                    }
                }
                else
                {
                    SetDefaultRoomStatistics();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading room statistics: {ex.Message}");
                SetDefaultRoomStatistics();
            }
        }

        private void UpdateOccupancyRateColor(decimal occupancyRate)
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

        private void SetDefaultRoomStatistics()
        {
            lblAvailableRoomsValue.Text = "0";
            lblOccupiedRoomsValue.Text = "0";
            lblPendingValue.Text = "0";
            lblRevenueValue.Text = "$0.00";
            lblOccupancyRate.Text = "0%";
            lblOccupancyRate.ForeColor = Color.Gray;
        }

        private void LoadRevenueData(DateTime today)
        {
            try
            {
                decimal todaysRevenue = _paymentRepo.GetTotalRevenue(today, today);
                lblRevenueValue.Text = $"${todaysRevenue:N2}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading revenue data: {ex.Message}");
                lblRevenueValue.Text = "$0.00";
            }
        }

        private void UpdateCharts()
        {
            try
            {
                UpdateOccupancyChart();
                UpdateRevenueChart();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating charts: {ex.Message}");
            }
        }

        private void UpdateOccupancyChart()
        {
            chartOccupancy.Series.Clear();

            try
            {
                // Parse values from the VALUE labels
                int available = int.Parse(lblAvailableRoomsValue.Text);
                int occupied = int.Parse(lblOccupiedRoomsValue.Text);
                int reserved = int.Parse(lblPendingValue.Text);

                var occupancySeries = new System.Windows.Forms.DataVisualization.Charting.Series("Room Status")
                {
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie,
                    IsValueShownAsLabel = true,
                    LabelFormat = "#,##0"
                };

                var availablePoint = occupancySeries.Points.Add(available);
                availablePoint.Color = Color.FromArgb(39, 174, 96);
                availablePoint.LegendText = "Available";

                var occupiedPoint = occupancySeries.Points.Add(occupied);
                occupiedPoint.Color = Color.FromArgb(192, 57, 43);
                occupiedPoint.LegendText = "Occupied";

                var reservedPoint = occupancySeries.Points.Add(reserved);
                reservedPoint.Color = Color.FromArgb(243, 156, 18);
                reservedPoint.LegendText = "Reserved";

                chartOccupancy.Series.Add(occupancySeries);
                chartOccupancy.Titles.Clear();
                chartOccupancy.Titles.Add("Room Occupancy Status");
                chartOccupancy.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            }
            catch
            {
                chartOccupancy.Titles.Clear();
                chartOccupancy.Titles.Add("No Data Available");
            }
        }

        private void UpdateRevenueChart()
        {
            chartRevenue.Series.Clear();

            try
            {
                var revenueSeries = new System.Windows.Forms.DataVisualization.Charting.Series("Revenue")
                {
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
                    Color = Color.FromArgb(52, 152, 219),
                    IsValueShownAsLabel = true,
                    LabelFormat = "C0"
                };

                for (int i = 6; i >= 0; i--)
                {
                    DateTime date = DateTime.Today.AddDays(-i);
                    string dayName = date.ToString("ddd");
                    decimal dayRevenue = _paymentRepo.GetTotalRevenue(date, date);
                    revenueSeries.Points.AddXY(dayName, dayRevenue);
                }

                chartRevenue.Series.Add(revenueSeries);
                chartRevenue.Titles.Clear();
                chartRevenue.Titles.Add("Last 7 Days Revenue");
                chartRevenue.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                chartRevenue.ChartAreas[0].AxisY.Title = "Amount ($)";
                chartRevenue.ChartAreas[0].AxisY.TitleFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in revenue chart: {ex.Message}");
                chartRevenue.Titles.Clear();
                chartRevenue.Titles.Add("Revenue Data Unavailable");
            }
        }

        private void UpdateStatusStrip()
        {
            statusStrip.Items.Clear();

            var timeLabel = new ToolStripStatusLabel($"Last Updated: {DateTime.Now:HH:mm:ss}");
            timeLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            statusStrip.Items.Add(timeLabel);

            statusStrip.Items.Add(new ToolStripStatusLabel(" | "));

            var userLabel = new ToolStripStatusLabel($"User: {ApplicationContext.CurrentUser?.Username ?? "Guest"}");
            userLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            statusStrip.Items.Add(userLabel);

            statusStrip.Items.Add(new ToolStripStatusLabel(" | "));

            var dateLabel = new ToolStripStatusLabel($"Date: {DateTime.Today:yyyy-MM-dd}");
            dateLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            statusStrip.Items.Add(dateLabel);

            statusStrip.Items.Add(new ToolStripStatusLabel());

            var hotelLabel = new ToolStripStatusLabel("Hotel Management System v1.0");
            hotelLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            hotelLabel.ForeColor = Color.FromArgb(52, 152, 219);
            statusStrip.Items.Add(hotelLabel);
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

            if (btn == null) return;

            Form formToOpen = null;
            string formName = btn.Tag?.ToString();

            switch (formName)
            {
                case "NewReservation":
                    formToOpen = new frmReservation();
                    break;
                case "CheckIn":
                    formToOpen = new frmCheckIn();
                    break;
                case "CheckOut":
                    formToOpen = new frmCheckOut();
                    break;
                case "RoomManagement":
                    formToOpen = new frmRoomManagement();
                    break;
                case "GuestManagement":
                    formToOpen = new frmGuestManagement();
                    break;
            }

            if (formToOpen != null)
            {
                formToOpen.Show();
                formToOpen.Focus();
            }
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            if (menuItem == null) return;

            Form formToOpen = null;
            bool shouldOpenForm = true;

            switch (menuItem.Name)
            {
                case "menuReservations":
                case "menuViewReservations":
                    formToOpen = new frmReservation();
                    break;
                case "menuCheckIn":
                    formToOpen = new frmCheckIn();
                    break;
                case "menuCheckOut":
                    formToOpen = new frmCheckOut();
                    break;
                case "menuRooms":
                    formToOpen = new frmRoomManagement();
                    break;
                case "menuGuests":
                    formToOpen = new frmGuestManagement();
                    break;
                case "menuBilling":
                    formToOpen = new frmBilling();
                    break;
                case "menuDailyReport":
                case "menuMonthlyReport":
                case "menuFinancialReport":
                    formToOpen = new frmReports();
                    break;
                case "menuUsers":
                    if (ApplicationContext.CurrentUser is Admin)
                    {
                        formToOpen = new frmUserManagement();
                    }
                    else
                    {
                        MessageBox.Show("Access denied. Admin privileges required.",
                                      "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        shouldOpenForm = false;
                    }
                    break;
                case "menuSettings":
                    MessageBox.Show("System Settings feature coming soon!",
                                  "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    shouldOpenForm = false;
                    break;
                case "menuLogout":
                    btnLogout_Click(sender, e);
                    shouldOpenForm = false;
                    break;
                case "menuExit":
                    Application.Exit();
                    shouldOpenForm = false;
                    break;
            }

            if (shouldOpenForm && formToOpen != null)
            {
                formToOpen.Show();
                formToOpen.Focus();
            }
        }

        private void frmMainDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_dashboardTimer != null)
            {
                _dashboardTimer.Stop();
                _dashboardTimer.Dispose();
            }
        }
    }
}