﻿using SnakeGame.Contracts.Coordination;

namespace SnakeGame.Collisions
{
    public class Coordinates : ICoordinates
    {
        public Coordinates(int xAxis, int yAxis)
        {
            XAxis = xAxis;
            YAxis = yAxis;
        }

        public int XAxis { get; set; }
        public int YAxis { get; set; }
    }
}
