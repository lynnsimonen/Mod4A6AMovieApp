using System;

namespace Mod4A6AMovieApp
{   
    public abstract class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual void ReadCsv()
        {
            
        }

        public abstract void Display();

        public override string ToString() 
        {
            return Id + " " + Title;
        }
    }    
}