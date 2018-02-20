
namespace TextAdventureCommon
{
    public class Player
    {
        public Location CurrentLocation { get; set; }
        public Player(World world)
        {
            CurrentLocation = world.GetStartingLocation();
        }
    }
}