namespace Hotel_ManagementIT13.Forms
{
    partial class frmGuestManagement
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
            this.dgvGuests = new System.Windows.Forms.DataGridView();
            this.btnAddGuest = new System.Windows.Forms.Button();
            this.btnEditGuest = new System.Windows.Forms.Button();
            this.btnDeleteGuest = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlGuestForm = new System.Windows.Forms.Panel();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.cmbNationality = new System.Windows.Forms.ComboBox();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.cmbIDType = new System.Windows.Forms.ComboBox();
            this.txtIDNumber = new System.Windows.Forms.TextBox();
            this.cmbGuestType = new System.Windows.Forms.ComboBox();
            this.btnSaveGuest = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuests)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGuests
            // 
            this.dgvGuests.AllowUserToAddRows = false;
            this.dgvGuests.AllowUserToDeleteRows = false;
            this.dgvGuests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGuests.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvGuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGuests.Location = new System.Drawing.Point(40, 160);
            this.dgvGuests.Name = "dgvGuests";
            this.dgvGuests.ReadOnly = true;
            this.dgvGuests.RowHeadersWidth = 51;
            this.dgvGuests.RowTemplate.Height = 30;
            this.dgvGuests.Size = new System.Drawing.Size(900, 700);
            this.dgvGuests.TabIndex = 0;
            // 
            // btnAddGuest
            // 
            this.btnAddGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddGuest.Location = new System.Drawing.Point(40, 90);
            this.btnAddGuest.Name = "btnAddGuest";
            this.btnAddGuest.Size = new System.Drawing.Size(200, 50);
            this.btnAddGuest.TabIndex = 1;
            this.btnAddGuest.Text = "ADD GUEST";
            this.btnAddGuest.UseVisualStyleBackColor = true;
            // 
            // btnEditGuest
            // 
            this.btnEditGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditGuest.Location = new System.Drawing.Point(260, 90);
            this.btnEditGuest.Name = "btnEditGuest";
            this.btnEditGuest.Size = new System.Drawing.Size(200, 50);
            this.btnEditGuest.TabIndex = 2;
            this.btnEditGuest.Text = "EDIT GUEST";
            this.btnEditGuest.UseVisualStyleBackColor = true;
            // 
            // btnDeleteGuest
            // 
            this.btnDeleteGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteGuest.Location = new System.Drawing.Point(480, 90);
            this.btnDeleteGuest.Name = "btnDeleteGuest";
            this.btnDeleteGuest.Size = new System.Drawing.Size(200, 50);
            this.btnDeleteGuest.TabIndex = 3;
            this.btnDeleteGuest.Text = "DELETE GUEST";
            this.btnDeleteGuest.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(700, 90);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(200, 50);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(40, 40);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(860, 34);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.Text = "Search guests by name, email, or phone...";
            // 
            // pnlGuestForm
            // 
            this.pnlGuestForm.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlGuestForm.Location = new System.Drawing.Point(1000, 40);
            this.pnlGuestForm.Name = "pnlGuestForm";
            this.pnlGuestForm.Size = new System.Drawing.Size(880, 300);
            this.pnlGuestForm.TabIndex = 6;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(1000, 360);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(400, 34);
            this.txtFirstName.TabIndex = 7;
            this.txtFirstName.Text = "First Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(1480, 360);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(400, 34);
            this.txtLastName.TabIndex = 8;
            this.txtLastName.Text = "Last Name";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(1000, 420);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(400, 34);
            this.txtEmail.TabIndex = 9;
            this.txtEmail.Text = "Email Address";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(1480, 420);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(400, 34);
            this.txtPhone.TabIndex = 10;
            this.txtPhone.Text = "Phone Number";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(1000, 480);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(880, 100);
            this.txtAddress.TabIndex = 11;
            this.txtAddress.Text = "Address";
            // 
            // cmbNationality
            // 
            this.cmbNationality.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNationality.FormattingEnabled = true;
            this.cmbNationality.Location = new System.Drawing.Point(1000, 600);
            this.cmbNationality.Name = "cmbNationality";
            this.cmbNationality.Size = new System.Drawing.Size(400, 37);
            this.cmbNationality.TabIndex = 12;
            this.cmbNationality.Text = "Nationality";
            // 
            // dtpDOB
            // 
            this.dtpDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDOB.Location = new System.Drawing.Point(1480, 600);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(400, 38);
            this.dtpDOB.TabIndex = 13;
            // 
            // cmbIDType
            // 
            this.cmbIDType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIDType.FormattingEnabled = true;
            this.cmbIDType.Location = new System.Drawing.Point(1000, 660);
            this.cmbIDType.Name = "cmbIDType";
            this.cmbIDType.Size = new System.Drawing.Size(400, 37);
            this.cmbIDType.TabIndex = 14;
            this.cmbIDType.Text = "ID Type";
            // 
            // txtIDNumber
            // 
            this.txtIDNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDNumber.Location = new System.Drawing.Point(1480, 660);
            this.txtIDNumber.Name = "txtIDNumber";
            this.txtIDNumber.Size = new System.Drawing.Size(400, 34);
            this.txtIDNumber.TabIndex = 15;
            this.txtIDNumber.Text = "ID Number";
            // 
            // cmbGuestType
            // 
            this.cmbGuestType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGuestType.FormattingEnabled = true;
            this.cmbGuestType.Location = new System.Drawing.Point(1000, 720);
            this.cmbGuestType.Name = "cmbGuestType";
            this.cmbGuestType.Size = new System.Drawing.Size(400, 37);
            this.cmbGuestType.TabIndex = 16;
            this.cmbGuestType.Text = "Guest Type";
            // 
            // btnSaveGuest
            // 
            this.btnSaveGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveGuest.Location = new System.Drawing.Point(1000, 800);
            this.btnSaveGuest.Name = "btnSaveGuest";
            this.btnSaveGuest.Size = new System.Drawing.Size(400, 60);
            this.btnSaveGuest.TabIndex = 17;
            this.btnSaveGuest.Text = "SAVE GUEST";
            this.btnSaveGuest.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(1480, 800);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(400, 60);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmGuestManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 960);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveGuest);
            this.Controls.Add(this.cmbGuestType);
            this.Controls.Add(this.txtIDNumber);
            this.Controls.Add(this.cmbIDType);
            this.Controls.Add(this.dtpDOB);
            this.Controls.Add(this.cmbNationality);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.pnlGuestForm);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDeleteGuest);
            this.Controls.Add(this.btnEditGuest);
            this.Controls.Add(this.btnAddGuest);
            this.Controls.Add(this.dgvGuests);
            this.Name = "frmGuestManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Management System - Guest Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGuests;
        private System.Windows.Forms.Button btnAddGuest;
        private System.Windows.Forms.Button btnEditGuest;
        private System.Windows.Forms.Button btnDeleteGuest;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlGuestForm;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.ComboBox cmbNationality;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.ComboBox cmbIDType;
        private System.Windows.Forms.TextBox txtIDNumber;
        private System.Windows.Forms.ComboBox cmbGuestType;
        private System.Windows.Forms.Button btnSaveGuest;
        private System.Windows.Forms.Button btnCancel;
    }
}