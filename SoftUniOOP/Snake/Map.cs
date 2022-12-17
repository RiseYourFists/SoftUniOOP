using Snake.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Map
    {
        private List<CollisionObject> tiles;
        private readonly string path;
        public Map(string mapHolderPath)
        {
            path = mapHolderPath;
            tiles = new List<CollisionObject>();
        }

        public IReadOnlyCollection<CollisionObject> Tiles => tiles;

        public int XAxisSize { get; set; }
        public int YAxisSize { get; set; }

        public void ReadMapData(char wall, ICycle gameState)
        {
            using (var reader = new StreamReader(path))
            {
                var mapSize = reader.ReadLine().Split(',');
                YAxisSize = int.Parse(mapSize[0]);
                XAxisSize = int.Parse(mapSize[1]);

                string line;
                int counter = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == wall)
                        {
                            ICoordinates coords = new Coordinates(i, counter);
                            tiles.Add(new Tile(coords, gameState, wall));
                        }
                    }
                    counter++;
                }
            }
        }
    }
}
