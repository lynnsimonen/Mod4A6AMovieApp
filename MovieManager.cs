using System;
using System.Collections.Generic;
using System.Text;

namespace Mod4A6AMovieApp
{
    public class MovieManager
    {
        public List<Movie> Movies { get; set; }
        public MovieManager()
        {
            Movies = new List<Movie>();
        }

        public bool IsDuplicate()
        {
            return true;
        }
    }

    public class Movie
    {
        public int MovieID { get; set; }
        public string MovieTitle { get; set; }
        public string Genre { get; set; }

        public Movie()
        {

        }
        public Movie(int movieID, string movieTitle)
        {
            this.MovieID = movieID;
            this.MovieTitle = movieTitle;
        }

        public void GenreListUtility()
        {
            string[] genre = new string[6];
            //index of genre arr set at 0
            int j = 0;
            //create variable for another genre
            string moreGenre = "";
            do
            {
                // prompt for genre
                Console.WriteLine("Enter movie genre: ");
                // save the genre into array
                genre[j] = Console.ReadLine();
                // increment the array index
                j++;
                //ask user whether there is another genre
                Console.WriteLine("Is there another genre for this movie (Y/N)?");
                // input whether another genre
                moreGenre = Console.ReadLine().ToUpper();
                // while another genre is "Y", continue loop
            } while (moreGenre == "Y");
            //create a string to hold all genres (starts empty)
            string genres = "";
            //if more than one genres, do loop
            if (j >= 1)
            {
                //loop through all except last genre listed and put pipe between them 
                for (int k = 0; k < j - 1; k++)
                {
                    genres += genre[k] + "|";
                }
                //cap string with last name listed
                genres = genres + genre[j - 1];
            }
            else
            //if only one genre, no need for pipes 
            {
                genres = genre[0];
            }
            this.Genre =  genres;
        }

        public override string ToString() 
        {
            return MovieID + " " + MovieTitle + " " + Genre;
        }

    }

}