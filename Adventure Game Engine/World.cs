using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game_Engine
{
    public class World
    {
        
        public Dictionary<string,Zone> zones { get; set; }

        public void Populate()
        {
            //currently takes those datas to create the world, TODO: replace this by loading from XML
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
        public void CreateNewZone(string zoneName)
        {
            Zone newZone = new Zone(zoneName);      //create new zone
            zones.Add(zoneName, newZone);           //add it to the dictionnary
        }
        public void DeleteZone(string zoneName)
        {
            zones.Remove(zoneName);
        }
        public bool isZoneExisting(string zoneName)
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
        public Zone GetZoneFromString(string zoneName)
        {
            Zone zone = null;
            if (isZoneExisting(zoneName))
            {
                zones.TryGetValue(zoneName, out zone);
            }
            return zone;
        }
        public string[] GetAllZones()
        {
            return zones.Keys.ToArray<String>();
        }
    }
}
