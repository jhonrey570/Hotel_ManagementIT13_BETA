using Hotel_ManagementIT13.Data.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hotel_ManagementIT13.Services
{
    public class DataGridConfigurationService
    {
        public void InitializeRoomsDataGrid(DataGridView dataGrid)
        {
            dataGrid.Columns.Clear();
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGrid.RowHeadersVisible = false;
            dataGrid.ReadOnly = false;
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.EditMode = DataGridViewEditMode.EditOnEnter;

            AddSelectionColumn(dataGrid);
            AddRoomIdColumn(dataGrid);
            AddRoomNumberColumn(dataGrid);
            AddTypeColumn(dataGrid);
            AddFloorColumn(dataGrid);
            AddViewColumn(dataGrid);
            AddStatusColumn(dataGrid);
            AddRateColumn(dataGrid);
        }

        private void AddSelectionColumn(DataGridView dataGrid)
        {
            DataGridViewCheckBoxColumn selectionColumn = new DataGridViewCheckBoxColumn();
            selectionColumn.Name = "Select";
            selectionColumn.HeaderText = "Select";
            selectionColumn.FillWeight = 8;
            selectionColumn.ReadOnly = false;
            selectionColumn.TrueValue = true;
            selectionColumn.FalseValue = false;
            dataGrid.Columns.Add(selectionColumn);
        }

        private void AddRoomIdColumn(DataGridView dataGrid)
        {
            DataGridViewTextBoxColumn roomIdColumn = new DataGridViewTextBoxColumn();
            roomIdColumn.Name = "RoomId";
            roomIdColumn.HeaderText = "ID";
            roomIdColumn.Visible = false;
            roomIdColumn.ReadOnly = true;
            dataGrid.Columns.Add(roomIdColumn);
        }

        private void AddRoomNumberColumn(DataGridView dataGrid)
        {
            DataGridViewTextBoxColumn roomNumberColumn = new DataGridViewTextBoxColumn();
            roomNumberColumn.Name = "RoomNumber";
            roomNumberColumn.HeaderText = "Room #";
            roomNumberColumn.FillWeight = 12;
            roomNumberColumn.ReadOnly = true;
            dataGrid.Columns.Add(roomNumberColumn);
        }

        private void AddTypeColumn(DataGridView dataGrid)
        {
            DataGridViewTextBoxColumn typeColumn = new DataGridViewTextBoxColumn();
            typeColumn.Name = "Type";
            typeColumn.HeaderText = "Type";
            typeColumn.FillWeight = 15;
            typeColumn.ReadOnly = true;
            dataGrid.Columns.Add(typeColumn);
        }

        private void AddFloorColumn(DataGridView dataGrid)
        {
            DataGridViewTextBoxColumn floorColumn = new DataGridViewTextBoxColumn();
            floorColumn.Name = "Floor";
            floorColumn.HeaderText = "Floor";
            floorColumn.FillWeight = 10;
            floorColumn.ReadOnly = true;
            dataGrid.Columns.Add(floorColumn);
        }

        private void AddViewColumn(DataGridView dataGrid)
        {
            DataGridViewTextBoxColumn viewColumn = new DataGridViewTextBoxColumn();
            viewColumn.Name = "View";
            viewColumn.HeaderText = "View";
            viewColumn.FillWeight = 15;
            viewColumn.ReadOnly = true;
            dataGrid.Columns.Add(viewColumn);
        }

        private void AddStatusColumn(DataGridView dataGrid)
        {
            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
            statusColumn.Name = "Status";
            statusColumn.HeaderText = "Status";
            statusColumn.FillWeight = 20;
            statusColumn.ReadOnly = true;
            dataGrid.Columns.Add(statusColumn);
        }

        private void AddRateColumn(DataGridView dataGrid)
        {
            DataGridViewTextBoxColumn rateColumn = new DataGridViewTextBoxColumn();
            rateColumn.Name = "Rate";
            rateColumn.HeaderText = "Rate/Night";
            rateColumn.FillWeight = 20;
            rateColumn.ReadOnly = true;
            dataGrid.Columns.Add(rateColumn);
        }

        public void DisplayRoomsInGrid(DataGridView dataGrid, List<Room> rooms)
        {
            dataGrid.Rows.Clear();

            foreach (var room in rooms)
            {
                int rowIndex = dataGrid.Rows.Add();
                dataGrid.Rows[rowIndex].Cells["Select"].Value = false;
                dataGrid.Rows[rowIndex].Cells["RoomId"].Value = room.RoomId;
                dataGrid.Rows[rowIndex].Cells["RoomNumber"].Value = room.RoomNumber;
                dataGrid.Rows[rowIndex].Cells["Type"].Value = room.RoomTypeName ?? "N/A";
                dataGrid.Rows[rowIndex].Cells["Floor"].Value = room.Floor;
                dataGrid.Rows[rowIndex].Cells["View"].Value = room.ViewName ?? "N/A";
                dataGrid.Rows[rowIndex].Cells["Status"].Value = room.StatusName ?? "N/A";
                dataGrid.Rows[rowIndex].Cells["Rate"].Value = FormatCurrency(room.BaseRate);
            }
        }

        private string FormatCurrency(decimal amount)
        {
            return $"₱{amount:N2}";
        }
    }
}