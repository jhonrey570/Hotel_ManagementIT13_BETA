using System;
using System.Windows.Forms;

namespace Hotel_ManagementIT13
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Test database connection
            if (!Data.DatabaseHelper.TestConnection())
            {
                MessageBox.Show("Cannot connect to database. Please check your connection.",
                              "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new Forms.frmLogin());
            //Application.Run(new Forms.frmMainDashboard());
        }
    }
}