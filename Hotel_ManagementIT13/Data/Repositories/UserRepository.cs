using MySql.Data.MySqlClient;
using Hotel_ManagementIT13.Data.Models;
using System;
using System.Collections.Generic;
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
                
                using (var cmd = new MySqlCommand("sp_AuthenticateUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_username", username);
                    cmd.Parameters.AddWithValue("@p_password", password);

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

       
        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                
                using (var cmd = new MySqlCommand("sp_GetAllUsers", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

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

        
        public User GetUserById(int userId)
        {
            User user = null;

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                
                using (var cmd = new MySqlCommand("sp_GetUserById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_user_id", userId);

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

       
        public bool AddUser(User user)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                
                using (var cmd = new MySqlCommand("sp_AddUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_username", user.Username);
                    cmd.Parameters.AddWithValue("@p_password", user.Password);
                    cmd.Parameters.AddWithValue("@p_first_name", user.FirstName);
                    cmd.Parameters.AddWithValue("@p_last_name", user.LastName);
                    cmd.Parameters.AddWithValue("@p_email", user.Email);
                    cmd.Parameters.AddWithValue("@p_is_active", user.IsActive);
                    cmd.Parameters.AddWithValue("@p_role", user.GetRole());
                    
                    var outputParam = new MySqlParameter("@p_success", MySqlDbType.Int32);
                    outputParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParam);

                    cmd.ExecuteNonQuery();
                    
                    return outputParam.Value != DBNull.Value && Convert.ToInt32(outputParam.Value) == 1;
                }
            }
        }

        
        public bool UpdateUser(User user)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                
                using (var cmd = new MySqlCommand("sp_UpdateUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_user_id", user.UserId);
                    cmd.Parameters.AddWithValue("@p_username", user.Username);
                    cmd.Parameters.AddWithValue("@p_first_name", user.FirstName);
                    cmd.Parameters.AddWithValue("@p_last_name", user.LastName);
                    cmd.Parameters.AddWithValue("@p_email", user.Email);
                    cmd.Parameters.AddWithValue("@p_is_active", user.IsActive);
                    cmd.Parameters.AddWithValue("@p_role", user.GetRole());
                    
                    var outputParam = new MySqlParameter("@p_success", MySqlDbType.Int32);
                    outputParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParam);

                    cmd.ExecuteNonQuery();
                    
                    return outputParam.Value != DBNull.Value && Convert.ToInt32(outputParam.Value) == 1;
                }
            }
        }

        
        public bool DeleteUser(int userId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                
                using (var cmd = new MySqlCommand("sp_DeleteUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_user_id", userId);
                    
                    var outputParam = new MySqlParameter("@p_success", MySqlDbType.Int32);
                    outputParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParam);

                    cmd.ExecuteNonQuery();
                    
                    return outputParam.Value != DBNull.Value && Convert.ToInt32(outputParam.Value) == 1;
                }
            }
        }

       
        public bool ResetPassword(int userId, string newPassword)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                
                using (var cmd = new MySqlCommand("sp_ResetPassword", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_user_id", userId);
                    cmd.Parameters.AddWithValue("@p_new_password", newPassword);
                    
                    var outputParam = new MySqlParameter("@p_success", MySqlDbType.Int32);
                    outputParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParam);

                    cmd.ExecuteNonQuery();
                    
                    return outputParam.Value != DBNull.Value && Convert.ToInt32(outputParam.Value) == 1;
                }
            }
        }

        
        public bool UsernameExists(string username, int? excludeUserId = null)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                
                using (var cmd = new MySqlCommand("sp_UsernameExists", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_username", username);
                    cmd.Parameters.AddWithValue("@p_exclude_user_id", excludeUserId.HasValue ? excludeUserId.Value : (object)DBNull.Value);
                    
                    var outputParam = new MySqlParameter("@p_exists", MySqlDbType.Int32);
                    outputParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParam);

                    cmd.ExecuteNonQuery();
                    
                    return outputParam.Value != DBNull.Value && Convert.ToInt32(outputParam.Value) == 1;
                }
            }
        }

        

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
                
                user.LastLogin = null;
            }
        }
    }
}