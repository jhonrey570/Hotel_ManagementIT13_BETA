using Hotel_ManagementIT13.Data.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_ManagementIT13.Forms.Services
{
    public class RolePermissionService
    {
        public void ApplyRoleBasedUIRestrictions(Control.ControlCollection quickActionButtons,
                                                MenuStrip mainMenu)
        {
            var currentUser = ApplicationContext.CurrentUser;

            if (currentUser is FrontDeskStaff)
            {
                HideFrontDeskRestrictedButtons(quickActionButtons);
                HideFrontDeskRestrictedMenuItems(mainMenu);
            }
            else if (currentUser is Manager)
            {
                HideManagerRestrictedButtons(quickActionButtons);
                HideManagerRestrictedMenuItems(mainMenu);
            }
            else if (currentUser is Admin)
            {
                ShowAllQuickActionButtons(quickActionButtons);
                ShowAllMenuItems(mainMenu);
            }
        }

        private void HideFrontDeskRestrictedButtons(Control.ControlCollection buttons)
        {
            string[] buttonsToHide = { "RateSettings", "UserManagement", "Reports" };

            foreach (Control control in buttons)
            {
                if (control is Button button && button.Tag != null &&
                    buttonsToHide.Contains(button.Tag.ToString()))
                {
                    button.Visible = false;
                }
            }
        }

        private void HideManagerRestrictedButtons(Control.ControlCollection buttons)
        {
            string[] buttonsToHide = { "UserManagement" };

            foreach (Control control in buttons)
            {
                if (control is Button button && button.Tag != null)
                {
                    if (buttonsToHide.Contains(button.Tag.ToString()))
                    {
                        button.Visible = false;
                    }
                    else
                    {
                        button.Visible = true;
                    }
                }
            }
        }

        private void HideFrontDeskRestrictedMenuItems(MenuStrip mainMenu)
        {
            foreach (ToolStripMenuItem menuItem in mainMenu.Items)
            {
                if (menuItem.Text == "Admin" || menuItem.Text == "Reports")
                {
                    menuItem.Visible = false;
                }
            }
        }

        private void HideManagerRestrictedMenuItems(MenuStrip mainMenu)
        {
            foreach (ToolStripMenuItem menuItem in mainMenu.Items)
            {
                if (menuItem.Text == "Admin")
                {
                    foreach (ToolStripItem subItem in menuItem.DropDownItems)
                    {
                        if (subItem.Name == "menuUsers")
                        {
                            subItem.Visible = false;
                        }
                        else
                        {
                            subItem.Visible = true;
                        }
                    }
                }
            }
        }

        private void ShowAllQuickActionButtons(Control.ControlCollection buttons)
        {
            foreach (Control control in buttons)
            {
                if (control is Button)
                {
                    control.Visible = true;
                }
            }
        }

        private void ShowAllMenuItems(MenuStrip mainMenu)
        {
            foreach (ToolStripMenuItem menuItem in mainMenu.Items)
            {
                menuItem.Visible = true;
                foreach (ToolStripItem subItem in menuItem.DropDownItems)
                {
                    subItem.Visible = true;
                }
            }
        }

        public bool CanAccessRateSettings()
        {
            var currentUser = ApplicationContext.CurrentUser;
            return !(currentUser is FrontDeskStaff);
        }

        public bool CanAccessUserManagement()
        {
            var currentUser = ApplicationContext.CurrentUser;
            return currentUser is Admin;
        }

        public bool CanAccessReports()
        {
            var currentUser = ApplicationContext.CurrentUser;
            return !(currentUser is FrontDeskStaff);
        }
    }
}