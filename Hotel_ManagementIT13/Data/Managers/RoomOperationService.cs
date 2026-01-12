using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_ManagementIT13.Services
{
    public class RoomOperationService
    {
        private readonly RoomRepository _roomRepository;

        public RoomOperationService()
        {
            _roomRepository = new RoomRepository();
        }

        public ServiceResult<List<Room>> LoadBookableRooms()
        {
            var result = new ServiceResult<List<Room>>();

            try
            {
                var allRooms = _roomRepository.GetAllRooms();

                if (allRooms != null && allRooms.Count > 0)
                {
                    var bookableRooms = allRooms
                        .Where(r => StatusHelper.BOOKABLE_STATUSES.Contains(r.StatusId))
                        .ToList();

                    result.Data = bookableRooms;
                    result.Message = $"Loaded {allRooms.Count} total rooms, {bookableRooms.Count} are bookable";
                    result.Success = true;
                }
                else
                {
                    result.Data = new List<Room>();
                    result.Message = "No rooms found in the database";
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                result.Data = new List<Room>();
                result.Message = $"Error loading rooms: {ex.Message}";
                result.Success = false;
            }

            return result;
        }

        public List<string> GetRoomTypeOptions(List<Room> rooms)
        {
            var roomTypes = new List<string>();

            try
            {
                if (rooms != null && rooms.Count > 0)
                {
                    roomTypes = rooms
                        .Where(r => !string.IsNullOrEmpty(r.RoomTypeName))
                        .Select(r => r.RoomTypeName)
                        .Distinct()
                        .OrderBy(t => t)
                        .ToList();
                }

                if (roomTypes.Count == 0)
                {
                    try
                    {
                        var allRooms = _roomRepository.GetAllRooms();
                        if (allRooms != null)
                        {
                            roomTypes = allRooms
                                .Where(r => !string.IsNullOrEmpty(r.RoomTypeName))
                                .Select(r => r.RoomTypeName)
                                .Distinct()
                                .OrderBy(t => t)
                                .ToList();
                        }
                    }
                    catch
                    {
                        roomTypes = new List<string> { "Standard", "Deluxe", "Suite" };
                    }
                }
            }
            catch
            {
                roomTypes = new List<string> { "Standard", "Deluxe", "Suite" };
            }

            return roomTypes;
        }

        public ServiceResult<List<Room>> FindAvailableRooms(DateTime startDate, DateTime endDate, string roomTypeFilter, List<Room> currentRooms)
        {
            var result = new ServiceResult<List<Room>>();

            try
            {
                List<Room> availableRooms;

                try
                {
                    availableRooms = _roomRepository.GetAvailableRooms(startDate, endDate, 0);

                    if (availableRooms != null && availableRooms.Count > 0)
                    {
                        availableRooms = availableRooms
                            .Where(r => StatusHelper.BOOKABLE_STATUSES.Contains(r.StatusId))
                            .ToList();

                        result.Message = $"Found {availableRooms.Count} available rooms";
                    }
                    else
                    {
                        availableRooms = new List<Room>(currentRooms);
                        result.Message = $"Displaying {availableRooms.Count} rooms from current list";
                    }
                }
                catch
                {
                    availableRooms = new List<Room>(currentRooms);
                    result.Message = $"Displaying {availableRooms.Count} rooms from current list";
                }

                if (!string.IsNullOrEmpty(roomTypeFilter) && roomTypeFilter != "All Types")
                {
                    availableRooms = availableRooms
                        .Where(r => r.RoomTypeName == roomTypeFilter)
                        .ToList();
                    result.Message = $"Found {availableRooms.Count} {roomTypeFilter} rooms";
                }

                result.Data = availableRooms;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Data = new List<Room>();
                result.Message = $"Error finding available rooms: {ex.Message}";
                result.Success = false;
            }

            return result;
        }
    }
}