using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace morse
{
    public partial class mainform : Form
    {

//        short mark, dot or "dit" (▄▄▄▄): "dot duration" is one time unit long
//longer mark, dash or "dah" (▄▄▄▄▄▄): three time units long
//inter-element gap between the dots and dashes within a character: one dot duration or one unit long
//short gap( between letters ): three time units long
// medium gap( between words ) : seven time units long

        public static char[ ] dots = ".*•".ToCharArray( );
        public static char[ ] dashes = "-_−".ToCharArray( );
        public static char[ ] validalphabet = "QWERTYUIOPASDFGHJKLZXCVBNM0123456789 ".ToCharArray( );
        public static Dictionary<string , string> conv_table = new Dictionary<string , string>( )
        { //normal, morse
            { "A", ".-" },
            { "B", "-..." },
            { "C", "-.-." },
            { "D", "-.." },
            { "E", "." },
            { "F", "..-." },
            { "G", "--." },
            { "H", "...." },
            { "I", ".." },
            { "J", ".---" },
            { "K", "-.-" },
            { "L", ".-.." },
            { "M", "--" },
            { "N", "-." },
            { "O", "---" },
            { "P", ".--." },
            { "Q", "--.-" },
            { "R", ".-." },
            { "S", "..." },
            { "T", "-" },
            { "U", "..-" },
            { "V", "...-" },
            { "W", ".--" },
            { "X", "-..-" },
            { "Y", "-.--" },
            { "Z", "--.." },
            { "1", ".----" },
            { "2", "..---" },
            { "3", "...--" },
            { "4", "....-" },
            { "5", "....." },
            { "6", "-...." },
            { "7", "--..." },
            { "8", "---.." },
            { "9", "----." },
            { "0", "-----" },
        };


        public mainform()
        {
            InitializeComponent( );
        }

        int ismorse(char c )
        {
            return dots.Contains( c ) ? 0 : (dashes.Contains( c ) ? 1 : -1);
        }

        bool ismorse(string s )
        {
         
            foreach(char c in s.ToCharArray( ))
            {
                int a = ismorse( c );
                if (a == -1)
                {
                    if (c == ' ' || c == '/' || c == '|')
                        continue;
                } else continue;

                return false;
            }
            return true;
        }

        bool istext(string text )
        {
            foreach (var c in text.ToUpperInvariant( ).ToCharArray( ))
                if (!validalphabet.Contains( c ))
                    return false;

            return true;
        }
        string oldtext = "";
        private void textBox1_TextChanged( object sender , EventArgs e )
        {
            var txt = (sender as TextBox);
            if (!ismorse( txt.Text ))
            {
                txt.Text = oldtext;
                txt.SelectionStart = txt.TextLength;
            }
            else
                oldtext = txt.Text;
        }


        string totext(string morse )
        {
            if (!ismorse( morse ))
                return "";
			//TODO: implement
            return "";
        }

        string tomorse(string text )
        {
            if (!istext( text ))
                return "";

            string ret = "";
            foreach (char ch in text.ToUpperInvariant( ).ToCharArray( ))
            {
                if (ch == ' ')
                {
                    ret += checkBox1.Checked ? "   " : "|";
                    continue;
                }
                else
                {
                    bool a = conv_table.TryGetValue( ch.ToString( ) , out string converted );
                    if (a)
                        ret += converted + " ";
                }
            }
            return ret;
        }


        private void button1_Click( object sender , EventArgs e ) => textBox2.Text = totext( textBox1.Text );
        private void button2_Click( object sender , EventArgs e ) => textBox1.Text = tomorse( textBox2.Text );

    }
}
