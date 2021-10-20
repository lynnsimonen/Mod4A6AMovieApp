using System.IO.Enumeration;
using System.Net;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using System.Globalization;
using NLog;
using NLog.Web;

namespace Mod4A6AMovieApp
{
    public class MovieManager : MediaManager
    {
        public List<Movie> Movies { get; set; }
       
        public MovieManager()
        {
            Movies = new List<Movie>();
        }

        public override void ReadCsv()
        {   
            Movie movie = new Movie();
            string movieFile = "movies.csv";
            string moviePath = $"{Environment.CurrentDirectory}/data/{movieFile}";
            StreamReader sr = new StreamReader(moviePath);
            
            if (File.Exists(moviePath))
            {   
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    char[] lineChar = line.ToCharArray();
                    int quote = line.IndexOf('"');


                    if ((quote == -1) && (!(lineChar[0].Equals('i'))))                  //No quotes in title & Not the header line
                    {
                        string[] arr = line.Split(',');
                        movie = new Movie(Int32.Parse(arr[0]), arr[1]); 
                        string[] genresPerMovie = (arr[2]).Split('|'); 
                        movie.Genre = genresPerMovie;
                        Movies.Add(movie);
                    }
                    else if (!(lineChar[0].Equals('i')))                                //Not the header line
                    {                        
                        int mID = Int32.Parse(line.Substring(0,quote-1));    
                        line = line.Remove(0,quote+1);
                        quote = line.IndexOf('"');
                        string mTitle = line.Substring(0,quote);
                        line = line.Remove(0,quote+2);
                        string[] genresPerMovie = (line.Split('|'));                       
                        movie = new Movie(mID, mTitle);
                        movie.Genre = genresPerMovie;
                        Movies.Add(movie);
                    }                       
                }                 
            }
            sr.Close();
        }

        public void Add()
        {            
            //COLLECT NEW MOVIE INFO & DETERMINE IF DUPLICATE OR NOT:
            Logger log = LogManager.GetCurrentClassLogger();
            log.Trace("Logging starts now");
            string newMovieTitle = "";
            string newMovie = "";
            Boolean dup = false;                                   //** NEW MOVIE ID # (FROM MOVIES ARRAY LIST)
            try
            {
                string oops2 = "";                                                          //MAKE SURE NEW MOVIE IS NOT BLANK
                string oops3 = "";                                                          //MAKE SURE MOVIE YEAR IS WITHIN REASON
                do {
                Console.Write("Name of Movie to Add: ");
                newMovie = Console.ReadLine();
                oops2 = (newMovie!="") ? "Y" : "N";
                Console.Write("\nYear Movie was Released (as YYYY): ");
                string movieRelease = Console.ReadLine();
                int theYear = Convert.ToInt32(movieRelease);
                //NEEDS HELP HERE
                oops3 = ((theYear > 1906) || (theYear < 2022)) ? "Y" : "N";
                newMovieTitle = string.Format(newMovie + " (" + movieRelease + ")");        //** NEW MOVIE NAME = NAME + YEAR
                } while ((oops2 != "Y") || (oops3 != "Y"));      
            } 
            catch (Exception e)
            {
                log.Debug(e.StackTrace);
                Console.WriteLine("\nException Note: " + e.Message);
            }

            for (int i = 0; i < Movies.Count - 1; i++)
            {
                string alreadyInList = Movies[i].Title;
                if (alreadyInList.Equals(newMovieTitle))
                {
                    Console.WriteLine("\n" + newMovie + " is already in the Movie Library.");       
                    dup = true;  
                    break;                         
                }                        
            }
            if (!(dup))
            {     
                try {  
                    //ADD NEW MOVIE TO MOVIES ARRAY LIST:
                    Movie movie = new Movie();           
                    int newID = (Movies[Movies.Count-1].Id + 1);  
                    movie = new Movie(newID, newMovieTitle);
                    string listUtility = movie.ListUtility();
                    string[] movieGenres = listUtility.Split('|');
                    movie.Genre = movieGenres;   
                    Movies.Add(movie);
                    string csvMovie = newMovieTitle;
                    int csvNewID = newID;

                    //ADD NEW MOVIE TO CSV FILE:
                    string movieFile = "movies.csv";
                    string moviePath = $"{Environment.CurrentDirectory}/data/{movieFile}";
                    StreamWriter sw = new StreamWriter(moviePath, true);
                    sw.WriteLine($"{csvNewID},{csvMovie},{listUtility}");  
                    sw.Close();
                    log.Info($"Movie {newID} added");
                    System.Console.WriteLine("\nYour movie has been added to the list.\n");
                }
                catch (Exception e)
                {
                    log.Debug(e.StackTrace);
                    Console.WriteLine("\nException Note: " + e.Message);
                }
            }
        }

    }
        
}