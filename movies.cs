using System;

namespace Mod4A6AMovieApp
{   
    public class Movies : Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }

        // public override string MediaList()
        // {        
        //     do
        //     {
        //         for (int i = start; i < (start + 5); i++)
        //         {
        //         Console.WriteLine(movieManager.Movies[i]);
        //         }
        //         start += 5;
        //         Console.WriteLine("\nWould you like to have more movies listed? Y/N");
        //         listMore = Console.ReadLine().ToUpper();
        //     } while (!(listMore == "N"));
        // }

        public override string ToString() 
        {
            return Id + " " + Title + " " + Genre;
        }
    }    
}