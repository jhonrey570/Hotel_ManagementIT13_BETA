using Hotel_ManagementIT13.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

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

                using (var cmd = new MySqlCommand("sp_GetRoomTypesList", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roomTypes.Add(reader["type_name"].ToString());
                        }
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

                using (var cmd = new MySqlCommand("sp_GetRoomStatusesList", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            statuses.Add(reader["status_name"].ToString());
                        }
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

                using (var cmd = new MySqlCommand("sp_GetRoomViewsList", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            views.Add(reader["view_name"].ToString());
                        }
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