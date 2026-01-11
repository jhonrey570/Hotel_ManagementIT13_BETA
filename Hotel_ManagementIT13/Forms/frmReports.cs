using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_ManagementIT13.Forms
{
    public partial class frmReports : Form
    {
        private DataTable currentReportData;
        private Hotel_ManagementIT13.Data.ReportHelper reportHelper;
        private string currentReportType;

        public frmReports()
        {
            InitializeComponent();
            reportHelper = new Hotel_ManagementIT13.Data.ReportHelper();
            InitializeControls();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            // Existing load code
        }

        private void frmReports_Load_1(object sender, EventArgs e)
        {
            InitializeControls();
        }

        private void InitializeControls()
        {
            // Set default dates (last 7 days)
            dtpReportFrom.Value = DateTime.Today.AddDays(-7);
            dtpReportTo.Value = DateTime.Today;

            // Populate report type combo box
            cmbReportType.Items.Clear();
            cmbReportType.Items.AddRange(reportHelper.GetReportTypes().ToArray());
            cmbReportType.SelectedIndex = 0;

            // Populate room type filter
            cmbRoomTypeFilter.Items.Clear();
            cmbRoomTypeFilter.Items.AddRange(reportHelper.GetRoomTypes().ToArray());
            cmbRoomTypeFilter.SelectedIndex = 0;

            // Populate guest type filter
            cmbGuestTypeFilter.Items.Clear();
            cmbGuestTypeFilter.Items.AddRange(reportHelper.GetGuestTypes().ToArray());
            cmbGuestTypeFilter.SelectedIndex = 0;

            // Configure chart
            ConfigureChart();

            // Configure detailed reports tab
            ConfigureDetailedReportsTab();

            // Set button colors
            SetButtonColors();

            // Center the panel
            CenterPanel();
        }

        private void ConfigureChart()
        {
            chartReport.Series.Clear();
            chartReport.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chartReport.ChartAreas[0].AxisX.Interval = 1;
            chartReport.ChartAreas[0].AxisY.Title = "Value";
            chartReport.ChartAreas[0].AxisX.Title = "Date";

            // Set chart appearance
            chartReport.BackColor = Color.White;
            chartReport.ChartAreas[0].BackColor = Color.White;
            chartReport.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chartReport.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
        }

        private void ConfigureDetailedReportsTab()
        {
            // Clear existing controls in tabPage2
            tabPage2.Controls.Clear();

            // Create a Panel for better layout
            Panel detailPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.GhostWhite,
                Padding = new Padding(10)
            };

            // Create a Label for instructions
            Label lblInstructions = new Label
            {
                Text = "Detailed Reports\n\n" +
                      "This tab shows detailed information about the generated report.\n" +
                      "Generate a report first, then switch to this tab to see the details.",
                Font = new Font("Calibri", 12, FontStyle.Regular),
                ForeColor = Color.DarkSlateGray,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                AutoSize = false
            };

            // Create a TableLayoutPanel for organized display
            TableLayoutPanel tableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 0,
                AutoScroll = true,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                BackColor = Color.White
            };

            // Set column styles
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));

            // Add controls to detailPanel
            detailPanel.Controls.Add(lblInstructions);
            detailPanel.Controls.Add(tableLayout);

            // Store references for later use
            tabPage2.Tag = new { Panel = detailPanel, TableLayout = tableLayout, Label = lblInstructions };

            // Add detailPanel to tabPage2
            tabPage2.Controls.Add(detailPanel);
        }

        private void SetButtonColors()
        {
            // Set button colors for better UI
            btnGenerate.BackColor = Color.FromArgb(46, 204, 113); // Green
            btnGenerate.ForeColor = Color.White;
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.FlatAppearance.BorderSize = 0;

            btnExport.BackColor = Color.FromArgb(52, 152, 219); // Blue
            btnExport.ForeColor = Color.White;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.FlatAppearance.BorderSize = 0;

            btnPrint.BackColor = Color.FromArgb(155, 89, 182); // Purple
            btnPrint.ForeColor = Color.White;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.FlatAppearance.BorderSize = 0;

            btnClearFilters.BackColor = Color.FromArgb(231, 76, 60); // Red
            btnClearFilters.ForeColor = Color.White;
            btnClearFilters.FlatStyle = FlatStyle.Flat;
            btnClearFilters.FlatAppearance.BorderSize = 0;
        }

        private void CenterPanel()
        {
            if (panel1 != null)
            {
                panel1.Left = Math.Max(0, (this.ClientSize.Width - panel1.Width) / 2);
                panel1.Top = Math.Max(0, (this.ClientSize.Height - panel1.Height) / 2);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (cmbReportType.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please select a report type.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime fromDate = dtpReportFrom.Value.Date;
                DateTime toDate = dtpReportTo.Value.Date;

                if (fromDate > toDate)
                {
                    MessageBox.Show("From date cannot be later than To date.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                currentReportType = cmbReportType.SelectedItem.ToString();
                currentReportData = null;

                string roomTypeFilter = cmbRoomTypeFilter.SelectedItem?.ToString() ?? "All Room Types";
                string guestTypeFilter = cmbGuestTypeFilter.SelectedItem?.ToString() ?? "All Guest Types";

                // Generate report based on type
                switch (currentReportType)
                {
                    case Hotel_ManagementIT13.Data.ReportHelper.OCCUPANCY_REPORT:
                        currentReportData = reportHelper.GenerateOccupancyReport(fromDate, toDate, roomTypeFilter, guestTypeFilter);
                        DisplayReport(currentReportData, "Occupancy Report");
                        reportHelper.PopulateChart(chartReport, currentReportData, Hotel_ManagementIT13.Data.ReportHelper.OCCUPANCY_REPORT);
                        break;

                    case Hotel_ManagementIT13.Data.ReportHelper.FINANCIAL_REPORT:
                        currentReportData = reportHelper.GenerateFinancialReport(fromDate, toDate, roomTypeFilter, guestTypeFilter);
                        DisplayReport(currentReportData, "Financial Report");
                        reportHelper.PopulateChart(chartReport, currentReportData, Hotel_ManagementIT13.Data.ReportHelper.FINANCIAL_REPORT);
                        break;

                    case Hotel_ManagementIT13.Data.ReportHelper.DAILY_SALES:
                        // For daily sales, use only from date
                        currentReportData = reportHelper.GenerateDailySalesReport(fromDate, roomTypeFilter, guestTypeFilter);
                        DisplayReport(currentReportData, "Daily Sales Report");
                        reportHelper.PopulateChart(chartReport, currentReportData, Hotel_ManagementIT13.Data.ReportHelper.DAILY_SALES);
                        break;

                    case Hotel_ManagementIT13.Data.ReportHelper.GUEST_REPORT:
                        MessageBox.Show("Guest Report feature coming soon!", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;

                    case Hotel_ManagementIT13.Data.ReportHelper.ROOM_REPORT:
                        MessageBox.Show("Room Utilization Report feature coming soon!", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;

                    default:
                        MessageBox.Show("Please select a valid report type.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                UpdateSummaryLabels();

                // Switch to graphical reports tab
                tabReports.SelectedTab = tabPage1;

                MessageBox.Show($"Report generated successfully!\n{currentReportData.Rows.Count} records found.",
                    "Report Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void DisplayReport(DataTable data, string reportTitle)
        {
            dgvReport.DataSource = data;

            // Format the DataGridView
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGoldenrod;
            dgvReport.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReport.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
            dgvReport.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReport.EnableHeadersVisualStyles = false;

            // Format currency columns - USING PESO SIGN (₱)
            foreach (DataGridViewColumn column in dgvReport.Columns)
            {
                if (column.Name.Contains("Amount") || column.Name.Contains("Revenue") || column.Name.Contains("Paid"))
                {
                    // Set custom format for Peso
                    column.DefaultCellStyle.Format = "\"₱\"#,##0.00";
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    column.DefaultCellStyle.ForeColor = Color.Green;
                }
                else if (column.Name.Contains("Rate"))
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (column.Name.Contains("Date"))
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                column.DefaultCellStyle.Font = new Font("Calibri", 10F);
                column.DefaultCellStyle.Padding = new Padding(2);
            }

            // Set alternating row colors
            dgvReport.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvReport.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 192);
            dgvReport.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Auto-resize rows
            dgvReport.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

            // Update labels
            lblData.Text = $"{reportTitle} ({data.Rows.Count} records)";

            // Show data grid view
            dgvReport.Visible = true;

            // Update detailed reports tab
            UpdateDetailedReportsTab(data, reportTitle);
        }

        private void UpdateDetailedReportsTab(DataTable data, string reportTitle)
        {
            if (tabPage2.Tag == null) return;

            dynamic tabControls = tabPage2.Tag;
            Panel detailPanel = tabControls.Panel;
            TableLayoutPanel tableLayout = tabControls.TableLayout;
            Label lblInstructions = tabControls.Label;

            // Clear existing rows
            tableLayout.Controls.Clear();
            tableLayout.RowStyles.Clear();
            tableLayout.RowCount = 0;

            if (data == null || data.Rows.Count == 0)
            {
                lblInstructions.Text = "No data available.\nPlease generate a report first.";
                lblInstructions.Visible = true;
                tableLayout.Visible = false;
                return;
            }

            lblInstructions.Visible = false;
            tableLayout.Visible = true;

            // Add report header
            AddTableRow(tableLayout, "Report Type", reportTitle, true);
            AddTableRow(tableLayout, "Date Range", $"{dtpReportFrom.Value:yyyy-MM-dd} to {dtpReportTo.Value:yyyy-MM-dd}", false);
            AddTableRow(tableLayout, "Generated", DateTime.Now.ToString("yyyy-MM-dd HH:mm"), false);
            AddTableRow(tableLayout, "Total Records", data.Rows.Count.ToString(), false);

            // Add separator
            AddTableRow(tableLayout, "", "", true);

            // Calculate and display summary based on report type
            if (currentReportType == Hotel_ManagementIT13.Data.ReportHelper.OCCUPANCY_REPORT)
            {
                DisplayOccupancySummary(data, tableLayout);
            }
            else if (currentReportType == Hotel_ManagementIT13.Data.ReportHelper.FINANCIAL_REPORT)
            {
                DisplayFinancialSummary(data, tableLayout);
            }
            else if (currentReportType == Hotel_ManagementIT13.Data.ReportHelper.DAILY_SALES)
            {
                DisplayDailySalesSummary(data, tableLayout);
            }

            // Add separator
            AddTableRow(tableLayout, "", "", true);

            // Add column headers from data
            foreach (DataColumn column in data.Columns)
            {
                AddTableRow(tableLayout, column.ColumnName, "Sample Data", true);
            }
        }

        private void DisplayOccupancySummary(DataTable data, TableLayoutPanel tableLayout)
        {
            decimal totalRate = 0;
            int count = 0;
            int maxOccupancy = 0;
            DateTime maxDate = DateTime.MinValue;
            int minOccupancy = int.MaxValue;
            DateTime minDate = DateTime.MinValue;

            foreach (DataRow row in data.Rows)
            {
                string rateStr = row["OccupancyRate"].ToString().Replace("%", "");
                if (decimal.TryParse(rateStr, out decimal rate))
                {
                    totalRate += rate;
                    count++;

                    int occupied = Convert.ToInt32(row["OccupiedRooms"]);
                    string dateStr = row["Date"].ToString();

                    if (occupied > maxOccupancy)
                    {
                        maxOccupancy = occupied;
                        maxDate = DateTime.Parse(dateStr);
                    }

                    if (occupied < minOccupancy)
                    {
                        minOccupancy = occupied;
                        minDate = DateTime.Parse(dateStr);
                    }
                }
            }

            if (count > 0)
            {
                decimal avgOccupancy = totalRate / count;
                AddTableRow(tableLayout, "Average Occupancy", $"{avgOccupancy:F2}%", false);
                AddTableRow(tableLayout, "Peak Occupancy", $"{maxOccupancy} rooms ({maxDate:MMM dd})", false);
                AddTableRow(tableLayout, "Lowest Occupancy", $"{minOccupancy} rooms ({minDate:MMM dd})", false);
            }
        }

        private void DisplayFinancialSummary(DataTable data, TableLayoutPanel tableLayout)
        {
            decimal totalRevenue = 0;
            decimal totalPaid = 0;
            int totalReservations = data.Rows.Count;
            Dictionary<string, decimal> revenueByStatus = new Dictionary<string, decimal>();

            foreach (DataRow row in data.Rows)
            {
                decimal amount = Convert.ToDecimal(row["TotalAmount"]);
                totalRevenue += amount;

                if (data.Columns.Contains("AmountPaid"))
                {
                    decimal paid = Convert.ToDecimal(row["AmountPaid"]);
                    totalPaid += paid;
                }

                string status = row["Status"].ToString();
                if (!revenueByStatus.ContainsKey(status))
                    revenueByStatus[status] = 0;
                revenueByStatus[status] += amount;
            }

            AddTableRow(tableLayout, "Total Revenue", $"₱{totalRevenue:N2}", false);
            AddTableRow(tableLayout, "Total Reservations", totalReservations.ToString(), false);

            if (totalPaid > 0)
            {
                AddTableRow(tableLayout, "Total Paid", $"₱{totalPaid:N2}", false);
                AddTableRow(tableLayout, "Balance", $"₱{(totalRevenue - totalPaid):N2}", false);
            }

            // Add revenue by status
            foreach (var kvp in revenueByStatus)
            {
                AddTableRow(tableLayout, $"Revenue ({kvp.Key})", $"₱{kvp.Value:N2}", false);
            }
        }

        private void DisplayDailySalesSummary(DataTable data, TableLayoutPanel tableLayout)
        {
            decimal totalSales = 0;
            Dictionary<string, decimal> salesByMethod = new Dictionary<string, decimal>();
            Dictionary<string, int> countByMethod = new Dictionary<string, int>();

            foreach (DataRow row in data.Rows)
            {
                decimal amount = Convert.ToDecimal(row["Amount"]);
                totalSales += amount;

                string method = row["PaymentMethod"].ToString();
                if (!salesByMethod.ContainsKey(method))
                {
                    salesByMethod[method] = 0;
                    countByMethod[method] = 0;
                }
                salesByMethod[method] += amount;
                countByMethod[method]++;
            }

            AddTableRow(tableLayout, "Total Daily Sales", $"₱{totalSales:N2}", false);
            AddTableRow(tableLayout, "Total Transactions", data.Rows.Count.ToString(), false);

            // Add sales by payment method
            foreach (var kvp in salesByMethod)
            {
                decimal percentage = totalSales > 0 ? (kvp.Value / totalSales * 100) : 0;
                AddTableRow(tableLayout, $"{kvp.Key} ({countByMethod[kvp.Key]} trans)",
                           $"₱{kvp.Value:N2} ({percentage:F1}%)", false);
            }
        }

        private void AddTableRow(TableLayoutPanel tableLayout, string label, string value, bool isHeader)
        {
            int rowIndex = tableLayout.RowCount;
            tableLayout.RowCount++;
            tableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            Label lblLabel = new Label
            {
                Text = label,
                Font = isHeader ? new Font("Calibri", 10, FontStyle.Bold) : new Font("Calibri", 10),
                ForeColor = isHeader ? Color.DarkGoldenrod : Color.Black,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5)
            };

            Label lblValue = new Label
            {
                Text = value,
                Font = isHeader ? new Font("Calibri", 10, FontStyle.Bold) : new Font("Calibri", 10),
                ForeColor = isHeader ? Color.DarkSlateGray : Color.Black,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5)
            };

            tableLayout.Controls.Add(lblLabel, 0, rowIndex);
            tableLayout.Controls.Add(lblValue, 1, rowIndex);
        }

        private void UpdateSummaryLabels()
        {
            if (currentReportData != null && currentReportData.Rows.Count > 0)
            {
                if (currentReportType == Hotel_ManagementIT13.Data.ReportHelper.FINANCIAL_REPORT)
                {
                    decimal totalRevenue = reportHelper.CalculateTotalRevenue(currentReportData);
                    lblRates.Text = $"Total Revenue: ₱{totalRevenue:N2}"; // Peso sign
                    lblRates.ForeColor = Color.Green;

                    // Also show total for the period
                    decimal periodRevenue = reportHelper.GetTotalRevenueForPeriod(dtpReportFrom.Value, dtpReportTo.Value);
                    lblDatess.Text = $"Dates: {dtpReportFrom.Value:yyyy-MM-dd} to {dtpReportTo.Value:yyyy-MM-dd} (Total: ₱{periodRevenue:N2})";
                }
                else if (currentReportType == Hotel_ManagementIT13.Data.ReportHelper.OCCUPANCY_REPORT)
                {
                    if (currentReportData.Columns.Contains("OccupancyRate"))
                    {
                        // Calculate average occupancy
                        decimal totalRate = 0;
                        int count = 0;

                        foreach (DataRow row in currentReportData.Rows)
                        {
                            string rateStr = row["OccupancyRate"].ToString().Replace("%", "");
                            if (decimal.TryParse(rateStr, out decimal rate))
                            {
                                totalRate += rate;
                                count++;
                            }
                        }

                        if (count > 0)
                        {
                            decimal avgOccupancy = totalRate / count;
                            lblRates.Text = $"Average Occupancy: {avgOccupancy:F2}%";

                            // Color code based on occupancy
                            if (avgOccupancy > 80)
                                lblRates.ForeColor = Color.Red;
                            else if (avgOccupancy > 60)
                                lblRates.ForeColor = Color.Orange;
                            else
                                lblRates.ForeColor = Color.Green;
                        }
                    }
                }
                else if (currentReportType == Hotel_ManagementIT13.Data.ReportHelper.DAILY_SALES)
                {
                    if (currentReportData.Columns.Contains("Amount"))
                    {
                        decimal totalSales = reportHelper.CalculateTotalRevenue(currentReportData);
                        lblRates.Text = $"Total Daily Sales: ₱{totalSales:N2}"; // Peso sign
                        lblRates.ForeColor = Color.Blue;

                        // Update date label
                        lblDatess.Text = $"Date: {dtpReportFrom.Value:yyyy-MM-dd}";
                    }
                }
            }
            else
            {
                lblRates.Text = "No data available";
                lblRates.ForeColor = Color.Gray;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReport.Rows.Count == 0 || dgvReport.DataSource == null)
                {
                    MessageBox.Show("No data to export. Please generate a report first.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string reportName = currentReportType ?? "Report";
                reportHelper.ExportToCSV(dgvReport, reportName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReport.Rows.Count == 0 || dgvReport.DataSource == null)
                {
                    MessageBox.Show("No data to print. Please generate a report first.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime fromDate = dtpReportFrom.Value;
                DateTime toDate = dtpReportTo.Value;

                string reportTitle = currentReportType ?? "Report";
                reportHelper.PrintReport(dgvReport, reportTitle, fromDate, toDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset chart when report type changes
            if (chartReport.Series.Count > 0)
            {
                chartReport.Series.Clear();
                chartReport.Titles.Clear();
            }

            // Update date picker visibility for daily sales
            if (cmbReportType.SelectedItem?.ToString() == Hotel_ManagementIT13.Data.ReportHelper.DAILY_SALES)
            {
                lblDatess.Text = "Date:";
                dtpReportTo.Visible = false;
                dtpReportFrom.Value = DateTime.Today;
            }
            else
            {
                lblDatess.Text = "Dates:";
                dtpReportTo.Visible = true;
            }
        }

        private void dtpReportFrom_ValueChanged(object sender, EventArgs e)
        {
            // Enable/disable generate button based on date validity
            if (cmbReportType.SelectedItem?.ToString() == Hotel_ManagementIT13.Data.ReportHelper.DAILY_SALES)
            {
                btnGenerate.Enabled = true;
            }
            else
            {
                btnGenerate.Enabled = dtpReportFrom.Value <= dtpReportTo.Value;
            }
        }

        private void dtpReportTo_ValueChanged(object sender, EventArgs e)
        {
            // Enable/disable generate button based on date validity
            btnGenerate.Enabled = dtpReportFrom.Value <= dtpReportTo.Value;
        }

        private void tabReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabReports.SelectedTab == tabPage1) // Graphical Reports tab
            {
                if (chartReport.Series.Count == 0 && currentReportData != null)
                {
                    // Re-populate chart if data exists
                    reportHelper.PopulateChart(chartReport, currentReportData, currentReportType);
                }
            }
            else if (tabReports.SelectedTab == tabPage2) // Detailed Reports tab
            {
                // Ensure detailed tab is updated with current data
                if (currentReportData != null)
                {
                    UpdateDetailedReportsTab(currentReportData, currentReportType);
                }
            }
        }

        private void cmbRoomTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Filter applied - you can regenerate report automatically or wait for generate button
        }

        private void cmbGuestTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Filter applied - you can regenerate report automatically or wait for generate button
        }

        private void frmReports_Resize(object sender, EventArgs e)
        {
            // Center the panel when form is resized
            CenterPanel();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            // Clear all filters and reset to defaults
            cmbReportType.SelectedIndex = 0;
            cmbRoomTypeFilter.SelectedIndex = 0;
            cmbGuestTypeFilter.SelectedIndex = 0;
            dtpReportFrom.Value = DateTime.Today.AddDays(-7);
            dtpReportTo.Value = DateTime.Today;

            // Clear data
            dgvReport.DataSource = null;
            chartReport.Series.Clear();
            chartReport.Titles.Clear();

            // Clear detailed reports tab
            if (tabPage2.Tag != null)
            {
                dynamic tabControls = tabPage2.Tag;
                Label lblInstructions = tabControls.Label;
                TableLayoutPanel tableLayout = tabControls.TableLayout;

                lblInstructions.Text = "Detailed Reports\n\n" +
                                      "This tab shows detailed information about the generated report.\n" +
                                      "Generate a report first, then switch to this tab to see the details.";
                lblInstructions.Visible = true;
                tableLayout.Visible = false;
                tableLayout.Controls.Clear();
                tableLayout.RowStyles.Clear();
                tableLayout.RowCount = 0;
            }

            // Reset labels
            lblRates.Text = "Chart";
            lblData.Text = "Reports";
            lblDatess.Text = "Dates:";

            MessageBox.Show("All filters cleared!", "Clear Filters",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}