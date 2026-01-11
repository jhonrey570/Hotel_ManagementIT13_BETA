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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
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
            this.pnlRightSidebar = new System.Windows.Forms.Panel();
            this.pnlCharts = new System.Windows.Forms.Panel();
            this.pnlAvailableRoom = new System.Windows.Forms.Panel();
            this.lblMainDash = new System.Windows.Forms.Label();
            this.pnlOccupiedRoom = new System.Windows.Forms.Panel();
            this.pnlRevenue = new System.Windows.Forms.Panel();
            this.pnlReservations = new System.Windows.Forms.Panel();
            this.pnlOccupancyRt = new System.Windows.Forms.Panel();
            this.lblOcRate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnRefreshDashboard = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodaysArrivals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodaysDepartures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOccupancy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            this.pnlStats.SuspendLayout();
            this.pnlRightSidebar.SuspendLayout();
            this.pnlCharts.SuspendLayout();
            this.pnlAvailableRoom.SuspendLayout();
            this.pnlOccupiedRoom.SuspendLayout();
            this.pnlRevenue.SuspendLayout();
            this.pnlReservations.SuspendLayout();
            this.pnlOccupancyRt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.Color.Thistle;
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
            this.statusStrip.BackColor = System.Drawing.Color.Thistle;
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
            this.tabMain.Location = new System.Drawing.Point(10, 100);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(295, 400);
            this.tabMain.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(287, 366);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Upcoming Events";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(287, 366);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Notifications";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.btnLogout);
            this.pnlHeader.Controls.Add(this.btnRefreshDashboard);
            this.pnlHeader.Controls.Add(this.pictureBox1);
            this.pnlHeader.Controls.Add(this.lblMainDash);
            this.pnlHeader.Location = new System.Drawing.Point(0, 27);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1920, 56);
            this.pnlHeader.TabIndex = 3;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Georgia", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblWelcome.Location = new System.Drawing.Point(317, 85);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(205, 39);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "WELCOME!";
            // 
            // flpQuickActions
            // 
            this.flpQuickActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flpQuickActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.flpQuickActions.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpQuickActions.Location = new System.Drawing.Point(0, 83);
            this.flpQuickActions.Name = "flpQuickActions";
            this.flpQuickActions.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.flpQuickActions.Size = new System.Drawing.Size(315, 806);
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
            this.dgvTodaysArrivals.Size = new System.Drawing.Size(295, 90);
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
            this.dgvTodaysDepartures.Size = new System.Drawing.Size(295, 485);
            this.dgvTodaysDepartures.TabIndex = 8;
            // 
            // lblAvailableRooms
            // 
            this.lblAvailableRooms.AutoSize = true;
            this.lblAvailableRooms.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableRooms.ForeColor = System.Drawing.Color.Black;
            this.lblAvailableRooms.Location = new System.Drawing.Point(9, 94);
            this.lblAvailableRooms.Name = "lblAvailableRooms";
            this.lblAvailableRooms.Size = new System.Drawing.Size(125, 21);
            this.lblAvailableRooms.TabIndex = 9;
            this.lblAvailableRooms.Text = "Available Rooms";
            // 
            // lblOccupiedRooms
            // 
            this.lblOccupiedRooms.AutoSize = true;
            this.lblOccupiedRooms.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOccupiedRooms.ForeColor = System.Drawing.Color.Black;
            this.lblOccupiedRooms.Location = new System.Drawing.Point(9, 94);
            this.lblOccupiedRooms.Name = "lblOccupiedRooms";
            this.lblOccupiedRooms.Size = new System.Drawing.Size(126, 21);
            this.lblOccupiedRooms.TabIndex = 10;
            this.lblOccupiedRooms.Text = "Occupied Rooms";
            // 
            // lblRevenueToday
            // 
            this.lblRevenueToday.AutoSize = true;
            this.lblRevenueToday.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueToday.ForeColor = System.Drawing.Color.Black;
            this.lblRevenueToday.Location = new System.Drawing.Point(9, 94);
            this.lblRevenueToday.Name = "lblRevenueToday";
            this.lblRevenueToday.Size = new System.Drawing.Size(113, 21);
            this.lblRevenueToday.TabIndex = 11;
            this.lblRevenueToday.Text = "Revenue Today";
            this.lblRevenueToday.Click += new System.EventHandler(this.lblRevenueToday_Click);
            // 
            // lblPendingReservations
            // 
            this.lblPendingReservations.AutoSize = true;
            this.lblPendingReservations.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingReservations.ForeColor = System.Drawing.Color.Black;
            this.lblPendingReservations.Location = new System.Drawing.Point(9, 94);
            this.lblPendingReservations.Name = "lblPendingReservations";
            this.lblPendingReservations.Size = new System.Drawing.Size(158, 21);
            this.lblPendingReservations.TabIndex = 12;
            this.lblPendingReservations.Text = "Pending Reservations";
            // 
            // chartOccupancy
            // 
            this.chartOccupancy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartOccupancy.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chartOccupancy.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartOccupancy.Legends.Add(legend1);
            this.chartOccupancy.Location = new System.Drawing.Point(13, 13);
            this.chartOccupancy.Name = "chartOccupancy";
            this.chartOccupancy.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Room Status";
            this.chartOccupancy.Series.Add(series1);
            this.chartOccupancy.Size = new System.Drawing.Size(518, 508);
            this.chartOccupancy.TabIndex = 13;
            this.chartOccupancy.Text = "chart1";
            // 
            // chartRevenue
            // 
            this.chartRevenue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartRevenue.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chartRevenue.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartRevenue.Legends.Add(legend2);
            this.chartRevenue.Location = new System.Drawing.Point(13, 13);
            this.chartRevenue.Name = "chartRevenue";
            this.chartRevenue.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series2.ChartArea = "ChartArea1";
            series2.IsValueShownAsLabel = true;
            series2.LabelFormat = "C0";
            series2.Legend = "Legend1";
            series2.Name = "Revenue";
            this.chartRevenue.Series.Add(series2);
            this.chartRevenue.Size = new System.Drawing.Size(630, 508);
            this.chartRevenue.TabIndex = 14;
            this.chartRevenue.Text = "chart2";
            // 
            // lblOccupancyRate
            // 
            this.lblOccupancyRate.AutoSize = true;
            this.lblOccupancyRate.Font = new System.Drawing.Font("Calibri", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOccupancyRate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblOccupancyRate.Location = new System.Drawing.Point(3, 36);
            this.lblOccupancyRate.Name = "lblOccupancyRate";
            this.lblOccupancyRate.Size = new System.Drawing.Size(119, 58);
            this.lblOccupancyRate.TabIndex = 15;
            this.lblOccupancyRate.Text = "0.0%";
            // 
            // lblAvailableRoomsValue
            // 
            this.lblAvailableRoomsValue.AutoSize = true;
            this.lblAvailableRoomsValue.Font = new System.Drawing.Font("Calibri", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableRoomsValue.ForeColor = System.Drawing.Color.Black;
            this.lblAvailableRoomsValue.Location = new System.Drawing.Point(3, 36);
            this.lblAvailableRoomsValue.Name = "lblAvailableRoomsValue";
            this.lblAvailableRoomsValue.Size = new System.Drawing.Size(49, 58);
            this.lblAvailableRoomsValue.TabIndex = 16;
            this.lblAvailableRoomsValue.Text = "0";
            // 
            // lblOccupiedRoomsValue
            // 
            this.lblOccupiedRoomsValue.AutoSize = true;
            this.lblOccupiedRoomsValue.Font = new System.Drawing.Font("Calibri", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOccupiedRoomsValue.ForeColor = System.Drawing.Color.Black;
            this.lblOccupiedRoomsValue.Location = new System.Drawing.Point(3, 36);
            this.lblOccupiedRoomsValue.Name = "lblOccupiedRoomsValue";
            this.lblOccupiedRoomsValue.Size = new System.Drawing.Size(49, 58);
            this.lblOccupiedRoomsValue.TabIndex = 17;
            this.lblOccupiedRoomsValue.Text = "0";
            // 
            // lblRevenueValue
            // 
            this.lblRevenueValue.AutoSize = true;
            this.lblRevenueValue.Font = new System.Drawing.Font("Calibri", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueValue.ForeColor = System.Drawing.Color.Black;
            this.lblRevenueValue.Location = new System.Drawing.Point(3, 36);
            this.lblRevenueValue.Name = "lblRevenueValue";
            this.lblRevenueValue.Size = new System.Drawing.Size(49, 58);
            this.lblRevenueValue.TabIndex = 18;
            this.lblRevenueValue.Text = "0";
            // 
            // lblPendingValue
            // 
            this.lblPendingValue.AutoSize = true;
            this.lblPendingValue.Font = new System.Drawing.Font("Calibri", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingValue.ForeColor = System.Drawing.Color.Black;
            this.lblPendingValue.Location = new System.Drawing.Point(3, 36);
            this.lblPendingValue.Name = "lblPendingValue";
            this.lblPendingValue.Size = new System.Drawing.Size(49, 58);
            this.lblPendingValue.TabIndex = 19;
            this.lblPendingValue.Text = "0";
            // 
            // pnlStats
            // 
            this.pnlStats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pnlStats.Controls.Add(this.chartOccupancy);
            this.pnlStats.Controls.Add(this.pnlRightSidebar);
            this.pnlStats.Location = new System.Drawing.Point(1019, 355);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Padding = new System.Windows.Forms.Padding(10);
            this.pnlStats.Size = new System.Drawing.Size(865, 534);
            this.pnlStats.TabIndex = 20;
            // 
            // pnlRightSidebar
            // 
            this.pnlRightSidebar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRightSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pnlRightSidebar.Controls.Add(this.tabMain);
            this.pnlRightSidebar.Controls.Add(this.dgvTodaysArrivals);
            this.pnlRightSidebar.Controls.Add(this.dgvTodaysDepartures);
            this.pnlRightSidebar.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlRightSidebar.Location = new System.Drawing.Point(537, 13);
            this.pnlRightSidebar.Name = "pnlRightSidebar";
            this.pnlRightSidebar.Padding = new System.Windows.Forms.Padding(10);
            this.pnlRightSidebar.Size = new System.Drawing.Size(315, 505);
            this.pnlRightSidebar.TabIndex = 21;
            // 
            // pnlCharts
            // 
            this.pnlCharts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlCharts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pnlCharts.Controls.Add(this.chartRevenue);
            this.pnlCharts.Location = new System.Drawing.Point(357, 355);
            this.pnlCharts.Name = "pnlCharts";
            this.pnlCharts.Padding = new System.Windows.Forms.Padding(10);
            this.pnlCharts.Size = new System.Drawing.Size(656, 534);
            this.pnlCharts.TabIndex = 22;
            // 
            // pnlAvailableRoom
            // 
            this.pnlAvailableRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pnlAvailableRoom.Controls.Add(this.lblAvailableRooms);
            this.pnlAvailableRoom.Controls.Add(this.pictureBox2);
            this.pnlAvailableRoom.Controls.Add(this.lblAvailableRoomsValue);
            this.pnlAvailableRoom.Location = new System.Drawing.Point(357, 173);
            this.pnlAvailableRoom.Name = "pnlAvailableRoom";
            this.pnlAvailableRoom.Size = new System.Drawing.Size(325, 150);
            this.pnlAvailableRoom.TabIndex = 23;
            // 
            // lblMainDash
            // 
            this.lblMainDash.AutoSize = true;
            this.lblMainDash.BackColor = System.Drawing.Color.Transparent;
            this.lblMainDash.Font = new System.Drawing.Font("Georgia", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainDash.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblMainDash.Location = new System.Drawing.Point(54, 9);
            this.lblMainDash.Name = "lblMainDash";
            this.lblMainDash.Size = new System.Drawing.Size(211, 39);
            this.lblMainDash.TabIndex = 24;
            this.lblMainDash.Text = "JMS HOTEL";
            // 
            // pnlOccupiedRoom
            // 
            this.pnlOccupiedRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pnlOccupiedRoom.Controls.Add(this.pictureBox3);
            this.pnlOccupiedRoom.Controls.Add(this.lblOccupiedRoomsValue);
            this.pnlOccupiedRoom.Controls.Add(this.lblOccupiedRooms);
            this.pnlOccupiedRoom.Location = new System.Drawing.Point(688, 173);
            this.pnlOccupiedRoom.Name = "pnlOccupiedRoom";
            this.pnlOccupiedRoom.Size = new System.Drawing.Size(325, 150);
            this.pnlOccupiedRoom.TabIndex = 24;
            // 
            // pnlRevenue
            // 
            this.pnlRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pnlRevenue.Controls.Add(this.pictureBox4);
            this.pnlRevenue.Controls.Add(this.lblRevenueValue);
            this.pnlRevenue.Controls.Add(this.lblRevenueToday);
            this.pnlRevenue.Location = new System.Drawing.Point(1019, 173);
            this.pnlRevenue.Name = "pnlRevenue";
            this.pnlRevenue.Size = new System.Drawing.Size(325, 150);
            this.pnlRevenue.TabIndex = 25;
            // 
            // pnlReservations
            // 
            this.pnlReservations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pnlReservations.Controls.Add(this.pictureBox5);
            this.pnlReservations.Controls.Add(this.lblPendingValue);
            this.pnlReservations.Controls.Add(this.lblPendingReservations);
            this.pnlReservations.Location = new System.Drawing.Point(1350, 173);
            this.pnlReservations.Name = "pnlReservations";
            this.pnlReservations.Size = new System.Drawing.Size(325, 150);
            this.pnlReservations.TabIndex = 26;
            // 
            // pnlOccupancyRt
            // 
            this.pnlOccupancyRt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOccupancyRt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pnlOccupancyRt.Controls.Add(this.pictureBox6);
            this.pnlOccupancyRt.Controls.Add(this.lblOcRate);
            this.pnlOccupancyRt.Controls.Add(this.lblOccupancyRate);
            this.pnlOccupancyRt.Location = new System.Drawing.Point(1681, 173);
            this.pnlOccupancyRt.Name = "pnlOccupancyRt";
            this.pnlOccupancyRt.Size = new System.Drawing.Size(203, 150);
            this.pnlOccupancyRt.TabIndex = 27;
            // 
            // lblOcRate
            // 
            this.lblOcRate.AutoSize = true;
            this.lblOcRate.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOcRate.ForeColor = System.Drawing.Color.Black;
            this.lblOcRate.Location = new System.Drawing.Point(9, 94);
            this.lblOcRate.Name = "lblOcRate";
            this.lblOcRate.Size = new System.Drawing.Size(120, 21);
            this.lblOcRate.TabIndex = 20;
            this.lblOcRate.Text = "Occupancy Rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label1.Location = new System.Drawing.Point(320, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Main Dashboard";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pictureBox6.BackgroundImage = global::Hotel_ManagementIT13.Properties.Resources.material_symbols_light__percent1;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Location = new System.Drawing.Point(155, 8);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(40, 40);
            this.pictureBox6.TabIndex = 31;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pictureBox5.BackgroundImage = global::Hotel_ManagementIT13.Properties.Resources.clarity__warning_line;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(277, 8);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(40, 40);
            this.pictureBox5.TabIndex = 30;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pictureBox4.BackgroundImage = global::Hotel_ManagementIT13.Properties.Resources.clarity__dollar_bill_line;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(277, 8);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(40, 40);
            this.pictureBox4.TabIndex = 30;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pictureBox3.BackgroundImage = global::Hotel_ManagementIT13.Properties.Resources.clarity__house_solid;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(277, 8);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 40);
            this.pictureBox3.TabIndex = 30;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pictureBox2.BackgroundImage = global::Hotel_ManagementIT13.Properties.Resources.clarity__house_line;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(277, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.BackgroundImage = global::Hotel_ManagementIT13.Properties.Resources.clarity__sign_out_line;
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1872, 8);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.btnLogout.Size = new System.Drawing.Size(40, 40);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnRefreshDashboard
            // 
            this.btnRefreshDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshDashboard.BackgroundImage = global::Hotel_ManagementIT13.Properties.Resources.clarity__refresh_line;
            this.btnRefreshDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshDashboard.Location = new System.Drawing.Point(1826, 8);
            this.btnRefreshDashboard.Name = "btnRefreshDashboard";
            this.btnRefreshDashboard.Size = new System.Drawing.Size(40, 40);
            this.btnRefreshDashboard.TabIndex = 9;
            this.btnRefreshDashboard.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Hotel_ManagementIT13.Properties.Resources.logosaIT131;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // frmMainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(220)))), ((int)(((byte)(242)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 950);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlOccupancyRt);
            this.Controls.Add(this.pnlReservations);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.pnlRevenue);
            this.Controls.Add(this.pnlOccupiedRoom);
            this.Controls.Add(this.pnlAvailableRoom);
            this.Controls.Add(this.pnlCharts);
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
            this.pnlRightSidebar.ResumeLayout(false);
            this.pnlCharts.ResumeLayout(false);
            this.pnlAvailableRoom.ResumeLayout(false);
            this.pnlAvailableRoom.PerformLayout();
            this.pnlOccupiedRoom.ResumeLayout(false);
            this.pnlOccupiedRoom.PerformLayout();
            this.pnlRevenue.ResumeLayout(false);
            this.pnlRevenue.PerformLayout();
            this.pnlReservations.ResumeLayout(false);
            this.pnlReservations.PerformLayout();
            this.pnlOccupancyRt.ResumeLayout(false);
            this.pnlOccupancyRt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Button btnRefreshDashboard;
        private System.Windows.Forms.Panel pnlAvailableRoom;
        private System.Windows.Forms.Label lblMainDash;
        private System.Windows.Forms.Panel pnlOccupiedRoom;
        private System.Windows.Forms.Panel pnlRevenue;
        private System.Windows.Forms.Panel pnlReservations;
        private System.Windows.Forms.Panel pnlOccupancyRt;
        private System.Windows.Forms.Label lblOcRate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}