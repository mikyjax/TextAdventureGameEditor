using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureCommon
{
    public abstract class Oobject
    {
        public static int IdCounter { get; set; }

        public string Name { get; set; }
        public int Id { get; set; }
        public string[] Synonyms { get; set; }
        public Genre[] GenreSynonyms { get; set; }
        public Inventory ParentInventory;

        public bool HasAboveContainer { get; set; }
        public bool HasInsideContainer { get; set; }
        public bool HasUnderContainer { get; set; }

        public Inventory aboveInventory { get; set; }
        public Inventory insideInventory { get; set; }
        public Inventory underInventory { get; set; }

        public Oobject(Inventory parentInventory)
        {
            ParentInventory = parentInventory;
            HasAboveContainer = false;
            HasInsideContainer = false;
            HasUnderContainer = false;
            Id = IdCounter++;
        }

    }
    public abstract class ConceptualObject : Oobject
    {
        public  ConceptualObject(Inventory parentInventory)  : base(parentInventory: parentInventory)
        {

        }
    }
    public abstract class SolidObject : Oobject
    {
        public SolidObject(Inventory parentInventory) : base(parentInventory: parentInventory)
        {

        }
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
                directionsObjects.Add(new DirectionObject(player.CurrentLocation.Void.insideInventory,player,world,accessPoint));
            }

            return directionsObjects;
        }

        public DirectionObject (Inventory parentInventory,Player player,World world,AccessPoint accessPoint) : base(parentInventory: parentInventory)
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
    public class VoidContainer : ConceptualObject
    {
        public VoidContainer (Inventory parentInventory)  : base(parentInventory: parentInventory)
        {
            Synonyms = new string[] { "void" };
            GenreSynonyms = new Genre[] { Genre.masuclin };

            HasInsideContainer = true;
            insideInventory = new Inventory(this);
        }
    }
    public class FloorContainer : SolidObject
    {
        public FloorContainer(Inventory parentInventory) : base(parentInventory: parentInventory)
        {
            Synonyms = new string[]     {"sol"              };
            GenreSynonyms = new Genre[] { Genre.masuclin    };

            HasAboveContainer = true;
            aboveInventory = new Inventory(this);
        } 
    }

    public interface IGoToAble
    {

        void Go(Oobject secondaryDirectionOrObjectToGo);
    }
}
