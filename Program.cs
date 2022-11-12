﻿using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AZLyricScraperNetFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DEBUG ARGS
            //args = new[] { @"C:\Users\kbass\Desktop\songstoscrape.csv", @"C:\Users\kbass\source\repos\AZLyricScraperNetFramework\bin\Debug\Files6\" };
        
            //check args
            if (args.Length < 2)
            {
                Console.WriteLine(Help.HelpText);
                return;
            }
            if (Directory.Exists(args[1]) == false)
            {
                Directory.CreateDirectory(args[1]);
            }
            if (File.Exists(args[0]) == false)
            {
                Console.WriteLine("csv file not found\n");
                Console.WriteLine(Help.HelpText);
                return;
            }
            //process csv  
            var readLines = File.ReadAllLines(args[0]);
            foreach (var line in readLines)
            {
                var fields = line.Split(',');
                try
                {
                    string songtitle = fields[0];
                    string artist = fields[1];
                    //Skip if file exists
                    if (File.Exists($"{args[1]}\\{songtitle} - {artist}.pdf") == false)
                    {
                        Regex rgx = new Regex(" featuring ");
                        if (rgx.IsMatch(fields[1]) == true)
                        {
                            var temp = fields[1].Split(Statics.stringSeparators3, StringSplitOptions.None);
                            fields[1] = temp[0].Trim();
                            Console.WriteLine(fields[1]);
                        }

                        Task<string> task = LyricScraper.GetUrl(songtitle, artist);
                        task.Wait(3000);

                        Task<string> task2 = LyricScraper.GetHtml(task.Result, songtitle, artist, args[1]);
                        task2.Wait(3000);

                        LyricScraper.Html2Pdf(task2.Result, songtitle, artist, args[1]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }        
    }
}