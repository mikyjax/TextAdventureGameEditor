using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureCommon
{
    public abstract class Object
    {
        public string name { get; set; }
        public string[] synonyms { get; set; }
        public string genre { get; set; }
    }

    public abstract class ConceptualObject : Object
    {

    }

    interface IGoToAble
    {
        void Go(Object secondaryDirectionOrObjectToGo);
    }
    public class DirectionObject : ConceptualObject , IGoToAble
    {

        AccessPoint accessPoint;
        Player player;
        World world;

        public static string[][] directions = new string[][]
        {
            new string[] {"n","north","nord"},
            new string[] {"ne","north-east","north east","nord est","nordest","nord-est"},
            new string[] {"s","south","sud"},
            new string[] {"se", "south-east", "south east", "sud est","sudest","sud-est"},
            new string[] {"e","east","est"},
            new string[] {"sw", "south-west", "south west", "sud ouest","sudouest","sud-ouest"},
            new string[] {"w","west","ouest"},
            new string[] {"nw", "north-west", "north west", "nord ouest","nordouest","nor-ouest"},
        };

        public static List<DirectionObject> GetAvailableDirObjects(List<AccessPoint> accessPoints)
        {
            List<DirectionObject> directionsObjects = new List<DirectionObject>();

            foreach (var accessPoint in accessPoints)
            {
                directionsObjects.Add(new DirectionObject())
            }

            return directionsObjects;
        }

        public DirectionObject (Player player,World world,AccessPoint accessPoint)
        {
            this.player = player;
            this.accessPoint = accessPoint;
            name = accessPoint.Direction;
            this.world = world;
            
        }

        public void Go(Object secondaryDirectionOrObjectToGo)
        {
            Location locToGo = world.GetLocation(accessPoint.DestZone,accessPoint.DestLoc);
            player.CurrentLocation = locToGo;
        }
    }




}
