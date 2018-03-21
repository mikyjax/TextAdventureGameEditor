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
        private Dictionary<int, string> items = new Dictionary<int, string>();
        protected Dictionary<int, string> Items { get => items; set => items = value; }


        public virtual void DisplayMenuElements(string menuSentence = "")
        {
            int optionCount = 1;

            if(menuSentence != "")
            {
                Display.TextAndReturn(menuSentence,2);
            }

            foreach (var item in Items.Keys)
            {
                Display.Text(Items.Keys.ElementAt(optionCount - 1).ToString());
                Display.Text(" ");
                Display.TextAndReturn(Items.Values.ElementAt(optionCount - 1));
                optionCount++;
            }
            Display.TextAndReturn("");
        }
        public virtual string GetChoiceFromPlayerInput()
        {
            int playerChoice = 0;
            bool correctChoice = false;
            while (!correctChoice)
            {
                Display.TextAndReturn("");
                if (Int32.TryParse(Display.RequestPlayerInput(), out playerChoice) &&
                    playerChoice >= 1 &&
                    playerChoice <= Items.Count())
                {
                    Display.TextAndReturn("");
                    correctChoice = true;
                }
                else
                {
                    Display.TextAndReturn("");
                    Display.Text("Please, enter a number between 1 and ");
                    Display.TextAndReturn(Items.Count().ToString());
                    DisplayMenuElements();
                }

            }
            string playerChoiceString;
            Items.TryGetValue(playerChoice, out playerChoiceString);
            return playerChoiceString;
        }
    }

    public class MainMenu : Menu
    {
        DataManager dataManager ;
        public MainMenu(string [] menuChoices)
        {
            dataManager = new DataManager();
            int itemId = 1;
            
            if (!dataManager.IsDirectoryEmpty("Saves"))
            {
                Items.Add(itemId, menuChoices[1]);
                itemId++;
            }

            if (!dataManager.IsDirectoryEmpty("Games"))
            {
                Items.Add(itemId, menuChoices[0]);
                itemId++;
            }
            else
            {
                //throw new System.ArgumentException("No game Found in Games directory");
            }

            Items.Add(itemId, menuChoices[2]);
            itemId++;
        }
        
    }
    public class NewGameMenu : Menu
    {
        DataManager dataManager;
        List<GameInfos> games;

        public NewGameMenu()
        {
            dataManager = new DataManager();
            games = new List<GameInfos>();
            int itemId = 1;
            games = dataManager.GetListOfGames("Games");

            foreach (GameInfos item in games)
            {
                Items.Add(itemId, item.GameTitle);
                itemId++;
            }

        }

        
    }
    public class LoadGameMenu : Menu
    { 
        public LoadGameMenu(string[]SaveNames)
        {
           
            int itemId = 1;
            foreach (var saveName in SaveNames)
            {
                Items.Add(itemId, saveName);
                itemId++;
            }

        }
        public override void DisplayMenuElements(string menuSentence = "")
        {
            int optionCount = 1;

            if (menuSentence != "")
            {
                Display.TextAndReturn(menuSentence, 2);
            }

            foreach (var item in Items.Keys)
            {
                string fileToLoadWithoutXmlExtension = Items.Values.ElementAt(optionCount - 1);
                string [] nameSplitted = fileToLoadWithoutXmlExtension.Split('.');
                fileToLoadWithoutXmlExtension = nameSplitted[0];

                Display.Text(Items.Keys.ElementAt(optionCount - 1).ToString());
                Display.Text(" ");
                Display.TextAndReturn(fileToLoadWithoutXmlExtension);
                optionCount++;
            }
            Display.TextAndReturn("");
        }

    }
}
