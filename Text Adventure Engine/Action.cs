using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureCommon;
namespace TextAdventureEngine
{
    abstract class Action
    {
        public static string sayThereIsNothingThere = "Il n'y a rien là-bas.";


        public Player Player { get; set; }
        public World World { get; set; }

        public Action(Player player, World world)
        {
            Player = player;
            World = world;
        }

        public abstract void Execute();
        
    }
    class GoAction : Action
    {
        string direction = "";
        private AccessPoint accessPointToUse;
        public GoAction(Player player, World world) : base(player: player, world: world)
        {

        }

        public  override void Execute()
        {
            accessPointToUse = Player.CurrentLocation.GetAccessPoint(direction);
            if(accessPointToUse != null){
                Player.GoToNextLocation(accessPointToUse);
            }
            else
            {
                Display.TextAndReturn(sayThereIsNothingThere);
            }
            
        }
    }

}
