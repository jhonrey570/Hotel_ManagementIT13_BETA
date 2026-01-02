using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ManagementIT13.Data.Models
{
    public class Suite : Room
    {
        public bool HasLivingRoom { get; set; } = true;
        public bool HasKitchenette { get; set; } = true;
        public int NumberOfBedrooms { get; set; } = 1;
        public bool HasDiningArea { get; set; } = true;
        public bool HasPrivatePool { get; set; }

        public override string GetRoomCategory()
        {
            return "Suite";
        }

        public override decimal CalculateRate(int nights, int guestType)
        {
            decimal baseRate = BaseRate * 2.0m; // Suites are 100% more expensive

            // Apply guest type discounts
            if (guestType == 2) // VIP
                baseRate *= 0.9m;
            else if (guestType == 3) // Corporate
                baseRate *= 0.85m;

            return baseRate * nights;
        }

        public string GetSuiteDescription()
        {
            return $"{NumberOfBedrooms} Bedroom Suite with Living Room, Kitchenette{(HasPrivatePool ? ", Private Pool" : "")}";
        }
    }
}
