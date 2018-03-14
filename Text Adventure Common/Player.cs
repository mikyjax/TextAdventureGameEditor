
using System;

namespace TextAdventureCommon
{
    public class Player
    {
        World world;
        public Location CurrentLocation { get; set; }
        public Inventory MainInventory { get; set; }
        public Player(World world)
        {
            this.world = world;
            CurrentLocation = world.GetStartingLocation();
            MainInventory = new Inventory(null);
        }

        public void GoToNextLocation(AccessPoint accessPoint)
        {
            Location  lastLoc = CurrentLocation;
            CurrentLocation = world.GetLocation(accessPoint.DestZone, accessPoint.DestLoc);

            while (CurrentLocation.TransitionLocation)
            {
                Location nextRoom = null;
                bool found = false;
                foreach (var ap in CurrentLocation.AccessPoints)
                {
                    Location tempRoom = world.GetLocation(ap.DestZone, ap.DestLoc);
                    if (tempRoom != lastLoc)
                    {
                        nextRoom = tempRoom;
                        found = true;
                    }
                    if (found)
                    {
                        lastLoc = CurrentLocation;
                        CurrentLocation = nextRoom;
                        break;
                    }
                }
                
                
            }
           
            
        }
    }
}