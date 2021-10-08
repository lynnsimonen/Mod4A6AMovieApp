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
    public class MovieManager : MediaManager
    {
        public List<Movie> Movies { get; set; }
       
        public MovieManager()
        {
            Movies = new List<Movie>();
        }

    }
        
}