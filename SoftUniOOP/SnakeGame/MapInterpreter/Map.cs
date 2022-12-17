﻿using SnakeGame.Collisions;
using SnakeGame.Contracts.Coordination;
using System.Collections.Generic;
using System.IO;

namespace SnakeGame.MapInterpreter
{
    public class Map : Collision
    {
        private readonly List<Collision> tileData;
        private readonly string path;

        public Map(string mapHolderPath)
        {
            path = mapHolderPath;
            tileData = new List<Collision>();
        }

        public int Rows { get; private set; }
        public int Cols { get; private set; }

        public IReadOnlyCollection<Collision> Tiles => tileData;

        public void ReadMapData(char wall)
        {
            using (var reader = new StreamReader(path))
            {
                var mapSize = reader.ReadLine().Split(',');
                Rows = int.Parse(mapSize[0]);
                Cols = int.Parse(mapSize[1]);

                string line;
                int counter = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == wall)
                        {
                            ICoordinates coords = new Coordinates(counter, i);
                            tileData.Add(new Tile(wall, coords));
                        }
                    }
                    counter++;
                }
            }
        }
    }
}
