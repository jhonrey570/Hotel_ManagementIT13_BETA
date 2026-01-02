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
            this.lblGuestName = new System.Windows.Forms.Label();
            this.lblBookingRef = new System.Windows.Forms.Label();
            this.lblRoomNumber = new System.Windows.Forms.Label();
            this.lblAmountDue = new System.Windows.Forms.Label();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.btnProcessCheckIn = new System.Windows.Forms.Button();
            this.btnWalkInCheckIn = new System.Windows.Forms.Button();
            this.btnPrintKeyCard = new System.Windows.Forms.Button();
            this.dtpActualCheckIn = new System.Windows.Forms.DateTimePicker();
            this.nudDeposit = new System.Windows.Forms.NumericUpDown();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.rtbCheckInNotes = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayArrivals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWalkInAvailable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeposit)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTodayArrivals
            // 
            this.dgvTodayArrivals.AllowUserToAddRows = false;
            this.dgvTodayArrivals.AllowUserToDeleteRows = false;
            this.dgvTodayArrivals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTodayArrivals.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTodayArrivals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTodayArrivals.Location = new System.Drawing.Point(40, 40);
            this.dgvTodayArrivals.Name = "dgvTodayArrivals";
            this.dgvTodayArrivals.ReadOnly = true;
            this.dgvTodayArrivals.RowHeadersWidth = 51;
            this.dgvTodayArrivals.RowTemplate.Height = 30;
            this.dgvTodayArrivals.Size = new System.Drawing.Size(900, 400);
            this.dgvTodayArrivals.TabIndex = 0;
            // 
            // dgvWalkInAvailable
            // 
            this.dgvWalkInAvailable.AllowUserToAddRows = false;
            this.dgvWalkInAvailable.AllowUserToDeleteRows = false;
            this.dgvWalkInAvailable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWalkInAvailable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvWalkInAvailable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWalkInAvailable.Location = new System.Drawing.Point(40, 480);
            this.dgvWalkInAvailable.Name = "dgvWalkInAvailable";
            this.dgvWalkInAvailable.ReadOnly = true;
            this.dgvWalkInAvailable.RowHeadersWidth = 51;
            this.dgvWalkInAvailable.RowTemplate.Height = 30;
            this.dgvWalkInAvailable.Size = new System.Drawing.Size(900, 400);
            this.dgvWalkInAvailable.TabIndex = 1;
            // 
            // pnlReservationDetails
            // 
            this.pnlReservationDetails.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlReservationDetails.Location = new System.Drawing.Point(1000, 40);
            this.pnlReservationDetails.Name = "pnlReservationDetails";
            this.pnlReservationDetails.Size = new System.Drawing.Size(880, 200);
            this.pnlReservationDetails.TabIndex = 2;
            // 
            // lblGuestName
            // 
            this.lblGuestName.AutoSize = true;
            this.lblGuestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestName.ForeColor = System.Drawing.Color.Blue;
            this.lblGuestName.Location = new System.Drawing.Point(1000, 260);
            this.lblGuestName.Name = "lblGuestName";
            this.lblGuestName.Size = new System.Drawing.Size(196, 36);
            this.lblGuestName.TabIndex = 3;
            this.lblGuestName.Text = "Guest Name:";
            // 
            // lblBookingRef
            // 
            this.lblBookingRef.AutoSize = true;
            this.lblBookingRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingRef.Location = new System.Drawing.Point(1000, 320);
            this.lblBookingRef.Name = "lblBookingRef";
            this.lblBookingRef.Size = new System.Drawing.Size(187, 31);
            this.lblBookingRef.TabIndex = 4;
            this.lblBookingRef.Text = "Booking Ref: #";
            // 
            // lblRoomNumber
            // 
            this.lblRoomNumber.AutoSize = true;
            this.lblRoomNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomNumber.Location = new System.Drawing.Point(1000, 380);
            this.lblRoomNumber.Name = "lblRoomNumber";
            this.lblRoomNumber.Size = new System.Drawing.Size(208, 31);
            this.lblRoomNumber.TabIndex = 5;
            this.lblRoomNumber.Text = "Room Number: #";
            // 
            // lblAmountDue
            // 
            this.lblAmountDue.AutoSize = true;
            this.lblAmountDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountDue.ForeColor = System.Drawing.Color.Green;
            this.lblAmountDue.Location = new System.Drawing.Point(1000, 440);
            this.lblAmountDue.Name = "lblAmountDue";
            this.lblAmountDue.Size = new System.Drawing.Size(223, 39);
            this.lblAmountDue.TabIndex = 6;
            this.lblAmountDue.Text = "Amount Due:";
            // 
            // txtPayment
            // 
            this.txtPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayment.Location = new System.Drawing.Point(1000, 500);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(400, 38);
            this.txtPayment.TabIndex = 7;
            this.txtPayment.Text = "Payment Amount";
            // 
            // btnProcessCheckIn
            // 
            this.btnProcessCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessCheckIn.Location = new System.Drawing.Point(1000, 680);
            this.btnProcessCheckIn.Name = "btnProcessCheckIn";
            this.btnProcessCheckIn.Size = new System.Drawing.Size(400, 60);
            this.btnProcessCheckIn.TabIndex = 8;
            this.btnProcessCheckIn.Text = "PROCESS CHECK-IN";
            this.btnProcessCheckIn.UseVisualStyleBackColor = true;
            // 
            // btnWalkInCheckIn
            // 
            this.btnWalkInCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWalkInCheckIn.Location = new System.Drawing.Point(1480, 680);
            this.btnWalkInCheckIn.Name = "btnWalkInCheckIn";
            this.btnWalkInCheckIn.Size = new System.Drawing.Size(400, 60);
            this.btnWalkInCheckIn.TabIndex = 9;
            this.btnWalkInCheckIn.Text = "WALK-IN CHECK-IN";
            this.btnWalkInCheckIn.UseVisualStyleBackColor = true;
            // 
            // btnPrintKeyCard
            // 
            this.btnPrintKeyCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintKeyCard.Location = new System.Drawing.Point(1000, 760);
            this.btnPrintKeyCard.Name = "btnPrintKeyCard";
            this.btnPrintKeyCard.Size = new System.Drawing.Size(400, 60);
            this.btnPrintKeyCard.TabIndex = 10;
            this.btnPrintKeyCard.Text = "PRINT KEY CARD";
            this.btnPrintKeyCard.UseVisualStyleBackColor = true;
            // 
            // dtpActualCheckIn
            // 
            this.dtpActualCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpActualCheckIn.Location = new System.Drawing.Point(1000, 560);
            this.dtpActualCheckIn.Name = "dtpActualCheckIn";
            this.dtpActualCheckIn.Size = new System.Drawing.Size(400, 38);
            this.dtpActualCheckIn.TabIndex = 11;
            // 
            // nudDeposit
            // 
            this.nudDeposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDeposit.Location = new System.Drawing.Point(1480, 500);
            this.nudDeposit.Name = "nudDeposit";
            this.nudDeposit.Size = new System.Drawing.Size(400, 38);
            this.nudDeposit.TabIndex = 12;
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Location = new System.Drawing.Point(1480, 560);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(400, 39);
            this.cmbPaymentMethod.TabIndex = 13;
            this.cmbPaymentMethod.Text = "Payment Method";
            // 
            // rtbCheckInNotes
            // 
            this.rtbCheckInNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbCheckInNotes.Location = new System.Drawing.Point(1480, 260);
            this.rtbCheckInNotes.Name = "rtbCheckInNotes";
            this.rtbCheckInNotes.Size = new System.Drawing.Size(400, 200);
            this.rtbCheckInNotes.TabIndex = 14;
            this.rtbCheckInNotes.Text = "Check-in Notes...";
            // 
            // frmCheckIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 960);
            this.Controls.Add(this.rtbCheckInNotes);
            this.Controls.Add(this.cmbPaymentMethod);
            this.Controls.Add(this.nudDeposit);
            this.Controls.Add(this.dtpActualCheckIn);
            this.Controls.Add(this.btnPrintKeyCard);
            this.Controls.Add(this.btnWalkInCheckIn);
            this.Controls.Add(this.btnProcessCheckIn);
            this.Controls.Add(this.txtPayment);
            this.Controls.Add(this.lblAmountDue);
            this.Controls.Add(this.lblRoomNumber);
            this.Controls.Add(this.lblBookingRef);
            this.Controls.Add(this.lblGuestName);
            this.Controls.Add(this.pnlReservationDetails);
            this.Controls.Add(this.dgvWalkInAvailable);
            this.Controls.Add(this.dgvTodayArrivals);
            this.Name = "frmCheckIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Management System - Check-In";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayArrivals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWalkInAvailable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeposit)).EndInit();
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
    }
}