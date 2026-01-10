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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblReq = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbllstRoom = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.clbSpecialRequests = new System.Windows.Forms.CheckedListBox();
            this.cmbRoomType = new System.Windows.Forms.ComboBox();
            this.lblAvailableRooms = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAvailableRooms = new System.Windows.Forms.DataGridView();
            this.pnlGuestInfo = new System.Windows.Forms.Panel();
            this.lblNumDults = new System.Windows.Forms.Label();
            this.lblNumDren = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblChckOut = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblchckIn = new System.Windows.Forms.Label();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.nudAdults = new System.Windows.Forms.NumericUpDown();
            this.nudChildren = new System.Windows.Forms.NumericUpDown();
            this.lblRom = new System.Windows.Forms.Label();
            this.lblGuestAv = new System.Windows.Forms.Label();
            this.lblSearchResults = new System.Windows.Forms.Label();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.btnNewGuest = new System.Windows.Forms.Button();
            this.lblSelectedGuest = new System.Windows.Forms.Label();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.dgvGuestResults = new System.Windows.Forms.DataGridView();
            this.btnSearchGuest = new System.Windows.Forms.Button();
            this.txtGuestSearch = new System.Windows.Forms.TextBox();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabReservation.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableRooms)).BeginInit();
            this.pnlGuestInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChildren)).BeginInit();
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
            this.tabReservation.Size = new System.Drawing.Size(1920, 950);
            this.tabReservation.TabIndex = 0;
            this.tabReservation.SelectedIndexChanged += new System.EventHandler(this.tabReservation_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Thistle;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.pnlGuestInfo);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1912, 917);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "New Reservation";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblReq);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbllstRoom);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.clbSpecialRequests);
            this.panel1.Controls.Add(this.cmbRoomType);
            this.panel1.Controls.Add(this.lblAvailableRooms);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dgvAvailableRooms);
            this.panel1.Location = new System.Drawing.Point(8, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(985, 905);
            this.panel1.TabIndex = 23;
            // 
            // lblReq
            // 
            this.lblReq.AutoSize = true;
            this.lblReq.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq.Location = new System.Drawing.Point(3, 524);
            this.lblReq.Name = "lblReq";
            this.lblReq.Size = new System.Drawing.Size(225, 28);
            this.lblReq.TabIndex = 26;
            this.lblReq.Text = "Room Special Requests";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label1.Location = new System.Drawing.Point(554, 381);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 27);
            this.label1.TabIndex = 22;
            // 
            // lbllstRoom
            // 
            this.lbllstRoom.AutoSize = true;
            this.lbllstRoom.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllstRoom.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lbllstRoom.Location = new System.Drawing.Point(3, 0);
            this.lbllstRoom.Name = "lbllstRoom";
            this.lbllstRoom.Size = new System.Drawing.Size(176, 27);
            this.lbllstRoom.TabIndex = 24;
            this.lbllstRoom.Text = "List of Rooms";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.button1.Location = new System.Drawing.Point(1676, 888);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 35);
            this.button1.TabIndex = 21;
            this.button1.Text = "NEW GUEST";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // clbSpecialRequests
            // 
            this.clbSpecialRequests.BackColor = System.Drawing.Color.White;
            this.clbSpecialRequests.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbSpecialRequests.FormattingEnabled = true;
            this.clbSpecialRequests.Location = new System.Drawing.Point(3, 555);
            this.clbSpecialRequests.Name = "clbSpecialRequests";
            this.clbSpecialRequests.Size = new System.Drawing.Size(977, 314);
            this.clbSpecialRequests.TabIndex = 11;
            // 
            // cmbRoomType
            // 
            this.cmbRoomType.BackColor = System.Drawing.Color.White;
            this.cmbRoomType.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoomType.FormattingEnabled = true;
            this.cmbRoomType.Location = new System.Drawing.Point(3, 30);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(977, 36);
            this.cmbRoomType.TabIndex = 9;
            this.cmbRoomType.SelectedIndexChanged += new System.EventHandler(this.cmbRoomType_SelectedIndexChanged);
            // 
            // lblAvailableRooms
            // 
            this.lblAvailableRooms.AutoSize = true;
            this.lblAvailableRooms.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableRooms.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAvailableRooms.Location = new System.Drawing.Point(3, 69);
            this.lblAvailableRooms.Name = "lblAvailableRooms";
            this.lblAvailableRooms.Size = new System.Drawing.Size(159, 28);
            this.lblAvailableRooms.TabIndex = 20;
            this.lblAvailableRooms.Text = "Available rooms";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.button2.Location = new System.Drawing.Point(1378, 840);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 45);
            this.button2.TabIndex = 17;
            this.button2.Text = "PRINT";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(1670, 760);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 36);
            this.label2.TabIndex = 13;
            this.label2.Text = "Total: ₱0.00";
            // 
            // dgvAvailableRooms
            // 
            this.dgvAvailableRooms.AllowUserToAddRows = false;
            this.dgvAvailableRooms.AllowUserToDeleteRows = false;
            this.dgvAvailableRooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAvailableRooms.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvAvailableRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableRooms.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvAvailableRooms.Location = new System.Drawing.Point(3, 100);
            this.dgvAvailableRooms.Name = "dgvAvailableRooms";
            this.dgvAvailableRooms.RowHeadersVisible = false;
            this.dgvAvailableRooms.RowHeadersWidth = 51;
            this.dgvAvailableRooms.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAvailableRooms.RowTemplate.Height = 24;
            this.dgvAvailableRooms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvailableRooms.Size = new System.Drawing.Size(977, 421);
            this.dgvAvailableRooms.TabIndex = 10;
            // 
            // pnlGuestInfo
            // 
            this.pnlGuestInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGuestInfo.BackColor = System.Drawing.Color.White;
            this.pnlGuestInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGuestInfo.Controls.Add(this.lblNumDults);
            this.pnlGuestInfo.Controls.Add(this.lblNumDren);
            this.pnlGuestInfo.Controls.Add(this.lblNotes);
            this.pnlGuestInfo.Controls.Add(this.lblTotalAmount);
            this.pnlGuestInfo.Controls.Add(this.lblChckOut);
            this.pnlGuestInfo.Controls.Add(this.btnCancel);
            this.pnlGuestInfo.Controls.Add(this.lblchckIn);
            this.pnlGuestInfo.Controls.Add(this.rtbNotes);
            this.pnlGuestInfo.Controls.Add(this.nudAdults);
            this.pnlGuestInfo.Controls.Add(this.nudChildren);
            this.pnlGuestInfo.Controls.Add(this.lblRom);
            this.pnlGuestInfo.Controls.Add(this.lblGuestAv);
            this.pnlGuestInfo.Controls.Add(this.lblSearchResults);
            this.pnlGuestInfo.Controls.Add(this.dtpCheckIn);
            this.pnlGuestInfo.Controls.Add(this.btnNewGuest);
            this.pnlGuestInfo.Controls.Add(this.lblSelectedGuest);
            this.pnlGuestInfo.Controls.Add(this.dtpCheckOut);
            this.pnlGuestInfo.Controls.Add(this.dgvGuestResults);
            this.pnlGuestInfo.Controls.Add(this.btnSearchGuest);
            this.pnlGuestInfo.Controls.Add(this.txtGuestSearch);
            this.pnlGuestInfo.Controls.Add(this.btnBook);
            this.pnlGuestInfo.Controls.Add(this.btnCalculate);
            this.pnlGuestInfo.Controls.Add(this.btnPrint);
            this.pnlGuestInfo.Location = new System.Drawing.Point(1000, 6);
            this.pnlGuestInfo.Name = "pnlGuestInfo";
            this.pnlGuestInfo.Size = new System.Drawing.Size(904, 905);
            this.pnlGuestInfo.TabIndex = 1;
            this.pnlGuestInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGuestInfo_Paint);
            // 
            // lblNumDults
            // 
            this.lblNumDults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumDults.AutoSize = true;
            this.lblNumDults.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumDults.Location = new System.Drawing.Point(501, 594);
            this.lblNumDults.Name = "lblNumDults";
            this.lblNumDults.Size = new System.Drawing.Size(176, 28);
            this.lblNumDults.TabIndex = 29;
            this.lblNumDults.Text = "Number of Adults";
            // 
            // lblNumDren
            // 
            this.lblNumDren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumDren.AutoSize = true;
            this.lblNumDren.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumDren.Location = new System.Drawing.Point(501, 524);
            this.lblNumDren.Name = "lblNumDren";
            this.lblNumDren.Size = new System.Drawing.Size(194, 28);
            this.lblNumDren.TabIndex = 28;
            this.lblNumDren.Text = "Number of Children";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(3, 664);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(167, 28);
            this.lblNotes.TabIndex = 26;
            this.lblNotes.Text = "Additional Notes";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Green;
            this.lblTotalAmount.Location = new System.Drawing.Point(501, 847);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(123, 28);
            this.lblTotalAmount.TabIndex = 13;
            this.lblTotalAmount.Text = "Total: ₱0.00";
            // 
            // lblChckOut
            // 
            this.lblChckOut.AutoSize = true;
            this.lblChckOut.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChckOut.Location = new System.Drawing.Point(3, 594);
            this.lblChckOut.Name = "lblChckOut";
            this.lblChckOut.Size = new System.Drawing.Size(157, 28);
            this.lblChckOut.TabIndex = 25;
            this.lblChckOut.Text = "Check-Out Date";
            this.lblChckOut.Click += new System.EventHandler(this.lblChckOut_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(699, 850);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(200, 50);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblchckIn
            // 
            this.lblchckIn.AutoSize = true;
            this.lblchckIn.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblchckIn.Location = new System.Drawing.Point(3, 524);
            this.lblchckIn.Name = "lblchckIn";
            this.lblchckIn.Size = new System.Drawing.Size(140, 28);
            this.lblchckIn.TabIndex = 24;
            this.lblchckIn.Text = "Check-In Date";
            this.lblchckIn.Click += new System.EventHandler(this.lblchckIn_Click);
            // 
            // rtbNotes
            // 
            this.rtbNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbNotes.BackColor = System.Drawing.Color.White;
            this.rtbNotes.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbNotes.Location = new System.Drawing.Point(3, 695);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(484, 205);
            this.rtbNotes.TabIndex = 12;
            this.rtbNotes.Text = "";
            // 
            // nudAdults
            // 
            this.nudAdults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudAdults.BackColor = System.Drawing.Color.White;
            this.nudAdults.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudAdults.Location = new System.Drawing.Point(498, 625);
            this.nudAdults.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAdults.Name = "nudAdults";
            this.nudAdults.Size = new System.Drawing.Size(400, 36);
            this.nudAdults.TabIndex = 7;
            this.nudAdults.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudChildren
            // 
            this.nudChildren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudChildren.BackColor = System.Drawing.Color.White;
            this.nudChildren.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudChildren.Location = new System.Drawing.Point(498, 555);
            this.nudChildren.Name = "nudChildren";
            this.nudChildren.Size = new System.Drawing.Size(400, 36);
            this.nudChildren.TabIndex = 8;
            // 
            // lblRom
            // 
            this.lblRom.AutoSize = true;
            this.lblRom.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRom.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblRom.Location = new System.Drawing.Point(554, 381);
            this.lblRom.Name = "lblRom";
            this.lblRom.Size = new System.Drawing.Size(0, 27);
            this.lblRom.TabIndex = 22;
            // 
            // lblGuestAv
            // 
            this.lblGuestAv.AutoSize = true;
            this.lblGuestAv.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestAv.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblGuestAv.Location = new System.Drawing.Point(3, 0);
            this.lblGuestAv.Name = "lblGuestAv";
            this.lblGuestAv.Size = new System.Drawing.Size(174, 27);
            this.lblGuestAv.TabIndex = 23;
            this.lblGuestAv.Text = "List of Guests";
            // 
            // lblSearchResults
            // 
            this.lblSearchResults.AutoSize = true;
            this.lblSearchResults.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchResults.Location = new System.Drawing.Point(3, 69);
            this.lblSearchResults.Name = "lblSearchResults";
            this.lblSearchResults.Size = new System.Drawing.Size(153, 28);
            this.lblSearchResults.TabIndex = 18;
            this.lblSearchResults.Text = "Found 0 guests";
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheckIn.Location = new System.Drawing.Point(3, 555);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(400, 36);
            this.dtpCheckIn.TabIndex = 5;
            this.dtpCheckIn.ValueChanged += new System.EventHandler(this.dtpCheckIn_ValueChanged);
            // 
            // btnNewGuest
            // 
            this.btnNewGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnNewGuest.Location = new System.Drawing.Point(1676, 888);
            this.btnNewGuest.Name = "btnNewGuest";
            this.btnNewGuest.Size = new System.Drawing.Size(130, 35);
            this.btnNewGuest.TabIndex = 21;
            this.btnNewGuest.Text = "NEW GUEST";
            this.btnNewGuest.UseVisualStyleBackColor = true;
            this.btnNewGuest.Click += new System.EventHandler(this.btnNewGuest_Click);
            // 
            // lblSelectedGuest
            // 
            this.lblSelectedGuest.AutoSize = true;
            this.lblSelectedGuest.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedGuest.ForeColor = System.Drawing.Color.Red;
            this.lblSelectedGuest.Location = new System.Drawing.Point(691, 69);
            this.lblSelectedGuest.Name = "lblSelectedGuest";
            this.lblSelectedGuest.Size = new System.Drawing.Size(177, 28);
            this.lblSelectedGuest.TabIndex = 19;
            this.lblSelectedGuest.Text = "No guest selected";
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheckOut.Location = new System.Drawing.Point(3, 625);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(400, 36);
            this.dtpCheckOut.TabIndex = 6;
            this.dtpCheckOut.ValueChanged += new System.EventHandler(this.dtpCheckOut_ValueChanged);
            // 
            // dgvGuestResults
            // 
            this.dgvGuestResults.AllowUserToAddRows = false;
            this.dgvGuestResults.AllowUserToDeleteRows = false;
            this.dgvGuestResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGuestResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGuestResults.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvGuestResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGuestResults.Location = new System.Drawing.Point(3, 100);
            this.dgvGuestResults.Name = "dgvGuestResults";
            this.dgvGuestResults.ReadOnly = true;
            this.dgvGuestResults.RowHeadersWidth = 51;
            this.dgvGuestResults.RowTemplate.Height = 24;
            this.dgvGuestResults.Size = new System.Drawing.Size(895, 421);
            this.dgvGuestResults.TabIndex = 4;
            this.dgvGuestResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGuestResults_CellClick);
            this.dgvGuestResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGuestResults_CellDoubleClick);
            // 
            // btnSearchGuest
            // 
            this.btnSearchGuest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchGuest.BackgroundImage = global::Hotel_ManagementIT13.Properties.Resources.people;
            this.btnSearchGuest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchGuest.FlatAppearance.BorderSize = 0;
            this.btnSearchGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnSearchGuest.Location = new System.Drawing.Point(864, 33);
            this.btnSearchGuest.Name = "btnSearchGuest";
            this.btnSearchGuest.Size = new System.Drawing.Size(30, 30);
            this.btnSearchGuest.TabIndex = 3;
            this.btnSearchGuest.UseVisualStyleBackColor = true;
            this.btnSearchGuest.Click += new System.EventHandler(this.btnSearchGuest_Click);
            // 
            // txtGuestSearch
            // 
            this.txtGuestSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGuestSearch.BackColor = System.Drawing.Color.White;
            this.txtGuestSearch.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuestSearch.Location = new System.Drawing.Point(3, 30);
            this.txtGuestSearch.Name = "txtGuestSearch";
            this.txtGuestSearch.Size = new System.Drawing.Size(895, 36);
            this.txtGuestSearch.TabIndex = 2;
            this.txtGuestSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGuestSearch_KeyPress);
            // 
            // btnBook
            // 
            this.btnBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBook.BackColor = System.Drawing.Color.Green;
            this.btnBook.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBook.ForeColor = System.Drawing.Color.White;
            this.btnBook.Location = new System.Drawing.Point(699, 794);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(200, 50);
            this.btnBook.TabIndex = 15;
            this.btnBook.Text = "BOOK NOW";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculate.BackColor = System.Drawing.Color.Blue;
            this.btnCalculate.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.ForeColor = System.Drawing.Color.White;
            this.btnCalculate.Location = new System.Drawing.Point(493, 794);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(200, 50);
            this.btnCalculate.TabIndex = 14;
            this.btnCalculate.Text = "CALCULATE";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnPrint.Location = new System.Drawing.Point(1378, 840);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(130, 45);
            this.btnPrint.TabIndex = 17;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Thistle;
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1912, 917);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Reservation History";
            // 
            // frmReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Plum;
            this.ClientSize = new System.Drawing.Size(1920, 950);
            this.Controls.Add(this.tabReservation);
            this.Name = "frmReservation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Management System - Reservations";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReservation_Load);
            this.tabReservation.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableRooms)).EndInit();
            this.pnlGuestInfo.ResumeLayout(false);
            this.pnlGuestInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChildren)).EndInit();
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
        private System.Windows.Forms.Label lblRom;
        private System.Windows.Forms.Label lblGuestAv;
        private System.Windows.Forms.Label lbllstRoom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblChckOut;
        private System.Windows.Forms.Label lblchckIn;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblReq;
        private System.Windows.Forms.Label lblNumDults;
        private System.Windows.Forms.Label lblNumDren;
    }
}