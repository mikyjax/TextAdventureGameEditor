using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame
{
    public class Zone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Location> Locations { get; set; }

        public Zone(string zoneName)
        {
            Name = zoneName;
            Locations = new List<Location>();
        }

        #region HELPERS
        public void AddLocation(Location loc)
        {
            Locations.Add(loc);
        }
        public String[] GetLocationsTitles()
        {
            List<string> titles = new List<string>();

            foreach (Location loc in Locations)
            {
                titles.Add(loc.Title);
            }
            return titles.ToArray();


        }
        public Location GetLocationByName(string locToFind)
        {
            foreach (Location loc in Locations)
            {
                if (loc.Title == locToFind)
                {
                    return loc;
                }
            }
            return null;
        }
        public void DeleteLocationAccessPoints(Location locToDelete, World world)
        {
            foreach (Zone zone in world.GetAllZones())
            {
                foreach (Location loc in zone.Locations)
                {
                    if (loc.AccessPoints != null && loc.AccessPoints.Count > 0)
                    {
                        foreach (AccessPoint ap in loc.AccessPoints)
                        {
                            bool apRemoved = false;
                            if (ap.DestZone == this.Name && ap.DestLoc == locToDelete.Title)
                            {
                                loc.AccessPoints.Remove(ap);
                                apRemoved = true;
                            }
                            if (apRemoved)
                            {
                                break;
                            }
                        }
                    }

                }
            }

        }
        public void DeleteLocation(Location locToDelete)
        {
            Locations.Remove(locToDelete);
        }
        public bool IsLocationExistingInZone(string title)
        {
            bool isExisting = false;

            foreach (Location loc in Locations)
            {
                if (loc.Title == title)
                {
                    return true;
                }
            }

            return isExisting;
        }
        public void CreateEmptyButNamedLocationInAZone(string locName)
        {
            Location locToAdd = new Location(locName, "");
            AddLocation(locToAdd);
        }
        #endregion

        #region Static Helpers
        static public  List<Location> GetLocationsFromAllZones(List<Zone> zones)
        {
            List<Location> allLocations = new List<Location>();

            foreach (Zone zone in zones)
            {
                foreach (Location loc in zone.Locations)
                {
                    allLocations.Add(loc);
                }
            }
            return allLocations;
        }
        #endregion
    }
}
