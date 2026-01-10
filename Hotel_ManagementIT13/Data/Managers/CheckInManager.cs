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
        private readonly PaymentRepository _paymentRepo;

        public CheckInManager()
        {
            _reservationRepo = new ReservationRepository();
            _roomRepo = new RoomRepository();
            _billingRepo = new BillingRepository();
            _guestRepo = new GuestRepository();
            _paymentRepo = new PaymentRepository();
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
                if (reservation.StatusId == 3) // Checked-in (reservation_statuses)
                {
                    result.Success = false;
                    result.Message = "Guest already checked in";
                    return result;
                }

                // Update reservation status to Checked-in (reservation_statuses.status_id = 3)
                _reservationRepo.UpdateReservationStatus(reservation.ReservationId, 3);

                // Update room status to Occupied (room_statuses.status_id = 2)
                foreach (var room in reservation.Rooms)
                {
                    _roomRepo.UpdateRoomStatus(room.RoomId, 2); // Occupied
                }

                // Record check-in in check_in_out table (check_in_statuses.status_id = 1)
                _reservationRepo.RecordCheckIn(reservation.ReservationId, processedByUserId, 1); // Status: Checked-in

                // Process deposit payment if any
                if (depositAmount > 0)
                {
                    _paymentRepo.ProcessPayment(reservation.ReservationId, depositAmount,
                                              paymentMethod, "Deposit payment at check-in");
                }

                result.Success = true;
                result.Message = $"Check-in processed successfully for {reservation.GuestName}";
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
                                                int processedByUserId, decimal depositAmount,
                                                decimal paymentAmount, string paymentMethod = "Cash")
        {
            var result = new CheckInResult();

            try
            {
                // Check room availability
                var room = _roomRepo.GetRoomById(roomId);
                if (room == null || room.StatusId != 1) // Not Available (room_statuses.status_id = 1)
                {
                    result.Success = false;
                    result.Message = $"Room is not available";
                    return result;
                }

                // Create guest if not exists
                int guestId;
                if (guest.GuestId == 0)
                {
                    // Set default values for walk-in guest
                    if (string.IsNullOrEmpty(guest.Phone)) guest.Phone = "000-000-0000";
                    if (string.IsNullOrEmpty(guest.Email)) guest.Email = "walkin@hotel.com";
                    guestId = _guestRepo.AddGuest(guest);
                }
                else
                {
                    guestId = guest.GuestId;
                }

                // Create instant reservation
                var reservationManager = new ReservationManager();
                string reservationResult = reservationManager.CreateReservation(
                    guestId, processedByUserId, checkIn, checkOut,
                    new List<int> { roomId }, adults, children);

                // Extract booking reference from result
                string bookingRef = "";
                if (reservationResult.Contains("Booking Reference:"))
                {
                    int startIndex = reservationResult.IndexOf("Booking Reference:") + "Booking Reference:".Length;
                    bookingRef = reservationResult.Substring(startIndex).Trim();
                }
                else if (reservationResult.Contains("RES")) // Check if result is the booking reference itself
                {
                    bookingRef = reservationResult;
                }

                if (!string.IsNullOrEmpty(bookingRef))
                {
                    // Process deposit payment if any
                    if (depositAmount > 0)
                    {
                        // Get the newly created reservation
                        var reservation = _reservationRepo.GetReservationByReference(bookingRef);
                        if (reservation != null)
                        {
                            _paymentRepo.ProcessPayment(reservation.ReservationId, depositAmount,
                                                      paymentMethod, "Walk-in deposit payment at check-in");
                        }
                    }

                    // Process additional payment if any
                    if (paymentAmount > 0)
                    {
                        var reservation = _reservationRepo.GetReservationByReference(bookingRef);
                        if (reservation != null)
                        {
                            _paymentRepo.ProcessPayment(reservation.ReservationId, paymentAmount,
                                                      paymentMethod, "Walk-in payment at check-in");
                        }
                    }

                    // Process immediate check-in
                    return ProcessCheckIn(bookingRef, processedByUserId, 0, paymentMethod); // Deposit already processed above
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
                _reservationRepo.UpdateReservationStatus(reservation.ReservationId, 3);

                // Record check-in
                _reservationRepo.RecordCheckIn(reservation.ReservationId, processedByUserId, 1);

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
    }

    public class CheckInResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Reservation Reservation { get; set; }
    }
}