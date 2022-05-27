namespace RestAPIKliens.Forms
{
    partial class FormDry
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
            this.dataGridDry = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtPostName = new System.Windows.Forms.ComboBox();
            this.btnPost = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPostWeight = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPostPlace = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.gtnGetById = new System.Windows.Forms.Button();
            this.txtGetById = new System.Windows.Forms.TextBox();
            this.btnGetAll = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelSelector = new System.Windows.Forms.Panel();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDry)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelSelector.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridDry
            // 
            this.dataGridDry.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridDry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridDry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDry.Location = new System.Drawing.Point(0, 0);
            this.dataGridDry.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.dataGridDry.Name = "dataGridDry";
            this.dataGridDry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridDry.Size = new System.Drawing.Size(610, 447);
            this.dataGridDry.TabIndex = 21;
            this.dataGridDry.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDry_CellContentClick);
            this.dataGridDry.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDry_CellValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panelSelector);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(364, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 447);
            this.panel1.TabIndex = 21;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.gtnGetById);
            this.panel4.Controls.Add(this.txtGetById);
            this.panel4.Controls.Add(this.txtPostName);
            this.panel4.Controls.Add(this.btnGetAll);
            this.panel4.Controls.Add(this.btnPost);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtPostWeight);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtPostPlace);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.dateTimePicker1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 303);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(246, 144);
            this.panel4.TabIndex = 33;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // txtPostName
            // 
            this.txtPostName.FormattingEnabled = true;
            this.txtPostName.Items.AddRange(new object[] {
            "Comb",
            "Csülök",
            "kenyér"});
            this.txtPostName.Location = new System.Drawing.Point(13, 142);
            this.txtPostName.Name = "txtPostName";
            this.txtPostName.Size = new System.Drawing.Size(100, 21);
            this.txtPostName.TabIndex = 22;
            this.txtPostName.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnPost
            // 
            this.btnPost.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPost.Location = new System.Drawing.Point(75, 243);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(93, 37);
            this.btnPost.TabIndex = 6;
            this.btnPost.Text = "Feltölt";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Honnan érkezett";
            this.label3.Click += new System.EventHandler(this.label3_Click);
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
            this.txtPostWeight.Location = new System.Drawing.Point(132, 142);
            this.txtPostWeight.Name = "txtPostWeight";
            this.txtPostWeight.Size = new System.Drawing.Size(100, 21);
            this.txtPostWeight.TabIndex = 23;
            this.txtPostWeight.SelectedIndexChanged += new System.EventHandler(this.txtPostWeight_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Súly";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtPostPlace
            // 
            this.txtPostPlace.FormattingEnabled = true;
            this.txtPostPlace.Items.AddRange(new object[] {
            "Eger",
            "Miskolc",
            "Gyöngyös",
            "Pásztó"});
            this.txtPostPlace.Location = new System.Drawing.Point(13, 190);
            this.txtPostPlace.Name = "txtPostPlace";
            this.txtPostPlace.Size = new System.Drawing.Size(100, 21);
            this.txtPostPlace.TabIndex = 24;
            this.txtPostPlace.SelectedIndexChanged += new System.EventHandler(this.txtPostPlace_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Megnevezés";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(13, 217);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(219, 20);
            this.dateTimePicker1.TabIndex = 28;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // gtnGetById
            // 
            this.gtnGetById.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gtnGetById.Location = new System.Drawing.Point(20, 70);
            this.gtnGetById.Name = "gtnGetById";
            this.gtnGetById.Size = new System.Drawing.Size(104, 43);
            this.gtnGetById.TabIndex = 2;
            this.gtnGetById.Text = "Keresés";
            this.gtnGetById.UseVisualStyleBackColor = true;
            this.gtnGetById.Click += new System.EventHandler(this.gtnGetById_Click);
            // 
            // txtGetById
            // 
            this.txtGetById.Location = new System.Drawing.Point(127, 82);
            this.txtGetById.Name = "txtGetById";
            this.txtGetById.Size = new System.Drawing.Size(100, 20);
            this.txtGetById.TabIndex = 3;
            this.txtGetById.TextChanged += new System.EventHandler(this.txtGetById_TextChanged);
            // 
            // btnGetAll
            // 
            this.btnGetAll.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnGetAll.Location = new System.Drawing.Point(20, 9);
            this.btnGetAll.Name = "btnGetAll";
            this.btnGetAll.Size = new System.Drawing.Size(104, 43);
            this.btnGetAll.TabIndex = 0;
            this.btnGetAll.Text = "Frissités";
            this.btnGetAll.UseVisualStyleBackColor = true;
            this.btnGetAll.Click += new System.EventHandler(this.btnGetAll_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.dataGridDry);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(610, 447);
            this.panel3.TabIndex = 30;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panelSelector
            // 
            this.panelSelector.Controls.Add(this.radioButton5);
            this.panelSelector.Controls.Add(this.radioButton4);
            this.panelSelector.Controls.Add(this.radioButton3);
            this.panelSelector.Controls.Add(this.radioButton1);
            this.panelSelector.Controls.Add(this.radioButton2);
            this.panelSelector.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSelector.Location = new System.Drawing.Point(0, 0);
            this.panelSelector.Name = "panelSelector";
            this.panelSelector.Size = new System.Drawing.Size(246, 84);
            this.panelSelector.TabIndex = 34;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(26, 55);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(63, 17);
            this.radioButton5.TabIndex = 6;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Basinba";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(125, 32);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(75, 17);
            this.radioButton4.TabIndex = 5;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Nyomtatás";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(26, 32);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(51, 17);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Selejt";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(26, 9);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(63, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Keresés";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(125, 9);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(78, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Hozzáadás";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(246, 219);
            this.panel2.TabIndex = 35;
            // 
            // FormDry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 447);
            this.Controls.Add(this.panel3);
            this.Name = "FormDry";
            this.Text = "FormDry";
            this.Load += new System.EventHandler(this.FormDry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDry)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panelSelector.ResumeLayout(false);
            this.panelSelector.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnGetAll;
        private System.Windows.Forms.Button gtnGetById;
        private System.Windows.Forms.TextBox txtGetById;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridDry;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox txtPostName;
        private System.Windows.Forms.ComboBox txtPostPlace;
        private System.Windows.Forms.ComboBox txtPostWeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelSelector;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}