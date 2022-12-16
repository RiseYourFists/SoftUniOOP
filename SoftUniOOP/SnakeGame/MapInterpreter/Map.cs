using System.Collections.Generic;

namespace SnakeGame.MapInterpreter
{
    public class Map
    {
        private readonly List<Tile> tileData;
        private string path;

        public Map(string mapHolderPath)
        {
            path = mapHolderPath;
            tileData = new List<Tile>();
        }

        public IReadOnlyCollection<Tile> Tiles => tileData;

        public void ReadMapData()
        {

        }
    }
}
