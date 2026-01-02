using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hotel_ManagementIT13.Data.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int ReservationId { get; set; }
        public int PaymentStatusId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public string TransactionId { get; set; }
        public string Notes { get; set; }
        public int ProcessedBy { get; set; }

        // Navigation properties
        public string StatusName { get; set; }
        public string GuestName { get; set; }
        public string BookingReference { get; set; }

        public string GetPaymentSummary()
        {
            return $"Payment #{PaymentId}: {Amount:C} via {PaymentMethod} on {PaymentDate:yyyy-MM-dd}";
        }

        public bool IsSuccessful()
        {
            return PaymentStatusId == 2; // Status ID 2 = Paid
        }
    }
}