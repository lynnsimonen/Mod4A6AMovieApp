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
            string newMovie = "";                               //** NEW MOVIE ID # (FROM MOVIES ARRAY LIST)
            try
            {
                string oops2 = "";                              //MAKE SURE NEW MOVIE IS NOT BLANK
                string oops3 = "";                              //MAKE SURE MOVIE YEAR IS WITHIN REASON
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
                string jsonFile = "movies.json";
                string jsonPath = $"{Environment.CurrentDirectory}/data/{jsonFile}";
                string strResultJson = String.Empty;
                strResultJson = System.IO.File.ReadAllText(@jsonPath);         //READ IN JSON FILE (COULD READ IN CSV LIST IF WANT TO WORK WITH ENTIRE LIST)
                List<MovieJSON> resultMovieJSON = JsonConvert.DeserializeObject<List<MovieJSON>>(strResultJson);  //CONVERT JSON FILE TO LIST (TO ALLOW ADD MOVIE)
                int newID = (resultMovieJSON[resultMovieJSON.Count-1].Id + 1);   
                movieJson = new MovieJSON(newID, newMovieTitle);
                string listUtility = movieJson.ListUtility();  //CREATE A STRING COMBINED WITH '|' OF ALL GENRES
                string[] movieGenres = listUtility.Split('|');  //CREATE STRING ARRAY OF ALL GENRES
                movieJson.Genre = movieGenres;                
                resultMovieJSON.Add(movieJson);
               
                //ADD NEW MOVIE TO JSON FILE:    
                var json = JsonConvert.SerializeObject(resultMovieJSON);    //CONVERT/SERIALIZE LIST 
                System.IO.File.WriteAllText(@jsonPath, json);               //WRITE CONVERTED LIST TO JSON FILE
                System.Console.WriteLine("\nYour file has been stored.\n");
                log.Info($"Movie {newID} added");
                new MovieJSON {Id = newID, Title = "newMovieTitle", Genre = movieGenres};
            }
            catch (Exception e)
            {
                log.Debug(e.StackTrace);
                Console.WriteLine("\nException Note: " + e.Message);
            } 
        }
    }
}