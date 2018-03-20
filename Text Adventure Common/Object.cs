using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TextAdventureCommon
{
    public abstract class Oobject
    {
        public  const string FixedObjectType = "Fixed Object";
        public const string AccessPointObjectType = "Access Point Object";
        public const string FurnitureObjectType = "Furniture Object";
        public const string FloorObjectType = "Floor Object";
        public const string CeilingObjectType = "Ceiling Object";
        public const string WallObjectType = "Wall Object";

        protected string sayOnTryToGo = "Vous voulez aller dans quoi??";

        public static string[] ObjectTypeStrings = new string[] { FixedObjectType, AccessPointObjectType, FurnitureObjectType,FloorObjectType,CeilingObjectType,WallObjectType };

        public static int IdCounter { get; set; }
        public static string newObjectName = "New Object";
        public string Name { get; set; }
        public int Id { get; set; }
        public string[] Synonyms { get; set; }
        public Genre[] GenreSynonyms { get; set; }
        public Inventory ParentInventory;

        public bool HasAboveContainer { get; set; }
        public bool HasInsideContainer { get; set; }



        public  string SayOnTryToGo()
        {
            return sayOnTryToGo;
        }

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
            Synonyms = new string[] { Name };
        }
        static public Oobject CopyObject(Oobject obj,Inventory copyiedParentInventory)
        {
            Oobject copyiedObject;
            if (obj is AccessPointObject)
            {
                copyiedObject = new AccessPointObject(copyiedParentInventory);
                AccessPointObject apRealObjet = (AccessPointObject)obj;
                AccessPointObject apCopyiedObj = (AccessPointObject)copyiedObject;
                apCopyiedObj.Direction = apRealObjet.Direction;
            }else if (obj is FloorContainer)
            {
                copyiedObject = new FloorContainer(copyiedParentInventory);
            }
            else if (obj is WallContainer)
            {
                copyiedObject = new WallContainer(copyiedParentInventory);
            }
            else if (obj is CeilingContainer)
            {
                copyiedObject = new CeilingContainer(copyiedParentInventory);
            }
            else
            {
                copyiedObject = new SolidObject(copyiedParentInventory);
                
            }
            
            copyiedObject.Id = obj.Id;
            copyiedObject.Name = obj.Name;

            List<String> synonyms = new List<string>();
            synonyms.AddRange(synonyms);
            obj.Synonyms = synonyms.ToArray();

            List<Genre> GenreSynonyms = new List<Genre>();
            GenreSynonyms.AddRange(GenreSynonyms);
            obj.GenreSynonyms = GenreSynonyms.ToArray();

            copyiedObject.HasAboveContainer = obj.HasAboveContainer;
            copyiedObject.HasInsideContainer = obj.HasInsideContainer;
            copyiedObject.HasUnderContainer = obj.HasUnderContainer;

            copyiedObject.sayOnTryToGo = obj.sayOnTryToGo;
            


            return copyiedObject;
        }

        public void CreateInventories()
        {
            if (HasAboveContainer && aboveInventory == null)
            {
                aboveInventory = new OnInventory(this);
            }
            if (HasInsideContainer && insideInventory == null)
            {
                insideInventory = new InsideInventory(this);
            }
            if (HasUnderContainer && underInventory == null)
            {
                underInventory = new UnderInventory(this);
            }
        }

        internal object GetObjectType()
        {
            if(this is AccessPointObject)
            {
                return AccessPointObjectType;
            }

            else if(this is FloorContainer)
            {
                return FloorObjectType; 
            }

            else if(this is CeilingContainer)
            {
                return CeilingObjectType;
            }

            else if(this is WallContainer)
            {
                return WallObjectType;
            }
            return FurnitureObjectType;
        }

        internal static String GetDirection(Oobject currentObject)
        {
            AccessPointObject apObj = (AccessPointObject)currentObject;
            return apObj.Direction;
        }

        public  bool IsWordExistingInSynonyms(string word)
        {
            foreach (var synonym in Synonyms)
            {
                if(word.ToLower() == synonym.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
    }

    

    public abstract class ConceptualObject : Oobject
    {
        public  ConceptualObject(Inventory parentInventory)  : base(parentInventory: parentInventory)
        {
        

        }
    }
    public  class SolidObject : Oobject
    {
        public SolidObject(Inventory parentInventory) : base(parentInventory: parentInventory)
        {
            Synonyms = new String[] { Name };
        }
    }
    public class FixedObject : SolidObject
    {
        public FixedObject(Inventory parentInventory) : base(parentInventory: parentInventory)
        {

        }
    }
    public class AccessPointObject : SolidObject , IGoToAble
    {
        public string Direction { get; set; }
        public AccessPointObject(Inventory parentInventory) : base(parentInventory: parentInventory)
        {
            Direction = "NONE";
        }

        public void Go(Oobject secondaryDirectionOrObjectToGo)
        {
            Location currentLocation = getRootLocation(this);

        }

        private Location getRootLocation(Oobject obj)
        {
            Location rootLocation = null;
            Oobject parentObject = null;
            Oobject currentObject = obj;
            while(parentObject is VoidContainer == false)
            {
                currentObject = getParentObject(currentObject);
            }
            VoidContainer voidObject = (VoidContainer)parentObject;
            return voidObject.Location;
        }

        private Oobject getParentObject(Oobject currentObject)
        {
            Oobject parentObject = currentObject.ParentInventory.Parent;
            return parentObject;
        }
    }
    public class DirectionObject : ConceptualObject 
    {

        public AccessPoint accessPoint;

        public static string[][] directions = new string[][]
        {
            new string[] {"n","north","nord"},
            new string[] {"ne","north-east","north east","nord est","nordest","nord-est"},
            new string[] {"s","south","sud"},
            new string[] {"se", "south-east", "south east", "sud est","sudest","sud-est"},
            new string[] {"e","east","est","l'est"},
            new string[] {"sw", "south-west", "south west", "sud ouest","sudouest","sud-ouest"},
            new string[] {"w","west","ouest","l'ouest"},
            new string[] {"nw", "north-west", "north west", "nord ouest","nordouest","nor-ouest"},
        };

        public  List<DirectionObject> GetAvailableDirObjects(List<AccessPoint> accessPoints)
        {
            List<DirectionObject> directionsObjects = new List<DirectionObject>();

            foreach (var accessPoint in accessPoints)
            {
                directionsObjects.Add(new DirectionObject(null, accessPoint));
            }

            return directionsObjects;
        }

        public DirectionObject (Inventory parentInventory ,AccessPoint accessPoint) : base(parentInventory: parentInventory)
        {
            this.accessPoint = accessPoint;
            Name = accessPoint.Direction.ToLower();
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

        public static bool isDirectionExisting(string concatenateDirection)
        {
            

            int numberOfRow = directions.GetUpperBound(0) - directions.GetLowerBound(0) + 1;
            for (int i = 0; i < numberOfRow; i++)
            {
                if (directions[i][0] == concatenateDirection)
                    return true;
            }

            return false;
        }
    }
    public class VoidContainer : ConceptualObject
    {
        public Location Location { get; set; }
        public VoidContainer (Inventory parentInventory, Location location)  : base(parentInventory: parentInventory)
        {
            Location = location;
            Synonyms = new string[] { "void" };
            GenreSynonyms = new Genre[] { Genre.masuclin };
            Name = "Void";
            HasAboveContainer = false;
            HasInsideContainer = true;
            HasUnderContainer = false;
            insideInventory = new InsideInventory(this);
        }
        public List <Oobject>  GetAllChildrenObjects()
        {
            List<Oobject> childrenObjects = new List<Oobject>();

            foreach (var obj in insideInventory.objects)
            {
                //
            }

            return childrenObjects;
        }
    }
    public class FloorContainer : SolidObject
    {
        public FloorContainer(Inventory parentInventory) : base(parentInventory: parentInventory)
        {
            Synonyms = new string[]     {"sol"              };
            Name = "sol";
            GenreSynonyms = new Genre[] { Genre.masuclin    };

            sayOnTryToGo = "Vous compter creuser??";

            HasAboveContainer = true;
            aboveInventory = new OnInventory(this);
        } 
    }
    public class WallContainer : SolidObject
    {
        public WallContainer(Inventory parentInventory) : base(parentInventory: parentInventory)
        {
            Synonyms = new string[] { "mur"               };
            Name = "mur";
            GenreSynonyms = new Genre[] { Genre.masuclin };

            sayOnTryToGo = "Oui de fait, je pense que vous allez dans le mur...";

            HasAboveContainer = true;
            aboveInventory = new OnInventory(this);
        }
    }
    public class CeilingContainer : SolidObject
    {
        public CeilingContainer(Inventory parentInventory) : base(parentInventory: parentInventory)
        {
            Synonyms = new string[] { "plafond"          };
            Name = "plafond";
            GenreSynonyms = new Genre[] { Genre.masuclin };

            sayOnTryToGo = "Mais bien sûr...";

            HasUnderContainer = true;
            underInventory = new UnderInventory(this);
        }
    }

    public interface IGoToAble
    {

        void Go(Oobject secondaryDirectionOrObjectToGo);
    }
}
