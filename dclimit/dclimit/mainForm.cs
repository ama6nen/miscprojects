using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dclimit
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsIconic(IntPtr hWnd);

        int discordPoints = 1;
        int fractionalCounter = 0;
        DateTime WorkStartTime = default;
        private void Watchdog_Tick(object sender, EventArgs e)
        {
            if (discordPoints < 1)
            {
                if (!WorkButton.Enabled && DiscordButton.Enabled)
                    WorkButton.Enabled = true;
                DiscordButton.Enabled = false;
            }

            bool discordMode = !WorkButton.Enabled;
            if (discordPoints == 1)
                DiscordTime.Text = $"Allowed DC time: {60 - fractionalCounter} seconds";
            else
                DiscordTime.Text = $"Allowed DC time: {discordPoints - 1} min {60 - fractionalCounter} sec";

            if (discordMode)
            {
                fractionalCounter++;
                if (fractionalCounter >= 60)
                {
                    discordPoints--;
                    fractionalCounter = 0;
                }
                if (discordPoints > 0)
                    return;
            }
            var procs = Process.GetProcessesByName("Discord");
            foreach (var proc in procs)
                if (!string.IsNullOrEmpty(proc.MainWindowTitle))
                    if (!IsIconic(proc.MainWindowHandle))
                        ShowWindow(proc.MainWindowHandle, 6);
        }

        private void WorkButton_Click(object sender, EventArgs e)
        {
            bool startNow = WorkButton.Text.StartsWith("Start");
            if (startNow)
            {
                WorkButton.Text = WorkButton.Text.Replace("Start", "End");
                WorkButton.ForeColor = Color.Red;
                WorkStartTime = DateTime.Now;
            }
            else
            {
                var elapsed = DateTime.Now.Subtract(WorkStartTime);
                var elapsedPoints = elapsed.TotalMinutes / 6.0;
                var minutes = Convert.ToInt32(elapsedPoints);
                discordPoints += minutes;
                if(fractionalCounter > 0)
                {
                    var val = Convert.ToInt32(100.0 * (elapsedPoints - Math.Floor(elapsedPoints)));
                    fractionalCounter -= val;
                    if (fractionalCounter < 0)
                        fractionalCounter = 0;
                }
                WorkButton.Text = WorkButton.Text.Replace("End", "Start");
                WorkButton.ForeColor = Color.LawnGreen;
            }
            DiscordButton.Enabled = !startNow;
        }

        private void DiscordButton_Click(object sender, EventArgs e)
        {
            bool startNow = DiscordButton.Text.StartsWith("Discord");
            if (startNow)
                DiscordButton.Text = DiscordButton.Text.Replace("Discord", "No discord");
            else
                DiscordButton.Text = DiscordButton.Text.Replace("No discord", "Discord");

            WorkButton.Enabled = !startNow;
        }
    }
}
