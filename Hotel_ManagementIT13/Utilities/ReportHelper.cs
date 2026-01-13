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
        private readonly GuestRepository _guestRepo;
        private readonly RoomRepository _roomRepo;

        public ReportHelper()
        {
            _reservationRepo = new ReservationRepository();
            _paymentRepo = new PaymentRepository();
            _roomManager = new RoomManager();
            _guestRepo = new GuestRepository();
            _roomRepo = new RoomRepository();
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

        public DataTable GenerateOccupancyReport(DateTime fromDate, DateTime toDate,
            string roomTypeFilter = "All Room Types", string guestTypeFilter = "All Guest Types")
        {
            return GenerateDailyOccupancyData(fromDate, toDate, roomTypeFilter);
        }

        public DataTable GenerateFinancialReport(DateTime fromDate, DateTime toDate,
            string roomTypeFilter = "All Room Types", string guestTypeFilter = "All Guest Types")
        {
            return GenerateReservationFinancialData(fromDate, toDate, roomTypeFilter, guestTypeFilter);
        }

        public DataTable GenerateDailySalesReport(DateTime reportDate,
            string roomTypeFilter = "All Room Types", string guestTypeFilter = "All Guest Types")
        {
            return GenerateDailyTransactionData(reportDate, roomTypeFilter, guestTypeFilter);
        }

        public DataTable GenerateGuestReport(DateTime fromDate, DateTime toDate,
            string roomTypeFilter = "All Room Types", string guestTypeFilter = "All Guest Types")
        {
            return GenerateGuestAnalysisData(fromDate, toDate, guestTypeFilter);
        }

        public DataTable GenerateRoomUtilizationReport(DateTime fromDate, DateTime toDate,
            string roomTypeFilter = "All Room Types", string guestTypeFilter = "All Guest Types")
        {
            return GenerateRoomUtilizationData(fromDate, toDate, roomTypeFilter);
        }

        

        public void PopulateChart(Chart chart, DataTable data, string reportType)
        {
            if (data == null || data.Rows.Count == 0)
                return;

            chart.Series.Clear();
            chart.Titles.Clear();
            chart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.Palette = ChartColorPalette.BrightPastel;

            switch (reportType)
            {
                case OCCUPANCY_REPORT:
                    CreateOccupancyChart(chart, data);
                    break;
                case FINANCIAL_REPORT:
                    CreateFinancialChart(chart, data);
                    break;
                case DAILY_SALES:
                    CreateDailySalesChart(chart, data);
                    break;
                case GUEST_REPORT:
                    CreateGuestChart(chart, data);
                    break;
                case ROOM_REPORT:
                    CreateRoomUtilizationChart(chart, data);
                    break;
            }
        }

       

        public decimal CalculateTotalRevenue(DataTable data)
        {
            if (data.Columns.Contains("TotalAmount"))
            {
                return CalculateSumFromColumn(data, "TotalAmount");
            }
            else if (data.Columns.Contains("Amount"))
            {
                return CalculateSumFromColumn(data, "Amount");
            }
            else if (data.Columns.Contains("TotalSpent"))
            {
                return CalculateSumFromColumn(data, "TotalSpent");
            }
            else if (data.Columns.Contains("Revenue"))
            {
                return CalculateSumFromColumn(data, "Revenue");
            }
            return 0;
        }

        public void ExportToCSV(DataGridView dataGridView, string reportName)
        {
            ExportDataGridViewToCSV(dataGridView, reportName);
        }

        public void PrintReport(DataGridView dataGridView, string reportTitle, DateTime fromDate, DateTime toDate)
        {
            PrintDataGridView(dataGridView, reportTitle, fromDate, toDate);
        }

        public List<string> GetRoomTypes()
        {
            return RetrieveRoomTypesFromDatabase();
        }

        public List<string> GetGuestTypes()
        {
            return RetrieveGuestTypesFromDatabase();
        }

        public decimal GetTotalRevenueForPeriod(DateTime startDate, DateTime endDate)
        {
            return RetrieveTotalRevenue(startDate, endDate);
        }

       

        private DataTable GenerateDailyOccupancyData(DateTime fromDate, DateTime toDate, string roomTypeFilter)
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

                for (DateTime date = fromDate; date <= toDate; date = date.AddDays(1))
                {
                    int occupiedRooms = CalculateOccupiedRoomsForDate(date, roomTypeFilter);
                    int availableRooms = Math.Max(0, totalRooms - occupiedRooms);
                    decimal occupancyRate = totalRooms > 0 ? (decimal)occupiedRooms / totalRooms * 100 : 0;

                    dataTable.Rows.Add(
                        date.ToString("yyyy-MM-dd"),
                        totalRooms,
                        occupiedRooms,
                        availableRooms,
                        $"{occupancyRate:F2}%",
                        0
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating occupancy report: {ex.Message}");
            }

            return dataTable;
        }

        private DataTable GenerateReservationFinancialData(DateTime fromDate, DateTime toDate,
            string roomTypeFilter, string guestTypeFilter)
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
                var reservations = GetFilteredReservations(fromDate, toDate, roomTypeFilter, guestTypeFilter);

                foreach (var reservation in reservations)
                {
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
                Console.WriteLine($"Error generating financial report: {ex.Message}");
            }

            return dataTable;
        }

        private DataTable GenerateDailyTransactionData(DateTime reportDate,
            string roomTypeFilter, string guestTypeFilter)
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
                var payments = _paymentRepo.GetPaymentsByDateRange(reportDate, reportDate);

                foreach (var payment in payments)
                {
                    var reservation = GetReservationForPayment(payment.ReservationId);

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

        private DataTable GenerateGuestAnalysisData(DateTime fromDate, DateTime toDate, string guestTypeFilter)
        {
            var dataTable = new DataTable("GuestReport");

            // Basic guest information
            dataTable.Columns.Add("GuestID", typeof(int));
            dataTable.Columns.Add("FullName", typeof(string));
            dataTable.Columns.Add("GuestType", typeof(string));
            dataTable.Columns.Add("Phone", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("Nationality", typeof(string));

            // Reservation statistics
            dataTable.Columns.Add("TotalReservations", typeof(int));
            dataTable.Columns.Add("TotalNights", typeof(int));
            dataTable.Columns.Add("TotalSpent", typeof(decimal));
            dataTable.Columns.Add("LastVisit", typeof(string));

            try
            {
                // Get all guests first
                var allGuests = _guestRepo.GetAllGuests();

                // Filter by guest type if needed
                if (guestTypeFilter != "All Guest Types")
                {
                    allGuests = allGuests.Where(g => g.GuestTypeName == guestTypeFilter).ToList();
                }

                foreach (var guest in allGuests)
                {
                    // Get reservations for this guest
                    var guestReservations = GetReservationsForGuest(guest.GuestId, fromDate, toDate);

                    int totalReservations = guestReservations.Count;
                    int totalNights = guestReservations.Sum(r => r.NumberOfNights);
                    decimal totalSpent = guestReservations.Sum(r => r.TotalAmount);
                    string lastVisit = guestReservations.Any()
                        ? guestReservations.Max(r => r.CheckInDate).ToString("yyyy-MM-dd")
                        : "Never";

                    dataTable.Rows.Add(
                        guest.GuestId,
                        $"{guest.FirstName} {guest.LastName}",
                        guest.GuestTypeName,
                        guest.Phone,
                        guest.Email ?? "",
                        guest.Nationality ?? "",
                        totalReservations,
                        totalNights,
                        totalSpent,
                        lastVisit
                    );
                }

                // Sort by total spent (highest first)
                dataTable.DefaultView.Sort = "TotalSpent DESC";
                dataTable = dataTable.DefaultView.ToTable();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating guest report: {ex.Message}");
                // Return empty table with structure
            }

            return dataTable;
        }

        private DataTable GenerateRoomUtilizationData(DateTime fromDate, DateTime toDate, string roomTypeFilter)
        {
            var dataTable = new DataTable("RoomUtilizationReport");

            dataTable.Columns.Add("RoomType", typeof(string));
            dataTable.Columns.Add("TotalRooms", typeof(int));
            dataTable.Columns.Add("AvailableRooms", typeof(int));
            dataTable.Columns.Add("OccupiedRooms", typeof(int));
            dataTable.Columns.Add("OccupancyRate", typeof(string));
            dataTable.Columns.Add("Maintenance", typeof(int));
            dataTable.Columns.Add("Revenue", typeof(decimal));

            try
            {
                // Get all rooms
                var allRooms = _roomRepo.GetAllRooms();

                // Filter by room type if needed
                if (roomTypeFilter != "All Room Types")
                {
                    allRooms = allRooms.Where(r => r.RoomTypeName == roomTypeFilter).ToList();
                }

                // Group rooms by type
                var roomsByType = allRooms.GroupBy(r => r.RoomTypeName);

                foreach (var roomGroup in roomsByType)
                {
                    string roomType = roomGroup.Key;
                    int totalRooms = roomGroup.Count();

                    // Count by status
                    int availableRooms = roomGroup.Count(r => r.StatusName == "Available");
                    int occupiedRooms = roomGroup.Count(r => r.StatusName == "Occupied");
                    int maintenanceRooms = roomGroup.Count(r => r.StatusName == "Maintenance");

                    // Calculate occupancy rate
                    decimal occupancyRate = totalRooms > 0 ? (decimal)occupiedRooms / totalRooms * 100 : 0;

                    // Calculate revenue for this room type
                    decimal revenue = CalculateRevenueForRoomType(roomType, fromDate, toDate);

                    dataTable.Rows.Add(
                        roomType,
                        totalRooms,
                        availableRooms,
                        occupiedRooms,
                        $"{occupancyRate:F2}%",
                        maintenanceRooms,
                        revenue
                    );
                }

                // Sort by occupancy rate (highest first)
                dataTable.DefaultView.Sort = "OccupancyRate DESC";
                dataTable = dataTable.DefaultView.ToTable();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating room utilization report: {ex.Message}");
                // Return empty table with structure
            }

            return dataTable;
        }

        // ==================== PRIVATE HELPER METHODS ====================

        private int CalculateOccupiedRoomsForDate(DateTime date, string roomTypeFilter)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand("sp_CalculateOccupiedRoomsForDate", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_date", date);
                        cmd.Parameters.AddWithValue("@p_room_type_filter",
                            roomTypeFilter == "All Room Types" ? (object)DBNull.Value : roomTypeFilter);

                        var resultParam = new MySqlParameter("@p_occupied_rooms", MySqlDbType.Int32);
                        resultParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(resultParam);

                        cmd.ExecuteNonQuery();

                        return resultParam.Value != DBNull.Value ? Convert.ToInt32(resultParam.Value) : 0;
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private List<Reservation> GetFilteredReservations(DateTime fromDate, DateTime toDate,
            string roomTypeFilter, string guestTypeFilter)
        {
            var reservations = _reservationRepo.GetReservationsByDateRange(fromDate, toDate);

            if (reservations == null)
                return new List<Reservation>();

            if (roomTypeFilter != "All Room Types")
            {
                reservations = reservations.Where(r =>
                    r.Rooms != null && r.Rooms.Any(room => room.RoomTypeName == roomTypeFilter)).ToList();
            }

            return reservations;
        }

        private (string PaymentMethod, string PaymentDate, decimal AmountPaid) GetPaymentInfo(int reservationId)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand("sp_GetPaymentInfo", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_reservation_id", reservationId);

                        var paymentMethodParam = new MySqlParameter("@p_payment_method", MySqlDbType.VarChar, 50);
                        paymentMethodParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(paymentMethodParam);

                        var paymentDateParam = new MySqlParameter("@p_payment_date", MySqlDbType.DateTime);
                        paymentDateParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(paymentDateParam);

                        var amountParam = new MySqlParameter("@p_amount", MySqlDbType.Decimal);
                        amountParam.Precision = 10;
                        amountParam.Scale = 2;
                        amountParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(amountParam);

                        cmd.ExecuteNonQuery();

                        string paymentMethod = paymentMethodParam.Value != DBNull.Value ?
                            paymentMethodParam.Value.ToString() : "Not Paid";
                        string paymentDate = paymentDateParam.Value != DBNull.Value ?
                            Convert.ToDateTime(paymentDateParam.Value).ToString("yyyy-MM-dd") : "N/A";
                        decimal amount = amountParam.Value != DBNull.Value ?
                            Convert.ToDecimal(amountParam.Value) : 0;

                        return (paymentMethod, paymentDate, amount);
                    }
                }
            }
            catch (Exception)
            {
                // Return default values
                return ("Not Paid", "N/A", 0);
            }
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

            if (roomTypeFilter != "All Room Types")
            {
                if (reservation.Rooms == null || !reservation.Rooms.Any(r => r.RoomTypeName == roomTypeFilter))
                    return false;
            }

            return true;
        }

        private List<Reservation> GetReservationsForDate(DateTime fromDate, DateTime toDate,
            string roomTypeFilter, string guestTypeFilter)
        {
            try
            {
                return _reservationRepo.GetReservationsByDateRange(fromDate, toDate);
            }
            catch (Exception)
            {
                return new List<Reservation>();
            }
        }

        // NEW METHOD: Get reservations for a specific guest
        private List<Reservation> GetReservationsForGuest(int guestId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var allReservations = _reservationRepo.GetReservationsByDateRange(fromDate, toDate);
                return allReservations.Where(r => r.GuestId == guestId).ToList();
            }
            catch (Exception)
            {
                return new List<Reservation>();
            }
        }

        // NEW METHOD: Calculate revenue for a specific room type
        private decimal CalculateRevenueForRoomType(string roomType, DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand("sp_CalculateRevenueForRoomType", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_room_type", roomType);
                        cmd.Parameters.AddWithValue("@p_from_date", fromDate);
                        cmd.Parameters.AddWithValue("@p_to_date", toDate);

                        var resultParam = new MySqlParameter("@p_revenue", MySqlDbType.Decimal);
                        resultParam.Precision = 10;
                        resultParam.Scale = 2;
                        resultParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(resultParam);

                        cmd.ExecuteNonQuery();

                        return resultParam.Value != DBNull.Value ? Convert.ToDecimal(resultParam.Value) : 0;
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        // ==================== CHART CREATION METHODS ====================

        private void CreateOccupancyChart(Chart chart, DataTable data)
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
                    series.Points.AddXY(row["Date"].ToString(), rate);
                }
            }

            chart.Series.Add(series);
            chart.ChartAreas[0].AxisY.Title = "Occupancy Rate (%)";
            chart.ChartAreas[0].AxisX.Title = "Date";
            chart.Titles.Add($"Occupancy Rate Trend ({data.Rows.Count} days)");
            chart.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
        }

        private void CreateFinancialChart(Chart chart, DataTable data)
        {
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
                LabelFormat = "\"₱\"#,##0",
                LabelAngle = -90
            };

            foreach (var kvp in revenueByDate.OrderBy(x => x.Key))
            {
                series.Points.AddXY(kvp.Key, kvp.Value);
            }

            chart.Series.Add(series);
            chart.ChartAreas[0].AxisY.Title = "Revenue (₱)";
            chart.ChartAreas[0].AxisX.Title = "Date";
            chart.Titles.Add($"Revenue by Date (Total: ₱{revenueByDate.Values.Sum():N2})");
            chart.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
        }

        private void CreateDailySalesChart(Chart chart, DataTable data)
        {
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

        private void CreateGuestChart(Chart chart, DataTable data)
        {
            var guestsByType = new Dictionary<string, int>();

            foreach (DataRow row in data.Rows)
            {
                string guestType = row["GuestType"].ToString();
                if (guestsByType.ContainsKey(guestType))
                    guestsByType[guestType]++;
                else
                    guestsByType[guestType] = 1;
            }

            var series = new Series("Guest Distribution")
            {
                ChartType = SeriesChartType.Doughnut,
                IsValueShownAsLabel = true,
                LabelFormat = "#PERCENT{P1}",
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
            };

            foreach (var kvp in guestsByType)
            {
                series.Points.AddXY(kvp.Key, kvp.Value);
            }

            chart.Series.Add(series);
            chart.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart.Titles.Add($"Guest Distribution by Type");
            chart.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
        }

        private void CreateRoomUtilizationChart(Chart chart, DataTable data)
        {
            var series = new Series("Room Utilization")
            {
                ChartType = SeriesChartType.StackedColumn,
                IsValueShownAsLabel = true,
                LabelFormat = "#VALY{P1}",
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold)
            };

            foreach (DataRow row in data.Rows)
            {
                // FIXED: Use OccupancyRate column instead of Utilization
                string occupancyStr = row["OccupancyRate"].ToString().Replace("%", "");
                if (decimal.TryParse(occupancyStr, out decimal occupancyRate))
                {
                    series.Points.AddXY(row["RoomType"].ToString(), occupancyRate);
                }
            }

            chart.Series.Add(series);
            chart.ChartAreas[0].AxisY.Title = "Occupancy Rate (%)";
            chart.ChartAreas[0].AxisX.Title = "Room Type";
            chart.Titles.Add($"Room Type Occupancy Rates");
            chart.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
        }

        // ==================== UTILITY CALCULATION METHODS ====================

        private decimal CalculateSumFromColumn(DataTable data, string columnName)
        {
            try
            {
                return data.AsEnumerable()
                    .Sum(row => Convert.ToDecimal(row[columnName]));
            }
            catch
            {
                return 0;
            }
        }

        private List<string> RetrieveRoomTypesFromDatabase()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand("sp_GetRoomTypesForReports", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        var roomTypes = new List<string> { "All Room Types" };

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
            }
            catch (Exception)
            {
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

        private List<string> RetrieveGuestTypesFromDatabase()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand("sp_GetGuestTypesForReports", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        var guestTypes = new List<string> { "All Guest Types" };

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
            }
            catch (Exception)
            {
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

        private decimal RetrieveTotalRevenue(DateTime startDate, DateTime endDate)
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

        private void ExportDataGridViewToCSV(DataGridView dataGridView, string reportName)
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

                    // Headers
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        csvContent.Append(dataGridView.Columns[i].HeaderText);
                        if (i < dataGridView.Columns.Count - 1)
                            csvContent.Append(",");
                    }
                    csvContent.AppendLine();

                    // Data
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            for (int i = 0; i < dataGridView.Columns.Count; i++)
                            {
                                string cellValue = row.Cells[i].Value?.ToString() ?? "";
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

        private void PrintDataGridView(DataGridView dataGridView, string reportTitle, DateTime fromDate, DateTime toDate)
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                PrintDocument printDocument = new PrintDocument();

                printDocument.PrintPage += (sender, e) =>
                {
                    string header = $"Hotel Management System\n";
                    header += $"{reportTitle}\n";
                    header += $"Date Range: {fromDate:yyyy-MM-dd} to {toDate:yyyy-MM-dd}\n";
                    header += $"Generated: {DateTime.Now:yyyy-MM-dd HH:mm}\n";
                    header += new string('-', 80) + "\n\n";

                    string columnHeaders = "";
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        columnHeaders += dataGridView.Columns[i].HeaderText.PadRight(20);
                    }
                    columnHeaders += "\n" + new string('-', 80) + "\n";

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

                    string content = header + columnHeaders + string.Join("\n", rows);

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
    }
}