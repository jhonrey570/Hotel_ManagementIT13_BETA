using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
using System;
using System.Collections.Generic;

namespace Hotel_ManagementIT13.Data.Managers
{
    public class GuestManager
    {
        private readonly GuestRepository _guestRepo;
        private readonly ReservationRepository _reservationRepo;

        public GuestManager()
        {
            _guestRepo = new GuestRepository();
            _reservationRepo = new ReservationRepository();
        }

        public GuestRegistrationResult RegisterGuest(Guest guest, bool isWalkIn = false)
        {
            var result = new GuestRegistrationResult();

            try
            {
                // Validate guest data
                if (!ValidateGuest(guest, out string validationError))
                {
                    result.Success = false;
                    result.Message = validationError;
                    return result;
                }

                // Check for duplicate guest
                var existingGuests = _guestRepo.SearchGuests(guest.Email);
                if (existingGuests.Count > 0 && !string.IsNullOrEmpty(guest.Email))
                {
                    result.Success = false;
                    result.Message = "A guest with this email already exists";
                    result.ExistingGuestId = existingGuests[0].GuestId;
                    return result;
                }

                // Set guest type if not specified
                if (guest.GuestTypeId == 0)
                {
                    guest.GuestTypeId = isWalkIn ? 1 : 2; // Regular or VIP
                }

                // Add guest to database
                int guestId = _guestRepo.AddGuest(guest);

                result.Success = true;
                result.Message = "Guest registered successfully";
                result.GuestId = guestId;
                result.Guest = guest;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error registering guest: {ex.Message}";
            }

            return result;
        }

        public GuestSearchResult SearchGuests(string searchTerm)
        {
            var result = new GuestSearchResult();

            try
            {
                if (string.IsNullOrWhiteSpace(searchTerm) || searchTerm.Length < 2)
                {
                    result.Success = false;
                    result.Message = "Please enter at least 2 characters to search";
                    return result;
                }

                var guests = _guestRepo.SearchGuests(searchTerm);

                result.Success = true;
                result.Message = $"Found {guests.Count} guest(s)";
                result.Guests = guests;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error searching guests: {ex.Message}";
            }

            return result;
        }

        public GuestHistory GetGuestHistory(int guestId)
        {
            var history = new GuestHistory();

            try
            {
                // Get guest information
                history.Guest = _guestRepo.GetGuestById(guestId);

                if (history.Guest != null)
                {
                    // Get reservation history (last 6 months)
                    DateTime sixMonthsAgo = DateTime.Now.AddMonths(-6);
                    history.Reservations = _reservationRepo.GetReservationsByDateRange(
                        sixMonthsAgo, DateTime.Now.AddDays(30));

                    // Filter to this guest's reservations
                    history.Reservations = history.Reservations
                        .FindAll(r => r.GuestId == guestId);

                    // Calculate statistics
                    history.TotalReservations = history.Reservations.Count;
                    history.TotalNights = 0;
                    history.TotalSpent = 0;

                    foreach (var reservation in history.Reservations)
                    {
                        history.TotalNights += reservation.NumberOfNights;
                        history.TotalSpent += reservation.TotalAmount;
                    }

                    history.AverageStayLength = history.TotalReservations > 0 ?
                        (double)history.TotalNights / history.TotalReservations : 0;
                }
            }
            catch (Exception ex)
            {
                // Log error but return partial data
                Console.WriteLine($"Error getting guest history: {ex.Message}");
            }

            return history;
        }

        private bool ValidateGuest(Guest guest, out string errorMessage)
        {
            errorMessage = "";

            if (string.IsNullOrWhiteSpace(guest.FirstName))
            {
                errorMessage = "First name is required";
                return false;
            }

            if (string.IsNullOrWhiteSpace(guest.LastName))
            {
                errorMessage = "Last name is required";
                return false;
            }

            if (string.IsNullOrWhiteSpace(guest.Phone))
            {
                errorMessage = "Phone number is required";
                return false;
            }

            // Validate phone format
            if (guest.Phone.Length < 10)
            {
                errorMessage = "Phone number must be at least 10 digits";
                return false;
            }

            // Validate email if provided
            if (!string.IsNullOrWhiteSpace(guest.Email))
            {
                if (!guest.Email.Contains("@") || !guest.Email.Contains("."))
                {
                    errorMessage = "Invalid email format";
                    return false;
                }
            }

            return true;
        }
    }

    public class GuestRegistrationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int GuestId { get; set; }
        public Guest Guest { get; set; }
        public int ExistingGuestId { get; set; }
    }

    public class GuestSearchResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<Guest> Guests { get; set; }
    }

    public class GuestHistory
    {
        public Guest Guest { get; set; }
        public List<Reservation> Reservations { get; set; }
        public int TotalReservations { get; set; }
        public int TotalNights { get; set; }
        public decimal TotalSpent { get; set; }
        public double AverageStayLength { get; set; }
    }
}