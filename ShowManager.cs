using System.IO.Enumeration;
using System.Net;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using System.Globalization;
using NLog;
using NLog.Web;

namespace Mod4A6AMovieApp
{
    public class ShowManager : MediaManager
    {
       public List<Show> Shows {get; set;}
        
       public ShowManager()
        {
            Shows = new List<Show>();
        }

        public override void ReadCsv()
        {   
            Show show = new Show();
            string showFile = "shows.csv";
            string showPath = $"{Environment.CurrentDirectory}/data/{showFile}";
            StreamReader sr = new StreamReader(showPath);
            sr = new StreamReader(showPath);     
            
            if (File.Exists(showPath))
            {   
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    char[] lineChar = line.ToCharArray();
                    int quote = line.IndexOf('"');

                    if ((quote == -1) && (!(lineChar[0].Equals('i'))))                  //No quotes in title & Not the header line
                    {
                        string[] arr = line.Split(',');
                        show = new Show(Int32.Parse(arr[0]), arr[1], Int32.Parse(arr[2]), Int32.Parse(arr[3])); 
                        string[] writersPerMovie = (arr[4]).Split('|'); 
                        show.Writers = writersPerMovie;
                        Shows.Add(show);
                    }
                    else if (!(lineChar[0].Equals('i')))                                //Not the header line
                    {                        
                        int sID = Int32.Parse(line.Substring(0,quote-1));   
                        line = line.Remove(0,quote+1);
                        quote = line.IndexOf('"');
                        string sTitle = line.Substring(0,quote);
                        line = line.Remove(0,quote+2);
                        string[] arr = line.Split(',');                        
                        int sSeason = Int32.Parse(arr[0]);  
                        int sEpisode = Int32.Parse(arr[1]);
                        string [] writersPerMovie = arr[2].Split('|');                       
                        show = new Show(sID, sTitle, sSeason, sEpisode);
                        show.Writers = writersPerMovie;
                        Shows.Add(show);
                    }                       
                }                 
            }
            sr.Close();
        }
    }
}