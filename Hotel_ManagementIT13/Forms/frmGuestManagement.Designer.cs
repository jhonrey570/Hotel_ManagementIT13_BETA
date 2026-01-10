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
            this.colGuestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGuestType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.lblGuestCount = new System.Windows.Forms.Label();
            this.pnlGuestList = new System.Windows.Forms.Panel();
            this.lblGuestDetails = new System.Windows.Forms.Label();
            this.lblGuestList = new System.Windows.Forms.Label();
            this.lblFirstNm = new System.Windows.Forms.Label();
            this.lblLastNm = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lblNationality = new System.Windows.Forms.Label();
            this.lblIDType = new System.Windows.Forms.Label();
            this.lblIDNum = new System.Windows.Forms.Label();
            this.lblGuestType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuests)).BeginInit();
            this.pnlGuestForm.SuspendLayout();
            this.pnlGuestList.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvGuests
            // 
            this.dgvGuests.AllowUserToAddRows = false;
            this.dgvGuests.AllowUserToDeleteRows = false;
            this.dgvGuests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGuests.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvGuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGuests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGuestId,
            this.colFullName,
            this.colPhone,
            this.colEmail,
            this.colNationality,
            this.colGuestType,
            this.colCreatedAt});
            this.dgvGuests.Location = new System.Drawing.Point(3, 131);
            this.dgvGuests.Name = "dgvGuests";
            this.dgvGuests.ReadOnly = true;
            this.dgvGuests.RowHeadersWidth = 51;
            this.dgvGuests.RowTemplate.Height = 30;
            this.dgvGuests.Size = new System.Drawing.Size(1123, 802);
            this.dgvGuests.TabIndex = 0;
            this.dgvGuests.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGuests_CellClick);
            // 
            // colGuestId
            // 
            this.colGuestId.DataPropertyName = "GuestId";
            this.colGuestId.HeaderText = "ID";
            this.colGuestId.MinimumWidth = 6;
            this.colGuestId.Name = "colGuestId";
            this.colGuestId.ReadOnly = true;
            // 
            // colFullName
            // 
            this.colFullName.DataPropertyName = "FullName";
            this.colFullName.HeaderText = "Full Name";
            this.colFullName.MinimumWidth = 6;
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            // 
            // colPhone
            // 
            this.colPhone.DataPropertyName = "Phone";
            this.colPhone.HeaderText = "Phone";
            this.colPhone.MinimumWidth = 6;
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.HeaderText = "Email";
            this.colEmail.MinimumWidth = 6;
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // colNationality
            // 
            this.colNationality.DataPropertyName = "Nationality";
            this.colNationality.HeaderText = "Nationality";
            this.colNationality.MinimumWidth = 6;
            this.colNationality.Name = "colNationality";
            this.colNationality.ReadOnly = true;
            // 
            // colGuestType
            // 
            this.colGuestType.DataPropertyName = "GuestTypeName";
            this.colGuestType.HeaderText = "Guest Type";
            this.colGuestType.MinimumWidth = 6;
            this.colGuestType.Name = "colGuestType";
            this.colGuestType.ReadOnly = true;
            // 
            // colCreatedAt
            // 
            this.colCreatedAt.DataPropertyName = "CreatedAt";
            this.colCreatedAt.HeaderText = "Created Date";
            this.colCreatedAt.MinimumWidth = 6;
            this.colCreatedAt.Name = "colCreatedAt";
            this.colCreatedAt.ReadOnly = true;
            // 
            // btnAddGuest
            // 
            this.btnAddGuest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddGuest.BackColor = System.Drawing.Color.Green;
            this.btnAddGuest.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddGuest.ForeColor = System.Drawing.Color.White;
            this.btnAddGuest.Location = new System.Drawing.Point(352, 441);
            this.btnAddGuest.Name = "btnAddGuest";
            this.btnAddGuest.Size = new System.Drawing.Size(200, 50);
            this.btnAddGuest.TabIndex = 1;
            this.btnAddGuest.Text = "ADD GUEST";
            this.btnAddGuest.UseVisualStyleBackColor = false;
            this.btnAddGuest.Click += new System.EventHandler(this.btnAddGuest_Click);
            // 
            // btnEditGuest
            // 
            this.btnEditGuest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditGuest.BackColor = System.Drawing.Color.Blue;
            this.btnEditGuest.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditGuest.ForeColor = System.Drawing.Color.White;
            this.btnEditGuest.Location = new System.Drawing.Point(352, 497);
            this.btnEditGuest.Name = "btnEditGuest";
            this.btnEditGuest.Size = new System.Drawing.Size(200, 50);
            this.btnEditGuest.TabIndex = 2;
            this.btnEditGuest.Text = "EDIT GUEST";
            this.btnEditGuest.UseVisualStyleBackColor = false;
            this.btnEditGuest.Click += new System.EventHandler(this.btnEditGuest_Click);
            // 
            // btnDeleteGuest
            // 
            this.btnDeleteGuest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteGuest.BackColor = System.Drawing.Color.Red;
            this.btnDeleteGuest.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteGuest.ForeColor = System.Drawing.Color.White;
            this.btnDeleteGuest.Location = new System.Drawing.Point(558, 497);
            this.btnDeleteGuest.Name = "btnDeleteGuest";
            this.btnDeleteGuest.Size = new System.Drawing.Size(200, 50);
            this.btnDeleteGuest.TabIndex = 3;
            this.btnDeleteGuest.Text = "DELETE GUEST";
            this.btnDeleteGuest.UseVisualStyleBackColor = false;
            this.btnDeleteGuest.Click += new System.EventHandler(this.btnDeleteGuest_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = global::Hotel_ManagementIT13.Properties.Resources.people;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(1096, 64);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(30, 30);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(3, 61);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(1123, 36);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Search guests by name, email, or phone...";
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // pnlGuestForm
            // 
            this.pnlGuestForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGuestForm.BackColor = System.Drawing.Color.White;
            this.pnlGuestForm.Controls.Add(this.lblGuestType);
            this.pnlGuestForm.Controls.Add(this.lblIDNum);
            this.pnlGuestForm.Controls.Add(this.lblIDType);
            this.pnlGuestForm.Controls.Add(this.lblNationality);
            this.pnlGuestForm.Controls.Add(this.lblDOB);
            this.pnlGuestForm.Controls.Add(this.txtIDNumber);
            this.pnlGuestForm.Controls.Add(this.lblAddress);
            this.pnlGuestForm.Controls.Add(this.dtpDOB);
            this.pnlGuestForm.Controls.Add(this.lblEmail);
            this.pnlGuestForm.Controls.Add(this.lblPhone);
            this.pnlGuestForm.Controls.Add(this.lblLastNm);
            this.pnlGuestForm.Controls.Add(this.txtPhone);
            this.pnlGuestForm.Controls.Add(this.btnCancel);
            this.pnlGuestForm.Controls.Add(this.lblFirstNm);
            this.pnlGuestForm.Controls.Add(this.txtAddress);
            this.pnlGuestForm.Controls.Add(this.txtLastName);
            this.pnlGuestForm.Controls.Add(this.btnSaveGuest);
            this.pnlGuestForm.Controls.Add(this.lblGuestDetails);
            this.pnlGuestForm.Controls.Add(this.cmbGuestType);
            this.pnlGuestForm.Controls.Add(this.txtFirstName);
            this.pnlGuestForm.Controls.Add(this.btnDeleteGuest);
            this.pnlGuestForm.Controls.Add(this.cmbIDType);
            this.pnlGuestForm.Controls.Add(this.btnAddGuest);
            this.pnlGuestForm.Controls.Add(this.btnEditGuest);
            this.pnlGuestForm.Controls.Add(this.cmbNationality);
            this.pnlGuestForm.Controls.Add(this.txtEmail);
            this.pnlGuestForm.Location = new System.Drawing.Point(1147, 12);
            this.pnlGuestForm.Name = "pnlGuestForm";
            this.pnlGuestForm.Size = new System.Drawing.Size(761, 685);
            this.pnlGuestForm.TabIndex = 6;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.White;
            this.txtFirstName.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtFirstName.Location = new System.Drawing.Point(3, 91);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(300, 36);
            this.txtFirstName.TabIndex = 7;
            this.txtFirstName.Text = "First Name";
            this.txtFirstName.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtFirstName.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.White;
            this.txtLastName.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtLastName.Location = new System.Drawing.Point(3, 161);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(300, 36);
            this.txtLastName.TabIndex = 8;
            this.txtLastName.Text = "Last Name";
            this.txtLastName.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtLastName.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtEmail.Location = new System.Drawing.Point(3, 301);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 36);
            this.txtEmail.TabIndex = 9;
            this.txtEmail.Text = "Email Address";
            this.txtEmail.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.White;
            this.txtPhone.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPhone.Location = new System.Drawing.Point(3, 231);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(300, 36);
            this.txtPhone.TabIndex = 10;
            this.txtPhone.Text = "Phone Number";
            this.txtPhone.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtPhone.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(3, 441);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(343, 241);
            this.txtAddress.TabIndex = 11;
            this.txtAddress.Text = "Address";
            this.txtAddress.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtAddress.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // cmbNationality
            // 
            this.cmbNationality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbNationality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNationality.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNationality.FormattingEnabled = true;
            this.cmbNationality.Location = new System.Drawing.Point(311, 161);
            this.cmbNationality.Name = "cmbNationality";
            this.cmbNationality.Size = new System.Drawing.Size(300, 36);
            this.cmbNationality.TabIndex = 12;
            // 
            // dtpDOB
            // 
            this.dtpDOB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDOB.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDOB.Location = new System.Drawing.Point(311, 91);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(400, 36);
            this.dtpDOB.TabIndex = 13;
            // 
            // cmbIDType
            // 
            this.cmbIDType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbIDType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIDType.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIDType.FormattingEnabled = true;
            this.cmbIDType.Location = new System.Drawing.Point(309, 231);
            this.cmbIDType.Name = "cmbIDType";
            this.cmbIDType.Size = new System.Drawing.Size(300, 36);
            this.cmbIDType.TabIndex = 14;
            // 
            // txtIDNumber
            // 
            this.txtIDNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIDNumber.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDNumber.Location = new System.Drawing.Point(309, 301);
            this.txtIDNumber.Name = "txtIDNumber";
            this.txtIDNumber.Size = new System.Drawing.Size(300, 36);
            this.txtIDNumber.TabIndex = 15;
            this.txtIDNumber.Text = "ID Number";
            this.txtIDNumber.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtIDNumber.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // cmbGuestType
            // 
            this.cmbGuestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGuestType.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGuestType.FormattingEnabled = true;
            this.cmbGuestType.Location = new System.Drawing.Point(3, 371);
            this.cmbGuestType.Name = "cmbGuestType";
            this.cmbGuestType.Size = new System.Drawing.Size(300, 36);
            this.cmbGuestType.TabIndex = 16;
            // 
            // btnSaveGuest
            // 
            this.btnSaveGuest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveGuest.BackColor = System.Drawing.Color.Orange;
            this.btnSaveGuest.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveGuest.ForeColor = System.Drawing.Color.White;
            this.btnSaveGuest.Location = new System.Drawing.Point(558, 441);
            this.btnSaveGuest.Name = "btnSaveGuest";
            this.btnSaveGuest.Size = new System.Drawing.Size(200, 50);
            this.btnSaveGuest.TabIndex = 17;
            this.btnSaveGuest.Text = "SAVE GUEST";
            this.btnSaveGuest.UseVisualStyleBackColor = false;
            this.btnSaveGuest.Click += new System.EventHandler(this.btnSaveGuest_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(558, 553);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(200, 50);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblGuestCount
            // 
            this.lblGuestCount.AutoSize = true;
            this.lblGuestCount.BackColor = System.Drawing.Color.White;
            this.lblGuestCount.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestCount.Location = new System.Drawing.Point(3, 100);
            this.lblGuestCount.Name = "lblGuestCount";
            this.lblGuestCount.Size = new System.Drawing.Size(163, 28);
            this.lblGuestCount.TabIndex = 19;
            this.lblGuestCount.Text = "0 guest(s) found";
            // 
            // pnlGuestList
            // 
            this.pnlGuestList.BackColor = System.Drawing.Color.White;
            this.pnlGuestList.Controls.Add(this.lblGuestCount);
            this.pnlGuestList.Controls.Add(this.btnSearch);
            this.pnlGuestList.Controls.Add(this.lblGuestList);
            this.pnlGuestList.Controls.Add(this.txtSearch);
            this.pnlGuestList.Controls.Add(this.dgvGuests);
            this.pnlGuestList.Location = new System.Drawing.Point(12, 12);
            this.pnlGuestList.Name = "pnlGuestList";
            this.pnlGuestList.Size = new System.Drawing.Size(1129, 936);
            this.pnlGuestList.TabIndex = 20;
            // 
            // lblGuestDetails
            // 
            this.lblGuestDetails.AutoSize = true;
            this.lblGuestDetails.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestDetails.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblGuestDetails.Location = new System.Drawing.Point(2, 2);
            this.lblGuestDetails.Name = "lblGuestDetails";
            this.lblGuestDetails.Size = new System.Drawing.Size(176, 27);
            this.lblGuestDetails.TabIndex = 32;
            this.lblGuestDetails.Text = "Guest Details ";
            // 
            // lblGuestList
            // 
            this.lblGuestList.AutoSize = true;
            this.lblGuestList.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestList.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblGuestList.Location = new System.Drawing.Point(3, 3);
            this.lblGuestList.Name = "lblGuestList";
            this.lblGuestList.Size = new System.Drawing.Size(150, 27);
            this.lblGuestList.TabIndex = 33;
            this.lblGuestList.Text = "Guest Lists ";
            // 
            // lblFirstNm
            // 
            this.lblFirstNm.AutoSize = true;
            this.lblFirstNm.BackColor = System.Drawing.Color.White;
            this.lblFirstNm.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstNm.Location = new System.Drawing.Point(3, 60);
            this.lblFirstNm.Name = "lblFirstNm";
            this.lblFirstNm.Size = new System.Drawing.Size(119, 28);
            this.lblFirstNm.TabIndex = 33;
            this.lblFirstNm.Text = "First Name:";
            // 
            // lblLastNm
            // 
            this.lblLastNm.AutoSize = true;
            this.lblLastNm.BackColor = System.Drawing.Color.White;
            this.lblLastNm.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastNm.Location = new System.Drawing.Point(3, 130);
            this.lblLastNm.Name = "lblLastNm";
            this.lblLastNm.Size = new System.Drawing.Size(116, 28);
            this.lblLastNm.TabIndex = 34;
            this.lblLastNm.Text = "Last Name:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.BackColor = System.Drawing.Color.White;
            this.lblPhone.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(3, 200);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(158, 28);
            this.lblPhone.TabIndex = 35;
            this.lblPhone.Text = "Phone Number:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.White;
            this.lblEmail.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(3, 270);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(147, 28);
            this.lblEmail.TabIndex = 36;
            this.lblEmail.Text = "Email Address:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.BackColor = System.Drawing.Color.White;
            this.lblAddress.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(3, 410);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(92, 28);
            this.lblAddress.TabIndex = 37;
            this.lblAddress.Text = "Address:";
            // 
            // lblDOB
            // 
            this.lblDOB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDOB.AutoSize = true;
            this.lblDOB.BackColor = System.Drawing.Color.White;
            this.lblDOB.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOB.Location = new System.Drawing.Point(314, 60);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(137, 28);
            this.lblDOB.TabIndex = 38;
            this.lblDOB.Text = "Date of Birth:";
            // 
            // lblNationality
            // 
            this.lblNationality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNationality.AutoSize = true;
            this.lblNationality.BackColor = System.Drawing.Color.White;
            this.lblNationality.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNationality.Location = new System.Drawing.Point(314, 130);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(120, 28);
            this.lblNationality.TabIndex = 39;
            this.lblNationality.Text = "Nationality:";
            // 
            // lblIDType
            // 
            this.lblIDType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIDType.AutoSize = true;
            this.lblIDType.BackColor = System.Drawing.Color.White;
            this.lblIDType.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDType.Location = new System.Drawing.Point(314, 200);
            this.lblIDType.Name = "lblIDType";
            this.lblIDType.Size = new System.Drawing.Size(86, 28);
            this.lblIDType.TabIndex = 40;
            this.lblIDType.Text = "ID Type:";
            // 
            // lblIDNum
            // 
            this.lblIDNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIDNum.AutoSize = true;
            this.lblIDNum.BackColor = System.Drawing.Color.White;
            this.lblIDNum.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDNum.Location = new System.Drawing.Point(314, 270);
            this.lblIDNum.Name = "lblIDNum";
            this.lblIDNum.Size = new System.Drawing.Size(119, 28);
            this.lblIDNum.TabIndex = 41;
            this.lblIDNum.Text = "ID Number:";
            // 
            // lblGuestType
            // 
            this.lblGuestType.AutoSize = true;
            this.lblGuestType.BackColor = System.Drawing.Color.White;
            this.lblGuestType.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestType.Location = new System.Drawing.Point(3, 340);
            this.lblGuestType.Name = "lblGuestType";
            this.lblGuestType.Size = new System.Drawing.Size(121, 28);
            this.lblGuestType.TabIndex = 42;
            this.lblGuestType.Text = "Guest Type:";
            // 
            // frmGuestManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1920, 960);
            this.Controls.Add(this.pnlGuestForm);
            this.Controls.Add(this.pnlGuestList);
            this.Name = "frmGuestManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Management System - Guest Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGuestManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuests)).EndInit();
            this.pnlGuestForm.ResumeLayout(false);
            this.pnlGuestForm.PerformLayout();
            this.pnlGuestList.ResumeLayout(false);
            this.pnlGuestList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGuests;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGuestId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGuestType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedAt;
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
        private System.Windows.Forms.Label lblGuestCount;
        private System.Windows.Forms.Panel pnlGuestList;
        private System.Windows.Forms.Label lblGuestDetails;
        private System.Windows.Forms.Label lblGuestList;
        private System.Windows.Forms.Label lblFirstNm;
        private System.Windows.Forms.Label lblLastNm;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblIDNum;
        private System.Windows.Forms.Label lblIDType;
        private System.Windows.Forms.Label lblNationality;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblGuestType;
    }
}