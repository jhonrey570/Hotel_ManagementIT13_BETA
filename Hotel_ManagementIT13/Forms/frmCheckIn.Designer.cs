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
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.lblWalkInRoomsCount = new System.Windows.Forms.Label();
            this.lblArrivalsCount = new System.Windows.Forms.Label();
            this.pnlWalkIn = new System.Windows.Forms.Panel();
            this.cmbWalkInPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblWalkInPaymentMethod = new System.Windows.Forms.Label();
            this.nudWalkInPaymentAmount = new System.Windows.Forms.NumericUpDown();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblWalkInPaymentAmount = new System.Windows.Forms.Label();
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
            this.btnWalkInCheckIn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMainDash = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayArrivals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWalkInAvailable)).BeginInit();
            this.pnlReservationDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeposit)).BeginInit();
            this.pnlDetails.SuspendLayout();
            this.pnlWalkIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWalkInPaymentAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWalkInDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWalkInChildren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWalkInAdults)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTodayArrivals
            // 
            this.dgvTodayArrivals.AllowUserToAddRows = false;
            this.dgvTodayArrivals.AllowUserToDeleteRows = false;
            this.dgvTodayArrivals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTodayArrivals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTodayArrivals.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvTodayArrivals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTodayArrivals.Location = new System.Drawing.Point(39, 34);
            this.dgvTodayArrivals.Name = "dgvTodayArrivals";
            this.dgvTodayArrivals.ReadOnly = true;
            this.dgvTodayArrivals.RowHeadersWidth = 51;
            this.dgvTodayArrivals.RowTemplate.Height = 30;
            this.dgvTodayArrivals.Size = new System.Drawing.Size(1240, 374);
            this.dgvTodayArrivals.TabIndex = 0;
            // 
            // dgvWalkInAvailable
            // 
            this.dgvWalkInAvailable.AllowUserToAddRows = false;
            this.dgvWalkInAvailable.AllowUserToDeleteRows = false;
            this.dgvWalkInAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWalkInAvailable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWalkInAvailable.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvWalkInAvailable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWalkInAvailable.Location = new System.Drawing.Point(39, 442);
            this.dgvWalkInAvailable.Name = "dgvWalkInAvailable";
            this.dgvWalkInAvailable.ReadOnly = true;
            this.dgvWalkInAvailable.RowHeadersWidth = 51;
            this.dgvWalkInAvailable.RowTemplate.Height = 30;
            this.dgvWalkInAvailable.Size = new System.Drawing.Size(1240, 343);
            this.dgvWalkInAvailable.TabIndex = 1;
            // 
            // pnlReservationDetails
            // 
            this.pnlReservationDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReservationDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pnlReservationDetails.Controls.Add(this.label5);
            this.pnlReservationDetails.Controls.Add(this.label4);
            this.pnlReservationDetails.Controls.Add(this.label2);
            this.pnlReservationDetails.Controls.Add(this.label1);
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
            this.pnlReservationDetails.Location = new System.Drawing.Point(1372, 108);
            this.pnlReservationDetails.Name = "pnlReservationDetails";
            this.pnlReservationDetails.Size = new System.Drawing.Size(500, 436);
            this.pnlReservationDetails.TabIndex = 2;
            this.pnlReservationDetails.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlReservationDetails_Paint);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNotes.Location = new System.Drawing.Point(275, 308);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(118, 21);
            this.lblNotes.TabIndex = 31;
            this.lblNotes.Text = "Check-In Notes:";
            // 
            // btnPrintKeyCard
            // 
            this.btnPrintKeyCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintKeyCard.BackColor = System.Drawing.Color.Thistle;
            this.btnPrintKeyCard.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintKeyCard.ForeColor = System.Drawing.Color.Black;
            this.btnPrintKeyCard.Location = new System.Drawing.Point(137, 372);
            this.btnPrintKeyCard.Name = "btnPrintKeyCard";
            this.btnPrintKeyCard.Size = new System.Drawing.Size(100, 35);
            this.btnPrintKeyCard.TabIndex = 10;
            this.btnPrintKeyCard.Text = "Key Card";
            this.btnPrintKeyCard.UseVisualStyleBackColor = false;
            this.btnPrintKeyCard.Click += new System.EventHandler(this.btnPrintKeyCard_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDate.Location = new System.Drawing.Point(36, 198);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(109, 21);
            this.lblDate.TabIndex = 30;
            this.lblDate.Text = "Check-In Date:";
            this.lblDate.Click += new System.EventHandler(this.lblDate_Click);
            // 
            // lblDeposit
            // 
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeposit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDeposit.Location = new System.Drawing.Point(275, 253);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(129, 21);
            this.lblDeposit.TabIndex = 29;
            this.lblDeposit.Text = "Deposit Amount:";
            // 
            // btnProcessCheckIn
            // 
            this.btnProcessCheckIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProcessCheckIn.BackColor = System.Drawing.Color.Thistle;
            this.btnProcessCheckIn.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessCheckIn.ForeColor = System.Drawing.Color.Black;
            this.btnProcessCheckIn.Location = new System.Drawing.Point(39, 372);
            this.btnProcessCheckIn.Name = "btnProcessCheckIn";
            this.btnProcessCheckIn.Size = new System.Drawing.Size(100, 35);
            this.btnProcessCheckIn.TabIndex = 8;
            this.btnProcessCheckIn.Text = "Process";
            this.btnProcessCheckIn.UseVisualStyleBackColor = false;
            this.btnProcessCheckIn.Click += new System.EventHandler(this.btnProcessCheckIn_Click);
            // 
            // dtpActualCheckIn
            // 
            this.dtpActualCheckIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpActualCheckIn.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpActualCheckIn.Location = new System.Drawing.Point(39, 222);
            this.dtpActualCheckIn.Name = "dtpActualCheckIn";
            this.dtpActualCheckIn.Size = new System.Drawing.Size(422, 28);
            this.dtpActualCheckIn.TabIndex = 11;
            // 
            // lblActPay
            // 
            this.lblActPay.AutoSize = true;
            this.lblActPay.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActPay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblActPay.Location = new System.Drawing.Point(35, 253);
            this.lblActPay.Name = "lblActPay";
            this.lblActPay.Size = new System.Drawing.Size(138, 21);
            this.lblActPay.TabIndex = 28;
            this.lblActPay.Text = "Payment Amount:";
            // 
            // lblPayment
            // 
            this.lblPayment.AutoSize = true;
            this.lblPayment.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayment.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPayment.Location = new System.Drawing.Point(36, 308);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(137, 21);
            this.lblPayment.TabIndex = 27;
            this.lblPayment.Text = "Payment Method:";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.BackColor = System.Drawing.Color.White;
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Location = new System.Drawing.Point(39, 332);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(198, 29);
            this.cmbPaymentMethod.TabIndex = 13;
            // 
            // nudDeposit
            // 
            this.nudDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudDeposit.BackColor = System.Drawing.Color.White;
            this.nudDeposit.DecimalPlaces = 2;
            this.nudDeposit.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDeposit.Location = new System.Drawing.Point(279, 277);
            this.nudDeposit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudDeposit.Name = "nudDeposit";
            this.nudDeposit.Size = new System.Drawing.Size(182, 28);
            this.nudDeposit.TabIndex = 12;
            // 
            // lblGuestDetails
            // 
            this.lblGuestDetails.AutoSize = true;
            this.lblGuestDetails.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestDetails.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblGuestDetails.Location = new System.Drawing.Point(34, 3);
            this.lblGuestDetails.Name = "lblGuestDetails";
            this.lblGuestDetails.Size = new System.Drawing.Size(262, 27);
            this.lblGuestDetails.TabIndex = 26;
            this.lblGuestDetails.Text = "Guest Information Form";
            // 
            // rtbCheckInNotes
            // 
            this.rtbCheckInNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbCheckInNotes.BackColor = System.Drawing.Color.White;
            this.rtbCheckInNotes.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbCheckInNotes.Location = new System.Drawing.Point(279, 332);
            this.rtbCheckInNotes.Name = "rtbCheckInNotes";
            this.rtbCheckInNotes.Size = new System.Drawing.Size(182, 76);
            this.rtbCheckInNotes.TabIndex = 14;
            this.rtbCheckInNotes.Text = "";
            // 
            // lblGuestName
            // 
            this.lblGuestName.AutoSize = true;
            this.lblGuestName.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGuestName.Location = new System.Drawing.Point(35, 51);
            this.lblGuestName.Name = "lblGuestName";
            this.lblGuestName.Size = new System.Drawing.Size(106, 21);
            this.lblGuestName.TabIndex = 3;
            this.lblGuestName.Text = "____________";
            // 
            // lblBookingRef
            // 
            this.lblBookingRef.AutoSize = true;
            this.lblBookingRef.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingRef.Location = new System.Drawing.Point(35, 135);
            this.lblBookingRef.Name = "lblBookingRef";
            this.lblBookingRef.Size = new System.Drawing.Size(106, 21);
            this.lblBookingRef.TabIndex = 4;
            this.lblBookingRef.Text = "____________";
            // 
            // lblRoomNumber
            // 
            this.lblRoomNumber.AutoSize = true;
            this.lblRoomNumber.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomNumber.Location = new System.Drawing.Point(35, 93);
            this.lblRoomNumber.Name = "lblRoomNumber";
            this.lblRoomNumber.Size = new System.Drawing.Size(106, 21);
            this.lblRoomNumber.TabIndex = 5;
            this.lblRoomNumber.Text = "____________";
            // 
            // txtPayment
            // 
            this.txtPayment.BackColor = System.Drawing.Color.White;
            this.txtPayment.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayment.Location = new System.Drawing.Point(39, 277);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(198, 28);
            this.txtPayment.TabIndex = 7;
            // 
            // lblAmountDue
            // 
            this.lblAmountDue.AutoSize = true;
            this.lblAmountDue.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountDue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAmountDue.Location = new System.Drawing.Point(35, 177);
            this.lblAmountDue.Name = "lblAmountDue";
            this.lblAmountDue.Size = new System.Drawing.Size(106, 21);
            this.lblAmountDue.TabIndex = 6;
            this.lblAmountDue.Text = "____________";
            // 
            // pnlDetails
            // 
            this.pnlDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pnlDetails.Controls.Add(this.lblWalkInRoomsCount);
            this.pnlDetails.Controls.Add(this.lblArrivalsCount);
            this.pnlDetails.Controls.Add(this.dgvTodayArrivals);
            this.pnlDetails.Controls.Add(this.dgvWalkInAvailable);
            this.pnlDetails.Location = new System.Drawing.Point(48, 108);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(1318, 814);
            this.pnlDetails.TabIndex = 26;
            // 
            // lblWalkInRoomsCount
            // 
            this.lblWalkInRoomsCount.AutoSize = true;
            this.lblWalkInRoomsCount.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalkInRoomsCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWalkInRoomsCount.Location = new System.Drawing.Point(34, 411);
            this.lblWalkInRoomsCount.Name = "lblWalkInRoomsCount";
            this.lblWalkInRoomsCount.Size = new System.Drawing.Size(290, 28);
            this.lblWalkInRoomsCount.TabIndex = 33;
            this.lblWalkInRoomsCount.Text = "0 room(s) available for walk-in";
            // 
            // lblArrivalsCount
            // 
            this.lblArrivalsCount.AutoSize = true;
            this.lblArrivalsCount.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrivalsCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblArrivalsCount.Location = new System.Drawing.Point(34, 3);
            this.lblArrivalsCount.Name = "lblArrivalsCount";
            this.lblArrivalsCount.Size = new System.Drawing.Size(168, 28);
            this.lblArrivalsCount.TabIndex = 32;
            this.lblArrivalsCount.Text = "0 arrival(s) today";
            // 
            // pnlWalkIn
            // 
            this.pnlWalkIn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWalkIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pnlWalkIn.Controls.Add(this.cmbWalkInPaymentMethod);
            this.pnlWalkIn.Controls.Add(this.lblWalkInPaymentMethod);
            this.pnlWalkIn.Controls.Add(this.nudWalkInPaymentAmount);
            this.pnlWalkIn.Controls.Add(this.lblWalkInPaymentAmount);
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
            this.pnlWalkIn.Location = new System.Drawing.Point(1372, 550);
            this.pnlWalkIn.Name = "pnlWalkIn";
            this.pnlWalkIn.Size = new System.Drawing.Size(500, 372);
            this.pnlWalkIn.TabIndex = 27;
            this.pnlWalkIn.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlWalkIn_Paint);
            // 
            // cmbWalkInPaymentMethod
            // 
            this.cmbWalkInPaymentMethod.BackColor = System.Drawing.Color.White;
            this.cmbWalkInPaymentMethod.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWalkInPaymentMethod.FormattingEnabled = true;
            this.cmbWalkInPaymentMethod.Location = new System.Drawing.Point(39, 278);
            this.cmbWalkInPaymentMethod.Name = "cmbWalkInPaymentMethod";
            this.cmbWalkInPaymentMethod.Size = new System.Drawing.Size(197, 29);
            this.cmbWalkInPaymentMethod.TabIndex = 50;
            // 
            // lblWalkInPaymentMethod
            // 
            this.lblWalkInPaymentMethod.AutoSize = true;
            this.lblWalkInPaymentMethod.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalkInPaymentMethod.Location = new System.Drawing.Point(36, 254);
            this.lblWalkInPaymentMethod.Name = "lblWalkInPaymentMethod";
            this.lblWalkInPaymentMethod.Size = new System.Drawing.Size(132, 21);
            this.lblWalkInPaymentMethod.TabIndex = 49;
            this.lblWalkInPaymentMethod.Text = "Payment Method";
            // 
            // nudWalkInPaymentAmount
            // 
            this.nudWalkInPaymentAmount.BackColor = System.Drawing.Color.White;
            this.nudWalkInPaymentAmount.DecimalPlaces = 2;
            this.nudWalkInPaymentAmount.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudWalkInPaymentAmount.Location = new System.Drawing.Point(39, 223);
            this.nudWalkInPaymentAmount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWalkInPaymentAmount.Name = "nudWalkInPaymentAmount";
            this.nudWalkInPaymentAmount.Size = new System.Drawing.Size(198, 28);
            this.nudWalkInPaymentAmount.TabIndex = 48;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.BackgroundImage = global::Hotel_ManagementIT13.Properties.Resources.clarity__refresh_line;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1874, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(35, 35);
            this.btnRefresh.TabIndex = 46;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblWalkInPaymentAmount
            // 
            this.lblWalkInPaymentAmount.AutoSize = true;
            this.lblWalkInPaymentAmount.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalkInPaymentAmount.Location = new System.Drawing.Point(36, 195);
            this.lblWalkInPaymentAmount.Name = "lblWalkInPaymentAmount";
            this.lblWalkInPaymentAmount.Size = new System.Drawing.Size(138, 21);
            this.lblWalkInPaymentAmount.TabIndex = 47;
            this.lblWalkInPaymentAmount.Text = "Payment Amount:";
            // 
            // chkPrintWalkInKeyCard
            // 
            this.chkPrintWalkInKeyCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkPrintWalkInKeyCard.AutoSize = true;
            this.chkPrintWalkInKeyCard.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrintWalkInKeyCard.Location = new System.Drawing.Point(144, 314);
            this.chkPrintWalkInKeyCard.Name = "chkPrintWalkInKeyCard";
            this.chkPrintWalkInKeyCard.Size = new System.Drawing.Size(93, 25);
            this.chkPrintWalkInKeyCard.TabIndex = 26;
            this.chkPrintWalkInKeyCard.Text = "Key Card";
            this.chkPrintWalkInKeyCard.UseVisualStyleBackColor = true;
            // 
            // nudWalkInDeposit
            // 
            this.nudWalkInDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudWalkInDeposit.BackColor = System.Drawing.Color.White;
            this.nudWalkInDeposit.DecimalPlaces = 2;
            this.nudWalkInDeposit.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudWalkInDeposit.Location = new System.Drawing.Point(279, 274);
            this.nudWalkInDeposit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWalkInDeposit.Name = "nudWalkInDeposit";
            this.nudWalkInDeposit.Size = new System.Drawing.Size(182, 28);
            this.nudWalkInDeposit.TabIndex = 25;
            // 
            // nudWalkInChildren
            // 
            this.nudWalkInChildren.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudWalkInChildren.BackColor = System.Drawing.Color.White;
            this.nudWalkInChildren.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudWalkInChildren.Location = new System.Drawing.Point(279, 109);
            this.nudWalkInChildren.Name = "nudWalkInChildren";
            this.nudWalkInChildren.Size = new System.Drawing.Size(182, 28);
            this.nudWalkInChildren.TabIndex = 24;
            // 
            // nudWalkInAdults
            // 
            this.nudWalkInAdults.BackColor = System.Drawing.Color.White;
            this.nudWalkInAdults.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudWalkInAdults.Location = new System.Drawing.Point(40, 109);
            this.nudWalkInAdults.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWalkInAdults.Name = "nudWalkInAdults";
            this.nudWalkInAdults.Size = new System.Drawing.Size(197, 28);
            this.nudWalkInAdults.TabIndex = 23;
            this.nudWalkInAdults.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtpWalkInCheckOut
            // 
            this.dtpWalkInCheckOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpWalkInCheckOut.CalendarFont = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpWalkInCheckOut.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpWalkInCheckOut.Location = new System.Drawing.Point(279, 219);
            this.dtpWalkInCheckOut.Name = "dtpWalkInCheckOut";
            this.dtpWalkInCheckOut.Size = new System.Drawing.Size(182, 28);
            this.dtpWalkInCheckOut.TabIndex = 22;
            // 
            // lblWalkInDeposit
            // 
            this.lblWalkInDeposit.AutoSize = true;
            this.lblWalkInDeposit.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalkInDeposit.Location = new System.Drawing.Point(275, 250);
            this.lblWalkInDeposit.Name = "lblWalkInDeposit";
            this.lblWalkInDeposit.Size = new System.Drawing.Size(129, 21);
            this.lblWalkInDeposit.TabIndex = 21;
            this.lblWalkInDeposit.Text = "Deposit Amount:";
            // 
            // lblWalkInChildren
            // 
            this.lblWalkInChildren.AutoSize = true;
            this.lblWalkInChildren.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalkInChildren.Location = new System.Drawing.Point(275, 85);
            this.lblWalkInChildren.Name = "lblWalkInChildren";
            this.lblWalkInChildren.Size = new System.Drawing.Size(152, 21);
            this.lblWalkInChildren.TabIndex = 20;
            this.lblWalkInChildren.Text = "Number of Children:";
            // 
            // lblWalkInAdults
            // 
            this.lblWalkInAdults.AutoSize = true;
            this.lblWalkInAdults.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalkInAdults.Location = new System.Drawing.Point(36, 85);
            this.lblWalkInAdults.Name = "lblWalkInAdults";
            this.lblWalkInAdults.Size = new System.Drawing.Size(60, 21);
            this.lblWalkInAdults.TabIndex = 19;
            this.lblWalkInAdults.Text = "Adults:";
            // 
            // lblWalkInCheckOut
            // 
            this.lblWalkInCheckOut.AutoSize = true;
            this.lblWalkInCheckOut.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalkInCheckOut.Location = new System.Drawing.Point(275, 195);
            this.lblWalkInCheckOut.Name = "lblWalkInCheckOut";
            this.lblWalkInCheckOut.Size = new System.Drawing.Size(120, 21);
            this.lblWalkInCheckOut.TabIndex = 17;
            this.lblWalkInCheckOut.Text = "Check-out Date:";
            // 
            // txtWalkInEmail
            // 
            this.txtWalkInEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWalkInEmail.BackColor = System.Drawing.Color.White;
            this.txtWalkInEmail.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWalkInEmail.Location = new System.Drawing.Point(279, 164);
            this.txtWalkInEmail.Name = "txtWalkInEmail";
            this.txtWalkInEmail.Size = new System.Drawing.Size(182, 28);
            this.txtWalkInEmail.TabIndex = 16;
            // 
            // lblWalkInEmail
            // 
            this.lblWalkInEmail.AutoSize = true;
            this.lblWalkInEmail.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalkInEmail.Location = new System.Drawing.Point(275, 140);
            this.lblWalkInEmail.Name = "lblWalkInEmail";
            this.lblWalkInEmail.Size = new System.Drawing.Size(53, 21);
            this.lblWalkInEmail.TabIndex = 15;
            this.lblWalkInEmail.Text = "Email:";
            this.lblWalkInEmail.Click += new System.EventHandler(this.lblWalkInEmail_Click);
            // 
            // txtWalkInPhone
            // 
            this.txtWalkInPhone.BackColor = System.Drawing.Color.White;
            this.txtWalkInPhone.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWalkInPhone.Location = new System.Drawing.Point(39, 164);
            this.txtWalkInPhone.Name = "txtWalkInPhone";
            this.txtWalkInPhone.Size = new System.Drawing.Size(198, 28);
            this.txtWalkInPhone.TabIndex = 14;
            // 
            // lblWalkInPhone
            // 
            this.lblWalkInPhone.AutoSize = true;
            this.lblWalkInPhone.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalkInPhone.Location = new System.Drawing.Point(35, 140);
            this.lblWalkInPhone.Name = "lblWalkInPhone";
            this.lblWalkInPhone.Size = new System.Drawing.Size(59, 21);
            this.lblWalkInPhone.TabIndex = 13;
            this.lblWalkInPhone.Text = "Phone:";
            // 
            // txtWalkInLastName
            // 
            this.txtWalkInLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWalkInLastName.BackColor = System.Drawing.Color.White;
            this.txtWalkInLastName.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWalkInLastName.Location = new System.Drawing.Point(279, 54);
            this.txtWalkInLastName.Name = "txtWalkInLastName";
            this.txtWalkInLastName.Size = new System.Drawing.Size(182, 28);
            this.txtWalkInLastName.TabIndex = 12;
            // 
            // lblWalkInLastName
            // 
            this.lblWalkInLastName.AutoSize = true;
            this.lblWalkInLastName.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalkInLastName.Location = new System.Drawing.Point(275, 30);
            this.lblWalkInLastName.Name = "lblWalkInLastName";
            this.lblWalkInLastName.Size = new System.Drawing.Size(88, 21);
            this.lblWalkInLastName.TabIndex = 11;
            this.lblWalkInLastName.Text = "Last Name:";
            // 
            // txtWalkInFirstName
            // 
            this.txtWalkInFirstName.BackColor = System.Drawing.Color.White;
            this.txtWalkInFirstName.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWalkInFirstName.Location = new System.Drawing.Point(40, 54);
            this.txtWalkInFirstName.Name = "txtWalkInFirstName";
            this.txtWalkInFirstName.Size = new System.Drawing.Size(197, 28);
            this.txtWalkInFirstName.TabIndex = 10;
            // 
            // lblWalkInFirstName
            // 
            this.lblWalkInFirstName.AutoSize = true;
            this.lblWalkInFirstName.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalkInFirstName.Location = new System.Drawing.Point(35, 30);
            this.lblWalkInFirstName.Name = "lblWalkInFirstName";
            this.lblWalkInFirstName.Size = new System.Drawing.Size(91, 21);
            this.lblWalkInFirstName.TabIndex = 9;
            this.lblWalkInFirstName.Text = "First Name:";
            // 
            // lblWalkInGuestDetails
            // 
            this.lblWalkInGuestDetails.AutoSize = true;
            this.lblWalkInGuestDetails.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalkInGuestDetails.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblWalkInGuestDetails.Location = new System.Drawing.Point(34, 3);
            this.lblWalkInGuestDetails.Name = "lblWalkInGuestDetails";
            this.lblWalkInGuestDetails.Size = new System.Drawing.Size(240, 27);
            this.lblWalkInGuestDetails.TabIndex = 8;
            this.lblWalkInGuestDetails.Text = "Walk-In Guest Details";
            // 
            // btnWalkInCheckIn
            // 
            this.btnWalkInCheckIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWalkInCheckIn.BackColor = System.Drawing.Color.Thistle;
            this.btnWalkInCheckIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWalkInCheckIn.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWalkInCheckIn.ForeColor = System.Drawing.Color.Black;
            this.btnWalkInCheckIn.Location = new System.Drawing.Point(39, 308);
            this.btnWalkInCheckIn.Name = "btnWalkInCheckIn";
            this.btnWalkInCheckIn.Size = new System.Drawing.Size(100, 35);
            this.btnWalkInCheckIn.TabIndex = 9;
            this.btnWalkInCheckIn.Text = "Process";
            this.btnWalkInCheckIn.UseVisualStyleBackColor = false;
            this.btnWalkInCheckIn.Click += new System.EventHandler(this.btnWalkInCheckIn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblMainDash);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 56);
            this.panel1.TabIndex = 28;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Hotel_ManagementIT13.Properties.Resources.logosaIT131;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // lblMainDash
            // 
            this.lblMainDash.AutoSize = true;
            this.lblMainDash.BackColor = System.Drawing.Color.Transparent;
            this.lblMainDash.Font = new System.Drawing.Font("Georgia", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainDash.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblMainDash.Location = new System.Drawing.Point(54, 9);
            this.lblMainDash.Name = "lblMainDash";
            this.lblMainDash.Size = new System.Drawing.Size(211, 39);
            this.lblMainDash.TabIndex = 31;
            this.lblMainDash.Text = "JMS HOTEL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label3.Location = new System.Drawing.Point(4, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Check-In Page";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(35, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 21);
            this.label1.TabIndex = 32;
            this.label1.Text = "Guest Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 21);
            this.label2.TabIndex = 33;
            this.label2.Text = "Room Number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 21);
            this.label4.TabIndex = 34;
            this.label4.Text = "Booking Ref:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(35, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 21);
            this.label5.TabIndex = 35;
            this.label5.Text = "Amount Due:";
            // 
            // frmCheckIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(220)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1920, 960);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
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
            ((System.ComponentModel.ISupportInitialize)(this.nudWalkInPaymentAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWalkInDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWalkInChildren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWalkInAdults)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Label lblGuestDetails;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.Label lblActPay;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDeposit;
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
        private System.Windows.Forms.NumericUpDown nudWalkInPaymentAmount;
        private System.Windows.Forms.Label lblWalkInPaymentAmount;
        private System.Windows.Forms.ComboBox cmbWalkInPaymentMethod;
        private System.Windows.Forms.Label lblWalkInPaymentMethod;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMainDash;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}