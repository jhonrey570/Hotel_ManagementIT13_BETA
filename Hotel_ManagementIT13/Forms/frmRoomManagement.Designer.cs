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
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblBeds = new System.Windows.Forms.Label();
            this.lblRooms = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblRoomCount = new System.Windows.Forms.Label();
            this.dgvBeds = new System.Windows.Forms.DataGridView();
            this.colBedType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRoomNumber = new System.Windows.Forms.TextBox();
            this.cmbRoomType = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbView = new System.Windows.Forms.ComboBox();
            this.nudFloor = new System.Windows.Forms.NumericUpDown();
            this.clbAmenities = new System.Windows.Forms.CheckedListBox();
            this.btnSaveRoom = new System.Windows.Forms.Button();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.btnViewStatistics = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAmenities = new System.Windows.Forms.Label();
            this.lblFloor = new System.Windows.Forms.Label();
            this.lblStats = new System.Windows.Forms.Label();
            this.lblView = new System.Windows.Forms.Label();
            this.lblRoomNum = new System.Windows.Forms.Label();
            this.lblRoomDet = new System.Windows.Forms.Label();
            this.lblRoomTypes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            this.pnlRoomDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFloor)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRooms
            // 
            this.dgvRooms.AllowUserToAddRows = false;
            this.dgvRooms.AllowUserToDeleteRows = false;
            this.dgvRooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRooms.BackgroundColor = System.Drawing.Color.GhostWhite;
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
            this.dgvRooms.Location = new System.Drawing.Point(3, 201);
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.ReadOnly = true;
            this.dgvRooms.RowHeadersWidth = 51;
            this.dgvRooms.RowTemplate.Height = 30;
            this.dgvRooms.Size = new System.Drawing.Size(1123, 421);
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
            this.btnAddRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRoom.BackColor = System.Drawing.Color.Green;
            this.btnAddRoom.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRoom.ForeColor = System.Drawing.Color.White;
            this.btnAddRoom.Location = new System.Drawing.Point(352, 442);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(200, 50);
            this.btnAddRoom.TabIndex = 1;
            this.btnAddRoom.Text = "ADD ROOM";
            this.btnAddRoom.UseVisualStyleBackColor = false;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // btnEditRoom
            // 
            this.btnEditRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditRoom.BackColor = System.Drawing.Color.Blue;
            this.btnEditRoom.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditRoom.ForeColor = System.Drawing.Color.White;
            this.btnEditRoom.Location = new System.Drawing.Point(352, 498);
            this.btnEditRoom.Name = "btnEditRoom";
            this.btnEditRoom.Size = new System.Drawing.Size(200, 50);
            this.btnEditRoom.TabIndex = 2;
            this.btnEditRoom.Text = "EDIT ROOM";
            this.btnEditRoom.UseVisualStyleBackColor = false;
            this.btnEditRoom.Click += new System.EventHandler(this.btnEditRoom_Click);
            // 
            // btnDeleteRoom
            // 
            this.btnDeleteRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteRoom.BackColor = System.Drawing.Color.Red;
            this.btnDeleteRoom.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteRoom.ForeColor = System.Drawing.Color.White;
            this.btnDeleteRoom.Location = new System.Drawing.Point(558, 498);
            this.btnDeleteRoom.Name = "btnDeleteRoom";
            this.btnDeleteRoom.Size = new System.Drawing.Size(200, 50);
            this.btnDeleteRoom.TabIndex = 3;
            this.btnDeleteRoom.Text = "DELETE ROOM";
            this.btnDeleteRoom.UseVisualStyleBackColor = false;
            this.btnDeleteRoom.Click += new System.EventHandler(this.btnDeleteRoom_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.Violet;
            this.btnRefresh.BackgroundImage = global::Hotel_ManagementIT13.Properties.Resources.refresh_page_option;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(352, 610);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(50, 50);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtSearch.Location = new System.Drawing.Point(3, 61);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(1121, 36);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Search rooms...";
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // cmbFilterStatus
            // 
            this.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterStatus.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterStatus.FormattingEnabled = true;
            this.cmbFilterStatus.Location = new System.Drawing.Point(314, 131);
            this.cmbFilterStatus.Name = "cmbFilterStatus";
            this.cmbFilterStatus.Size = new System.Drawing.Size(300, 36);
            this.cmbFilterStatus.TabIndex = 6;
            this.cmbFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cmbFilterStatus_SelectedIndexChanged);
            // 
            // cmbFilterType
            // 
            this.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterType.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterType.FormattingEnabled = true;
            this.cmbFilterType.Location = new System.Drawing.Point(620, 131);
            this.cmbFilterType.Name = "cmbFilterType";
            this.cmbFilterType.Size = new System.Drawing.Size(300, 36);
            this.cmbFilterType.TabIndex = 7;
            this.cmbFilterType.SelectedIndexChanged += new System.EventHandler(this.cmbFilterType_SelectedIndexChanged);
            // 
            // cmbFilterView
            // 
            this.cmbFilterView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterView.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterView.FormattingEnabled = true;
            this.cmbFilterView.Location = new System.Drawing.Point(8, 131);
            this.cmbFilterView.Name = "cmbFilterView";
            this.cmbFilterView.Size = new System.Drawing.Size(300, 36);
            this.cmbFilterView.TabIndex = 8;
            this.cmbFilterView.SelectedIndexChanged += new System.EventHandler(this.cmbFilterView_SelectedIndexChanged);
            // 
            // pnlRoomDetails
            // 
            this.pnlRoomDetails.BackColor = System.Drawing.Color.White;
            this.pnlRoomDetails.Controls.Add(this.lblFilter);
            this.pnlRoomDetails.Controls.Add(this.lblBeds);
            this.pnlRoomDetails.Controls.Add(this.lblRooms);
            this.pnlRoomDetails.Controls.Add(this.btnSearch);
            this.pnlRoomDetails.Controls.Add(this.dgvRooms);
            this.pnlRoomDetails.Controls.Add(this.lblRoomCount);
            this.pnlRoomDetails.Controls.Add(this.dgvBeds);
            this.pnlRoomDetails.Controls.Add(this.txtSearch);
            this.pnlRoomDetails.Controls.Add(this.cmbFilterView);
            this.pnlRoomDetails.Controls.Add(this.cmbFilterStatus);
            this.pnlRoomDetails.Controls.Add(this.cmbFilterType);
            this.pnlRoomDetails.Location = new System.Drawing.Point(12, 12);
            this.pnlRoomDetails.Name = "pnlRoomDetails";
            this.pnlRoomDetails.Size = new System.Drawing.Size(1129, 936);
            this.pnlRoomDetails.TabIndex = 9;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.BackColor = System.Drawing.Color.White;
            this.lblFilter.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.Location = new System.Drawing.Point(3, 100);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(75, 28);
            this.lblFilter.TabIndex = 37;
            this.lblFilter.Text = "Filters:";
            // 
            // lblBeds
            // 
            this.lblBeds.AutoSize = true;
            this.lblBeds.BackColor = System.Drawing.Color.White;
            this.lblBeds.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeds.Location = new System.Drawing.Point(3, 625);
            this.lblBeds.Name = "lblBeds";
            this.lblBeds.Size = new System.Drawing.Size(57, 28);
            this.lblBeds.TabIndex = 29;
            this.lblBeds.Text = "Beds";
            // 
            // lblRooms
            // 
            this.lblRooms.AutoSize = true;
            this.lblRooms.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRooms.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblRooms.Location = new System.Drawing.Point(3, 3);
            this.lblRooms.Name = "lblRooms";
            this.lblRooms.Size = new System.Drawing.Size(95, 27);
            this.lblRooms.TabIndex = 28;
            this.lblRooms.Text = "Rooms";
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = global::Hotel_ManagementIT13.Properties.Resources.people;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(1091, 64);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(30, 30);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblRoomCount
            // 
            this.lblRoomCount.AutoSize = true;
            this.lblRoomCount.BackColor = System.Drawing.Color.White;
            this.lblRoomCount.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomCount.Location = new System.Drawing.Point(3, 170);
            this.lblRoomCount.Name = "lblRoomCount";
            this.lblRoomCount.Size = new System.Drawing.Size(162, 28);
            this.lblRoomCount.TabIndex = 19;
            this.lblRoomCount.Text = "0 room(s) found";
            // 
            // dgvBeds
            // 
            this.dgvBeds.AllowUserToAddRows = false;
            this.dgvBeds.AllowUserToDeleteRows = false;
            this.dgvBeds.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBeds.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvBeds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBeds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBedType,
            this.colQuantity});
            this.dgvBeds.Location = new System.Drawing.Point(3, 656);
            this.dgvBeds.Name = "dgvBeds";
            this.dgvBeds.ReadOnly = true;
            this.dgvBeds.RowHeadersWidth = 51;
            this.dgvBeds.RowTemplate.Height = 30;
            this.dgvBeds.Size = new System.Drawing.Size(1123, 277);
            this.dgvBeds.TabIndex = 16;
            // 
            // colBedType
            // 
            this.colBedType.HeaderText = "Bed Type";
            this.colBedType.MinimumWidth = 6;
            this.colBedType.Name = "colBedType";
            this.colBedType.ReadOnly = true;
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.MinimumWidth = 6;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            // 
            // txtRoomNumber
            // 
            this.txtRoomNumber.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtRoomNumber.Location = new System.Drawing.Point(3, 160);
            this.txtRoomNumber.Name = "txtRoomNumber";
            this.txtRoomNumber.Size = new System.Drawing.Size(300, 36);
            this.txtRoomNumber.TabIndex = 10;
            this.txtRoomNumber.Text = "Room Number";
            this.txtRoomNumber.Enter += new System.EventHandler(this.txtRoomNumber_Enter);
            this.txtRoomNumber.Leave += new System.EventHandler(this.txtRoomNumber_Leave);
            // 
            // cmbRoomType
            // 
            this.cmbRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoomType.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoomType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbRoomType.FormattingEnabled = true;
            this.cmbRoomType.Location = new System.Drawing.Point(3, 90);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(300, 36);
            this.cmbRoomType.TabIndex = 11;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(3, 300);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(300, 36);
            this.cmbStatus.TabIndex = 12;
            // 
            // cmbView
            // 
            this.cmbView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbView.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbView.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbView.FormattingEnabled = true;
            this.cmbView.Location = new System.Drawing.Point(3, 230);
            this.cmbView.Name = "cmbView";
            this.cmbView.Size = new System.Drawing.Size(300, 36);
            this.cmbView.TabIndex = 13;
            // 
            // nudFloor
            // 
            this.nudFloor.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudFloor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.nudFloor.Location = new System.Drawing.Point(3, 370);
            this.nudFloor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFloor.Name = "nudFloor";
            this.nudFloor.Size = new System.Drawing.Size(300, 36);
            this.nudFloor.TabIndex = 14;
            this.nudFloor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // clbAmenities
            // 
            this.clbAmenities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbAmenities.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbAmenities.FormattingEnabled = true;
            this.clbAmenities.Location = new System.Drawing.Point(3, 440);
            this.clbAmenities.Name = "clbAmenities";
            this.clbAmenities.Size = new System.Drawing.Size(343, 221);
            this.clbAmenities.TabIndex = 15;
            // 
            // btnSaveRoom
            // 
            this.btnSaveRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveRoom.BackColor = System.Drawing.Color.Orange;
            this.btnSaveRoom.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveRoom.ForeColor = System.Drawing.Color.White;
            this.btnSaveRoom.Location = new System.Drawing.Point(558, 442);
            this.btnSaveRoom.Name = "btnSaveRoom";
            this.btnSaveRoom.Size = new System.Drawing.Size(200, 50);
            this.btnSaveRoom.TabIndex = 17;
            this.btnSaveRoom.Text = "SAVE ROOM";
            this.btnSaveRoom.UseVisualStyleBackColor = false;
            this.btnSaveRoom.Click += new System.EventHandler(this.btnSaveRoom_Click);
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelEdit.BackColor = System.Drawing.Color.Red;
            this.btnCancelEdit.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelEdit.ForeColor = System.Drawing.Color.White;
            this.btnCancelEdit.Location = new System.Drawing.Point(558, 554);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(200, 50);
            this.btnCancelEdit.TabIndex = 18;
            this.btnCancelEdit.Text = "CANCEL";
            this.btnCancelEdit.UseVisualStyleBackColor = false;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);
            // 
            // btnViewStatistics
            // 
            this.btnViewStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewStatistics.BackColor = System.Drawing.Color.Gray;
            this.btnViewStatistics.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewStatistics.ForeColor = System.Drawing.Color.White;
            this.btnViewStatistics.Location = new System.Drawing.Point(352, 554);
            this.btnViewStatistics.Name = "btnViewStatistics";
            this.btnViewStatistics.Size = new System.Drawing.Size(200, 50);
            this.btnViewStatistics.TabIndex = 21;
            this.btnViewStatistics.Text = "VIEW STATISTICS";
            this.btnViewStatistics.UseVisualStyleBackColor = false;
            this.btnViewStatistics.Click += new System.EventHandler(this.btnViewStatistics_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblAmenities);
            this.panel1.Controls.Add(this.lblFloor);
            this.panel1.Controls.Add(this.clbAmenities);
            this.panel1.Controls.Add(this.btnViewStatistics);
            this.panel1.Controls.Add(this.lblStats);
            this.panel1.Controls.Add(this.btnCancelEdit);
            this.panel1.Controls.Add(this.lblView);
            this.panel1.Controls.Add(this.btnSaveRoom);
            this.panel1.Controls.Add(this.txtRoomNumber);
            this.panel1.Controls.Add(this.btnEditRoom);
            this.panel1.Controls.Add(this.lblRoomNum);
            this.panel1.Controls.Add(this.btnDeleteRoom);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.lblRoomDet);
            this.panel1.Controls.Add(this.lblRoomTypes);
            this.panel1.Controls.Add(this.cmbRoomType);
            this.panel1.Controls.Add(this.btnAddRoom);
            this.panel1.Controls.Add(this.cmbStatus);
            this.panel1.Controls.Add(this.cmbView);
            this.panel1.Controls.Add(this.nudFloor);
            this.panel1.Location = new System.Drawing.Point(1147, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 665);
            this.panel1.TabIndex = 22;
            // 
            // lblAmenities
            // 
            this.lblAmenities.AutoSize = true;
            this.lblAmenities.BackColor = System.Drawing.Color.White;
            this.lblAmenities.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmenities.Location = new System.Drawing.Point(3, 409);
            this.lblAmenities.Name = "lblAmenities";
            this.lblAmenities.Size = new System.Drawing.Size(164, 28);
            this.lblAmenities.TabIndex = 37;
            this.lblAmenities.Text = "Room Amenites:";
            // 
            // lblFloor
            // 
            this.lblFloor.AutoSize = true;
            this.lblFloor.BackColor = System.Drawing.Color.White;
            this.lblFloor.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFloor.Location = new System.Drawing.Point(3, 339);
            this.lblFloor.Name = "lblFloor";
            this.lblFloor.Size = new System.Drawing.Size(147, 28);
            this.lblFloor.TabIndex = 36;
            this.lblFloor.Text = "Floor Number:";
            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.BackColor = System.Drawing.Color.White;
            this.lblStats.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStats.Location = new System.Drawing.Point(3, 269);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(136, 28);
            this.lblStats.TabIndex = 35;
            this.lblStats.Text = "Room Status:";
            // 
            // lblView
            // 
            this.lblView.AutoSize = true;
            this.lblView.BackColor = System.Drawing.Color.White;
            this.lblView.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblView.Location = new System.Drawing.Point(3, 199);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(122, 28);
            this.lblView.TabIndex = 34;
            this.lblView.Text = "Room View:";
            // 
            // lblRoomNum
            // 
            this.lblRoomNum.AutoSize = true;
            this.lblRoomNum.BackColor = System.Drawing.Color.White;
            this.lblRoomNum.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomNum.Location = new System.Drawing.Point(3, 129);
            this.lblRoomNum.Name = "lblRoomNum";
            this.lblRoomNum.Size = new System.Drawing.Size(153, 28);
            this.lblRoomNum.TabIndex = 33;
            this.lblRoomNum.Text = "Room Number:";
            // 
            // lblRoomDet
            // 
            this.lblRoomDet.AutoSize = true;
            this.lblRoomDet.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomDet.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblRoomDet.Location = new System.Drawing.Point(3, 4);
            this.lblRoomDet.Name = "lblRoomDet";
            this.lblRoomDet.Size = new System.Drawing.Size(178, 27);
            this.lblRoomDet.TabIndex = 31;
            this.lblRoomDet.Text = "Room Details ";
            // 
            // lblRoomTypes
            // 
            this.lblRoomTypes.AutoSize = true;
            this.lblRoomTypes.BackColor = System.Drawing.Color.White;
            this.lblRoomTypes.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomTypes.Location = new System.Drawing.Point(3, 59);
            this.lblRoomTypes.Name = "lblRoomTypes";
            this.lblRoomTypes.Size = new System.Drawing.Size(129, 28);
            this.lblRoomTypes.TabIndex = 30;
            this.lblRoomTypes.Text = "Room Types:";
            // 
            // frmRoomManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1920, 960);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlRoomDetails);
            this.Name = "frmRoomManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Management System - Room Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRoomManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            this.pnlRoomDetails.ResumeLayout(false);
            this.pnlRoomDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFloor)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label lblRooms;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBeds;
        private System.Windows.Forms.Label lblRoomDet;
        private System.Windows.Forms.Label lblRoomTypes;
        private System.Windows.Forms.Label lblRoomNum;
        private System.Windows.Forms.Label lblView;
        private System.Windows.Forms.Label lblFloor;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblAmenities;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBedType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
    }
}