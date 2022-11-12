using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AZLyricScraperNetFramework
{
    public class Banned
    {
        public static void WaitForBanExpiration()
        {
            Statics.q++;
            if (Statics.q > 0)
            {
                int timer = 1800000;
                int dot = 0;
                Console.WriteLine("Too Many Requests... please wait...");
                Console.Write($"{(timer / 60000)} minutes remaining");
                Console.SetCursorPosition(0, Console.CursorTop);
                while (timer > 0)
                {
                    Thread.Sleep(2000);
                    timer = timer - 2000;

                    if (dot == 0)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.Write("                                                                                   ");
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.Write($"{(timer / 60000)} minutes remaining");
                    }
                    dot++;
                    Console.Write(".");
                    if (dot == 30)
                    {
                        dot = 0;
                        //Console.Write("\n");
                    }
                };
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write("                                                                                   \n");
                Statics.q = 0;
            }
            //return string.Empty;
        }
    }
    
}
