using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame
{
    public class Location
    {
        public static int IdCounter { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AccessPoint> AccessPoints;

        

        public Location (string title, string description)
        {
            Title = title;
            Description = description;
            IdCounter++;
            Id = IdCounter;
            
        }
      
    }
}
