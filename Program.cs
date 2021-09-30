using System.IO.Enumeration;
using System.Net;
using System;
//using NLogBuilder;  --- NLog was getting Compiler Error CS0234
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using System.Globalization;

namespace Mod4A6AMovieApp
{
    class Program
    {

        static void Main(string[] args)
        {

            // //CsvHelper Errors: CS8803, CS1022
            // public static System.Globalization.CultureInfo InvariantCulture { get; }
            
            // using (var streamReader = new StreamReader(@"D:\2021_Fall_dotNet\Git_Repos\Mod4A6AMovieApp\Data.movies.csv")) 
            //     {
            //         using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            //         {
            //             var records = csvReader.GetRecords<dynamic>().ToList;
            //         }
            //     }

            //NLOG HAS COMPILE ERROR CS1529, CS0234--  NEED TO FIX THIS so same as last computer
            //Setup Logger...
            //var logData = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            //Initial Logging...
            //logData.Info("Program started");

            string movieFile = "movies.csv";

            movieFile = $"{ Environment.CurrentDirectory}/data/movies.csv";
            StreamReader sr = new StreamReader(movieFile);

            MovieManager movieManager = new MovieManager();
            MovieListUtility movieListUtility = new MovieListUtility();

            Movie movie = new Movie();
            string libraryOption = "";
            do
            {
                Console.WriteLine("");
                Console.WriteLine("WELCOME TO THE MOVIE LIBRARY.  HOW CAN WE HELP YOU?");
                Console.WriteLine("ADD a movie");
                Console.WriteLine("LIST all movies");
                Console.WriteLine("QUIT program");

                try
                {
                    libraryOption = Console.ReadLine().ToUpper();
                    //logData.Info("Data: {0}", libraryOption);
                }
                catch (Exception e)
                {
                    //TODO LOGGING HERE!
                    Console.WriteLine(e.Message);
                    //logData.Info(e.Message);
                    //logData.Info(e.StackTrace);
                }
                string newMovieTitle = "";
                string newMovie = "";
                
                if (File.Exists(movieFile))
                {
                   
                    sr = new StreamReader(movieFile);
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] arr = line.Split(',');
                        if (arr[1].Contains("\""))
                        {
                            arr[1] = arr[1].Replace("\"", "");
                            arr[1] = arr[1].Replace("\"", "");
                        }
                        if (arr[0] != "movieId")
                        {
                            movie = new Movie(Int32.Parse(arr[0]), arr[1]);
                            movie.Genre = arr[2];
                            movieManager.Movies.Add(movie);
                        }
                    }
                     sr.Close();
                }

                if (libraryOption.ToUpper() == "ADD")
                {
                    Console.Write("Name of Movie to Add: ");
                     //newID = movie.Count();
                     System.Console.WriteLine();
                    newMovie = Console.ReadLine();
                    Console.Write("Year Movie was Released: ");
                    string movieRelease = Console.ReadLine();
                    newMovieTitle = string.Format(newMovie + " (" + movieRelease + ")");
                    Boolean dup = false;

                    for (int i = 0; i < movieManager.Movies.Count - 1; i++)
                    {
                        string movieListmovie = movieManager.Movies[i].MovieTitle;

                        if (movieListmovie.Equals(newMovieTitle))
                        {
                            Console.WriteLine(newMovie + " is already in the Movie Library.");
                            Console.WriteLine(movieManager.Movies[i].MovieID);
                            Console.WriteLine(movieManager.Movies[i].MovieTitle);
                            Console.WriteLine(movieManager.Movies[i].Genre);
                            dup = true;
                            break;
                        }
                    }
                    if (!(dup))
                    {
                        //int newID = movie.Count;
                        //int newID = movieManager.Movies[movieManager.Movies.Count - 1].MovieID + 1;
                        //sr.Close();
                        
                        //Movie movie = new Movie(newID, newMovieTitle);
                        // StreamWriter sw = new StreamWriter(movieFile);                                              
                        // sw.WriteLine("{0},{1},{2}",newID,newMovieTitle,movie.Genre);                        
                        // sw.Close();
                    }
                    Console.WriteLine("");
                }

                //------------------------------------------------------------------

                else if (libraryOption.ToUpper() == "LIST")
                {
                    string listMore = "";
                    int start = 0;
                    do
                    {
                        for (int i = start; i < (start + 25); i++)
                        {
                          Console.WriteLine(movieManager.Movies[i]);
                        }
                        start += 25;
                        Console.WriteLine("Would you like to have more movies listed? Y/N");
                        listMore = Console.ReadLine().ToUpper();
                    } while (!(listMore == "N"));

                    Console.WriteLine("");
                }
            } while (!(libraryOption.ToUpper() == "QUIT"));
        }
    }
}