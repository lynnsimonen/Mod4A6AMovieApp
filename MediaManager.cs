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
    public abstract class MediaManager
    {
        public List<Media> Medias { get; set; }       

        //public MediaManager();

        public virtual void ReadCsv()
        {
            
        }

        public bool IsDuplicate()
        {
            return true;
        }
    }
    
}