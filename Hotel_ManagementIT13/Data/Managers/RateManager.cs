using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
using System;
using System.Collections.Generic;

namespace Hotel_ManagementIT13.Data.Managers
{
    public class RateManager
    {
        private readonly RateRepository _rateRepo;

        public RateManager()
        {
            _rateRepo = new RateRepository();
        }

        public decimal GetRoomRate(int roomTypeId, int guestTypeId, DateTime date)
        {
            try
            {
                // First try to get rate configuration for specific date
                decimal rate = GetConfiguredRate(roomTypeId, date);

                // Apply guest type discount
                rate = ApplyGuestDiscount(rate, guestTypeId);

                return rate;
            }
            catch (Exception)
            {
                // Fallback to default rate
                return GetDefaultRate(roomTypeId);
            }
        }

        private decimal GetConfiguredRate(int roomTypeId, DateTime date)
        {
            // In real implementation, query database for rate on specific date
            // For now, use current rate
            return _rateRepo.GetCurrentRate(roomTypeId);
        }

        private decimal ApplyGuestDiscount(decimal rate, int guestTypeId)
        {
            if (guestTypeId == 2) // VIP
                return rate * 0.9m; // 10% discount
            else if (guestTypeId == 3) // Corporate
                return rate * 0.85m; // 15% discount
            else if (guestTypeId == 4) // Travel Agency
                return rate * 0.8m; // 20% discount

            return rate; // No discount for regular guests
        }

        private decimal GetDefaultRate(int roomTypeId)
        {
            // Use simple if-else for compatibility
            if (roomTypeId == 1) return 100;     // Single
            else if (roomTypeId == 2) return 150; // Double
            else if (roomTypeId == 3) return 200; // Twin
            else if (roomTypeId == 4) return 300; // Suite
            else if (roomTypeId == 5) return 400; // Deluxe
            else if (roomTypeId == 6) return 1000; // Presidential
            else return 100; // Default
        }

        public RateResult AddRateConfiguration(RateConfiguration rate)
        {
            var result = new RateResult();

            try
            {
                // Validate rate
                if (!ValidateRateConfiguration(rate, out string errorMessage))
                {
                    result.Success = false;
                    result.Message = errorMessage;
                    return result;
                }

                // Check for overlapping rates
                if (HasOverlappingRates(rate))
                {
                    result.Success = false;
                    result.Message = "Rate configuration overlaps with existing rates for this room type";
                    return result;
                }

                bool success = _rateRepo.AddRateConfiguration(rate);

                if (success)
                {
                    result.Success = true;
                    result.Message = "Rate configuration added successfully";
                    result.RateConfiguration = rate;
                }
                else
                {
                    result.Success = false;
                    result.Message = "Failed to add rate configuration";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error adding rate configuration: {ex.Message}";
            }

            return result;
        }

        private bool ValidateRateConfiguration(RateConfiguration rate, out string errorMessage)
        {
            errorMessage = "";

            if (rate.RoomTypeId <= 0)
            {
                errorMessage = "Room type is required";
                return false;
            }

            if (rate.RatePlanId <= 0)
            {
                errorMessage = "Rate plan is required";
                return false;
            }

            if (rate.RateAmount <= 0)
            {
                errorMessage = "Rate amount must be greater than 0";
                return false;
            }

            if (rate.StartDate >= rate.EndDate)
            {
                errorMessage = "End date must be after start date";
                return false;
            }

            if (rate.StartDate < DateTime.Today)
            {
                errorMessage = "Start date cannot be in the past";
                return false;
            }

            return true;
        }

        private bool HasOverlappingRates(RateConfiguration newRate)
        {
            // Implementation to check for overlapping rate configurations
            // This would query the database for existing rates
            return false; // Simplified for now
        }

        public List<RateConfiguration> GetActiveRates()
        {
            return _rateRepo.GetRateConfigurations()
                .FindAll(r => r.IsActive());
        }

        public List<RateConfiguration> GetRatesByRoomType(int roomTypeId)
        {
            return _rateRepo.GetRateConfigurations()
                .FindAll(r => r.RoomTypeId == roomTypeId);
        }

        public List<RoomType> GetAvailableRoomTypes()
        {
            return _rateRepo.GetRoomTypes();
        }

        public List<RatePlan> GetAvailableRatePlans()
        {
            return _rateRepo.GetRatePlans();
        }

        public decimal CalculateTotalStayCost(int roomTypeId, int guestTypeId,
                                            DateTime checkIn, DateTime checkOut)
        {
            int nights = (checkOut - checkIn).Days;
            if (nights <= 0) return 0;

            decimal nightlyRate = GetRoomRate(roomTypeId, guestTypeId, checkIn);
            return nightlyRate * nights;
        }
    }

    public class RateResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public RateConfiguration RateConfiguration { get; set; }
    }
}