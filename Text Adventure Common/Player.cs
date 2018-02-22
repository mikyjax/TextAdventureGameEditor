
using System;

namespace TextAdventureCommon
{
    public class Player
    {
        World world;
        public Location CurrentLocation { get; set; }
        public Player(World world)
        {
            this.world = world;
            CurrentLocation = world.GetStartingLocation();
        }

        public void GoToNextLocation(AccessPoint accessPoint)
        {
            Location  lastLoc = CurrentLocation;
            
            Location newLocation = world.GetLocation(accessPoint.DestZone, accessPoint.DestLoc);
            if (newLocation.TransitionLocation)
            {
                foreach (var aP in newLocation.AccessPoints)
                {
                    Location tempLoc = world.GetLocation(aP.DestZone, aP.DestLoc);
                    if (lastLoc != tempLoc)
                    {
                        lastLoc = tempLoc;
                        //CurrentLocation = tempLoc;
                        foreach (var aP2 in newLocation.AccessPoints)
                        {
                            Location tempLoc2 = world.GetLocation(aP2.DestZone, aP2.DestLoc);
                            if (lastLoc != tempLoc2)
                            {
                                CurrentLocation = tempLoc2;

                            }
                        }
                    }
                }
            }
            else
            {
                CurrentLocation = newLocation;
            }
            
        }
    }
}