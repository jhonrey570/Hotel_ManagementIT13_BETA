namespace Hotel_ManagementIT13.Forms
{
    partial class frmReservation
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
            this.tabReservation = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlGuestInfo = new System.Windows.Forms.Panel();
            this.txtGuestSearch = new System.Windows.Forms.TextBox();
            this.btnSearchGuest = new System.Windows.Forms.Button();
            this.dgvGuestResults = new System.Windows.Forms.DataGridView();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.nudAdults = new System.Windows.Forms.NumericUpDown();
            this.nudChildren = new System.Windows.Forms.NumericUpDown();
            this.cmbRoomType = new System.Windows.Forms.ComboBox();
            this.dgvAvailableRooms = new System.Windows.Forms.DataGridView();
            this.clbSpecialRequests = new System.Windows.Forms.CheckedListBox();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblSearchResults = new System.Windows.Forms.Label();
            this.lblSelectedGuest = new System.Windows.Forms.Label();
            this.lblAvailableRooms = new System.Windows.Forms.Label();
            this.btnNewGuest = new System.Windows.Forms.Button();
            this.tabReservation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuestResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChildren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableRooms)).BeginInit();
            this.SuspendLayout();
            // 
            // tabReservation
            // 
            this.tabReservation.Controls.Add(this.tabPage1);
            this.tabReservation.Controls.Add(this.tabPage2);
            this.tabReservation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tabReservation.Location = new System.Drawing.Point(30, 30);
            this.tabReservation.Name = "tabReservation";
            this.tabReservation.SelectedIndex = 0;
            this.tabReservation.Size = new System.Drawing.Size(600, 350);
            this.tabReservation.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(592, 317);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "New Reservation";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(592, 317);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Reservation History";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlGuestInfo
            // 
            this.pnlGuestInfo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlGuestInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGuestInfo.Location = new System.Drawing.Point(660, 30);
            this.pnlGuestInfo.Name = "pnlGuestInfo";
            this.pnlGuestInfo.Size = new System.Drawing.Size(1150, 160);
            this.pnlGuestInfo.TabIndex = 1;
            // 
            // txtGuestSearch
            // 
            this.txtGuestSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtGuestSearch.Location = new System.Drawing.Point(660, 210);
            this.txtGuestSearch.Name = "txtGuestSearch";
            this.txtGuestSearch.Size = new System.Drawing.Size(850, 28);
            this.txtGuestSearch.TabIndex = 2;
            // 
            // btnSearchGuest
            // 
            this.btnSearchGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnSearchGuest.Location = new System.Drawing.Point(1520, 210);
            this.btnSearchGuest.Name = "btnSearchGuest";
            this.btnSearchGuest.Size = new System.Drawing.Size(140, 35);
            this.btnSearchGuest.TabIndex = 3;
            this.btnSearchGuest.Text = "SEARCH";
            this.btnSearchGuest.UseVisualStyleBackColor = true;
            // 
            // dgvGuestResults
            // 
            this.dgvGuestResults.AllowUserToAddRows = false;
            this.dgvGuestResults.AllowUserToDeleteRows = false;
            this.dgvGuestResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGuestResults.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvGuestResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGuestResults.Location = new System.Drawing.Point(660, 270);
            this.dgvGuestResults.Name = "dgvGuestResults";
            this.dgvGuestResults.ReadOnly = true;
            this.dgvGuestResults.RowHeadersWidth = 51;
            this.dgvGuestResults.RowTemplate.Height = 24;
            this.dgvGuestResults.Size = new System.Drawing.Size(1000, 250);
            this.dgvGuestResults.TabIndex = 4;
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dtpCheckIn.Location = new System.Drawing.Point(30, 410);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(250, 28);
            this.dtpCheckIn.TabIndex = 5;
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dtpCheckOut.Location = new System.Drawing.Point(320, 410);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(250, 28);
            this.dtpCheckOut.TabIndex = 6;
            // 
            // nudAdults
            // 
            this.nudAdults.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.nudAdults.Location = new System.Drawing.Point(30, 480);
            this.nudAdults.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAdults.Name = "nudAdults";
            this.nudAdults.Size = new System.Drawing.Size(100, 28);
            this.nudAdults.TabIndex = 7;
            this.nudAdults.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudChildren
            // 
            this.nudChildren.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.nudChildren.Location = new System.Drawing.Point(170, 480);
            this.nudChildren.Name = "nudChildren";
            this.nudChildren.Size = new System.Drawing.Size(100, 28);
            this.nudChildren.TabIndex = 8;
            // 
            // cmbRoomType
            // 
            this.cmbRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cmbRoomType.FormattingEnabled = true;
            this.cmbRoomType.Location = new System.Drawing.Point(320, 480);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(250, 30);
            this.cmbRoomType.TabIndex = 9;
            // 
            // dgvAvailableRooms
            // 
            this.dgvAvailableRooms.AllowUserToAddRows = false;
            this.dgvAvailableRooms.AllowUserToDeleteRows = false;
            this.dgvAvailableRooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAvailableRooms.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvAvailableRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableRooms.Location = new System.Drawing.Point(30, 550);
            this.dgvAvailableRooms.Name = "dgvAvailableRooms";
            this.dgvAvailableRooms.RowHeadersWidth = 51;
            this.dgvAvailableRooms.RowTemplate.Height = 24;
            this.dgvAvailableRooms.Size = new System.Drawing.Size(600, 280);
            this.dgvAvailableRooms.TabIndex = 10;
            // 
            // clbSpecialRequests
            // 
            this.clbSpecialRequests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.clbSpecialRequests.FormattingEnabled = true;
            this.clbSpecialRequests.Location = new System.Drawing.Point(660, 560);
            this.clbSpecialRequests.Name = "clbSpecialRequests";
            this.clbSpecialRequests.Size = new System.Drawing.Size(350, 250);
            this.clbSpecialRequests.TabIndex = 11;
            // 
            // rtbNotes
            // 
            this.rtbNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rtbNotes.Location = new System.Drawing.Point(1040, 560);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(350, 250);
            this.rtbNotes.TabIndex = 12;
            this.rtbNotes.Text = "";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Green;
            this.lblTotalAmount.Location = new System.Drawing.Point(1430, 560);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(180, 36);
            this.lblTotalAmount.TabIndex = 13;
            this.lblTotalAmount.Text = "Total: $0.00";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnCalculate.Location = new System.Drawing.Point(1430, 620);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(280, 45);
            this.btnCalculate.TabIndex = 14;
            this.btnCalculate.Text = "CALCULATE";
            this.btnCalculate.UseVisualStyleBackColor = true;
            // 
            // btnBook
            // 
            this.btnBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnBook.Location = new System.Drawing.Point(1430, 680);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(280, 45);
            this.btnBook.TabIndex = 15;
            this.btnBook.Text = "BOOK NOW";
            this.btnBook.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnCancel.Location = new System.Drawing.Point(1430, 740);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 45);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnPrint.Location = new System.Drawing.Point(1580, 740);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(130, 45);
            this.btnPrint.TabIndex = 17;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // lblSearchResults
            // 
            this.lblSearchResults.AutoSize = true;
            this.lblSearchResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblSearchResults.Location = new System.Drawing.Point(660, 530);
            this.lblSearchResults.Name = "lblSearchResults";
            this.lblSearchResults.Size = new System.Drawing.Size(120, 20);
            this.lblSearchResults.TabIndex = 18;
            this.lblSearchResults.Text = "Found 0 guests";
            // 
            // lblSelectedGuest
            // 
            this.lblSelectedGuest.AutoSize = true;
            this.lblSelectedGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblSelectedGuest.ForeColor = System.Drawing.Color.Red;
            this.lblSelectedGuest.Location = new System.Drawing.Point(660, 240);
            this.lblSelectedGuest.Name = "lblSelectedGuest";
            this.lblSelectedGuest.Size = new System.Drawing.Size(136, 20);
            this.lblSelectedGuest.TabIndex = 19;
            this.lblSelectedGuest.Text = "No guest selected";
            // 
            // lblAvailableRooms
            // 
            this.lblAvailableRooms.AutoSize = true;
            this.lblAvailableRooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblAvailableRooms.Location = new System.Drawing.Point(30, 530);
            this.lblAvailableRooms.Name = "lblAvailableRooms";
            this.lblAvailableRooms.Size = new System.Drawing.Size(125, 20);
            this.lblAvailableRooms.TabIndex = 20;
            this.lblAvailableRooms.Text = "Available rooms";
            // 
            // btnNewGuest
            // 
            this.btnNewGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnNewGuest.Location = new System.Drawing.Point(1680, 210);
            this.btnNewGuest.Name = "btnNewGuest";
            this.btnNewGuest.Size = new System.Drawing.Size(130, 35);
            this.btnNewGuest.TabIndex = 21;
            this.btnNewGuest.Text = "NEW GUEST";
            this.btnNewGuest.UseVisualStyleBackColor = true;
            // 
            // frmReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1850, 870);
            this.Controls.Add(this.btnNewGuest);
            this.Controls.Add(this.lblAvailableRooms);
            this.Controls.Add(this.lblSelectedGuest);
            this.Controls.Add(this.lblSearchResults);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.clbSpecialRequests);
            this.Controls.Add(this.dgvAvailableRooms);
            this.Controls.Add(this.cmbRoomType);
            this.Controls.Add(this.nudChildren);
            this.Controls.Add(this.nudAdults);
            this.Controls.Add(this.dtpCheckOut);
            this.Controls.Add(this.dtpCheckIn);
            this.Controls.Add(this.dgvGuestResults);
            this.Controls.Add(this.btnSearchGuest);
            this.Controls.Add(this.txtGuestSearch);
            this.Controls.Add(this.pnlGuestInfo);
            this.Controls.Add(this.tabReservation);
            this.Name = "frmReservation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Management System - Reservations";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReservation_Load);
            this.tabReservation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuestResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChildren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableRooms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabReservation;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pnlGuestInfo;
        private System.Windows.Forms.TextBox txtGuestSearch;
        private System.Windows.Forms.Button btnSearchGuest;
        private System.Windows.Forms.DataGridView dgvGuestResults;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.NumericUpDown nudAdults;
        private System.Windows.Forms.NumericUpDown nudChildren;
        private System.Windows.Forms.ComboBox cmbRoomType;
        private System.Windows.Forms.DataGridView dgvAvailableRooms;
        private System.Windows.Forms.CheckedListBox clbSpecialRequests;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblSearchResults;
        private System.Windows.Forms.Label lblSelectedGuest;
        private System.Windows.Forms.Label lblAvailableRooms;
        private System.Windows.Forms.Button btnNewGuest;
    }
}