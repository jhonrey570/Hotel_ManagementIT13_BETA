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
            this.lblGuestName = new System.Windows.Forms.Label();
            this.lblRoomNumber = new System.Windows.Forms.Label();
            this.lblTotalBill = new System.Windows.Forms.Label();
            this.lblAmountPaid = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.dgvBillingItems = new System.Windows.Forms.DataGridView();
            this.txtPaymentAmount = new System.Windows.Forms.TextBox();
            this.btnProcessCheckOut = new System.Windows.Forms.Button();
            this.btnPrintInvoice = new System.Windows.Forms.Button();
            this.btnAddCharge = new System.Windows.Forms.Button();
            this.dtpActualCheckOut = new System.Windows.Forms.DateTimePicker();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.nudLateCheckoutHours = new System.Windows.Forms.NumericUpDown();
            this.lblLateFee = new System.Windows.Forms.Label();
            this.lblDeparturesCount = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayDepartures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillingItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLateCheckoutHours)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTodayDepartures
            // 
            this.dgvTodayDepartures.AllowUserToAddRows = false;
            this.dgvTodayDepartures.AllowUserToDeleteRows = false;
            this.dgvTodayDepartures.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTodayDepartures.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTodayDepartures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTodayDepartures.Location = new System.Drawing.Point(40, 40);
            this.dgvTodayDepartures.Name = "dgvTodayDepartures";
            this.dgvTodayDepartures.ReadOnly = true;
            this.dgvTodayDepartures.RowHeadersWidth = 51;
            this.dgvTodayDepartures.RowTemplate.Height = 30;
            this.dgvTodayDepartures.Size = new System.Drawing.Size(900, 400);
            this.dgvTodayDepartures.TabIndex = 0;
            this.dgvTodayDepartures.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTodayDepartures_CellClick);
            // 
            // pnlGuestDetails
            // 
            this.pnlGuestDetails.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlGuestDetails.Location = new System.Drawing.Point(1000, 40);
            this.pnlGuestDetails.Name = "pnlGuestDetails";
            this.pnlGuestDetails.Size = new System.Drawing.Size(880, 200);
            this.pnlGuestDetails.TabIndex = 1;
            // 
            // lblGuestName
            // 
            this.lblGuestName.AutoSize = true;
            this.lblGuestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestName.ForeColor = System.Drawing.Color.Blue;
            this.lblGuestName.Location = new System.Drawing.Point(1000, 260);
            this.lblGuestName.Name = "lblGuestName";
            this.lblGuestName.Size = new System.Drawing.Size(198, 36);
            this.lblGuestName.TabIndex = 2;
            this.lblGuestName.Text = "Guest Name:";
            // 
            // lblRoomNumber
            // 
            this.lblRoomNumber.AutoSize = true;
            this.lblRoomNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomNumber.Location = new System.Drawing.Point(1000, 320);
            this.lblRoomNumber.Name = "lblRoomNumber";
            this.lblRoomNumber.Size = new System.Drawing.Size(219, 31);
            this.lblRoomNumber.TabIndex = 3;
            this.lblRoomNumber.Text = "Room Number: #";
            // 
            // lblTotalBill
            // 
            this.lblTotalBill.AutoSize = true;
            this.lblTotalBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBill.ForeColor = System.Drawing.Color.Red;
            this.lblTotalBill.Location = new System.Drawing.Point(1000, 380);
            this.lblTotalBill.Name = "lblTotalBill";
            this.lblTotalBill.Size = new System.Drawing.Size(149, 36);
            this.lblTotalBill.TabIndex = 4;
            this.lblTotalBill.Text = "Total Bill:";
            // 
            // lblAmountPaid
            // 
            this.lblAmountPaid.AutoSize = true;
            this.lblAmountPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountPaid.ForeColor = System.Drawing.Color.Green;
            this.lblAmountPaid.Location = new System.Drawing.Point(1000, 440);
            this.lblAmountPaid.Name = "lblAmountPaid";
            this.lblAmountPaid.Size = new System.Drawing.Size(176, 31);
            this.lblAmountPaid.TabIndex = 5;
            this.lblAmountPaid.Text = "Amount Paid:";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.Purple;
            this.lblBalance.Location = new System.Drawing.Point(1000, 500);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(158, 39);
            this.lblBalance.TabIndex = 6;
            this.lblBalance.Text = "Balance:";
            // 
            // dgvBillingItems
            // 
            this.dgvBillingItems.AllowUserToAddRows = false;
            this.dgvBillingItems.AllowUserToDeleteRows = false;
            this.dgvBillingItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBillingItems.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBillingItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillingItems.Location = new System.Drawing.Point(40, 480);
            this.dgvBillingItems.Name = "dgvBillingItems";
            this.dgvBillingItems.ReadOnly = true;
            this.dgvBillingItems.RowHeadersWidth = 51;
            this.dgvBillingItems.RowTemplate.Height = 30;
            this.dgvBillingItems.Size = new System.Drawing.Size(900, 400);
            this.dgvBillingItems.TabIndex = 7;
            // 
            // txtPaymentAmount
            // 
            this.txtPaymentAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentAmount.Location = new System.Drawing.Point(1480, 260);
            this.txtPaymentAmount.Name = "txtPaymentAmount";
            this.txtPaymentAmount.Size = new System.Drawing.Size(400, 38);
            this.txtPaymentAmount.TabIndex = 8;
            this.txtPaymentAmount.Text = "0.00";
            // 
            // btnProcessCheckOut
            // 
            this.btnProcessCheckOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnProcessCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessCheckOut.ForeColor = System.Drawing.Color.White;
            this.btnProcessCheckOut.Location = new System.Drawing.Point(1480, 380);
            this.btnProcessCheckOut.Name = "btnProcessCheckOut";
            this.btnProcessCheckOut.Size = new System.Drawing.Size(400, 60);
            this.btnProcessCheckOut.TabIndex = 9;
            this.btnProcessCheckOut.Text = "PROCESS CHECK-OUT";
            this.btnProcessCheckOut.UseVisualStyleBackColor = false;
            this.btnProcessCheckOut.Click += new System.EventHandler(this.btnProcessCheckOut_Click);
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPrintInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintInvoice.ForeColor = System.Drawing.Color.White;
            this.btnPrintInvoice.Location = new System.Drawing.Point(1480, 460);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(400, 60);
            this.btnPrintInvoice.TabIndex = 10;
            this.btnPrintInvoice.Text = "PRINT INVOICE";
            this.btnPrintInvoice.UseVisualStyleBackColor = false;
            this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoice_Click);
            // 
            // btnAddCharge
            // 
            this.btnAddCharge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAddCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCharge.ForeColor = System.Drawing.Color.White;
            this.btnAddCharge.Location = new System.Drawing.Point(1480, 540);
            this.btnAddCharge.Name = "btnAddCharge";
            this.btnAddCharge.Size = new System.Drawing.Size(400, 60);
            this.btnAddCharge.TabIndex = 11;
            this.btnAddCharge.Text = "ADD CHARGE";
            this.btnAddCharge.UseVisualStyleBackColor = false;
            this.btnAddCharge.Click += new System.EventHandler(this.btnAddCharge_Click);
            // 
            // dtpActualCheckOut
            // 
            this.dtpActualCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpActualCheckOut.Location = new System.Drawing.Point(1480, 320);
            this.dtpActualCheckOut.Name = "dtpActualCheckOut";
            this.dtpActualCheckOut.Size = new System.Drawing.Size(400, 38);
            this.dtpActualCheckOut.TabIndex = 12;
            this.dtpActualCheckOut.ValueChanged += new System.EventHandler(this.dtpActualCheckOut_ValueChanged);
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Location = new System.Drawing.Point(1480, 620);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(400, 39);
            this.cmbPaymentMethod.TabIndex = 13;
            this.cmbPaymentMethod.Text = "Payment Method";
            // 
            // nudLateCheckoutHours
            // 
            this.nudLateCheckoutHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLateCheckoutHours.Location = new System.Drawing.Point(1480, 680);
            this.nudLateCheckoutHours.Name = "nudLateCheckoutHours";
            this.nudLateCheckoutHours.Size = new System.Drawing.Size(400, 38);
            this.nudLateCheckoutHours.TabIndex = 14;
            this.nudLateCheckoutHours.ValueChanged += new System.EventHandler(this.nudLateCheckoutHours_ValueChanged);
            // 
            // lblLateFee
            // 
            this.lblLateFee.AutoSize = true;
            this.lblLateFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLateFee.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblLateFee.Location = new System.Drawing.Point(1000, 580);
            this.lblLateFee.Name = "lblLateFee";
            this.lblLateFee.Size = new System.Drawing.Size(129, 31);
            this.lblLateFee.TabIndex = 15;
            this.lblLateFee.Text = "Late Fee:";
            // 
            // lblDeparturesCount
            // 
            this.lblDeparturesCount.AutoSize = true;
            this.lblDeparturesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeparturesCount.Location = new System.Drawing.Point(40, 450);
            this.lblDeparturesCount.Name = "lblDeparturesCount";
            this.lblDeparturesCount.Size = new System.Drawing.Size(144, 25);
            this.lblDeparturesCount.TabIndex = 16;
            this.lblDeparturesCount.Text = "0 departure(s)";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(850, 450);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmCheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 960);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblDeparturesCount);
            this.Controls.Add(this.lblLateFee);
            this.Controls.Add(this.nudLateCheckoutHours);
            this.Controls.Add(this.cmbPaymentMethod);
            this.Controls.Add(this.dtpActualCheckOut);
            this.Controls.Add(this.btnAddCharge);
            this.Controls.Add(this.btnPrintInvoice);
            this.Controls.Add(this.btnProcessCheckOut);
            this.Controls.Add(this.txtPaymentAmount);
            this.Controls.Add(this.dgvBillingItems);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblAmountPaid);
            this.Controls.Add(this.lblTotalBill);
            this.Controls.Add(this.lblRoomNumber);
            this.Controls.Add(this.lblGuestName);
            this.Controls.Add(this.pnlGuestDetails);
            this.Controls.Add(this.dgvTodayDepartures);
            this.Name = "frmCheckOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Management System - Check-Out";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCheckOut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayDepartures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillingItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLateCheckoutHours)).EndInit();
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
    }
}