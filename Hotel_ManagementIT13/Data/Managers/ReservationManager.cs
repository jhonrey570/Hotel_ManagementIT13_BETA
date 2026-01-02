using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
using System;
using System.Collections.Generic;

namespace Hotel_ManagementIT13.Data.Managers
{
    public class ReservationManager
    {
        private readonly ReservationRepository _reservationRepo;
        private readonly RoomRepository _roomRepo;
        private readonly GuestRepository _guestRepo;

        public ReservationManager()
        {
            _reservationRepo = new ReservationRepository();
            _roomRepo = new RoomRepository();
            _guestRepo = new GuestRepository();
        }

        public decimal CalculateReservationAmount(DateTime checkIn, DateTime checkOut,
                                                List<int> roomIds, int guestTypeId = 1)
        {
            decimal totalAmount = 0;
            int nights = (checkOut - checkIn).Days;

            foreach (int roomId in roomIds)
            {
                var room = _roomRepo.GetRoomById(roomId);
                if (room != null)
                {
                    decimal roomRate = GetRoomRate(room.RoomTypeId, guestTypeId);
                    totalAmount += roomRate * nights;
                }
            }

            return totalAmount;
        }

        public string CreateReservation(int guestId, int userId, DateTime checkIn, DateTime checkOut,
                                       List<int> roomIds, int adults, int children,
                                       string specialRequests = "", int? companyId = null)
        {
            try
            {
                // Check room availability
                foreach (int roomId in roomIds)
                {
                    var room = _roomRepo.GetRoomById(roomId);
                    if (room == null || room.StatusId != 1) // Not Available
                    {
                        return $"Room {room?.RoomNumber} is not available";
                    }
                }

                // Get guest type
                var guest = _guestRepo.GetGuestById(guestId);

                // Calculate total amount
                decimal totalAmount = CalculateReservationAmount(checkIn, checkOut, roomIds, guest?.GuestTypeId ?? 1);

                // Create reservation object
                var reservation = new Reservation
                {
                    GuestId = guestId,
                    UserId = userId,
                    CompanyId = companyId,
                    StatusId = 1, // Confirmed
                    ReservationTypeId = companyId.HasValue ? 2 : 1, // Corporate or Standard
                    BookingReference = _reservationRepo.GenerateBookingReference(),
                    CheckInDate = checkIn,
                    CheckOutDate = checkOut,
                    Adults = adults,
                    Children = children,
                    SpecialRequests = specialRequests,
                    TotalAmount = totalAmount,
                    CreatedAt = DateTime.Now
                };

                // Add rooms to reservation
                foreach (int roomId in roomIds)
                {
                    var room = _roomRepo.GetRoomById(roomId);
                    reservation.Rooms.Add(new ReservationRoom
                    {
                        RoomId = roomId,
                        RoomNumber = room.RoomNumber,
                        RoomTypeName = room.RoomTypeName,
                        RoomRate = GetRoomRate(room.RoomTypeId, guest?.GuestTypeId ?? 1)
                    });
                }

                // Save reservation
                int reservationId = _reservationRepo.CreateReservation(reservation);

                return $"Reservation created successfully! Booking Reference: {reservation.BookingReference}";
            }
            catch (Exception ex)
            {
                return $"Error creating reservation: {ex.Message}";
            }
        }

        private decimal GetRoomRate(int roomTypeId, int guestTypeId)
        {
            // In real implementation, get rate from rate_configurations table
            // For now, return base rate with adjustments based on guest type
            decimal baseRate = 100; // Default
            decimal multiplier = 1.0m;

            switch (guestTypeId)
            {
                case 2: // VIP
                    multiplier = 0.9m; // 10% discount
                    break;
                case 3: // Corporate
                    multiplier = 0.85m; // 15% discount
                    break;
            }

            return baseRate * multiplier;
        }
    }
}