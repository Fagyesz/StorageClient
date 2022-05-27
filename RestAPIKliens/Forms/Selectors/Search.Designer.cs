namespace RestAPIKliens.Forms.Selectors
{
    partial class Search
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
            this.gtnGetById = new System.Windows.Forms.Button();
            this.btnGetAll = new System.Windows.Forms.Button();
            this.txtGetById = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // gtnGetById
            // 
            this.gtnGetById.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gtnGetById.Location = new System.Drawing.Point(12, 74);
            this.gtnGetById.Name = "gtnGetById";
            this.gtnGetById.Size = new System.Drawing.Size(104, 43);
            this.gtnGetById.TabIndex = 5;
            this.gtnGetById.Text = "Keresés";
            this.gtnGetById.UseVisualStyleBackColor = true;
            this.gtnGetById.Click += new System.EventHandler(this.gtnGetById_Click);
            // 
            // btnGetAll
            // 
            this.btnGetAll.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnGetAll.Location = new System.Drawing.Point(12, 18);
            this.btnGetAll.Name = "btnGetAll";
            this.btnGetAll.Size = new System.Drawing.Size(104, 43);
            this.btnGetAll.TabIndex = 4;
            this.btnGetAll.Text = "Frissités";
            this.btnGetAll.UseVisualStyleBackColor = true;
            this.btnGetAll.Click += new System.EventHandler(this.btnGetAll_Click);
            // 
            // txtGetById
            // 
            this.txtGetById.Location = new System.Drawing.Point(123, 86);
            this.txtGetById.Name = "txtGetById";
            this.txtGetById.Size = new System.Drawing.Size(100, 20);
            this.txtGetById.TabIndex = 6;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 139);
            this.Controls.Add(this.gtnGetById);
            this.Controls.Add(this.btnGetAll);
            this.Controls.Add(this.txtGetById);
            this.Name = "Search";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Search_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button gtnGetById;
        private System.Windows.Forms.Button btnGetAll;
        private System.Windows.Forms.TextBox txtGetById;
    }
}