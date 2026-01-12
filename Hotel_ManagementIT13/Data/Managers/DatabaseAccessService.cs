using Hotel_ManagementIT13.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Hotel_ManagementIT13.Services
{
    public class DatabaseAccessService
    {
        public List<string> GetRoomTypes()
        {
            var roomTypes = new List<string>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT type_name FROM room_types ORDER BY room_type_id";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roomTypes.Add(reader["type_name"].ToString());
                    }
                }
            }

            return roomTypes;
        }

        public List<string> GetRoomStatuses()
        {
            var statuses = new List<string>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT status_name FROM room_statuses ORDER BY status_id";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        statuses.Add(reader["status_name"].ToString());
                    }
                }
            }

            return statuses;
        }

        public List<string> GetRoomViews()
        {
            var views = new List<string>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT view_name FROM room_views ORDER BY view_id";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        views.Add(reader["view_name"].ToString());
                    }
                }
            }

            return views;
        }

        public bool TestDatabaseConnection()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}