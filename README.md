# LyricsToPDFs
LyricsToPDFs is a commandline tool for scraping and formatting song lyrics straight to pdf. Scrape a batch of songs by inputing a CSV of {songtitle},{artist/optional}.
The {artist} value is optional. The "," after {songtitle} is required.
*The scraper may not find your song.

Usage:

     AzLyricScraperNetFramework <pathtocsvfile.csv> <pathtodestinationdirectory>
     
     Options:
     
     -m manual entry
     
     -h help
     
     csv format:
     
           Help,The Beatles
           
           Fly Me To The Moon,Frank Sinatra
           
           Thriller,Micheal Jackson
           
           <Title>,<Artist optional>
           
      *Artist field is optional. The Title and comma are required.
