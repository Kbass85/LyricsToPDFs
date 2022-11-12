using System.Text.RegularExpressions;

namespace AZLyricScraperNetFramework
{
    public class Statics
    {
        public static string[] user_agent_list = {
                                        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_5) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.1.1 Safari/605.1.15",
                                        "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:77.0) Gecko/20100101 Firefox/77.0",
                                        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_5) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36",
                                        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.15; rv:77.0) Gecko/20100101 Firefox/77.0",
                                        "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36" };

        public static int q = 0;
        public static string queryString = "https://www.google.com/search?q=site%3Aazlyrics.com";
        public static Regex regex = new Regex(@"<title>AZLyrics - request for access</title>");
        public static Regex regex2 = new Regex(@"^https://www.azlyrics.com/lyrics/");
        public static string[] stringSeparators1 = new string[] { "a href=\"" };
        public static string[] stringSeparators2 = new string[] { "\"" };
        public static string[] stringSeparators3 = new string[] { " featuring " };
    }
}
