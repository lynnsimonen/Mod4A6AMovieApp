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
    public class Movie : Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string[] Genre { get; set; }
        //public string Genre { get; set; }

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
            
            //return String.Format("{0,8}  {1,-65}  {2,-45}",Id, Title, Genre);
            return String.Format("{0,8}  {1,-65}  {2,-45}",Id, Title, string.Join(", ", Genre));
        }

        public void ListUtility()
        {
            //COLLECTING GENRES FOR NEW MOVIE & CREATING STRINGS SEPARATED BY "|"
            string[] genre = new string[6];
            int j = 0;
            string moreGenre = "";
            do
            {
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
            }
            else
            {
                genres = genre[0];
            }
            this.Genre =  genre;
        }

        //-------------------------------------------------------------------------------------------------------

        public override void Display()
        {   
            MovieManager movieManager = new MovieManager();
            movieManager.ReadCsv();
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