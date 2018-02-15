using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame
{
    public class AccessPoint
    {
        public string Direction { get; set; }
        public string DestLoc { get; set; }
        public string DestZone { get; set; }

        static public string[] DIRECTIONS = { "N","NE","E","SE","S","SW","W","NW" };
        

        public AccessPoint (string direction,
                            string destZone, 
                            string destLoc = "None")
        {
            Direction = direction;
            DestLoc = destLoc;
            DestZone = destZone;
        }

        public bool IsEqualTo(AccessPoint other)
        {
            if(Direction == other.Direction &&
               DestZone == other.DestZone &&
               DestLoc == other.DestLoc)
            {
                return true;
            }
            return false;
        }

        public bool IsOppositeAccessPointExisting(Location currentLocation, Zone currentZone, World world)
        {

            foreach (AccessPoint apOpposite in GetAllAccessPointFromWorld(world))
            {
                if (apOpposite.Direction == AccessPoint.ReturnOppositeDirection(Direction)&&
                    apOpposite.DestZone == currentZone.Name&&
                    apOpposite.DestLoc == currentLocation.Title)
                {
                    return true ;
                }
            }

            return false;
        }

        #region STATIC FUNCTIONS
        public static string ReturnOppositeDirection(string dir)
        {
            int indexToGo = 0;
            int dirIndex = 0;
            for (int i=0; i<DIRECTIONS.Length;i++)
            {
                
                if (DIRECTIONS[i] == dir)
                {
                    dirIndex = i;
                }
            }
            indexToGo = dirIndex - 4;
            if(indexToGo < 0)
            {
                indexToGo = DIRECTIONS.Length  + indexToGo;
            }
            return DIRECTIONS[indexToGo];
            
        }
        public static List<AccessPoint> GetAllAccessPointFromWorld(World world)
        {
            List<Zone> allZones = world.GetAllZones();
            List<AccessPoint> allAccessPoints = new List<AccessPoint>();
            //List<Location> allLocations = new List<Location>();
            foreach(Zone zone in allZones)
            {
                
                foreach (Location loc in zone.Locations)
                {

                    foreach (AccessPoint ap in loc.AccessPoints)
                    {
                        allAccessPoints.Add(ap);
                    }
                }
            }

            return allAccessPoints;
        }
        public static List<AccessPoint> GetAllAccessPointFromWorldExceptFromOneLocation(World world,Location locationToAvoid)
        {
            List<Zone> allZones = world.GetAllZones();
            List<AccessPoint> allAccessPoints = new List<AccessPoint>();
            //List<Location> allLocations = new List<Location>();
            foreach (Zone zone in allZones)
            {

                foreach (Location loc in zone.Locations)
                {
                    if(loc != locationToAvoid)
                    {
                        foreach (AccessPoint ap in loc.AccessPoints)
                        {
                            allAccessPoints.Add(ap);
                        }
                    }
                }
            }

            return allAccessPoints;
        }

        internal void CreateOppositeAccessPoint(Location currentLocation, Zone currentZone, Location locReceivingNewAccessPoint)
        {
            AccessPoint apToAdd = new AccessPoint(AccessPoint.ReturnOppositeDirection(Direction),currentZone.Name,currentLocation.Title);
            
        }

        #endregion
    }
}
