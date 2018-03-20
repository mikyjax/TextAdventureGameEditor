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
        List<Oobject> objects; //a direction is an object
        protected Player player;
    }

    public class Go : Verb
    {
       List < DirectionObject > directionObjects;
        public const   string ROOTVERB = "go";
        public  Go (Player player=null) 
        {
            this.player = player;
            synonyms = new string[] {"go","move","aller","diriger","déplacer" };
            directionObjects = new List<DirectionObject>();
        }
    }

    public class Quit : Verb
    {
        public const string ROOTVERB = "quit";
        public Quit()
        {
            synonyms = new String[] { "quit", "quitter" };
        }
    }
}
