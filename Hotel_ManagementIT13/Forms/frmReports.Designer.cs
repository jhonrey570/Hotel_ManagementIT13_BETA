namespace Hotel_ManagementIT13.Forms
{
    partial class frmReports
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
            this.tabReports = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chartReport = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtpReportFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpReportTo = new System.Windows.Forms.DateTimePicker();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.cmbRoomTypeFilter = new System.Windows.Forms.ComboBox();
            this.cmbGuestTypeFilter = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblData = new System.Windows.Forms.Label();
            this.lblRates = new System.Windows.Forms.Label();
            this.lblFilte = new System.Windows.Forms.Label();
            this.lblReportTypes = new System.Windows.Forms.Label();
            this.lblDatess = new System.Windows.Forms.Label();
            this.lblReports = new System.Windows.Forms.Label();
            this.pnlReportForms = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblReportForms = new System.Windows.Forms.Label();
            this.pnlHeaderUser = new System.Windows.Forms.Panel();
            this.lblMainDash = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.tabReports.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlReportForms.SuspendLayout();
            this.pnlHeaderUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabReports
            // 
            this.tabReports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabReports.Controls.Add(this.tabPage1);
            this.tabReports.Controls.Add(this.tabPage2);
            this.tabReports.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabReports.Location = new System.Drawing.Point(39, 442);
            this.tabReports.Name = "tabReports";
            this.tabReports.SelectedIndex = 0;
            this.tabReports.Size = new System.Drawing.Size(1240, 343);
            this.tabReports.TabIndex = 0;
            this.tabReports.SelectedIndexChanged += new System.EventHandler(this.tabReports_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chartReport);
            this.tabPage1.Location = new System.Drawing.Point(4, 37);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1232, 302);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Graphical Reports";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chartReport
            // 
            this.chartReport.BackColor = System.Drawing.Color.GhostWhite;
            this.chartReport.BorderlineColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.chartReport.ChartAreas.Add(chartArea1);
            this.chartReport.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartReport.Legends.Add(legend1);
            this.chartReport.Location = new System.Drawing.Point(3, 3);
            this.chartReport.Name = "chartReport";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartReport.Series.Add(series1);
            this.chartReport.Size = new System.Drawing.Size(1226, 296);
            this.chartReport.TabIndex = 8;
            this.chartReport.Text = "Report Chart";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.GhostWhite;
            this.tabPage2.Location = new System.Drawing.Point(4, 37);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1232, 302);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detailed Reports";
            // 
            // dtpReportFrom
            // 
            this.dtpReportFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpReportFrom.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReportFrom.Location = new System.Drawing.Point(39, 61);
            this.dtpReportFrom.Name = "dtpReportFrom";
            this.dtpReportFrom.Size = new System.Drawing.Size(422, 36);
            this.dtpReportFrom.TabIndex = 1;
            this.dtpReportFrom.ValueChanged += new System.EventHandler(this.dtpReportFrom_ValueChanged);
            // 
            // dtpReportTo
            // 
            this.dtpReportTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpReportTo.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReportTo.Location = new System.Drawing.Point(39, 131);
            this.dtpReportTo.Name = "dtpReportTo";
            this.dtpReportTo.Size = new System.Drawing.Size(422, 36);
            this.dtpReportTo.TabIndex = 2;
            this.dtpReportTo.ValueChanged += new System.EventHandler(this.dtpReportTo_ValueChanged);
            // 
            // cmbReportType
            // 
            this.cmbReportType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbReportType.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(39, 201);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(422, 36);
            this.cmbReportType.TabIndex = 3;
            this.cmbReportType.Text = "Select Report Type";
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.cmbReportType_SelectedIndexChanged);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerate.BackColor = System.Drawing.Color.Thistle;
            this.btnGenerate.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(39, 425);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(200, 50);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate Report";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(39, 34);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersWidth = 51;
            this.dgvReport.RowTemplate.Height = 30;
            this.dgvReport.Size = new System.Drawing.Size(1240, 374);
            this.dgvReport.TabIndex = 7;
            // 
            // cmbRoomTypeFilter
            // 
            this.cmbRoomTypeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRoomTypeFilter.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoomTypeFilter.FormattingEnabled = true;
            this.cmbRoomTypeFilter.Location = new System.Drawing.Point(39, 271);
            this.cmbRoomTypeFilter.Name = "cmbRoomTypeFilter";
            this.cmbRoomTypeFilter.Size = new System.Drawing.Size(422, 36);
            this.cmbRoomTypeFilter.TabIndex = 9;
            this.cmbRoomTypeFilter.Text = "Filter by Room Type";
            this.cmbRoomTypeFilter.SelectedIndexChanged += new System.EventHandler(this.cmbRoomTypeFilter_SelectedIndexChanged);
            // 
            // cmbGuestTypeFilter
            // 
            this.cmbGuestTypeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGuestTypeFilter.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGuestTypeFilter.FormattingEnabled = true;
            this.cmbGuestTypeFilter.Location = new System.Drawing.Point(39, 341);
            this.cmbGuestTypeFilter.Name = "cmbGuestTypeFilter";
            this.cmbGuestTypeFilter.Size = new System.Drawing.Size(422, 36);
            this.cmbGuestTypeFilter.TabIndex = 10;
            this.cmbGuestTypeFilter.Text = "Filter by Guest Type";
            this.cmbGuestTypeFilter.SelectedIndexChanged += new System.EventHandler(this.cmbGuestTypeFilter_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panel1.Controls.Add(this.lblData);
            this.panel1.Controls.Add(this.dgvReport);
            this.panel1.Controls.Add(this.lblRates);
            this.panel1.Controls.Add(this.tabReports);
            this.panel1.Location = new System.Drawing.Point(48, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1318, 814);
            this.panel1.TabIndex = 11;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(34, 3);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(56, 28);
            this.lblData.TabIndex = 47;
            this.lblData.Text = "Data";
            this.lblData.Click += new System.EventHandler(this.lblData_Click);
            // 
            // lblRates
            // 
            this.lblRates.AutoSize = true;
            this.lblRates.BackColor = System.Drawing.Color.Transparent;
            this.lblRates.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRates.Location = new System.Drawing.Point(34, 411);
            this.lblRates.Name = "lblRates";
            this.lblRates.Size = new System.Drawing.Size(63, 28);
            this.lblRates.TabIndex = 40;
            this.lblRates.Text = "Chart";
            // 
            // lblFilte
            // 
            this.lblFilte.AutoSize = true;
            this.lblFilte.BackColor = System.Drawing.Color.Transparent;
            this.lblFilte.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilte.Location = new System.Drawing.Point(34, 240);
            this.lblFilte.Name = "lblFilte";
            this.lblFilte.Size = new System.Drawing.Size(182, 28);
            this.lblFilte.TabIndex = 44;
            this.lblFilte.Text = "Filter Room Types:";
            // 
            // lblReportTypes
            // 
            this.lblReportTypes.AutoSize = true;
            this.lblReportTypes.BackColor = System.Drawing.Color.Transparent;
            this.lblReportTypes.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportTypes.Location = new System.Drawing.Point(34, 170);
            this.lblReportTypes.Name = "lblReportTypes";
            this.lblReportTypes.Size = new System.Drawing.Size(138, 28);
            this.lblReportTypes.TabIndex = 42;
            this.lblReportTypes.Text = "Report Types:";
            // 
            // lblDatess
            // 
            this.lblDatess.AutoSize = true;
            this.lblDatess.BackColor = System.Drawing.Color.Transparent;
            this.lblDatess.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatess.Location = new System.Drawing.Point(34, 30);
            this.lblDatess.Name = "lblDatess";
            this.lblDatess.Size = new System.Drawing.Size(116, 28);
            this.lblDatess.TabIndex = 41;
            this.lblDatess.Text = "Date From:";
            // 
            // lblReports
            // 
            this.lblReports.AutoSize = true;
            this.lblReports.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReports.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblReports.Location = new System.Drawing.Point(4, 59);
            this.lblReports.Name = "lblReports";
            this.lblReports.Size = new System.Drawing.Size(68, 20);
            this.lblReports.TabIndex = 34;
            this.lblReports.Text = "Reports";
            // 
            // pnlReportForms
            // 
            this.pnlReportForms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReportForms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pnlReportForms.Controls.Add(this.label1);
            this.pnlReportForms.Controls.Add(this.btnClearFilters);
            this.pnlReportForms.Controls.Add(this.lblDateTo);
            this.pnlReportForms.Controls.Add(this.cmbGuestTypeFilter);
            this.pnlReportForms.Controls.Add(this.lblReportForms);
            this.pnlReportForms.Controls.Add(this.cmbRoomTypeFilter);
            this.pnlReportForms.Controls.Add(this.lblFilte);
            this.pnlReportForms.Controls.Add(this.lblDatess);
            this.pnlReportForms.Controls.Add(this.dtpReportFrom);
            this.pnlReportForms.Controls.Add(this.lblReportTypes);
            this.pnlReportForms.Controls.Add(this.btnGenerate);
            this.pnlReportForms.Controls.Add(this.dtpReportTo);
            this.pnlReportForms.Controls.Add(this.cmbReportType);
            this.pnlReportForms.Location = new System.Drawing.Point(1372, 108);
            this.pnlReportForms.Name = "pnlReportForms";
            this.pnlReportForms.Size = new System.Drawing.Size(500, 509);
            this.pnlReportForms.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 28);
            this.label1.TabIndex = 53;
            this.label1.Text = "Filter Guest Types:";
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFilters.BackColor = System.Drawing.Color.Thistle;
            this.btnClearFilters.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClearFilters.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearFilters.Location = new System.Drawing.Point(261, 425);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(200, 50);
            this.btnClearFilters.TabIndex = 45;
            this.btnClearFilters.Text = "Clear Filters";
            this.btnClearFilters.UseVisualStyleBackColor = false;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.BackColor = System.Drawing.Color.Transparent;
            this.lblDateTo.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.Location = new System.Drawing.Point(34, 100);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(88, 28);
            this.lblDateTo.TabIndex = 52;
            this.lblDateTo.Text = "Date To:";
            // 
            // lblReportForms
            // 
            this.lblReportForms.AutoSize = true;
            this.lblReportForms.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportForms.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblReportForms.Location = new System.Drawing.Point(34, 3);
            this.lblReportForms.Name = "lblReportForms";
            this.lblReportForms.Size = new System.Drawing.Size(235, 27);
            this.lblReportForms.TabIndex = 42;
            this.lblReportForms.Text = "Report Control Forms";
            // 
            // pnlHeaderUser
            // 
            this.pnlHeaderUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeaderUser.BackColor = System.Drawing.Color.White;
            this.pnlHeaderUser.Controls.Add(this.lblMainDash);
            this.pnlHeaderUser.Controls.Add(this.pictureBox1);
            this.pnlHeaderUser.Controls.Add(this.btnPrint);
            this.pnlHeaderUser.Controls.Add(this.btnExport);
            this.pnlHeaderUser.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderUser.Name = "pnlHeaderUser";
            this.pnlHeaderUser.Size = new System.Drawing.Size(1920, 56);
            this.pnlHeaderUser.TabIndex = 50;
            // 
            // lblMainDash
            // 
            this.lblMainDash.AutoSize = true;
            this.lblMainDash.BackColor = System.Drawing.Color.Transparent;
            this.lblMainDash.Font = new System.Drawing.Font("Georgia", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainDash.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblMainDash.Location = new System.Drawing.Point(54, 9);
            this.lblMainDash.Name = "lblMainDash";
            this.lblMainDash.Size = new System.Drawing.Size(206, 38);
            this.lblMainDash.TabIndex = 31;
            this.lblMainDash.Text = "JMS HOTEL";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Hotel_ManagementIT13.Properties.Resources.logosaIT131;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackgroundImage = global::Hotel_ManagementIT13.Properties.Resources.clarity__printer_line;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(1874, 11);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(35, 35);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackgroundImage = global::Hotel_ManagementIT13.Properties.Resources.clarity__export_line;
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExport.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(1833, 11);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(35, 35);
            this.btnExport.TabIndex = 5;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(220)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1920, 960);
            this.Controls.Add(this.pnlHeaderUser);
            this.Controls.Add(this.pnlReportForms);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblReports);
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Management System - Reports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReports_Load_1);
            this.Resize += new System.EventHandler(this.frmReports_Resize);
            this.tabReports.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlReportForms.ResumeLayout(false);
            this.pnlReportForms.PerformLayout();
            this.pnlHeaderUser.ResumeLayout(false);
            this.pnlHeaderUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabReports;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DateTimePicker dtpReportFrom;
        private System.Windows.Forms.DateTimePicker dtpReportTo;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartReport;
        private System.Windows.Forms.ComboBox cmbRoomTypeFilter;
        private System.Windows.Forms.ComboBox cmbGuestTypeFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblReports;
        private System.Windows.Forms.Label lblRates;
        private System.Windows.Forms.Label lblReportTypes;
        private System.Windows.Forms.Label lblDatess;
        private System.Windows.Forms.Label lblFilte;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Panel pnlReportForms;
        private System.Windows.Forms.Panel pnlHeaderUser;
        private System.Windows.Forms.Label lblMainDash;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblReportForms;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label label1;
    }
}