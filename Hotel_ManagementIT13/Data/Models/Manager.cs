using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ManagementIT13.Data.Models
{
    public class Manager : User
    {
        public int ManagerId { get; set; }
        public string Department { get; set; }
        public bool CanManageRooms { get; set; } = true;
        public bool CanViewReports { get; set; } = true;
        public bool CanConfigureRates { get; set; } = true;

        public override string GetRole()
        {
            return "Manager";
        }

        public string GetManagerialDuties()
        {
            return "Room Management, Rate Configuration, Report Viewing";
        }
    }
}