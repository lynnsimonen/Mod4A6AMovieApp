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
       
        public override string ToString() 
        {
            return String.Format("{0,8}  {1,-45}  {2,5}  {3,5}  {4,-35}",Id, Title, Season, Episode, string.Join(", ", Writers));
        }

        public override void Display()
        {   
            ShowManager showManager = new ShowManager();
            showManager.ReadCsv();
            string listMore = "";
            int start = 0; 
            do
            {
                for (int i = start; i < (start + 5); i++)
                {
                Console.WriteLine(showManager.Shows[i]);
                }
                start += 5;
                string oops5 = "";
                do {
                Console.WriteLine("\nWould you like to have more shows listed? Y/N");
                listMore = Console.ReadLine().ToUpper();
                oops5 = (listMore == "Y" || listMore == "N") ? "Y" : "N";
                } while (oops5 != "Y");  
            } while (!(listMore == "N"));
        }
    }    
}