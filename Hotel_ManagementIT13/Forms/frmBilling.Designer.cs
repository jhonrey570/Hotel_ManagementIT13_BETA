namespace Hotel_ManagementIT13.Forms
{
    partial class frmBilling
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
            this.dgvBills = new System.Windows.Forms.DataGridView();
            this.dgvBillItems = new System.Windows.Forms.DataGridView();
            this.pnlPayment = new System.Windows.Forms.Panel();
            this.txtAmountToPay = new System.Windows.Forms.TextBox();
            this.btnProcessPayment = new System.Windows.Forms.Button();
            this.btnPrintReceipt = new System.Windows.Forms.Button();
            this.btnEmailInvoice = new System.Windows.Forms.Button();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.rtbPaymentNotes = new System.Windows.Forms.RichTextBox();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.txtSearchBill = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBills
            // 
            this.dgvBills.AllowUserToAddRows = false;
            this.dgvBills.AllowUserToDeleteRows = false;
            this.dgvBills.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBills.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBills.Location = new System.Drawing.Point(40, 86);
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.ReadOnly = true;
            this.dgvBills.RowHeadersWidth = 51;
            this.dgvBills.RowTemplate.Height = 30;
            this.dgvBills.Size = new System.Drawing.Size(900, 257);
            this.dgvBills.TabIndex = 0;
            // 
            // dgvBillItems
            // 
            this.dgvBillItems.AllowUserToAddRows = false;
            this.dgvBillItems.AllowUserToDeleteRows = false;
            this.dgvBillItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBillItems.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBillItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillItems.Location = new System.Drawing.Point(40, 403);
            this.dgvBillItems.Name = "dgvBillItems";
            this.dgvBillItems.ReadOnly = true;
            this.dgvBillItems.RowHeadersWidth = 51;
            this.dgvBillItems.RowTemplate.Height = 30;
            this.dgvBillItems.Size = new System.Drawing.Size(900, 257);
            this.dgvBillItems.TabIndex = 1;
            // 
            // pnlPayment
            // 
            this.pnlPayment.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlPayment.Location = new System.Drawing.Point(1007, 86);
            this.pnlPayment.Name = "pnlPayment";
            this.pnlPayment.Size = new System.Drawing.Size(880, 200);
            this.pnlPayment.TabIndex = 2;
            // 
            // txtAmountToPay
            // 
            this.txtAmountToPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountToPay.Location = new System.Drawing.Point(1000, 380);
            this.txtAmountToPay.Name = "txtAmountToPay";
            this.txtAmountToPay.Size = new System.Drawing.Size(400, 38);
            this.txtAmountToPay.TabIndex = 3;
            this.txtAmountToPay.Text = "Amount to Pay";
            // 
            // btnProcessPayment
            // 
            this.btnProcessPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessPayment.Location = new System.Drawing.Point(1000, 600);
            this.btnProcessPayment.Name = "btnProcessPayment";
            this.btnProcessPayment.Size = new System.Drawing.Size(400, 60);
            this.btnProcessPayment.TabIndex = 4;
            this.btnProcessPayment.Text = "PROCESS PAYMENT";
            this.btnProcessPayment.UseVisualStyleBackColor = true;
            // 
            // btnPrintReceipt
            // 
            this.btnPrintReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintReceipt.Location = new System.Drawing.Point(1480, 600);
            this.btnPrintReceipt.Name = "btnPrintReceipt";
            this.btnPrintReceipt.Size = new System.Drawing.Size(400, 60);
            this.btnPrintReceipt.TabIndex = 5;
            this.btnPrintReceipt.Text = "PRINT RECEIPT";
            this.btnPrintReceipt.UseVisualStyleBackColor = true;
            // 
            // btnEmailInvoice
            // 
            this.btnEmailInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmailInvoice.Location = new System.Drawing.Point(1000, 680);
            this.btnEmailInvoice.Name = "btnEmailInvoice";
            this.btnEmailInvoice.Size = new System.Drawing.Size(400, 60);
            this.btnEmailInvoice.TabIndex = 6;
            this.btnEmailInvoice.Text = "EMAIL INVOICE";
            this.btnEmailInvoice.UseVisualStyleBackColor = true;
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Location = new System.Drawing.Point(1480, 380);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(400, 39);
            this.cmbPaymentMethod.TabIndex = 7;
            this.cmbPaymentMethod.Text = "Payment Method";
            // 
            // rtbPaymentNotes
            // 
            this.rtbPaymentNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbPaymentNotes.Location = new System.Drawing.Point(1000, 440);
            this.rtbPaymentNotes.Name = "rtbPaymentNotes";
            this.rtbPaymentNotes.Size = new System.Drawing.Size(880, 120);
            this.rtbPaymentNotes.TabIndex = 8;
            this.rtbPaymentNotes.Text = "Payment Notes...";
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPaymentDate.Location = new System.Drawing.Point(1480, 680);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(400, 38);
            this.dtpPaymentDate.TabIndex = 9;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Red;
            this.lblTotalAmount.Location = new System.Drawing.Point(1000, 40);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(241, 39);
            this.lblTotalAmount.TabIndex = 10;
            this.lblTotalAmount.Text = "Total Amount:";
            // 
            // txtSearchBill
            // 
            this.txtSearchBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBill.Location = new System.Drawing.Point(40, 40);
            this.txtSearchBill.Name = "txtSearchBill";
            this.txtSearchBill.Size = new System.Drawing.Size(700, 34);
            this.txtSearchBill.TabIndex = 13;
            this.txtSearchBill.Text = "Search bills by guest name, room number, or bill ID...";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(760, 40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(180, 34);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // frmBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 960);
            this.Controls.Add(this.dgvBillItems);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchBill);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.dtpPaymentDate);
            this.Controls.Add(this.rtbPaymentNotes);
            this.Controls.Add(this.cmbPaymentMethod);
            this.Controls.Add(this.btnEmailInvoice);
            this.Controls.Add(this.btnPrintReceipt);
            this.Controls.Add(this.btnProcessPayment);
            this.Controls.Add(this.txtAmountToPay);
            this.Controls.Add(this.pnlPayment);
            this.Controls.Add(this.dgvBills);
            this.Name = "frmBilling";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Management System - Billing & Payments";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBilling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBills;
        private System.Windows.Forms.DataGridView dgvBillItems;
        private System.Windows.Forms.Panel pnlPayment;
        private System.Windows.Forms.TextBox txtAmountToPay;
        private System.Windows.Forms.Button btnProcessPayment;
        private System.Windows.Forms.Button btnPrintReceipt;
        private System.Windows.Forms.Button btnEmailInvoice;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.RichTextBox rtbPaymentNotes;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtSearchBill;
        private System.Windows.Forms.Button btnSearch;
    }
}