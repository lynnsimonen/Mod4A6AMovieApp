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
        public List<IMedia> Medias { get; set; }   

        public virtual void ReadFile()
        {
            System.Console.WriteLine("Read file here...");
        }

        public virtual void Add()
        {
            System.Console.WriteLine("Add media to file.");
        }  

    }
    
}