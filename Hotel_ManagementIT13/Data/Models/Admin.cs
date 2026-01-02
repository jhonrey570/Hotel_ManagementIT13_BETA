using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ManagementIT13.Data.Models
{
    public class Admin : User
    {
        public int AdminId { get; set; }
        public string Department { get; set; }
        public bool CanManageUsers { get; set; } = true;
        public bool CanConfigureSystem { get; set; } = true;

        public override string GetRole()
        {
            return "Admin";
        }

        public string GetFullPrivileges()
        {
            return "Full system access, User Management, System Configuration";
        }
    }
}