using System;
using System.IO;
using System.Windows.Forms;

namespace Hotel_ManagementIT13.Utilities
{
    public static class Logger
    {
        private static string logFilePath = Path.Combine(
            Application.StartupPath, "Logs", $"hotel_log_{DateTime.Now:yyyyMMdd}.txt");

        static Logger()
        {
            // Create logs directory if it doesn't exist
            string logDir = Path.GetDirectoryName(logFilePath);
            if (!Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }
        }

        public static void LogInfo(string message)
        {
            Log("INFO", message);
        }

        public static void LogError(string message, Exception ex = null)
        {
            string fullMessage = message;
            if (ex != null)
            {
                fullMessage += $" | Exception: {ex.Message} | StackTrace: {ex.StackTrace}";
            }
            Log("ERROR", fullMessage);
        }

        public static void LogWarning(string message)
        {
            Log("WARNING", message);
        }

        public static void LogAudit(string userId, string action, string details)
        {
            string message = $"User: {userId} | Action: {action} | Details: {details}";
            Log("AUDIT", message);
        }

        private static void Log(string level, string message)
        {
            try
            {
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";

                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine(logEntry);
                }

                // Also write to console in debug mode
#if DEBUG
                Console.WriteLine(logEntry);
#endif
            }
            catch (Exception)
            {
                // If logging fails, we don't want to crash the application
            }
        }
    }
}