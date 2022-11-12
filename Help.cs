namespace AZLyricScraperNetFramework
{
    public static class Help
    {
        public static string HelpText = "\nUsage:\t" +
            "AzLyricScraperNetFramework <pathtocsvfile.csv> <pathtodestinationdirectory>\n" +
            "Options:\n" +
            "\t-m\tmanual entry\n" +
            "\t-h\thelp\n" +
            "csv format:\n" +
            "\tHelp,The Beatles\n" +
            "\tFly Me To The Moon,Frank Sinatra\n" +
            "\tThriller,Micheal Jackson\n" +
            "\t<Title>,<Artist optional>\n" +
            "\t*Artist field is optional. The Title comma is required.";
    }
}
