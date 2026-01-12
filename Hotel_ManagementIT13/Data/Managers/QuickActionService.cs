using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_ManagementIT13.Forms.Services
{
    public class QuickActionService
    {
        private readonly Dictionary<string, Button> _quickActionButtons;
        private readonly RolePermissionService _roleService;

        public QuickActionService(RolePermissionService roleService)
        {
            _quickActionButtons = new Dictionary<string, Button>();
            _roleService = roleService;
        }

        public void SetupQuickActions(FlowLayoutPanel flpQuickActions, EventHandler buttonClickHandler)
        {
            string[] actions = new[] { "NewReservation", "CheckIn", "CheckOut", "RoomManagement", "GuestManagement", "RateSettings", "UserManagement", "Reports" };
            string[] texts = new[] { "New Reservation", "Check-In", "Check-Out", "Rooms", "Guests", "Rate Settings", "User Management", "Reports" };

            Color thistleColor = Color.Thistle;

            for (int i = 0; i < actions.Length; i++)
            {
                Button btn = CreateQuickActionButton(texts[i], actions[i], thistleColor, buttonClickHandler);
                flpQuickActions.Controls.Add(btn);
                _quickActionButtons[actions[i]] = btn;
            }
        }

        public Form HandleQuickActionClick(string actionTag)
        {
            Form formToOpen = null;

            switch (actionTag)
            {
                case "NewReservation":
                    formToOpen = new frmReservation();
                    break;
                case "CheckIn":
                    formToOpen = new frmCheckIn();
                    break;
                case "CheckOut":
                    formToOpen = new frmCheckOut();
                    break;
                case "RoomManagement":
                    formToOpen = new frmRoomManagement();
                    break;
                case "GuestManagement":
                    formToOpen = new frmGuestManagement();
                    break;
                case "RateSettings":
                    if (!_roleService.CanAccessRateSettings())
                    {
                        MessageBox.Show("Access denied. Admin or Manager privileges required for Rate Settings.",
                                      "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return null;
                    }
                    formToOpen = new frmRateManagement();
                    break;
                case "UserManagement":
                    if (!_roleService.CanAccessUserManagement())
                    {
                        MessageBox.Show("Access denied. Admin privileges required for User Management.",
                                      "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return null;
                    }
                    formToOpen = new frmUserManagement();
                    break;
                case "Reports":
                    if (!_roleService.CanAccessReports())
                    {
                        MessageBox.Show("Access denied. Admin or Manager privileges required for Reports.",
                                      "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return null;
                    }
                    formToOpen = new frmReports();
                    break;
            }

            return formToOpen;
        }

        private Button CreateQuickActionButton(string text, string tag, Color color, EventHandler clickHandler)
        {
            Button btn = new Button
            {
                Text = text,
                Tag = tag,
                Size = new Size(200, 40),
                BackColor = color,
                ForeColor = Color.Black,
                Font = new Font("Calibri", 13.8f, FontStyle.Regular),
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(8, 6, 8, 6),
                Cursor = Cursors.Hand
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = ControlPaint.Dark(color, 0.1f);
            btn.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(color, 0.2f);
            btn.Click += clickHandler;

            return btn;
        }
    }
}