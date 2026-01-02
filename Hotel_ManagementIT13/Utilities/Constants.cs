namespace Hotel_ManagementIT13.Utilities
{
    public static class Constants
    {
        // Room Status IDs
        public const int ROOM_STATUS_AVAILABLE = 1;
        public const int ROOM_STATUS_OCCUPIED = 2;
        public const int ROOM_STATUS_RESERVED = 3;
        public const int ROOM_STATUS_UNDER_MAINTENANCE = 4;
        public const int ROOM_STATUS_OUT_OF_SERVICE = 5;
        public const int ROOM_STATUS_CLEANING_IN_PROGRESS = 6;
        public const int ROOM_STATUS_READY_FOR_CHECKIN = 7;

        // Reservation Status IDs
        public const int RESERVATION_STATUS_CONFIRMED = 1;
        public const int RESERVATION_STATUS_PENDING_PAYMENT = 2;
        public const int RESERVATION_STATUS_CHECKED_IN = 3;
        public const int RESERVATION_STATUS_CHECKED_OUT = 4;
        public const int RESERVATION_STATUS_CANCELLED = 5;
        public const int RESERVATION_STATUS_NO_SHOW = 6;

        // Guest Type IDs
        public const int GUEST_TYPE_REGULAR = 1;
        public const int GUEST_TYPE_VIP = 2;
        public const int GUEST_TYPE_CORPORATE = 3;
        public const int GUEST_TYPE_TRAVEL_AGENCY = 4;

        // Payment Status IDs
        public const int PAYMENT_STATUS_PENDING = 1;
        public const int PAYMENT_STATUS_PAID = 2;
        public const int PAYMENT_STATUS_PARTIALLY_PAID = 3;
        public const int PAYMENT_STATUS_REFUNDED = 4;

        // Check-in/out Status IDs
        public const int CHECKIN_STATUS_CHECKED_IN = 1;
        public const int CHECKIN_STATUS_CHECKED_OUT = 2;
        public const int CHECKIN_STATUS_EARLY_CHECKOUT = 3;
        public const int CHECKIN_STATUS_LATE_CHECKOUT = 4;

        // Application Settings
        public const string APP_NAME = "Hotel Management System";
        public const string APP_VERSION = "1.0.0";
        public const string COMPANY_NAME = "Hotel Management IT13";

        // Default Values
        public const decimal DEFAULT_DEPOSIT_PERCENTAGE = 0.2m; // 20%
        public const int DEFAULT_CHECKIN_HOUR = 14; // 2 PM
        public const int DEFAULT_CHECKOUT_HOUR = 12; // 12 PM
        public const decimal LATE_CHECKOUT_FEE_FIRST_HOUR = 50m;
        public const decimal LATE_CHECKOUT_FEE_ADDITIONAL_HOUR = 25m;

        // Validation
        public const int MIN_GUEST_AGE = 18;
        public const int MAX_ROOM_OCCUPANCY = 6;
        public const int MAX_RESERVATION_DAYS = 30;

        // File Paths
        public const string REPORTS_DIRECTORY = "Reports";
        public const string BACKUP_DIRECTORY = "Backups";
        public const string TEMPLATES_DIRECTORY = "Templates";
    }
}