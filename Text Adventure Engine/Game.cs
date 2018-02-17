using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventureCommon;
namespace TextAdventureEngine
{
    class Game
    {
        public World world  = new World();
        Player player;

        DataManager dataManager;

        public Game()
        {
            dataManager = new DataManager();
            

            player = new Player(world);

        }

        public void Run()
        {
            int menuChoice = 0;
            Display.ClearConsole();
            Display.TextUnderlinedAndReturn("Welcome in the game.",3);
            Display.TextAndReturn("What would you like to do?");
            MainMenu mainMenu = new MainMenu(world);
            mainMenu.Show();
            //List <Location> locs = world.GetAllLocations();
            Display.RequestPlayerInput();

        }


    }
}
