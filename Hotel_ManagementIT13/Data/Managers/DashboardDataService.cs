using Hotel_ManagementIT13.Data.Managers;
using Hotel_ManagementIT13.Data.Repositories;
using System;
using System.Linq;

namespace Hotel_ManagementIT13.Forms.Services
{
    public class DashboardDataService
    {
        private readonly ReservationManager _reservationManager;
        private readonly RoomRepository _roomRepo;
        private readonly PaymentRepository _paymentRepo;
        private readonly RoomManager _roomManager;
        private readonly ReportManager _reportManager;

        public DashboardDataService()
        {
            _reservationManager = new ReservationManager();
            _roomRepo = new RoomRepository();
            _paymentRepo = new PaymentRepository();
            _roomManager = new RoomManager();
            _reportManager = new ReportManager();
        }

        public DashboardData LoadDashboardData()
        {
            var data = new DashboardData();
            DateTime today = DateTime.Today;

            try
            {
                data.TodaysArrivals = LoadTodaysArrivals(today);
                data.TodaysDepartures = LoadTodaysDepartures(today);
                data.RoomStatistics = LoadRoomStatistics();
                data.TodaysRevenue = LoadRevenueData(today);
                data.OccupancyData = LoadOccupancyData(today);
                data.RevenueChartData = LoadRevenueChartData(today);
            }
            catch (Exception ex)
            {
                data.ErrorMessage = $"Error loading dashboard: {ex.Message}";
            }

            return data;
        }

        private string[] LoadTodaysArrivals(DateTime today)
        {
            // In real app, get actual arrivals from reservation manager
            return new[]
            {
                "John Smith,Room 101,Standard,Confirmed",
                "Maria Garcia,Room 205,Deluxe,Confirmed",
                "Robert Johnson,Room 312,Suite,Pending"
            };
        }

        private string[] LoadTodaysDepartures(DateTime today)
        {
            // In real app, get actual departures from reservation manager
            return new[]
            {
                "Sarah Wilson,Room 102,Standard,Paid",
                "David Brown,Room 208,Deluxe,Paid",
                "Lisa Miller,Room 310,Suite,Unpaid"
            };
        }

        private RoomStatistics LoadRoomStatistics()
        {
            var stats = new RoomStatistics();

            try
            {
                var occupancyReport = _reportManager.GenerateOccupancyReport(DateTime.Today, DateTime.Today);

                if (occupancyReport.Success && occupancyReport.DailyOccupancy.Count > 0)
                {
                    stats.OccupiedRooms = occupancyReport.DailyOccupancy[0].OccupiedRooms;
                    stats.ReservedRooms = occupancyReport.DailyOccupancy[0].ReservedRooms;
                    stats.TotalRooms = occupancyReport.TotalRooms;
                    stats.AvailableRooms = stats.TotalRooms - stats.OccupiedRooms - stats.ReservedRooms;
                    stats.OccupancyRate = occupancyReport.DailyOccupancy[0].OccupancyRate;
                }
                else
                {
                    // Fallback
                    var rooms = _roomManager.GetAllRooms();
                    if (rooms != null && rooms.Count > 0)
                    {
                        stats.AvailableRooms = rooms.Count(r => r.StatusId == RoomManager.STATUS_AVAILABLE);
                        stats.OccupiedRooms = rooms.Count(r => r.StatusId == RoomManager.STATUS_OCCUPIED);
                        stats.ReservedRooms = rooms.Count(r => r.StatusId == RoomManager.STATUS_RESERVED);
                        stats.TotalRooms = rooms.Count;
                        stats.OccupancyRate = stats.TotalRooms > 0 ?
                            (decimal)stats.OccupiedRooms / stats.TotalRooms * 100 : 0;
                    }
                }
            }
            catch (Exception)
            {
                stats.AvailableRooms = 0;
                stats.OccupiedRooms = 0;
                stats.ReservedRooms = 0;
                stats.TotalRooms = 0;
                stats.OccupancyRate = 0;
            }

            return stats;
        }

        private decimal LoadRevenueData(DateTime today)
        {
            try
            {
                return _paymentRepo.GetTotalRevenue(today, today);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private OccupancyData LoadOccupancyData(DateTime today)
        {
            var occupancyReport = _reportManager.GenerateOccupancyReport(today, today);
            return new OccupancyData
            {
                Occupied = occupancyReport.DailyOccupancy[0]?.OccupiedRooms ?? 0,
                Reserved = occupancyReport.DailyOccupancy[0]?.ReservedRooms ?? 0,
                Available = occupancyReport.TotalRooms - (occupancyReport.DailyOccupancy[0]?.OccupiedRooms ?? 0) -
                          (occupancyReport.DailyOccupancy[0]?.ReservedRooms ?? 0),
                Total = occupancyReport.TotalRooms
            };
        }

        private RevenueChartData LoadRevenueChartData(DateTime today)
        {
            var data = new RevenueChartData();

            for (int i = 6; i >= 0; i--)
            {
                DateTime date = today.AddDays(-i);
                string dayName = date.ToString("ddd");
                decimal dayRevenue = _paymentRepo.GetTotalRevenue(date, date);
                data.Days.Add(dayName);
                data.Revenues.Add(dayRevenue);
            }

            return data;
        }
    }

    public class DashboardData
    {
        public string[] TodaysArrivals { get; set; }
        public string[] TodaysDepartures { get; set; }
        public RoomStatistics RoomStatistics { get; set; }
        public decimal TodaysRevenue { get; set; }
        public OccupancyData OccupancyData { get; set; }
        public RevenueChartData RevenueChartData { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class RoomStatistics
    {
        public int AvailableRooms { get; set; }
        public int OccupiedRooms { get; set; }
        public int ReservedRooms { get; set; }
        public int TotalRooms { get; set; }
        public decimal OccupancyRate { get; set; }
    }

    public class OccupancyData
    {
        public int Available { get; set; }
        public int Occupied { get; set; }
        public int Reserved { get; set; }
        public int Total { get; set; }
    }

    public class RevenueChartData
    {
        public RevenueChartData()
        {
            Days = new System.Collections.Generic.List<string>();
            Revenues = new System.Collections.Generic.List<decimal>();
        }

        public System.Collections.Generic.List<string> Days { get; set; }
        public System.Collections.Generic.List<decimal> Revenues { get; set; }
    }
}