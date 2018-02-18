using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventureCommon;
namespace TextAdventureEngine
{
    public class Menu
    {
       
        const string newGame = "New Game";
        const string loadGame = "Load Game";
        const string exitGame = "Exit Game";
        DataManager dataManager ;
        World world;
        Dictionary<int, string> items = new Dictionary<int, string>();

        public Menu(DataManager _dataManager, World _world)
        {
            this.dataManager = _dataManager;
            this.world = _world;
            int itemId = 1;
            world = dataManager.LoadFile("Games\\test game.xml");
            return;
            if (!dataManager.IsDirectoryEmpty("Saves"))
            {
                items.Add(itemId, loadGame);
                itemId++;
            }

            if (!dataManager.IsDirectoryEmpty("Games"))
            {
                items.Add(itemId, newGame);
                itemId++;
            }
            else
            {
                //throw new System.ArgumentException("No game Found in Games directory");
            }

            items.Add(itemId, exitGame);
            itemId++;
        }

        //public Menu(World _world,DataManager _dataManager)
        //{
        //    dataManager = _dataManager;
        //    world = _world;
            
        //    int itemId = 1;
        //    if (!dataManager.IsDirectoryEmpty("Saves"))
        //    {
        //        items.Add(itemId, loadGame);
        //        itemId++;
        //    }

        //    if (!dataManager.IsDirectoryEmpty("Games"))
        //    {
        //        items.Add(itemId, newGame);
        //        itemId++;
        //    }
        //    else
        //    {
        //        //throw new System.ArgumentException("No game Found in Games directory");
        //    }

        //    items.Add(itemId, exitGame);
        //    itemId++;
        //}

        

        public void Show()
        {
            int playerChoice = 0;
            bool correctChoice = false;
            while (!correctChoice)
            {
                Display.TextAndReturn("");
                DisplayMainMenuElementsChoices();
                if (Int32.TryParse(Display.RequestPlayerInput(), out playerChoice) &&
                    playerChoice >=1 &&
                    playerChoice <=items.Count())
                {
                    Display.TextAndReturn("");
                    correctChoice = true;
                }
                else
                {
                    Display.TextAndReturn("");
                    Display.Text("Please, enter a number between 1 and ");
                    Display.TextAndReturn(items.Count().ToString());
                }
                
            }
            string playerChoiceString;
            items.TryGetValue(playerChoice, out playerChoiceString);
            ExecuteChoice(playerChoiceString);
        }

        private void ExecuteChoice(string playerChoice)
        {
            
            switch (playerChoice)
            {
                case newGame:
                    CreateANewGame();
                    break;
                case loadGame:
                    Console.WriteLine("Load Game");
                    break;
                case exitGame:
                    Console.WriteLine("exiting");
                    break;

                default:
                    Console.WriteLine("choice not existing");
                    break;
            }
        }

        private  void CreateANewGame()
        {
            Display.ClearConsole();
             
            Display.TextAndReturn("Give a name to your New Game",2);
            string fileName = Display.RequestPlayerInput();
            
            fileName = fileName + ".xml";

            world = dataManager.LoadFile("Games\\test game.xml");           

        }

        private void DisplayMainMenuElementsChoices()
        {
            int optionCount = 1;
            
            foreach (var item in items.Keys)
            {
                Display.Text(items.Keys.ElementAt(optionCount - 1).ToString());
                Display.Text(" ");
                Display.TextAndReturn(items.Values.ElementAt(optionCount - 1));
                optionCount++;
            }
            Display.TextAndReturn("");
        }
    }
}
