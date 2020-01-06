using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ce_detect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        enum wow
        {
            Unknown,
            CETRAINER,
            General,
            OldVersion,
            FakeTrainer
        };
        int probability = 0;
        int fakeHits = 0;
        private async void button2_Click(object sender, EventArgs e)
        {
            await Task.Delay(0);
            wow w = wow.Unknown;
            string text = this.textBox1.Text;
            if (File.Exists(text))
            {

                StreamReader r = new StreamReader(text, Encoding.GetEncoding("iso-8859-1"), false);
         
                string alltext = r.ReadToEnd();

                FileVersionInfo nff = FileVersionInfo.GetVersionInfo(text);

                try
                {
                    AssemblyName nam = AssemblyName.GetAssemblyName(text);
                    w = wow.FakeTrainer;
                    fakeHits++;
                }
                catch (BadImageFormatException ff)
                {

                }
            

                if (text.EndsWith(".CETRAINER"))
                {
                    w = wow.CETRAINER;
                    probability += 100;
                }
                if (text.EndsWith(".EXE"))
                {
                    w = wow.General;
                    probability += 5;
                }
                if (text.EndsWith(".exe"))
                {
                    w = wow.Unknown;
                    probability -= 20;
                }
                if (alltext.Contains("IsDebuggerPresent"))
                {
                    probability += 10;
                }
                if(alltext.Contains("Microsoft Visual C++ Runtime Library "))
                {
                    probability += 5;
                }
                if (alltext.Contains("PADPADDINGXX"))
                {
                    w = wow.General;
                    probability += 5;
                }
                if (alltext.Contains("dark_byte@hotmail.com"))
                {
                    w = wow.General;
                    probability += 20;
                }
                if(alltext.Contains("GlobalSign CodeSigning"))
                {
                    probability += 15;
                }
                if (alltext.Contains("www.cheatengine.org"))
                {
                    probability += 15;
                }
                if (alltext.Contains("CET_TRAINER.CETRAINER"))
                {
                    probability += 15;
                }
                if(alltext.Contains("This trainer was made by Cheat Engine"))
                {
                    probability += 15;
                    w = wow.General;
                }
                if(alltext.Contains("ARCHIVE cetrainers"))
                {
                    probability += 15;

                }
                if (alltext.Contains("CET_Archive.dat"))
                {
                    probability += 15;

                }
                if(alltext.Contains("Trainer failure Failure loading the trainer. Your tempfolder must allow execution.") || alltext.Contains("Trainer failure"))
                {
                   
                    probability += 15;
                }
                if(alltext.Contains(".CETRAINER  Launch Error        Please update your Cheat Engine version to Cheat Engine 6.3 or later") || alltext.Contains("Please update your Cheat Engine version to Cheat Engine 6.3 or later"))
                {
                    w = wow.OldVersion;
                    probability += 15;
                }
                if(alltext.Contains("Failure creating a temporary folder Failure assigning a temporary name  Failure getting the temp folder D:(A;OICI;GA;;;WD)") || alltext.Contains("D:(A;OICI;GA;;;WD)"))
                {
                    probability += 15;
                }
                if(alltext.Contains("EncodePointer   K E R N E L 3 2 . D L L     DecodePointer   FlsFree FlsSetValue FlsGetValue FlsAlloc") || alltext.Contains("FlsFree FlsSetValue FlsGetValue FlsAlloc"))
                {
                   
                    probability += 10;
                }
                if(alltext.Contains("GetLocaleInfoA  ¦HeapSize  AFlushFileBuffers "))
                {
                    probability += 10;
                }
                if (alltext.Contains("requireAdministrator"))
                {
                    probability += 5;
                }
                if(alltext.Contains("cheatengine-i386.exe") || alltext.Contains("cheatengine-x86_64.exe"))
                {
                    probability += 15;
                }
                if (alltext.Contains("cheatengine-i386.exe.sig"))
                {
                    probability += 10;
                }
                int count = Regex.Matches(alltext, "This program cannot").Count;
                if(count >= 3)
                {
                    fakeHits++;
                    w = wow.FakeTrainer;
                }
                if (alltext.Contains(".NETFramework") || alltext.Contains(".ctor") || alltext.Contains("System.Resources"))
                {
                    fakeHits++;
                    w = wow.FakeTrainer;
                }
             
                if (probability > 100)
                {
                    probability = 100;
                }
                if (probability < 0)
                {
                    probability = 0;
                }
                if (nff.IsDebug || nff.IsPreRelease || nff.IsPatched)
                {
                    fakeHits++;
                    w = wow.FakeTrainer;
                }
                if (alltext.Contains(@"level=""asInvoker"""))
                {
                    fakeHits++;
                    w = wow.FakeTrainer;
                }
             
                if(nff.Language != null && nff.Language != String.Empty && nff.Language != " " && nff.Language != "")
                {
                    fakeHits++;
                    w = wow.FakeTrainer;
                }

                if(w == wow.FakeTrainer)
                {
                    label2.Text = "The assembly either is not a trainer or binded with something.\nFake Flags: " + fakeHits.ToString() + " | Type: " + w.ToString();
                }
               
                else
                {
                    if (text.EndsWith(".exe"))
                    {
                        label2.Text = "The assembly is " + probability.ToString() + "% a cheat engine trainer\nBut normally trainer ends with big .EXE, this doesn't.Type: " + w.ToString();
                    }else
                    {
                        label2.Text = "The assembly is " + probability.ToString() + "% a cheat engine trainer \nType: " + w.ToString();
                    }
                }
                r.Close();

                probability = 0;
                fakeHits = 0;

            }
            else
            {
                MessageBox.Show("File doesn't exist.");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
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
                        if (text2 == ".EXE" || text2 == ".CETRAINER" || text2 == ".exe")
                        {
                            base.Activate();
                            this.textBox1.Text = text;
                            int num2 = text.LastIndexOf("\\");
                            if (num2 != -1)
                            {
                                this.DirectoryName = text.Remove(num2, text.Length - num2);
                            }
                            if (this.DirectoryName.Length == 2)
                            {
                                this.DirectoryName += "\\";
                            }
                        }
                    }
                }
            }

            catch
            {
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.label2.Text = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Browse for target assembly";
            openFileDialog.InitialDirectory = "c:\\";
            if (this.DirectoryName != "")
            {
                openFileDialog.InitialDirectory = this.DirectoryName;
            }
            openFileDialog.Filter = "All files (*.exe,*.CETRAINER)|*.exe;*.CETRAINER";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                this.textBox1.Text = fileName;
                int num = fileName.LastIndexOf("\\");
                if (num != -1)
                {
                    this.DirectoryName = fileName.Remove(num, fileName.Length - num);
                }
                if (this.DirectoryName.Length == 2)
                {
                    this.DirectoryName += "\\";
                }
            }
        }
    }
}
