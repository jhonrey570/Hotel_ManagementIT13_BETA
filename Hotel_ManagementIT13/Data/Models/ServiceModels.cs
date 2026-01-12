using Hotel_ManagementIT13.Data.Models;
using System.Collections.Generic;

namespace Hotel_ManagementIT13.Services
{
    public class GuestServiceResult
    {
        public List<Guest> Guests { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        public GuestServiceResult()
        {
            Guests = new List<Guest>();
        }
    }

    public class RoomServiceResult
    {
        public List<Room> Rooms { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        public RoomServiceResult()
        {
            Rooms = new List<Room>();
        }
    }

    public class ReservationServiceResult
    {
        public int ReservationId { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }

    public class AmenityServiceResult
    {
        public List<Amenity> Amenities { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        public AmenityServiceResult()
        {
            Amenities = new List<Amenity>();
        }
    }

    public class HistoryServiceResult
    {
        public List<Reservation> Reservations { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        public HistoryServiceResult()
        {
            Reservations = new List<Reservation>();
        }
    }

    public class HistoryActionResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}