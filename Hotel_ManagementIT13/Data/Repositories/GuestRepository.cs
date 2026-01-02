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
                string query = @"
                    SELECT g.*, gt.guest_type_name
                    FROM guests g
                    JOIN guest_types gt ON g.guest_type_id = gt.guest_type_id
                    ORDER BY g.last_name, g.first_name";

                using (var cmd = new MySqlCommand(query, conn))
                {
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
                string query = @"
                    SELECT g.*, gt.guest_type_name
                    FROM guests g
                    JOIN guest_types gt ON g.guest_type_id = gt.guest_type_id
                    WHERE g.guest_id = @guestId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@guestId", guestId);

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
                string query = @"
                    SELECT g.*, gt.guest_type_name
                    FROM guests g
                    JOIN guest_types gt ON g.guest_type_id = gt.guest_type_id
                    WHERE g.first_name LIKE @search 
                       OR g.last_name LIKE @search
                       OR g.email LIKE @search
                       OR g.phone LIKE @search
                    ORDER BY g.last_name, g.first_name";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", $"%{searchTerm}%");

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
                string query = @"
                    INSERT INTO guests 
                    (guest_type_id, first_name, last_name, phone, email, 
                     address, nationality, date_of_birth, id_type, id_number)
                    VALUES 
                    (@typeId, @firstName, @lastName, @phone, @email,
                     @address, @nationality, @dob, @idType, @idNumber);
                    SELECT LAST_INSERT_ID();";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@typeId", guest.GuestTypeId);
                    cmd.Parameters.AddWithValue("@firstName", guest.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", guest.LastName);
                    cmd.Parameters.AddWithValue("@phone", guest.Phone);
                    cmd.Parameters.AddWithValue("@email", guest.Email ?? "");
                    cmd.Parameters.AddWithValue("@address", guest.Address ?? "");
                    cmd.Parameters.AddWithValue("@nationality", guest.Nationality ?? "");
                    cmd.Parameters.AddWithValue("@dob", guest.DateOfBirth.HasValue ?
                        (object)guest.DateOfBirth.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@idType", guest.IdType ?? "");
                    cmd.Parameters.AddWithValue("@idNumber", guest.IdNumber ?? "");

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public bool UpdateGuest(Guest guest)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    UPDATE guests SET
                    guest_type_id = @typeId,
                    first_name = @firstName,
                    last_name = @lastName,
                    phone = @phone,
                    email = @email,
                    address = @address,
                    nationality = @nationality,
                    date_of_birth = @dob,
                    id_type = @idType,
                    id_number = @idNumber
                    WHERE guest_id = @guestId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@guestId", guest.GuestId);
                    cmd.Parameters.AddWithValue("@typeId", guest.GuestTypeId);
                    cmd.Parameters.AddWithValue("@firstName", guest.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", guest.LastName);
                    cmd.Parameters.AddWithValue("@phone", guest.Phone);
                    cmd.Parameters.AddWithValue("@email", guest.Email ?? "");
                    cmd.Parameters.AddWithValue("@address", guest.Address ?? "");
                    cmd.Parameters.AddWithValue("@nationality", guest.Nationality ?? "");
                    cmd.Parameters.AddWithValue("@dob", guest.DateOfBirth.HasValue ?
                        (object)guest.DateOfBirth.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@idType", guest.IdType ?? "");
                    cmd.Parameters.AddWithValue("@idNumber", guest.IdNumber ?? "");

                    return cmd.ExecuteNonQuery() > 0;
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