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

         public override void ReadCsv()
        {   
            Video video = new Video();
            string file = "videos.csv";
            string path = $"{Environment.CurrentDirectory}/data/{file}";
            StreamReader sr = new StreamReader(path);
            sr = new StreamReader(path);     
            
            if (File.Exists(path))
            {   
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    char[] lineChar = line.ToCharArray();
                    int quote = line.IndexOf('"');

                    if ((quote == -1) && (!(lineChar[0].Equals('i'))))                  //No quotes in title & Not the header line
                    {
                        string[] arr = line.Split(',');
                        video = new Video(Int32.Parse(arr[0]), arr[1], arr[2], Int32.Parse(arr[3])); 
                        string[] regionsPerVideo = (arr[4]).Split('|'); 
                        video.Regions = regionsPerVideo;
                        Videos.Add(video);
                    }
                    else if (!(lineChar[0].Equals('i')))                                //Not the header line
                    {                        
                        int sID = Int32.Parse(line.Substring(0,quote-1));   
                        line = line.Remove(0,quote+1);
                        quote = line.IndexOf('"');
                        string sTitle = line.Substring(0,quote);
                        line = line.Remove(0,quote+2);
                        string[] arr = line.Split(',');                        
                        string vFormat = arr[0];  
                        int vLength = Int32.Parse(arr[1]);
                        string [] regionsPerVideo = arr[2].Split('|');                       
                        video = new Video(sID, sTitle, vFormat, vLength);
                        video.Regions = regionsPerVideo;
                        Videos.Add(video);
                    }                       
                }                 
            }
            sr.Close();
        } 
    }
}