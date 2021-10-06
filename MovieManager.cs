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
            int j = 0;
            string moreGenre = "";
            do
            {
                Console.WriteLine("Enter movie genre: ");
                genre[j] = Console.ReadLine();
                j++;
                Console.WriteLine("Is there another genre for this movie (Y/N)?");
                moreGenre = Console.ReadLine().ToUpper();
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
            this.Genre =  genres;
        }

        public override string ToString() 
        {
            return String.Format("{0,8}  {1,-60}  {2,-45}",MovieID, MovieTitle, Genre);
        }

    }

}