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

        public CheckOutManager()
        {
            _reservationRepo = new ReservationRepository();

            //I HAVE AN ISSUE IN HERE RoomRepo(); NOT RECOGNIZED
            _roomRepo = new RoomRepository();
            _billingRepo = new BillingRepository();
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
                if (reservation.StatusId == 4) // Checked-out
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
                    _billingRepo.ProcessPayment(reservation.ReservationId, paymentAmount,
                                              paymentMethod, notes);

                    // Get final billing after payment
                    updatedBilling = _billingRepo.GetBillingByReservationId(reservation.ReservationId);
                }

                // Update reservation status to Checked-out
                UpdateReservationStatus(reservation.ReservationId, 4);

                // Update room status to Cleaning in Progress
                foreach (var room in reservation.Rooms)
                {
                    _roomRepo.UpdateRoomStatus(room.RoomId, 6); // Cleaning in Progress
                }

                // Record check-out
                RecordCheckOut(reservation.ReservationId, processedByUserId, actualCheckOut, 2); // Status: Checked-out

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

        public EarlyCheckOutResult ProcessEarlyCheckOut(string bookingReference,
                                                       int processedByUserId,
                                                       DateTime newCheckOut)
        {
            var result = new EarlyCheckOutResult();

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

                // Validate new check-out date
                if (newCheckOut <= reservation.CheckInDate)
                {
                    result.Success = false;
                    result.Message = "New check-out date must be after check-in date";
                    return result;
                }

                if (newCheckOut > reservation.CheckOutDate)
                {
                    result.Success = false;
                    result.Message = "New check-out date cannot be after original check-out date";
                    return result;
                }

                // Calculate refund if applicable
                int originalNights = (reservation.CheckOutDate - reservation.CheckInDate).Days;
                int newNights = (newCheckOut - reservation.CheckInDate).Days;
                int nightsDifference = originalNights - newNights;

                decimal refundAmount = 0;
                if (nightsDifference > 0)
                {
                    // Calculate refund based on nightly rate
                    decimal nightlyRate = reservation.TotalAmount / originalNights;
                    refundAmount = nightlyRate * nightsDifference * 0.5m; // 50% refund for early checkout

                    // Add refund as negative billing item
                    var billing = _billingRepo.GetBillingByReservationId(reservation.ReservationId);
                    if (billing != null)
                    {
                        _billingRepo.AddBillingItem(billing.BillingId,
                            "Early Checkout Refund", -refundAmount);
                    }
                }

                // Update reservation check-out date
                UpdateReservationCheckOut(reservation.ReservationId, newCheckOut);

                result.Success = true;
                result.Message = $"Early check-out processed. Refund amount: {refundAmount:C}";
                result.RefundAmount = refundAmount;
                result.NewCheckOutDate = newCheckOut;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error during early check-out: {ex.Message}";
            }

            return result;
        }

        private decimal CalculateLateCheckoutFee(Reservation reservation, DateTime actualCheckOut)
        {
            DateTime standardCheckOut = reservation.CheckOutDate.AddHours(12); // Assuming 12:00 PM checkout

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

        private bool UpdateReservationStatus(int reservationId, int statusId)
        {
            // Implementation to update reservation status
            return true;
        }

        private bool UpdateReservationCheckOut(int reservationId, DateTime newCheckOut)
        {
            // Implementation to update check-out date
            return true;
        }

        private bool RecordCheckOut(int reservationId, int processedBy,
                                  DateTime checkOutTime, int statusId)
        {
            // Implementation to record check-out
            return true;
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

    public class EarlyCheckOutResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public decimal RefundAmount { get; set; }
        public DateTime NewCheckOutDate { get; set; }
    }
}