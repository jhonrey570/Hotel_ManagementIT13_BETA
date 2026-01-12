using System.Drawing;
using System.Windows.Forms;

namespace Hotel_ManagementIT13.Services
{
    public class UIStateManagementService
    {
        public void SetPlaceholderText(TextBox textBox, string placeholder)
        {
            textBox.Tag = placeholder;
            textBox.Text = placeholder;
            textBox.ForeColor = SystemColors.GrayText;
        }

        public void ClearPlaceholderOnEnter(TextBox textBox)
        {
            if (textBox.Tag != null && textBox.Text == textBox.Tag.ToString())
            {
                textBox.Text = "";
                textBox.ForeColor = SystemColors.ControlText;
            }
        }

        public void RestorePlaceholderOnLeave(TextBox textBox)
        {
            if (textBox.Tag != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Tag.ToString();
                textBox.ForeColor = SystemColors.GrayText;
            }
        }

        public void InitializeFilterComboBox(ComboBox comboBox, string defaultText, System.Collections.IEnumerable items)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add(defaultText);

            foreach (var item in items)
            {
                comboBox.Items.Add(item);
            }

            comboBox.SelectedIndex = 0;
        }
    }
}