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
            string libraryOption = "";
            do
            {
                Console.WriteLine("\nWELCOME TO THE MOVIE LIBRARY.  HOW CAN WE HELP YOU?"
                +"\nADD a movie to the movie library"
                + "\nLIST all items in differnt media categories \nQUIT program");

                try
                {
                    libraryOption = Console.ReadLine().ToUpper();
                    //logData.Info("Data: {0}", libraryOption);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    //logData.Info(e.StackTrace);
                }

                //READ MOVIE.CSV TO ARRAY
                string movieFile = "movies.csv";
                movieFile = $"{ Environment.CurrentDirectory}/data/{movieFile}";
                StreamReader sr = new StreamReader(movieFile);
                MovieManager movieManager = new MovieManager();
                MovieListUtility movieListUtility = new MovieListUtility();
                Movie movie = new Movie();

                string newMovieTitle = "";
                string newMovie = "";
                
                if (File.Exists(movieFile))
                {                   
                    sr = new StreamReader(movieFile);
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] arr = line.Split(',');
                        int quote = line.IndexOf('"');

                        if ((quote == -1) && (arr[0] != "movieId"))
                        {
                            arr = line.Split(',');
                            movie = new Movie(Int32.Parse(arr[0]), arr[1]);
                            movie.Genre = arr[2];
                            movieManager.Movies.Add(movie);
                        }
                        else if (arr[0] != "movieId")
                        {
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
                     sr.Close();
                     System.Console.WriteLine(movieManager.Movies[9124]);                                   //TEST
                     System.Console.WriteLine(movieManager.Movies[movieManager.Movies.Count - 1].MovieID);  //TEST
                }

                //ADD NEW MOVIE TO CSV FILE
                if (libraryOption.ToUpper() == "ADD")
                {
                    Console.Write("Name of Movie to Add: ");
                    newMovie = Console.ReadLine();
                    int newID = (movieManager.Movies[movieManager.Movies.Count-1].MovieID + 1);
                    Console.Write("\nYear Movie was Released: ");
                    string movieRelease = Console.ReadLine();
                    newMovieTitle = string.Format(newMovie + " (" + movieRelease + ")");
                    Boolean dup = false;

                    for (int i = 0; i < movieManager.Movies.Count - 1; i++)
                    {
                        string movieListmovie = movieManager.Movies[i].MovieTitle;

                        if (movieListmovie.Equals(newMovieTitle))
                        {
                            Console.WriteLine("\n" + newMovie + " is already in the Movie Library." 
                            + "\n\n" + movieManager.Movies[i]);
                            dup = true;                           
                        }
                         break;
                    }
                    if (!(dup))
                    {                       
                       movie = new Movie(newID, newMovieTitle);
                       movieManager.Movies.Add(movie);
                       System.Console.WriteLine(new Movie(newID, newMovieTitle));    //TEST
                       string newM = ($"{newID}, {newMovie} ({movieRelease})"); 

                       StreamWriter sw = new StreamWriter(($"{ Environment.CurrentDirectory}/data/movies.csv"), true);
                       sw.WriteLine($"{newID}, {newMovie} ({movieRelease})");
                       sw.Close();
                       movieManager.Movies.Add(movie);
                       //logger.Info($"Movie {newID} added");
                        System.Console.WriteLine("\nYour movie has been added to the list.");
                    }
                }

                //LIST DIFFERENT MEDIAS
                else if (libraryOption.ToUpper() == "LIST")
                {
                    string mediaChoice = "";
                    string media = ""; 
                    try
                    {
                        Console.WriteLine("\nWhich media type would you like listed? SHOW, VIDEO or MOVIE:   ");
                        mediaChoice = Console.ReadLine().ToUpper(); 
                    }
                    catch (System.Exception)
                    {
                        //if mediaChoice doesn't equal show, video or movie, exception brings to beginning (or while loop?)
                        throw;
                    }      

                    media = (mediaChoice == "SHOW") ? "shows.csv" : (media = (mediaChoice == "VIDEO") ? "videos.csv" : "movies.csv");
                    //--------------------------------------------------------------
                    string listMore = "";
                    int start = 0;
                    if (mediaChoice == "MOVIE")
                    {
                        // movies m = new movies();
                        // m.MList();
                        do
                        {
                            for (int i = start; i < (start + 5); i++)
                            {
                            Console.WriteLine(movieManager.Movies[i]);
                            }
                            start += 5;
                            Console.WriteLine("\nWould you like to have more movies listed? Y/N");
                            listMore = Console.ReadLine().ToUpper();
                        } while (!(listMore == "N"));
                    } else if (mediaChoice == "SHOW")
                    {

                    } else
                    {

                    }

                }
            } while (!(libraryOption.ToUpper() == "QUIT"));
        }
    }
}