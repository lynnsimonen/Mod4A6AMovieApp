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

                //ADD MOVIE TO MOVIES.CSV
                if (libraryOption.ToUpper() == "ADD")
                {
                    MovieManager movieManager = new MovieManager(); 
                    movieManager.ReadFile();
                    movieManager.Add();
                }

                //LIST DIFFERENT MEDIAS
                else if (libraryOption.ToUpper() == "LIST")
                {
                    string mediaChoice = "";
                    string oops4 = "";
                    do {
                        Console.WriteLine("\nWhich media type would you like listed? SHOW, VIDEO or MOVIE:   ");
                        mediaChoice = Console.ReadLine().ToUpper();
                        oops4 = (mediaChoice == "SHOW" || mediaChoice == "VIDEO" || mediaChoice == "MOVIE") ? "Y" : "N";
                    } while (oops4 != "Y") ;  

                   //----------------------------------------------------

                   
                    if (mediaChoice == "MOVIE")
                    {
                    try 
                        {
                            IMedia media = new MovieJSON(); 
                            media.Display();
                        }
                    catch(Exception e)
                        {
                        Console.WriteLine("\nException Note: " + e.Message);   
                        }
                    } 
                   
                    //--------------------------------------
                    // if (mediaChoice == "MOVIE")
                    // {
                    // try 
                    //     {
                    //         MediaManager mediaManager = new MovieManager(); 
                    //         IMedia media = new Movie();
                    //         media.Display();
                    //     }
                    // catch(Exception e)
                    //     {
                    //     Console.WriteLine("\nException Note: " + e.Message);   
                    //     }
                    // } 
                    //--------------------------------------
                    else if (mediaChoice == "SHOW")
                        {
                        try 
                            {
                                MediaManager mediaManager = new ShowManager();
                                IMedia media = new Show();
                                media.Display();
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
                            MediaManager mediaManager = new VideoManager();
                            IMedia media = new Video();
                            media.Display();
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