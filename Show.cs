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
        public string[] Writers { get; set; }

        public Show()
        {
        }

        public Show(int Id, string Title)
        {
            this.Id = Id;
            this.Title = Title;
        }
        
        public Show(int Id, string Title, int Season, int Episode)
        {
            this.Id = Id;
            this.Title = Title;
            this.Season = Season;
            this.Episode = Episode;
        }

        public override void ReadCsv()
        {
            MediaManager mediaManager = new MediaManager();
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

        public override void Display()
        {
        string listMore = "";
        int start = 0; 
        do
        {
            for (int i = start; i < (start + 5); i++)
            {
                //HELP HERE!!!
                //Console.WriteLine(mediaManager.Shows[i]);
            }
            start += 5;
            string oops1 = "";
            do {
                Console.WriteLine("\nWould you like to have more movies listed? Y/N");            
                listMore = Console.ReadLine().ToUpper();
                oops1 = (listMore == "Y" || listMore == "N") ? "Y" : "N";
            } while (oops1 != "Y"); 
        } while (!(listMore == "N"));

        }

        public override string ToString() 
        {
            return String.Format("{0,8}  {1,-45}  {2,5}  {3,5}  {4,-35}",Id, Title, Season, Episode, Writers);
        }
    }    
}