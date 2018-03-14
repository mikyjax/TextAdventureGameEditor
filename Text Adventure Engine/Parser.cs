using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventureCommon;
namespace TextAdventureEngine
{
    class Parser
    {
        static string sayNoVerbFound = "No verb was found in the sentence!";
        static string sayTooManyVerbs = "There are too much verb in this sentence...";
        static string sayNoDirectionFound = "No direction found in sentence";
        static string sayMoreThanOneDirectionFound = "More than one direction found";
        static string sayNothingThere = "Il n'y a rien la bas...";
        static string sayTooManyDirections = "Il y a beacoup trop de direction dans votre phrase ;)";
        List<TextAdventureCommon.Oobject> objectsAround;
        World world;
        Player player;

        

        public Parser (World world, Player player)
        {
            this.player = player;
            this.world = world;

        }

        public Verb GetAction(Sentence fullSentence)
        {
            String[] verbs = fullSentence.GetVerbs();
            SearchAndFillOjectsAround();

            if (verbs.Length > 0)
            {
                if (verbs.Length > 1)
                {
                    Display.TextAndReturn(sayTooManyVerbs);
                }
                else
                {
                    //we have the verb. we need to create an action related to it.
                    string verb = verbs[0];
                    switch (verb)
                    {
                        case "go":
                            //TO DO : look for direction object.
                            Go go = new Go(player);
                            string[] directionsToGo = fullSentence.GetDirections();
                            if(directionsToGo.Length < 1)
                            {
                                Display.TextAndReturn(sayNoDirectionFound,2);
                            }else if(directionsToGo.Length == 1)
                            {
                                List<DirectionObject> directionOjects = new List<DirectionObject>();
                                //fill a go verb with AVAILABLE directions.
                                foreach (var direction in directionsToGo)
                                {
                                    if (IsRootWordExistingInOjectAround(direction))
                                    {
                                        AccessPoint accessPoint;
                                        foreach(AccessPoint ap in player.CurrentLocation.AccessPoints)
                                        {
                                            if (ap.Direction.ToLower() == direction)
                                            {
                                                accessPoint = ap;
                                                DirectionObject dirObject = new DirectionObject(player.CurrentLocation.Void.insideInventory, player, world, ap);
                                                go.AddDirectionObject(dirObject);
                                                return go;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Display.TextAndReturn(sayNothingThere,2);
                                    }
                                }
                            }else if(directionsToGo.Length > 2)
                            {
                                Display.TextAndReturn(sayTooManyDirections,2);
                            }
                            else
                            {
                                Display.TextAndReturn(sayMoreThanOneDirectionFound,2);
                            }

                            break;
                        default:
                            break;
                    }

                }
            }
            else
            {
                Display.TextAndReturn(sayNoVerbFound);
            }


            return null;
        }

        private void SearchAndFillOjectsAround()
        {
            objectsAround = new List<Oobject>();
            List<DirectionObject> dirObjects = GetAvailableDirectionObjects();
            objectsAround.AddRange(dirObjects);
        }

        private List <DirectionObject> GetAvailableDirectionObjects()
        {
            List<DirectionObject> dirObjects = new List<DirectionObject>();
            foreach (var accessPoint in player.CurrentLocation.AccessPoints)
            {
                dirObjects.Add(new DirectionObject(player.CurrentLocation.Void.insideInventory, player, world, accessPoint));
            }
            return dirObjects;
        }
        private bool IsRootWordExistingInOjectAround(string rootWord) {
            foreach (var obj in objectsAround)
            {
                if (obj.Synonyms[0] == rootWord)
                    return true;
            }
            return false;
        }

    }
}
