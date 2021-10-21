using System.IO.Enumeration;
using System.Net;
using System;
using NLog;
using NLog.Web;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mod4A6AMovieApp
{
    public class MovieManagerJSON : MediaManager

    {
        public List<MovieJSON> MoviesJson { get; set; }
       
        public MovieManagerJSON()
        {
            MoviesJson = new List<MovieJSON>();
        }
        
        public override void Add()
         {
            //COLLECT NEW MOVIE INFO & DETERMINE IF DUPLICATE OR NOT:
            Logger log = LogManager.GetCurrentClassLogger();
            log.Trace("Logging in MovieManagerJSON.cs starts now");
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
 
            try 
            {  
                //ADD NEW MOVIE TO MOVIES ARRAY LIST:  
                MovieJSON movieJson = new MovieJSON();                         
                //int newID = (Movies[Movies.Count-1].Id + 1);  
                int newID = 3;
                movieJson = new MovieJSON(newID, newMovieTitle);
                string listUtility = movieJson.ListUtility();
                string[] movieGenres = listUtility.Split('|');
                movieJson.Genre = movieGenres;   
                MoviesJson.Add(movieJson);

                //ADD NEW MOVIE TO JSON FILE:       
                string movieFile = "movies.csv";
                string moviePath = $"{Environment.CurrentDirectory}/data/{movieFile}";
                movieJson.Id = newID;
                movieJson.Title = newMovieTitle;
                movieJson.Genre = movieGenres;              
                string strResultJson = JsonConvert.SerializeObject(movieJson);




                // StreamWriter sw = new StreamWriter(moviePath, true);
                // sw.WriteLine($"{csvNewID},{csvMovie},{listUtility}");  
                // sw.Close();
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