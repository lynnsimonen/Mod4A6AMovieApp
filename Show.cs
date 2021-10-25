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
    public class Show : IMedia
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
            return String.Format("{0,8}  {1,-45}  {2,5}  {3,10}    {4,-35}",Id, Title, Season, Episode, string.Join(", ", Writers));
        }

         public void Search(string searchWord)
        {
            ShowManager showManager = new ShowManager();
            showManager.ReadFile();
            List <Show> titles = showManager.Shows.Where(m => m.Title.Contains(searchWord)).ToList();
            foreach (Show show in titles)
            {
                System.Console.WriteLine("Show Library: " + show);
            }
        } 

        public void Display()
        {   
            ShowManager showManager = new ShowManager();
            showManager.ReadFile();
            System.Console.WriteLine(String.Format("{0,8}  {1,-45}  {2,5}  {3,10}   {4,-35}","Id", "Title", "Season", "Episode", "Writers"));
            foreach (var show in showManager.Shows)
            {
                System.Console.WriteLine(show);
            }
        }
    }    
}