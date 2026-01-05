namespace Hotel_ManagementIT13.Forms
{
    partial class frmSearch
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.flpQuickActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuickSearch = new System.Windows.Forms.Button();
            this.btnQuickRateManagement = new System.Windows.Forms.Button();
            this.btnQuickUserManagement = new System.Windows.Forms.Button();
            this.btnQuickReports = new System.Windows.Forms.Button();
            this.btnRoomCreation = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlHeader.SuspendLayout();
            this.flpQuickActions.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Controls.Add(this.btnLogout);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1280, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(40, 22);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(230, 31);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Hotel Search Hub";
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1060, 15);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 50);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "LOGOUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // flpQuickActions
            // 
            this.flpQuickActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpQuickActions.BackColor = System.Drawing.Color.White;
            this.flpQuickActions.Controls.Add(this.btnQuickSearch);
            this.flpQuickActions.Controls.Add(this.btnQuickRateManagement);
            this.flpQuickActions.Controls.Add(this.btnQuickUserManagement);
            this.flpQuickActions.Controls.Add(this.btnQuickReports);
            this.flpQuickActions.Controls.Add(this.btnRoomCreation);
            this.flpQuickActions.Location = new System.Drawing.Point(40, 120);
            this.flpQuickActions.Name = "flpQuickActions";
            this.flpQuickActions.Size = new System.Drawing.Size(1200, 150);
            this.flpQuickActions.TabIndex = 1;
            // 
            // btnQuickSearch
            // 
            this.btnQuickSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnQuickSearch.FlatAppearance.BorderSize = 0;
            this.btnQuickSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuickSearch.ForeColor = System.Drawing.Color.White;
            this.btnQuickSearch.Location = new System.Drawing.Point(3, 3);
            this.btnQuickSearch.Name = "btnQuickSearch";
            this.btnQuickSearch.Size = new System.Drawing.Size(230, 140);
            this.btnQuickSearch.TabIndex = 0;
            this.btnQuickSearch.Text = "SEARCH";
            this.btnQuickSearch.UseVisualStyleBackColor = false;
            this.btnQuickSearch.Click += new System.EventHandler(this.btnQuickSearch_Click);
            // 
            // btnQuickRateManagement
            // 
            this.btnQuickRateManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnQuickRateManagement.FlatAppearance.BorderSize = 0;
            this.btnQuickRateManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickRateManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuickRateManagement.ForeColor = System.Drawing.Color.White;
            this.btnQuickRateManagement.Location = new System.Drawing.Point(239, 3);
            this.btnQuickRateManagement.Name = "btnQuickRateManagement";
            this.btnQuickRateManagement.Size = new System.Drawing.Size(230, 140);
            this.btnQuickRateManagement.TabIndex = 1;
            this.btnQuickRateManagement.Text = "RATE MANAGEMENT";
            this.btnQuickRateManagement.UseVisualStyleBackColor = false;
            this.btnQuickRateManagement.Click += new System.EventHandler(this.btnQuickRateManagement_Click);
            // 
            // btnQuickUserManagement
            // 
            this.btnQuickUserManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnQuickUserManagement.FlatAppearance.BorderSize = 0;
            this.btnQuickUserManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickUserManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuickUserManagement.ForeColor = System.Drawing.Color.White;
            this.btnQuickUserManagement.Location = new System.Drawing.Point(475, 3);
            this.btnQuickUserManagement.Name = "btnQuickUserManagement";
            this.btnQuickUserManagement.Size = new System.Drawing.Size(230, 140);
            this.btnQuickUserManagement.TabIndex = 2;
            this.btnQuickUserManagement.Text = "USER MANAGEMENT";
            this.btnQuickUserManagement.UseVisualStyleBackColor = false;
            this.btnQuickUserManagement.Click += new System.EventHandler(this.btnQuickUserManagement_Click);
            // 
            // btnQuickReports
            // 
            this.btnQuickReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnQuickReports.FlatAppearance.BorderSize = 0;
            this.btnQuickReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuickReports.ForeColor = System.Drawing.Color.White;
            this.btnQuickReports.Location = new System.Drawing.Point(711, 3);
            this.btnQuickReports.Name = "btnQuickReports";
            this.btnQuickReports.Size = new System.Drawing.Size(230, 140);
            this.btnQuickReports.TabIndex = 3;
            this.btnQuickReports.Text = "REPORTS";
            this.btnQuickReports.UseVisualStyleBackColor = false;
            this.btnQuickReports.Click += new System.EventHandler(this.btnQuickReports_Click);
            // 
            // btnRoomCreation
            // 
            this.btnRoomCreation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnRoomCreation.FlatAppearance.BorderSize = 0;
            this.btnRoomCreation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoomCreation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoomCreation.ForeColor = System.Drawing.Color.White;
            this.btnRoomCreation.Location = new System.Drawing.Point(947, 3);
            this.btnRoomCreation.Name = "btnRoomCreation";
            this.btnRoomCreation.Size = new System.Drawing.Size(230, 140);
            this.btnRoomCreation.TabIndex = 4;
            this.btnRoomCreation.Text = "ROOM MANAGEMENT";
            this.btnRoomCreation.UseVisualStyleBackColor = false;
            this.btnRoomCreation.Click += new System.EventHandler(this.btnRoomCreation_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 716);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1280, 26);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(120, 20);
            this.toolStripStatusLabel.Text = "Ready - Main Menu";
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1280, 742);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.flpQuickActions);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "frmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Management System - Search Hub";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSearch_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.flpQuickActions.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.FlowLayoutPanel flpQuickActions;
        private System.Windows.Forms.Button btnQuickSearch;
        private System.Windows.Forms.Button btnQuickRateManagement;
        private System.Windows.Forms.Button btnQuickUserManagement;
        private System.Windows.Forms.Button btnQuickReports;
        private System.Windows.Forms.Button btnRoomCreation;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}