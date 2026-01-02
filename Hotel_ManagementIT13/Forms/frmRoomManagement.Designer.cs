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
            this.dgvRooms.Location = new System.Drawing.Point(40, 160);
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.ReadOnly = true;
            this.dgvRooms.RowHeadersWidth = 51;
            this.dgvRooms.RowTemplate.Height = 30;
            this.dgvRooms.Size = new System.Drawing.Size(900, 500);
            this.dgvRooms.TabIndex = 0;
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
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(40, 40);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(400, 34);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.Text = "Search rooms...";
            // 
            // cmbFilterStatus
            // 
            this.cmbFilterStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterStatus.FormattingEnabled = true;
            this.cmbFilterStatus.Location = new System.Drawing.Point(460, 40);
            this.cmbFilterStatus.Name = "cmbFilterStatus";
            this.cmbFilterStatus.Size = new System.Drawing.Size(200, 37);
            this.cmbFilterStatus.TabIndex = 6;
            this.cmbFilterStatus.Text = "Filter by Status";
            // 
            // cmbFilterType
            // 
            this.cmbFilterType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterType.FormattingEnabled = true;
            this.cmbFilterType.Location = new System.Drawing.Point(680, 40);
            this.cmbFilterType.Name = "cmbFilterType";
            this.cmbFilterType.Size = new System.Drawing.Size(200, 37);
            this.cmbFilterType.TabIndex = 7;
            this.cmbFilterType.Text = "Filter by Type";
            // 
            // cmbFilterView
            // 
            this.cmbFilterView.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterView.FormattingEnabled = true;
            this.cmbFilterView.Location = new System.Drawing.Point(900, 40);
            this.cmbFilterView.Name = "cmbFilterView";
            this.cmbFilterView.Size = new System.Drawing.Size(200, 37);
            this.cmbFilterView.TabIndex = 8;
            this.cmbFilterView.Text = "Filter by View";
            // 
            // pnlRoomDetails
            // 
            this.pnlRoomDetails.BackColor = System.Drawing.SystemColors.ControlLight;
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
            // 
            // cmbRoomType
            // 
            this.cmbRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoomType.FormattingEnabled = true;
            this.cmbRoomType.Location = new System.Drawing.Point(1220, 480);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(200, 37);
            this.cmbRoomType.TabIndex = 11;
            this.cmbRoomType.Text = "Room Type";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(1440, 480);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(200, 37);
            this.cmbStatus.TabIndex = 12;
            this.cmbStatus.Text = "Status";
            // 
            // cmbView
            // 
            this.cmbView.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbView.FormattingEnabled = true;
            this.cmbView.Location = new System.Drawing.Point(1660, 480);
            this.cmbView.Name = "cmbView";
            this.cmbView.Size = new System.Drawing.Size(200, 37);
            this.cmbView.TabIndex = 13;
            this.cmbView.Text = "View";
            // 
            // nudFloor
            // 
            this.nudFloor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudFloor.Location = new System.Drawing.Point(1000, 540);
            this.nudFloor.Name = "nudFloor";
            this.nudFloor.Size = new System.Drawing.Size(200, 34);
            this.nudFloor.TabIndex = 14;
            // 
            // clbAmenities
            // 
            this.clbAmenities.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbAmenities.FormattingEnabled = true;
            this.clbAmenities.Location = new System.Drawing.Point(1220, 540);
            this.clbAmenities.Name = "clbAmenities";
            this.clbAmenities.Size = new System.Drawing.Size(640, 120);
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
            this.btnSaveRoom.Location = new System.Drawing.Point(40, 680);
            this.btnSaveRoom.Name = "btnSaveRoom";
            this.btnSaveRoom.Size = new System.Drawing.Size(300, 50);
            this.btnSaveRoom.TabIndex = 17;
            this.btnSaveRoom.Text = "SAVE CHANGES";
            this.btnSaveRoom.UseVisualStyleBackColor = true;
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelEdit.Location = new System.Drawing.Point(40, 750);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(300, 50);
            this.btnCancelEdit.TabIndex = 18;
            this.btnCancelEdit.Text = "CANCEL";
            this.btnCancelEdit.UseVisualStyleBackColor = true;
            // 
            // frmRoomManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 960);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRooms;
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
    }
}