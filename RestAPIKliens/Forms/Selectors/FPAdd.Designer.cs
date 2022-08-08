namespace RestAPIKliens.Forms.Selectors
{
    partial class FPAdd
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
            this.txtPostName = new System.Windows.Forms.ComboBox();
            this.btnPost = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPostWeight = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPostPlace = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCollection3 = new System.Windows.Forms.Button();
            this.btnCollection2 = new System.Windows.Forms.Button();
            this.btnCollection = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPostName
            // 
            this.txtPostName.FormattingEnabled = true;
            this.txtPostName.Items.AddRange(new object[] {
            "Comb",
            "Csülök",
            "kenyér"});
            this.txtPostName.Location = new System.Drawing.Point(40, 45);
            this.txtPostName.Name = "txtPostName";
            this.txtPostName.Size = new System.Drawing.Size(100, 21);
            this.txtPostName.TabIndex = 33;
            // 
            // btnPost
            // 
            this.btnPost.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPost.Location = new System.Drawing.Point(78, 244);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(93, 37);
            this.btnPost.TabIndex = 32;
            this.btnPost.Text = "Feltölt";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Honnan érkezett";
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
            this.txtPostWeight.Location = new System.Drawing.Point(40, 95);
            this.txtPostWeight.Name = "txtPostWeight";
            this.txtPostWeight.Size = new System.Drawing.Size(100, 21);
            this.txtPostWeight.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Súly";
            // 
            // txtPostPlace
            // 
            this.txtPostPlace.FormattingEnabled = true;
            this.txtPostPlace.Items.AddRange(new object[] {
            "Eger",
            "Miskolc",
            "Gyöngyös",
            "Pásztó"});
            this.txtPostPlace.Location = new System.Drawing.Point(40, 150);
            this.txtPostPlace.Name = "txtPostPlace";
            this.txtPostPlace.Size = new System.Drawing.Size(100, 21);
            this.txtPostPlace.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Megnevezés";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(16, 218);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(219, 20);
            this.dateTimePicker1.TabIndex = 36;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BackgroundImage = global::RestAPIKliens.Properties.Resources.icons8_erase_20;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClear.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnClear.Location = new System.Drawing.Point(7, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(25, 24);
            this.btnClear.TabIndex = 65;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCollection3
            // 
            this.btnCollection3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCollection3.Location = new System.Drawing.Point(163, 149);
            this.btnCollection3.Name = "btnCollection3";
            this.btnCollection3.Size = new System.Drawing.Size(67, 21);
            this.btnCollection3.TabIndex = 64;
            this.btnCollection3.Text = "Bővítés";
            this.btnCollection3.UseVisualStyleBackColor = true;
            this.btnCollection3.Visible = false;
            this.btnCollection3.Click += new System.EventHandler(this.btnCollection3_Click);
            // 
            // btnCollection2
            // 
            this.btnCollection2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCollection2.Location = new System.Drawing.Point(163, 95);
            this.btnCollection2.Name = "btnCollection2";
            this.btnCollection2.Size = new System.Drawing.Size(67, 21);
            this.btnCollection2.TabIndex = 63;
            this.btnCollection2.Text = "Bővítés";
            this.btnCollection2.UseVisualStyleBackColor = true;
            this.btnCollection2.Visible = false;
            this.btnCollection2.Click += new System.EventHandler(this.btnCollection2_Click);
            // 
            // btnCollection
            // 
            this.btnCollection.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCollection.Location = new System.Drawing.Point(163, 45);
            this.btnCollection.Name = "btnCollection";
            this.btnCollection.Size = new System.Drawing.Size(67, 21);
            this.btnCollection.TabIndex = 62;
            this.btnCollection.Text = "Bővítés";
            this.btnCollection.UseVisualStyleBackColor = true;
            this.btnCollection.Visible = false;
            this.btnCollection.Click += new System.EventHandler(this.btnCollection_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::RestAPIKliens.Properties.Resources.icons8_gear_16;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(220, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 24);
            this.button2.TabIndex = 61;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 66;
            this.label1.Text = "Mikor érkezett";
            // 
            // FPAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 293);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCollection3);
            this.Controls.Add(this.btnCollection2);
            this.Controls.Add(this.btnCollection);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtPostName);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPostWeight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPostPlace);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "FPAdd";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FPAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox txtPostName;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox txtPostWeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox txtPostPlace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCollection3;
        private System.Windows.Forms.Button btnCollection2;
        private System.Windows.Forms.Button btnCollection;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}