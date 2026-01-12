using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_ManagementIT13.Forms.Services
{
    public class StatusStripService
    {
        public void UpdateStatusStrip(StatusStrip statusStrip)
        {
            statusStrip.Items.Clear();

            AddStatusLabel($"Last Updated: {DateTime.Now:HH:mm:ss}", FontStyle.Regular, statusStrip);
            AddSeparator(statusStrip);
            AddStatusLabel($"User: {ApplicationContext.CurrentUser?.Username ?? "Guest"}", FontStyle.Regular, statusStrip);
            AddSeparator(statusStrip);
            AddStatusLabel($"Date: {DateTime.Today:yyyy-MM-dd}", FontStyle.Regular, statusStrip);
            AddSeparator(statusStrip);

            var hotelLabel = new ToolStripStatusLabel("Hotel Management System v1.0");
            hotelLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            hotelLabel.ForeColor = Color.FromArgb(52, 152, 219);
            statusStrip.Items.Add(hotelLabel);
        }

        private void AddStatusLabel(string text, FontStyle style, StatusStrip statusStrip)
        {
            var label = new ToolStripStatusLabel(text);
            label.Font = new Font("Segoe UI", 10, style);
            statusStrip.Items.Add(label);
        }

        private void AddSeparator(StatusStrip statusStrip)
        {
            statusStrip.Items.Add(new ToolStripStatusLabel(" | "));
        }
    }
}