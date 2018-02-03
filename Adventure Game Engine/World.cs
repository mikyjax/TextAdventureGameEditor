using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game_Engine
{
    public class World
    {
        
        public Dictionary<string,Zone> zones { get; set; }


        public void Populate()
        {
            //currently takes those datas to create the world, TODO: replace this by loading from XML
        }
        public void Create()
        {
            zones = new Dictionary<string, Zone>();
        }
    }
}
