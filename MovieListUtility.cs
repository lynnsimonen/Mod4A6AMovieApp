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
    public class MovieListUtility
    {
        public void List(MovieManager movieManager)
        {
            foreach (var movie in movieManager.Movies)
            {
                Console.WriteLine(movie.Title);
            }
        }

        public int Count(MovieManager movieManager)
        {
            return movieManager.Movies.Count;
        }

    }
}