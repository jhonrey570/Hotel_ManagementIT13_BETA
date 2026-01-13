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
                decimal rate = GetConfiguredRate(roomTypeId, date);
                rate = ApplyGuestDiscount(rate, guestTypeId);
                return rate;
            }
            catch (Exception)
            {
                return GetDefaultRate(roomTypeId);
            }
        }

        private decimal GetConfiguredRate(int roomTypeId, DateTime date)
        {
            return _rateRepo.GetCurrentRate(roomTypeId);
        }

        private decimal ApplyGuestDiscount(decimal rate, int guestTypeId)
        {
            if (guestTypeId == 2) return rate * 0.9m;
            else if (guestTypeId == 3) return rate * 0.85m;
            else if (guestTypeId == 4) return rate * 0.8m;
            return rate;
        }

        private decimal GetDefaultRate(int roomTypeId)
        {
            if (roomTypeId == 1) return 100;
            else if (roomTypeId == 2) return 150;
            else if (roomTypeId == 3) return 200;
            else if (roomTypeId == 4) return 300;
            else if (roomTypeId == 5) return 400;
            else if (roomTypeId == 6) return 1000;
            else return 100;
        }

        public RateResult AddRateConfiguration(RateConfiguration rate)
        {
            var result = new RateResult();

            try
            {
                Console.WriteLine($"DEBUG [RateManager]: Validating rate configuration...");

                // Validate rate
                if (!ValidateRateConfiguration(rate, out string errorMessage))
                {
                    result.Success = false;
                    result.Message = errorMessage;
                    Console.WriteLine($"DEBUG [RateManager]: Validation failed: {errorMessage}");
                    return result;
                }

                Console.WriteLine($"DEBUG [RateManager]: Calling repository to add rate...");
                bool success = _rateRepo.AddRateConfiguration(rate);

                if (success)
                {
                    // UPDATE THE BASE RATE IN ROOM_TYPES TABLE
                    Console.WriteLine($"DEBUG [RateManager]: Updating base rate for room type {rate.RoomTypeId} to {rate.RateAmount}");
                    bool baseRateUpdated = _rateRepo.UpdateRoomTypeBaseRate(rate.RoomTypeId, rate.RateAmount);

                    if (baseRateUpdated)
                    {
                        result.Success = true;
                        result.Message = "Rate configuration added successfully AND base rate updated";
                        Console.WriteLine($"DEBUG [RateManager]: Base rate updated successfully");
                    }
                    else
                    {
                        result.Success = true;
                        result.Message = "Rate configuration added but base rate update failed";
                        Console.WriteLine($"DEBUG [RateManager]: Base rate update failed");
                    }
                    result.RateConfiguration = rate;
                }
                else
                {
                    result.Success = false;
                    result.Message = "Failed to add rate configuration";
                    Console.WriteLine($"DEBUG [RateManager]: Repository returned false - rate not added");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DEBUG [RateManager]: Exception: {ex.Message}");
                Console.WriteLine($"DEBUG [RateManager]: Stack Trace: {ex.StackTrace}");
                result.Success = false;
                result.Message = $"Error adding rate configuration: {ex.Message}";
            }

            return result;
        }

        public bool UpdateRateConfiguration(RateConfiguration rate)
        {
            try
            {
                // Validate rate
                if (!ValidateRateConfiguration(rate, out string errorMessage))
                {
                    Console.WriteLine($"DEBUG [RateManager]: Update validation failed: {errorMessage}");
                    return false;
                }

                // Update the rate configuration
                bool success = _rateRepo.UpdateRateConfiguration(rate);

                if (success)
                {
                    // ALSO UPDATE THE BASE RATE IN ROOM_TYPES TABLE
                    Console.WriteLine($"DEBUG [RateManager]: Updating base rate for room type {rate.RoomTypeId} to {rate.RateAmount}");
                    _rateRepo.UpdateRoomTypeBaseRate(rate.RoomTypeId, rate.RateAmount);
                }

                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DEBUG [RateManager]: Update exception: {ex.Message}");
                return false;
            }
        }

        public bool DeleteRateConfiguration(int rateId)
        {
            try
            {
                Console.WriteLine($"DEBUG [RateManager]: Deleting rate configuration {rateId}");
                return _rateRepo.DeleteRateConfiguration(rateId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DEBUG [RateManager]: Delete exception: {ex.Message}");
                return false;
            }
        }

        public RateConfiguration GetRateConfigurationById(int rateId)
        {
            try
            {
                Console.WriteLine($"DEBUG [RateManager]: Getting rate configuration {rateId}");
                return _rateRepo.GetRateConfigurationById(rateId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DEBUG [RateManager]: GetById exception: {ex.Message}");
                return null;
            }
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

            return true;
        }

        private bool HasOverlappingRates(RateConfiguration newRate)
        {
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
}

