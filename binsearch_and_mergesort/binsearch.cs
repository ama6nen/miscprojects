using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binsearch
{
    class Program
    {

        static int binsteps = 0;

        static int binarysearch( int[ ] array , int num , int min , int max )
        {
            if (min > max)
            {
                Console.WriteLine( "Not found in array" );
                return -1;
            }
            binsteps++;
            int middle = (min + max) / 2;

            if (array[middle] == num)
            {
                Console.WriteLine( "bin search found match with " + binsteps + " steps" );
                return ++num;
            }
            else if (num < array[middle])
            {
                return binarysearch( array , num , min , middle - 1 );
            }
            else
            {
                return binarysearch( array , num , middle + 1 , max );
            }

        }

        static void Main( string[ ] args )
        {
            var array = new int[ 50_000_000 ];   
            int addition = 0;

            for(int i = 0; i < 50_000_000; i++)
            {
                array[ i ] = addition;
                addition++;
            }
            

           Random r = new Random( );
            for(int i= 0; i < 10; i++)
            {
                int random = r.Next( 1 , 50_000_000 );
                binsteps = 0;
                var watch = Stopwatch.StartNew( );
                int index = binarysearch( array , random , 0, array.Length);
                watch.Stop( );
                Console.WriteLine( "Elapsed binary search time " + watch.ElapsedMilliseconds + "ms" );
                
                var elapsedMs = watch.ElapsedMilliseconds;
            }
            Console.ReadKey( );
        }
    }
}
