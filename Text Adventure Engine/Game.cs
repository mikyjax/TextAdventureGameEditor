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
        World world;
        Player player;

        DataManager dataManager;

        public Game()
        {
            dataManager = new DataManager();
            

            player = new Player(world);

        }

        public void Run()
        {
            Display.Clear();
            Display.TextAndReturn("Welcome in the game.");
            Display.RequestPlayerInput();

        }


    }
}
