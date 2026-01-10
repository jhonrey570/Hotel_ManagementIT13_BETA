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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabReports = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chartReport = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtpReportFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpReportTo = new System.Windows.Forms.DateTimePicker();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cmbRoomTypeFilter = new System.Windows.Forms.ComboBox();
            this.cmbGuestTypeFilter = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblReports = new System.Windows.Forms.Label();
            this.lblRates = new System.Windows.Forms.Label();
            this.lblDatess = new System.Windows.Forms.Label();
            this.lblReportTypes = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.lblFilte = new System.Windows.Forms.Label();
            this.tabReports.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabReports
            // 
            this.tabReports.Controls.Add(this.tabPage1);
            this.tabReports.Controls.Add(this.tabPage2);
            this.tabReports.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabReports.Location = new System.Drawing.Point(3, 89);
            this.tabReports.Name = "tabReports";
            this.tabReports.SelectedIndex = 0;
            this.tabReports.Size = new System.Drawing.Size(1003, 369);
            this.tabReports.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chartReport);
            this.tabPage1.Location = new System.Drawing.Point(4, 37);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(995, 328);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Graphical Reports";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chartReport
            // 
            this.chartReport.BackColor = System.Drawing.Color.GhostWhite;
            this.chartReport.BorderlineColor = System.Drawing.SystemColors.Control;
            chartArea6.Name = "ChartArea1";
            this.chartReport.ChartAreas.Add(chartArea6);
            this.chartReport.Dock = System.Windows.Forms.DockStyle.Fill;
            legend6.Name = "Legend1";
            this.chartReport.Legends.Add(legend6);
            this.chartReport.Location = new System.Drawing.Point(3, 3);
            this.chartReport.Name = "chartReport";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartReport.Series.Add(series6);
            this.chartReport.Size = new System.Drawing.Size(989, 322);
            this.chartReport.TabIndex = 8;
            this.chartReport.Text = "Report Chart";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.GhostWhite;
            this.tabPage2.Location = new System.Drawing.Point(4, 37);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(937, 359);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detailed Reports";
            // 
            // dtpReportFrom
            // 
            this.dtpReportFrom.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReportFrom.Location = new System.Drawing.Point(3, 492);
            this.dtpReportFrom.Name = "dtpReportFrom";
            this.dtpReportFrom.Size = new System.Drawing.Size(400, 36);
            this.dtpReportFrom.TabIndex = 1;
            // 
            // dtpReportTo
            // 
            this.dtpReportTo.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReportTo.Location = new System.Drawing.Point(409, 492);
            this.dtpReportTo.Name = "dtpReportTo";
            this.dtpReportTo.Size = new System.Drawing.Size(400, 36);
            this.dtpReportTo.TabIndex = 2;
            // 
            // cmbReportType
            // 
            this.cmbReportType.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(3, 562);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(300, 36);
            this.cmbReportType.TabIndex = 3;
            this.cmbReportType.Text = "Select Report Type";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(3, 604);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(200, 50);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "GENERATE REPORT";
            this.btnGenerate.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(209, 604);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(200, 50);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "EXPORT TO EXCEL";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(415, 604);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(200, 50);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "PRINT REPORT";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(3, 758);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersWidth = 51;
            this.dgvReport.RowTemplate.Height = 30;
            this.dgvReport.Size = new System.Drawing.Size(1003, 175);
            this.dgvReport.TabIndex = 7;
            // 
            // reportViewer
            // 
            this.reportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer.BackColor = System.Drawing.Color.GhostWhite;
            this.reportViewer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportViewer.Location = new System.Drawing.Point(1012, 89);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(881, 844);
            this.reportViewer.TabIndex = 8;
            // 
            // cmbRoomTypeFilter
            // 
            this.cmbRoomTypeFilter.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoomTypeFilter.FormattingEnabled = true;
            this.cmbRoomTypeFilter.Location = new System.Drawing.Point(3, 688);
            this.cmbRoomTypeFilter.Name = "cmbRoomTypeFilter";
            this.cmbRoomTypeFilter.Size = new System.Drawing.Size(300, 36);
            this.cmbRoomTypeFilter.TabIndex = 9;
            this.cmbRoomTypeFilter.Text = "Filter by Room Type";
            // 
            // cmbGuestTypeFilter
            // 
            this.cmbGuestTypeFilter.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGuestTypeFilter.FormattingEnabled = true;
            this.cmbGuestTypeFilter.Location = new System.Drawing.Point(309, 688);
            this.cmbGuestTypeFilter.Name = "cmbGuestTypeFilter";
            this.cmbGuestTypeFilter.Size = new System.Drawing.Size(300, 36);
            this.cmbGuestTypeFilter.TabIndex = 10;
            this.cmbGuestTypeFilter.Text = "Filter by Guest Type";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblFilte);
            this.panel1.Controls.Add(this.cmbRoomTypeFilter);
            this.panel1.Controls.Add(this.cmbGuestTypeFilter);
            this.panel1.Controls.Add(this.lblData);
            this.panel1.Controls.Add(this.lblReportTypes);
            this.panel1.Controls.Add(this.dgvReport);
            this.panel1.Controls.Add(this.lblDatess);
            this.panel1.Controls.Add(this.lblRates);
            this.panel1.Controls.Add(this.lblReports);
            this.panel1.Controls.Add(this.cmbReportType);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.reportViewer);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.tabReports);
            this.panel1.Controls.Add(this.btnGenerate);
            this.panel1.Controls.Add(this.dtpReportFrom);
            this.panel1.Controls.Add(this.dtpReportTo);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1896, 936);
            this.panel1.TabIndex = 11;
            // 
            // lblReports
            // 
            this.lblReports.AutoSize = true;
            this.lblReports.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReports.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblReports.Location = new System.Drawing.Point(3, 3);
            this.lblReports.Name = "lblReports";
            this.lblReports.Size = new System.Drawing.Size(106, 27);
            this.lblReports.TabIndex = 34;
            this.lblReports.Text = "Reports";
            // 
            // lblRates
            // 
            this.lblRates.AutoSize = true;
            this.lblRates.BackColor = System.Drawing.Color.White;
            this.lblRates.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRates.Location = new System.Drawing.Point(3, 58);
            this.lblRates.Name = "lblRates";
            this.lblRates.Size = new System.Drawing.Size(63, 28);
            this.lblRates.TabIndex = 40;
            this.lblRates.Text = "Chart";
            // 
            // lblDatess
            // 
            this.lblDatess.AutoSize = true;
            this.lblDatess.BackColor = System.Drawing.Color.White;
            this.lblDatess.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatess.Location = new System.Drawing.Point(3, 461);
            this.lblDatess.Name = "lblDatess";
            this.lblDatess.Size = new System.Drawing.Size(71, 28);
            this.lblDatess.TabIndex = 41;
            this.lblDatess.Text = "Dates:";
            // 
            // lblReportTypes
            // 
            this.lblReportTypes.AutoSize = true;
            this.lblReportTypes.BackColor = System.Drawing.Color.White;
            this.lblReportTypes.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportTypes.Location = new System.Drawing.Point(3, 531);
            this.lblReportTypes.Name = "lblReportTypes";
            this.lblReportTypes.Size = new System.Drawing.Size(138, 28);
            this.lblReportTypes.TabIndex = 42;
            this.lblReportTypes.Text = "Report Types:";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.BackColor = System.Drawing.Color.White;
            this.lblData.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(3, 727);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(84, 28);
            this.lblData.TabIndex = 43;
            this.lblData.Text = "Reports";
            // 
            // lblFilte
            // 
            this.lblFilte.AutoSize = true;
            this.lblFilte.BackColor = System.Drawing.Color.White;
            this.lblFilte.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilte.Location = new System.Drawing.Point(3, 657);
            this.lblFilte.Name = "lblFilte";
            this.lblFilte.Size = new System.Drawing.Size(75, 28);
            this.lblFilte.TabIndex = 44;
            this.lblFilte.Text = "Filters:";
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1920, 960);
            this.Controls.Add(this.panel1);
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Management System - Reports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReports_Load_1);
            this.tabReports.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

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
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.ComboBox cmbRoomTypeFilter;
        private System.Windows.Forms.ComboBox cmbGuestTypeFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblReports;
        private System.Windows.Forms.Label lblRates;
        private System.Windows.Forms.Label lblReportTypes;
        private System.Windows.Forms.Label lblDatess;
        private System.Windows.Forms.Label lblFilte;
        private System.Windows.Forms.Label lblData;
    }
}