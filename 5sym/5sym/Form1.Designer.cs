namespace _5sym
{
    partial class main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.add = new System.Windows.Forms.Button();
            this.numbers = new System.Windows.Forms.ListBox();
            this.mode = new System.Windows.Forms.ComboBox();
            this.modelbl = new System.Windows.Forms.Label();
            this.results = new System.Windows.Forms.RichTextBox();
            this.calc = new System.Windows.Forms.Button();
            this.conv_num = new System.Windows.Forms.TextBox();
            this.conv_res = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sym4 = new System.Windows.Forms.PictureBox();
            this.sym3 = new System.Windows.Forms.PictureBox();
            this.sym2 = new System.Windows.Forms.PictureBox();
            this.sym1 = new System.Windows.Forms.PictureBox();
            this.sym0 = new System.Windows.Forms.PictureBox();
            this.conv_alert = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sym4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sym3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sym2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sym1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sym0)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(23, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(105, 25);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(135, 13);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(56, 25);
            this.add.TabIndex = 1;
            this.add.Text = "add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // numbers
            // 
            this.numbers.FormattingEnabled = true;
            this.numbers.ItemHeight = 17;
            this.numbers.Location = new System.Drawing.Point(23, 45);
            this.numbers.Name = "numbers";
            this.numbers.Size = new System.Drawing.Size(168, 140);
            this.numbers.TabIndex = 2;
            // 
            // mode
            // 
            this.mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mode.FormattingEnabled = true;
            this.mode.Items.AddRange(new object[] {
            "addition",
            "subtraction",
            "multiplication",
            "division"});
            this.mode.Location = new System.Drawing.Point(23, 192);
            this.mode.Name = "mode";
            this.mode.Size = new System.Drawing.Size(121, 25);
            this.mode.TabIndex = 3;
            // 
            // modelbl
            // 
            this.modelbl.AutoSize = true;
            this.modelbl.Location = new System.Drawing.Point(150, 195);
            this.modelbl.Name = "modelbl";
            this.modelbl.Size = new System.Drawing.Size(42, 17);
            this.modelbl.TabIndex = 4;
            this.modelbl.Text = "mode";
            // 
            // results
            // 
            this.results.Location = new System.Drawing.Point(197, 75);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(100, 110);
            this.results.TabIndex = 5;
            this.results.Text = "";
            // 
            // calc
            // 
            this.calc.Location = new System.Drawing.Point(197, 45);
            this.calc.Name = "calc";
            this.calc.Size = new System.Drawing.Size(100, 24);
            this.calc.TabIndex = 6;
            this.calc.Text = "calculate";
            this.calc.UseVisualStyleBackColor = true;
            this.calc.Click += new System.EventHandler(this.calc_Click);
            // 
            // conv_num
            // 
            this.conv_num.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.conv_num.Location = new System.Drawing.Point(6, 24);
            this.conv_num.Name = "conv_num";
            this.conv_num.Size = new System.Drawing.Size(135, 25);
            this.conv_num.TabIndex = 10;
            this.conv_num.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            this.conv_num.KeyUp += new System.Windows.Forms.KeyEventHandler(this.conv_num_KeyUp);
            // 
            // conv_res
            // 
            this.conv_res.Location = new System.Drawing.Point(7, 104);
            this.conv_res.Name = "conv_res";
            this.conv_res.Size = new System.Drawing.Size(229, 25);
            this.conv_res.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.conv_alert);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.conv_num);
            this.groupBox1.Controls.Add(this.conv_res);
            this.groupBox1.Location = new System.Drawing.Point(383, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 163);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Convert";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.sym4);
            this.panel2.Controls.Add(this.sym3);
            this.panel2.Controls.Add(this.sym2);
            this.panel2.Controls.Add(this.sym1);
            this.panel2.Controls.Add(this.sym0);
            this.panel2.Location = new System.Drawing.Point(155, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(81, 18);
            this.panel2.TabIndex = 15;
            this.panel2.Visible = false;
            // 
            // sym4
            // 
            this.sym4.Image = global::_5sym.Properties.Resources.sym5;
            this.sym4.Location = new System.Drawing.Point(64, 0);
            this.sym4.Name = "sym4";
            this.sym4.Size = new System.Drawing.Size(16, 16);
            this.sym4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sym4.TabIndex = 20;
            this.sym4.TabStop = false;
            this.sym4.Click += new System.EventHandler(this.sym4_Click);
            // 
            // sym3
            // 
            this.sym3.Image = global::_5sym.Properties.Resources.sym3;
            this.sym3.Location = new System.Drawing.Point(48, 0);
            this.sym3.Name = "sym3";
            this.sym3.Size = new System.Drawing.Size(16, 16);
            this.sym3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sym3.TabIndex = 19;
            this.sym3.TabStop = false;
            this.sym3.Click += new System.EventHandler(this.sym3_Click);
            // 
            // sym2
            // 
            this.sym2.Image = global::_5sym.Properties.Resources.sym2;
            this.sym2.Location = new System.Drawing.Point(32, 0);
            this.sym2.Name = "sym2";
            this.sym2.Size = new System.Drawing.Size(16, 16);
            this.sym2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sym2.TabIndex = 18;
            this.sym2.TabStop = false;
            this.sym2.Click += new System.EventHandler(this.sym2_Click);
            // 
            // sym1
            // 
            this.sym1.Image = global::_5sym.Properties.Resources.sym1;
            this.sym1.Location = new System.Drawing.Point(16, 0);
            this.sym1.Name = "sym1";
            this.sym1.Size = new System.Drawing.Size(16, 16);
            this.sym1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sym1.TabIndex = 17;
            this.sym1.TabStop = false;
            this.sym1.Click += new System.EventHandler(this.sym1_Click);
            // 
            // sym0
            // 
            this.sym0.Image = global::_5sym.Properties.Resources.sym0;
            this.sym0.Location = new System.Drawing.Point(0, 0);
            this.sym0.Name = "sym0";
            this.sym0.Size = new System.Drawing.Size(16, 16);
            this.sym0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sym0.TabIndex = 16;
            this.sym0.TabStop = false;
            this.sym0.Click += new System.EventHandler(this.sym0_Click);
            // 
            // conv_alert
            // 
            this.conv_alert.AutoSize = true;
            this.conv_alert.ForeColor = System.Drawing.Color.Black;
            this.conv_alert.Location = new System.Drawing.Point(146, 28);
            this.conv_alert.Name = "conv_alert";
            this.conv_alert.Size = new System.Drawing.Size(90, 17);
            this.conv_alert.TabIndex = 14;
            this.conv_alert.Text = "Input is empty";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 77);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(132, 21);
            this.radioButton2.TabIndex = 13;
            this.radioButton2.Text = "5-sym to numbers";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(7, 138);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 18);
            this.panel1.TabIndex = 13;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 56);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(135, 21);
            this.radioButton1.TabIndex = 12;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Numbers to 5-sym";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 227);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.calc);
            this.Controls.Add(this.results);
            this.Controls.Add(this.modelbl);
            this.Controls.Add(this.mode);
            this.Controls.Add(this.numbers);
            this.Controls.Add(this.add);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "main";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sym4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sym3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sym2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sym1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sym0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.ListBox numbers;
        private System.Windows.Forms.ComboBox mode;
        private System.Windows.Forms.Label modelbl;
        private System.Windows.Forms.RichTextBox results;
        private System.Windows.Forms.Button calc;
        private System.Windows.Forms.TextBox conv_num;
        private System.Windows.Forms.TextBox conv_res;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label conv_alert;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox sym4;
        private System.Windows.Forms.PictureBox sym3;
        private System.Windows.Forms.PictureBox sym2;
        private System.Windows.Forms.PictureBox sym1;
        private System.Windows.Forms.PictureBox sym0;
    }
}

