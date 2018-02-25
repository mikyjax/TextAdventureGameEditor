using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureCommon
{
    public abstract class Oobject
    {
        public string Name { get; set; }
        public string[] Synonyms { get; set; }
        public string Genre { get; set; }
    }

    public abstract class ConceptualObject : Oobject
    {

    }

    public interface IGoToAble
    {
        
        void Go(Oobject secondaryDirectionOrObjectToGo);
    }
    public class DirectionObject : ConceptualObject , IGoToAble
    {

        public AccessPoint accessPoint;
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

        public  List<DirectionObject> GetAvailableDirObjects(List<AccessPoint> accessPoints)
        {
            List<DirectionObject> directionsObjects = new List<DirectionObject>();

            foreach (var accessPoint in accessPoints)
            {
                directionsObjects.Add(new DirectionObject(player,world,accessPoint));
            }

            return directionsObjects;
        }

        public DirectionObject (Player player,World world,AccessPoint accessPoint)
        {
            this.player = player;
            this.accessPoint = accessPoint;
            Name = accessPoint.Direction.ToLower();
            this.world = world;
            SetDirectionSynonyms(Name);
            
        }

        private void SetDirectionSynonyms(string name)
        {
            int numberOfRow = directions.GetUpperBound(0) - directions.GetLowerBound(0) + 1;
            for (int i = 0; i < numberOfRow; i++)
            {
                foreach (var word in directions[i])
                {
                    if(word == name)
                    {
                        Synonyms = directions[i];
                    }
                }
            }
        }

        public void Go(Oobject secondaryDirectionOrObjectToGo)
        {
            Location locToGo = world.GetLocation(accessPoint.DestZone,accessPoint.DestLoc);
            player.CurrentLocation = locToGo;
        }
    }

    public class MainContainer: ConceptualObject, IInsideContainer
    {
        Inventory inventory;
        public MainContainer(string locationName){
            Rename(locationName);
            inventory = new Inventory(this);
        }

        public int GetInsideContainerSize()
        {
            return inventory.GetInventorySize();
        }

        public void Rename(string newName)
        {
            Name = newName + " - Void";
        }
    }

    public class ContainerAboveOnly : ConceptualObject, IAboveContainer
    {
        Inventory aboveInventory;
        public ContainerAboveOnly(string name)
        {
            aboveInventory = new Inventory(this);
            Name = name;
        }
    }
    
    public class Floor : ContainerAboveOnly
    {
        public Floor() : base("sol")
        {

        } 
    }

    internal interface IAboveContainer
    {
    }

    public interface IInsideContainer
    {
        //public Oobject GetFromInventory(Inventory inventory);
        int GetInsideContainerSize();
    }
}
