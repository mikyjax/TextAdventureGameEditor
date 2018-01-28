using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Adventure_Game_Engine
{
    class DataManager
    {

        static public void LoadXmlFile(string path)
        {
            XDocument doc = XDocument.Load(path);
        }
        static public void SaveXmlFile(List<Location> locations,string path)
        {
            XDocument doc = new XDocument();

            doc.Save(path);
           
        }

    }
    
}
