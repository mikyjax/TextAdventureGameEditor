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
        //changes
        //DEBUG VARIABLES
        bool autoLoad = true;
        string gameToLoad = "test 3 - test 3 Save.xml";
        //$DEBUG VARIABLES

        World world;
        Player player;
        DataManager dataManager;
        GameFileAndTitle currentGame;
        public List<Oobject> AvaillableObjects { get; set; }

        string saveName;
        bool exitGame = false;

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
            string playerChoice = "";
            Display.ClearConsole();
            if (!autoLoad)
            {
                playerChoice = PresentMainMenu();
            }
            else
            {
                LoadWorldAndPlayerFromSavedFile(gameToLoad);
            }

            if(playerChoice != EXIT_GAME)
            {
                ExecuteMainMenuChoice(playerChoice);
                Location currentLocation = player.CurrentLocation;
                Location previousLocation = null;
                Display.ClearConsole();
                while (!exitGame)
                {
                    currentLocation = player.CurrentLocation;

                    AvaillableObjects = currentLocation.GetAllAvaillableObjects();

                    if (currentLocation != previousLocation) {
                        previousLocation = currentLocation;
                        Display.ClearConsole();
                        Display.TextUnderlinedAndReturn(currentLocation.Title, 3);
                        Display.TextAndReturn(currentLocation.Description, 2);
                    }

                    string playerInput = Display.RequestPlayerInput();
                    Sentence sentence = new Sentence(playerInput);
                    Parser parser = new Parser(player, world);
                    Action action = parser.GetAction(AvaillableObjects,sentence);
                    if (action != null)
                    {
                        action.Execute();
                    }
                    else
                    {
                        exitGame = true;
                    }
                               
                }
            }
        }

        

        private string PresentMainMenu()
        {
            string playerChoice;
            Display.TextUnderlinedAndReturn("Welcome in the game.", 3);
            Menu mainMenu = new MainMenu(menuChoices);
            mainMenu.DisplayMenuElements("What would you like to to?");
            playerChoice = mainMenu.GetChoiceFromPlayerInput();
            return playerChoice;
        }
        private void ExecuteMainMenuChoice(string playerChoice)
        {
            switch (playerChoice)
            {
                case NEW_GAME:
                    CreateNewGame();
                    break;
                case LOAD_GAME:
                    LoadExistingGame();
                    break;
                case EXIT_GAME:
                    exitGame = true;
                    break;

                default:
                    Console.WriteLine("choice not existing");
                    break;
            }
        }
        private void LoadExistingGame()
        {
            string[] fileNames = DataManager.GetSaveFile ("Saves");
            string[] validFiles = DataManager.GetValidFiles(@"Saves\",fileNames);
            if(validFiles.Length > 1)
            {
                //show menu and select SaveGame
                Menu loadMenu = new LoadGameMenu(validFiles);
                Display.ClearConsole();
                loadMenu.DisplayMenuElements("Which game do you want to load?");
                string playerChoice = loadMenu.GetChoiceFromPlayerInput();
                LoadWorldAndPlayerFromSavedFile(playerChoice);
            }
            else
            {
                //automatically load the only file.
                LoadWorldAndPlayerFromSavedFile(validFiles[0]);
            }
        }
        private void LoadWorldAndPlayerFromSavedFile(string validFileName)
        {
            string worldFileName = DataManager.GetWorldFileName(@"Saves\" + validFileName);
            world = dataManager.LoadFile(@"Saves\" + worldFileName);
            //load player save.
            player = new Player(world);
        }
        private  void CreateNewGame()
        {

            Menu newGameMenu = new NewGameMenu();
            Display.ClearConsole();
            newGameMenu.DisplayMenuElements("Please select the game you want to play :");
            string gameTitle = newGameMenu.GetChoiceFromPlayerInput();
            string path ="";
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
            if (path != "")// changed from null to ""
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
                    string completeSaveGameName = gameTitle + " - " + saveGameName + " World.xml";
                    if (IsSaveGameNameValid(saveGameName))
                    {
                        player = new Player(world);
                        world.GameTitle = gameTitle;
                        dataManager.SaveFile(world, @"Saves\", completeSaveGameName);
                        dataManager.SavePlayerGame(player, @"Saves\", currentGame, saveGameName, completeSaveGameName);
                        correctName = true;
                    }
                }
                else
                {
                    Display.TextAndReturn("Invalid input");
                }
            }
        }
        private static bool IsSaveGameNameValid(string saveGameName)
        {
            if (File.Exists(@"Saves\" + saveGameName))
            {
                Display.TextAndReturn("");
                Display.TextAndReturn("This save name already exist", 1);
                return false;
            }
            else if (saveGameName.Contains("Save"))
            {
                Display.TextAndReturn("");
                Display.TextAndReturn("The word \"Save\" cannot be use for a save file", 1);
                return false;
            }
            else if (saveGameName.Contains('.'))
            {
                Display.TextAndReturn("");
                Display.TextAndReturn("The character \".\" isn't allowed for a save file", 1);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
