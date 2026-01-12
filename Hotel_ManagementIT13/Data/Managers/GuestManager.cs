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
                if (!ValidateGuest(guest, out string validationError))
                {
                    result.Success = false;
                    result.Message = validationError;
                    return result;
                }

                var existingGuests = _guestRepo.SearchGuests(guest.Email);
                if (existingGuests.Count > 0 && !string.IsNullOrEmpty(guest.Email))
                {
                    result.Success = false;
                    result.Message = "A guest with this email already exists";
                    result.ExistingGuestId = existingGuests[0].GuestId;
                    return result;
                }

                if (guest.GuestTypeId == 0)
                {
                    guest.GuestTypeId = isWalkIn ? 1 : 2;
                }

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
                history.Guest = _guestRepo.GetGuestById(guestId);

                if (history.Guest != null)
                {
                    DateTime sixMonthsAgo = DateTime.Now.AddMonths(-6);
                    history.Reservations = _reservationRepo.GetReservationsByDateRange(
                        sixMonthsAgo, DateTime.Now.AddDays(30));

                    history.Reservations = history.Reservations
                        .FindAll(r => r.GuestId == guestId);

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

            if (guest.Phone.Length < 10)
            {
                errorMessage = "Phone number must be at least 10 digits";
                return false;
            }

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
}