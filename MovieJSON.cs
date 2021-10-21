using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Mod4A6AMovieApp
{
    public class MovieJSON : IMedia
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string[] Genre { get; set; }

        public MovieJSON()
        {
        }

        public MovieJSON(int Id, string Title)
        {
            this.Id = Id;
            this.Title = Title;
        }
    
        public override string ToString() 
        {
            return String.Format("{0,8}  {1,-65}  {2,-45}",Id, Title, string.Join(", ", Genre));
        }

        public void Display()
        {
            System.Console.WriteLine(String.Format("{0,8}  {1,-65}  {2,-45}","Id", "Title", "Genre"));
            MovieJSON movieJson = new MovieJSON();
            string jsonFile = "movies.json";
            string jsonPath = $"{Environment.CurrentDirectory}/data/{jsonFile}";
            string strResultJson = String.Empty;
            strResultJson = System.IO.File.ReadAllText(@jsonPath);
            List<MovieJSON> resultMovieJSON = JsonConvert.DeserializeObject<List<MovieJSON>>(strResultJson);
            foreach (var result in resultMovieJSON)
            {
                System.Console.WriteLine(result.ToString());
            }
        }

        public string ListUtility()
        {
            //COLLECTING GENRES FOR NEW MOVIE & CREATING STRING SEPARATED BY "|"
            string[] genre = new string[6];
            int j = 0;
            string moreGenre = "";
            do {
                string oops1 = "";
                do{
                Console.WriteLine("Enter movie genre: ");
                genre[j] = Console.ReadLine();
                oops1 = (genre[j]!="") ? "Y" : "N";
                } while (oops1 != "Y");
                j++;
                string oops2 = "";
                do{
                Console.WriteLine("Is there another genre for this movie (Y/N)?");
                moreGenre = Console.ReadLine().ToUpper();
                oops2 = (moreGenre == "Y" || moreGenre == "N") ? "Y" : "N";
                } while (oops2 != "Y");               
            } while (moreGenre == "Y");
            string genres = "";
            if (j >= 1)
            {
                for (int k = 0; k < j - 1; k++)
                {
                    genres += genre[k] + "|";
                }
                genres = genres + genre[j - 1];
                return genres;
            }
            else
            {
                genres = genre[0];
                return genres;   
            }
        }
    }
}