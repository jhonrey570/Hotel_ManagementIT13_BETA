using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;

namespace Hotel_ManagementIT13.Data.Managers
{
    public class BillingManager
    {
        private readonly BillingRepository _billingRepo;
        private readonly PaymentRepository _paymentRepo;

        public BillingManager()
        {
            _billingRepo = new BillingRepository();
            _paymentRepo = new PaymentRepository();
        }

        public Billing GetBillingByReservationId(int reservationId)
        {
            return _billingRepo.GetBillingByReservationId(reservationId);
        }

        public bool ProcessPayment(int reservationId, decimal amount,
                                 string paymentMethod, string notes)
        {

            return _paymentRepo.ProcessPayment(reservationId, amount, paymentMethod, notes);
        }

        public bool AddBillingItem(int billingId, string description, decimal amount)
        {
            return _billingRepo.AddBillingItem(billingId, description, amount);
        }

        public bool CreateBilling(int reservationId, decimal totalAmount)
        {
            return _billingRepo.CreateBilling(reservationId, totalAmount);
        }

        // Additional billing management methods
        public Billing GenerateFinalBill(int reservationId)
        {
            var billing = _billingRepo.GetBillingByReservationId(reservationId);

            if (billing != null)
            {

                return billing;
            }

            return null;
        }

        public decimal CalculateBalance(int reservationId)
        {
            var billing = _billingRepo.GetBillingByReservationId(reservationId);
            return billing?.Balance ?? 0;
        }

        public bool AddServiceCharge(int reservationId, string serviceName, decimal amount)
        {
            var billing = _billingRepo.GetBillingByReservationId(reservationId);
            if (billing == null)
                return false;

            return _billingRepo.AddBillingItem(billing.BillingId,
                $"{serviceName} Charge", amount);
        }

        public bool AddDiscount(int reservationId, string discountReason, decimal amount)
        {
            var billing = _billingRepo.GetBillingByReservationId(reservationId);
            if (billing == null)
                return false;


            return _billingRepo.AddBillingItem(billing.BillingId,
                $"Discount: {discountReason}", -amount);
        }
    }
}
