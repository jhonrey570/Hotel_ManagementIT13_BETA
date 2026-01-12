using Hotel_ManagementIT13.Data.Models;

namespace Hotel_ManagementIT13.Data.Managers
{
    public class CheckInResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Reservation Reservation { get; set; }
    }
}