using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Hotel_ManagementIT13.Data.Managers
{
    public class CheckInManager
    {
        private readonly ReservationRepository _reservationRepo;
        private readonly RoomRepository _roomRepo;
        private readonly BillingRepository _billingRepo;
        private readonly GuestRepository _guestRepo;
        private readonly PaymentRepository _paymentRepo;

        public CheckInManager()
        {
            _reservationRepo = new ReservationRepository();
            _roomRepo = new RoomRepository();
            _billingRepo = new BillingRepository();
            _guestRepo = new GuestRepository();
            _paymentRepo = new PaymentRepository();
        }

        public CheckInResult ProcessCheckIn(string bookingReference, int processedByUserId,
                                          decimal depositAmount = 0, string paymentMethod = "Cash")
        {
            var result = new CheckInResult();

            try
            {
                var reservation = _reservationRepo.GetReservationByReference(bookingReference);
                if (reservation == null)
                {
                    result.Success = false;
                    result.Message = "Reservation not found";
                    return result;
                }

                if (reservation.StatusId == 3)
                {
                    result.Success = false;
                    result.Message = "Guest already checked in";
                    return result;
                }

                _reservationRepo.UpdateReservationStatus(reservation.ReservationId, 3);

                foreach (var room in reservation.Rooms)
                {
                    _roomRepo.UpdateRoomStatus(room.RoomId, 2);
                }

                _reservationRepo.RecordCheckIn(reservation.ReservationId, processedByUserId, 1);

                if (depositAmount > 0)
                {
                    _paymentRepo.ProcessPayment(reservation.ReservationId, depositAmount,
                                              paymentMethod, "Deposit payment at check-in");
                }

                result.Success = true;
                result.Message = $"Check-in processed successfully for {reservation.GuestName}";
                result.Reservation = reservation;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error during check-in: {ex.Message}";
            }

            return result;
        }

        public CheckInResult ProcessWalkInCheckIn(Guest guest, DateTime checkIn, DateTime checkOut,
                                                int roomId, int adults, int children,
                                                int processedByUserId, decimal depositAmount,
                                                decimal paymentAmount, string paymentMethod = "Cash")
        {
            var result = new CheckInResult();

            try
            {
                var room = _roomRepo.GetRoomById(roomId);
                if (room == null || room.StatusId != 1)
                {
                    result.Success = false;
                    result.Message = $"Room is not available";
                    return result;
                }

                int nights = (checkOut - checkIn).Days;
                if (nights == 0) nights = 1;
                decimal roomCharge = room.BaseRate * nights;

                int guestId;
                if (guest.GuestId == 0)
                {
                    if (string.IsNullOrEmpty(guest.Phone)) guest.Phone = "000-000-0000";
                    if (string.IsNullOrEmpty(guest.Email)) guest.Email = "walkin@hotel.com";
                    guestId = _guestRepo.AddGuest(guest);
                }
                else
                {
                    guestId = guest.GuestId;
                }

                var reservationManager = new ReservationManager();
                string reservationResult = reservationManager.CreateReservation(
                    guestId, processedByUserId, checkIn, checkOut,
                    new List<int> { roomId }, adults, children);

                string bookingRef = "";
                if (reservationResult.Contains("Booking Reference:"))
                {
                    int startIndex = reservationResult.IndexOf("Booking Reference:") + "Booking Reference:".Length;
                    bookingRef = reservationResult.Substring(startIndex).Trim();
                }
                else if (reservationResult.Contains("RES"))
                {
                    bookingRef = reservationResult;
                }

                if (!string.IsNullOrEmpty(bookingRef))
                {
                    var reservation = _reservationRepo.GetReservationByReference(bookingRef);
                    if (reservation == null)
                    {
                        result.Success = false;
                        result.Message = "Failed to retrieve created reservation";
                        return result;
                    }

                    bool billingUpdated = false;
                    try
                    {
                        billingUpdated = _billingRepo.AddRoomCharge(
                            reservation.ReservationId,
                            room.RoomNumber,
                            nights,
                            room.BaseRate);

                        if (!billingUpdated)
                        {
                            Console.WriteLine("Warning: Room charge not added to billing");
                        }
                    }
                    catch (Exception billingEx)
                    {
                        Console.WriteLine($"Warning: Failed to update billing: {billingEx.Message}");
                    }

                    if (billingUpdated)
                    {
                        try
                        {
                            var billing = _billingRepo.GetBillingByReservationId(reservation.ReservationId);
                            if (billing != null)
                            {
                                UpdateReservationTotal(reservation.ReservationId, billing.TotalAmount);
                                reservation.TotalAmount = billing.TotalAmount;
                            }
                        }
                        catch (Exception updateEx)
                        {
                            Console.WriteLine($"Warning: Failed to update reservation total: {updateEx.Message}");
                        }
                    }

                    if (depositAmount > 0)
                    {
                        _paymentRepo.ProcessPayment(reservation.ReservationId, depositAmount,
                                                  paymentMethod, "Walk-in deposit payment at check-in");
                    }

                    if (paymentAmount > 0)
                    {
                        _paymentRepo.ProcessPayment(reservation.ReservationId, paymentAmount,
                                                  paymentMethod, "Walk-in payment at check-in");
                    }

                    var checkInResult = ProcessCheckIn(bookingRef, processedByUserId, 0, paymentMethod);

                    if (checkInResult.Success)
                    {
                        var updatedReservation = _reservationRepo.GetReservationByReference(bookingRef);
                        if (updatedReservation != null)
                        {
                            var finalBilling = _billingRepo.GetBillingByReservationId(updatedReservation.ReservationId);
                            if (finalBilling != null)
                            {
                                updatedReservation.TotalAmount = finalBilling.TotalAmount;
                            }

                            checkInResult.Reservation = updatedReservation;
                            result.Reservation = updatedReservation;
                        }
                        else
                        {
                            checkInResult.Reservation = reservation;
                        }
                    }

                    return checkInResult;
                }

                result.Success = false;
                result.Message = "Failed to create walk-in reservation";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error during walk-in check-in: {ex.Message}";
            }

            return result;
        }

        private bool UpdateReservationTotal(int reservationId, decimal totalAmount)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE reservations SET total_amount = @totalAmount WHERE reservation_id = @reservationId";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@reservationId", reservationId);
                        cmd.Parameters.AddWithValue("@totalAmount", totalAmount);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating reservation total: {ex.Message}");
                return false;
            }
        }

        public CheckInResult ProcessGroupCheckIn(string bookingReference, List<int> roomIds,
                                               int processedByUserId, decimal depositAmount = 0)
        {
            var result = new CheckInResult();

            try
            {
                var reservation = _reservationRepo.GetReservationByReference(bookingReference);
                if (reservation == null)
                {
                    result.Success = false;
                    result.Message = "Reservation not found";
                    return result;
                }

                foreach (int roomId in roomIds)
                {
                    bool roomFound = false;
                    foreach (var room in reservation.Rooms)
                    {
                        if (room.RoomId == roomId)
                        {
                            roomFound = true;
                            break;
                        }
                    }

                    if (!roomFound)
                    {
                        result.Success = false;
                        result.Message = $"Room {roomId} is not part of this reservation";
                        return result;
                    }
                }

                foreach (int roomId in roomIds)
                {
                    _roomRepo.UpdateRoomStatus(roomId, 2);
                }

                _reservationRepo.UpdateReservationStatus(reservation.ReservationId, 3);

                _reservationRepo.RecordCheckIn(reservation.ReservationId, processedByUserId, 1);

                if (depositAmount > 0)
                {
                    _paymentRepo.ProcessPayment(reservation.ReservationId, depositAmount,
                                              "Cash", "Group check-in deposit");
                }

                result.Success = true;
                result.Message = $"Group check-in processed successfully for {roomIds.Count} rooms";
                result.Reservation = reservation;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error during group check-in: {ex.Message}";
            }

            return result;
        }
    }
}