namespace Hotel_ManagementIT13.Forms
{
    partial class frmRoomManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.colRoomId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoomNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoomType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFloor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBaseRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaxOccupancy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.btnEditRoom = new System.Windows.Forms.Button();
            this.btnDeleteRoom = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbFilterStatus = new System.Windows.Forms.ComboBox();
            this.cmbFilterType = new System.Windows.Forms.ComboBox();
            this.cmbFilterView = new System.Windows.Forms.ComboBox();
            this.pnlRoomDetails = new System.Windows.Forms.Panel();
            this.txtRoomNumber = new System.Windows.Forms.TextBox();
            this.cmbRoomType = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbView = new System.Windows.Forms.ComboBox();
            this.nudFloor = new System.Windows.Forms.NumericUpDown();
            this.clbAmenities = new System.Windows.Forms.CheckedListBox();
            this.dgvBeds = new System.Windows.Forms.DataGridView();
            this.btnSaveRoom = new System.Windows.Forms.Button();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.lblRoomCount = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnViewStatistics = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeds)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRooms
            // 
            this.dgvRooms.AllowUserToAddRows = false;
            this.dgvRooms.AllowUserToDeleteRows = false;
            this.dgvRooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRooms.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRooms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRoomId,
            this.colRoomNumber,
            this.colRoomType,
            this.colFloor,
            this.colStatus,
            this.colView,
            this.colBaseRate,
            this.colMaxOccupancy});
            this.dgvRooms.Location = new System.Drawing.Point(40, 160);
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.ReadOnly = true;
            this.dgvRooms.RowHeadersWidth = 51;
            this.dgvRooms.RowTemplate.Height = 30;
            this.dgvRooms.Size = new System.Drawing.Size(900, 500);
            this.dgvRooms.TabIndex = 0;
            this.dgvRooms.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRooms_CellClick);
            // 
            // colRoomId
            // 
            this.colRoomId.DataPropertyName = "RoomId";
            this.colRoomId.HeaderText = "ID";
            this.colRoomId.MinimumWidth = 6;
            this.colRoomId.Name = "colRoomId";
            this.colRoomId.ReadOnly = true;
            this.colRoomId.Visible = false;
            // 
            // colRoomNumber
            // 
            this.colRoomNumber.DataPropertyName = "RoomNumber";
            this.colRoomNumber.HeaderText = "Room Number";
            this.colRoomNumber.MinimumWidth = 6;
            this.colRoomNumber.Name = "colRoomNumber";
            this.colRoomNumber.ReadOnly = true;
            // 
            // colRoomType
            // 
            this.colRoomType.DataPropertyName = "RoomTypeName";
            this.colRoomType.HeaderText = "Room Type";
            this.colRoomType.MinimumWidth = 6;
            this.colRoomType.Name = "colRoomType";
            this.colRoomType.ReadOnly = true;
            // 
            // colFloor
            // 
            this.colFloor.DataPropertyName = "Floor";
            this.colFloor.HeaderText = "Floor";
            this.colFloor.MinimumWidth = 6;
            this.colFloor.Name = "colFloor";
            this.colFloor.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "StatusName";
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 6;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colView
            // 
            this.colView.DataPropertyName = "ViewName";
            this.colView.HeaderText = "View";
            this.colView.MinimumWidth = 6;
            this.colView.Name = "colView";
            this.colView.ReadOnly = true;
            // 
            // colBaseRate
            // 
            this.colBaseRate.DataPropertyName = "BaseRate";
            this.colBaseRate.HeaderText = "Base Rate";
            this.colBaseRate.MinimumWidth = 6;
            this.colBaseRate.Name = "colBaseRate";
            this.colBaseRate.ReadOnly = true;
            // 
            // colMaxOccupancy
            // 
            this.colMaxOccupancy.DataPropertyName = "MaxOccupancy";
            this.colMaxOccupancy.HeaderText = "Max Occupancy";
            this.colMaxOccupancy.MinimumWidth = 6;
            this.colMaxOccupancy.Name = "colMaxOccupancy";
            this.colMaxOccupancy.ReadOnly = true;
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRoom.Location = new System.Drawing.Point(40, 90);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(180, 50);
            this.btnAddRoom.TabIndex = 1;
            this.btnAddRoom.Text = "ADD ROOM";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // btnEditRoom
            // 
            this.btnEditRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditRoom.Location = new System.Drawing.Point(240, 90);
            this.btnEditRoom.Name = "btnEditRoom";
            this.btnEditRoom.Size = new System.Drawing.Size(180, 50);
            this.btnEditRoom.TabIndex = 2;
            this.btnEditRoom.Text = "EDIT ROOM";
            this.btnEditRoom.UseVisualStyleBackColor = true;
            this.btnEditRoom.Click += new System.EventHandler(this.btnEditRoom_Click);
            // 
            // btnDeleteRoom
            // 
            this.btnDeleteRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteRoom.Location = new System.Drawing.Point(440, 90);
            this.btnDeleteRoom.Name = "btnDeleteRoom";
            this.btnDeleteRoom.Size = new System.Drawing.Size(180, 50);
            this.btnDeleteRoom.TabIndex = 3;
            this.btnDeleteRoom.Text = "DELETE ROOM";
            this.btnDeleteRoom.UseVisualStyleBackColor = true;
            this.btnDeleteRoom.Click += new System.EventHandler(this.btnDeleteRoom_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(640, 90);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(180, 50);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(40, 40);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(400, 34);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Search rooms...";
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // cmbFilterStatus
            // 
            this.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterStatus.FormattingEnabled = true;
            this.cmbFilterStatus.Location = new System.Drawing.Point(460, 40);
            this.cmbFilterStatus.Name = "cmbFilterStatus";
            this.cmbFilterStatus.Size = new System.Drawing.Size(200, 37);
            this.cmbFilterStatus.TabIndex = 6;
            this.cmbFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cmbFilterStatus_SelectedIndexChanged);
            // 
            // cmbFilterType
            // 
            this.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterType.FormattingEnabled = true;
            this.cmbFilterType.Location = new System.Drawing.Point(680, 40);
            this.cmbFilterType.Name = "cmbFilterType";
            this.cmbFilterType.Size = new System.Drawing.Size(200, 37);
            this.cmbFilterType.TabIndex = 7;
            this.cmbFilterType.SelectedIndexChanged += new System.EventHandler(this.cmbFilterType_SelectedIndexChanged);
            // 
            // cmbFilterView
            // 
            this.cmbFilterView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterView.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterView.FormattingEnabled = true;
            this.cmbFilterView.Location = new System.Drawing.Point(900, 40);
            this.cmbFilterView.Name = "cmbFilterView";
            this.cmbFilterView.Size = new System.Drawing.Size(200, 37);
            this.cmbFilterView.TabIndex = 8;
            this.cmbFilterView.SelectedIndexChanged += new System.EventHandler(this.cmbFilterView_SelectedIndexChanged);
            // 
            // pnlRoomDetails
            // 
            this.pnlRoomDetails.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlRoomDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRoomDetails.Location = new System.Drawing.Point(1000, 160);
            this.pnlRoomDetails.Name = "pnlRoomDetails";
            this.pnlRoomDetails.Size = new System.Drawing.Size(880, 300);
            this.pnlRoomDetails.TabIndex = 9;
            // 
            // txtRoomNumber
            // 
            this.txtRoomNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomNumber.Location = new System.Drawing.Point(1000, 480);
            this.txtRoomNumber.Name = "txtRoomNumber";
            this.txtRoomNumber.Size = new System.Drawing.Size(200, 34);
            this.txtRoomNumber.TabIndex = 10;
            this.txtRoomNumber.Text = "Room Number";
            this.txtRoomNumber.Enter += new System.EventHandler(this.txtRoomNumber_Enter);
            this.txtRoomNumber.Leave += new System.EventHandler(this.txtRoomNumber_Leave);
            // 
            // cmbRoomType
            // 
            this.cmbRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoomType.FormattingEnabled = true;
            this.cmbRoomType.Location = new System.Drawing.Point(1220, 480);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(200, 37);
            this.cmbRoomType.TabIndex = 11;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(1440, 480);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(200, 37);
            this.cmbStatus.TabIndex = 12;
            // 
            // cmbView
            // 
            this.cmbView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbView.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbView.FormattingEnabled = true;
            this.cmbView.Location = new System.Drawing.Point(1660, 480);
            this.cmbView.Name = "cmbView";
            this.cmbView.Size = new System.Drawing.Size(200, 37);
            this.cmbView.TabIndex = 13;
            // 
            // nudFloor
            // 
            this.nudFloor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudFloor.Location = new System.Drawing.Point(1000, 540);
            this.nudFloor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFloor.Name = "nudFloor";
            this.nudFloor.Size = new System.Drawing.Size(200, 34);
            this.nudFloor.TabIndex = 14;
            this.nudFloor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // clbAmenities
            // 
            this.clbAmenities.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbAmenities.FormattingEnabled = true;
            this.clbAmenities.Location = new System.Drawing.Point(1220, 540);
            this.clbAmenities.Name = "clbAmenities";
            this.clbAmenities.Size = new System.Drawing.Size(640, 104);
            this.clbAmenities.TabIndex = 15;
            // 
            // dgvBeds
            // 
            this.dgvBeds.AllowUserToAddRows = false;
            this.dgvBeds.AllowUserToDeleteRows = false;
            this.dgvBeds.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBeds.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBeds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBeds.Location = new System.Drawing.Point(1000, 680);
            this.dgvBeds.Name = "dgvBeds";
            this.dgvBeds.ReadOnly = true;
            this.dgvBeds.RowHeadersWidth = 51;
            this.dgvBeds.RowTemplate.Height = 30;
            this.dgvBeds.Size = new System.Drawing.Size(880, 220);
            this.dgvBeds.TabIndex = 16;
            // 
            // btnSaveRoom
            // 
            this.btnSaveRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveRoom.Location = new System.Drawing.Point(1000, 800);
            this.btnSaveRoom.Name = "btnSaveRoom";
            this.btnSaveRoom.Size = new System.Drawing.Size(400, 60);
            this.btnSaveRoom.TabIndex = 17;
            this.btnSaveRoom.Text = "SAVE ROOM";
            this.btnSaveRoom.UseVisualStyleBackColor = true;
            this.btnSaveRoom.Click += new System.EventHandler(this.btnSaveRoom_Click);
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelEdit.Location = new System.Drawing.Point(1480, 800);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(400, 60);
            this.btnCancelEdit.TabIndex = 18;
            this.btnCancelEdit.Text = "CANCEL";
            this.btnCancelEdit.UseVisualStyleBackColor = true;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);
            // 
            // lblRoomCount
            // 
            this.lblRoomCount.AutoSize = true;
            this.lblRoomCount.BackColor = System.Drawing.SystemColors.Control;
            this.lblRoomCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomCount.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRoomCount.Location = new System.Drawing.Point(40, 670);
            this.lblRoomCount.Name = "lblRoomCount";
            this.lblRoomCount.Size = new System.Drawing.Size(100, 20);
            this.lblRoomCount.TabIndex = 19;
            this.lblRoomCount.Text = "0 room(s) found";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(1120, 40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 37);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnViewStatistics
            // 
            this.btnViewStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewStatistics.Location = new System.Drawing.Point(40, 750);
            this.btnViewStatistics.Name = "btnViewStatistics";
            this.btnViewStatistics.Size = new System.Drawing.Size(300, 50);
            this.btnViewStatistics.TabIndex = 21;
            this.btnViewStatistics.Text = "VIEW STATISTICS";
            this.btnViewStatistics.UseVisualStyleBackColor = true;
            this.btnViewStatistics.Click += new System.EventHandler(this.btnViewStatistics_Click);
            // 
            // frmRoomManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 960);
            this.Controls.Add(this.btnViewStatistics);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblRoomCount);
            this.Controls.Add(this.btnCancelEdit);
            this.Controls.Add(this.btnSaveRoom);
            this.Controls.Add(this.dgvBeds);
            this.Controls.Add(this.clbAmenities);
            this.Controls.Add(this.nudFloor);
            this.Controls.Add(this.cmbView);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cmbRoomType);
            this.Controls.Add(this.txtRoomNumber);
            this.Controls.Add(this.pnlRoomDetails);
            this.Controls.Add(this.cmbFilterView);
            this.Controls.Add(this.cmbFilterType);
            this.Controls.Add(this.cmbFilterStatus);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDeleteRoom);
            this.Controls.Add(this.btnEditRoom);
            this.Controls.Add(this.btnAddRoom);
            this.Controls.Add(this.dgvRooms);
            this.Name = "frmRoomManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Management System - Room Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRoomManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRooms;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoomId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoomNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoomType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFloor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBaseRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaxOccupancy;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.Button btnEditRoom;
        private System.Windows.Forms.Button btnDeleteRoom;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.ComboBox cmbFilterType;
        private System.Windows.Forms.ComboBox cmbFilterView;
        private System.Windows.Forms.Panel pnlRoomDetails;
        private System.Windows.Forms.TextBox txtRoomNumber;
        private System.Windows.Forms.ComboBox cmbRoomType;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbView;
        private System.Windows.Forms.NumericUpDown nudFloor;
        private System.Windows.Forms.CheckedListBox clbAmenities;
        private System.Windows.Forms.DataGridView dgvBeds;
        private System.Windows.Forms.Button btnSaveRoom;
        private System.Windows.Forms.Button btnCancelEdit;
        private System.Windows.Forms.Label lblRoomCount;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnViewStatistics;
    }
}