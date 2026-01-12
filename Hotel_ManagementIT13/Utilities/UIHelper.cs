using System.Drawing;
using System.Windows.Forms;

namespace Hotel_ManagementIT13.Services
{
    public static class UIHelper
    {
        public static Button CreateStyledButton(string text, int x, int y)
        {
            Button button = new Button();
            button.Text = text;
            button.Location = new Point(x, y);
            button.Size = new Size(100, 35);
            button.Font = new Font("Calibri", 10, FontStyle.Regular);
            button.BackColor = Color.Thistle;
            button.ForeColor = Color.Black;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.DarkGray;

            return button;
        }
    }
}