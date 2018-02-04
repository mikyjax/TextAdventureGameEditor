using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game_Engine
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

        #region Public Functions
        public void AddLocation(Location loc)
        {
            Locations.Add(loc);
        }
        #endregion

        #region Static Helpers

        //static public List<Location> GetLocationsFromZoneExcept(Zone zone, Location locToIgnore)
        //{
        //    List<Location> locations = new List<Location>();
        //    foreach (Location loc in locations)
        //    {
        //        if(loc.Id != locToIgnore.Id)
        //        {
        //            locations.Add(loc);
        //        }
        //    }  
        //    return locations;
        //}
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
