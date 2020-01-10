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

        public class MartingaleInfo
        {
            public long time_elapsed = default;
            public ulong wins = default;
            public ulong losses = default;
            public ulong max_lose_streak = default;
            public ulong max_win_streak = default;
            public ulong max_bet = default;

            public static MartingaleInfo operator +(MartingaleInfo info1, MartingaleInfo info2)
            {
                info1.time_elapsed += info2.time_elapsed;
                info1.wins += info2.wins;
                info1.losses += info2.losses;
                info1.max_lose_streak += info2.max_lose_streak;
                info1.max_win_streak += info2.max_win_streak;
                info1.max_bet += info2.max_bet;
                return info1;
            }

            public static MartingaleInfo operator /(MartingaleInfo info, ulong dividor)
            {
                info.time_elapsed /= (long)dividor;
                info.wins /= dividor;
                info.losses /= dividor; 
                info.max_lose_streak /= dividor;
                info.max_win_streak /= dividor;
                info.max_bet /= dividor;
                return info;
            }
        }

        public static MartingaleInfo RunSimulation(ulong money = 100_000, ulong basebet = 1)
        {
            var info = new MartingaleInfo();

            var watch = new Stopwatch();
            watch.Start();

            var random = new Random();
            ulong current_bet = basebet;
            ulong start_money = money;
            bool won_last = false;
            ulong current_loss_streak = 0;
            ulong current_win_streak = 0;

            ulong multiplier = 2;
            ulong last_multiplier = 0;

            while (money > 0)
            {
                int rand = random.Next(0, 100);
                if (current_bet > info.max_bet)
                    info.max_bet = current_bet;
                

                if(last_multiplier != multiplier && (money / multiplier) > start_money)
                {
                    Console.WriteLine("Funds exceed " + multiplier + " times the initial money!");
                    last_multiplier = multiplier;
                    multiplier++;
                }
                
                if (info.max_bet > money) //not enough money
                    break;

                if (rand >= 50) // win
                {
                    if (won_last)
                        current_win_streak++;
                    else
                    {
                        if (current_loss_streak > info.max_lose_streak)
                        {
                            info.max_lose_streak = current_loss_streak;
                            current_loss_streak = 0;
                        }
                    }
                    info.wins++;
                    money += current_bet;
                    won_last = true;
                    current_bet = basebet;
                }
                else //lose
                {

                    if (won_last)
                    {
                        if (current_win_streak > info.max_win_streak)
                        {
                            info.max_win_streak = current_win_streak;
                            current_win_streak = 0;
                        }
                    }
                    else
                        current_loss_streak++;

                    info.losses++;
                    won_last = false;
                    money -= current_bet;
                    current_bet *= 2;
                }
            }
            watch.Stop();
            info.time_elapsed = watch.ElapsedMilliseconds;
            return info;
        }

        public static MartingaleInfo RunManySimulations(ulong money = 100_000, ulong basebet = 1, ulong samples = 5)
        {
            var info = new MartingaleInfo();
            for (ulong i = 0; i < samples; i++)
            {
                Console.WriteLine("Running simulation n" + i);
                info += RunSimulation(money, basebet);
            }
                
            Console.WriteLine("total time elapsed (not average): " + info.time_elapsed);
            info /= samples;
            return info;
        }
        static void Main(string[] args)
        {
            var result = RunManySimulations(300_000, 1, 10);
            Console.WriteLine("[AVERAGES]");
            Console.WriteLine("time elapsed in ms: " + result.time_elapsed);
            Console.WriteLine("total wins: " + result.wins);
            Console.WriteLine("total losses: " + result.losses);
            Console.WriteLine("biggest losing streak: " + result.max_lose_streak);
            Console.WriteLine("biggest winning streak: " + result.max_win_streak);
            Console.WriteLine("max bet: " + result.max_bet);
            Console.ReadKey();
        }
    }
}
