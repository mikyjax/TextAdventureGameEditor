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
        private Oobject objectToGo;
        public GoAction(Player player, World world, String direction) : base(player: player, world: world)
        {
            this.direction = direction;
        }

        public GoAction(Player player, World world, Oobject obj) : base(player: player, world: world)
        {
            if(obj is AccessPointObject)
            {
                AccessPointObject apObj = (AccessPointObject)obj;
                apObj.Direction = apObj.Direction;
            }
            else
            {
                objectToGo = obj;
            }
           
        }

        public  override void Execute()
        {
            accessPointToUse = Player.CurrentLocation.GetAccessPoint(direction);
            if(objectToGo != null)
            {
                Display.TextAndReturn (objectToGo.SayOnTryToGo());
                return;
            }

            if (accessPointToUse != null){
                Player.GoToNextLocation(accessPointToUse);
            }
            else
            {
                Display.TextAndReturn(sayThereIsNothingThere);
            }
            
        }
    }

}
