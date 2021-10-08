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
    public class VideoManager : MediaManager
    {
        public List<Video> Videos {get; set;}

        public VideoManager()
        {
            Videos = new List<Video>();
        }

        public void ReadCsv()
        {
            VideoManager videoManager = new VideoManager();
            Video video = new Video();
            string file = "videos.csv";
            string path = $"{Environment.CurrentDirectory}/data/{file}";
            StreamReader sr = new StreamReader(path);
            
            //string newTitle = "";
            //string newMedia = "";
            
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
                        video = new Video(Int32.Parse(arr[0]), arr[1], arr[2], Int32.Parse(arr[3])); 
                        //HOW READ AN ARRAY                           
                        // string[] Regions = arr[4];
                        // Videos.Add(video);
                    }
                    else if (arr[0] != "iD")
                    {
                        int vID = Int32.Parse(line.Substring(0,quote-1));
                        line = line.Substring(quote + 1);
                        quote = line.IndexOf('"');
                        string vTitle = line.Substring(0,quote);
                        video = new Video(vID, vTitle);
                        line = line.Substring(quote + 2);
                        //HOW READ AN ARRAY
                        // string[] Regions = line;
                        // Videos.Add(video);
                    }                       
                }
            }
            sr.Close();
        }       

    }
}