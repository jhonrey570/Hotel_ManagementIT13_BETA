using System;

namespace Hotel_ManagementIT13.Data.Models
{
    public abstract class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }

        public abstract string GetRole();

        public string FullName => $"{FirstName} {LastName}";

        public bool HasPermission(string permission)
        {
            // Permission checking logic based on role
            return GetRole() == "Admin"; // Simplified - expand as needed
        }

        public void UpdateLastLogin()
        {
            LastLogin = DateTime.Now;
        }
    }
}