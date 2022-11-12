using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZLyricScraperNetFramework
{
    public static class Help
    {
        public static string HelpText = "usage:\t" +
            "AzLyricScraperNetFramework <pathtocsvfile.csv> <pathtodestinationdirectory>\n" +
            "\t-m\tmanual entry\n" +
            "csv format:\n\t" +
            "Title1,Artist1\n\t" +
            "Fly Me To The Moon,Frank Sinatra\n\t" +
            "Title3,Artist3\n\t" +
            "Title4,\n\t" +
            "*Artist field is optional. The Title comma is required";
    }
}
