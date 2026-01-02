using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ManagementIT13.Data.Models
{
    public class DeluxeRoom : Room
    {
        public bool HasJacuzzi { get; set; }
        public bool HasMiniBar { get; set; } = true;
        public bool HasBalcony { get; set; } = true;
        public string BathroomType { get; set; } = "Marble";

        public override string GetRoomCategory()
        {
            return "Deluxe";
        }

        public override decimal CalculateRate(int nights, int guestType)
        {
            decimal baseRate = BaseRate * 1.5m; // Deluxe rooms are 50% more expensive

            // Apply guest type discounts
            if (guestType == 2) // VIP
                baseRate *= 0.9m;
            else if (guestType == 3) // Corporate
                baseRate *= 0.85m;

            return baseRate * nights;
        }

        public string GetDeluxeFeatures()
        {
            return $"Jacuzzi: {(HasJacuzzi ? "Yes" : "No")}, MiniBar: Yes, Balcony: Yes, Bathroom: {BathroomType}";
        }
    }
}
