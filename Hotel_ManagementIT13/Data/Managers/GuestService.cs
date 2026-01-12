using Hotel_ManagementIT13.Data;
using Hotel_ManagementIT13.Data.Managers;
using Hotel_ManagementIT13.Data.Models;
using Hotel_ManagementIT13.Data.Repositories;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hotel_ManagementIT13.Services
{
    public class GuestService
    {
        private readonly GuestManager _guestManager;
        private readonly GuestRepository _guestRepo;

        public GuestService()
        {
            _guestManager = new GuestManager();
            _guestRepo = new GuestRepository();
        }

        public GuestServiceResult LoadAllGuests()
        {
            var result = new GuestServiceResult();

            try
            {
                var allGuests = _guestRepo.GetAllGuests();

                if (allGuests != null && allGuests.Count > 0)
                {
                    result.Guests = allGuests;
                    result.Message = $"Loaded {allGuests.Count} guest(s) from database";
                    result.Success = true;
                }
                else
                {
                    result.Guests = new List<Guest>();
                    result.Message = "No guests found in database";
                    result.Success = true;
                }
            }
            catch
            {
                result.Guests = new List<Guest>();
                result.Message = "Error loading guests";
                result.Success = false;
            }

            return result;
        }

        public GuestServiceResult SearchGuests(string searchTerm)
        {
            var result = new GuestServiceResult();

            try
            {
                var searchResult = _guestManager.SearchGuests(searchTerm);

                if (searchResult.Success)
                {
                    result.Guests = searchResult.Guests;
                    result.Message = $"Found {searchResult.Guests.Count} guest(s)";
                    result.Success = true;
                }
                else
                {
                    result.Guests = new List<Guest>();
                    result.Message = searchResult.Message;
                    result.Success = false;
                }
            }
            catch
            {
                result.Guests = new List<Guest>();
                result.Message = "Error searching guests";
                result.Success = false;
            }

            return result;
        }

        public void SetupGuestGrid(DataGridView dgvGuestResults)
        {
            dgvGuestResults.Columns.Clear();

            DataGridViewTextBoxColumn guestIdCol = new DataGridViewTextBoxColumn();
            guestIdCol.Name = "GuestId";
            guestIdCol.HeaderText = "ID";
            guestIdCol.Visible = false;
            dgvGuestResults.Columns.Add(guestIdCol);

            DataGridViewTextBoxColumn nameCol = new DataGridViewTextBoxColumn();
            nameCol.Name = "Name";
            nameCol.HeaderText = "Name";
            nameCol.Width = 150;
            dgvGuestResults.Columns.Add(nameCol);

            DataGridViewTextBoxColumn phoneCol = new DataGridViewTextBoxColumn();
            phoneCol.Name = "Phone";
            phoneCol.HeaderText = "Phone";
            phoneCol.Width = 100;
            dgvGuestResults.Columns.Add(phoneCol);

            DataGridViewTextBoxColumn emailCol = new DataGridViewTextBoxColumn();
            emailCol.Name = "Email";
            emailCol.HeaderText = "Email";
            emailCol.Width = 150;
            dgvGuestResults.Columns.Add(emailCol);

            DataGridViewTextBoxColumn typeCol = new DataGridViewTextBoxColumn();
            typeCol.Name = "Type";
            typeCol.HeaderText = "Type";
            typeCol.Width = 80;
            dgvGuestResults.Columns.Add(typeCol);

            DataGridViewButtonColumn selectCol = new DataGridViewButtonColumn();
            selectCol.Name = "SelectAction";
            selectCol.HeaderText = "Action";
            selectCol.Text = "Select";
            selectCol.UseColumnTextForButtonValue = true;
            selectCol.Width = 70;
            dgvGuestResults.Columns.Add(selectCol);
        }
    }
}