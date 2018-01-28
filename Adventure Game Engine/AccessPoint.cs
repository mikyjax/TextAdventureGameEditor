using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game_Engine
{
    class AccessPoint
    {
        string Direction { get; set; }
        string DestLoc { get; set; }
        
        public AccessPoint (string direction, string destLoc = "None")
        {
            Direction = direction;
            DestLoc = destLoc;
        }
    }
}
