namespace RestAPIKliens.Forms
{
    partial class FormStat
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.panelSelector = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.paneAll = new System.Windows.Forms.Panel();
            this.dataGridRS = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panelSelector.SuspendLayout();
            this.paneAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRS)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelFill);
            this.panel1.Controls.Add(this.panelSelector);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(443, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 477);
            this.panel1.TabIndex = 33;
            // 
            // panelFill
            // 
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 83);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(240, 394);
            this.panelFill.TabIndex = 34;
            // 
            // panelSelector
            // 
            this.panelSelector.Controls.Add(this.radioButton2);
            this.panelSelector.Controls.Add(this.radioButton1);
            this.panelSelector.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSelector.Location = new System.Drawing.Point(0, 0);
            this.panelSelector.Name = "panelSelector";
            this.panelSelector.Size = new System.Drawing.Size(240, 83);
            this.panelSelector.TabIndex = 32;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(25, 35);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(63, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Keresés";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_2);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(118, 35);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(75, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Keresés++";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged_1);
            // 
            // paneAll
            // 
            this.paneAll.Controls.Add(this.dataGridRS);
            this.paneAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneAll.Location = new System.Drawing.Point(0, 0);
            this.paneAll.Name = "paneAll";
            this.paneAll.Size = new System.Drawing.Size(443, 477);
            this.paneAll.TabIndex = 34;
            // 
            // dataGridRS
            // 
            this.dataGridRS.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridRS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridRS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridRS.Location = new System.Drawing.Point(0, 0);
            this.dataGridRS.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.dataGridRS.Name = "dataGridRS";
            this.dataGridRS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridRS.Size = new System.Drawing.Size(443, 477);
            this.dataGridRS.TabIndex = 22;
            this.dataGridRS.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRS_CellValueChanged_1);
            // 
            // FormStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 477);
            this.Controls.Add(this.paneAll);
            this.Controls.Add(this.panel1);
            this.Name = "FormStat";
            this.Text = "FormStat";
            this.Load += new System.EventHandler(this.FormStat_Load);
            this.panel1.ResumeLayout(false);
            this.panelSelector.ResumeLayout(false);
            this.panelSelector.PerformLayout();
            this.paneAll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Panel panelSelector;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Panel paneAll;
        private System.Windows.Forms.DataGridView dataGridRS;
    }
}