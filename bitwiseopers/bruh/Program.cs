using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitwiseopers
{
    class Program
    {
        //https://i.imgur.com/JkThIMU.png
        static long AND(uint a, uint b)
        {
            long memes = 0;
            for(int n = 0; n <= Math.Log(a, 2); n++)
            {
                var pow2n = (long)Math.Pow(2, n);
                memes += pow2n * (a / pow2n % 2) * (b / pow2n % 2);
            }

            return memes;
        }
        static long OR(uint a, uint b)
        {
            long memes = 0;
            for (int n = 0; n <= Math.Log(a, 2); n++)
            {
                var pow2n = (long)Math.Pow(2, n);
                memes += pow2n *  ( ( a / pow2n % 2 + b / pow2n % 2 + a / pow2n % 2 * b / pow2n % 2) % 2);
            }

            return memes;
        }
        static long XOR(uint a, uint b)
        {
            long memes = 0;
            for (int n = 0; n <= Math.Log(a, 2); n++)
            {
                var pow2n = (long)Math.Pow(2, n);
                memes += pow2n * ( ( a / pow2n + b / pow2n) % 2);
            }

            return memes;
        }
        static void Main(string[] args)
        {

            Console.WriteLine("bitwise and, xor, or implementation\npress q to quit.");
            var r = new Random();
            do
            {
                uint a = Convert.ToUInt32(r.Next(500, 1000));
                uint b = Convert.ToUInt32(r.Next(1, 500));
                Console.WriteLine($"AND: {a}, {b} = {AND(a, b)}  |  {a} & {b} = {a & b}");
                Console.WriteLine($"OR: {a}, {b} = {OR(a, b)}    |  {a} | {b} = {a | b}");
                Console.WriteLine($"XOR: {a}, {b} = {XOR(a, b)}  |  {a} ^ {b} = {a ^ b}");
            }
            while (Console.ReadKey().KeyChar != 'q');
        }
    }
}
