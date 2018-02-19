using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
namespace TextAdventureCommon
{
    public class DataManager
    {
        public DataManager()
        {
        }

        public World LoadFile(string path)
        {
            World loadedWorld = new World();
            XDocument doc;
            doc = XDocument.Load(path);


            loadedWorld.zones = new Dictionary<string, Zone>();
            foreach (XElement element in doc.Root.Descendants("Zone"))
            {
                Zone zoneToAdd = new Zone(element.Attribute("Name").Value);
                loadedWorld.zones.Add(element.Attribute("Name").Value, zoneToAdd);
                Console.WriteLine(element.Attribute("Name").Value);

                foreach (XElement elementLoc in element.Descendants("Location"))
                {
                    bool transitionLocation = false;
                    if(elementLoc.Attribute("TransitionLocation").Value == "true")
                    {
                        transitionLocation = true;
                    }
                    bool startingRoom = false;
                    if(elementLoc.Attribute("SartingLocation").Value == "true")
                    {
                        startingRoom = true;
                    }
                    Location locToAdd = new Location(elementLoc.Attribute("Name").Value, elementLoc.Element("Description").Value,transitionLocation,startingRoom);
                    zoneToAdd.AddLocation(locToAdd);
                    Console.WriteLine("\t" + elementLoc.Attribute("Name").Value);
                    Console.WriteLine("\t" + elementLoc.Element("Description").Value);

                        List<AccessPoint> accessPointsToAdd = new List<AccessPoint>();
                        foreach(XElement elementAp in elementLoc.Descendants("AccessPoint"))
                        {
                        AccessPoint apToAdd = new AccessPoint(elementAp.Attribute("Dir").Value,
                            
                            elementAp.Attribute("ZoneDest").Value,
                            elementAp.Attribute("LocationDest").Value);
                            accessPointsToAdd.Add(apToAdd);
                            

                        Console.WriteLine("\t\t"+ elementAp.Attribute("Dir").Value + " : " 
                                + elementAp.Attribute("ZoneDest").Value+" --> " 
                                + elementAp.Attribute("LocationDest").Value);
                        }
                    locToAdd.AccessPoints = accessPointsToAdd;
                }
            }
            return loadedWorld;
        }
        public void SaveFile(World world,string path,string fileName)
        {
            string gameTitle = world.GameTitle;
            string completePath = path+fileName;
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
                                    select new XElement("Location", new XAttribute("Name", Location.Title), new XAttribute("SartingLocation", Location.StartingLocation), new XAttribute("TransitionLocation", Location.TransitionLocation),
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

            xmlDocument.Save(completePath);
        }
        public GameFileAndTitle GetAvailableGames(string path)
        {
            XDocument doc = XDocument.Load(path);
            string gameTitle = doc.Root.Attribute("Name").Value.ToString();
            string fileName = doc.Root.Attribute("FileName").Value.ToString();
            GameFileAndTitle game = new GameFileAndTitle(gameTitle, fileName);
            return game;
        }
        public  string GetGamePath(string _directory,string _gameTitle)
        {
            string gameTitle = _gameTitle;
            string path = "";
            string directory = _directory;
            List<GameFileAndTitle> games = new List<GameFileAndTitle>();
            games.Add(GetAvailableGames(directory));

            foreach (GameFileAndTitle game in games)
            {
                if(game.Title == gameTitle)
                {
                    path = directory + game.FileName;
                }
            }

            return path;
        }
        public bool IsDirectoryEmpty (string dirName)
        {
            string[] fileName = Directory.GetFileSystemEntries(dirName);
            if(fileName.Length > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public List<GameFileAndTitle> GetListOfGames(string directory)
        {
            List<GameFileAndTitle> games = new List<GameFileAndTitle>();
            string[] fileNames = Directory.GetFileSystemEntries(directory);
            foreach (string fileNamePath in fileNames)
            {
                games.Add(GetAvailableGames(fileNamePath));
            }
            return games;
        }

    }
    
}
