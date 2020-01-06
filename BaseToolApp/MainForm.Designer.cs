using System.Drawing;
using System.Windows.Forms;

namespace Base
{
    partial class MainForm
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
            this.exitbtn = new System.Windows.Forms.Button();
            this.actionbtn = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.file = new System.Windows.Forms.TextBox();
            this.browsebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exitbtn
            // 
            this.exitbtn.Location = new System.Drawing.Point(383, 103);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(72, 26);
            this.exitbtn.TabIndex = 20;
            this.exitbtn.Text = "Exit";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.ExitApp);
            // 
            // actionbtn
            // 
            this.actionbtn.Location = new System.Drawing.Point(218, 103);
            this.actionbtn.Name = "actionbtn";
            this.actionbtn.Size = new System.Drawing.Size(72, 26);
            this.actionbtn.TabIndex = 19;
            this.actionbtn.Text = "Base button";
            this.actionbtn.UseVisualStyleBackColor = true;
            this.actionbtn.Click += new System.EventHandler(this.ActionBtn_Click);
            // 
            // status
            // 
            this.status.ForeColor = System.Drawing.Color.Blue;
            this.status.Location = new System.Drawing.Point(112, 75);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(293, 25);
            this.status.TabIndex = 23;
            this.status.Text = "Current status";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(46, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 14);
            this.label1.TabIndex = 22;
            this.label1.Text = "Name of file:";
            // 
            // file
            // 
            this.file.AllowDrop = true;
            this.file.Location = new System.Drawing.Point(46, 50);
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(419, 20);
            this.file.TabIndex = 21;
            this.file.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.file.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            // 
            // browsebtn
            // 
            this.browsebtn.Location = new System.Drawing.Point(46, 103);
            this.browsebtn.Name = "browsebtn";
            this.browsebtn.Size = new System.Drawing.Size(123, 26);
            this.browsebtn.TabIndex = 18;
            this.browsebtn.Text = "Browse for file";
            this.browsebtn.UseVisualStyleBackColor = true;
            this.browsebtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 166);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.actionbtn);
            this.Controls.Add(this.status);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.file);
            this.Controls.Add(this.browsebtn);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Base";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browsebtn;
        private System.Windows.Forms.Button actionbtn;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.TextBox file;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label status;
    }
}

