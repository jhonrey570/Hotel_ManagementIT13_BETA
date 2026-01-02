using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ManagementIT13.Data.Models
{
    public class FrontDeskStaff : User
    {
        public int StaffId { get; set; }
        public string Shift { get; set; }
        public bool CanProcessReservations { get; set; } = true;
        public bool CanCheckInOut { get; set; } = true;
        public bool CanHandleBilling { get; set; } = true;

        public override string GetRole()
        {
            return "FrontDesk";
        }

        public string GetFrontDeskDuties()
        {
            return "Reservations, Check-in/Check-out, Billing, Guest Services";
        }
    }
}