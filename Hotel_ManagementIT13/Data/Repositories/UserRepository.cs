using MySql.Data.MySqlClient;
using Hotel_ManagementIT13.Data.Models;
using System;
using System.Data;

namespace Hotel_ManagementIT13.Data.Repositories
{
    public class UserRepository
    {
        public User Authenticate(string username, string password)
        {
            User user = null;

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT u.*, 
                           CASE 
                               WHEN a.admin_id IS NOT NULL THEN 'Admin'
                               WHEN m.manager_id IS NOT NULL THEN 'Manager'
                               WHEN f.staff_id IS NOT NULL THEN 'FrontDesk'
                           END as Role
                    FROM users u
                    LEFT JOIN admins a ON u.user_id = a.user_id
                    LEFT JOIN managers m ON u.user_id = m.user_id
                    LEFT JOIN front_desk_staff f ON u.user_id = f.user_id
                    WHERE u.username = @username AND u.password = @password AND u.is_active = 1";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string role = reader["Role"].ToString();

                            switch (role)
                            {
                                case "Admin":
                                    user = new Admin();
                                    break;
                                case "Manager":
                                    user = new Manager();
                                    break;
                                case "FrontDesk":
                                    user = new FrontDeskStaff();
                                    break;
                            }

                            if (user != null)
                            {
                                user.UserId = Convert.ToInt32(reader["user_id"]);
                                user.Username = reader["username"].ToString();
                                user.Password = reader["password"].ToString();
                                user.FirstName = reader["first_name"].ToString();
                                user.LastName = reader["last_name"].ToString();
                                user.Email = reader["email"].ToString();
                                user.IsActive = Convert.ToBoolean(reader["is_active"]);
                                user.CreatedAt = Convert.ToDateTime(reader["created_at"]);
                            }
                        }
                    }
                }
            }

            return user;
        }

        public bool AddUser(User user)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Insert into users table
                        string userQuery = @"
                            INSERT INTO users (username, password, first_name, last_name, email, is_active)
                            VALUES (@username, @password, @firstName, @lastName, @email, @isActive);
                            SELECT LAST_INSERT_ID();";

                        using (var cmd = new MySqlCommand(userQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@username", user.Username);
                            cmd.Parameters.AddWithValue("@password", user.Password);
                            cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                            cmd.Parameters.AddWithValue("@lastName", user.LastName);
                            cmd.Parameters.AddWithValue("@email", user.Email);
                            cmd.Parameters.AddWithValue("@isActive", user.IsActive);

                            int userId = Convert.ToInt32(cmd.ExecuteScalar());

                            // Insert into role-specific table
                            string roleQuery = "";
                            switch (user.GetRole())
                            {
                                case "Admin":
                                    roleQuery = "INSERT INTO admins (user_id) VALUES (@userId)";
                                    break;
                                case "Manager":
                                    roleQuery = "INSERT INTO managers (user_id) VALUES (@userId)";
                                    break;
                                case "FrontDesk":
                                    roleQuery = "INSERT INTO front_desk_staff (user_id) VALUES (@userId)";
                                    break;
                            }

                            if (!string.IsNullOrEmpty(roleQuery))
                            {
                                using (var roleCmd = new MySqlCommand(roleQuery, conn, transaction))
                                {
                                    roleCmd.Parameters.AddWithValue("@userId", userId);
                                    roleCmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            return true;
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}