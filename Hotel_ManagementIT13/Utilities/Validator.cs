using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Hotel_ManagementIT13.Utilities
{
    public static class Validator
    {
        public static bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return true; 

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        public static bool ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            
            string digits = Regex.Replace(phone, @"\D", "");
            return digits.Length >= 10;
        }

        public static bool ValidateRequired(TextBox textBox, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show($"{fieldName} is required",
                              "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Focus();
                return false;
            }
            return true;
        }

        public static bool ValidateDateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate >= endDate)
            {
                MessageBox.Show("Check-out date must be after check-in date",
                              "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (startDate < DateTime.Today)
            {
                MessageBox.Show("Check-in date cannot be in the past",
                              "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public static bool ValidateNumber(NumericUpDown control, string fieldName, int minValue = 1)
        {
            if (control.Value < minValue)
            {
                MessageBox.Show($"{fieldName} must be at least {minValue}",
                              "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                control.Focus();
                return false;
            }
            return true;
        }
    }
}