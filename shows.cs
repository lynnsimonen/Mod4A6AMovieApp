using System;
using System.Collections.Generic;

namespace Mod4A6AMovieApp
{   
    public class Shows : Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Season { get; set; }
        public int Episode { get; set; }
        public List<string> Writers { get; set; }

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
            return Id + " " + Title + " " + Season + " " + Writers;
        }
    }    
}