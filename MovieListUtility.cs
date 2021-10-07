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
        public void List(MediaManager mediaManager)
        {
            foreach (var movie in mediaManager.Movies)
            {
                Console.WriteLine(movie.Title);
            }
        }

        public int Count(MediaManager mediaManager)
        {
            return mediaManager.Movies.Count;
        }

    }
}