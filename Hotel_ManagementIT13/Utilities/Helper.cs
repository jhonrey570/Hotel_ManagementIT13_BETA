using System;
using System.Drawing;
using System.Windows.Forms;

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
    }
}