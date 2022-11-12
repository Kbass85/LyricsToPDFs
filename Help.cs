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
            "\tTitle1,Artist1\n" +
            "\tFly Me To The Moon,Frank Sinatra\n" +
            "\tTitle3,Artist3\n" +
            "\tTitle4,<optional>\n" +
            "\t*Artist field is optional. The Title comma is required";
    }
}
