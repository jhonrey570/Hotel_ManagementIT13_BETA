namespace Hotel_ManagementIT13.Forms
{
    partial class frmMainDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.flpQuickActions = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvTodaysArrivals = new System.Windows.Forms.DataGridView();
            this.dgvTodaysDepartures = new System.Windows.Forms.DataGridView();
            this.lblAvailableRooms = new System.Windows.Forms.Label();
            this.lblOccupiedRooms = new System.Windows.Forms.Label();
            this.lblRevenueToday = new System.Windows.Forms.Label();
            this.lblPendingReservations = new System.Windows.Forms.Label();
            this.chartOccupancy = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblOccupancyRate = new System.Windows.Forms.Label();
            this.lblAvailableRoomsValue = new System.Windows.Forms.Label();
            this.lblOccupiedRoomsValue = new System.Windows.Forms.Label();
            this.lblRevenueValue = new System.Windows.Forms.Label();
            this.lblPendingValue = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblSts = new System.Windows.Forms.Label();
            this.pnlRightSidebar = new System.Windows.Forms.Panel();
            this.pnlCharts = new System.Windows.Forms.Panel();
            this.lblGrps = new System.Windows.Forms.Label();
            this.btnRefreshDashboard = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodaysArrivals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodaysDepartures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOccupancy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            this.pnlStats.SuspendLayout();
            this.pnlRightSidebar.SuspendLayout();
            this.pnlCharts.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.Color.Plum;
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1920, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            this.mainMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mainMenu_ItemClicked);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.Plum;
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Location = new System.Drawing.Point(0, 928);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1920, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabMain.Location = new System.Drawing.Point(10, 255);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(450, 400);
            this.tabMain.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(442, 371);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Upcoming Events";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(442, 371);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Notifications";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.btnRefreshDashboard);
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Controls.Add(this.btnLogout);
            this.pnlHeader.Location = new System.Drawing.Point(12, 27);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1896, 65);
            this.pnlHeader.TabIndex = 3;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Georgia", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblWelcome.Location = new System.Drawing.Point(9, 3);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(315, 54);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "WELCOME!";
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.BackgroundImage = global::Hotel_ManagementIT13.Properties.Resources.exit;
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1850, 17);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.btnLogout.Size = new System.Drawing.Size(30, 30);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // flpQuickActions
            // 
            this.flpQuickActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpQuickActions.BackColor = System.Drawing.Color.White;
            this.flpQuickActions.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpQuickActions.Location = new System.Drawing.Point(12, 98);
            this.flpQuickActions.Name = "flpQuickActions";
            this.flpQuickActions.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.flpQuickActions.Size = new System.Drawing.Size(1896, 110);
            this.flpQuickActions.TabIndex = 6;
            // 
            // dgvTodaysArrivals
            // 
            this.dgvTodaysArrivals.AllowUserToAddRows = false;
            this.dgvTodaysArrivals.AllowUserToDeleteRows = false;
            this.dgvTodaysArrivals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTodaysArrivals.BackgroundColor = System.Drawing.Color.White;
            this.dgvTodaysArrivals.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTodaysArrivals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTodaysArrivals.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTodaysArrivals.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.dgvTodaysArrivals.Location = new System.Drawing.Point(10, 10);
            this.dgvTodaysArrivals.Name = "dgvTodaysArrivals";
            this.dgvTodaysArrivals.ReadOnly = true;
            this.dgvTodaysArrivals.RowHeadersVisible = false;
            this.dgvTodaysArrivals.RowHeadersWidth = 51;
            this.dgvTodaysArrivals.RowTemplate.Height = 30;
            this.dgvTodaysArrivals.Size = new System.Drawing.Size(450, 245);
            this.dgvTodaysArrivals.TabIndex = 7;
            // 
            // dgvTodaysDepartures
            // 
            this.dgvTodaysDepartures.AllowUserToAddRows = false;
            this.dgvTodaysDepartures.AllowUserToDeleteRows = false;
            this.dgvTodaysDepartures.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTodaysDepartures.BackgroundColor = System.Drawing.Color.White;
            this.dgvTodaysDepartures.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTodaysDepartures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTodaysDepartures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTodaysDepartures.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.dgvTodaysDepartures.Location = new System.Drawing.Point(10, 10);
            this.dgvTodaysDepartures.Name = "dgvTodaysDepartures";
            this.dgvTodaysDepartures.ReadOnly = true;
            this.dgvTodaysDepartures.RowHeadersVisible = false;
            this.dgvTodaysDepartures.RowHeadersWidth = 51;
            this.dgvTodaysDepartures.RowTemplate.Height = 30;
            this.dgvTodaysDepartures.Size = new System.Drawing.Size(450, 691);
            this.dgvTodaysDepartures.TabIndex = 8;
            // 
            // lblAvailableRooms
            // 
            this.lblAvailableRooms.AutoSize = true;
            this.lblAvailableRooms.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableRooms.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAvailableRooms.Location = new System.Drawing.Point(13, 65);
            this.lblAvailableRooms.Name = "lblAvailableRooms";
            this.lblAvailableRooms.Size = new System.Drawing.Size(169, 28);
            this.lblAvailableRooms.TabIndex = 9;
            this.lblAvailableRooms.Text = "Available Rooms:";
            // 
            // lblOccupiedRooms
            // 
            this.lblOccupiedRooms.AutoSize = true;
            this.lblOccupiedRooms.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOccupiedRooms.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOccupiedRooms.Location = new System.Drawing.Point(13, 121);
            this.lblOccupiedRooms.Name = "lblOccupiedRooms";
            this.lblOccupiedRooms.Size = new System.Drawing.Size(173, 28);
            this.lblOccupiedRooms.TabIndex = 10;
            this.lblOccupiedRooms.Text = "Occupied Rooms:";
            // 
            // lblRevenueToday
            // 
            this.lblRevenueToday.AutoSize = true;
            this.lblRevenueToday.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueToday.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRevenueToday.Location = new System.Drawing.Point(13, 177);
            this.lblRevenueToday.Name = "lblRevenueToday";
            this.lblRevenueToday.Size = new System.Drawing.Size(156, 28);
            this.lblRevenueToday.TabIndex = 11;
            this.lblRevenueToday.Text = "Revenue Today:";
            this.lblRevenueToday.Click += new System.EventHandler(this.lblRevenueToday_Click);
            // 
            // lblPendingReservations
            // 
            this.lblPendingReservations.AutoSize = true;
            this.lblPendingReservations.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingReservations.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPendingReservations.Location = new System.Drawing.Point(13, 233);
            this.lblPendingReservations.Name = "lblPendingReservations";
            this.lblPendingReservations.Size = new System.Drawing.Size(216, 28);
            this.lblPendingReservations.TabIndex = 12;
            this.lblPendingReservations.Text = "Pending Reservations:";
            // 
            // chartOccupancy
            // 
            this.chartOccupancy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartOccupancy.BackColor = System.Drawing.Color.Transparent;
            chartArea5.Name = "ChartArea1";
            this.chartOccupancy.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartOccupancy.Legends.Add(legend5);
            this.chartOccupancy.Location = new System.Drawing.Point(13, 40);
            this.chartOccupancy.Name = "chartOccupancy";
            this.chartOccupancy.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series5.IsValueShownAsLabel = true;
            series5.Legend = "Legend1";
            series5.Name = "Room Status";
            this.chartOccupancy.Series.Add(series5);
            this.chartOccupancy.Size = new System.Drawing.Size(948, 321);
            this.chartOccupancy.TabIndex = 13;
            this.chartOccupancy.Text = "chart1";
            // 
            // chartRevenue
            // 
            this.chartRevenue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartRevenue.BackColor = System.Drawing.Color.Transparent;
            chartArea6.Name = "ChartArea1";
            this.chartRevenue.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartRevenue.Legends.Add(legend6);
            this.chartRevenue.Location = new System.Drawing.Point(13, 378);
            this.chartRevenue.Name = "chartRevenue";
            this.chartRevenue.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series6.ChartArea = "ChartArea1";
            series6.IsValueShownAsLabel = true;
            series6.LabelFormat = "C0";
            series6.Legend = "Legend1";
            series6.Name = "Revenue";
            this.chartRevenue.Series.Add(series6);
            this.chartRevenue.Size = new System.Drawing.Size(948, 320);
            this.chartRevenue.TabIndex = 14;
            this.chartRevenue.Text = "chart2";
            // 
            // lblOccupancyRate
            // 
            this.lblOccupancyRate.AutoSize = true;
            this.lblOccupancyRate.Font = new System.Drawing.Font("Calibri", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOccupancyRate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblOccupancyRate.Location = new System.Drawing.Point(13, 317);
            this.lblOccupancyRate.Name = "lblOccupancyRate";
            this.lblOccupancyRate.Size = new System.Drawing.Size(93, 45);
            this.lblOccupancyRate.TabIndex = 15;
            this.lblOccupancyRate.Text = "0.0%";
            // 
            // lblAvailableRoomsValue
            // 
            this.lblAvailableRoomsValue.AutoSize = true;
            this.lblAvailableRoomsValue.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableRoomsValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAvailableRoomsValue.Location = new System.Drawing.Point(300, 65);
            this.lblAvailableRoomsValue.Name = "lblAvailableRoomsValue";
            this.lblAvailableRoomsValue.Size = new System.Drawing.Size(24, 28);
            this.lblAvailableRoomsValue.TabIndex = 16;
            this.lblAvailableRoomsValue.Text = "0";
            // 
            // lblOccupiedRoomsValue
            // 
            this.lblOccupiedRoomsValue.AutoSize = true;
            this.lblOccupiedRoomsValue.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOccupiedRoomsValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOccupiedRoomsValue.Location = new System.Drawing.Point(300, 121);
            this.lblOccupiedRoomsValue.Name = "lblOccupiedRoomsValue";
            this.lblOccupiedRoomsValue.Size = new System.Drawing.Size(24, 28);
            this.lblOccupiedRoomsValue.TabIndex = 17;
            this.lblOccupiedRoomsValue.Text = "0";
            // 
            // lblRevenueValue
            // 
            this.lblRevenueValue.AutoSize = true;
            this.lblRevenueValue.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRevenueValue.Location = new System.Drawing.Point(300, 177);
            this.lblRevenueValue.Name = "lblRevenueValue";
            this.lblRevenueValue.Size = new System.Drawing.Size(24, 28);
            this.lblRevenueValue.TabIndex = 18;
            this.lblRevenueValue.Text = "0";
            // 
            // lblPendingValue
            // 
            this.lblPendingValue.AutoSize = true;
            this.lblPendingValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPendingValue.Location = new System.Drawing.Point(300, 232);
            this.lblPendingValue.Name = "lblPendingValue";
            this.lblPendingValue.Size = new System.Drawing.Size(26, 29);
            this.lblPendingValue.TabIndex = 19;
            this.lblPendingValue.Text = "0";
            // 
            // pnlStats
            // 
            this.pnlStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlStats.BackColor = System.Drawing.Color.White;
            this.pnlStats.Controls.Add(this.lblSts);
            this.pnlStats.Controls.Add(this.lblAvailableRooms);
            this.pnlStats.Controls.Add(this.lblPendingValue);
            this.pnlStats.Controls.Add(this.lblOccupiedRooms);
            this.pnlStats.Controls.Add(this.lblRevenueValue);
            this.pnlStats.Controls.Add(this.lblRevenueToday);
            this.pnlStats.Controls.Add(this.lblOccupiedRoomsValue);
            this.pnlStats.Controls.Add(this.lblPendingReservations);
            this.pnlStats.Controls.Add(this.lblOccupancyRate);
            this.pnlStats.Controls.Add(this.lblAvailableRoomsValue);
            this.pnlStats.Location = new System.Drawing.Point(12, 214);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Padding = new System.Windows.Forms.Padding(10);
            this.pnlStats.Size = new System.Drawing.Size(440, 382);
            this.pnlStats.TabIndex = 20;
            // 
            // lblSts
            // 
            this.lblSts.AutoSize = true;
            this.lblSts.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSts.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblSts.Location = new System.Drawing.Point(13, 10);
            this.lblSts.Name = "lblSts";
            this.lblSts.Size = new System.Drawing.Size(87, 27);
            this.lblSts.TabIndex = 15;
            this.lblSts.Text = "Status";
            // 
            // pnlRightSidebar
            // 
            this.pnlRightSidebar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRightSidebar.BackColor = System.Drawing.Color.White;
            this.pnlRightSidebar.Controls.Add(this.tabMain);
            this.pnlRightSidebar.Controls.Add(this.dgvTodaysArrivals);
            this.pnlRightSidebar.Controls.Add(this.dgvTodaysDepartures);
            this.pnlRightSidebar.Location = new System.Drawing.Point(1438, 214);
            this.pnlRightSidebar.Name = "pnlRightSidebar";
            this.pnlRightSidebar.Padding = new System.Windows.Forms.Padding(10);
            this.pnlRightSidebar.Size = new System.Drawing.Size(470, 711);
            this.pnlRightSidebar.TabIndex = 21;
            // 
            // pnlCharts
            // 
            this.pnlCharts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCharts.BackColor = System.Drawing.Color.White;
            this.pnlCharts.Controls.Add(this.lblGrps);
            this.pnlCharts.Controls.Add(this.chartOccupancy);
            this.pnlCharts.Controls.Add(this.chartRevenue);
            this.pnlCharts.Location = new System.Drawing.Point(458, 214);
            this.pnlCharts.Name = "pnlCharts";
            this.pnlCharts.Padding = new System.Windows.Forms.Padding(10);
            this.pnlCharts.Size = new System.Drawing.Size(974, 711);
            this.pnlCharts.TabIndex = 22;
            // 
            // lblGrps
            // 
            this.lblGrps.AutoSize = true;
            this.lblGrps.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrps.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblGrps.Location = new System.Drawing.Point(13, 10);
            this.lblGrps.Name = "lblGrps";
            this.lblGrps.Size = new System.Drawing.Size(100, 27);
            this.lblGrps.TabIndex = 20;
            this.lblGrps.Text = "Graphs";
            // 
            // btnRefreshDashboard
            // 
            this.btnRefreshDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshDashboard.BackgroundImage = global::Hotel_ManagementIT13.Properties.Resources.refresh_page_option;
            this.btnRefreshDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshDashboard.Location = new System.Drawing.Point(1814, 17);
            this.btnRefreshDashboard.Name = "btnRefreshDashboard";
            this.btnRefreshDashboard.Size = new System.Drawing.Size(30, 30);
            this.btnRefreshDashboard.TabIndex = 9;
            this.btnRefreshDashboard.UseVisualStyleBackColor = true;
            // 
            // frmMainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 950);
            this.Controls.Add(this.pnlCharts);
            this.Controls.Add(this.pnlRightSidebar);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.flpQuickActions);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "frmMainDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Management System - Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainDashboard_Load);
            this.tabMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodaysArrivals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodaysDepartures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOccupancy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            this.pnlRightSidebar.ResumeLayout(false);
            this.pnlCharts.ResumeLayout(false);
            this.pnlCharts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.FlowLayoutPanel flpQuickActions;
        private System.Windows.Forms.DataGridView dgvTodaysArrivals;
        private System.Windows.Forms.DataGridView dgvTodaysDepartures;
        private System.Windows.Forms.Label lblAvailableRooms;
        private System.Windows.Forms.Label lblOccupiedRooms;
        private System.Windows.Forms.Label lblRevenueToday;
        private System.Windows.Forms.Label lblPendingReservations;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOccupancy;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private System.Windows.Forms.Label lblOccupancyRate;
        private System.Windows.Forms.Label lblAvailableRoomsValue;
        private System.Windows.Forms.Label lblOccupiedRoomsValue;
        private System.Windows.Forms.Label lblRevenueValue;
        private System.Windows.Forms.Label lblPendingValue;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel pnlRightSidebar;
        private System.Windows.Forms.Panel pnlCharts;
        private System.Windows.Forms.Label lblSts;
        private System.Windows.Forms.Label lblGrps;
        private System.Windows.Forms.Button btnRefreshDashboard;
    }
}