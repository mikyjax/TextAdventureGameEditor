using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventureCommon;
namespace TextAdventureEngine
{
    static class Parser
    {
        static string sayNoVerbFound = "No verb was found in the sentence!";
        static string sayTooManyVerbs = "There are too much verb in this sentence...";
        static string sayNoDirectionFound = "No direction found in sentence";
        static string sayMoreThanOneDirectionFound = "More than one direction found";
        static string sayTooManyDirections = "Il y a beacoup trop de direction dans votre phrase ;)";
        

        

        static public Action GetAction(List<Oobject> availlableObjects, Sentence fullSentence)
        {
            String[] verbs = fullSentence.GetVerbs();
            // TO DO: GET ACTION FROM SENTENCE

            return null;
        }
    }
}
