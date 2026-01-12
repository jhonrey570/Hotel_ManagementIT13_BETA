using Hotel_ManagementIT13.Data.Models;

namespace Hotel_ManagementIT13.Data.Managers
{
    public class CheckOutResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Reservation Reservation { get; set; }
        public Billing Billing { get; set; }
        public decimal LateFee { get; set; }
        public string ReceiptNumber { get; set; }
    }
}