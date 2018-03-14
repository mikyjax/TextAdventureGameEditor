﻿using System;
using System.Collections.Generic;
namespace TextAdventureCommon
{
    public abstract class Inventory
    {
        public Oobject Parent;
        public List<Oobject> objects;
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

        public void  Add(Oobject obj)
        {
                objects.Add(obj);
        }
        public bool IsObjectExisting(Oobject obj)
        {
            if (objects.Contains(obj))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Inventory CopyCompleteInventory(Oobject rootObject)
        {
            Oobject copyiedRootObject = Oobject.CopyObject(rootObject,null);
            Inventory copyiedInventory = new Inventory(copyiedRootObject);
            copyInventories(copyiedRootObject,rootObject);
            return copyiedInventory;
        }

        private static void copyInventories(Oobject copyiedObject,Oobject obj)
        {

            copyiedObject.aboveInventory = copyThisInventory(copyiedObject.HasAboveContainer, obj.aboveInventory, copyiedObject, obj);
            copyiedObject.insideInventory = copyThisInventory(copyiedObject.HasInsideContainer, obj.insideInventory, copyiedObject, obj);
            copyiedObject.underInventory = copyThisInventory(copyiedObject.HasUnderContainer, obj.underInventory, copyiedObject, obj);

        }

        private static Inventory copyThisInventory(bool hasInventory,Inventory inventoryToCopy,Oobject copyiedObjectParent,Oobject objReference)
        {
            if (hasInventory)
            {
                Inventory copyiedInventory = new Inventory(copyiedObjectParent);
                if(inventoryToCopy == null)
                {
                    return copyiedInventory;
                }
                foreach (var realObj in inventoryToCopy.objects)
                {
                    Oobject childObjectCopy = Oobject.CopyObject(realObj, copyiedInventory);
                    copyInventories(childObjectCopy, realObj);
                    copyiedInventory.Add(childObjectCopy);
                }
                return copyiedInventory;
            }
            else
            {
                return null;
            }
        }

        public void Remove(Oobject tempObject)
        {
            if (this.IsObjectExisting(tempObject))
            {
                objects.Remove(tempObject);
            }
        }
    }
    public class InsideInventory : Inventory
    {
        public InsideInventory (Oobject parent) : base ( parent : parent){
        }
    }
    public class OnInventory : Inventory
    {
        public OnInventory(Oobject parent) : base(parent: parent)
        {
        }
    }
    public class UnderInventory : Inventory
    {
        public UnderInventory(Oobject parent) : base(parent: parent)
        {
        }
    }
}