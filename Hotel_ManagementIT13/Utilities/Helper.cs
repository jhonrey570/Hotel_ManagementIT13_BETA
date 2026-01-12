using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Hotel_ManagementIT13.Utilities
{
    public static class Helper
    {
     
        public static void SetButtonColors(Button button, Color backColor, Color foreColor)
        {
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.FlatAppearance.BorderColor = backColor;
        }

        public static void StyleButton(Button button, Color backColor, Color foreColor)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.Cursor = Cursors.Hand;
            button.Padding = new Padding(10, 5, 10, 5);

          
            button.MouseEnter += (s, e) =>
            {
                button.BackColor = Color.FromArgb(
                    Math.Min(backColor.R + 20, 255),
                    Math.Min(backColor.G + 20, 255),
                    Math.Min(backColor.B + 20, 255)
                );
            };

            button.MouseLeave += (s, e) =>
            {
                button.BackColor = backColor;
            };
        }

        public static void HighlightRow(DataGridView dataGridView, int rowIndex)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }

            if (rowIndex >= 0 && rowIndex < dataGridView.Rows.Count)
            {
                dataGridView.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            }
        }

        
        public static string FormatCurrency(decimal amount)
        {
            return amount.ToString("C2");
        }

        public static string FormatDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public static string FormatDateTime(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm");
        }

        public static string FormatPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return "";

           
            string digits = Regex.Replace(phone, @"\D", "");

            if (digits.Length == 10)
                return $"({digits.Substring(0, 3)}) {digits.Substring(3, 3)}-{digits.Substring(6, 4)}";
            else if (digits.Length == 11)
                return $"{digits.Substring(0, 4)} {digits.Substring(4, 3)} {digits.Substring(7, 4)}";
            else
                return phone;
        }

        
        public static DialogResult ConfirmAction(string message)
        {
            return MessageBox.Show(message, "Confirm Action",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Success",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, "Warning",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

           
            string digits = Regex.Replace(phone, @"\D", "");
            return digits.Length >= 10;
        }

        public static bool IsValidRequired(TextBox textBox, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                ShowError($"{fieldName} is required");
                textBox.Focus();
                return false;
            }
            return true;
        }

        public static bool IsValidRequired(ComboBox comboBox, string fieldName)
        {
            if (comboBox.SelectedIndex == -1 || string.IsNullOrWhiteSpace(comboBox.Text))
            {
                ShowError($"{fieldName} is required");
                comboBox.Focus();
                return false;
            }
            return true;
        }

        public static bool IsValidNumber(NumericUpDown control, string fieldName, int minValue = 1)
        {
            if (control.Value < minValue)
            {
                ShowError($"{fieldName} must be at least {minValue}");
                control.Focus();
                return false;
            }
            return true;
        }

        public static bool IsValidDateRange(DateTime startDate, DateTime endDate, string fieldName = "Date range")
        {
            if (startDate >= endDate)
            {
                ShowError("End date must be after start date");
                return false;
            }

            if (startDate < DateTime.Today)
            {
                ShowError("Start date cannot be in the past");
                return false;
            }

            return true;
        }

       
        public static int CalculateNights(DateTime checkIn, DateTime checkOut)
        {
            return (checkOut - checkIn).Days;
        }

        public static decimal CalculateTotalAmount(decimal nightlyRate, int nights, int numberOfRooms = 1)
        {
            return nightlyRate * nights * numberOfRooms;
        }

       
        public static string TruncateString(string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text)) return text;
            return text.Length <= maxLength ? text : text.Substring(0, maxLength) + "...";
        }

        public static string CapitalizeFirstLetter(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            return char.ToUpper(text[0]) + text.Substring(1).ToLower();
        }

        
        public static string GetTimestamp()
        {
            return DateTime.Now.ToString("yyyyMMdd_HHmmss");
        }

        public static string GenerateReportFilename(string reportType)
        {
            return $"{reportType}_{GetTimestamp()}.pdf";
        }

      
        public static Color SuccessColor = Color.FromArgb(46, 204, 113); // Green
        public static Color ErrorColor = Color.FromArgb(231, 76, 60);    // Red
        public static Color WarningColor = Color.FromArgb(241, 196, 15); // Yellow
        public static Color InfoColor = Color.FromArgb(52, 152, 219);    // Blue
        public static Color PrimaryColor = Color.FromArgb(41, 128, 185); // Dark Blue
        public static Color SecondaryColor = Color.FromArgb(149, 165, 166); // Gray
    }
}