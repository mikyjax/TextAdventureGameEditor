using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureCommon
{
    public class Location
    {
        public static int IdCounter { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AccessPoint> AccessPoints;
        public bool TransitionLocation { get; set; } //a location that won't appear ingame but will influence access point directions.
                                                     //like a stairs turning 180° or 90°.
        public bool StartingLocation { get; set; }



        public Location(string title, string description, bool transitionLocation = false, bool isStartingLocation = false)
        {
            Title = title;
            Description = description;
            IdCounter++;
            Id = IdCounter;
            TransitionLocation = transitionLocation;
            StartingLocation = isStartingLocation;
            AccessPoints = new List<AccessPoint>();
        }

        public void AddAccessPointsToLocation(List<AccessPoint> accessPoints)
        {
            if (accessPoints != null)
            {
                AccessPoints = accessPoints;
            }
            else
            {
                accessPoints = new List<AccessPoint>();
            }
        }

    }
}
