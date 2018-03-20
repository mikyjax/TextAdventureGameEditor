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
        static string sayNoVerbFound = "Il n'y a pas de verbe dans votre phrase";
        static string sayTooManyVerbs = "Il y a trop de verbes dans cette phrase...";
        static string sayNoDirectionFound = "Aucune directions cohérente n'a été trouvée dans votre phrase";
        static string sayTooManyDirections = "Il y a beacoup trop de direction dans votre phrase...";
        static string sayWhereDoYouWantToGo = "Wow... vous voulez aller où???";
        static string sayIfYouWantToQuit = "Si vous voulez quitter le jeu, ne tapez que 'quitter' si vous souhaitez quitter la pièce entrez une direction";

        Player player;
        World world;
        Sentence sentence;
        public Parser(Player player, World world)
        {
            this.player = player;
            this.world = world;
        }
       

        

        public Action GetAction(List<Oobject> availlableObjects, Sentence fullSentence)
        {
            bool sentenceUnderstood = false;
            string playerInput;

            sentence = fullSentence;
            
            while (!sentenceUnderstood)
            {
                String[] verbs = sentence.GetVerbs();
                if(verbs.Length > 1)
                {
                    requestNewSentenceAndTellsProblem(sayTooManyVerbs);
                }

                else if (verbs.Length < 1)
                {
                    requestNewSentenceAndTellsProblem(sayNoVerbFound);
                }
                else
                {
                    string verb = verbs[0];
                    switch (verb)
                    {
                        case Go.ROOTVERB:
                            GoAction goAction =  TryToGo( availlableObjects);
                            if(goAction !=null)
                            {
                                return goAction;
                            }
                            break;
                        case Quit.ROOTVERB:
                            if (sentence.IsEmpty())
                            {
                                return null;
                            }
                            else
                            {
                                requestNewSentenceAndTellsProblem(sayIfYouWantToQuit);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return null;
        }

        private GoAction TryToGo(List <Oobject> availlableObjects)
        {
            GoAction goAction = null;
            string direction = sentence.GetDirection();
            List<Oobject> objectsToGo = sentence.GetObjectsInSentence(availlableObjects);


            switch (direction)
            {
                case Sentence.DIRECTION_NOT_EXISTING:
                    if(objectsToGo.Count == 1)
                    {
                        goAction = new GoAction(player, world, objectsToGo[0]);
                    }
                    else if(objectsToGo.Count > 1)
                    {
                        requestNewSentenceAndTellsProblem(sayWhereDoYouWantToGo);
                        
                    }
                    else
                    {
                        requestNewSentenceAndTellsProblem(sayNoDirectionFound);
                    }

                    break;
                case Sentence.TOO_MANY_DIRECTIONS:
                    requestNewSentenceAndTellsProblem(sayTooManyDirections);
                    break;
                default:
                    goAction = new GoAction(player, world, direction);
                    break;
            }
            return goAction;
        }

        public void requestNewSentenceAndTellsProblem(string problem)
        {
            Display.TextAndReturn(problem,2);
            string playerInput = Display.RequestPlayerInput();

            sentence = new Sentence(playerInput);
        }
    }
}
