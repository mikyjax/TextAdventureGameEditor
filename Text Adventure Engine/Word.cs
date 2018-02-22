using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventureCommon;

namespace TextAdventureEngine
{
    public abstract class Word
    {
        public static string[] synonyms { get; set; }
    }

    
    public abstract class Verb : Word
    {
        List<Ooject> objects; //a direction is an object
        abstract public bool tryExecute();
        protected Player player;
    }

    public class Go : Verb
    {
       List < DirectionObject > directionObjects;
        public  Go (Player player=null) 
        {
            this.player = player;
            synonyms = new string[] {"go","move","aller","diriger","déplacer" };
            directionObjects = new List<DirectionObject>();
        }

        public override bool tryExecute()
        {
            if (directionObjects.Count() > 1)
            {
                Console.WriteLine("More than one Direction, not implemented yet");
                return false;
            }else if (directionObjects.Count() < 1)
            {
                Console.WriteLine("An error occured... no direction oject found");
                return false;
            }
            else
            {
                DirectionObject dirObject = directionObjects[0] as DirectionObject;
                player.GoToNextLocation(dirObject.accessPoint);
                return true;
            }
            
        }

        internal void AddDirectionObject(DirectionObject directionObject)
        {
            directionObjects.Add(directionObject);
        }
    }
}
