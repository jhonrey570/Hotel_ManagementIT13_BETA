using MySql.Data.MySqlClient;
using Hotel_ManagementIT13.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Hotel_ManagementIT13.Data.Repositories
{
    public class UserRepository
    {
        // Existing Authentication method
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
                                MapUserFromReader(reader, user);
                            }
                        }
                    }
                }
            }

            return user;
        }

        // NEW: Get all users for DataGridView
        public List<User> GetAllUsers()
        {
            var users = new List<User>();

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
                    ORDER BY u.created_at DESC";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = CreateUserByRole(reader["Role"].ToString());
                            if (user != null)
                            {
                                MapUserFromReader(reader, user);
                                users.Add(user);
                            }
                        }
                    }
                }
            }

            return users;
        }

        // NEW: Get user by ID for editing
        public User GetUserById(int userId)
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
                    WHERE u.user_id = @userId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string role = reader["Role"].ToString();
                            user = CreateUserByRole(role);
                            if (user != null)
                            {
                                MapUserFromReader(reader, user);
                            }
                        }
                    }
                }
            }

            return user;
        }

        // Existing AddUser method (with minor improvement)
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
                            InsertIntoRoleTable(user.GetRole(), userId, conn, transaction);

                            transaction.Commit();
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Failed to add user: {ex.Message}", ex);
                    }
                }
            }
        }

        // NEW: Update existing user
        public bool UpdateUser(User user)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Update users table
                        string userQuery = @"
                            UPDATE users 
                            SET username = @username, 
                                first_name = @firstName, 
                                last_name = @lastName, 
                                email = @email, 
                                is_active = @isActive
                            WHERE user_id = @userId";

                        using (var cmd = new MySqlCommand(userQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@username", user.Username);
                            cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                            cmd.Parameters.AddWithValue("@lastName", user.LastName);
                            cmd.Parameters.AddWithValue("@email", user.Email);
                            cmd.Parameters.AddWithValue("@isActive", user.IsActive);
                            cmd.Parameters.AddWithValue("@userId", user.UserId);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Delete from all role tables and insert into correct one
                                DeleteFromAllRoleTables(user.UserId, conn, transaction);
                                InsertIntoRoleTable(user.GetRole(), user.UserId, conn, transaction);

                                transaction.Commit();
                                return true;
                            }
                            else
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Failed to update user: {ex.Message}", ex);
                    }
                }
            }
        }

        // NEW: Delete user
        public bool DeleteUser(int userId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Delete from role tables first (due to foreign key constraints)
                        DeleteFromAllRoleTables(userId, conn, transaction);

                        // Delete from users table
                        string userQuery = "DELETE FROM users WHERE user_id = @userId";

                        using (var cmd = new MySqlCommand(userQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@userId", userId);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            transaction.Commit();
                            return rowsAffected > 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Failed to delete user: {ex.Message}", ex);
                    }
                }
            }
        }

        // NEW: Reset password
        public bool ResetPassword(int userId, string newPassword)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE users SET password = @password WHERE user_id = @userId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@password", newPassword);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // NEW: Check if username exists
        public bool UsernameExists(string username, int? excludeUserId = null)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE username = @username";

                if (excludeUserId.HasValue)
                {
                    query += " AND user_id != @excludeUserId";
                }

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    if (excludeUserId.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@excludeUserId", excludeUserId.Value);
                    }

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        // HELPER METHODS

        private User CreateUserByRole(string role)
        {
            switch (role)
            {
                case "Admin":
                    return new Admin();
                case "Manager":
                    return new Manager();
                case "FrontDesk":
                    return new FrontDeskStaff();
                default:
                    return null;
            }
        }

        private void MapUserFromReader(MySqlDataReader reader, User user)
        {
            user.UserId = Convert.ToInt32(reader["user_id"]);
            user.Username = reader["username"].ToString();
            user.Password = reader["password"].ToString();
            user.FirstName = reader["first_name"].ToString();
            user.LastName = reader["last_name"].ToString();
            user.Email = reader["email"].ToString();
            user.IsActive = Convert.ToBoolean(reader["is_active"]);
            user.CreatedAt = Convert.ToDateTime(reader["created_at"]);

            
            try
            {
                // Check if the column exists in the result set
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (reader.GetName(i).Equals("last_login", StringComparison.OrdinalIgnoreCase))
                    {
                        if (reader["last_login"] != DBNull.Value)
                        {
                            user.LastLogin = Convert.ToDateTime(reader["last_login"]);
                        }
                        break;
                    }
                }
            }
            catch
            {
                // Column doesn't exist, just ignore it
                user.LastLogin = null;
            }
        }

        private void InsertIntoRoleTable(string role, int userId, MySqlConnection conn, MySqlTransaction transaction)
        {
            string roleQuery;

            switch (role)
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
                default:
                    roleQuery = null;
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
        }

        private void DeleteFromAllRoleTables(int userId, MySqlConnection conn, MySqlTransaction transaction)
        {
            string[] roleTables = { "admins", "managers", "front_desk_staff" };

            foreach (var table in roleTables)
            {
                string query = $"DELETE FROM {table} WHERE user_id = @userId";
                using (var cmd = new MySqlCommand(query, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}