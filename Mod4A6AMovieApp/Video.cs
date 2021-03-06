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
    public class Video : IMedia
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

        public override string ToString() 
        {
            return String.Format("{0,8}  {1,-45}  {2,-20}  {3,7}  {4,-25}",Id, Title, Format, Length, string.Join(", ", Regions));
        }

        public void Search(string searchWord)
        {
            VideoManager videoManager = new VideoManager();
            videoManager.ReadFile();
            List <Video> titles = videoManager.Videos.Where(m => m.Title.ToUpper().Contains(searchWord)).ToList();
            System.Console.WriteLine(string.Format($"\nVideo Library matches: ({titles.Count()})"));
            foreach (Video video in titles)
            {
                System.Console.WriteLine("     " + video.Title);
            }
        } 

        public void Display()
        {   
            VideoManager videoManager = new VideoManager();
            videoManager.ReadFile();
            System.Console.WriteLine(String.Format("{0,8}  {1,-45}  {2,-20}  {3,7}  {4,-25}","Id", "Title", "Format", "Length", "Regions"));  
            foreach (var video in videoManager.Videos)
            {
                System.Console.WriteLine(video);
            }
        }
    }    
}