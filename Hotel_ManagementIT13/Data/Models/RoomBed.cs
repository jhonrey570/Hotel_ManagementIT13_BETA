namespace Hotel_ManagementIT13.Data.Models
{
    public class RoomBed
    {
        public int RoomBedId { get; set; }
        public int RoomId { get; set; }
        public int BedTypeId { get; set; }
        public int Quantity { get; set; }
        public string BedTypeName { get; set; }
        public string BedSize { get; set; }
        public decimal AdditionalCost { get; set; }

        // Navigation property
        public BedType BedType { get; set; }

        // Calculated property
        public decimal TotalAdditionalCost => AdditionalCost * Quantity;

        // Helper method
        public string GetBedInfo()
        {
            return $"{Quantity} x {BedTypeName} ({BedSize})";
        }
    }
}