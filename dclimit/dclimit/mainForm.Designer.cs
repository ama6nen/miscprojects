namespace dclimit
{
    partial class mainForm
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
            this.components = new System.ComponentModel.Container();
            this.WorkButton = new System.Windows.Forms.Button();
            this.DiscordButton = new System.Windows.Forms.Button();
            this.DiscordTime = new System.Windows.Forms.Label();
            this.Watchdog = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // WorkButton
            // 
            this.WorkButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.WorkButton.ForeColor = System.Drawing.Color.LawnGreen;
            this.WorkButton.Location = new System.Drawing.Point(12, 13);
            this.WorkButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WorkButton.Name = "WorkButton";
            this.WorkButton.Size = new System.Drawing.Size(121, 30);
            this.WorkButton.TabIndex = 0;
            this.WorkButton.Text = "Start work mode";
            this.WorkButton.UseVisualStyleBackColor = false;
            this.WorkButton.Click += new System.EventHandler(this.WorkButton_Click);
            // 
            // DiscordButton
            // 
            this.DiscordButton.Location = new System.Drawing.Point(141, 13);
            this.DiscordButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DiscordButton.Name = "DiscordButton";
            this.DiscordButton.Size = new System.Drawing.Size(121, 30);
            this.DiscordButton.TabIndex = 1;
            this.DiscordButton.Text = "Discord mode";
            this.DiscordButton.UseVisualStyleBackColor = true;
            this.DiscordButton.Click += new System.EventHandler(this.DiscordButton_Click);
            // 
            // DiscordTime
            // 
            this.DiscordTime.AutoSize = true;
            this.DiscordTime.Location = new System.Drawing.Point(13, 52);
            this.DiscordTime.Name = "DiscordTime";
            this.DiscordTime.Size = new System.Drawing.Size(195, 17);
            this.DiscordTime.TabIndex = 2;
            this.DiscordTime.Text = "Allowed Discord time: 0 minutes";
            // 
            // Watchdog
            // 
            this.Watchdog.Enabled = true;
            this.Watchdog.Interval = 1000;
            this.Watchdog.Tick += new System.EventHandler(this.Watchdog_Tick);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 77);
            this.ControlBox = false;
            this.Controls.Add(this.DiscordTime);
            this.Controls.Add(this.DiscordButton);
            this.Controls.Add(this.WorkButton);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Discord limiter";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button WorkButton;
        private System.Windows.Forms.Button DiscordButton;
        private System.Windows.Forms.Label DiscordTime;
        private System.Windows.Forms.Timer Watchdog;
    }
}

