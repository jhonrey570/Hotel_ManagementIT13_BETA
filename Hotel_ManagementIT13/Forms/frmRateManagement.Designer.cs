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
            this.cmbRoomType = new System.Windows.Forms.ComboBox();
            this.cmbRatePlan = new System.Windows.Forms.ComboBox();
            this.txtRateAmount = new System.Windows.Forms.TextBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddRate = new System.Windows.Forms.Button();
            this.btnEditRate = new System.Windows.Forms.Button();
            this.btnDeleteRate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvRatePlans = new System.Windows.Forms.DataGridView();
            this.txtPlanName = new System.Windows.Forms.TextBox();
            this.rtbPlanDescription = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRatePlans)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRates
            // 
            this.dgvRates.AllowUserToAddRows = false;
            this.dgvRates.AllowUserToDeleteRows = false;
            this.dgvRates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRates.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRates.Location = new System.Drawing.Point(40, 40);
            this.dgvRates.Name = "dgvRates";
            this.dgvRates.ReadOnly = true;
            this.dgvRates.RowHeadersWidth = 51;
            this.dgvRates.RowTemplate.Height = 30;
            this.dgvRates.Size = new System.Drawing.Size(900, 400);
            this.dgvRates.TabIndex = 0;
            // 
            // pnlRateForm
            // 
            this.pnlRateForm.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlRateForm.Location = new System.Drawing.Point(1000, 40);
            this.pnlRateForm.Name = "pnlRateForm";
            this.pnlRateForm.Size = new System.Drawing.Size(880, 200);
            this.pnlRateForm.TabIndex = 1;
            // 
            // cmbRoomType
            // 
            this.cmbRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoomType.FormattingEnabled = true;
            this.cmbRoomType.Location = new System.Drawing.Point(1000, 260);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(400, 37);
            this.cmbRoomType.TabIndex = 2;
            this.cmbRoomType.Text = "Room Type";
            // 
            // cmbRatePlan
            // 
            this.cmbRatePlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRatePlan.FormattingEnabled = true;
            this.cmbRatePlan.Location = new System.Drawing.Point(1480, 260);
            this.cmbRatePlan.Name = "cmbRatePlan";
            this.cmbRatePlan.Size = new System.Drawing.Size(400, 37);
            this.cmbRatePlan.TabIndex = 3;
            this.cmbRatePlan.Text = "Rate Plan";
            // 
            // txtRateAmount
            // 
            this.txtRateAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRateAmount.Location = new System.Drawing.Point(1000, 320);
            this.txtRateAmount.Name = "txtRateAmount";
            this.txtRateAmount.Size = new System.Drawing.Size(400, 34);
            this.txtRateAmount.TabIndex = 4;
            this.txtRateAmount.Text = "Rate Amount";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Location = new System.Drawing.Point(1480, 320);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(400, 38);
            this.dtpStartDate.TabIndex = 5;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Location = new System.Drawing.Point(1000, 380);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(400, 38);
            this.dtpEndDate.TabIndex = 6;
            // 
            // btnAddRate
            // 
            this.btnAddRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRate.Location = new System.Drawing.Point(40, 460);
            this.btnAddRate.Name = "btnAddRate";
            this.btnAddRate.Size = new System.Drawing.Size(200, 50);
            this.btnAddRate.TabIndex = 7;
            this.btnAddRate.Text = "ADD RATE";
            this.btnAddRate.UseVisualStyleBackColor = true;
            // 
            // btnEditRate
            // 
            this.btnEditRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditRate.Location = new System.Drawing.Point(260, 460);
            this.btnEditRate.Name = "btnEditRate";
            this.btnEditRate.Size = new System.Drawing.Size(200, 50);
            this.btnEditRate.TabIndex = 8;
            this.btnEditRate.Text = "EDIT RATE";
            this.btnEditRate.UseVisualStyleBackColor = true;
            // 
            // btnDeleteRate
            // 
            this.btnDeleteRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteRate.Location = new System.Drawing.Point(480, 460);
            this.btnDeleteRate.Name = "btnDeleteRate";
            this.btnDeleteRate.Size = new System.Drawing.Size(200, 50);
            this.btnDeleteRate.TabIndex = 9;
            this.btnDeleteRate.Text = "DELETE RATE";
            this.btnDeleteRate.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(1480, 380);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(400, 60);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "SAVE RATE";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(1480, 460);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(400, 60);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dgvRatePlans
            // 
            this.dgvRatePlans.AllowUserToAddRows = false;
            this.dgvRatePlans.AllowUserToDeleteRows = false;
            this.dgvRatePlans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRatePlans.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRatePlans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRatePlans.Location = new System.Drawing.Point(40, 540);
            this.dgvRatePlans.Name = "dgvRatePlans";
            this.dgvRatePlans.ReadOnly = true;
            this.dgvRatePlans.RowHeadersWidth = 51;
            this.dgvRatePlans.RowTemplate.Height = 30;
            this.dgvRatePlans.Size = new System.Drawing.Size(900, 380);
            this.dgvRatePlans.TabIndex = 12;
            // 
            // txtPlanName
            // 
            this.txtPlanName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlanName.Location = new System.Drawing.Point(1000, 540);
            this.txtPlanName.Name = "txtPlanName";
            this.txtPlanName.Size = new System.Drawing.Size(880, 34);
            this.txtPlanName.TabIndex = 13;
            this.txtPlanName.Text = "Rate Plan Name";
            // 
            // rtbPlanDescription
            // 
            this.rtbPlanDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbPlanDescription.Location = new System.Drawing.Point(1000, 600);
            this.rtbPlanDescription.Name = "rtbPlanDescription";
            this.rtbPlanDescription.Size = new System.Drawing.Size(880, 320);
            this.rtbPlanDescription.TabIndex = 14;
            this.rtbPlanDescription.Text = "Rate Plan Description...";
            // 
            // frmRateManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 960);
            this.Controls.Add(this.rtbPlanDescription);
            this.Controls.Add(this.txtPlanName);
            this.Controls.Add(this.dgvRatePlans);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDeleteRate);
            this.Controls.Add(this.btnEditRate);
            this.Controls.Add(this.btnAddRate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.txtRateAmount);
            this.Controls.Add(this.cmbRatePlan);
            this.Controls.Add(this.cmbRoomType);
            this.Controls.Add(this.pnlRateForm);
            this.Controls.Add(this.dgvRates);
            this.Name = "frmRateManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Management System - Rate Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvRates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRatePlans)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}