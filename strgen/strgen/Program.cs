using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strgen
{
    class Program
    {
        static string ValidChars = "abc0123456789";
        static int atpos = 0;
        static int position = 0;
        static string prefix = "";
        static string last = "";
        public static string random
        {
            get
            {
                if (position >= ValidChars.Length)
                {
                    if (atpos >= ValidChars.Length)
                    {

                        var chars = last.ToCharArray().ToList();
                        for (int i = 0; i < chars.Count; i++)
                        {
                            var c = chars[i];

                            if ((ValidChars.IndexOf(c) + 1) == ValidChars.Length)
                            {
                                if ((i - 1) >= 0)
                                {
                                    var cc = chars[i - 1];
                                    chars[i - 1] = ValidChars[ValidChars.IndexOf(cc) + 1];
                                    chars[i] = ValidChars[0];
                                    break;
                                }
                                else
                                {
                                    if ((i + 1) < chars.Count)
                                    {
                                        var cc = chars[i + 1];
                                        if ((ValidChars.IndexOf(cc) + 1) == ValidChars.Length)
                                        {
                                            chars[i] = ValidChars[0];
                                            chars.Insert(0, ValidChars[0]);
                                        }
                                        else
                                        {
                                            chars[i + 1] = ValidChars[ValidChars.IndexOf(cc) + 1];
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        chars[i] = ValidChars[0];
                                        chars.Insert(0, ValidChars[0]);
                                    }

                                    break;
                                }
                            }
                        }

                        string next = "";
                        foreach (var cc in chars)
                            next += cc;

                        atpos = 0;
                        prefix = next.Remove(next.Length - 1, 1);

                    }
                    else
                    {
                        var chars = last.ToCharArray().ToList();
                        for (int i = 0; i < chars.Count; i++)
                        {
                            var c = chars[i];
                            if ((ValidChars.IndexOf(c) + 1) == ValidChars.Length)
                            {
                                if ((i - 1) >= 0)
                                {
                                    var cc = chars[i - 1];
                                    chars[i - 1] = ValidChars[ValidChars.IndexOf(cc) + 1];
                                    chars[i] = ValidChars[0];
                                    break;
                                }
                                else
                                {
                                    chars[i] = ValidChars[0];
                                    chars.Insert(0, ValidChars[0]);
                                    break;
                                }
                            }
                        }

                        string next = "";
                        foreach (var cc in chars)
                            next += cc;

                        prefix = next.Remove(next.Length - 1, 1);
                    }
                    atpos++;
                    position = 0;
                }

                string gen = prefix + ValidChars[position];
                position++;
                last = gen;
                return gen;
            }
        }

        static void Main(string[] args)
        {
            while (true)
                Console.WriteLine(random);     
        }
    }
}
