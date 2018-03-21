namespace TextAdventureCommon
{
    public class GameInfos
    {
        public string GameTitle;
        public string WorldFileName;

        public string SaveFileName;
        public string SaveTitle;

        public string SaveDirectory = @"Saves\";
        public string Extension = ".xml";

        public GameInfos(string _gameTitle, string _worldFileName)
        {
            GameTitle = _gameTitle;
            WorldFileName = _worldFileName;
            
        }
    }
}