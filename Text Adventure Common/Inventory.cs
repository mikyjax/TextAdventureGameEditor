using System.Collections.Generic;
namespace TextAdventureCommon
{
    public class Inventory
    {
        Oobject Parent;
        List<Oobject> objects;

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