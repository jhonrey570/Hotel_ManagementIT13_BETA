using MySql.Data.MySqlClient;
using System;
using System.Configuration;

namespace Hotel_ManagementIT13.Data
{
    public static class DatabaseHelper
    {
        private static string connectionString;

        static DatabaseHelper()
        {
            try
            {
                // Try to get connection string from config
                connectionString = ConfigurationManager.ConnectionStrings["HotelDB"]?.ConnectionString;

                if (string.IsNullOrEmpty(connectionString))
                {
                    // Fallback connection string if config fails
                    connectionString = "Server=localhost;Port=3307;Database=hotel_management;Uid=root;Pwd=;Charset=utf8;";
                }
            }
            catch
            {
                // Fallback if ConfigurationManager fails
                connectionString = "Server=localhost;Port=3307;Database=hotel_management;Uid=root;Pwd=;Charset=utf8;";
            }
        }

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database connection failed: {ex.Message}");
                return false;
            }
        }
    }
}