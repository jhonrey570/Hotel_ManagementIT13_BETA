using MySql.Data.MySqlClient;
using Hotel_ManagementIT13.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Hotel_ManagementIT13.Data.Repositories
{
    public class GuestRepository
    {
        public List<Guest> GetAllGuests()
        {
            var guests = new List<Guest>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_GetAllGuests", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            guests.Add(CreateGuestFromReader(reader));
                        }
                    }
                }
            }

            return guests;
        }

        public Guest GetGuestById(int guestId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_GetGuestById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_guest_id", guestId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return CreateGuestFromReader(reader);
                        }
                    }
                }
            }

            return null;
        }

        public List<Guest> SearchGuests(string searchTerm)
        {
            var guests = new List<Guest>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_SearchGuests", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_search_term", $"%{searchTerm}%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            guests.Add(CreateGuestFromReader(reader));
                        }
                    }
                }
            }

            return guests;
        }

        public int AddGuest(Guest guest)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_AddGuest", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_guest_type_id", guest.GuestTypeId);
                    cmd.Parameters.AddWithValue("@p_first_name", guest.FirstName);
                    cmd.Parameters.AddWithValue("@p_last_name", guest.LastName);
                    cmd.Parameters.AddWithValue("@p_phone", guest.Phone);
                    cmd.Parameters.AddWithValue("@p_email", guest.Email ?? "");
                    cmd.Parameters.AddWithValue("@p_address", guest.Address ?? "");
                    cmd.Parameters.AddWithValue("@p_nationality", guest.Nationality ?? "");
                    cmd.Parameters.AddWithValue("@p_date_of_birth", guest.DateOfBirth.HasValue ?
                        (object)guest.DateOfBirth.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@p_id_type", guest.IdType ?? "");
                    cmd.Parameters.AddWithValue("@p_id_number", guest.IdNumber ?? "");

                    var outputParam = new MySqlParameter("@p_new_guest_id", MySqlDbType.Int32);
                    outputParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParam);

                    cmd.ExecuteNonQuery();

                    return outputParam.Value != DBNull.Value ? Convert.ToInt32(outputParam.Value) : 0;
                }
            }
        }

        public bool UpdateGuest(Guest guest)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_UpdateGuest", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_guest_id", guest.GuestId);
                    cmd.Parameters.AddWithValue("@p_guest_type_id", guest.GuestTypeId);
                    cmd.Parameters.AddWithValue("@p_first_name", guest.FirstName);
                    cmd.Parameters.AddWithValue("@p_last_name", guest.LastName);
                    cmd.Parameters.AddWithValue("@p_phone", guest.Phone);
                    cmd.Parameters.AddWithValue("@p_email", guest.Email ?? "");
                    cmd.Parameters.AddWithValue("@p_address", guest.Address ?? "");
                    cmd.Parameters.AddWithValue("@p_nationality", guest.Nationality ?? "");
                    cmd.Parameters.AddWithValue("@p_date_of_birth", guest.DateOfBirth.HasValue ?
                        (object)guest.DateOfBirth.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@p_id_type", guest.IdType ?? "");
                    cmd.Parameters.AddWithValue("@p_id_number", guest.IdNumber ?? "");

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteGuest(int guestId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_DeleteGuest", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_guest_id", guestId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool GuestHasReservations(int guestId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand("sp_GuestHasReservations", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_guest_id", guestId);

                    var resultParam = new MySqlParameter("@p_has_reservations", MySqlDbType.Int32);
                    resultParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(resultParam);

                    cmd.ExecuteNonQuery();

                    return resultParam.Value != DBNull.Value && Convert.ToInt32(resultParam.Value) > 0;
                }
            }
        }

        private Guest CreateGuestFromReader(MySqlDataReader reader)
        {
            return new Guest
            {
                GuestId = Convert.ToInt32(reader["guest_id"]),
                GuestTypeId = Convert.ToInt32(reader["guest_type_id"]),
                FirstName = reader["first_name"].ToString(),
                LastName = reader["last_name"].ToString(),
                Phone = reader["phone"].ToString(),
                Email = reader["email"].ToString(),
                Address = reader["address"].ToString(),
                Nationality = reader["nationality"].ToString(),
                DateOfBirth = reader["date_of_birth"] != DBNull.Value ?
                    Convert.ToDateTime(reader["date_of_birth"]) : (DateTime?)null,
                IdType = reader["id_type"].ToString(),
                IdNumber = reader["id_number"].ToString(),
                CreatedAt = Convert.ToDateTime(reader["created_at"]),
                GuestTypeName = reader["guest_type_name"].ToString()
            };
        }
    }
}