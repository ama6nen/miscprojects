using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5sym
{
    public partial class main : Form
    {
        Font fivefont;
        Font normalfont;
        public main()
        {
            InitializeComponent( );
            mode.SelectedIndex = 0;

            var ccc = panel2.Controls;

            foreach (var c in ccc)
            {
                if (c is PictureBox)
                {
                    ((PictureBox)c).MouseEnter += Main_MouseEnter;
                    ((PictureBox)c).MouseLeave += Main_MouseLeave;
                }
                   
            }
            fivefont = new Font( "FiveSym" , 9.75f , FontStyle.Regular );
            normalfont = conv_num.Font;
        }

        private void Main_MouseLeave( object sender , EventArgs e )
        {
            ((PictureBox)sender).BackColor = Color.FromKnownColor(KnownColor.Control);
        }
        private void Main_MouseEnter( object sender , EventArgs e )
        {
            ((PictureBox)sender).BackColor = Color.LightGray;
        }

        private void textBox1_KeyPress( object sender , KeyPressEventArgs e )
        {
            e.Handled = !char.IsDigit( e.KeyChar ) && !char.IsControl( e.KeyChar );
        }

        private void add_Click( object sender , EventArgs e )
        {
            if (textBox1.TextLength < 1)
                return;

            numbers.Items.Add( textBox1.Text );
            textBox1.Text = "";
        }

        private void calc_Click( object sender , EventArgs e )
        {
           
        }

        public static int ToNumeral( int num )
        {
            return num.ToString( ).Reverse( )
                      .Select( ( c , index ) => (int)Char.GetNumericValue( c ) * (int)Math.Pow( 5 , index ) )
                      .Sum( );
        }
        public static string ToFiveSym( object val )
        {
            int value = Math.Abs(int.Parse( val.ToString() ));
            string result = string.Empty;
            do
            {//ABCDEF
                result = "0123456789"[ value % 5 ] + result;
                value /= 5;
            }
            while (value > 0);

            return result;
        }

        public static IEnumerable<int> GetDigits( int source )
        {
            while (source > 0)
            {
                var digit = source % 10;
                source /= 10;
                yield return digit;
            }
        }
        bool basic_checks( string num )
        {
            if (num.Length < 1 || num == string.Empty || conv_alert.ForeColor != Color.Green)
                return false;
            
            var value = long.Parse( num );

            if (value > int.MaxValue || value < int.MinValue)    
                return false;


            if (radioButton2.Checked)
            {
                var digits = GetDigits( (int)value );

                foreach (var digit in digits)
                    if (digit > 4)
                        return false;
            }
            return true;
        }

        private void button1_Click( object sender , EventArgs e )
        {
            if (radioButton1.Checked)
            {
                var a = conv_num.Text;

                if (!basic_checks( a ))
                    return;

                panel1.Controls.Clear( );
                
                var fivesym = ToFiveSym( a );
                conv_res.Text =  fivesym;

                int count = 0;
                foreach(char c in fivesym.ToCharArray( ))
                {
                   
                    panel1.Controls.Add( GenerateSymbol( int.Parse(c.ToString()) , count ) );
                    count++;
                }
              
            }
            
        }

        private void button2_Click( object sender , EventArgs e )
        {
           // MessageBox.Show()
        }

        async void check(KeyPressEventArgs e )
        {
            e.Handled = !char.IsDigit( e.KeyChar ) && !char.IsControl( e.KeyChar );

            if (radioButton2.Checked && conv_num.Text.Length > 0)
                    conv_num.Text = Regex.Replace( conv_num.Text , @"[56789 ]" , "" );
            
            if (conv_num.Text.Length < 1)
            {
                conv_alert.Text = "input is empty";
                conv_alert.ForeColor = Color.Black;
            }
            else if (conv_num.Text.Length > 6 && long.Parse( conv_num.Text ) > int.MaxValue)
            {
                conv_alert.Text = "input too big";
                conv_alert.ForeColor = Color.Red;
            }
            else
            {
                conv_alert.Text = "input is valid";
                conv_alert.ForeColor = Color.Green;
            }

        }
        private async void textBox2_KeyPress( object sender , KeyPressEventArgs e )
        {

            check( e );

            await Task.Delay( 25 );
            check( e );
        }

        int c = 0;
        PictureBox GenerateSymbol(int SymbolAsNumber, int count )
        {
            PictureBox pb = new PictureBox( );

            switch (SymbolAsNumber)
            {
                case 0:
                    pb.Image = Properties.Resources.sym0;
                    break;

                case 1:
                    pb.Image = Properties.Resources.sym1;
                    break;

                case 2:
                    pb.Image = Properties.Resources.sym2;
                    break;

                case 3:
                    pb.Image = Properties.Resources.sym3;
                    break;

                case 4:
                    pb.Image = Properties.Resources.sym5;
                    break;

                default:
                    return null;
            }
           
            pb.Size = new Size( 16 , 16 );
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Location = new Point( count*16 , 0 );
            return pb;
        }
        private void button3_Click( object sender , EventArgs e )
        {
           
            panel1.Controls.Add( GenerateSymbol(c,c) );
            c++;
        }

        private void conv_num_KeyUp( object sender , KeyEventArgs e )
        {

            var a = conv_num.Text;

            if (!basic_checks( a ))
                return;
            
            panel1.Controls.Clear( );

           
            var fivesym = radioButton2.Checked ? ToNumeral(int.Parse(a)).ToString() : ToFiveSym( a );
            conv_res.Text = fivesym;

            if (!radioButton2.Checked)
            {
                int count = 0;
                foreach (char c in fivesym.ToCharArray( ))
                {

                    panel1.Controls.Add( GenerateSymbol( int.Parse( c.ToString( ) ) , count ) );
                    count++;
                }
            }
            
        }

        private void radioButton2_CheckedChanged( object sender , EventArgs e )
        {
            if (radioButton2.Checked)
            {
                conv_num.Font = fivefont;
                conv_res.Font = normalfont;
            }
            else
            {
                conv_num.Font = normalfont;
                conv_res.Font = fivefont;
            }
               

                panel2.Visible = radioButton2.Checked;
        }

        private void sym0_Click( object sender , EventArgs e )
        {
            conv_num.Text += "0";
        }

        private void sym1_Click( object sender , EventArgs e )
        {
            conv_num.Text += "1";
        }

        private void sym2_Click( object sender , EventArgs e )
        {
            conv_num.Text += "2";
        }

        private void sym3_Click( object sender , EventArgs e )
        {
            conv_num.Text += "3";
        }

        private void sym4_Click( object sender , EventArgs e )
        {
            conv_num.Text += "4";
        }
    }
}
