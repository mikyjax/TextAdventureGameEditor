using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextAdventureGame
{
    class DataManager
    {

        public World LoadFile(string fileName)
        {
            World loadedWorld = new World();
            string path = @"Games\" + fileName;
            XDocument doc;
            doc = XDocument.Load(path);

            var result = from q in doc.Descendants("World")
                         select new Zone
                         {
                             Name = q.Element("Zone").Attribute("Name").Value
                         };

            foreach(var Zone in result)
            {
                Console.WriteLine(Zone.Name);
            }

            foreach (XElement element in doc.Root.Descendants("Zone"))
            {
                Console.WriteLine(element.Attribute("Name").Value);
                foreach (XElement elementLoc in element.Descendants("Location"))
                {
                    Console.WriteLine("\t" + elementLoc.Attribute("Name").Value);
                    foreach(XElement elementAp in elementLoc.Descendants("AccessPoint"))
                    {
                        Console.WriteLine("\t\t"+ elementAp.Attribute("Dir").Value + " : " 
                            + elementAp.Attribute("ZoneDest").Value+" --> " 
                            + elementAp.Attribute("LocationDest").Value);
                    }
                }
            }


            return loadedWorld;
        }
        public void SaveFile(World world,string fileName)
        {
            string gameTitle = world.GameTitle;
            string path = @"Games\"+fileName;
            string[] ZonesNames = world.GetAllZonesNames();
            List <Zone> zones = world.GetAllZones();
            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                
                new XComment("Creating xml file from level editor"),
                
                new XElement("World", new XAttribute("Name", gameTitle), new XAttribute("FileName", fileName),

                from Zone in zones
                select new XElement("Zone", new XAttribute("Name", Zone.Name),
                                    new XElement("Locations",
                                    from Location in Zone.Locations
                                    select  new XElement("Location", new XAttribute("Name", Location.Title),
                                            new XElement("Description",Location.Description),
                                            new XElement("AccessPoints",
                                                from AccessPoint in Location.AccessPoints
                                                select new XElement("AccessPoint",new XAttribute("Dir",AccessPoint.Direction),
                                                                                  new XAttribute("ZoneDest", AccessPoint.DestZone),
                                                                                  new XAttribute("LocationDest", AccessPoint.DestLoc)
                                                                   )
                                                            ))
                                                  )
                                    )
                            )
                );

            xmlDocument.Save(path);
        }
        public Game  GetAvailableGames(string path)
        {
            XDocument doc = XDocument.Load(path);
            string gameTitle = doc.Root.Attribute("Name").Value.ToString();
            string fileName = doc.Root.Attribute("FileName").Value.ToString();
            Game game = new Game(gameTitle, fileName);
            return game;
        }
    }
    
}
