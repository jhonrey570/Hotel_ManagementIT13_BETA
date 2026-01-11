using Hotel_ManagementIT13.Data.Managers;
using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Hotel_ManagementIT13.Data
{
    public class ReportHelper
    {
        private readonly ReservationRepository _reservationRepo;
        private readonly PaymentRepository _paymentRepo;
        private readonly RoomManager _roomManager;

        public ReportHelper()
        {
            _reservationRepo = new ReservationRepository();
            _paymentRepo = new PaymentRepository();
            _roomManager = new RoomManager();
        }

        // Report type constants
        public const string OCCUPANCY_REPORT = "Occupancy Report";
        public const string FINANCIAL_REPORT = "Financial Report";
        public const string DAILY_SALES = "Daily Sales Report";
        public const string GUEST_REPORT = "Guest Report";
        public const string ROOM_REPORT = "Room Utilization Report";

        public List<string> GetReportTypes()
        {
            return new List<string>
            {
                "Select Report Type",
                OCCUPANCY_REPORT,
                FINANCIAL_REPORT,
                DAILY_SALES,
                GUEST_REPORT,
                ROOM_REPORT
            };
        }

        public DataTable GenerateOccupancyReport(DateTime fromDate, DateTime toDate, string roomTypeFilter = "All Room Types", string guestTypeFilter = "All Guest Types")
        {
            var dataTable = new DataTable("OccupancyReport");
            dataTable.Columns.Add("Date", typeof(string));
            dataTable.Columns.Add("TotalRooms", typeof(int));
            dataTable.Columns.Add("OccupiedRooms", typeof(int));
            dataTable.Columns.Add("AvailableRooms", typeof(int));
            dataTable.Columns.Add("OccupancyRate", typeof(string));
            dataTable.Columns.Add("ReservedRooms", typeof(int));

            try
            {
                var roomStats = _roomManager.GetRoomStatistics();
                int totalRooms = roomStats.ContainsKey("Total") ? roomStats["Total"] : 0;

                // Calculate for each day in the range
                for (DateTime date = fromDate; date <= toDate; date = date.AddDays(1))
                {
                    int occupiedRooms = 0;

                    try
                    {
                        // Get reservations for this date
                        var reservations = GetReservationsForDate(date, date, roomTypeFilter, guestTypeFilter);

                        // Calculate occupied rooms
                        foreach (var reservation in reservations)
                        {
                            if (reservation.CheckInDate <= date && reservation.CheckOutDate > date)
                            {
                                occupiedRooms += reservation.Rooms != null ? reservation.Rooms.Count : 0;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // If there's an error, use 0
                        occupiedRooms = 0;
                    }

                    int availableRooms = Math.Max(0, totalRooms - occupiedRooms);
                    decimal occupancyRate = totalRooms > 0 ? (decimal)occupiedRooms / totalRooms * 100 : 0;

                    dataTable.Rows.Add(
                        date.ToString("yyyy-MM-dd"),
                        totalRooms,
                        occupiedRooms,
                        availableRooms,
                        $"{occupancyRate:F2}%",
                        0 // Reserved rooms - would need more complex logic
                    );
                }
            }
            catch (Exception ex)
            {
                // Return empty table with error message
                Console.WriteLine($"Error generating occupancy report: {ex.Message}");
            }

            return dataTable;
        }

        public DataTable GenerateFinancialReport(DateTime fromDate, DateTime toDate, string roomTypeFilter = "All Room Types", string guestTypeFilter = "All Guest Types")
        {
            var dataTable = new DataTable("FinancialReport");
            dataTable.Columns.Add("BookingReference", typeof(string));
            dataTable.Columns.Add("GuestName", typeof(string));
            dataTable.Columns.Add("CheckInDate", typeof(string));
            dataTable.Columns.Add("CheckOutDate", typeof(string));
            dataTable.Columns.Add("Nights", typeof(int));
            dataTable.Columns.Add("RoomType", typeof(string));
            dataTable.Columns.Add("TotalAmount", typeof(decimal));
            dataTable.Columns.Add("Status", typeof(string));
            dataTable.Columns.Add("PaymentMethod", typeof(string));
            dataTable.Columns.Add("PaymentDate", typeof(string));
            dataTable.Columns.Add("AmountPaid", typeof(decimal));

            try
            {
                var reservations = GetReservationsForDate(fromDate, toDate, roomTypeFilter, guestTypeFilter);

                foreach (var reservation in reservations)
                {
                    // Get payment info for this reservation
                    var paymentInfo = GetPaymentInfo(reservation.ReservationId);

                    dataTable.Rows.Add(
                        reservation.BookingReference,
                        reservation.GuestName,
                        reservation.CheckInDate.ToString("yyyy-MM-dd"),
                        reservation.CheckOutDate.ToString("yyyy-MM-dd"),
                        reservation.NumberOfNights,
                        GetRoomTypes(reservation),
                        reservation.TotalAmount,
                        reservation.StatusName,
                        paymentInfo.PaymentMethod,
                        paymentInfo.PaymentDate,
                        paymentInfo.AmountPaid
                    );
                }
            }
            catch (Exception ex)
            {
                // Log error or handle appropriately
                Console.WriteLine($"Error generating financial report: {ex.Message}");
            }

            return dataTable;
        }

        public DataTable GenerateDailySalesReport(DateTime reportDate, string roomTypeFilter = "All Room Types", string guestTypeFilter = "All Guest Types")
        {
            var dataTable = new DataTable("DailySales");
            dataTable.Columns.Add("Time", typeof(string));
            dataTable.Columns.Add("TransactionType", typeof(string));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.Columns.Add("Amount", typeof(decimal));
            dataTable.Columns.Add("PaymentMethod", typeof(string));
            dataTable.Columns.Add("Reference", typeof(string));
            dataTable.Columns.Add("Status", typeof(string));
            dataTable.Columns.Add("GuestName", typeof(string));

            try
            {
                // Get payments for the day
                var payments = _paymentRepo.GetPaymentsByDateRange(reportDate, reportDate);

                foreach (var payment in payments)
                {
                    // Get reservation info
                    var reservation = GetReservationForPayment(payment.ReservationId);

                    // Apply filters
                    if (ShouldIncludeReservation(reservation, roomTypeFilter, guestTypeFilter))
                    {
                        dataTable.Rows.Add(
                            payment.PaymentDate.ToString("HH:mm"),
                            "Payment",
                            $"Payment for reservation {payment.BookingReference}",
                            payment.Amount,
                            payment.PaymentMethod,
                            payment.TransactionId ?? payment.BookingReference,
                            payment.StatusName,
                            payment.GuestName
                        );
                    }
                }

                // Also include check-ins as "potential sales"
                var checkIns = GetCheckInsForDate(reportDate);
                foreach (var checkIn in checkIns)
                {
                    if (ShouldIncludeReservation(checkIn, roomTypeFilter, guestTypeFilter))
                    {
                        dataTable.Rows.Add(
                            checkIn.CheckInDate.ToString("HH:mm"),
                            "Check-In",
                            $"Check-in for {checkIn.GuestName}",
                            checkIn.TotalAmount,
                            "Pending",
                            checkIn.BookingReference,
                            "Checked In",
                            checkIn.GuestName
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating daily sales report: {ex.Message}");
            }

            return dataTable;
        }

        public void PopulateChart(Chart chart, DataTable data, string reportType)
        {
            try
            {
                chart.Series.Clear();
                chart.Titles.Clear();
                chart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                chart.ChartAreas[0].AxisX.Interval = 1;
                chart.Palette = ChartColorPalette.BrightPastel;

                if (reportType == OCCUPANCY_REPORT)
                {
                    var series = new Series("Occupancy Rate")
                    {
                        ChartType = SeriesChartType.Line,
                        BorderWidth = 3,
                        Color = Color.Blue,
                        MarkerStyle = MarkerStyle.Circle,
                        MarkerSize = 8,
                        MarkerColor = Color.Red
                    };

                    foreach (DataRow row in data.Rows)
                    {
                        string rateStr = row["OccupancyRate"].ToString().Replace("%", "");
                        if (decimal.TryParse(rateStr, out decimal rate))
                        {
                            series.Points.AddXY(
                                row["Date"].ToString(),
                                rate
                            );
                        }
                    }

                    chart.Series.Add(series);
                    chart.ChartAreas[0].AxisY.Title = "Occupancy Rate (%)";
                    chart.ChartAreas[0].AxisX.Title = "Date";

                    chart.Titles.Add($"Occupancy Rate Trend ({data.Rows.Count} days)");
                    chart.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                }
                else if (reportType == FINANCIAL_REPORT)
                {
                    // Group by date for revenue chart
                    var revenueByDate = new Dictionary<string, decimal>();

                    foreach (DataRow row in data.Rows)
                    {
                        string date = row["CheckInDate"].ToString();
                        decimal amount = Convert.ToDecimal(row["TotalAmount"]);

                        if (revenueByDate.ContainsKey(date))
                            revenueByDate[date] += amount;
                        else
                            revenueByDate[date] = amount;
                    }

                    var series = new Series("Revenue")
                    {
                        ChartType = SeriesChartType.Column,
                        Color = Color.Green,
                        IsValueShownAsLabel = true,
                        // Changed from "C" to custom format for Peso
                        LabelFormat = "\"₱\"#,##0",
                        LabelAngle = -90
                    };

                    foreach (var kvp in revenueByDate.OrderBy(x => x.Key))
                    {
                        series.Points.AddXY(kvp.Key, kvp.Value);
                    }

                    chart.Series.Add(series);
                    chart.ChartAreas[0].AxisY.Title = "Revenue (₱)"; // Peso sign
                    chart.ChartAreas[0].AxisX.Title = "Date";

                    // Updated title with Peso sign
                    chart.Titles.Add($"Revenue by Date (Total: ₱{revenueByDate.Values.Sum():N2})");
                    chart.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                }
                else if (reportType == DAILY_SALES)
                {
                    // Pie chart for daily sales by payment method
                    var paymentsByMethod = new Dictionary<string, decimal>();

                    foreach (DataRow row in data.Rows)
                    {
                        string method = row["PaymentMethod"].ToString();
                        decimal amount = Convert.ToDecimal(row["Amount"]);

                        if (paymentsByMethod.ContainsKey(method))
                            paymentsByMethod[method] += amount;
                        else
                            paymentsByMethod[method] = amount;
                    }

                    var series = new Series("Payment Methods")
                    {
                        ChartType = SeriesChartType.Pie,
                        IsValueShownAsLabel = true,
                        // Changed to Peso format
                        LabelFormat = "#VALX: ₱#VALY{N2}",
                        Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                    };

                    foreach (var kvp in paymentsByMethod)
                    {
                        series.Points.AddXY(kvp.Key, kvp.Value);
                    }

                    chart.Series.Add(series);
                    chart.ChartAreas[0].Area3DStyle.Enable3D = true;

                    chart.Titles.Add($"Daily Sales by Payment Method");
                    chart.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error populating chart: {ex.Message}");
            }
        }

        public decimal CalculateTotalRevenue(DataTable data)
        {
            if (data.Columns.Contains("TotalAmount"))
            {
                try
                {
                    return data.AsEnumerable()
                        .Sum(row => Convert.ToDecimal(row["TotalAmount"]));
                }
                catch
                {
                    return 0;
                }
            }
            else if (data.Columns.Contains("Amount"))
            {
                try
                {
                    return data.AsEnumerable()
                        .Sum(row => Convert.ToDecimal(row["Amount"]));
                }
                catch
                {
                    return 0;
                }
            }
            return 0;
        }

        public void ExportToCSV(DataGridView dataGridView, string reportName)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "CSV Files|*.csv|All Files|*.*",
                    FileName = $"{reportName}_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                    Title = "Export to CSV"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder csvContent = new StringBuilder();

                    // Add headers
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        csvContent.Append(dataGridView.Columns[i].HeaderText);
                        if (i < dataGridView.Columns.Count - 1)
                            csvContent.Append(",");
                    }
                    csvContent.AppendLine();

                    // Add data rows
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            for (int i = 0; i < dataGridView.Columns.Count; i++)
                            {
                                string cellValue = row.Cells[i].Value?.ToString() ?? "";

                                // Escape commas and quotes
                                if (cellValue.Contains(",") || cellValue.Contains("\"") || cellValue.Contains("\n") || cellValue.Contains("\r"))
                                {
                                    cellValue = $"\"{cellValue.Replace("\"", "\"\"")}\"";
                                }

                                csvContent.Append(cellValue);
                                if (i < dataGridView.Columns.Count - 1)
                                    csvContent.Append(",");
                            }
                            csvContent.AppendLine();
                        }
                    }

                    // Write to file
                    File.WriteAllText(saveDialog.FileName, csvContent.ToString(), Encoding.UTF8);

                    MessageBox.Show($"Report exported successfully to:\n{saveDialog.FileName}",
                        "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to CSV: {ex.Message}",
                    "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PrintReport(DataGridView dataGridView, string reportTitle, DateTime fromDate, DateTime toDate)
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                PrintDocument printDocument = new PrintDocument();

                printDocument.PrintPage += (sender, e) =>
                {
                    // Create report header
                    string header = $"Hotel Management System\n";
                    header += $"{reportTitle}\n";
                    header += $"Date Range: {fromDate:yyyy-MM-dd} to {toDate:yyyy-MM-dd}\n";
                    header += $"Generated: {DateTime.Now:yyyy-MM-dd HH:mm}\n";
                    header += new string('-', 80) + "\n\n";

                    // Create column headers
                    string columnHeaders = "";
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        columnHeaders += dataGridView.Columns[i].HeaderText.PadRight(20);
                    }
                    columnHeaders += "\n" + new string('-', 80) + "\n";

                    // Create data rows
                    List<string> rows = new List<string>();
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string rowData = "";
                            for (int i = 0; i < dataGridView.Columns.Count; i++)
                            {
                                string cellValue = row.Cells[i].Value?.ToString() ?? "";
                                rowData += cellValue.PadRight(20);
                            }
                            rows.Add(rowData);
                        }
                    }

                    // Combine all content
                    string content = header + columnHeaders + string.Join("\n", rows);

                    // Draw to print page
                    e.Graphics.DrawString(content,
                        new Font("Courier New", 10),
                        Brushes.Black,
                        new RectangleF(50, 50, 750, 1000));
                };

                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing: {ex.Message}",
                    "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<string> GetRoomTypes()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT type_name FROM room_types ORDER BY type_name";
                    var roomTypes = new List<string> { "All Room Types" };

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roomTypes.Add(reader["type_name"].ToString());
                        }
                    }

                    return roomTypes;
                }
            }
            catch (Exception)
            {
                // Return default list if database query fails
                return new List<string>
                {
                    "All Room Types",
                    "Standard Room",
                    "Deluxe Room",
                    "Executive Suite",
                    "Presidential Suite"
                };
            }
        }

        public List<string> GetGuestTypes()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT guest_type_name FROM guest_types ORDER BY guest_type_name";
                    var guestTypes = new List<string> { "All Guest Types" };

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            guestTypes.Add(reader["guest_type_name"].ToString());
                        }
                    }

                    return guestTypes;
                }
            }
            catch (Exception)
            {
                // Return default list if database query fails
                return new List<string>
                {
                    "All Guest Types",
                    "Walk-in",
                    "Regular",
                    "VIP",
                    "Corporate"
                };
            }
        }

        // Private helper methods
        private List<Reservation> GetReservationsForDate(DateTime fromDate, DateTime toDate, string roomTypeFilter, string guestTypeFilter)
        {
            try
            {
                var reservations = _reservationRepo.GetReservationsByDateRange(fromDate, toDate);

                if (reservations == null)
                    return new List<Reservation>();

                // Apply filters
                if (roomTypeFilter != "All Room Types")
                {
                    reservations = reservations.Where(r =>
                        r.Rooms != null && r.Rooms.Any(room => room.RoomTypeName == roomTypeFilter)).ToList();
                }

                return reservations;
            }
            catch (Exception)
            {
                return new List<Reservation>();
            }
        }

        private (string PaymentMethod, string PaymentDate, decimal AmountPaid) GetPaymentInfo(int reservationId)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT payment_method, payment_date, amount 
                        FROM payments 
                        WHERE reservation_id = @reservationId 
                        ORDER BY payment_date DESC LIMIT 1";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@reservationId", reservationId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return (
                                    reader["payment_method"].ToString(),
                                    Convert.ToDateTime(reader["payment_date"]).ToString("yyyy-MM-dd"),
                                    Convert.ToDecimal(reader["amount"])
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Return defaults if no payment found
            }

            return ("Not Paid", "N/A", 0);
        }

        private string GetRoomTypes(Reservation reservation)
        {
            if (reservation.Rooms == null || reservation.Rooms.Count == 0)
                return "N/A";

            return string.Join(", ", reservation.Rooms.Select(r => r.RoomTypeName).Distinct());
        }

        private Reservation GetReservationForPayment(int reservationId)
        {
            try
            {
                var reservations = _reservationRepo.GetReservationsByDateRange(DateTime.MinValue, DateTime.MaxValue);
                return reservations?.FirstOrDefault(r => r.ReservationId == reservationId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private List<Reservation> GetCheckInsForDate(DateTime date)
        {
            try
            {
                var reservations = _reservationRepo.GetReservationsByDateRange(date, date);
                return reservations?.Where(r => r.CheckInDate.Date == date.Date).ToList() ?? new List<Reservation>();
            }
            catch (Exception)
            {
                return new List<Reservation>();
            }
        }

        private bool ShouldIncludeReservation(Reservation reservation, string roomTypeFilter, string guestTypeFilter)
        {
            if (reservation == null)
                return false;

            // Room type filter
            if (roomTypeFilter != "All Room Types")
            {
                if (reservation.Rooms == null || !reservation.Rooms.Any(r => r.RoomTypeName == roomTypeFilter))
                    return false;
            }

            return true;
        }

        public decimal GetTotalRevenueForPeriod(DateTime startDate, DateTime endDate)
        {
            try
            {
                return _paymentRepo.GetTotalRevenue(startDate, endDate);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}