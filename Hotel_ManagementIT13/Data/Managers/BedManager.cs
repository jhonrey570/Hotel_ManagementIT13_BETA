using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
using System;
using System.Collections.Generic;

namespace Hotel_ManagementIT13.Data.Managers
{
    public class BedManager
    {
        private readonly BedRepository _bedRepo;

        public BedManager()
        {
            _bedRepo = new BedRepository();
        }

        public List<RoomBed> GetBedsForRoom(int roomId)
        {
            try
            {
                return _bedRepo.GetBedsForRoom(roomId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting beds for room: {ex.Message}", ex);
            }
        }

        public List<BedType> GetAllBedTypes()
        {
            try
            {
                return _bedRepo.GetAllBedTypes();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting bed types: {ex.Message}", ex);
            }
        }

        public bool AddBedToRoom(RoomBed roomBed)
        {
            try
            {
                return _bedRepo.AddRoomBed(roomBed);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding bed to room: {ex.Message}", ex);
            }
        }

        public bool UpdateBed(RoomBed roomBed)
        {
            try
            {
                return _bedRepo.UpdateRoomBed(roomBed);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating bed: {ex.Message}", ex);
            }
        }

        public bool RemoveBed(int roomBedId)
        {
            try
            {
                return _bedRepo.DeleteRoomBed(roomBedId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error removing bed: {ex.Message}", ex);
            }
        }

        public bool ClearRoomBeds(int roomId)
        {
            try
            {
                return _bedRepo.DeleteAllBedsForRoom(roomId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error clearing room beds: {ex.Message}", ex);
            }
        }

        public bool BedTypeExistsInRoom(int roomId, int bedTypeId)
        {
            try
            {
                return _bedRepo.BedTypeExistsInRoom(roomId, bedTypeId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking bed type: {ex.Message}", ex);
            }
        }

        public decimal CalculateTotalBedCost(List<RoomBed> beds)
        {
            decimal total = 0;
            foreach (var bed in beds)
            {
                total += bed.TotalAdditionalCost;
            }
            return total;
        }

        public int CalculateTotalBeds(List<RoomBed> beds)
        {
            int total = 0;
            foreach (var bed in beds)
            {
                total += bed.Quantity;
            }
            return total;
        }
    }
}