using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
using System;
using System.Collections.Generic;

namespace Hotel_ManagementIT13.Data.Managers
{
    public class CheckInManager
    {
        private readonly ReservationRepository _reservationRepo;
        private readonly RoomRepository _roomRepo;
        private readonly BillingRepository _billingRepo;
        private readonly GuestRepository _guestRepo;
        private readonly PaymentRepository _paymentRepo; // Added PaymentRepository

        public CheckInManager()
        {
            _reservationRepo = new ReservationRepository();
            _roomRepo = new RoomRepository();
            _billingRepo = new BillingRepository();
            _guestRepo = new GuestRepository();
            _paymentRepo = new PaymentRepository(); // Initialize PaymentRepository
        }

        public CheckInResult ProcessCheckIn(string bookingReference, int processedByUserId,
                                          decimal depositAmount = 0, string paymentMethod = "Cash")
        {
            var result = new CheckInResult();

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

                // Check if already checked in
                if (reservation.StatusId == 3) // Checked-in
                {
                    result.Success = false;
                    result.Message = "Guest already checked in";
                    return result;
                }

                // Update reservation status to Checked-in
                UpdateReservationStatus(reservation.ReservationId, 3);

                // Update room status to Occupied
                foreach (var room in reservation.Rooms)
                {
                    _roomRepo.UpdateRoomStatus(room.RoomId, 2); // Occupied
                }

                // Record check-in
                RecordCheckIn(reservation.ReservationId, processedByUserId, 1); // Status: Checked-in

                // Process deposit payment if any
                if (depositAmount > 0)
                {
                    // FIXED: Use PaymentRepository instead of BillingRepository
                    _paymentRepo.ProcessPayment(reservation.ReservationId, depositAmount,
                                              paymentMethod, "Deposit payment");
                }

                result.Success = true;
                result.Message = "Check-in processed successfully";
                result.Reservation = reservation;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error during check-in: {ex.Message}";
            }

            return result;
        }

        public CheckInResult ProcessWalkInCheckIn(Guest guest, DateTime checkIn, DateTime checkOut,
                                                int roomId, int adults, int children,
                                                int processedByUserId, decimal paymentAmount)
        {
            var result = new CheckInResult();

            try
            {
                // Check room availability
                var room = _roomRepo.GetRoomById(roomId);
                if (room == null || room.StatusId != 1) // Not Available
                {
                    result.Success = false;
                    result.Message = $"Room is not available";
                    return result;
                }

                // Create guest if not exists
                int guestId;
                if (guest.GuestId == 0)
                {
                    guestId = _guestRepo.AddGuest(guest);
                }
                else
                {
                    guestId = guest.GuestId;
                }

                // Create instant reservation
                var reservationManager = new ReservationManager();
                var reservationResult = reservationManager.CreateReservation(
                    guestId, processedByUserId, checkIn, checkOut,
                    new List<int> { roomId }, adults, children);

                // Get the reservation
                string bookingRef = "";
                if (reservationResult.StartsWith("Reservation created successfully!"))
                {
                    // Assuming format: "Reservation created successfully! Booking Reference: RES123"
                    int startIndex = reservationResult.IndexOf("Booking Reference: ") + "Booking Reference: ".Length;
                    bookingRef = reservationResult.Substring(startIndex).Trim();
                }

                var reservation = _reservationRepo.GetReservationByReference(bookingRef);

                if (reservation != null)
                {
                    // Process immediate check-in
                    return ProcessCheckIn(reservation.BookingReference, processedByUserId,
                                         paymentAmount, "Cash");
                }

                result.Success = false;
                result.Message = "Failed to create walk-in reservation";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error during walk-in check-in: {ex.Message}";
            }

            return result;
        }

        public CheckInResult ProcessGroupCheckIn(string bookingReference, List<int> roomIds,
                                               int processedByUserId, decimal depositAmount = 0)
        {
            var result = new CheckInResult();

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

                // Verify all rooms are part of the reservation
                foreach (int roomId in roomIds)
                {
                    bool roomFound = false;
                    foreach (var room in reservation.Rooms)
                    {
                        if (room.RoomId == roomId)
                        {
                            roomFound = true;
                            break;
                        }
                    }

                    if (!roomFound)
                    {
                        result.Success = false;
                        result.Message = $"Room {roomId} is not part of this reservation";
                        return result;
                    }
                }

                // Update each room status to Occupied
                foreach (int roomId in roomIds)
                {
                    _roomRepo.UpdateRoomStatus(roomId, 2); // Occupied
                }

                // Update reservation status to Checked-in
                UpdateReservationStatus(reservation.ReservationId, 3);

                // Record check-in
                RecordCheckIn(reservation.ReservationId, processedByUserId, 1);

                // Process deposit payment if any
                if (depositAmount > 0)
                {
                    _paymentRepo.ProcessPayment(reservation.ReservationId, depositAmount,
                                              "Cash", "Group check-in deposit");
                }

                result.Success = true;
                result.Message = $"Group check-in processed successfully for {roomIds.Count} rooms";
                result.Reservation = reservation;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error during group check-in: {ex.Message}";
            }

            return result;
        }

        private bool UpdateReservationStatus(int reservationId, int statusId)
        {
            // Implementation to update reservation status
            // This should call a repository method
            // For now, return true for compilation
            return true;
        }

        private bool RecordCheckIn(int reservationId, int processedBy, int statusId)
        {
            // Implementation to record check-in
            // This should call a repository method
            // For now, return true for compilation
            return true;
        }
    }

    public class CheckInResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Reservation Reservation { get; set; }
    }
}