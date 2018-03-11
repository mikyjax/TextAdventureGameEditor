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

            loadedWorld.GameTitle = doc.Root.Attribute("Name").Value;

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
                    locToAdd.Zone = zoneToAdd;
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

        public static string[] GetValidFiles(string dirName,string[]filesToCheck)
        {
            List<string> validFiles = new List<string>();

            foreach (var saveFileName in filesToCheck)
            {
                string path = dirName + saveFileName;
                string worldFileName = GetWorldFileName(path);
                if (File.Exists(@"Saves\"+worldFileName))
                {
                    validFiles.Add(saveFileName);
                }

            }

            return validFiles.ToArray();

        }

        public static string GetWorldFileName(string saveFileNamePath)
        {
            XDocument doc = XDocument.Load(saveFileNamePath);
            string worldFileName = doc.Root.Attribute("WorldFileName").Value;
            return worldFileName;
        }

        public static string[] GetSaveFile(string dirName)
        {
            string[] rawfileNames = Directory.GetFileSystemEntries(dirName);
            List<string> fileNames = new List<string>();

            foreach (string fileName in rawfileNames)
            {
                
                string[] splittedName = fileName.Split('\\');
                //fileNames.Add(fileName);
                if (splittedName[1].Contains("Save"))
                {
                    fileNames.Add(splittedName[1]);
                }
            }

            return fileNames.ToArray();
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
                                            new XElement("Description", Location.Description),
                                            new XElement("AccessPoints",
                                                from AccessPoint in Location.AccessPoints
                                                select new XElement("AccessPoint", new XAttribute("Dir", AccessPoint.Direction),
                                                                                  new XAttribute("ZoneDest", AccessPoint.DestZone),
                                                                                  new XAttribute("LocationDest", AccessPoint.DestLoc)
                                                                   )
                                                         ),
                                                AddInventoryToXml("Void",Location.Void.insideInventory)
                       
                                                        )//     </Location>
                                                  )
                                    )
                            )
                );

            xmlDocument.Save(completePath);
        }

        private object AddInventoryToXml(string type, Inventory inventoryToAdd)
        {
            XElement inventory =
            new XElement("Inventory", new XAttribute("Type", type),

                                                        from currentObject in inventoryToAdd.objects
                                                        select new XElement("Object", new XAttribute("Type", currentObject.GetObjectType()),
                                                                                        new XAttribute("Id", currentObject.Id),
                                                                                        new XAttribute("Name", currentObject.Name),
                        currentObject is AccessPointObject ? new XElement("Direction", Oobject.GetDirection(currentObject)) : null,
                        currentObject.insideInventory != null ? AddInventoryToXml("Inside",currentObject.insideInventory) : null ,
                        currentObject.aboveInventory != null ? AddInventoryToXml("On", currentObject.aboveInventory) : null,
                        currentObject.underInventory != null ? AddInventoryToXml("Under", currentObject.underInventory) : null
                                                                            )
                                                        // </Object>
                                                        );
            return inventory;
        }

        public void SavePlayerGame(Player player, string path, GameFileAndTitle game,string saveName,string worldFileName)
        {
            string fileName = game.Title + " - " + saveName + " Save.xml";
            string completePath = path + fileName;

            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),

                new XComment("Creating xml file from game Engine"),

                new XElement("Player", new XAttribute("GameTitle", game.Title), new XAttribute("FileName", fileName), new XAttribute("WorldFileName",worldFileName),

                new XElement("CurrentLocation", player.CurrentLocation.Title),
                new XElement("Inventory","Inventaire")
                                    
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
