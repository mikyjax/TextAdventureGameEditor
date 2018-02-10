using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame
{
    public class AccessPoint
    {
        string Direction { get; set; }
        string DestLoc { get; set; }
        static public string[] DIRECTIONS = { "N","NE","E","SE","S","SW","W","NW" };
        

        public AccessPoint (string direction, string destLoc = "None")
        {
            Direction = direction;
            DestLoc = destLoc;
        }
    }
}
