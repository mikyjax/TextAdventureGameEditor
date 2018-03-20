namespace TextAdventureCommon
{
    public class GameFileAndTitle
    {
        public string Title;
        public string WorldFileName;
        public string PlayerSaveFileName;
        public GameFileAndTitle(string _title, string _worldFileName)
        {
            Title = _title;
            WorldFileName = _worldFileName;
        }
    }
}