using Hotel_ManagementIT13.Data.Models;
using System.Collections.Generic;

namespace Hotel_ManagementIT13.Data.Managers
{
    public class GuestHistory
    {
        public Guest Guest { get; set; }
        public List<Reservation> Reservations { get; set; }
        public int TotalReservations { get; set; }
        public int TotalNights { get; set; }
        public decimal TotalSpent { get; set; }
        public double AverageStayLength { get; set; }
    }
}