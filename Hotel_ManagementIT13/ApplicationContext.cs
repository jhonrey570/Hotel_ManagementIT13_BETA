using Hotel_ManagementIT13.Data.Models;

namespace Hotel_ManagementIT13
{
    public static class ApplicationContext
    {
        public static User CurrentUser { get; set; }

        public static void Initialize()
        {
            // Create a default admin user for testing if needed
            if (CurrentUser == null)
            {
                CurrentUser = new Admin
                {
                    UserId = 1,
                    Username = "admin",
                    FirstName = "System",
                    LastName = "Administrator",
                    Email = "admin@hotel.com"
                };
            }
        }
    }
}