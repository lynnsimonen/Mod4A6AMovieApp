using System;
using System.Collections.Generic;

namespace Mod4A6AMovieApp
{   
    public class Videos : Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Format { get; set; }
        public int Length { get; set; }
        public List<int> Regions { get; set; }

        public override void List()
        {
            string listMore = "";
            int start = 0;
            do
            {
                for (int i = start; i < (start + 25); i++)
                {
                    Console.WriteLine("hello");
                }
                start += 25;
                Console.WriteLine("Would you like to have more media listed? Y/N");
                listMore = Console.ReadLine().ToUpper();
            } while (!(listMore == "N"));
            Console.WriteLine("");
        }

        public override string ToString() 
        {
            return Id + " " + Title + " " + Format + " " + Length + " " + Regions;
        }
    }    
}