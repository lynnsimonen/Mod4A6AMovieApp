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

namespace Mod4A6AMovieApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger log = LogManager.GetCurrentClassLogger();
            log.Trace("Logging starts now");
            
            string libraryOption = "";
            do
            {
                string oops = "";
                do {
                Console.WriteLine("\nWELCOME TO THE MOVIE LIBRARY.  HOW CAN WE HELP YOU?"
                +"\nADD a movie to the movie library"
                + "\nLIST all items in different media categories \nQUIT program");                
                libraryOption = Console.ReadLine().ToUpper();
                //logData.Info("Data: {0}", libraryOption);
                oops = (libraryOption == "ADD" || libraryOption == "QUIT" ||libraryOption == "LIST") ? "Y" : "N";
                } while (oops != "Y");              

                MovieManager movieManager = new MovieManager();
                MovieListUtility movieListUtility = new MovieListUtility();
                Movie movie = new Movie();
                string movieFile = "movies.csv";
                string moviePath = $"{Environment.CurrentDirectory}/data/{movieFile}";
                StreamReader sr = new StreamReader(moviePath);
                sr = new StreamReader(moviePath);      
                string newMovieTitle = "";
                string newMovie = "";
                
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
                            movieManager.Movies.Add(movie);
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
                            movieManager.Movies.Add(movie);
                        }                       
                    } 
                }
                sr.Close();

                if (libraryOption.ToUpper() == "ADD")
                {
                    Boolean dup = false;
                    int newID = (movieManager.Movies[movieManager.Movies.Count-1].Id + 1);
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

                    for (int i = 0; i < movieManager.Movies.Count - 1; i++)
                    {
                        string alreadyInList = movieManager.Movies[i].Title;
                        if (alreadyInList.Equals(newMovieTitle))
                        {
                            Console.WriteLine("\n" + newMovie + " is already in the Movie Library." 
                            + "\n\n" + movieManager.Movies[i]);
                            dup = true;  
                            break;                         
                        }                        
                    }
                    if (!(dup))
                    {     
                        try {    
                        movie = new Movie(newID, newMovieTitle);
                        movie.ListUtility();
                        movieManager.Movies.Add(movie);
                        //HELP HERE!!!
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

                //LIST DIFFERENT MEDIAS
                else if (libraryOption.ToUpper() == "LIST")
                {
                    string mediaChoice = "";
                    string media = ""; 
                    string oops4 = "";
                    do {
                        Console.WriteLine("\nWhich media type would you like listed? SHOW, VIDEO or MOVIE:   ");
                        mediaChoice = Console.ReadLine().ToUpper();
                        oops4 = (mediaChoice == "SHOW" || mediaChoice == "VIDEO" || mediaChoice == "MOVIE") ? "Y" : "N";
                    } while (oops4 != "Y") ;  

                    //media = (mediaChoice == "SHOW") ? "shows.csv" : (media = (mediaChoice == "VIDEO") ? "videos.csv" : "movies.csv");
                    
                    if (mediaChoice == "MOVIE")
                    { 
                        string listMore = "";
                        int start = 0; 
                        do
                        {
                            for (int i = start; i < (start + 5); i++)
                            {
                            Console.WriteLine(movieManager.Movies[i]);
                            }
                            start += 5;
                            string oops5 = "";
                            do {
                            Console.WriteLine("\nWould you like to have more movies listed? Y/N");
                            listMore = Console.ReadLine().ToUpper();
                            oops5 = (listMore == "Y" || listMore == "N") ? "Y" : "N";
                            } while (oops5 != "Y");  
                        } while (!(listMore == "N"));
                    } 
                    else if (mediaChoice == "SHOW")
                        {
                        try 
                            {
                                System.Console.WriteLine("LIST OF SHOWS HERE");
                                ShowManager showManager = new ShowManager();
                                showManager.ReadCsv();
                            }
                        catch(Exception e)
                            {
                            Console.WriteLine("\nException Note: " + e.Message);   
                            }
                        } 
                    else
                    {
                        try 
                        {
                            System.Console.WriteLine("LIST OF VIDEOS HERE");
                            VideoManager videoManager = new VideoManager();
                            videoManager.ReadCsv();
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("\nException Note: " + e.Message);   
                        }
                    } 
                }
            } while (!(libraryOption.ToUpper() == "QUIT"));
        }
    }
}