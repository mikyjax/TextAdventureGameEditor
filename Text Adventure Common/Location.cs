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
        public Zone Zone { get; set; }
        
        public Oobject Void;

        public AccessPoint GetAccessPoint(string direction)
        {
            foreach (var ap in AccessPoints)
            {
                if (ap.Direction.ToLower() == direction)
                {
                    return ap;
                }
            }
            return null;
        }

        public Inventory Inventory { get; set; }

        public bool HasFloor { get; set; }
        public bool  HasWalls { get; set; }
        public bool HasCeiling { get; set; }
        public bool HasGravity { get; set; }


        public Location(string title, string description, bool transitionLocation = false, bool isStartingLocation = false)
        {
            Title = title;
            Description = description;
            IdCounter++;
            Id = IdCounter;
            TransitionLocation = transitionLocation;
            StartingLocation = isStartingLocation;
            AccessPoints = new List<AccessPoint>();
            Void = new VoidContainer(null,this);
            HasFloor = true;
            HasWalls = true;
            HasCeiling = true;
            HasGravity = true;

            Void.insideInventory.Add(new FloorContainer(Void.insideInventory));
            Void.insideInventory.Add(new WallContainer(Void.insideInventory));
            Void.insideInventory.Add(new CeilingContainer(Void.insideInventory));

        }
        public List<Oobject> GetAllAvaillableObjects()
        {
            List<Oobject> availlableObjects = new List<Oobject>();
            availlableObjects.AddRange( getDirectionnalObject());


            availlableObjects.AddRange(getObjects());

            return availlableObjects;
        }

        private List<Oobject> getObjects()
        {
            List<Oobject> objects = new List<Oobject>();

            objects = this.Void.insideInventory.GetObjects();

            return objects;
        }

        private List<DirectionObject> getDirectionnalObject()
        {
            List<DirectionObject> directionObjects = new List<DirectionObject>();
            foreach (var ap in AccessPoints)
            {
                directionObjects.Add(new DirectionObject(Void.insideInventory, ap));
            }
            return directionObjects;
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
