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
    public class Show : Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Season { get; set; }
        public int Episode { get; set; }
        public List<string> Writers { get; set; }

         public void ReadCsv()
        {
            
        }

        public override void Display()
        {

        }

        public override string ToString() 
        {
            return String.Format("{0,8}  {1,-45}  {2,5}  {3,5}  {4,-35}",Id, Title, Season, Episode, Writers);
        }
    }    
}