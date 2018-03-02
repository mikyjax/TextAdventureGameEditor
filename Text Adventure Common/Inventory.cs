using System.Collections.Generic;
namespace TextAdventureCommon
{
    public class Inventory
    {
        Oobject Parent;
        List<Oobject> objects;
        public float WeightCapacity { get; set; }

        public Inventory(Oobject parent)
        {
            Parent = parent;
            objects = new List<Oobject>();
        }

        public int GetInventorySize()
        {
            return objects.Count;
        }
    }
}