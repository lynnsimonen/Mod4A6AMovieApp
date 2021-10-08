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
            sr = new StreamReader(moviePath);      
            
            if (File.Exists(moviePath))
            {   
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] arr = line.Split(',');
                    int quote = line.IndexOf('"');

                    if ((quote == -1) && (arr[0] != "iD"))
                    {
                        arr = line.Split(',');
                        movie = new Movie(Int32.Parse(arr[0]), arr[1]);                            
                        movie.Genre = arr[2];
                        Movies.Add(movie);
                    }
                    else if (arr[0] != "iD")
                    {
                        //Count '"' in line before this step:
                        int mID = Int32.Parse(line.Substring(0,quote-1));
                        line = line.Substring(quote + 1);
                        quote = line.IndexOf('"');
                        string mTitle = line.Substring(0,quote);
                        movie = new Movie(mID, mTitle);
                        line = line.Substring(quote + 2);
                        movie.Genre = line;
                        Movies.Add(movie);
                    }                       
                } 
            }
            sr.Close();
        }

        public void Add()
        {
            Logger log = LogManager.GetCurrentClassLogger();
            log.Trace("Logging starts now");
            string newMovieTitle = "";
            string newMovie = "";
            Boolean dup = false;
            int newID = (Movies[Movies.Count-1].Id + 1);
            try
            {
                string oops2 = "";
                string oops3 = "";
                do {
                Console.Write("Name of Movie to Add: ");
                newMovie = Console.ReadLine();
                oops2 = (newMovie!="") ? "Y" : "N";
                Console.Write("\nYear Movie was Released (as YYYY): ");
                string movieRelease = Console.ReadLine();
                int theYear = Convert.ToInt32(movieRelease);
                //NEEDS HELP HERE
                oops3 = ((theYear > 1906) || (theYear < 2022)) ? "Y" : "N";
                newMovieTitle = string.Format(newMovie + " (" + movieRelease + ")");
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
                    Console.WriteLine("\n" + newMovie + " is already in the Movie Library.");       //+ "\n\n" +Movies[i]
                    dup = true;  
                    break;                         
                }                        
            }
            if (!(dup))
            {     
                try {  
                    Movie movie = new Movie(); 
                    movie = new Movie(newID, newMovieTitle);
                    movie.ListUtility();
                    Movies.Add(movie);
                    //HELP HERE!!!
                    
                    string movieFile = "movies.csv";
                    string moviePath = $"{Environment.CurrentDirectory}/data/{movieFile}";
                    StreamWriter sw = new StreamWriter(moviePath, true);
                    sw.WriteLine($"{newID}, {movie}, {movie.Genre}");   // Won't append
                    sw.Close();
                    log.Info($"Movie {newID} added");
                    System.Console.WriteLine("\nYour movie has been added to the list.");
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