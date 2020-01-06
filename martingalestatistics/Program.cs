using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace martingale_statistics
{
    class Program
    {
        static void Main( string[ ] args )
        {
           ulong[] asd()
            {


                ulong money = 1_000_00; // 100k 
                ulong basebet = 1;

             
                    
                ulong losestreak = 0;
                ulong currentbet = basebet;
                ulong maxbet = 0;
                ulong winstreak = 0;
                Random random = new Random( );
                ulong losses = 0;
                ulong wins = 0;
                bool didWinLast = false;
                ulong currlose = 0;
                ulong currwin = 0;
                Stopwatch watch = new Stopwatch( );
                watch.Start( );
                while (money > 0)
                {
                    int rand = random.Next( 0 , 100 );
                    if (money > 1_500_000)
                        Console.WriteLine( "more" );

                        if (currentbet > maxbet)
                    {
                        //  Console.WriteLine( "new biggest bet " + currentbet );
                        maxbet = currentbet;
                    }

                    if (maxbet > money)
                    {
                        //  Console.WriteLine( "h" );
                        break;
                    }


                    if (rand >= 50) // win
                    {

                        if (didWinLast)
                            currwin++;
                        else
                        {
                            if (currlose > losestreak)
                            {
                                //         Console.WriteLine( "new max lose streak " + currlose );
                                losestreak = currlose;
                                currlose = 0;
                            }
                        }
                        wins++;
                        money += currentbet;
                        didWinLast = true;
                        currentbet = 1;
                    }
                    else //lose
                    {

                        if (didWinLast)
                        {
                            if (currwin > winstreak)
                            {
                                //      Console.WriteLine( "new max win streak " + currwin );
                                winstreak = currwin;
                                currwin = 0;
                            }
                        }
                        else
                            currlose++;


                        losses++;
                        didWinLast = false;
                        money -= currentbet;
                        currentbet *= 2;
                    }
                }

                watch.Stop( );
                //Console.WriteLine( "time elapsed in ms  " + watch.ElapsedMilliseconds );
                //Console.WriteLine( "out of money!" );
                //Console.WriteLine( "total wins " + wins );
                //Console.WriteLine( "total losses " + losses );
                //Console.WriteLine( "biggest losing streak " + losestreak );
                //Console.WriteLine( "biggest winning streak " + winstreak );
                //Console.WriteLine( "max bet " + maxbet );

                return new ulong [ ]{ (ulong)watch.ElapsedMilliseconds, wins, losses, losestreak, winstreak, maxbet};
                //   Console.ReadKey( );
            }
            double elapsed2 = 0;
            double wins2 = 0;
            double losses2 = 0;
            double losestreak2 = 0;
            double winstreak2 = 0;
            double maxbet2 = 0;
            var b = asd( );
            elapsed2 = (elapsed2 + b[ 0 ]) / 2d;
            wins2 = (wins2 + b[ 1 ]) / 2d;
            losses2 = (losses2 + b[ 2 ]) / 2d;
            losestreak2 = (losestreak2 + b[ 3 ]) / 2d;
            winstreak2 = (winstreak2 + b[ 4 ]) / 2d;
            maxbet2 = (maxbet2 + b[ 5 ]) / 2d;
            for (int i =0; i < 1; i++)
            {
                var a = asd( );
                elapsed2 = (elapsed2 + a[ 0]) / 2d;
                wins2 = (wins2 + a[ 1 ]) / 2d;
                losses2 = (losses2 + a[ 2 ]) / 2d;
                losestreak2 = (losestreak2 + a[ 3 ]) / 2d;
                winstreak2 = (winstreak2 + a[ 4 ]) / 2d;
                maxbet2 = (maxbet2 + a[ 5]) / 2d;


            }

            Console.WriteLine( "[AVERAGES]" );
            Console.WriteLine( "time elapsed in ms  " + elapsed2 );
            Console.WriteLine( "total wins " + wins2 );
            Console.WriteLine( "total losses " + losses2 );
            Console.WriteLine( "biggest losing streak " + losestreak2 );
            Console.WriteLine( "biggest winning streak " + winstreak2 );
            Console.WriteLine( "max bet " + maxbet2 );
            Console.ReadKey( );


        }
    }
}
