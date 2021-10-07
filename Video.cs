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
    public class Video : Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Format { get; set; }
        public int Length { get; set; }
        public string[] Regions { get; set; }

        public Video()
        {
        }

        public Video(int Id, string Title)
        {
            this.Id = Id;
            this.Title = Title;
        }
        
        public Video(int Id, string Title, string Format, int Length)
        {
            this.Id = Id;
            this.Title = Title;
            this.Format = Format;
            this.Length = Length;
        }

        public override void ReadCsv()
        {
            MediaManager mediaManager = new MediaManager();
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

        public override void Display()
        {
            string listMore = "";
            int start = 0; 
            do
            {
                for (int i = start; i < (start + 5); i++)
                {
                    //HELP HERE!!!
                    //Console.WriteLine(mediaManager.Videos[i]);
                }
                start += 5;
                Console.WriteLine("\nWould you like to have more movies listed? Y/N");
                listMore = Console.ReadLine().ToUpper();
            } while (!(listMore == "N"));

        }

        public override string ToString() 
        {
            return String.Format("{0,8}  {1,-45}  {2,-25}  {3,7}  {4,-25}",Id, Title, Format, Length, Regions);
        }
    }    
}