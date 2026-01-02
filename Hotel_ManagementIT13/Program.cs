using Hotel_ManagementIT13.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_ManagementIT13
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Application.Run(new frmLogin());
            //Application.Run(new frmMainDashboard());
            //Application.Run(new frmReservation());
            //Application.Run(new frmRoomManagement());
            //Application.Run(new frmCheckIn());
            //Application.Run(new frmCheckOut());
            //Application.Run(new frmGuestManagement());
            Application.Run(new frmBilling()); 
            Application.Run(new frmReports());
        }
    }
}
