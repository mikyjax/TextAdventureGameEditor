using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureCommon
{
    public class World
    {
        public string GameTitle;
        public Dictionary<string,Zone> zones { get; set; }

        public Zone Populate()
        {
            Zone startingZone = null;
            Zone papa = CreateNewZone("Maison de Papa");
            papa.AddLocation(new Location("Chambre de papa", ""));
            papa.AddLocation(new Location("Ancienne chambre de mike", ""));
            papa.AddLocation(new Location("Salon papa", ""));

            Zone fred = CreateNewZone("Maison de Fred");
            fred.AddLocation(new Location("Chambre mike et nastia", ""));
            fred.AddLocation(new Location("Chambre manon", ""));
            fred.AddLocation(new Location("Kot de Fred", ""));

            Zone maman = CreateNewZone("Maison de Maman");
            maman.AddLocation(new Location("Chambre maman et éric", ""));
            maman.AddLocation(new Location("Jardin pourri", ""));
            maman.AddLocation(new Location("Salle de bain", ""));
            startingZone = papa;
            return papa;
        }
        public void Create()
        {
            zones = new Dictionary<string, Zone>();
        }

        public void RenameZone(string oldName, string newName)
        {
            Zone newZone = new Zone(newName);//create a new zone with the new name
            zones.Add(newName, newZone);//add that zone to the dictionnary
            zones.Remove(oldName);//remove the old zone
        }
        public Zone CreateNewZone(string zoneName)
        {
            Zone newZone = new Zone(zoneName);      //create new zone
            zones.Add(zoneName, newZone);           //add it to the dictionnary
            return newZone;
        }
        public void DeleteZone(string zoneName)
        {
            Zone zone = GetZoneFromString(zoneName);
            List<Location> locsToDelete = zone.Locations;
            
            foreach (Location loc in locsToDelete)
            {
                zone.DeleteLocationAccessPoints(loc, this);
            }
            
            zones.Remove(zoneName);
        }
        public bool IsZoneExisting(string zoneName)
        {
            foreach (String zoneNameKey in zones.Keys)
            {
                if (zoneName == zoneNameKey)
                {
                    return true;
                }

            }
            return false;
        }
        public Zone GetZoneOfLocation(Location loc)
        {
            Zone zoneFound = null;

            foreach (KeyValuePair<string, Zone> item in zones)
            {
                if (item.Value.IsLocationExistingInZone(loc.Title))
                {
                    return item.Value;
                }
            }

            return zoneFound;
        }
        public Zone GetZoneFromString(string zoneName)
        {
            Zone zone = null;
            if (IsZoneExisting(zoneName))
            {
                zones.TryGetValue(zoneName, out zone);
            }
            return zone;
        }
        public string[] GetAllZonesNames()
        {
            return zones.Keys.ToArray<String>();
        }
        public List<Zone> GetAllZones()
        {
            List<Zone> allZones = new List<Zone>();
            foreach (var zone in zones.Values)
            {
                allZones.Add(zone);
            }
            return allZones;
        }

        public List<Location> GetAllLocations()
        {
            List<Location> allLocations = new List<Location>();
            foreach (Zone zone in GetAllZones())
            {
                foreach(Location loc in zone.Locations)
                {
                    allLocations.Add(loc);
                }
            }
            return allLocations;
        }
    }
}
