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
    public class MediaManager
    {
        public List<Movie> Movies { get; set; }
        public List<Show> Shows {get; set;}
        public List<Video> Videos {get; set;}

        public MediaManager()
        {
            Movies = new List<Movie>();
        }

        public void ShowManager()
        {
            Shows = new List<Show>();
        }

        public void VideoManager()
        {
            Videos = new List<Video>();
        }

        public bool IsDuplicate()
        {
            return true;
        }
    }
    
}