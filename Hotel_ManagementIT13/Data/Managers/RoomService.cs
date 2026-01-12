using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_ManagementIT13.Services
{
    public class RoomService
    {
        private readonly RoomRepository _roomRepo;

        public RoomService()
        {
            _roomRepo = new RoomRepository();
        }

        public RoomServiceResult LoadAvailableRooms()
        {
            var result = new RoomServiceResult();

            try
            {
                result.Rooms.Clear();
                var allRooms = _roomRepo.GetAllRooms();

                if (allRooms != null && allRooms.Count > 0)
                {
                    var bookableRooms = allRooms
                        .Where(r => StatusHelper.BOOKABLE_STATUSES.Contains(r.StatusId))
                        .ToList();

                    result.Rooms.AddRange(bookableRooms);
                    result.Message = $"Loaded {allRooms.Count} rooms, {bookableRooms.Count} available";
                    result.Success = true;
                }
                else
                {
                    result.Message = "No rooms found in database";
                    result.Success = true;
                }
            }
            catch
            {
                result.Message = "Error loading rooms";
                result.Success = false;
            }

            return result;
        }

        public List<string> GetRoomTypes(List<Room> availableRooms)
        {
            var roomTypes = new List<string>();

            try
            {
                if (availableRooms != null && availableRooms.Count > 0)
                {
                    var uniqueTypes = availableRooms
                        .Where(r => !string.IsNullOrEmpty(r.RoomTypeName))
                        .Select(r => r.RoomTypeName)
                        .Distinct()
                        .OrderBy(t => t)
                        .ToList();

                    roomTypes.AddRange(uniqueTypes);
                }

                if (roomTypes.Count == 0)
                {
                    try
                    {
                        var allRooms = _roomRepo.GetAllRooms();
                        if (allRooms != null)
                        {
                            var uniqueTypes = allRooms
                                .Where(r => !string.IsNullOrEmpty(r.RoomTypeName))
                                .Select(r => r.RoomTypeName)
                                .Distinct()
                                .OrderBy(t => t)
                                .ToList();

                            roomTypes.AddRange(uniqueTypes);
                        }
                    }
                    catch
                    {
                        roomTypes.Add("Standard");
                        roomTypes.Add("Deluxe");
                        roomTypes.Add("Suite");
                    }
                }
            }
            catch
            {
                roomTypes.Add("Standard");
                roomTypes.Add("Deluxe");
                roomTypes.Add("Suite");
            }

            return roomTypes;
        }

        public void SetupRoomsGrid(DataGridView dgvAvailableRooms)
        {
            dgvAvailableRooms.Columns.Clear();
            dgvAvailableRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAvailableRooms.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAvailableRooms.RowHeadersVisible = false;
            dgvAvailableRooms.ReadOnly = false;
            dgvAvailableRooms.AllowUserToAddRows = false;
            dgvAvailableRooms.AllowUserToDeleteRows = false;
            dgvAvailableRooms.EditMode = DataGridViewEditMode.EditOnEnter;

            DataGridViewCheckBoxColumn checkCol = new DataGridViewCheckBoxColumn();
            checkCol.Name = "Select";
            checkCol.HeaderText = "Select";
            checkCol.FillWeight = 8;
            checkCol.ReadOnly = false;
            checkCol.TrueValue = true;
            checkCol.FalseValue = false;
            dgvAvailableRooms.Columns.Add(checkCol);

            DataGridViewTextBoxColumn roomIdCol = new DataGridViewTextBoxColumn();
            roomIdCol.Name = "RoomId";
            roomIdCol.HeaderText = "ID";
            roomIdCol.Visible = false;
            roomIdCol.ReadOnly = true;
            dgvAvailableRooms.Columns.Add(roomIdCol);

            DataGridViewTextBoxColumn roomNumCol = new DataGridViewTextBoxColumn();
            roomNumCol.Name = "RoomNumber";
            roomNumCol.HeaderText = "Room #";
            roomNumCol.FillWeight = 12;
            roomNumCol.ReadOnly = true;
            dgvAvailableRooms.Columns.Add(roomNumCol);

            DataGridViewTextBoxColumn typeCol = new DataGridViewTextBoxColumn();
            typeCol.Name = "Type";
            typeCol.HeaderText = "Type";
            typeCol.FillWeight = 15;
            typeCol.ReadOnly = true;
            dgvAvailableRooms.Columns.Add(typeCol);

            DataGridViewTextBoxColumn floorCol = new DataGridViewTextBoxColumn();
            floorCol.Name = "Floor";
            floorCol.HeaderText = "Floor";
            floorCol.FillWeight = 10;
            floorCol.ReadOnly = true;
            dgvAvailableRooms.Columns.Add(floorCol);

            DataGridViewTextBoxColumn viewCol = new DataGridViewTextBoxColumn();
            viewCol.Name = "View";
            viewCol.HeaderText = "View";
            viewCol.FillWeight = 15;
            viewCol.ReadOnly = true;
            dgvAvailableRooms.Columns.Add(viewCol);

            DataGridViewTextBoxColumn statusCol = new DataGridViewTextBoxColumn();
            statusCol.Name = "Status";
            statusCol.HeaderText = "Status";
            statusCol.FillWeight = 20;
            statusCol.ReadOnly = true;
            dgvAvailableRooms.Columns.Add(statusCol);

            DataGridViewTextBoxColumn rateCol = new DataGridViewTextBoxColumn();
            rateCol.Name = "Rate";
            rateCol.HeaderText = "Rate/Night";
            rateCol.FillWeight = 20;
            rateCol.ReadOnly = true;
            dgvAvailableRooms.Columns.Add(rateCol);
        }

        public RoomServiceResult SearchAvailableRooms(DateTime checkIn, DateTime checkOut, string selectedType, List<Room> currentAvailableRooms)
        {
            var result = new RoomServiceResult();

            try
            {
                List<Room> availableRooms = new List<Room>();

                try
                {
                    availableRooms = _roomRepo.GetAvailableRooms(checkIn, checkOut, 0);

                    if (availableRooms != null && availableRooms.Count > 0)
                    {
                        availableRooms = availableRooms
                            .Where(r => StatusHelper.BOOKABLE_STATUSES.Contains(r.StatusId))
                            .ToList();

                        result.Message = $"Found {availableRooms.Count} available rooms";
                    }
                    else
                    {
                        availableRooms = currentAvailableRooms.ToList();
                        result.Message = $"Showing {availableRooms.Count} available rooms";
                    }
                }
                catch
                {
                    availableRooms = currentAvailableRooms.ToList();
                    result.Message = $"Showing {availableRooms.Count} rooms";
                }

                if (selectedType != "All Types" && !string.IsNullOrEmpty(selectedType))
                {
                    availableRooms = availableRooms.Where(r => r.RoomTypeName == selectedType).ToList();
                    result.Message = $"Found {availableRooms.Count} {selectedType} rooms";
                }

                result.Rooms = availableRooms;
                result.Success = true;
            }
            catch
            {
                result.Rooms = new List<Room>();
                result.Message = "Error searching rooms";
                result.Success = false;
            }

            return result;
        }
    }
}