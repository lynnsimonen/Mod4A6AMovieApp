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
    public class ShowManager : MediaManager
    {
       public List<Show> Shows {get; set;}
        
       public ShowManager()
        {
            Shows = new List<Show>();
        }

        public void ReadCsv()
        {
            //ShowManager showManager = new ShowManager();
            Show show = new Show();
            string file = "shows.csv";
            string path = $"{Environment.CurrentDirectory}/data/{file}";
            StreamReader sr = new StreamReader(path);
                        
            if (File.Exists(path)) 
            {    
                sr = new StreamReader(path);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] arr = line.Split(',');
                    int quote = line.IndexOf('"');

                    if ((quote == -1) && (arr[0] != "iD"))
                    {
                        arr = line.Split(',');
                        show = new Show(Int32.Parse(arr[0]), arr[1], Int32.Parse(arr[2]), Int32.Parse(arr[3])); 
                        //HOW READ AN ARRAY                           
                        // string[] Writers = arr[4];
                        // Shows.Add(Show);
                    }
                    else if (arr[0] != "iD")
                    {
                        int sID = Int32.Parse(line.Substring(0,quote-1));
                        line = line.Substring(quote + 1);
                        quote = line.IndexOf('"');
                        string sTitle = line.Substring(0,quote);
                        show = new Show(sID, sTitle);
                        line = line.Substring(quote + 2);
                        //HOW READ AN ARRAY
                        // string[] Writers = line;
                        // Shows.Add(show);
                    }                       
                }
            }
            sr.Close();
            
        }

       
    }
}