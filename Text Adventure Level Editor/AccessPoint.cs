using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame
{
    public class AccessPoint
    {
        public string Direction { get; set; }
        public string DestLoc { get; set; }
        public string DestZone { get; set; }

        static public string[] DIRECTIONS = { "N","NE","E","SE","S","SW","W","NW" };
        

        public AccessPoint (string direction,string destZone, string destLoc = "None")
        {
            Direction = direction;
            DestLoc = destLoc;
            DestZone = destZone;
        }

        public static string ReturnOppositeDirection(string dir)
        {
            int indexToGo = 0;
            int dirIndex = 0;
            for (int i=0; i<DIRECTIONS.Length;i++)
            {
                
                if (DIRECTIONS[i] == dir)
                {
                    dirIndex = i;
                }
            }
            indexToGo = dirIndex - 4;
            if(indexToGo < 0)
            {
                indexToGo = DIRECTIONS.Length  + indexToGo;
            }
            return DIRECTIONS[indexToGo];
            
        }
    }
}
