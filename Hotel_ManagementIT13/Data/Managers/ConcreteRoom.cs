using Hotel_ManagementIT13.Data.Models;
using System.Collections.Generic;

namespace Hotel_ManagementIT13.Services
{
    public class ConcreteRoom : Room
    {
        public ConcreteRoom()
        {
        }

        public ConcreteRoom(int roomId, string roomNumber, string roomTypeName, int floor,
                           string statusName, string viewName, decimal baseRate, int maxOccupancy)
        {
            this.RoomId = roomId;
            this.RoomNumber = roomNumber;
            this.RoomTypeName = roomTypeName;
            this.Floor = floor;
            this.StatusName = statusName;
            this.ViewName = viewName;
            this.BaseRate = baseRate;
            this.MaxOccupancy = maxOccupancy;
        }

        public override string GetRoomCategory()
        {
            if (this.RoomTypeName != null)
            {
                if (this.RoomTypeName.Contains("Standard"))
                    return "Standard";
                else if (this.RoomTypeName.Contains("Deluxe"))
                    return "Deluxe";
                else if (this.RoomTypeName.Contains("Suite") || this.RoomTypeName.Contains("Penthouse") || this.RoomTypeName.Contains("Executive"))
                    return "Suite";
            }
            return "Standard";
        }

        public override decimal CalculateRate(int nights, int guestType)
        {
            decimal rate = this.BaseRate * nights;

            if (this.Amenities != null)
            {
                rate += (this.Amenities.Count * 100m) * nights;
            }

            if (guestType == 2)
                rate *= 0.9m;
            else if (guestType == 3)
                rate *= 0.85m;

            return rate;
        }
    }
}