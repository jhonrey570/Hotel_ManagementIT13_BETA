using System;
using System.Collections.Generic;

namespace Hotel_ManagementIT13.Data.Models
{
    public class Billing
    {
        public int BillingId { get; set; }
        public int ReservationId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Balance { get; set; }
        public DateTime BillingDate { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsPaid { get; set; }
        public string InvoiceNumber { get; set; }

        // Navigation properties
        public List<BillingItem> Items { get; set; } = new List<BillingItem>();
        public List<Payment> Payments { get; set; } = new List<Payment>();
        public string GuestName { get; set; }
        public string BookingReference { get; set; }

        public void AddItem(string description, decimal amount)
        {
            Items.Add(new BillingItem
            {
                Description = description,
                Amount = amount,
                CreatedAt = DateTime.Now
            });

            TotalAmount += amount;
            Balance = TotalAmount - PaidAmount;
        }

        public void ProcessPayment(decimal amount, string method)
        {
            PaidAmount += amount;
            Balance = TotalAmount - PaidAmount;

            if (Balance <= 0)
                IsPaid = true;
        }

        public string GetBillingStatus()
        {
            if (IsPaid) return "Paid";
            if (Balance == TotalAmount) return "Unpaid";
            return "Partially Paid";
        }
    }

    public class BillingItem
    {
        public int ItemId { get; set; }
        public int BillingId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Category { get; set; }

        public string GetFormattedAmount()
        {
            return Amount.ToString("C");
        }
    }
}