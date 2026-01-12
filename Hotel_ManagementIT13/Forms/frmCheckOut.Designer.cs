namespace Hotel_ManagementIT13.Forms
{
    partial class frmCheckOut
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
            this.dgvTodayDepartures = new System.Windows.Forms.DataGridView();
            this.pnlGuestDetails = new System.Windows.Forms.Panel();
            this.lblActualCh = new System.Windows.Forms.Label();
            this.lblPaymentAm = new System.Windows.Forms.Label();
            this.lblPayMet = new System.Windows.Forms.Label();
            this.lblLateHr = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAP = new System.Windows.Forms.Label();
            this.lblTotalBi = new System.Windows.Forms.Label();
            this.lblNumb = new System.Windows.Forms.Label();
            this.lblNm = new System.Windows.Forms.Label();
            this.lblGuestDetails = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblAmountPaid = new System.Windows.Forms.Label();
            this.lblTotalBill = new System.Windows.Forms.Label();
            this.lblRoomNumber = new System.Windows.Forms.Label();
            this.lblGuestName = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.txtPaymentAmount = new System.Windows.Forms.TextBox();
            this.lblLateFee = new System.Windows.Forms.Label();
            this.nudLateCheckoutHours = new System.Windows.Forms.NumericUpDown();
            this.dtpActualCheckOut = new System.Windows.Forms.DateTimePicker();
            this.btnAddCharge = new System.Windows.Forms.Button();
            this.btnPrintInvoice = new System.Windows.Forms.Button();
            this.btnProcessCheckOut = new System.Windows.Forms.Button();
            this.dgvBillingItems = new System.Windows.Forms.DataGridView();
            this.lblDeparturesCount = new System.Windows.Forms.Label();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.lblBils = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMainDash = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayDepartures)).BeginInit();
            this.pnlGuestDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLateCheckoutHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillingItems)).BeginInit();
            this.pnlDetails.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTodayDepartures
            // 
            this.dgvTodayDepartures.AllowUserToAddRows = false;
            this.dgvTodayDepartures.AllowUserToDeleteRows = false;
            this.dgvTodayDepartures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTodayDepartures.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTodayDepartures.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvTodayDepartures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTodayDepartures.Location = new System.Drawing.Point(39, 34);
            this.dgvTodayDepartures.Name = "dgvTodayDepartures";
            this.dgvTodayDepartures.ReadOnly = true;
            this.dgvTodayDepartures.RowHeadersWidth = 51;
            this.dgvTodayDepartures.RowTemplate.Height = 30;
            this.dgvTodayDepartures.Size = new System.Drawing.Size(1240, 374);
            this.dgvTodayDepartures.TabIndex = 0;
            // 
            // pnlGuestDetails
            // 
            this.pnlGuestDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGuestDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pnlGuestDetails.Controls.Add(this.lblActualCh);
            this.pnlGuestDetails.Controls.Add(this.lblPaymentAm);
            this.pnlGuestDetails.Controls.Add(this.lblPayMet);
            this.pnlGuestDetails.Controls.Add(this.lblLateHr);
            this.pnlGuestDetails.Controls.Add(this.label3);
            this.pnlGuestDetails.Controls.Add(this.label1);
            this.pnlGuestDetails.Controls.Add(this.lblAP);
            this.pnlGuestDetails.Controls.Add(this.lblTotalBi);
            this.pnlGuestDetails.Controls.Add(this.lblNumb);
            this.pnlGuestDetails.Controls.Add(this.lblNm);
            this.pnlGuestDetails.Controls.Add(this.lblGuestDetails);
            this.pnlGuestDetails.Controls.Add(this.lblBalance);
            this.pnlGuestDetails.Controls.Add(this.lblAmountPaid);
            this.pnlGuestDetails.Controls.Add(this.lblTotalBill);
            this.pnlGuestDetails.Controls.Add(this.lblRoomNumber);
            this.pnlGuestDetails.Controls.Add(this.lblGuestName);
            this.pnlGuestDetails.Controls.Add(this.cmbPaymentMethod);
            this.pnlGuestDetails.Controls.Add(this.txtPaymentAmount);
            this.pnlGuestDetails.Controls.Add(this.lblLateFee);
            this.pnlGuestDetails.Controls.Add(this.nudLateCheckoutHours);
            this.pnlGuestDetails.Controls.Add(this.dtpActualCheckOut);
            this.pnlGuestDetails.Controls.Add(this.btnAddCharge);
            this.pnlGuestDetails.Controls.Add(this.btnPrintInvoice);
            this.pnlGuestDetails.Controls.Add(this.btnProcessCheckOut);
            this.pnlGuestDetails.Location = new System.Drawing.Point(1372, 108);
            this.pnlGuestDetails.Name = "pnlGuestDetails";
            this.pnlGuestDetails.Size = new System.Drawing.Size(500, 814);
            this.pnlGuestDetails.TabIndex = 1;
            // 
            // lblActualCh
            // 
            this.lblActualCh.AutoSize = true;
            this.lblActualCh.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualCh.Location = new System.Drawing.Point(34, 377);
            this.lblActualCh.Name = "lblActualCh";
            this.lblActualCh.Size = new System.Drawing.Size(226, 28);
            this.lblActualCh.TabIndex = 38;
            this.lblActualCh.Text = "Actual Check Out Date:";
            // 
            // lblPaymentAm
            // 
            this.lblPaymentAm.AutoSize = true;
            this.lblPaymentAm.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentAm.Location = new System.Drawing.Point(34, 444);
            this.lblPaymentAm.Name = "lblPaymentAm";
            this.lblPaymentAm.Size = new System.Drawing.Size(180, 28);
            this.lblPaymentAm.TabIndex = 37;
            this.lblPaymentAm.Text = "Payment Amount:";
            // 
            // lblPayMet
            // 
            this.lblPayMet.AutoSize = true;
            this.lblPayMet.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayMet.Location = new System.Drawing.Point(34, 584);
            this.lblPayMet.Name = "lblPayMet";
            this.lblPayMet.Size = new System.Drawing.Size(180, 28);
            this.lblPayMet.TabIndex = 36;
            this.lblPayMet.Text = "Payment Method:";
            // 
            // lblLateHr
            // 
            this.lblLateHr.AutoSize = true;
            this.lblLateHr.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLateHr.Location = new System.Drawing.Point(34, 514);
            this.lblLateHr.Name = "lblLateHr";
            this.lblLateHr.Size = new System.Drawing.Size(118, 28);
            this.lblLateHr.TabIndex = 35;
            this.lblLateHr.Text = "Late Hours:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 321);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 28);
            this.label3.TabIndex = 34;
            this.label3.Text = "Late Fee:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(34, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 28);
            this.label1.TabIndex = 33;
            this.label1.Text = "Balance:";
            // 
            // lblAP
            // 
            this.lblAP.AutoSize = true;
            this.lblAP.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAP.Location = new System.Drawing.Point(34, 204);
            this.lblAP.Name = "lblAP";
            this.lblAP.Size = new System.Drawing.Size(138, 28);
            this.lblAP.TabIndex = 32;
            this.lblAP.Text = "Amount Paid:";
            // 
            // lblTotalBi
            // 
            this.lblTotalBi.AutoSize = true;
            this.lblTotalBi.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotalBi.Location = new System.Drawing.Point(34, 146);
            this.lblTotalBi.Name = "lblTotalBi";
            this.lblTotalBi.Size = new System.Drawing.Size(96, 28);
            this.lblTotalBi.TabIndex = 30;
            this.lblTotalBi.Text = "Total Bill:";
            // 
            // lblNumb
            // 
            this.lblNumb.AutoSize = true;
            this.lblNumb.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumb.Location = new System.Drawing.Point(34, 88);
            this.lblNumb.Name = "lblNumb";
            this.lblNumb.Size = new System.Drawing.Size(153, 28);
            this.lblNumb.TabIndex = 29;
            this.lblNumb.Text = "Room Number:";
            // 
            // lblNm
            // 
            this.lblNm.AutoSize = true;
            this.lblNm.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNm.Location = new System.Drawing.Point(34, 30);
            this.lblNm.Name = "lblNm";
            this.lblNm.Size = new System.Drawing.Size(133, 28);
            this.lblNm.TabIndex = 28;
            this.lblNm.Text = "Guest Name:";
            // 
            // lblGuestDetails
            // 
            this.lblGuestDetails.AutoSize = true;
            this.lblGuestDetails.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestDetails.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblGuestDetails.Location = new System.Drawing.Point(34, 3);
            this.lblGuestDetails.Name = "lblGuestDetails";
            this.lblGuestDetails.Size = new System.Drawing.Size(149, 27);
            this.lblGuestDetails.TabIndex = 27;
            this.lblGuestDetails.Text = "Guest Details";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBalance.Location = new System.Drawing.Point(34, 290);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(144, 28);
            this.lblBalance.TabIndex = 7;
            this.lblBalance.Text = "____________";
            // 
            // lblAmountPaid
            // 
            this.lblAmountPaid.AutoSize = true;
            this.lblAmountPaid.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountPaid.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAmountPaid.Location = new System.Drawing.Point(34, 232);
            this.lblAmountPaid.Name = "lblAmountPaid";
            this.lblAmountPaid.Size = new System.Drawing.Size(144, 28);
            this.lblAmountPaid.TabIndex = 6;
            this.lblAmountPaid.Text = "____________";
            // 
            // lblTotalBill
            // 
            this.lblTotalBill.AutoSize = true;
            this.lblTotalBill.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBill.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotalBill.Location = new System.Drawing.Point(34, 174);
            this.lblTotalBill.Name = "lblTotalBill";
            this.lblTotalBill.Size = new System.Drawing.Size(144, 28);
            this.lblTotalBill.TabIndex = 5;
            this.lblTotalBill.Text = "____________";
            // 
            // lblRoomNumber
            // 
            this.lblRoomNumber.AutoSize = true;
            this.lblRoomNumber.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomNumber.Location = new System.Drawing.Point(34, 116);
            this.lblRoomNumber.Name = "lblRoomNumber";
            this.lblRoomNumber.Size = new System.Drawing.Size(144, 28);
            this.lblRoomNumber.TabIndex = 4;
            this.lblRoomNumber.Text = "____________";
            // 
            // lblGuestName
            // 
            this.lblGuestName.AutoSize = true;
            this.lblGuestName.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGuestName.Location = new System.Drawing.Point(34, 58);
            this.lblGuestName.Name = "lblGuestName";
            this.lblGuestName.Size = new System.Drawing.Size(144, 28);
            this.lblGuestName.TabIndex = 3;
            this.lblGuestName.Text = "____________";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Location = new System.Drawing.Point(39, 615);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(422, 36);
            this.cmbPaymentMethod.TabIndex = 13;
            this.cmbPaymentMethod.Text = "Payment Method";
            // 
            // txtPaymentAmount
            // 
            this.txtPaymentAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPaymentAmount.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentAmount.Location = new System.Drawing.Point(39, 475);
            this.txtPaymentAmount.Name = "txtPaymentAmount";
            this.txtPaymentAmount.Size = new System.Drawing.Size(422, 36);
            this.txtPaymentAmount.TabIndex = 8;
            this.txtPaymentAmount.Text = "0.00";
            // 
            // lblLateFee
            // 
            this.lblLateFee.AutoSize = true;
            this.lblLateFee.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLateFee.Location = new System.Drawing.Point(34, 349);
            this.lblLateFee.Name = "lblLateFee";
            this.lblLateFee.Size = new System.Drawing.Size(144, 28);
            this.lblLateFee.TabIndex = 15;
            this.lblLateFee.Text = "____________";
            // 
            // nudLateCheckoutHours
            // 
            this.nudLateCheckoutHours.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudLateCheckoutHours.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLateCheckoutHours.Location = new System.Drawing.Point(39, 545);
            this.nudLateCheckoutHours.Name = "nudLateCheckoutHours";
            this.nudLateCheckoutHours.Size = new System.Drawing.Size(422, 36);
            this.nudLateCheckoutHours.TabIndex = 14;
            this.nudLateCheckoutHours.ValueChanged += new System.EventHandler(this.nudLateCheckoutHours_ValueChanged);
            // 
            // dtpActualCheckOut
            // 
            this.dtpActualCheckOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpActualCheckOut.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpActualCheckOut.Location = new System.Drawing.Point(39, 405);
            this.dtpActualCheckOut.Name = "dtpActualCheckOut";
            this.dtpActualCheckOut.Size = new System.Drawing.Size(422, 36);
            this.dtpActualCheckOut.TabIndex = 12;
            this.dtpActualCheckOut.ValueChanged += new System.EventHandler(this.dtpActualCheckOut_ValueChanged);
            // 
            // btnAddCharge
            // 
            this.btnAddCharge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCharge.BackColor = System.Drawing.Color.Thistle;
            this.btnAddCharge.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCharge.ForeColor = System.Drawing.Color.Black;
            this.btnAddCharge.Location = new System.Drawing.Point(311, 735);
            this.btnAddCharge.Name = "btnAddCharge";
            this.btnAddCharge.Size = new System.Drawing.Size(150, 50);
            this.btnAddCharge.TabIndex = 11;
            this.btnAddCharge.Text = "Add Charge";
            this.btnAddCharge.UseVisualStyleBackColor = false;
            this.btnAddCharge.Click += new System.EventHandler(this.btnAddCharge_Click);
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintInvoice.BackColor = System.Drawing.Color.Blue;
            this.btnPrintInvoice.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintInvoice.ForeColor = System.Drawing.Color.White;
            this.btnPrintInvoice.Location = new System.Drawing.Point(858, 425);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(200, 50);
            this.btnPrintInvoice.TabIndex = 10;
            this.btnPrintInvoice.Text = "PRINT INVOICE";
            this.btnPrintInvoice.UseVisualStyleBackColor = false;
            this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoice_Click);
            // 
            // btnProcessCheckOut
            // 
            this.btnProcessCheckOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProcessCheckOut.BackColor = System.Drawing.Color.Thistle;
            this.btnProcessCheckOut.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessCheckOut.ForeColor = System.Drawing.Color.Black;
            this.btnProcessCheckOut.Location = new System.Drawing.Point(39, 735);
            this.btnProcessCheckOut.Name = "btnProcessCheckOut";
            this.btnProcessCheckOut.Size = new System.Drawing.Size(150, 50);
            this.btnProcessCheckOut.TabIndex = 9;
            this.btnProcessCheckOut.Text = "Process";
            this.btnProcessCheckOut.UseVisualStyleBackColor = false;
            this.btnProcessCheckOut.Click += new System.EventHandler(this.btnProcessCheckOut_Click);
            // 
            // dgvBillingItems
            // 
            this.dgvBillingItems.AllowUserToAddRows = false;
            this.dgvBillingItems.AllowUserToDeleteRows = false;
            this.dgvBillingItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBillingItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBillingItems.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvBillingItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillingItems.Location = new System.Drawing.Point(39, 442);
            this.dgvBillingItems.Name = "dgvBillingItems";
            this.dgvBillingItems.ReadOnly = true;
            this.dgvBillingItems.RowHeadersWidth = 51;
            this.dgvBillingItems.RowTemplate.Height = 30;
            this.dgvBillingItems.Size = new System.Drawing.Size(1240, 343);
            this.dgvBillingItems.TabIndex = 7;
            // 
            // lblDeparturesCount
            // 
            this.lblDeparturesCount.AutoSize = true;
            this.lblDeparturesCount.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeparturesCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDeparturesCount.Location = new System.Drawing.Point(34, 3);
            this.lblDeparturesCount.Name = "lblDeparturesCount";
            this.lblDeparturesCount.Size = new System.Drawing.Size(203, 28);
            this.lblDeparturesCount.TabIndex = 16;
            this.lblDeparturesCount.Text = "0 departure(s) today";
            // 
            // pnlDetails
            // 
            this.pnlDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pnlDetails.Controls.Add(this.lblBils);
            this.pnlDetails.Controls.Add(this.lblDeparturesCount);
            this.pnlDetails.Controls.Add(this.dgvTodayDepartures);
            this.pnlDetails.Controls.Add(this.dgvBillingItems);
            this.pnlDetails.Location = new System.Drawing.Point(48, 108);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(1318, 814);
            this.pnlDetails.TabIndex = 18;
            // 
            // lblBils
            // 
            this.lblBils.AutoSize = true;
            this.lblBils.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBils.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBils.Location = new System.Drawing.Point(34, 411);
            this.lblBils.Name = "lblBils";
            this.lblBils.Size = new System.Drawing.Size(124, 28);
            this.lblBils.TabIndex = 26;
            this.lblBils.Text = "billing Items";
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
            this.panel1.TabIndex = 39;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label2.Location = new System.Drawing.Point(4, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "Check-Out Page";
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
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.BackgroundImage = global::Hotel_ManagementIT13.Properties.Resources.clarity__refresh_line;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1874, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(35, 35);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmCheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(220)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1920, 960);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.pnlGuestDetails);
            this.Name = "frmCheckOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Management System - Check-Out";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCheckOut_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayDepartures)).EndInit();
            this.pnlGuestDetails.ResumeLayout(false);
            this.pnlGuestDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLateCheckoutHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillingItems)).EndInit();
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTodayDepartures;
        private System.Windows.Forms.Panel pnlGuestDetails;
        private System.Windows.Forms.Label lblGuestName;
        private System.Windows.Forms.Label lblRoomNumber;
        private System.Windows.Forms.Label lblTotalBill;
        private System.Windows.Forms.Label lblAmountPaid;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.DataGridView dgvBillingItems;
        private System.Windows.Forms.TextBox txtPaymentAmount;
        private System.Windows.Forms.Button btnProcessCheckOut;
        private System.Windows.Forms.Button btnPrintInvoice;
        private System.Windows.Forms.Button btnAddCharge;
        private System.Windows.Forms.DateTimePicker dtpActualCheckOut;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.NumericUpDown nudLateCheckoutHours;
        private System.Windows.Forms.Label lblLateFee;
        private System.Windows.Forms.Label lblDeparturesCount;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Label lblNm;
        private System.Windows.Forms.Label lblGuestDetails;
        private System.Windows.Forms.Label lblNumb;
        private System.Windows.Forms.Label lblTotalBi;
        private System.Windows.Forms.Label lblLateHr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAP;
        private System.Windows.Forms.Label lblActualCh;
        private System.Windows.Forms.Label lblPaymentAm;
        private System.Windows.Forms.Label lblPayMet;
        private System.Windows.Forms.Label lblBils;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMainDash;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
    }
}