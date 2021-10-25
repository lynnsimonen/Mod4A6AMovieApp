using System.IO.Enumeration;
using System.Net;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using System.Globalization;

namespace Mod4A6AMovieApp
{   
    public class Movie : IMedia
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string[] Genre { get; set; }

        public Movie()
        {
        }

        public Movie(int Id, string Title)
        {
            this.Id = Id;
            this.Title = Title;
        }
    
        public override string ToString() 
        {
            return String.Format("{0,8}  {1,-65}  {2,-45}",Id, Title, string.Join(", ", Genre));
        }

        public void Search(string searchWord)
        {
            MovieManager movieManager = new MovieManager();
            movieManager.ReadFile();
            searchWord = Console.ReadLine().ToUpper();
            List <Movie> titles = movieManager.Movies.Where(m => m.Title.Contains(searchWord)).ToList();
            foreach (Movie movie in movieManager.Movies)
            {
                System.Console.WriteLine("Movie Library: " + movie);
            }
        } 
        //     //paginate
        //     //var pageNumber = 4;
        //     //var outputRows = 10;
        //     //Employees.Skip(pageNumber*outputRows).Take(outputRows);
        //     for(int a = 0; a <= Medias.Count(); a+=10)
        //     {
        //     Medias.Skip(a).Take(10);
        //     a = a+10;
        //     }
        //     //var result = Employees.Where(x=>.Location == "United States").First();           or FirstOrDefault() or .Last() if only want one answer for result...
        // } 

        public string ListUtility()
        {
            //COLLECTING GENRES FOR NEW MOVIE & CREATING STRING SEPARATED BY "|"
            string[] genre = new string[6];
            int j = 0;
            string moreGenre = "";
            do {
                string oops1 = "";
                do{
                Console.WriteLine("Enter movie genre: ");
                genre[j] = Console.ReadLine();
                oops1 = (genre[j]!="") ? "Y" : "N";
                } while (oops1 != "Y");
                j++;
                string oops2 = "";
                do{
                Console.WriteLine("Is there another genre for this movie (Y/N)?");
                moreGenre = Console.ReadLine().ToUpper();
                oops2 = (moreGenre == "Y" || moreGenre == "N") ? "Y" : "N";
                } while (oops2 != "Y");               
            } while (moreGenre == "Y");
            string genres = "";
            if (j >= 1)
            {
                for (int k = 0; k < j - 1; k++)
                {
                    genres += genre[k] + "|";
                }
                genres = genres + genre[j - 1];
                return genres;
            }
            else
            {
                genres = genre[0];
                return genres;   
            }
        }

        //-------------------------------------------------------------------------------------------------------

        public void Display()
        {   
            MovieManager movieManager = new MovieManager();
            movieManager.ReadFile();
            System.Console.WriteLine(String.Format("{0,8}  {1,-65}  {2,-45}","Id", "Title", "Genre"));
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

    }    
}