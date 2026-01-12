using System;

namespace Hotel_ManagementIT13.Data.Models
{
    public class CheckInOutRecord
    {
        public int CheckId { get; set; }
        public int ReservationId { get; set; }
        public int ProcessedBy { get; set; }
        public string ProcessedByName { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
    }
}