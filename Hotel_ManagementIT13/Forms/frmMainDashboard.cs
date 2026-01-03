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
        private ReportManager _reportManager;
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
            LoadDashboardData();
        }

        private void InitializeManagers()
        {
            _reservationManager = new ReservationManager();
            _roomRepo = new RoomRepository();
            _paymentRepo = new PaymentRepository();
            _roomManager = new RoomManager();
            _reportManager = new ReportManager();
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
            _dashboardTimer.Interval = 300000; // 5 minutes
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
            try
            {
                // Clear existing rows
                dgvTodaysArrivals.Rows.Clear();

                // For demo purposes - in real app, get actual arrivals from reservation manager
                // var arrivals = _reservationManager.GetArrivalsForDate(today);

                // Sample data for testing
                string[] sampleArrivals = new[]
                {
                    "John Smith,Room 101,Standard,Confirmed",
                    "Maria Garcia,Room 205,Deluxe,Confirmed",
                    "Robert Johnson,Room 312,Suite,Pending"
                };

                foreach (var arrival in sampleArrivals)
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
                Console.WriteLine($"Error loading arrivals: {ex.Message}");
            }
        }

        private void LoadTodaysDepartures(DateTime today)
        {
            try
            {
                // Clear existing rows
                dgvTodaysDepartures.Rows.Clear();

                // For demo purposes - in real app, get actual departures from reservation manager
                // var departures = _reservationManager.GetDeparturesForDate(today);

                // Sample data for testing
                string[] sampleDepartures = new[]
                {
                    "Sarah Wilson,Room 102,Standard,Paid",
                    "David Brown,Room 208,Deluxe,Paid",
                    "Lisa Miller,Room 310,Suite,Unpaid"
                };

                foreach (var departure in sampleDepartures)
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
                Console.WriteLine($"Error loading departures: {ex.Message}");
            }
        }

        private void LoadRoomStatistics()
        {
            try
            {
                // Use ReportManager for occupancy data
                DateTime today = DateTime.Today;
                var occupancyReport = _reportManager.GenerateOccupancyReport(today, today);

                if (occupancyReport.Success && occupancyReport.DailyOccupancy.Count > 0)
                {
                    int occupiedRooms = occupancyReport.DailyOccupancy[0].OccupiedRooms;
                    int reservedRooms = occupancyReport.DailyOccupancy[0].ReservedRooms;
                    int totalRooms = occupancyReport.TotalRooms;
                    int availableRooms = totalRooms - occupiedRooms - reservedRooms;

                    // Update labels
                    lblAvailableRoomsValue.Text = availableRooms.ToString();
                    lblOccupiedRoomsValue.Text = occupiedRooms.ToString();
                    lblPendingValue.Text = reservedRooms.ToString();

                    if (totalRooms > 0)
                    {
                        decimal occupancyRate = occupancyReport.DailyOccupancy[0].OccupancyRate;
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
                    // Fallback to original method
                    FallbackLoadRoomStatistics();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading room statistics from ReportManager: {ex.Message}");
                FallbackLoadRoomStatistics();
            }
        }

        private void FallbackLoadRoomStatistics()
        {
            try
            {
                // Original room statistics loading
                var rooms = _roomManager.GetAllRooms();

                if (rooms != null && rooms.Count > 0)
                {
                    int availableRooms = rooms.Count(r => r.StatusId == RoomManager.STATUS_AVAILABLE);
                    int occupiedRooms = rooms.Count(r => r.StatusId == RoomManager.STATUS_OCCUPIED);
                    int reservedRooms = rooms.Count(r => r.StatusId == RoomManager.STATUS_RESERVED);
                    int totalRooms = rooms.Count;

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
                Console.WriteLine($"Error in fallback room statistics: {ex.Message}");
                SetDefaultRoomStatistics();
            }
        }

        private void UpdateOccupancyRateColor(decimal occupancyRate)
        {
            if (occupancyRate > 80)
            {
                lblOccupancyRate.ForeColor = Color.FromArgb(192, 57, 43); // Red
            }
            else if (occupancyRate > 60)
            {
                lblOccupancyRate.ForeColor = Color.FromArgb(243, 156, 18); // Orange
            }
            else
            {
                lblOccupancyRate.ForeColor = Color.FromArgb(39, 174, 96); // Green
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

                // Debug: Check chart configuration
                DebugChartConfiguration();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating charts: {ex.Message}");
            }
        }

        private void UpdateOccupancyChart()
        {
            try
            {
                // Clear existing series
                chartOccupancy.Series.Clear();

                // Get data from ReportManager
                DateTime today = DateTime.Today;
                var occupancyReport = _reportManager.GenerateOccupancyReport(today, today);

                if (occupancyReport.Success && occupancyReport.DailyOccupancy.Count > 0)
                {
                    int occupied = occupancyReport.DailyOccupancy[0].OccupiedRooms;
                    int reserved = occupancyReport.DailyOccupancy[0].ReservedRooms;
                    int totalRooms = occupancyReport.TotalRooms;
                    int available = totalRooms - occupied - reserved;

                    // Ensure we have valid data
                    if (available < 0) available = 0;

                    // Create new series
                    var occupancySeries = new System.Windows.Forms.DataVisualization.Charting.Series("Room Status")
                    {
                        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie,
                        IsValueShownAsLabel = true,
                        Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                        ChartArea = "ChartArea1"
                    };

                    // Add data points
                    if (available + occupied + reserved > 0)
                    {
                        occupancySeries.Points.AddXY("Available", available);
                        occupancySeries.Points.AddXY("Occupied", occupied);
                        occupancySeries.Points.AddXY("Reserved", reserved);
                    }
                    else
                    {
                        // Add a single point if no data
                        occupancySeries.Points.AddXY("No Data", 1);
                    }

                    // Set colors
                    if (occupancySeries.Points.Count >= 3)
                    {
                        occupancySeries.Points[0].Color = Color.FromArgb(39, 174, 96);   // Green
                        occupancySeries.Points[1].Color = Color.FromArgb(192, 57, 43);   // Red
                        occupancySeries.Points[2].Color = Color.FromArgb(243, 156, 18);  // Orange
                    }
                    else if (occupancySeries.Points.Count == 1)
                    {
                        occupancySeries.Points[0].Color = Color.LightGray;
                    }

                    // Add series to chart
                    chartOccupancy.Series.Add(occupancySeries);

                    // Configure chart area
                    chartOccupancy.ChartAreas[0].Area3DStyle.Enable3D = true;
                    chartOccupancy.ChartAreas[0].Area3DStyle.Rotation = 10;
                    chartOccupancy.ChartAreas[0].Area3DStyle.Inclination = 15;
                    chartOccupancy.ChartAreas[0].Area3DStyle.IsRightAngleAxes = false;
                    chartOccupancy.ChartAreas[0].Area3DStyle.PointDepth = 100;
                    chartOccupancy.ChartAreas[0].Area3DStyle.PointGapDepth = 100;

                    // Configure legend
                    if (chartOccupancy.Legends.Count == 0)
                    {
                        chartOccupancy.Legends.Add(new System.Windows.Forms.DataVisualization.Charting.Legend());
                    }
                    chartOccupancy.Legends[0].Enabled = true;
                    chartOccupancy.Legends[0].Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                    chartOccupancy.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;

                    // Configure labels - show both count and percentage
                    int total = available + occupied + reserved;
                    if (total > 0)
                    {
                        foreach (var point in occupancySeries.Points)
                        {
                            double percentage = (point.YValues[0] / total) * 100;
                            point.Label = $"{point.YValues[0]} ({percentage:F1}%)";
                            point.LabelForeColor = Color.White;
                            point.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                        }
                    }

                    // Set chart title
                    chartOccupancy.Titles.Clear();
                    var title = new System.Windows.Forms.DataVisualization.Charting.Title($"Room Occupancy - {today:MMM dd, yyyy}")
                    {
                        Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold),
                        ForeColor = Color.FromArgb(44, 62, 80)
                    };
                    chartOccupancy.Titles.Add(title);

                    // Ensure chart is visible
                    chartOccupancy.Visible = true;
                }
                else
                {
                    // Fallback to original method
                    FallbackUpdateOccupancyChart();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating occupancy chart: {ex.Message}");

                // Show error on chart
                chartOccupancy.Titles.Clear();
                chartOccupancy.Titles.Add("Chart Error - Check Data");
                chartOccupancy.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                chartOccupancy.Titles[0].ForeColor = Color.Red;

                // Try fallback
                try
                {
                    FallbackUpdateOccupancyChart();
                }
                catch
                {
                    // Last resort - create empty chart with message
                    var emptySeries = new System.Windows.Forms.DataVisualization.Charting.Series("No Data")
                    {
                        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
                    };
                    emptySeries.Points.AddXY("No Data", 1);
                    emptySeries.Points[0].Color = Color.LightGray;
                    chartOccupancy.Series.Clear();
                    chartOccupancy.Series.Add(emptySeries);
                }
            }
        }

        private void FallbackUpdateOccupancyChart()
        {
            try
            {
                chartOccupancy.Series.Clear();

                int available, occupied, reserved;

                // Parse values safely
                if (!int.TryParse(lblAvailableRoomsValue.Text, out available))
                    available = 0;
                if (!int.TryParse(lblOccupiedRoomsValue.Text, out occupied))
                    occupied = 0;
                if (!int.TryParse(lblPendingValue.Text, out reserved))
                    reserved = 0;

                int total = available + occupied + reserved;

                var occupancySeries = new System.Windows.Forms.DataVisualization.Charting.Series("Room Status")
                {
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie,
                    IsValueShownAsLabel = true,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                    ChartArea = "ChartArea1"
                };

                // Add data
                if (total > 0)
                {
                    occupancySeries.Points.AddXY("Available", available);
                    occupancySeries.Points.AddXY("Occupied", occupied);
                    occupancySeries.Points.AddXY("Reserved", reserved);
                }
                else
                {
                    // Add a single point if no data
                    occupancySeries.Points.AddXY("No Data", 1);
                }

                // Set colors
                if (occupancySeries.Points.Count >= 3)
                {
                    occupancySeries.Points[0].Color = Color.FromArgb(39, 174, 96);
                    occupancySeries.Points[1].Color = Color.FromArgb(192, 57, 43);
                    occupancySeries.Points[2].Color = Color.FromArgb(243, 156, 18);
                }
                else if (occupancySeries.Points.Count == 1)
                {
                    occupancySeries.Points[0].Color = Color.LightGray;
                }

                chartOccupancy.Series.Add(occupancySeries);

                // Configure chart area
                chartOccupancy.ChartAreas[0].Area3DStyle.Enable3D = true;
                chartOccupancy.ChartAreas[0].Area3DStyle.Rotation = 10;
                chartOccupancy.ChartAreas[0].Area3DStyle.Inclination = 15;

                // Configure legend
                if (chartOccupancy.Legends.Count == 0)
                {
                    chartOccupancy.Legends.Add(new System.Windows.Forms.DataVisualization.Charting.Legend());
                }
                chartOccupancy.Legends[0].Enabled = true;
                chartOccupancy.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;

                // Set labels with percentages
                if (total > 0)
                {
                    foreach (var point in occupancySeries.Points)
                    {
                        double percentage = (point.YValues[0] / total) * 100;
                        point.Label = $"{point.YValues[0]} ({percentage:F1}%)";
                        point.LabelForeColor = Color.White;
                        point.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                    }
                }

                chartOccupancy.Titles.Clear();
                chartOccupancy.Titles.Add("Room Occupancy Status");
                chartOccupancy.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in fallback chart: {ex.Message}");

                // Minimal chart with error
                chartOccupancy.Series.Clear();
                chartOccupancy.Titles.Clear();
                chartOccupancy.Titles.Add("Chart Error - Check Data");
                chartOccupancy.Titles[0].ForeColor = Color.Red;
            }
        }

        private void DebugChartConfiguration()
        {
            // Debug method to check chart configuration
            try
            {
                Console.WriteLine($"Chart Occupancy - Series Count: {chartOccupancy.Series.Count}");
                Console.WriteLine($"Chart Occupancy - Chart Areas: {chartOccupancy.ChartAreas.Count}");
                Console.WriteLine($"Chart Occupancy - Visible: {chartOccupancy.Visible}");

                if (chartOccupancy.Series.Count > 0)
                {
                    Console.WriteLine($"First Series - Points: {chartOccupancy.Series[0].Points.Count}");
                    Console.WriteLine($"First Series - Chart Type: {chartOccupancy.Series[0].ChartType}");

                    if (chartOccupancy.Series[0].Points.Count > 0)
                    {
                        Console.WriteLine($"First Point - Value: {chartOccupancy.Series[0].Points[0].YValues[0]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Debug error: {ex.Message}");
            }
        }

        private void UpdateRevenueChart()
        {
            try
            {
                chartRevenue.Series.Clear();

                var revenueSeries = new System.Windows.Forms.DataVisualization.Charting.Series("Revenue")
                {
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
                    Color = Color.FromArgb(52, 152, 219),
                    IsValueShownAsLabel = true,
                    LabelFormat = "C0",
                    ChartArea = "ChartArea1"
                };

                // Get revenue for last 7 days
                for (int i = 6; i >= 0; i--)
                {
                    DateTime date = DateTime.Today.AddDays(-i);
                    string dayName = date.ToString("ddd");
                    decimal dayRevenue = _paymentRepo.GetTotalRevenue(date, date);
                    revenueSeries.Points.AddXY(dayName, dayRevenue);
                }

                chartRevenue.Series.Add(revenueSeries);

                // Configure chart
                chartRevenue.ChartAreas[0].AxisY.Title = "Amount ($)";
                chartRevenue.ChartAreas[0].AxisY.TitleFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                chartRevenue.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

                chartRevenue.Titles.Clear();
                chartRevenue.Titles.Add("Last 7 Days Revenue");
                chartRevenue.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
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