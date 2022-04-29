namespace RestAPIKliens
{
    partial class Form1
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.IceYtm = new System.Windows.Forms.Label();
            this.panelDesktopPane = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.bntMinimize = new System.Windows.Forms.Button();
            this.btnCloseChildForm = new System.Windows.Forms.Button();
            this.btnStat = new System.Windows.Forms.Button();
            this.btnScrap = new System.Windows.Forms.Button();
            this.btnFP = new System.Windows.Forms.Button();
            this.btnBasin = new System.Windows.Forms.Button();
            this.btnDry = new System.Windows.Forms.Button();
            this.btnRS = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btnStat);
            this.panelMenu.Controls.Add(this.btnScrap);
            this.panelMenu.Controls.Add(this.btnFP);
            this.panelMenu.Controls.Add(this.btnBasin);
            this.panelMenu.Controls.Add(this.btnDry);
            this.panelMenu.Controls.Add(this.btnRS);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(230, 538);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLogo.Controls.Add(this.IceYtm);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(230, 80);
            this.panelLogo.TabIndex = 0;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panelTitleBar.Controls.Add(this.btnClose);
            this.panelTitleBar.Controls.Add(this.btnMaximize);
            this.panelTitleBar.Controls.Add(this.bntMinimize);
            this.panelTitleBar.Controls.Add(this.btnCloseChildForm);
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(230, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(788, 80);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown_1);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(351, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(90, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Raktár";
            this.lblTitle.Click += new System.EventHandler(this.Home_Click);
            // 
            // IceYtm
            // 
            this.IceYtm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IceYtm.AutoSize = true;
            this.IceYtm.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IceYtm.ForeColor = System.Drawing.Color.LightGray;
            this.IceYtm.Location = new System.Drawing.Point(63, 28);
            this.IceYtm.Name = "IceYtm";
            this.IceYtm.Size = new System.Drawing.Size(76, 23);
            this.IceYtm.TabIndex = 1;
            this.IceYtm.Text = "IceYtm";
            // 
            // panelDesktopPane
            // 
            this.panelDesktopPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPane.Location = new System.Drawing.Point(230, 80);
            this.panelDesktopPane.Name = "panelDesktopPane";
            this.panelDesktopPane.Size = new System.Drawing.Size(788, 458);
            this.panelDesktopPane.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::RestAPIKliens.Properties.Resources.icons8_multiply_25;
            this.btnClose.Location = new System.Drawing.Point(755, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 26);
            this.btnClose.TabIndex = 4;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Image = global::RestAPIKliens.Properties.Resources.icons8_unchecked_checkbox_25;
            this.btnMaximize.Location = new System.Drawing.Point(719, 3);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(30, 26);
            this.btnMaximize.TabIndex = 3;
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // bntMinimize
            // 
            this.bntMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntMinimize.FlatAppearance.BorderSize = 0;
            this.bntMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntMinimize.Image = global::RestAPIKliens.Properties.Resources.icons8_subtract_25;
            this.bntMinimize.Location = new System.Drawing.Point(683, 3);
            this.bntMinimize.Name = "bntMinimize";
            this.bntMinimize.Size = new System.Drawing.Size(30, 26);
            this.bntMinimize.TabIndex = 2;
            this.bntMinimize.UseVisualStyleBackColor = true;
            this.bntMinimize.Click += new System.EventHandler(this.bntMinimize_Click);
            // 
            // btnCloseChildForm
            // 
            this.btnCloseChildForm.FlatAppearance.BorderSize = 0;
            this.btnCloseChildForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseChildForm.Image = global::RestAPIKliens.Properties.Resources.icons8_close_64;
            this.btnCloseChildForm.Location = new System.Drawing.Point(0, 3);
            this.btnCloseChildForm.Name = "btnCloseChildForm";
            this.btnCloseChildForm.Size = new System.Drawing.Size(87, 77);
            this.btnCloseChildForm.TabIndex = 1;
            this.btnCloseChildForm.UseVisualStyleBackColor = true;
            this.btnCloseChildForm.Click += new System.EventHandler(this.btnCloseChildForm_Click_1);
            // 
            // btnStat
            // 
            this.btnStat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStat.FlatAppearance.BorderSize = 0;
            this.btnStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStat.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStat.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnStat.Image = global::RestAPIKliens.Properties.Resources.icons8_statistics_64;
            this.btnStat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStat.Location = new System.Drawing.Point(0, 455);
            this.btnStat.Name = "btnStat";
            this.btnStat.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnStat.Size = new System.Drawing.Size(230, 75);
            this.btnStat.TabIndex = 6;
            this.btnStat.Text = "Statisztika";
            this.btnStat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStat.UseVisualStyleBackColor = true;
            this.btnStat.Click += new System.EventHandler(this.btnStat_Click);
            // 
            // btnScrap
            // 
            this.btnScrap.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnScrap.FlatAppearance.BorderSize = 0;
            this.btnScrap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScrap.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrap.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnScrap.Image = global::RestAPIKliens.Properties.Resources.icons8_trash_64;
            this.btnScrap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScrap.Location = new System.Drawing.Point(0, 380);
            this.btnScrap.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.btnScrap.Name = "btnScrap";
            this.btnScrap.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnScrap.Size = new System.Drawing.Size(230, 75);
            this.btnScrap.TabIndex = 5;
            this.btnScrap.Text = "Selejt";
            this.btnScrap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScrap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnScrap.UseVisualStyleBackColor = true;
            this.btnScrap.Click += new System.EventHandler(this.btnScrap_Click);
            // 
            // btnFP
            // 
            this.btnFP.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFP.FlatAppearance.BorderSize = 0;
            this.btnFP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFP.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFP.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnFP.Image = global::RestAPIKliens.Properties.Resources.icons8_meat_64__1_;
            this.btnFP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFP.Location = new System.Drawing.Point(0, 305);
            this.btnFP.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.btnFP.Name = "btnFP";
            this.btnFP.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnFP.Size = new System.Drawing.Size(230, 75);
            this.btnFP.TabIndex = 4;
            this.btnFP.Text = "Kész termékek";
            this.btnFP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFP.UseVisualStyleBackColor = true;
            this.btnFP.Click += new System.EventHandler(this.btnFP_Click);
            // 
            // btnBasin
            // 
            this.btnBasin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBasin.FlatAppearance.BorderSize = 0;
            this.btnBasin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBasin.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBasin.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBasin.Image = global::RestAPIKliens.Properties.Resources.icons8_barrel_64;
            this.btnBasin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBasin.Location = new System.Drawing.Point(0, 230);
            this.btnBasin.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.btnBasin.Name = "btnBasin";
            this.btnBasin.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnBasin.Size = new System.Drawing.Size(230, 75);
            this.btnBasin.TabIndex = 3;
            this.btnBasin.Text = "Basin";
            this.btnBasin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBasin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBasin.UseVisualStyleBackColor = true;
            this.btnBasin.Click += new System.EventHandler(this.btnBasin_Click);
            // 
            // btnDry
            // 
            this.btnDry.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDry.FlatAppearance.BorderSize = 0;
            this.btnDry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDry.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDry.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDry.Image = global::RestAPIKliens.Properties.Resources.icons8_wheat_60__2_;
            this.btnDry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDry.Location = new System.Drawing.Point(0, 155);
            this.btnDry.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.btnDry.Name = "btnDry";
            this.btnDry.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnDry.Size = new System.Drawing.Size(230, 75);
            this.btnDry.TabIndex = 2;
            this.btnDry.Text = "Száraz    raktár";
            this.btnDry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDry.UseVisualStyleBackColor = true;
            this.btnDry.Click += new System.EventHandler(this.btnDry_Click);
            // 
            // btnRS
            // 
            this.btnRS.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRS.FlatAppearance.BorderSize = 0;
            this.btnRS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRS.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRS.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnRS.Image = global::RestAPIKliens.Properties.Resources.icons8_meat_64;
            this.btnRS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRS.Location = new System.Drawing.Point(0, 80);
            this.btnRS.Name = "btnRS";
            this.btnRS.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnRS.Size = new System.Drawing.Size(230, 75);
            this.btnRS.TabIndex = 1;
            this.btnRS.Text = "Nyersanyag raktár";
            this.btnRS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRS.UseVisualStyleBackColor = true;
            this.btnRS.Click += new System.EventHandler(this.btnRS_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 538);
            this.Controls.Add(this.panelDesktopPane);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(815, 565);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnRS;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnBasin;
        private System.Windows.Forms.Button btnDry;
        private System.Windows.Forms.Button btnStat;
        private System.Windows.Forms.Button btnScrap;
        private System.Windows.Forms.Button btnFP;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label IceYtm;
        private System.Windows.Forms.Panel panelDesktopPane;
        private System.Windows.Forms.Button btnCloseChildForm;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Button bntMinimize;
        private System.Windows.Forms.Button btnClose;
    }
}

