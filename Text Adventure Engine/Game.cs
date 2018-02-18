using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventureCommon;
namespace TextAdventureEngine
{
    public class Game
    {
        World world;
        Player player;
        DataManager dataManager;
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
            Display.TextAndReturn("What would you like to do?");
            Menu mainMenu = new Menu(dataManager,world);
           // mainMenu.Show();
            //world = dataManager.LoadFile("Games\\test game.xml");
            List <Location> locs = world.GetAllLocations();
            Display.RequestPlayerInput();
            List<Location> allLocs =  world.GetAllLocations();

        }


    }
}
