using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Base
{
    public partial class MainForm : Form
    {
        public MainForm()
        => InitializeComponent();
        
        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;         
            else
                e.Effect = DragDropEffects.None;          
        }
        public string DirectoryName = "";
        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                Array array = (Array)e.Data.GetData(DataFormats.FileDrop);
                if (array != null)
                {
                    string text = array.GetValue(0).ToString();
                    int num = text.LastIndexOf(".");
                    if (num != -1)
                    {
                        string text2 = text.Substring(num);
                        if (text2 == ".EXAMPLE" || text2 == ".EXAMPLE2")
                        {
                            base.Activate();
                            this.file.Text = text;
                            int num2 = text.LastIndexOf("\\");
                            if (num2 != -1)
                                this.DirectoryName = text.Remove(num2, text.Length - num2);                     
                            if (this.DirectoryName.Length == 2)  
                                this.DirectoryName += "\\";                         
                        }
                    }
                }
            } catch {}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.status.Text = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Browse for target file";
            openFileDialog.InitialDirectory = "c:\\";
            if (this.DirectoryName != "")
                openFileDialog.InitialDirectory = this.DirectoryName;        
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                this.file.Text = fileName;
                int num = fileName.LastIndexOf("\\");
                if (num != -1)
                    this.DirectoryName = fileName.Remove(num, fileName.Length - num);
                if (this.DirectoryName.Length == 2)
                    this.DirectoryName += "\\";
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void ActionBtn_Click(object sender, EventArgs e)
        {

        }

        private void ExitApp(object sender, EventArgs e)
        => Application.Exit();

    }
}
