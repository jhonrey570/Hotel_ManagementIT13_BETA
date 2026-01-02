using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data;

namespace Hotel_ManagementIT13.Data.Managers
{
    public class ReportManager
    {
        private readonly ReservationRepository _reservationRepo;
        private readonly RoomRepository _roomRepo;
        private readonly BillingRepository _billingRepo;
        private readonly PaymentRepository _paymentRepo; // Added PaymentRepository

        public ReportManager()
        {
            _reservationRepo = new ReservationRepository();
            _roomRepo = new RoomRepository();
            _billingRepo = new BillingRepository();
            _paymentRepo = new PaymentRepository(); // Initialize PaymentRepository
        }

        public OccupancyReport GenerateOccupancyReport(DateTime startDate, DateTime endDate)
        {
            var report = new OccupancyReport
            {
                StartDate = startDate,
                EndDate = endDate,
                GeneratedDate = DateTime.Now
            };

            try
            {
                // Get all reservations in date range
                var reservations = _reservationRepo.GetReservationsByDateRange(startDate, endDate);

                // Get all rooms
                var allRooms = _roomRepo.GetAllRooms();
                report.TotalRooms = allRooms.Count;

                // Calculate daily occupancy
                for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    int occupiedRooms = 0;
                    int reservedRooms = 0;

                    foreach (var reservation in reservations)
                    {
                        if (date >= reservation.CheckInDate && date <= reservation.CheckOutDate)
                        {
                            if (reservation.StatusId == 3) // Checked-in
                                occupiedRooms += reservation.Rooms.Count;
                            else if (reservation.StatusId == 1 || reservation.StatusId == 2) // Confirmed or Pending
                                reservedRooms += reservation.Rooms.Count;
                        }
                    }

                    report.DailyOccupancy.Add(new DailyOccupancy
                    {
                        Date = date,
                        OccupiedRooms = occupiedRooms,
                        ReservedRooms = reservedRooms,
                        OccupancyRate = report.TotalRooms > 0 ?
                            (decimal)occupiedRooms / report.TotalRooms * 100 : 0
                    });
                }

                // Calculate totals
                report.TotalOccupiedNights = 0;
                report.AverageOccupancyRate = 0;

                foreach (var daily in report.DailyOccupancy)
                {
                    report.TotalOccupiedNights += daily.OccupiedRooms;
                    report.AverageOccupancyRate += daily.OccupancyRate;
                }

                if (report.DailyOccupancy.Count > 0)
                {
                    report.AverageOccupancyRate /= report.DailyOccupancy.Count;
                }

                report.Success = true;
            }
            catch (Exception ex)
            {
                report.Success = false;
                report.ErrorMessage = ex.Message;
            }

            return report;
        }

        public FinancialReport GenerateFinancialReport(DateTime startDate, DateTime endDate)
        {
            var report = new FinancialReport
            {
                StartDate = startDate,
                EndDate = endDate,
                GeneratedDate = DateTime.Now
            };

            try
            {
                // FIXED: Get total revenue from PaymentRepository instead of BillingRepository
                report.TotalRevenue = _paymentRepo.GetTotalRevenue(startDate, endDate);

                // Get reservations in period
                var reservations = _reservationRepo.GetReservationsByDateRange(startDate, endDate);

                // Calculate by room type
                var roomTypeRevenue = new Dictionary<string, decimal>();
                var roomTypeCount = new Dictionary<string, int>();

                foreach (var reservation in reservations)
                {
                    foreach (var room in reservation.Rooms)
                    {
                        string roomType = room.RoomTypeName;

                        if (!roomTypeRevenue.ContainsKey(roomType))
                        {
                            roomTypeRevenue[roomType] = 0;
                            roomTypeCount[roomType] = 0;
                        }

                        // Calculate revenue based on room rate and nights stayed
                        // Note: This is estimated revenue, actual revenue should come from payments
                        int nights = (reservation.CheckOutDate - reservation.CheckInDate).Days;
                        roomTypeRevenue[roomType] += room.RoomRate * nights;
                        roomTypeCount[roomType]++;
                    }
                }

                report.RoomTypeBreakdown = roomTypeRevenue;
                report.RoomTypeCount = roomTypeCount;

                // Calculate average daily rate
                int totalRoomNights = 0;
                foreach (var count in roomTypeCount.Values)
                {
                    totalRoomNights += count;
                }

                report.AverageDailyRate = totalRoomNights > 0 ?
                    report.TotalRevenue / totalRoomNights : 0;

                report.Success = true;
            }
            catch (Exception ex)
            {
                report.Success = false;
                report.ErrorMessage = ex.Message;
            }

            return report;
        }

        public GuestReport GenerateGuestReport(DateTime startDate, DateTime endDate)
        {
            var report = new GuestReport
            {
                StartDate = startDate,
                EndDate = endDate,
                GeneratedDate = DateTime.Now
            };

            try
            {
                // Get reservations in period
                var reservations = _reservationRepo.GetReservationsByDateRange(startDate, endDate);

                // Count guests by type
                var guestTypeCount = new Dictionary<string, int>();
                var nationalityCount = new Dictionary<string, int>();

                foreach (var reservation in reservations)
                {
                    // Note: This is simplified - you'll need to get actual guest type from database
                    // Assuming guest type is stored in reservation or guest object
                    string guestType = "Regular"; // Default
                    string nationality = "Unknown"; // Default

                    // If you have access to guest object through reservation:
                    // string guestType = reservation.Guest.GuestType;
                    // string nationality = reservation.Guest.Nationality;

                    if (!guestTypeCount.ContainsKey(guestType))
                        guestTypeCount[guestType] = 0;
                    guestTypeCount[guestType]++;

                    if (!nationalityCount.ContainsKey(nationality))
                        nationalityCount[nationality] = 0;
                    nationalityCount[nationality]++;
                }

                report.GuestTypeDistribution = guestTypeCount;
                report.NationalityDistribution = nationalityCount;
                report.TotalGuests = reservations.Count;

                report.Success = true;
            }
            catch (Exception ex)
            {
                report.Success = false;
                report.ErrorMessage = ex.Message;
            }

            return report;
        }

        // Additional method to get payment summary
        public PaymentSummaryReport GeneratePaymentSummaryReport(DateTime startDate, DateTime endDate)
        {
            var report = new PaymentSummaryReport
            {
                StartDate = startDate,
                EndDate = endDate,
                GeneratedDate = DateTime.Now
            };

            try
            {
                // Get payments in date range
                var payments = _paymentRepo.GetPaymentsByDateRange(startDate, endDate);

                // Summarize by payment method
                var paymentMethodSummary = new Dictionary<string, decimal>();
                var statusSummary = new Dictionary<string, int>();

                foreach (var payment in payments)
                {
                    // Sum by payment method
                    if (!paymentMethodSummary.ContainsKey(payment.PaymentMethod))
                        paymentMethodSummary[payment.PaymentMethod] = 0;
                    paymentMethodSummary[payment.PaymentMethod] += payment.Amount;

                    // Count by status
                    if (!statusSummary.ContainsKey(payment.StatusName))
                        statusSummary[payment.StatusName] = 0;
                    statusSummary[payment.StatusName]++;
                }

                report.PaymentMethodBreakdown = paymentMethodSummary;
                report.PaymentStatusSummary = statusSummary;
                report.TotalPayments = payments.Count;
                report.Success = true;
            }
            catch (Exception ex)
            {
                report.Success = false;
                report.ErrorMessage = ex.Message;
            }

            return report;
        }
    }

    public class OccupancyReport
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime GeneratedDate { get; set; }
        public int TotalRooms { get; set; }
        public int TotalOccupiedNights { get; set; }
        public decimal AverageOccupancyRate { get; set; }
        public List<DailyOccupancy> DailyOccupancy { get; set; } = new List<DailyOccupancy>();
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class DailyOccupancy
    {
        public DateTime Date { get; set; }
        public int OccupiedRooms { get; set; }
        public int ReservedRooms { get; set; }
        public decimal OccupancyRate { get; set; }
    }

    public class FinancialReport
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime GeneratedDate { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal AverageDailyRate { get; set; }
        public Dictionary<string, decimal> RoomTypeBreakdown { get; set; } = new Dictionary<string, decimal>();
        public Dictionary<string, int> RoomTypeCount { get; set; } = new Dictionary<string, int>();
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class GuestReport
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime GeneratedDate { get; set; }
        public int TotalGuests { get; set; }
        public Dictionary<string, int> GuestTypeDistribution { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> NationalityDistribution { get; set; } = new Dictionary<string, int>();
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }

    // New class for payment summary report
    public class PaymentSummaryReport
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime GeneratedDate { get; set; }
        public int TotalPayments { get; set; }
        public Dictionary<string, decimal> PaymentMethodBreakdown { get; set; } = new Dictionary<string, decimal>();
        public Dictionary<string, int> PaymentStatusSummary { get; set; } = new Dictionary<string, int>();
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}