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

        List<TextAdventureCommon.Object> objectsAround;
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

            Verb go = new Go();
            return go;
        }

        private void SearchAndFillOjectsAround()
        {
            objectsAround = new List<TextAdventureCommon.Object>();
            List<DirectionObject> dirObjects = GetAvailableDirectionObjects();
            objectsAround.AddRange(dirObjects);
        }

        private List <DirectionObject> GetAvailableDirectionObjects()
        {
            List<DirectionObject> dirObjects = new List<DirectionObject>();
            foreach (var accessPoint in player.CurrentLocation.AccessPoints)
            {
                dirObjects.Add(new DirectionObject(player, world, accessPoint));
            }
            return dirObjects;
        }
    }
}
