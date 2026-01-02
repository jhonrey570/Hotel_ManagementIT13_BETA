using System;

namespace Hotel_ManagementIT13.Data.Models
{
    public class Guest
    {
        public int GuestId { get; set; }
        public int GuestTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string IdType { get; set; }
        public string IdNumber { get; set; }
        public DateTime CreatedAt { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        public string GuestTypeName { get; set; }
    }
}