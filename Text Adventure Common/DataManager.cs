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

        public World LoadWorld(string CompletePath)
        {
            World loadedWorld = new World();
            XDocument doc;
            doc = XDocument.Load(CompletePath);

            loadedWorld.GameTitle = doc.Element("Root").Element("World").Attribute("Name").Value;

            loadedWorld.zones = new Dictionary<string, Zone>();
            foreach (XElement element in doc.Root.Descendants("Zone"))
            {
                Zone zoneToAdd = new Zone(element.Attribute("Name").Value);
                loadedWorld.zones.Add(element.Attribute("Name").Value, zoneToAdd);

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
                    Location locToAdd = new Location(elementLoc.Attribute("Name").Value, 
                                                    elementLoc.Element("Description").Value,
                                                    transitionLocation,
                                                    startingRoom);
                    locToAdd.Id = Int32.Parse(elementLoc.Attribute("Id").Value);
                    locToAdd.Zone = zoneToAdd;
                    zoneToAdd.AddLocation(locToAdd);
                 
                        List<AccessPoint> accessPointsToAdd = new List<AccessPoint>();
                        foreach(XElement elementAp in elementLoc.Descendants("AccessPoint"))
                        {
                        AccessPoint apToAdd = new AccessPoint(elementAp.Attribute("Dir").Value,
                            
                            elementAp.Attribute("ZoneDest").Value,
                            elementAp.Attribute("LocationDest").Value);
                            accessPointsToAdd.Add(apToAdd);
                        }
                    locToAdd.AccessPoints = accessPointsToAdd;
                    XElement inventory = elementLoc.Element("Inventory");
                    
                    locToAdd.Void.insideInventory = loadInventory("Inside", inventory, locToAdd.Void,null);

                }
            }
            string lastLocationId = doc.Element("Root").Element("World").Attribute("LastLocationEditedId").Value;
            if (lastLocationId != "")
            {
                loadedWorld.LastLocationEdited = loadedWorld.GetLocation(Int32.Parse(lastLocationId));
            }
            return loadedWorld;
        }

        private Inventory loadInventory(string inventoryType, XElement inventory,Oobject parentObj, Inventory parentInventory)
        {
            Inventory inventoryToAdd= null;

            if(inventoryType == "On")
            {
                inventoryToAdd = new OnInventory(parentObj);
            }
            if (inventoryType == "Inside")
            {
                inventoryToAdd = new InsideInventory(parentObj);
            }
            if (inventoryType == "Under")
            {
                inventoryToAdd = new UnderInventory(parentObj);
            }

            //List<Oobject> objects = new List<Oobject>();
            foreach (XElement obj in inventory.Elements("Object"))
            {
                Oobject objectToAdd;
                if(obj.Attribute("Type").Value == Oobject.AccessPointObjectType)
                {
                    objectToAdd = new AccessPointObject(parentInventory);
                    AccessPointObject apObj = (AccessPointObject)objectToAdd;
                    apObj.Direction = obj.Element("Direction").Value;
                }

                else if(obj.Attribute("Type").Value == Oobject.FloorObjectType)
                {
                    objectToAdd = new FloorContainer(parentInventory);
                }

                else if (obj.Attribute("Type").Value == Oobject.WallObjectType)
                {
                    objectToAdd = new WallContainer(parentInventory);
                }

                else if (obj.Attribute("Type").Value == Oobject.CeilingObjectType)
                {
                    objectToAdd = new CeilingContainer(parentInventory);
                }

                else
                {
                    objectToAdd = new SolidObject(parentInventory);
                }
                objectToAdd.Id = Int32.Parse(obj.Attribute("Id").Value);
                objectToAdd.Noun.Singular = obj.Attribute("Name").Value;
                
                foreach (XElement elementInventory in obj.Elements("Inventory"))
                {
                    if(elementInventory.Attribute("Type").Value == "On")
                    {
                        
                        objectToAdd.aboveInventory = loadInventory("On", elementInventory, objectToAdd, inventoryToAdd);
                        
                        objectToAdd.HasAboveContainer = true;
                    }
                    else if (elementInventory.Attribute("Type").Value == "Under")
                    {
                        
                        objectToAdd.underInventory = loadInventory("Under", elementInventory, objectToAdd, inventoryToAdd);
                        
                        objectToAdd.HasUnderContainer = true;
                    }
                    else
                    {
                            
                            objectToAdd.insideInventory = loadInventory("Inside", elementInventory, objectToAdd, inventoryToAdd);
                       
                            objectToAdd.HasInsideContainer = true;
                    }
                }
                inventoryToAdd.Add(objectToAdd);
            }
            return inventoryToAdd;
        }

        public Player LoadPlayer(string completePath, World world)
        {
            Player player = new Player(world);

            XDocument doc;
            doc = XDocument.Load(completePath);

            int currentLocationId = Int32.Parse( doc.Element("Root").Element("Player").Element("CurrentLocationId").Value);
            
            if(currentLocationId != world.GetStartingLocation().Id)
            {
                player.CurrentLocation = world.GetLocation(currentLocationId);
            }
            XElement inventory = doc.Element("Root").Element("Player").Element("Inventory");
            player.Void.insideInventory = loadInventory("Inside", inventory, player.Void, null);

            return player; //TO DOOOOOOOOO
        }

        public static string[] GetValidFiles(string dirName,string[]filesToCheck)
        {
            List<string> validFiles = new List<string>();

            foreach (var saveFileName in filesToCheck)
            {
                string path = dirName + saveFileName;
                validFiles.Add(saveFileName);
            }

            return validFiles.ToArray();

        }

        public static string GetWorldFileName(string saveFileNamePath)
        {
            XDocument doc = XDocument.Load(saveFileNamePath);
            string worldFileName = doc.Root.Element("Player").Attribute("WorldFileName").Value;
            return worldFileName;
        }

        public static string[] GetSaveFiles(string dirName)
        {
            string[] rawfileNames = Directory.GetFileSystemEntries(dirName);
            List<string> fileNames = new List<string>();

            foreach (string fileName in rawfileNames)
            {
                string[] splittedName = fileName.Split('\\');
                fileNames.Add(splittedName[1]);
            }

            return fileNames.ToArray();
        }

        public void SaveWorldFromEditor(World world,string path,string fileName)
        {
            string gameTitle = world.GameTitle;
            string completePath = path + fileName;
            string lastLocationEditedId = "";
            if(world.LastLocationEdited != null)
            {
                lastLocationEditedId = world.LastLocationEdited.Id.ToString();
            }
            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),

                new XComment("Creating xml file from level editor"),
                new XElement("Root",
                new XElement("World", new XAttribute("Name", gameTitle), new XAttribute("FileName", fileName), new XAttribute("LastLocationEditedId",lastLocationEditedId))));
                //check if an existing id is last location edited
            addLocationsToXml(xmlDocument,world);
            xmlDocument.Save(completePath);
        }

        private void addLocationsToXml(XDocument xmlDocument,World world)
        {
            string[] ZonesNames = world.GetAllZonesNames();
            List<Zone> zones = world.GetAllZones();

            xmlDocument.Element("Root").Element("World").Add(
            from Zone in zones
            select new XElement("Zone", new XAttribute("Name", Zone.Name),
                                new XElement("Locations",
                                from Location in Zone.Locations
                                select new XElement("Location", new XAttribute("Name", Location.Title), new XAttribute("SartingLocation", Location.StartingLocation), new XAttribute("TransitionLocation", Location.TransitionLocation), new XAttribute("Id", Location.Id),
                                        new XElement("Description", Location.Description),
                                        new XElement("AccessPoints",
                                            from AccessPoint in Location.AccessPoints
                                            select new XElement("AccessPoint", new XAttribute("Dir", AccessPoint.Direction),
                                                                              new XAttribute("ZoneDest", AccessPoint.DestZone),
                                                                              new XAttribute("LocationDest", AccessPoint.DestLoc)
                                                               )
                                                     ),

                                            AddInventoryToXml("Void", Location.Void.insideInventory)

                                                    )//     </Location>
                                              )
                                )
            );

        }

        private object AddInventoryToXml(string type, Inventory inventoryToAdd)
        {
            XElement inventory =
            new XElement("Inventory", new XAttribute("Type", type),

                                                        from currentObject in inventoryToAdd.objects
                                                        select new XElement("Object", new XAttribute("Type", currentObject.GetObjectType()),
                                                                                        new XAttribute("Id", currentObject.Id),
                                                                                        new XAttribute("Name", currentObject.Noun),
                        currentObject is AccessPointObject ? new XElement("Direction", Oobject.GetDirection(currentObject)) : null,
                        currentObject.HasInsideContainer ? AddInventoryToXml("Inside",currentObject.insideInventory) : null ,
                        currentObject.HasAboveContainer  ? AddInventoryToXml("On", currentObject.aboveInventory) : null,
                        currentObject.HasUnderContainer ? AddInventoryToXml("Under", currentObject.underInventory) : null
                                                                            )
                                                        // </Object>
                                                        );
            return inventory;
        }

        public void SaveGameFromEngine(Player player, World world, string path, string saveFileName)
        {
            //string fileName = world.GameTitle + " - " + saveFileName;
            string completePath = path + saveFileName;

            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),

                new XComment("Creating xml file from game Engine"),
                new XElement("Root",
                new XElement("Player", new XAttribute("GameTitle", world.GameTitle), new XAttribute("FileName", saveFileName),

                new XElement("CurrentLocationId", player.CurrentLocation.Id),
                AddInventoryToXml("PlayerInventory", player.Void.insideInventory)

                            ), new XElement("World", new XAttribute("Name", world.GameTitle), new XAttribute("LastLocationEditedId", world.LastLocationEdited.Id))));

            
            addLocationsToXml(xmlDocument, world);
            xmlDocument.Save(completePath);
        }

        public GameInfos GetAvailableGame(string path)
        {
            XDocument doc = XDocument.Load(path);
            string gameTitle = doc.Element("Root").Element("World").Attribute("Name").Value.ToString();
            string fileName = doc.Element("Root").Element("World").Attribute("FileName").Value.ToString();
            GameInfos game = new GameInfos(gameTitle, fileName);
            return game;
        }
        public  string GetGamePath(string _directory,string _gameTitle)
        {
            string gameTitle = _gameTitle;
            string path = "";
            string directory = _directory;
            List<GameInfos> games = new List<GameInfos>();
            games.Add(GetAvailableGame(directory));

            foreach (GameInfos game in games)
            {
                if(game.GameTitle == gameTitle)
                {
                    path = directory + game.WorldFileName;
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
        
        
        public List<GameInfos> GetListOfGames(string directory)
        {
            List<GameInfos> games = new List<GameInfos>();
            string[] fileNames = Directory.GetFileSystemEntries(directory);
            foreach (string fileNamePath in fileNames)
            {
                games.Add(GetAvailableGame(fileNamePath));
            }
            return games;
        }

    }
    
}
