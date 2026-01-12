using Hotel_ManagementIT13.Data;
using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_ManagementIT13.Services
{
    public class ReservationService
    {
        private readonly ReservationRepository _reservationRepo;
        private readonly AmenityRepository _amenityRepo;
        private readonly RoomRepository _roomRepo;
        private const decimal AMENITY_FEE = 100m;

        public ReservationService()
        {
            _reservationRepo = new ReservationRepository();
            _amenityRepo = new AmenityRepository();
            _roomRepo = new RoomRepository();
        }

        public AmenityServiceResult LoadSpecialRequests()
        {
            var result = new AmenityServiceResult();

            try
            {
                var amenities = _amenityRepo.GetAllAmenities();

                if (amenities != null && amenities.Count > 0)
                {
                    result.Amenities = amenities;
                    result.Message = $"Loaded {amenities.Count} amenities";
                    result.Success = true;
                }
                else
                {
                    result.Amenities = new List<Amenity>();
                    result.Message = "No amenities found in the database. Please add amenities to the amenities table.";
                    result.Success = false;
                }
            }
            catch
            {
                result.Amenities = new List<Amenity>();
                result.Message = "Error loading amenities from database";
                result.Success = false;
            }

            return result;
        }

        public string GenerateBookingReference()
        {
            return _reservationRepo.GenerateBookingReference();
        }

        public decimal GetAmenityFee()
        {
            return AMENITY_FEE;
        }

        public ReservationServiceResult CreateReservation(Reservation reservation)
        {
            var result = new ReservationServiceResult();

            try
            {
                int reservationId = _reservationRepo.CreateReservation(reservation);

                if (reservationId > 0)
                {
                    result.ReservationId = reservationId;
                    result.Message = "Reservation created successfully";
                    result.Success = true;
                }
                else
                {
                    result.Message = "Failed to save reservation. Please try again.";
                    result.Success = false;
                }
            }
            catch (Exception ex)
            {
                result.Message = $"Error creating reservation: {ex.Message}";
                result.Success = false;
            }

            return result;
        }

        public void RefreshDatabaseConnection()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT 1", conn))
                    {
                        cmd.ExecuteScalar();
                    }
                }
            }
            catch
            {
                // Silent fail - connection refresh is optional
            }
        }

        public bool ValidateBooking(Guest selectedGuest, List<int> selectedRoomIds, List<Room> availableRooms,
            DateTime checkIn, DateTime checkOut, int adults)
        {
            if (selectedGuest == null)
            {
                MessageBox.Show("Please select a guest", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (selectedRoomIds.Count == 0)
            {
                MessageBox.Show("Please select at least one room", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (checkOut <= checkIn)
            {
                MessageBox.Show("Check-out date must be after check-in date", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (adults < 1)
            {
                MessageBox.Show("At least 1 adult is required", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            foreach (int roomId in selectedRoomIds)
            {
                var room = availableRooms.FirstOrDefault(r => r.RoomId == roomId);
                if (room != null && !StatusHelper.BOOKABLE_STATUSES.Contains(room.StatusId))
                {
                    MessageBox.Show($"Room {room.RoomNumber} is no longer available for booking. Status: {room.StatusName}",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }
    }
}