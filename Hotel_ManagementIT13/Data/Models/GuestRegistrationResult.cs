using Hotel_ManagementIT13.Data.Models;

namespace Hotel_ManagementIT13.Data.Managers
{
    public class GuestRegistrationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int GuestId { get; set; }
        public Guest Guest { get; set; }
        public int ExistingGuestId { get; set; }
    }
}