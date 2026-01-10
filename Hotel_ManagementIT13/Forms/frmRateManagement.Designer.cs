namespace Hotel_ManagementIT13.Forms
{
    partial class frmRateManagement
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
            this.dgvRates = new System.Windows.Forms.DataGridView();
            this.pnlRateForm = new System.Windows.Forms.Panel();
            this.lblDescriptions = new System.Windows.Forms.Label();
            this.btnEditRate = new System.Windows.Forms.Button();
            this.rtbPlanDescription = new System.Windows.Forms.RichTextBox();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblAmount = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblRoomTyp = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPln = new System.Windows.Forms.Label();
            this.btnDeleteRate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRateNm = new System.Windows.Forms.Label();
            this.btnAddRate = new System.Windows.Forms.Button();
            this.cmbRatePlan = new System.Windows.Forms.ComboBox();
            this.txtPlanName = new System.Windows.Forms.TextBox();
            this.cmbRoomType = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtRateAmount = new System.Windows.Forms.TextBox();
            this.dgvRatePlans = new System.Windows.Forms.DataGridView();
            this.pnlRts = new System.Windows.Forms.Panel();
            this.lblPlans = new System.Windows.Forms.Label();
            this.lblRates = new System.Windows.Forms.Label();
            this.lblGuestDetails = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRates)).BeginInit();
            this.pnlRateForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRatePlans)).BeginInit();
            this.pnlRts.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRates
            // 
            this.dgvRates.AllowUserToAddRows = false;
            this.dgvRates.AllowUserToDeleteRows = false;
            this.dgvRates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRates.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRates.Location = new System.Drawing.Point(3, 89);
            this.dgvRates.Name = "dgvRates";
            this.dgvRates.ReadOnly = true;
            this.dgvRates.RowHeadersWidth = 51;
            this.dgvRates.RowTemplate.Height = 30;
            this.dgvRates.Size = new System.Drawing.Size(1123, 400);
            this.dgvRates.TabIndex = 0;
            this.dgvRates.SelectionChanged += new System.EventHandler(this.dgvRates_SelectionChanged);
            // 
            // pnlRateForm
            // 
            this.pnlRateForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRateForm.BackColor = System.Drawing.Color.White;
            this.pnlRateForm.Controls.Add(this.lblDescriptions);
            this.pnlRateForm.Controls.Add(this.btnEditRate);
            this.pnlRateForm.Controls.Add(this.rtbPlanDescription);
            this.pnlRateForm.Controls.Add(this.lblEndDate);
            this.pnlRateForm.Controls.Add(this.lblStartDate);
            this.pnlRateForm.Controls.Add(this.dtpEndDate);
            this.pnlRateForm.Controls.Add(this.lblAmount);
            this.pnlRateForm.Controls.Add(this.btnCancel);
            this.pnlRateForm.Controls.Add(this.lblRoomTyp);
            this.pnlRateForm.Controls.Add(this.btnSave);
            this.pnlRateForm.Controls.Add(this.lblPln);
            this.pnlRateForm.Controls.Add(this.btnDeleteRate);
            this.pnlRateForm.Controls.Add(this.label1);
            this.pnlRateForm.Controls.Add(this.lblRateNm);
            this.pnlRateForm.Controls.Add(this.btnAddRate);
            this.pnlRateForm.Controls.Add(this.cmbRatePlan);
            this.pnlRateForm.Controls.Add(this.txtPlanName);
            this.pnlRateForm.Controls.Add(this.cmbRoomType);
            this.pnlRateForm.Controls.Add(this.dtpStartDate);
            this.pnlRateForm.Controls.Add(this.txtRateAmount);
            this.pnlRateForm.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlRateForm.Location = new System.Drawing.Point(1147, 12);
            this.pnlRateForm.Name = "pnlRateForm";
            this.pnlRateForm.Size = new System.Drawing.Size(761, 936);
            this.pnlRateForm.TabIndex = 1;
            // 
            // lblDescriptions
            // 
            this.lblDescriptions.AutoSize = true;
            this.lblDescriptions.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptions.Location = new System.Drawing.Point(3, 478);
            this.lblDescriptions.Name = "lblDescriptions";
            this.lblDescriptions.Size = new System.Drawing.Size(225, 28);
            this.lblDescriptions.TabIndex = 47;
            this.lblDescriptions.Text = "Rate Plan Descriptions:";
            // 
            // btnEditRate
            // 
            this.btnEditRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditRate.BackColor = System.Drawing.Color.Blue;
            this.btnEditRate.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditRate.ForeColor = System.Drawing.Color.White;
            this.btnEditRate.Location = new System.Drawing.Point(352, 565);
            this.btnEditRate.Name = "btnEditRate";
            this.btnEditRate.Size = new System.Drawing.Size(200, 50);
            this.btnEditRate.TabIndex = 8;
            this.btnEditRate.Text = "EDIT RATE";
            this.btnEditRate.UseVisualStyleBackColor = false;
            this.btnEditRate.Click += new System.EventHandler(this.btnEditRate_Click);
            // 
            // rtbPlanDescription
            // 
            this.rtbPlanDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbPlanDescription.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbPlanDescription.Location = new System.Drawing.Point(3, 509);
            this.rtbPlanDescription.Name = "rtbPlanDescription";
            this.rtbPlanDescription.Size = new System.Drawing.Size(343, 424);
            this.rtbPlanDescription.TabIndex = 14;
            this.rtbPlanDescription.Text = "Rate Plan Description...";
            this.rtbPlanDescription.Enter += new System.EventHandler(this.rtbPlanDescription_Enter);
            this.rtbPlanDescription.Leave += new System.EventHandler(this.rtbPlanDescription_Leave);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.Location = new System.Drawing.Point(3, 408);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(102, 28);
            this.lblEndDate.TabIndex = 46;
            this.lblEndDate.Text = "End Date:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.Location = new System.Drawing.Point(3, 338);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(113, 28);
            this.lblStartDate.TabIndex = 45;
            this.lblStartDate.Text = "Start Date:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Location = new System.Drawing.Point(3, 439);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(400, 36);
            this.dtpEndDate.TabIndex = 6;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(3, 268);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(158, 28);
            this.lblAmount.TabIndex = 44;
            this.lblAmount.Text = "Rate Ammount:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(558, 621);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(200, 50);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblRoomTyp
            // 
            this.lblRoomTyp.AutoSize = true;
            this.lblRoomTyp.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomTyp.Location = new System.Drawing.Point(3, 198);
            this.lblRoomTyp.Name = "lblRoomTyp";
            this.lblRoomTyp.Size = new System.Drawing.Size(120, 28);
            this.lblRoomTyp.TabIndex = 43;
            this.lblRoomTyp.Text = "Room Type:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Orange;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(558, 509);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 50);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "SAVE RATE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPln
            // 
            this.lblPln.AutoSize = true;
            this.lblPln.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPln.Location = new System.Drawing.Point(3, 128);
            this.lblPln.Name = "lblPln";
            this.lblPln.Size = new System.Drawing.Size(153, 28);
            this.lblPln.TabIndex = 42;
            this.lblPln.Text = "Rate Plan Type:";
            // 
            // btnDeleteRate
            // 
            this.btnDeleteRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteRate.BackColor = System.Drawing.Color.Red;
            this.btnDeleteRate.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteRate.ForeColor = System.Drawing.Color.White;
            this.btnDeleteRate.Location = new System.Drawing.Point(558, 565);
            this.btnDeleteRate.Name = "btnDeleteRate";
            this.btnDeleteRate.Size = new System.Drawing.Size(200, 50);
            this.btnDeleteRate.TabIndex = 9;
            this.btnDeleteRate.Text = "DELETE RATE";
            this.btnDeleteRate.UseVisualStyleBackColor = false;
            this.btnDeleteRate.Click += new System.EventHandler(this.btnDeleteRate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 27);
            this.label1.TabIndex = 41;
            this.label1.Text = "Rate Forms";
            // 
            // lblRateNm
            // 
            this.lblRateNm.AutoSize = true;
            this.lblRateNm.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRateNm.Location = new System.Drawing.Point(3, 58);
            this.lblRateNm.Name = "lblRateNm";
            this.lblRateNm.Size = new System.Drawing.Size(118, 28);
            this.lblRateNm.TabIndex = 14;
            this.lblRateNm.Text = "Plan Name:";
            // 
            // btnAddRate
            // 
            this.btnAddRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRate.BackColor = System.Drawing.Color.Green;
            this.btnAddRate.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRate.ForeColor = System.Drawing.Color.White;
            this.btnAddRate.Location = new System.Drawing.Point(352, 509);
            this.btnAddRate.Name = "btnAddRate";
            this.btnAddRate.Size = new System.Drawing.Size(200, 50);
            this.btnAddRate.TabIndex = 7;
            this.btnAddRate.Text = "ADD RATE";
            this.btnAddRate.UseVisualStyleBackColor = false;
            this.btnAddRate.Click += new System.EventHandler(this.btnAddRate_Click);
            // 
            // cmbRatePlan
            // 
            this.cmbRatePlan.BackColor = System.Drawing.Color.White;
            this.cmbRatePlan.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRatePlan.FormattingEnabled = true;
            this.cmbRatePlan.Location = new System.Drawing.Point(3, 159);
            this.cmbRatePlan.Name = "cmbRatePlan";
            this.cmbRatePlan.Size = new System.Drawing.Size(300, 36);
            this.cmbRatePlan.TabIndex = 3;
            this.cmbRatePlan.Text = "Rate Plan";
            this.cmbRatePlan.Enter += new System.EventHandler(this.cmbRatePlan_Enter);
            this.cmbRatePlan.Leave += new System.EventHandler(this.cmbRatePlan_Leave);
            // 
            // txtPlanName
            // 
            this.txtPlanName.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlanName.Location = new System.Drawing.Point(3, 89);
            this.txtPlanName.Name = "txtPlanName";
            this.txtPlanName.Size = new System.Drawing.Size(300, 36);
            this.txtPlanName.TabIndex = 13;
            this.txtPlanName.Text = "Rate Plan Name";
            this.txtPlanName.Enter += new System.EventHandler(this.txtPlanName_Enter);
            this.txtPlanName.Leave += new System.EventHandler(this.txtPlanName_Leave);
            // 
            // cmbRoomType
            // 
            this.cmbRoomType.BackColor = System.Drawing.Color.White;
            this.cmbRoomType.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoomType.FormattingEnabled = true;
            this.cmbRoomType.Location = new System.Drawing.Point(3, 229);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(300, 36);
            this.cmbRoomType.TabIndex = 2;
            this.cmbRoomType.Text = "Room Type";
            this.cmbRoomType.Enter += new System.EventHandler(this.cmbRoomType_Enter);
            this.cmbRoomType.Leave += new System.EventHandler(this.cmbRoomType_Leave);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Location = new System.Drawing.Point(3, 369);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(400, 36);
            this.dtpStartDate.TabIndex = 5;
            // 
            // txtRateAmount
            // 
            this.txtRateAmount.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRateAmount.Location = new System.Drawing.Point(3, 299);
            this.txtRateAmount.Name = "txtRateAmount";
            this.txtRateAmount.Size = new System.Drawing.Size(300, 36);
            this.txtRateAmount.TabIndex = 4;
            this.txtRateAmount.Text = "Rate Amount";
            this.txtRateAmount.Enter += new System.EventHandler(this.txtRateAmount_Enter);
            this.txtRateAmount.Leave += new System.EventHandler(this.txtRateAmount_Leave);
            // 
            // dgvRatePlans
            // 
            this.dgvRatePlans.AllowUserToAddRows = false;
            this.dgvRatePlans.AllowUserToDeleteRows = false;
            this.dgvRatePlans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRatePlans.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvRatePlans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRatePlans.Location = new System.Drawing.Point(0, 523);
            this.dgvRatePlans.Name = "dgvRatePlans";
            this.dgvRatePlans.ReadOnly = true;
            this.dgvRatePlans.RowHeadersWidth = 51;
            this.dgvRatePlans.RowTemplate.Height = 30;
            this.dgvRatePlans.Size = new System.Drawing.Size(1126, 410);
            this.dgvRatePlans.TabIndex = 12;
            // 
            // pnlRts
            // 
            this.pnlRts.BackColor = System.Drawing.Color.White;
            this.pnlRts.Controls.Add(this.lblPlans);
            this.pnlRts.Controls.Add(this.lblRates);
            this.pnlRts.Controls.Add(this.dgvRatePlans);
            this.pnlRts.Controls.Add(this.lblGuestDetails);
            this.pnlRts.Controls.Add(this.dgvRates);
            this.pnlRts.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlRts.Location = new System.Drawing.Point(12, 12);
            this.pnlRts.Name = "pnlRts";
            this.pnlRts.Size = new System.Drawing.Size(1129, 936);
            this.pnlRts.TabIndex = 15;
            // 
            // lblPlans
            // 
            this.lblPlans.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlans.AutoSize = true;
            this.lblPlans.BackColor = System.Drawing.Color.White;
            this.lblPlans.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlans.Location = new System.Drawing.Point(3, 492);
            this.lblPlans.Name = "lblPlans";
            this.lblPlans.Size = new System.Drawing.Size(108, 28);
            this.lblPlans.TabIndex = 40;
            this.lblPlans.Text = "Rate Plans";
            // 
            // lblRates
            // 
            this.lblRates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRates.AutoSize = true;
            this.lblRates.BackColor = System.Drawing.Color.White;
            this.lblRates.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRates.Location = new System.Drawing.Point(3, 58);
            this.lblRates.Name = "lblRates";
            this.lblRates.Size = new System.Drawing.Size(149, 28);
            this.lblRates.TabIndex = 39;
            this.lblRates.Text = "Rates Changed";
            // 
            // lblGuestDetails
            // 
            this.lblGuestDetails.AutoSize = true;
            this.lblGuestDetails.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestDetails.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblGuestDetails.Location = new System.Drawing.Point(3, 3);
            this.lblGuestDetails.Name = "lblGuestDetails";
            this.lblGuestDetails.Size = new System.Drawing.Size(78, 27);
            this.lblGuestDetails.TabIndex = 33;
            this.lblGuestDetails.Text = "Rates";
            // 
            // frmRateManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1920, 960);
            this.Controls.Add(this.pnlRateForm);
            this.Controls.Add(this.pnlRts);
            this.Name = "frmRateManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Management System - Rate Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRateManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRates)).EndInit();
            this.pnlRateForm.ResumeLayout(false);
            this.pnlRateForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRatePlans)).EndInit();
            this.pnlRts.ResumeLayout(false);
            this.pnlRts.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRates;
        private System.Windows.Forms.Panel pnlRateForm;
        private System.Windows.Forms.ComboBox cmbRoomType;
        private System.Windows.Forms.ComboBox cmbRatePlan;
        private System.Windows.Forms.TextBox txtRateAmount;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnAddRate;
        private System.Windows.Forms.Button btnEditRate;
        private System.Windows.Forms.Button btnDeleteRate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvRatePlans;
        private System.Windows.Forms.TextBox txtPlanName;
        private System.Windows.Forms.RichTextBox rtbPlanDescription;
        private System.Windows.Forms.Panel pnlRts;
        private System.Windows.Forms.Label lblGuestDetails;
        private System.Windows.Forms.Label lblRates;
        private System.Windows.Forms.Label lblPlans;
        private System.Windows.Forms.Label lblRateNm;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblRoomTyp;
        private System.Windows.Forms.Label lblPln;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDescriptions;
        private System.Windows.Forms.Label lblEndDate;
    }
}