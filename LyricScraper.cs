using PdfSharp.Pdf;
using PdfSharp;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace AZLyricScraperNetFramework
{
    public static class LyricScraper
    {
        public static async Task<string> GetUrl(string songtitle,string artist)
        {
            try
            {
                //construct and send request
                var queryString = Statics.queryString + "+" + "\"" + songtitle + "\"" + "+" + "\"" + artist + "\"";
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("User-Agent", Statics.user_agent_list[0]);
                var response = await httpClient.GetAsync(queryString);
                while (response.IsSuccessStatusCode != true)
                {
                    Console.Write("\n" + response.StatusCode.ToString() + " Error: ");
                    Banned.WaitForBanExpiration();
                    response = await httpClient.GetAsync(queryString);
                }
                //filter out and return url
                string responseBody = await response.Content.ReadAsStringAsync();
                var filter1 = responseBody.Split(Statics.stringSeparators1, StringSplitOptions.None);
                string[] filter2 = null;
                foreach (var split in filter1)
                {
                    if (Statics.regex2.IsMatch(split) == true)
                    {
                        filter2 = split.Split(Statics.stringSeparators2, StringSplitOptions.None);
                        break;
                    }
                }
                string azUrl = string.Empty;
                if (filter2 != null)
                {
                    azUrl = filter2[0];
                    Console.WriteLine(azUrl);
                    return azUrl;
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Thread.Sleep(1000);
                return string.Empty;
            }
        }
        public static async Task<string> GetHtml(string url, string songtitle,string artist,string pdffilepath)
        {
            try
            {
                //load url for parsing
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("User-Agent", Statics.user_agent_list[0]);
                var response = await httpClient.GetAsync(url);
                string responseBody = await response.Content.ReadAsStringAsync();
                //try not to get banned
                if (Statics.regex.IsMatch(responseBody) == true)
                {
                    Console.WriteLine($"Go To {url} and click not a robot");
                    Console.WriteLine($"Keypress to continue...");
                    Console.ReadKey();
                }
                //Format HTML
                string[] stringSeparators = new string[] { "<!-- Usage of azlyrics.com content by any third-party lyrics provider is prohibited by our licensing agreement. Sorry about that. -->" };
                var splitResponse = responseBody.Split(stringSeparators, StringSplitOptions.None);
                string[] stringSeparators2 = new string[] { "</div>" };
                var splitResponse2 = splitResponse[1].Split(stringSeparators2, StringSplitOptions.None);            
                var htmlSource = "<center><h1>" + songtitle + " - " + artist + "<br><br>" + splitResponse2[0] + "</h1></center>";
                Thread.Sleep(1500);
                return htmlSource;              
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                Thread.Sleep(1500);
                return String.Empty;
            }
        }
        public static void Html2Pdf(string html, string songtitle, string artist, string path)
        {
            PdfDocument pdf = PdfGenerator.GeneratePdf(html, PageSize.A4, 13, null, null, null);
            if (artist == string.Empty)
            {
                pdf.Save(path + @"\" + songtitle+".pdf");
            }
            else
            {
                pdf.Save(path + @"\" + songtitle + " - " + artist + ".pdf");
            }          
        }
    }
}
