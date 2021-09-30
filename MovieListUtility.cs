using System;
using System.Collections.Generic;
using System.Text;

namespace Mod4A6AMovieApp
{
    public class MovieListUtility
    {
        //TODO: return list of # of movies requested 1-100 and continue as requested
        public void List(MovieManager movieManager)
        {
            foreach (var movie in movieManager.Movies)
            {
                Console.WriteLine(movie.MovieTitle);
            }
        }

        public int Count(MovieManager movieManager)
        {
            return movieManager.Movies.Count;
        }

    }
}