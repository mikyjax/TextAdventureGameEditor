using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventureCommon;
using System.IO;
namespace TextAdventureEngine
{
    public class Game
    {
        World world;
        Player player;
        DataManager dataManager;

        string saveName;
        GameFileAndTitle currentGame;

        //main menu choices
        const string NEW_GAME = "New Game";
        const string LOAD_GAME = "Load Game";
        const string EXIT_GAME = "Exit Game";
        String[] menuChoices = {NEW_GAME,LOAD_GAME,EXIT_GAME };

        public Game()
        {
            world = new World();
            dataManager = new DataManager();
            world.Create();
        }

        public void Run()
        {
            Display.ClearConsole();
            Display.TextUnderlinedAndReturn("Welcome in the game.",3);
            Menu mainMenu = new MainMenu(menuChoices);
            mainMenu.DisplayMenuElements("What would you like to to?");
            string playerChoice = mainMenu.GetChoiceFromPlayerInput();
            
            if(playerChoice != EXIT_GAME)
            {
                ExecuteMainMenuChoice(playerChoice);
                //world = dataManager.LoadFile("Games\\test game.xml");
                List<Location> locs = world.GetAllLocations();
                Display.RequestPlayerInput();
                List<Location> allLocs = world.GetAllLocations();

            }
        }

        private void ExecuteMainMenuChoice(string playerChoice)
        {
            switch (playerChoice)
            {
                case NEW_GAME:
                    CreateNewGame();
                    break;
                case LOAD_GAME:
                    Console.WriteLine("Load Game");
                    break;
                case EXIT_GAME:
                    Console.WriteLine("exiting");
                    break;

                default:
                    Console.WriteLine("choice not existing");
                    break;
            }
        }

        private  void CreateNewGame()
        {

            Menu newGameMenu = new NewGameMenu();
            Display.ClearConsole();
            newGameMenu.DisplayMenuElements("Please select the game you want to play :");
            string gameTitle = newGameMenu.GetChoiceFromPlayerInput();
            string path = "";
            List<GameFileAndTitle> games = new List<GameFileAndTitle>();
            games = dataManager.GetListOfGames("Games");
            foreach (var game in games)
            {
                if(game.Title == gameTitle)
                {
                    path = "Games\\" + game.FileName;
                    currentGame = game;
                }
            }
            if (path != null)
            {
                CreateNewSaveGameFromGame(gameTitle, path);
            }
            else
            {
                Console.WriteLine("File not found in directory");
            }
        }
        private void CreateNewSaveGameFromGame(string gameTitle, string path)
        {
            world = dataManager.LoadFile(path);
            bool correctName = false;
            Display.ClearConsole();
            while (!correctName)
            {
                Display.TextAndReturn("Please, choose a name for your saved Game :", 2);
                string saveGameName = Display.RequestPlayerInput();

                if (!string.IsNullOrWhiteSpace(saveGameName))
                {
                    saveGameName = saveGameName.Trim();
                    saveGameName = gameTitle + " - " + saveGameName + ".xml";

                    //check if that save is already existing
                    if (File.Exists(@"Saves\" + saveGameName))
                    {
                        Display.TextAndReturn("");
                        Display.TextAndReturn("This save name already exist", 1);
                    }
                    else
                    {
                        world.GameTitle = gameTitle;
                        saveName = saveGameName;
                        dataManager.SaveFile(world, @"Saves\", saveGameName);
                        correctName = true;
                    }
                }
                else
                {
                    Display.TextAndReturn("Invalid input");
                }
            }
        }
    }
}
