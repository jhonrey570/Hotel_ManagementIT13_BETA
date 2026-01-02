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
            this.tabMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodaysArrivals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodaysDepartures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOccupancy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.mainMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mainMenu.Size = new System.Drawing.Size(1920, 36);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Location = new System.Drawing.Point(0, 938);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1920, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.Location = new System.Drawing.Point(1450, 160);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(440, 400);
            this.tabMain.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(432, 362);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Upcoming Events";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(432, 362);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Notifications";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Controls.Add(this.btnLogout);
            this.pnlHeader.Location = new System.Drawing.Point(0, 36);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1920, 80);
            this.pnlHeader.TabIndex = 3;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblWelcome.Location = new System.Drawing.Point(40, 22);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(145, 36);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1680, 15);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 50);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "LOGOUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // flpQuickActions
            // 
            this.flpQuickActions.BackColor = System.Drawing.Color.White;
            this.flpQuickActions.Location = new System.Drawing.Point(40, 140);
            this.flpQuickActions.Name = "flpQuickActions";
            this.flpQuickActions.Size = new System.Drawing.Size(1400, 100);
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
            this.dgvTodaysArrivals.GridColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.dgvTodaysArrivals.Location = new System.Drawing.Point(1450, 580);
            this.dgvTodaysArrivals.Name = "dgvTodaysArrivals";
            this.dgvTodaysArrivals.ReadOnly = true;
            this.dgvTodaysArrivals.RowHeadersVisible = false;
            this.dgvTodaysArrivals.RowHeadersWidth = 51;
            this.dgvTodaysArrivals.RowTemplate.Height = 30;
            this.dgvTodaysArrivals.Size = new System.Drawing.Size(440, 150);
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
            this.dgvTodaysDepartures.GridColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.dgvTodaysDepartures.Location = new System.Drawing.Point(1450, 750);
            this.dgvTodaysDepartures.Name = "dgvTodaysDepartures";
            this.dgvTodaysDepartures.ReadOnly = true;
            this.dgvTodaysDepartures.RowHeadersVisible = false;
            this.dgvTodaysDepartures.RowHeadersWidth = 51;
            this.dgvTodaysDepartures.RowTemplate.Height = 30;
            this.dgvTodaysDepartures.Size = new System.Drawing.Size(440, 150);
            this.dgvTodaysDepartures.TabIndex = 8;
            // 
            // lblAvailableRooms
            // 
            this.lblAvailableRooms.AutoSize = true;
            this.lblAvailableRooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableRooms.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblAvailableRooms.Location = new System.Drawing.Point(40, 260);
            this.lblAvailableRooms.Name = "lblAvailableRooms";
            this.lblAvailableRooms.Size = new System.Drawing.Size(192, 29);
            this.lblAvailableRooms.TabIndex = 9;
            this.lblAvailableRooms.Text = "Available Rooms";
            // 
            // lblOccupiedRooms
            // 
            this.lblOccupiedRooms.AutoSize = true;
            this.lblOccupiedRooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOccupiedRooms.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblOccupiedRooms.Location = new System.Drawing.Point(40, 330);
            this.lblOccupiedRooms.Name = "lblOccupiedRooms";
            this.lblOccupiedRooms.Size = new System.Drawing.Size(200, 29);
            this.lblOccupiedRooms.TabIndex = 10;
            this.lblOccupiedRooms.Text = "Occupied Rooms";
            // 
            // lblRevenueToday
            // 
            this.lblRevenueToday.AutoSize = true;
            this.lblRevenueToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueToday.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblRevenueToday.Location = new System.Drawing.Point(40, 400);
            this.lblRevenueToday.Name = "lblRevenueToday";
            this.lblRevenueToday.Size = new System.Drawing.Size(173, 29);
            this.lblRevenueToday.TabIndex = 11;
            this.lblRevenueToday.Text = "Revenue Today";
            // 
            // lblPendingReservations
            // 
            this.lblPendingReservations.AutoSize = true;
            this.lblPendingReservations.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingReservations.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblPendingReservations.Location = new System.Drawing.Point(40, 470);
            this.lblPendingReservations.Name = "lblPendingReservations";
            this.lblPendingReservations.Size = new System.Drawing.Size(237, 29);
            this.lblPendingReservations.TabIndex = 12;
            this.lblPendingReservations.Text = "Pending Reservations";
            // 
            // chartOccupancy
            // 
            this.chartOccupancy.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.Name = "ChartArea1";
            this.chartOccupancy.ChartAreas.Add(chartArea1);
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartOccupancy.Legends.Add(legend1);
            this.chartOccupancy.Location = new System.Drawing.Point(500, 260);
            this.chartOccupancy.Name = "chartOccupancy";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Room Status";
            this.chartOccupancy.Series.Add(series1);
            this.chartOccupancy.Size = new System.Drawing.Size(900, 300);
            this.chartOccupancy.TabIndex = 13;
            this.chartOccupancy.Text = "chart1";
            // 
            // chartRevenue
            // 
            this.chartRevenue.BackColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.Name = "ChartArea1";
            this.chartRevenue.ChartAreas.Add(chartArea2);
            legend2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            this.chartRevenue.Legends.Add(legend2);
            this.chartRevenue.Location = new System.Drawing.Point(500, 580);
            this.chartRevenue.Name = "chartRevenue";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsValueShownAsLabel = true;
            series2.LabelFormat = "C0";
            series2.Legend = "Legend1";
            series2.Name = "Revenue";
            this.chartRevenue.Series.Add(series2);
            this.chartRevenue.Size = new System.Drawing.Size(900, 320);
            this.chartRevenue.TabIndex = 14;
            this.chartRevenue.Text = "chart2";
            // 
            // lblOccupancyRate
            // 
            this.lblOccupancyRate.AutoSize = true;
            this.lblOccupancyRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOccupancyRate.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblOccupancyRate.Location = new System.Drawing.Point(40, 530);
            this.lblOccupancyRate.Name = "lblOccupancyRate";
            this.lblOccupancyRate.Size = new System.Drawing.Size(180, 69);
            this.lblOccupancyRate.TabIndex = 15;
            this.lblOccupancyRate.Text = "0.0%";
            // 
            // lblAvailableRoomsValue
            // 
            this.lblAvailableRoomsValue.AutoSize = true;
            this.lblAvailableRoomsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableRoomsValue.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblAvailableRoomsValue.Location = new System.Drawing.Point(300, 250);
            this.lblAvailableRoomsValue.Name = "lblAvailableRoomsValue";
            this.lblAvailableRoomsValue.Size = new System.Drawing.Size(45, 46);
            this.lblAvailableRoomsValue.TabIndex = 16;
            this.lblAvailableRoomsValue.Text = "0";
            // 
            // lblOccupiedRoomsValue
            // 
            this.lblOccupiedRoomsValue.AutoSize = true;
            this.lblOccupiedRoomsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOccupiedRoomsValue.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.lblOccupiedRoomsValue.Location = new System.Drawing.Point(300, 320);
            this.lblOccupiedRoomsValue.Name = "lblOccupiedRoomsValue";
            this.lblOccupiedRoomsValue.Size = new System.Drawing.Size(45, 46);
            this.lblOccupiedRoomsValue.TabIndex = 17;
            this.lblOccupiedRoomsValue.Text = "0";
            // 
            // lblRevenueValue
            // 
            this.lblRevenueValue.AutoSize = true;
            this.lblRevenueValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueValue.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblRevenueValue.Location = new System.Drawing.Point(300, 390);
            this.lblRevenueValue.Name = "lblRevenueValue";
            this.lblRevenueValue.Size = new System.Drawing.Size(45, 46);
            this.lblRevenueValue.TabIndex = 18;
            this.lblRevenueValue.Text = "0";
            // 
            // lblPendingValue
            // 
            this.lblPendingValue.AutoSize = true;
            this.lblPendingValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingValue.ForeColor = System.Drawing.Color.FromArgb(243, 156, 18);
            this.lblPendingValue.Location = new System.Drawing.Point(300, 460);
            this.lblPendingValue.Name = "lblPendingValue";
            this.lblPendingValue.Size = new System.Drawing.Size(45, 46);
            this.lblPendingValue.TabIndex = 19;
            this.lblPendingValue.Text = "0";
            // 
            // frmMainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.ClientSize = new System.Drawing.Size(1920, 960);
            this.Controls.Add(this.lblPendingValue);
            this.Controls.Add(this.lblRevenueValue);
            this.Controls.Add(this.lblOccupiedRoomsValue);
            this.Controls.Add(this.lblAvailableRoomsValue);
            this.Controls.Add(this.lblOccupancyRate);
            this.Controls.Add(this.chartRevenue);
            this.Controls.Add(this.chartOccupancy);
            this.Controls.Add(this.lblPendingReservations);
            this.Controls.Add(this.lblRevenueToday);
            this.Controls.Add(this.lblOccupiedRooms);
            this.Controls.Add(this.lblAvailableRooms);
            this.Controls.Add(this.dgvTodaysDepartures);
            this.Controls.Add(this.dgvTodaysArrivals);
            this.Controls.Add(this.flpQuickActions);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.tabMain);
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
    }
}