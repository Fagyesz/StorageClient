namespace RestAPIKliens.Forms.Selectors
{
    partial class StatAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnPost = new System.Windows.Forms.Button();
            this.txtPostWeight = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Selejtezés Dátuma";
            // 
            // btnPost
            // 
            this.btnPost.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPost.Location = new System.Drawing.Point(82, 162);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(93, 37);
            this.btnPost.TabIndex = 48;
            this.btnPost.Text = "Feltölt";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // txtPostWeight
            // 
            this.txtPostWeight.FormattingEnabled = true;
            this.txtPostWeight.Items.AddRange(new object[] {
            "100",
            "200",
            "300",
            "400",
            "500",
            "600"});
            this.txtPostWeight.Location = new System.Drawing.Point(75, 68);
            this.txtPostWeight.Name = "txtPostWeight";
            this.txtPostWeight.Size = new System.Drawing.Size(100, 21);
            this.txtPostWeight.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Súly";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(22, 127);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(219, 20);
            this.dateTimePicker1.TabIndex = 50;
            // 
            // StatAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 242);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.txtPostWeight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "StatAdd";
            this.Text = "StatAdd";
            this.Load += new System.EventHandler(this.StatAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.ComboBox txtPostWeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}