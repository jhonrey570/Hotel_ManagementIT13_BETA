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
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cmbRoomTypeFilter = new System.Windows.Forms.ComboBox();
            this.cmbGuestTypeFilter = new System.Windows.Forms.ComboBox();
            this.tabReports.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // tabReports
            // 
            this.tabReports.Controls.Add(this.tabPage1);
            this.tabReports.Controls.Add(this.tabPage2);
            this.tabReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabReports.Location = new System.Drawing.Point(40, 40);
            this.tabReports.Name = "tabReports";
            this.tabReports.SelectedIndex = 0;
            this.tabReports.Size = new System.Drawing.Size(900, 400);
            this.tabReports.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chartReport);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(892, 362);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Graphical Reports";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chartReport
            // 
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
            this.chartReport.Size = new System.Drawing.Size(886, 356);
            this.chartReport.TabIndex = 8;
            this.chartReport.Text = "Report Chart";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(892, 362);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detailed Reports";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtpReportFrom
            // 
            this.dtpReportFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReportFrom.Location = new System.Drawing.Point(40, 480);
            this.dtpReportFrom.Name = "dtpReportFrom";
            this.dtpReportFrom.Size = new System.Drawing.Size(300, 34);
            this.dtpReportFrom.TabIndex = 1;
            // 
            // dtpReportTo
            // 
            this.dtpReportTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReportTo.Location = new System.Drawing.Point(360, 480);
            this.dtpReportTo.Name = "dtpReportTo";
            this.dtpReportTo.Size = new System.Drawing.Size(300, 34);
            this.dtpReportTo.TabIndex = 2;
            // 
            // cmbReportType
            // 
            this.cmbReportType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(680, 480);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(260, 37);
            this.cmbReportType.TabIndex = 3;
            this.cmbReportType.Text = "Select Report Type";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(40, 540);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(300, 60);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "GENERATE REPORT";
            this.btnGenerate.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(360, 540);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(300, 60);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "EXPORT TO EXCEL";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(680, 540);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(260, 60);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "PRINT REPORT";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(40, 620);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersWidth = 51;
            this.dgvReport.RowTemplate.Height = 30;
            this.dgvReport.Size = new System.Drawing.Size(900, 280);
            this.dgvReport.TabIndex = 7;
            // 
            // reportViewer
            // 
            this.reportViewer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportViewer.Location = new System.Drawing.Point(1000, 40);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(880, 860);
            this.reportViewer.TabIndex = 8;
            // 
            // cmbRoomTypeFilter
            // 
            this.cmbRoomTypeFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoomTypeFilter.FormattingEnabled = true;
            this.cmbRoomTypeFilter.Location = new System.Drawing.Point(40, 920);
            this.cmbRoomTypeFilter.Name = "cmbRoomTypeFilter";
            this.cmbRoomTypeFilter.Size = new System.Drawing.Size(300, 37);
            this.cmbRoomTypeFilter.TabIndex = 9;
            this.cmbRoomTypeFilter.Text = "Filter by Room Type";
            // 
            // cmbGuestTypeFilter
            // 
            this.cmbGuestTypeFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGuestTypeFilter.FormattingEnabled = true;
            this.cmbGuestTypeFilter.Location = new System.Drawing.Point(360, 920);
            this.cmbGuestTypeFilter.Name = "cmbGuestTypeFilter";
            this.cmbGuestTypeFilter.Size = new System.Drawing.Size(300, 37);
            this.cmbGuestTypeFilter.TabIndex = 10;
            this.cmbGuestTypeFilter.Text = "Filter by Guest Type";
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1000);
            this.Controls.Add(this.cmbGuestTypeFilter);
            this.Controls.Add(this.cmbRoomTypeFilter);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.cmbReportType);
            this.Controls.Add(this.dtpReportTo);
            this.Controls.Add(this.dtpReportFrom);
            this.Controls.Add(this.tabReports);
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Management System - Reports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReports_Load_1);
            this.tabReports.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
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
    }
}