using System;

namespace Hotel_ManagementIT13.Data.Models
{
    public class RateConfiguration
    {
        public int RateId { get; set; }
        public int RoomTypeId { get; set; }
        public int RatePlanId { get; set; }
        public decimal RateAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RoomTypeName { get; set; }
        public string PlanName { get; set; }

        public bool IsActive()
        {
            DateTime today = DateTime.Today;
            return StartDate <= today && EndDate >= today;
        }
    }

    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string TypeName { get; set; }
        public decimal BaseRate { get; set; }
        public int MaxOccupancy { get; set; }
    }

    public class RatePlan
    {
        public int RatePlanId { get; set; }
        public string PlanName { get; set; }
        public string Description { get; set; }
    }

    public class RateResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public RateConfiguration RateConfiguration { get; set; }
    }
}