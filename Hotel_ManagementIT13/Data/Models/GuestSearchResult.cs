using Hotel_ManagementIT13.Data.Models;
using System.Collections.Generic;

namespace Hotel_ManagementIT13.Data.Managers
{
    public class GuestSearchResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<Guest> Guests { get; set; }
    }
}