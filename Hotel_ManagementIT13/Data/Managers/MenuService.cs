using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hotel_ManagementIT13.Forms.Services
{
    public class MenuService
    {
        private readonly Dictionary<string, Func<Form>> _formCreators;

        public MenuService()
        {
            _formCreators = new Dictionary<string, Func<Form>>
            {
                ["menuReservations"] = () => new frmReservation(),
                ["menuViewReservations"] = () => new frmReservation(),
                ["menuCheckIn"] = () => new frmCheckIn(),
                ["menuCheckOut"] = () => new frmCheckOut(),
                ["menuRooms"] = () => new frmRoomManagement(),
                ["menuGuests"] = () => new frmGuestManagement(),
                ["menuBilling"] = () => new frmBilling(),
                ["menuDailyReport"] = () => new frmReports(),
                ["menuMonthlyReport"] = () => new frmReports(),
                ["menuFinancialReport"] = () => new frmReports(),
                ["menuUsers"] = () => new frmUserManagement()
            };
        }

        public void SetupMainMenu(MenuStrip mainMenu, EventHandler menuItemClickHandler)
        {
            var fileMenu = CreateMenuItem("File",
                new[] { ("menuLogout", "Logout"), ("menuExit", "Exit") },
                menuItemClickHandler);

            var reservationsMenu = CreateMenuItem("Reservations",
                new[] { ("menuReservations", "New Reservation"), ("menuViewReservations", "View Reservations") },
                menuItemClickHandler);

            var operationsMenu = CreateMenuItem("Operations",
                new[] { ("menuCheckIn", "Check-In"), ("menuCheckOut", "Check-Out") },
                menuItemClickHandler);

            var managementMenu = CreateMenuItem("Management",
                new[] { ("menuRooms", "Room Management"), ("menuGuests", "Guest Management"), ("menuBilling", "Billing") },
                menuItemClickHandler);

            var reportsMenu = CreateMenuItem("Reports",
                new[] { ("menuDailyReport", "Daily Report"), ("menuMonthlyReport", "Monthly Report"), ("menuFinancialReport", "Financial Report") },
                menuItemClickHandler);

            var adminMenu = CreateMenuItem("Admin",
                new[] { ("menuUsers", "User Management"), ("menuSettings", "System Settings") },
                menuItemClickHandler);

            var helpMenu = new ToolStripMenuItem("Help");

            mainMenu.Items.AddRange(new ToolStripItem[] {
                fileMenu, reservationsMenu, operationsMenu,
                managementMenu, reportsMenu, adminMenu, helpMenu
            });
        }

        public Form HandleMenuItemClick(string menuItemName, RolePermissionService roleService)
        {
            switch (menuItemName)
            {
                case "menuReservations":
                case "menuViewReservations":
                    return _formCreators["menuReservations"]();

                case "menuCheckIn":
                case "menuCheckOut":
                case "menuRooms":
                case "menuGuests":
                case "menuBilling":
                    return _formCreators[menuItemName]();

                case "menuDailyReport":
                case "menuMonthlyReport":
                case "menuFinancialReport":
                    if (!roleService.CanAccessReports())
                    {
                        MessageBox.Show("Access denied. Admin or Manager privileges required for Reports.",
                                      "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return null;
                    }
                    return _formCreators[menuItemName]();

                case "menuUsers":
                    if (!roleService.CanAccessUserManagement())
                    {
                        MessageBox.Show("Access denied. Admin privileges required.",
                                      "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return null;
                    }
                    return _formCreators[menuItemName]();

                case "menuSettings":
                    MessageBox.Show("System Settings feature coming soon!",
                                  "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;

                default:
                    return null;
            }
        }

        private ToolStripMenuItem CreateMenuItem(string text, (string name, string text)[] subItems, EventHandler clickHandler)
        {
            var menuItem = new ToolStripMenuItem(text);
            foreach (var (name, itemText) in subItems)
            {
                var subMenuItem = new ToolStripMenuItem(itemText, null, clickHandler);
                subMenuItem.Name = name;
                menuItem.DropDownItems.Add(subMenuItem);
            }
            return menuItem;
        }
    }
}