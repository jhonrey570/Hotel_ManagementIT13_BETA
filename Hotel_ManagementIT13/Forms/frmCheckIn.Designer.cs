namespace Hotel_ManagementIT13.Forms
{
    partial class frmCheckIn
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
            this.dgvTodayArrivals = new System.Windows.Forms.DataGridView();
            this.dgvWalkInAvailable = new System.Windows.Forms.DataGridView();
            this.pnlReservationDetails = new System.Windows.Forms.Panel();
            this.lblNotes = new System.Windows.Forms.Label();
            this.btnPrintKeyCard = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.btnProcessCheckIn = new System.Windows.Forms.Button();
            this.dtpActualCheckIn = new System.Windows.Forms.DateTimePicker();
            this.lblActPay = new System.Windows.Forms.Label();
            this.lblPayment = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.nudDeposit = new System.Windows.Forms.NumericUpDown();
            this.lblGuestDetails = new System.Windows.Forms.Label();
            this.rtbCheckInNotes = new System.Windows.Forms.RichTextBox();
            this.lblGuestName = new System.Windows.Forms.Label();
            this.lblBookingRef = new System.Windows.Forms.Label();
            this.lblRoomNumber = new System.Windows.Forms.Label();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.lblAmountDue = new System.Windows.Forms.Label();
            this.btnWalkInCheckIn = new System.Windows.Forms.Button();
            this.lblChck = new System.Windows.Forms.Label();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.lblWalkInRoomsCount = new System.Windows.Forms.Label();
            this.lblArrivalsCount = new System.Windows.Forms.Label();
            this.lblSel = new System.Windows.Forms.Label();
            this.lblArrivals = new System.Windows.Forms.Label();
            this.pnlWalkIn = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chkPrintWalkInKeyCard = new System.Windows.Forms.CheckBox();
            this.nudWalkInDeposit = new System.Windows.Forms.NumericUpDown();
            this.nudWalkInChildren = new System.Windows.Forms.NumericUpDown();
            this.nudWalkInAdults = new System.Windows.Forms.NumericUpDown();
            this.dtpWalkInCheckOut = new System.Windows.Forms.DateTimePicker();
            this.lblWalkInDeposit = new System.Windows.Forms.Label();
            this.lblWalkInChildren = new System.Windows.Forms.Label();
            this.lblWalkInAdults = new System.Windows.Forms.Label();
            this.lblWalkInCheckOut = new System.Windows.Forms.Label();
            this.txtWalkInEmail = new System.Windows.Forms.TextBox();
            this.lblWalkInEmail = new System.Windows.Forms.Label();
            this.txtWalkInPhone = new System.Windows.Forms.TextBox();
            this.lblWalkInPhone = new System.Windows.Forms.Label();
            this.txtWalkInLastName = new System.Windows.Forms.TextBox();
            this.lblWalkInLastName = new System.Windows.Forms.Label();
            this.txtWalkInFirstName = new System.Windows.Forms.TextBox();
            this.lblWalkInFirstName = new System.Windows.Forms.Label();
            this.lblWalkInGuestDetails = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayArrivals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWalkInAvailable)).BeginInit();
            this.pnlReservationDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeposit)).BeginInit();
            this.pnlDetails.SuspendLayout();
            this.pnlWalkIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWalkInDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWalkInChildren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWalkInAdults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTodayArrivals
            // 
            this.dgvTodayArrivals.AllowUserToAddRows = false;
            this.dgvTodayArrivals.AllowUserToDeleteRows = false;
            this.dgvTodayArrivals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTodayArrivals.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvTodayArrivals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTodayArrivals.Location = new System.Drawing.Point(3, 89);
            this.dgvTodayArrivals.Name = "dgvTodayArrivals";
            this.dgvTodayArrivals.ReadOnly = true;
            this.dgvTodayArrivals.RowHeadersWidth = 51;
            this.dgvTodayArrivals.RowTemplate.Height = 30;
            this.dgvTodayArrivals.Size = new System.Drawing.Size(1123, 409);
            this.dgvTodayArrivals.TabIndex = 0;
            // 
            // dgvWalkInAvailable
            // 
            this.dgvWalkInAvailable.AllowUserToAddRows = false;
            this.dgvWalkInAvailable.AllowUserToDeleteRows = false;
            this.dgvWalkInAvailable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWalkInAvailable.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvWalkInAvailable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWalkInAvailable.Location = new System.Drawing.Point(3, 532);
            this.dgvWalkInAvailable.Name = "dgvWalkInAvailable";
            this.dgvWalkInAvailable.ReadOnly = true;
            this.dgvWalkInAvailable.RowHeadersWidth = 51;
            this.dgvWalkInAvailable.RowTemplate.Height = 30;
            this.dgvWalkInAvailable.Size = new System.Drawing.Size(1123, 401);
            this.dgvWalkInAvailable.TabIndex = 1;
            // 
            // pnlReservationDetails
            // 
            this.pnlReservationDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReservationDetails.BackColor = System.Drawing.Color.White;
            this.pnlReservationDetails.Controls.Add(this.lblNotes);
            this.pnlReservationDetails.Controls.Add(this.btnPrintKeyCard);
            this.pnlReservationDetails.Controls.Add(this.lblDate);
            this.pnlReservationDetails.Controls.Add(this.lblDeposit);
            this.pnlReservationDetails.Controls.Add(this.btnProcessCheckIn);
            this.pnlReservationDetails.Controls.Add(this.dtpActualCheckIn);
            this.pnlReservationDetails.Controls.Add(this.lblActPay);
            this.pnlReservationDetails.Controls.Add(this.lblPayment);
            this.pnlReservationDetails.Controls.Add(this.cmbPaymentMethod);
            this.pnlReservationDetails.Controls.Add(this.nudDeposit);
            this.pnlReservationDetails.Controls.Add(this.lblGuestDetails);
            this.pnlReservationDetails.Controls.Add(this.rtbCheckInNotes);
            this.pnlReservationDetails.Controls.Add(this.lblGuestName);
            this.pnlReservationDetails.Controls.Add(this.lblBookingRef);
            this.pnlReservationDetails.Controls.Add(this.lblRoomNumber);
            this.pnlReservationDetails.Controls.Add(this.txtPayment);
            this.pnlReservationDetails.Controls.Add(this.lblAmountDue);
            this.pnlReservationDetails.Location = new System.Drawing.Point(1147, 12);
            this.pnlReservationDetails.Name = "pnlReservationDetails";
            this.pnlReservationDetails.Size = new System.Drawing.Size(761, 498);
            this.pnlReservationDetails.TabIndex = 2;
            this.pnlReservationDetails.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlReservationDetails_Paint);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNotes.Location = new System.Drawing.Point(313, 128);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(151, 28);
            this.lblNotes.TabIndex = 31;
            this.lblNotes.Text = "Check-In Notes";
            // 
            // btnPrintKeyCard
            // 
            this.btnPrintKeyCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintKeyCard.BackColor = System.Drawing.Color.Blue;
            this.btnPrintKeyCard.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintKeyCard.ForeColor = System.Drawing.Color.White;
            this.btnPrintKeyCard.Location = new System.Drawing.Point(558, 425);
            this.btnPrintKeyCard.Name = "btnPrintKeyCard";
            this.btnPrintKeyCard.Size = new System.Drawing.Size(200, 50);
            this.btnPrintKeyCard.TabIndex = 10;
            this.btnPrintKeyCard.Text = "PRINT KEY CARD";
            this.btnPrintKeyCard.UseVisualStyleBackColor = false;
            this.btnPrintKeyCard.Click += new System.EventHandler(this.btnPrintKeyCard_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDate.Location = new System.Drawing.Point(313, 58);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(56, 28);
            this.lblDate.TabIndex = 30;
            this.lblDate.Text = "Date";
            this.lblDate.Click += new System.EventHandler(this.lblDate_Click);
            // 
            // lblDeposit
            // 
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeposit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDeposit.Location = new System.Drawing.Point(3, 422);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(83, 28);
            this.lblDeposit.TabIndex = 29;
            this.lblDeposit.Text = "Deposit";
            // 
            // btnProcessCheckIn
            // 
            this.btnProcessCheckIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcessCheckIn.BackColor = System.Drawing.Color.Green;
            this.btnProcessCheckIn.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessCheckIn.ForeColor = System.Drawing.Color.White;
            this.btnProcessCheckIn.Location = new System.Drawing.Point(314, 425);
            this.btnProcessCheckIn.Name = "btnProcessCheckIn";
            this.btnProcessCheckIn.Size = new System.Drawing.Size(200, 50);
            this.btnProcessCheckIn.TabIndex = 8;
            this.btnProcessCheckIn.Text = "PROCESS CHECK-IN";
            this.btnProcessCheckIn.UseVisualStyleBackColor = false;
            this.btnProcessCheckIn.Click += new System.EventHandler(this.btnProcessCheckIn_Click);
            // 
            // dtpActualCheckIn
            // 
            this.dtpActualCheckIn.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpActualCheckIn.Location = new System.Drawing.Point(314, 89);
            this.dtpActualCheckIn.Name = "dtpActualCheckIn";
            this.dtpActualCheckIn.Size = new System.Drawing.Size(400, 36);
            this.dtpActualCheckIn.TabIndex = 11;
            // 
            // lblActPay
            // 
            this.lblActPay.AutoSize = true;
            this.lblActPay.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActPay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblActPay.Location = new System.Drawing.Point(3, 352);
            this.lblActPay.Name = "lblActPay";
            this.lblActPay.Size = new System.Drawing.Size(94, 28);
            this.lblActPay.TabIndex = 28;
            this.lblActPay.Text = "Payment";
            // 
            // lblPayment
            // 
            this.lblPayment.AutoSize = true;
            this.lblPayment.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayment.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPayment.Location = new System.Drawing.Point(3, 282);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(174, 28);
            this.lblPayment.TabIndex = 27;
            this.lblPayment.Text = "Payment Method";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.BackColor = System.Drawing.Color.White;
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Location = new System.Drawing.Point(3, 313);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(300, 36);
            this.cmbPaymentMethod.TabIndex = 13;
            // 
            // nudDeposit
            // 
            this.nudDeposit.BackColor = System.Drawing.Color.White;
            this.nudDeposit.DecimalPlaces = 2;
            this.nudDeposit.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDeposit.Location = new System.Drawing.Point(3, 453);
            this.nudDeposit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudDeposit.Name = "nudDeposit";
            this.nudDeposit.Size = new System.Drawing.Size(300, 36);
            this.nudDeposit.TabIndex = 12;
            this.nudDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblGuestDetails
            // 
            this.lblGuestDetails.AutoSize = true;
            this.lblGuestDetails.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestDetails.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblGuestDetails.Location = new System.Drawing.Point(3, 3);
            this.lblGuestDetails.Name = "lblGuestDetails";
            this.lblGuestDetails.Size = new System.Drawing.Size(170, 27);
            this.lblGuestDetails.TabIndex = 26;
            this.lblGuestDetails.Text = "Guest Details";
            // 
            // rtbCheckInNotes
            // 
            this.rtbCheckInNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbCheckInNotes.BackColor = System.Drawing.Color.White;
            this.rtbCheckInNotes.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbCheckInNotes.Location = new System.Drawing.Point(314, 159);
            this.rtbCheckInNotes.Name = "rtbCheckInNotes";
            this.rtbCheckInNotes.Size = new System.Drawing.Size(444, 260);
            this.rtbCheckInNotes.TabIndex = 14;
            this.rtbCheckInNotes.Text = "Check-in Notes...";
            // 
            // lblGuestName
            // 
            this.lblGuestName.AutoSize = true;
            this.lblGuestName.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGuestName.Location = new System.Drawing.Point(3, 58);
            this.lblGuestName.Name = "lblGuestName";
            this.lblGuestName.Size = new System.Drawing.Size(133, 28);
            this.lblGuestName.TabIndex = 3;
            this.lblGuestName.Text = "Guest Name:";
            // 
            // lblBookingRef
            // 
            this.lblBookingRef.AutoSize = true;
            this.lblBookingRef.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingRef.Location = new System.Drawing.Point(3, 114);
            this.lblBookingRef.Name = "lblBookingRef";
            this.lblBookingRef.Size = new System.Drawing.Size(128, 28);
            this.lblBookingRef.TabIndex = 4;
            this.lblBookingRef.Text = "Booking Ref:";
            // 
            // lblRoomNumber
            // 
            this.lblRoomNumber.AutoSize = true;
            this.lblRoomNumber.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomNumber.Location = new System.Drawing.Point(3, 170);
            this.lblRoomNumber.Name = "lblRoomNumber";
            this.lblRoomNumber.Size = new System.Drawing.Size(153, 28);
            this.lblRoomNumber.TabIndex = 5;
            this.lblRoomNumber.Text = "Room Number:";
            // 
            // txtPayment
            // 
            this.txtPayment.BackColor = System.Drawing.Color.White;
            this.txtPayment.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayment.Location = new System.Drawing.Point(3, 383);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(300, 36);
            this.txtPayment.TabIndex = 7;
            this.txtPayment.Text = "0.00";
            // 
            // lblAmountDue
            // 
            this.lblAmountDue.AutoSize = true;
            this.lblAmountDue.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountDue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAmountDue.Location = new System.Drawing.Point(3, 226);
            this.lblAmountDue.Name = "lblAmountDue";
            this.lblAmountDue.Size = new System.Drawing.Size(135, 28);
            this.lblAmountDue.TabIndex = 6;
            this.lblAmountDue.Text = "Amount Due:";
            // 
            // btnWalkInCheckIn
            // 
            this.btnWalkInCheckIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWalkInCheckIn.BackColor = System.Drawing.Color.Orange;
            this.btnWalkInCheckIn.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWalkInCheckIn.ForeColor = System.Drawing.Color.White;
            this.btnWalkInCheckIn.Location = new System.Drawing.Point(342, 309);
            this.btnWalkInCheckIn.Name = "btnWalkInCheckIn";
            this.btnWalkInCheckIn.Size = new System.Drawing.Size(250, 50);
            this.btnWalkInCheckIn.TabIndex = 9;
            this.btnWalkInCheckIn.Text = "WALK-IN CHECK-IN";
            this.btnWalkInCheckIn.UseVisualStyleBackColor = false;
            this.btnWalkInCheckIn.Click += new System.EventHandler(this.btnWalkInCheckIn_Click);
            // 
            // lblChck
            // 
            this.lblChck.AutoSize = true;
            this.lblChck.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChck.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblChck.Location = new System.Drawing.Point(3, 3);
            this.lblChck.Name = "lblChck";
            this.lblChck.Size = new System.Drawing.Size(119, 27);
            this.lblChck.TabIndex = 25;
            this.lblChck.Text = "Check-In";
            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.Color.White;
            this.pnlDetails.Controls.Add(this.lblWalkInRoomsCount);
            this.pnlDetails.Controls.Add(this.lblArrivalsCount);
            this.pnlDetails.Controls.Add(this.lblSel);
            this.pnlDetails.Controls.Add(this.lblArrivals);
            this.pnlDetails.Controls.Add(this.lblChck);
            this.pnlDetails.Controls.Add(this.dgvTodayArrivals);
            this.pnlDetails.Controls.Add(this.dgvWalkInAvailable);
            this.pnlDetails.Location = new System.Drawing.Point(12, 12);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(1129, 936);
            this.pnlDetails.TabIndex = 26;
            // 
            // lblWalkInRoomsCount
            // 
            this.lblWalkInRoomsCount.AutoSize = true;
            this.lblWalkInRoomsCount.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalkInRoomsCount.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblWalkInRoomsCount.Location = new System.Drawing.Point(3, 513);
            this.lblWalkInRoomsCount.Name = "lblWalkInRoomsCount";
            this.lblWalkInRoomsCount.Size = new System.Drawing.Size(220, 21);
            this.lblWalkInRoomsCount.TabIndex = 33;
            this.lblWalkInRoomsCount.Text = "0 room(s) available for walk-in";
            // 
            // lblArrivalsCount
            // 
            this.lblArrivalsCount.AutoSize = true;
            this.lblArrivalsCount.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrivalsCount.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblArrivalsCount.Location = new System.Drawing.Point(3, 70);
            this.lblArrivalsCount.Name = "lblArrivalsCount";
            this.lblArrivalsCount.Size = new System.Drawing.Size(128, 21);
            this.lblArrivalsCount.TabIndex = 32;
            this.lblArrivalsCount.Text = "0 arrival(s) today";
            // 
            // lblSel
            // 
            this.lblSel.AutoSize = true;
            this.lblSel.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSel.Location = new System.Drawing.Point(3, 501);
            this.lblSel.Name = "lblSel";
            this.lblSel.Size = new System.Drawing.Size(242, 28);
            this.lblSel.TabIndex = 31;
            this.lblSel.Text = "Available Walk-In Rooms ";
            // 
            // lblArrivals
            // 
            this.lblArrivals.AutoSize = true;
            this.lblArrivals.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrivals.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblArrivals.Location = new System.Drawing.Point(3, 58);
            this.lblArrivals.Name = "lblArrivals";
            this.lblArrivals.Size = new System.Drawing.Size(216, 28);
            this.lblArrivals.TabIndex = 30;
            this.lblArrivals.Text = "Arrivals, and Reserved";
            // 
            // pnlWalkIn
            // 
            this.pnlWalkIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWalkIn.BackColor = System.Drawing.Color.White;
            this.pnlWalkIn.Controls.Add(this.label6);
            this.pnlWalkIn.Controls.Add(this.label5);
            this.pnlWalkIn.Controls.Add(this.label4);
            this.pnlWalkIn.Controls.Add(this.label3);
            this.pnlWalkIn.Controls.Add(this.label2);
            this.pnlWalkIn.Controls.Add(this.label1);
            this.pnlWalkIn.Controls.Add(this.numericUpDown1);
            this.pnlWalkIn.Controls.Add(this.comboBox1);
            this.pnlWalkIn.Controls.Add(this.btnRefresh);
            this.pnlWalkIn.Controls.Add(this.chkPrintWalkInKeyCard);
            this.pnlWalkIn.Controls.Add(this.nudWalkInDeposit);
            this.pnlWalkIn.Controls.Add(this.nudWalkInChildren);
            this.pnlWalkIn.Controls.Add(this.nudWalkInAdults);
            this.pnlWalkIn.Controls.Add(this.dtpWalkInCheckOut);
            this.pnlWalkIn.Controls.Add(this.lblWalkInDeposit);
            this.pnlWalkIn.Controls.Add(this.lblWalkInChildren);
            this.pnlWalkIn.Controls.Add(this.lblWalkInAdults);
            this.pnlWalkIn.Controls.Add(this.lblWalkInCheckOut);
            this.pnlWalkIn.Controls.Add(this.txtWalkInEmail);
            this.pnlWalkIn.Controls.Add(this.lblWalkInEmail);
            this.pnlWalkIn.Controls.Add(this.txtWalkInPhone);
            this.pnlWalkIn.Controls.Add(this.lblWalkInPhone);
            this.pnlWalkIn.Controls.Add(this.txtWalkInLastName);
            this.pnlWalkIn.Controls.Add(this.lblWalkInLastName);
            this.pnlWalkIn.Controls.Add(this.txtWalkInFirstName);
            this.pnlWalkIn.Controls.Add(this.lblWalkInFirstName);
            this.pnlWalkIn.Controls.Add(this.lblWalkInGuestDetails);
            this.pnlWalkIn.Controls.Add(this.btnWalkInCheckIn);
            this.pnlWalkIn.Location = new System.Drawing.Point(1147, 516);
            this.pnlWalkIn.Name = "pnlWalkIn";
            this.pnlWalkIn.Size = new System.Drawing.Size(761, 432);
            this.pnlWalkIn.TabIndex = 27;
            this.pnlWalkIn.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlWalkIn_Paint);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.Violet;
            this.btnRefresh.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(592, 309);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 50);
            this.btnRefresh.TabIndex = 46;
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chkPrintWalkInKeyCard
            // 
            this.chkPrintWalkInKeyCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPrintWalkInKeyCard.AutoSize = true;
            this.chkPrintWalkInKeyCard.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrintWalkInKeyCard.Location = new System.Drawing.Point(364, 271);
            this.chkPrintWalkInKeyCard.Name = "chkPrintWalkInKeyCard";
            this.chkPrintWalkInKeyCard.Size = new System.Drawing.Size(165, 32);
            this.chkPrintWalkInKeyCard.TabIndex = 26;
            this.chkPrintWalkInKeyCard.Text = "Print Key Card";
            this.chkPrintWalkInKeyCard.UseVisualStyleBackColor = true;
            // 
            // nudWalkInDeposit
            // 
            this.nudWalkInDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudWalkInDeposit.BackColor = System.Drawing.Color.White;
            this.nudWalkInDeposit.DecimalPlaces = 2;
            this.nudWalkInDeposit.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudWalkInDeposit.Location = new System.Drawing.Point(342, 159);
            this.nudWalkInDeposit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWalkInDeposit.Name = "nudWalkInDeposit";
            this.nudWalkInDeposit.Size = new System.Drawing.Size(300, 36);
            this.nudWalkInDeposit.TabIndex = 25;
            this.nudWalkInDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudWalkInChildren
            // 
            this.nudWalkInChildren.BackColor = System.Drawing.Color.White;
            this.nudWalkInChildren.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudWalkInChildren.Location = new System.Drawing.Point(18, 369);
            this.nudWalkInChildren.Name = "nudWalkInChildren";
            this.nudWalkInChildren.Size = new System.Drawing.Size(300, 36);
            this.nudWalkInChildren.TabIndex = 24;
            // 
            // nudWalkInAdults
            // 
            this.nudWalkInAdults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudWalkInAdults.BackColor = System.Drawing.Color.White;
            this.nudWalkInAdults.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudWalkInAdults.Location = new System.Drawing.Point(342, 89);
            this.nudWalkInAdults.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWalkInAdults.Name = "nudWalkInAdults";
            this.nudWalkInAdults.Size = new System.Drawing.Size(300, 36);
            this.nudWalkInAdults.TabIndex = 23;
            this.nudWalkInAdults.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtpWalkInCheckOut
            // 
            this.dtpWalkInCheckOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpWalkInCheckOut.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpWalkInCheckOut.Location = new System.Drawing.Point(342, 229);
            this.dtpWalkInCheckOut.Name = "dtpWalkInCheckOut";
            this.dtpWalkInCheckOut.Size = new System.Drawing.Size(400, 36);
            this.dtpWalkInCheckOut.TabIndex = 22;
            // 
            // lblWalkInDeposit
            // 
            this.lblWalkInDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWalkInDeposit.AutoSize = true;
            this.lblWalkInDeposit.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalkInDeposit.Location = new System.Drawing.Point(341, 128);
            this.lblWalkInDeposit.Name = "lblWalkInDeposit";
            this.lblWalkInDeposit.Size = new System.Drawing.Size(169, 28);
            this.lblWalkInDeposit.TabIndex = 21;
            this.lblWalkInDeposit.Text = "Deposit Amount:";
            // 
            // lblWalkInChildren
            // 
            this.lblWalkInChildren.AutoSize = true;
            this.lblWalkInChildren.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalkInChildren.Location = new System.Drawing.Point(21, 338);
            this.lblWalkInChildren.Name = "lblWalkInChildren";
            this.lblWalkInChildren.Size = new System.Drawing.Size(200, 28);
            this.lblWalkInChildren.TabIndex = 20;
            this.lblWalkInChildren.Text = "Number of Children:";
            // 
            // lblWalkInAdults
            // 
            this.lblWalkInAdults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWalkInAdults.AutoSize = true;
            this.lblWalkInAdults.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalkInAdults.Location = new System.Drawing.Point(341, 58);
            this.lblWalkInAdults.Name = "lblWalkInAdults";
            this.lblWalkInAdults.Size = new System.Drawing.Size(77, 28);
            this.lblWalkInAdults.TabIndex = 19;
            this.lblWalkInAdults.Text = "Adults:";
            // 
            // lblWalkInCheckOut
            // 
            this.lblWalkInCheckOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWalkInCheckOut.AutoSize = true;
            this.lblWalkInCheckOut.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalkInCheckOut.Location = new System.Drawing.Point(341, 198);
            this.lblWalkInCheckOut.Name = "lblWalkInCheckOut";
            this.lblWalkInCheckOut.Size = new System.Drawing.Size(160, 28);
            this.lblWalkInCheckOut.TabIndex = 17;
            this.lblWalkInCheckOut.Text = "Check-out Date:";
            // 
            // txtWalkInEmail
            // 
            this.txtWalkInEmail.BackColor = System.Drawing.Color.White;
            this.txtWalkInEmail.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWalkInEmail.Location = new System.Drawing.Point(18, 299);
            this.txtWalkInEmail.Name = "txtWalkInEmail";
            this.txtWalkInEmail.Size = new System.Drawing.Size(300, 36);
            this.txtWalkInEmail.TabIndex = 16;
            // 
            // lblWalkInEmail
            // 
            this.lblWalkInEmail.AutoSize = true;
            this.lblWalkInEmail.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalkInEmail.Location = new System.Drawing.Point(21, 268);
            this.lblWalkInEmail.Name = "lblWalkInEmail";
            this.lblWalkInEmail.Size = new System.Drawing.Size(68, 28);
            this.lblWalkInEmail.TabIndex = 15;
            this.lblWalkInEmail.Text = "Email:";
            // 
            // txtWalkInPhone
            // 
            this.txtWalkInPhone.BackColor = System.Drawing.Color.White;
            this.txtWalkInPhone.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWalkInPhone.Location = new System.Drawing.Point(18, 229);
            this.txtWalkInPhone.Name = "txtWalkInPhone";
            this.txtWalkInPhone.Size = new System.Drawing.Size(300, 36);
            this.txtWalkInPhone.TabIndex = 14;
            // 
            // lblWalkInPhone
            // 
            this.lblWalkInPhone.AutoSize = true;
            this.lblWalkInPhone.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalkInPhone.Location = new System.Drawing.Point(21, 198);
            this.lblWalkInPhone.Name = "lblWalkInPhone";
            this.lblWalkInPhone.Size = new System.Drawing.Size(77, 28);
            this.lblWalkInPhone.TabIndex = 13;
            this.lblWalkInPhone.Text = "Phone:";
            // 
            // txtWalkInLastName
            // 
            this.txtWalkInLastName.BackColor = System.Drawing.Color.White;
            this.txtWalkInLastName.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWalkInLastName.Location = new System.Drawing.Point(18, 159);
            this.txtWalkInLastName.Name = "txtWalkInLastName";
            this.txtWalkInLastName.Size = new System.Drawing.Size(300, 36);
            this.txtWalkInLastName.TabIndex = 12;
            // 
            // lblWalkInLastName
            // 
            this.lblWalkInLastName.AutoSize = true;
            this.lblWalkInLastName.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalkInLastName.Location = new System.Drawing.Point(21, 128);
            this.lblWalkInLastName.Name = "lblWalkInLastName";
            this.lblWalkInLastName.Size = new System.Drawing.Size(116, 28);
            this.lblWalkInLastName.TabIndex = 11;
            this.lblWalkInLastName.Text = "Last Name:";
            // 
            // txtWalkInFirstName
            // 
            this.txtWalkInFirstName.BackColor = System.Drawing.Color.White;
            this.txtWalkInFirstName.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWalkInFirstName.Location = new System.Drawing.Point(18, 89);
            this.txtWalkInFirstName.Name = "txtWalkInFirstName";
            this.txtWalkInFirstName.Size = new System.Drawing.Size(300, 36);
            this.txtWalkInFirstName.TabIndex = 10;
            // 
            // lblWalkInFirstName
            // 
            this.lblWalkInFirstName.AutoSize = true;
            this.lblWalkInFirstName.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalkInFirstName.Location = new System.Drawing.Point(18, 58);
            this.lblWalkInFirstName.Name = "lblWalkInFirstName";
            this.lblWalkInFirstName.Size = new System.Drawing.Size(119, 28);
            this.lblWalkInFirstName.TabIndex = 9;
            this.lblWalkInFirstName.Text = "First Name:";
            // 
            // lblWalkInGuestDetails
            // 
            this.lblWalkInGuestDetails.AutoSize = true;
            this.lblWalkInGuestDetails.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalkInGuestDetails.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblWalkInGuestDetails.Location = new System.Drawing.Point(3, 3);
            this.lblWalkInGuestDetails.Name = "lblWalkInGuestDetails";
            this.lblWalkInGuestDetails.Size = new System.Drawing.Size(274, 27);
            this.lblWalkInGuestDetails.TabIndex = 8;
            this.lblWalkInGuestDetails.Text = "Walk-In Guest Details";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(419, 380);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 47;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(432, 380);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(592, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 49;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(358, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 50;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(366, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 51;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 52;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(382, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 53;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(390, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 54;
            this.label6.Text = "label6";
            // 
            // frmCheckIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1920, 960);
            this.Controls.Add(this.pnlWalkIn);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.pnlReservationDetails);
            this.Name = "frmCheckIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Management System - Check-In";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCheckIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayArrivals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWalkInAvailable)).EndInit();
            this.pnlReservationDetails.ResumeLayout(false);
            this.pnlReservationDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeposit)).EndInit();
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.pnlWalkIn.ResumeLayout(false);
            this.pnlWalkIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWalkInDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWalkInChildren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWalkInAdults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTodayArrivals;
        private System.Windows.Forms.DataGridView dgvWalkInAvailable;
        private System.Windows.Forms.Panel pnlReservationDetails;
        private System.Windows.Forms.Label lblGuestName;
        private System.Windows.Forms.Label lblBookingRef;
        private System.Windows.Forms.Label lblRoomNumber;
        private System.Windows.Forms.Label lblAmountDue;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.Button btnProcessCheckIn;
        private System.Windows.Forms.Button btnWalkInCheckIn;
        private System.Windows.Forms.Button btnPrintKeyCard;
        private System.Windows.Forms.DateTimePicker dtpActualCheckIn;
        private System.Windows.Forms.NumericUpDown nudDeposit;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.RichTextBox rtbCheckInNotes;
        private System.Windows.Forms.Label lblChck;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Label lblGuestDetails;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.Label lblActPay;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDeposit;
        private System.Windows.Forms.Label lblArrivals;
        private System.Windows.Forms.Label lblSel;
        private System.Windows.Forms.Panel pnlWalkIn;
        private System.Windows.Forms.CheckBox chkPrintWalkInKeyCard;
        private System.Windows.Forms.NumericUpDown nudWalkInDeposit;
        private System.Windows.Forms.NumericUpDown nudWalkInChildren;
        private System.Windows.Forms.NumericUpDown nudWalkInAdults;
        private System.Windows.Forms.DateTimePicker dtpWalkInCheckOut;
        private System.Windows.Forms.Label lblWalkInDeposit;
        private System.Windows.Forms.Label lblWalkInChildren;
        private System.Windows.Forms.Label lblWalkInAdults;
        private System.Windows.Forms.Label lblWalkInCheckOut;
        private System.Windows.Forms.TextBox txtWalkInEmail;
        private System.Windows.Forms.Label lblWalkInEmail;
        private System.Windows.Forms.TextBox txtWalkInPhone;
        private System.Windows.Forms.Label lblWalkInPhone;
        private System.Windows.Forms.TextBox txtWalkInLastName;
        private System.Windows.Forms.Label lblWalkInLastName;
        private System.Windows.Forms.TextBox txtWalkInFirstName;
        private System.Windows.Forms.Label lblWalkInFirstName;
        private System.Windows.Forms.Label lblWalkInGuestDetails;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblArrivalsCount;
        private System.Windows.Forms.Label lblWalkInRoomsCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}