using System.Collections.Generic;

namespace Hotel_ManagementIT13.Data.Models
{
    public abstract class Room
    {
        public int RoomId { get; set; }
        public int RoomTypeId { get; set; }
        public int StatusId { get; set; }
        public int ViewId { get; set; }
        public string RoomNumber { get; set; }
        public int Floor { get; set; }
        public string RoomTypeName { get; set; }
        public string StatusName { get; set; }
        public string ViewName { get; set; }
        public decimal BaseRate { get; set; }
        public int MaxOccupancy { get; set; }

        public List<RoomBed> Beds { get; set; } = new List<RoomBed>();
        public List<Amenity> Amenities { get; set; } = new List<Amenity>();

        public abstract string GetRoomCategory();

        public abstract decimal CalculateRate(int nights, int guestType);

        public string GetRoomInfo()
        {
            return $"Room {RoomNumber} - {RoomTypeName} (Floor {Floor}, {ViewName})";
        }

        public bool IsAvailable()
        {
            return StatusId == 1; // Status ID 1 = Available
        }
    }

    public class RoomBed
    {
        public int RoomBedId { get; set; }
        public int RoomId { get; set; }
        public int BedTypeId { get; set; }
        public int Quantity { get; set; }
        public string BedTypeName { get; set; }
    }

    public class Amenity
    {
        public int AmenityId { get; set; }
        public string AmenityName { get; set; }
        public string Category { get; set; }
        public bool IsStandard { get; set; }
    }
}