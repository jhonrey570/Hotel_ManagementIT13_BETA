using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
using System;

namespace Hotel_ManagementIT13.Data.Managers
{
    public class CheckOutManager
    {
        private readonly ReservationRepository _reservationRepo;
        private readonly RoomRepository _roomRepo;
        private readonly BillingRepository _billingRepo;
        private readonly PaymentRepository _paymentRepo;

        public CheckOutManager()
        {
            _reservationRepo = new ReservationRepository();
            _roomRepo = new RoomRepository();
            _billingRepo = new BillingRepository();
            _paymentRepo = new PaymentRepository();
        }

        public CheckOutResult ProcessCheckOut(string bookingReference, int processedByUserId,
                                            DateTime actualCheckOut, decimal paymentAmount,
                                            string paymentMethod = "Cash", string notes = "")
        {
            var result = new CheckOutResult();

            try
            {
                // Get reservation
                var reservation = _reservationRepo.GetReservationByReference(bookingReference);
                if (reservation == null)
                {
                    result.Success = false;
                    result.Message = "Reservation not found";
                    return result;
                }

                // Check if already checked out
                if (reservation.StatusId == 4) // Checked-out (reservation_statuses)
                {
                    result.Success = false;
                    result.Message = "Guest already checked out";
                    return result;
                }

                // Calculate late checkout fee if applicable
                decimal lateFee = CalculateLateCheckoutFee(reservation, actualCheckOut);
                if (lateFee > 0)
                {
                    // Add late fee to billing
                    var billing = _billingRepo.GetBillingByReservationId(reservation.ReservationId);
                    if (billing != null)
                    {
                        _billingRepo.AddBillingItem(billing.BillingId,
                            "Late Checkout Fee", lateFee);
                    }
                }

                // Get updated billing information
                var updatedBilling = _billingRepo.GetBillingByReservationId(reservation.ReservationId);
                if (updatedBilling == null)
                {
                    result.Success = false;
                    result.Message = "Billing information not found";
                    return result;
                }

                // Process final payment
                if (paymentAmount > 0)
                {
                    _paymentRepo.ProcessPayment(reservation.ReservationId, paymentAmount,
                                              paymentMethod, notes);

                    // Get final billing after payment
                    updatedBilling = _billingRepo.GetBillingByReservationId(reservation.ReservationId);
                }

                // Update reservation status to Checked-out (reservation_statuses.status_id = 4)
                _reservationRepo.UpdateReservationStatus(reservation.ReservationId, 4);

                // Update room status to Cleaning in Progress (room_statuses.status_id = 6)
                foreach (var room in reservation.Rooms)
                {
                    _roomRepo.UpdateRoomStatus(room.RoomId, 6); // Cleaning in Progress
                }

                // Record check-out in check_in_out table (check_in_statuses.status_id = 2)
                _reservationRepo.RecordCheckOut(reservation.ReservationId, processedByUserId, 2, actualCheckOut);

                result.Success = true;
                result.Message = "Check-out processed successfully";
                result.Reservation = reservation;
                result.Billing = updatedBilling;
                result.LateFee = lateFee;
                result.ReceiptNumber = GenerateReceiptNumber();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error during check-out: {ex.Message}";
            }

            return result;
        }

        private decimal CalculateLateCheckoutFee(Reservation reservation, DateTime actualCheckOut)
        {
            DateTime standardCheckOut = reservation.CheckOutDate.Date.AddHours(12); // Assuming 12:00 PM checkout

            if (actualCheckOut <= standardCheckOut)
                return 0;

            TimeSpan lateDuration = actualCheckOut - standardCheckOut;
            int lateHours = (int)Math.Ceiling(lateDuration.TotalHours);

            // Fee structure: $50 for first hour, $25 for each additional hour
            if (lateHours <= 1)
                return 50;
            else
                return 50 + ((lateHours - 1) * 25);
        }

        private string GenerateReceiptNumber()
        {
            return "RCPT" + DateTime.Now.ToString("yyMMddHHmmss") + new Random().Next(100, 999);
        }
    }

    public class CheckOutResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Reservation Reservation { get; set; }
        public Billing Billing { get; set; }
        public decimal LateFee { get; set; }
        public string ReceiptNumber { get; set; }
    }
}