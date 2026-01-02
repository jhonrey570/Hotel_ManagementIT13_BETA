using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ManagementIT13.Data.Models
{
    public class StandardRoom : Room
    {
        public bool HasBasicAmenities { get; set; } = true;
        public bool HasWorkDesk { get; set; } = true;
        public bool HasCoffeeMaker { get; set; } = true;

        public override string GetRoomCategory()
        {
            return "Standard";
        }

        public override decimal CalculateRate(int nights, int guestType)
        {
            decimal baseRate = BaseRate;

            // Apply guest type discounts
            if (guestType == 2) // VIP
                baseRate *= 0.9m;
            else if (guestType == 3) // Corporate
                baseRate *= 0.85m;

            return baseRate * nights;
        }
    }
}
