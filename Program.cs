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
            MovieListUtility movieListUtility = new MovieListUtility();
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
                movieManager.ReadCsv();
                if (libraryOption.ToUpper() == "ADD")
                {
                    movieManager.Add();

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
                    
                    if (mediaChoice == "MOVIE")
                    { 
                       Movie movie = new Movie();
                       movie.Display();
                    } 
                    else if (mediaChoice == "SHOW")
                        {
                        try 
                            {
                                ShowManager showManager = new ShowManager();
                                showManager.ReadCsv();
                                Show show = new Show();
                                show.Display();
                            }
                        catch(Exception e)
                            {
                            Console.WriteLine("\nException Note: " + e.Message);   
                            }
                        } 
                    else if (mediaChoice == "VIDEO")
                    {
                        try 
                        {
                            VideoManager videoManager = new VideoManager();
                            videoManager.ReadCsv();
                            Video video = new Video();
                            video.Display();
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