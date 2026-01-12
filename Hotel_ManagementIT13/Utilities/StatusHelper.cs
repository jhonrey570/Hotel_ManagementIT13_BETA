using System.Drawing;

namespace Hotel_ManagementIT13.Services
{
    public static class StatusHelper
    {
        public const int STATUS_AVAILABLE = 1;
        public const int STATUS_OCCUPIED = 2;
        public const int STATUS_RESERVED = 3;
        public const int STATUS_UNDER_MAINTENANCE = 4;
        public const int STATUS_OUT_OF_SERVICE = 5;
        public const int STATUS_CLEANING_IN_PROGRESS = 6;
        public const int STATUS_READY_FOR_CHECKIN = 7;
        public const int STATUS_CLOSED = 8;

        public static readonly int[] BOOKABLE_STATUSES = { STATUS_AVAILABLE, STATUS_READY_FOR_CHECKIN };

        public static string GetStatusDisplayText(int statusId)
        {
            switch (statusId)
            {
                case STATUS_AVAILABLE: return "Available";
                case STATUS_OCCUPIED: return "Occupied";
                case STATUS_RESERVED: return "Reserved";
                case STATUS_UNDER_MAINTENANCE: return "Under Maintenance";
                case STATUS_OUT_OF_SERVICE: return "Out of Service";
                case STATUS_CLEANING_IN_PROGRESS: return "Cleaning";
                case STATUS_READY_FOR_CHECKIN: return "Ready for Check-in";
                case STATUS_CLOSED: return "Closed";
                default: return "Unknown";
            }
        }

        public static Color GetStatusColor(int statusId)
        {
            switch (statusId)
            {
                case STATUS_AVAILABLE: return Color.Green;
                case STATUS_READY_FOR_CHECKIN: return Color.Blue;
                case STATUS_OCCUPIED: return Color.Red;
                case STATUS_RESERVED: return Color.Orange;
                case STATUS_UNDER_MAINTENANCE: return Color.Purple;
                case STATUS_OUT_OF_SERVICE: return Color.Gray;
                case STATUS_CLEANING_IN_PROGRESS: return Color.DarkCyan;
                case STATUS_CLOSED: return Color.DarkRed;
                default: return Color.Black;
            }
        }

        public static Color GetStatusColorForHistory(string status)
        {
            switch (status.ToLower())
            {
                case "confirmed":
                case "checked-in":
                    return Color.LightGreen;
                case "pending payment":
                    return Color.LightYellow;
                case "cancelled":
                    return Color.LightGray;
                case "no-show":
                    return Color.LightPink;
                default:
                    return Color.White;
            }
        }
    }
}