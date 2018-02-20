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
        List<Object> objects; //a direction is an object
    }

    public class Go : Verb
    {
        public  Go () 
        {
            synonyms = new string[] {"go","move","aller","diriger","déplacer" };
        }
            
       
    }
}
