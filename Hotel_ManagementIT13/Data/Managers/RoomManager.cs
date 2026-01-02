using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_ManagementIT13.Data.Managers
{
    public class RoomManager
    {
        private readonly RoomRepository _roomRepo;

        // Room status constants
        public const int STATUS_AVAILABLE = 1;
        public const int STATUS_OCCUPIED = 2;
        public const int STATUS_RESERVED = 3;
        public const int STATUS_MAINTENANCE = 4;

        public RoomManager()
        {
            _roomRepo = new RoomRepository();
        }

        public List<Room> GetAllRooms()
        {
            return _roomRepo.GetAllRooms();
        }

        public Room GetRoomById(int roomId)
        {
            return _roomRepo.GetRoomById(roomId);
        }

        public bool AddRoom(Room room)
        {
            return _roomRepo.AddRoom(room);
        }

        public bool UpdateRoom(Room room)
        {
            // TODO: Implement UpdateRoom in repository
            return true;
        }

        public bool UpdateRoomStatus(int roomId, int statusId)
        {
            return _roomRepo.UpdateRoomStatus(roomId, statusId);
        }

        public List<Room> GetAvailableRooms()
        {
            return _roomRepo.GetAvailableRooms(DateTime.Today, DateTime.Today.AddDays(1));
        }

        public List<Room> GetAvailableRooms(DateTime checkIn, DateTime checkOut, int roomTypeId = 0)
        {
            return _roomRepo.GetAvailableRooms(checkIn, checkOut, roomTypeId);
        }

        // New method to get available room count
        public int GetAvailableRoomCount()
        {
            var rooms = GetAllRooms();
            return rooms.Count(r => r.StatusId == STATUS_AVAILABLE);
        }

        // New method to get occupied room count
        public int GetOccupiedRoomCount()
        {
            var rooms = GetAllRooms();
            return rooms.Count(r => r.StatusId == STATUS_OCCUPIED);
        }

        // New method to get reserved room count
        public int GetReservedRoomCount()
        {
            var rooms = GetAllRooms();
            return rooms.Count(r => r.StatusId == STATUS_RESERVED);
        }

        // New method to get room statistics
        public Dictionary<string, int> GetRoomStatistics()
        {
            var rooms = GetAllRooms();

            return new Dictionary<string, int>
            {
                { "Total", rooms.Count },
                { "Available", rooms.Count(r => r.StatusId == STATUS_AVAILABLE) },
                { "Occupied", rooms.Count(r => r.StatusId == STATUS_OCCUPIED) },
                { "Reserved", rooms.Count(r => r.StatusId == STATUS_RESERVED) },
                { "Maintenance", rooms.Count(r => r.StatusId == STATUS_MAINTENANCE) }
            };
        }

        // New method to get occupancy rate
        public decimal GetOccupancyRate()
        {
            var rooms = GetAllRooms();
            int totalRooms = rooms.Count;
            int occupiedRooms = rooms.Count(r => r.StatusId == STATUS_OCCUPIED);

            if (totalRooms == 0) return 0;
            return (decimal)occupiedRooms / totalRooms * 100;
        }
    }
}