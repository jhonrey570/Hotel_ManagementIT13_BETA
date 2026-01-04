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
            this.btnNewGuest = new System.Windows.Forms.Button();
            this.lblAvailableRooms = new System.Windows.Forms.Label();
            this.lblSelectedGuest = new System.Windows.Forms.Label();
            this.lblSearchResults = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.clbSpecialRequests = new System.Windows.Forms.CheckedListBox();
            this.dgvAvailableRooms = new System.Windows.Forms.DataGridView();
            this.cmbRoomType = new System.Windows.Forms.ComboBox();
            this.nudChildren = new System.Windows.Forms.NumericUpDown();
            this.nudAdults = new System.Windows.Forms.NumericUpDown();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.dgvGuestResults = new System.Windows.Forms.DataGridView();
            this.btnSearchGuest = new System.Windows.Forms.Button();
            this.txtGuestSearch = new System.Windows.Forms.TextBox();
            this.pnlGuestInfo = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabReservation.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChildren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuestResults)).BeginInit();
            this.SuspendLayout();
            // 
            // tabReservation
            // 
            this.tabReservation.Controls.Add(this.tabPage1);
            this.tabReservation.Controls.Add(this.tabPage2);
            this.tabReservation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabReservation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tabReservation.Location = new System.Drawing.Point(0, 0);
            this.tabReservation.Name = "tabReservation";
            this.tabReservation.SelectedIndex = 0;
            this.tabReservation.Size = new System.Drawing.Size(1850, 870);
            this.tabReservation.TabIndex = 0;
            this.tabReservation.SelectedIndexChanged += new System.EventHandler(this.tabReservation_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnNewGuest);
            this.tabPage1.Controls.Add(this.lblAvailableRooms);
            this.tabPage1.Controls.Add(this.lblSelectedGuest);
            this.tabPage1.Controls.Add(this.lblSearchResults);
            this.tabPage1.Controls.Add(this.btnPrint);
            this.tabPage1.Controls.Add(this.btnCancel);
            this.tabPage1.Controls.Add(this.btnBook);
            this.tabPage1.Controls.Add(this.btnCalculate);
            this.tabPage1.Controls.Add(this.lblTotalAmount);
            this.tabPage1.Controls.Add(this.rtbNotes);
            this.tabPage1.Controls.Add(this.clbSpecialRequests);
            this.tabPage1.Controls.Add(this.dgvAvailableRooms);
            this.tabPage1.Controls.Add(this.cmbRoomType);
            this.tabPage1.Controls.Add(this.nudChildren);
            this.tabPage1.Controls.Add(this.nudAdults);
            this.tabPage1.Controls.Add(this.dtpCheckOut);
            this.tabPage1.Controls.Add(this.dtpCheckIn);
            this.tabPage1.Controls.Add(this.dgvGuestResults);
            this.tabPage1.Controls.Add(this.btnSearchGuest);
            this.tabPage1.Controls.Add(this.txtGuestSearch);
            this.tabPage1.Controls.Add(this.pnlGuestInfo);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1842, 837);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "New Reservation";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.btnNewGuest.Click += new System.EventHandler(this.btnNewGuest_Click);
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
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnPrint.Location = new System.Drawing.Point(1580, 740);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(130, 45);
            this.btnPrint.TabIndex = 17;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
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
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
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
            // rtbNotes
            // 
            this.rtbNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rtbNotes.Location = new System.Drawing.Point(1040, 560);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(350, 250);
            this.rtbNotes.TabIndex = 12;
            this.rtbNotes.Text = "";
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
            // cmbRoomType
            // 
            this.cmbRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cmbRoomType.FormattingEnabled = true;
            this.cmbRoomType.Location = new System.Drawing.Point(320, 480);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(250, 30);
            this.cmbRoomType.TabIndex = 9;
            this.cmbRoomType.SelectedIndexChanged += new System.EventHandler(this.cmbRoomType_SelectedIndexChanged);
            // 
            // nudChildren
            // 
            this.nudChildren.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.nudChildren.Location = new System.Drawing.Point(170, 480);
            this.nudChildren.Name = "nudChildren";
            this.nudChildren.Size = new System.Drawing.Size(100, 28);
            this.nudChildren.TabIndex = 8;
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
            // dtpCheckOut
            // 
            this.dtpCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dtpCheckOut.Location = new System.Drawing.Point(320, 410);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(250, 28);
            this.dtpCheckOut.TabIndex = 6;
            this.dtpCheckOut.ValueChanged += new System.EventHandler(this.dtpCheckOut_ValueChanged);
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dtpCheckIn.Location = new System.Drawing.Point(30, 410);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(250, 28);
            this.dtpCheckIn.TabIndex = 5;
            this.dtpCheckIn.ValueChanged += new System.EventHandler(this.dtpCheckIn_ValueChanged);
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
            this.dgvGuestResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGuestResults_CellClick);
            this.dgvGuestResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGuestResults_CellDoubleClick);
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
            this.btnSearchGuest.Click += new System.EventHandler(this.btnSearchGuest_Click);
            // 
            // txtGuestSearch
            // 
            this.txtGuestSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtGuestSearch.Location = new System.Drawing.Point(660, 210);
            this.txtGuestSearch.Name = "txtGuestSearch";
            this.txtGuestSearch.Size = new System.Drawing.Size(850, 28);
            this.txtGuestSearch.TabIndex = 2;
            this.txtGuestSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGuestSearch_KeyPress);
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
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1842, 837);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Reservation History";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // frmReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1850, 870);
            this.Controls.Add(this.tabReservation);
            this.Name = "frmReservation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Management System - Reservations";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReservation_Load);
            this.tabReservation.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChildren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuestResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabReservation;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnNewGuest;
        private System.Windows.Forms.Label lblAvailableRooms;
        private System.Windows.Forms.Label lblSelectedGuest;
        private System.Windows.Forms.Label lblSearchResults;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.CheckedListBox clbSpecialRequests;
        private System.Windows.Forms.DataGridView dgvAvailableRooms;
        private System.Windows.Forms.ComboBox cmbRoomType;
        private System.Windows.Forms.NumericUpDown nudChildren;
        private System.Windows.Forms.NumericUpDown nudAdults;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.DataGridView dgvGuestResults;
        private System.Windows.Forms.Button btnSearchGuest;
        private System.Windows.Forms.TextBox txtGuestSearch;
        private System.Windows.Forms.Panel pnlGuestInfo;
        private System.Windows.Forms.TabPage tabPage2;
    }
}