using System;
using System.Collections.Generic;

namespace Hotel_ManagementIT13.Data.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int GuestId { get; set; }
        public int UserId { get; set; }
        public int? CompanyId { get; set; }
        public int StatusId { get; set; }
        public int ReservationTypeId { get; set; }
        public string BookingReference { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public string SpecialRequests { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public string GuestName { get; set; }
        public string StatusName { get; set; }
        public string ReservationTypeName { get; set; }
        public string CompanyName { get; set; }
        public string UserName { get; set; }

        public List<ReservationRoom> Rooms { get; set; } = new List<ReservationRoom>();
        public int NumberOfNights => (CheckOutDate - CheckInDate).Days;
    }

    public class ReservationRoom
    {
        public int ResRoomId { get; set; }
        public int ReservationId { get; set; }
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string RoomTypeName { get; set; }
        public decimal RoomRate { get; set; }
    }
}