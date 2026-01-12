using System.Windows.Forms;

namespace Hotel_ManagementIT13.Services
{
    public class FormValidationService
    {
        public bool ValidateRoomForm(string roomNumber, ComboBox cmbRoomType,
                                    ComboBox cmbStatus, ComboBox cmbView)
        {
            if (string.IsNullOrWhiteSpace(roomNumber) || roomNumber == "Room Number")
            {
                return false;
            }

            if (cmbRoomType.SelectedIndex == -1)
            {
                return false;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
                return false;
            }

            if (cmbView.SelectedIndex == -1)
            {
                return false;
            }

            return true;
        }

        public bool IsPlaceholderText(string text, string placeholder)
        {
            return text == placeholder || string.IsNullOrWhiteSpace(text);
        }
    }
}