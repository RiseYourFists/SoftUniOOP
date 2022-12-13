using SnakeGame.Contracts.Coordination;
using SnakeGame.EngineHolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame.Collisions
{
    public abstract class Collision : Engine, ICoordinateComparator
    {
        public ICoordinates Coordinates { get; set; }

        public virtual void OnCollisionEvent()
        {
            isOver = !isOver;
        }

        public bool Compare(ICoordinates that)
            => Coordinates.YAxis == that.YAxis 
            && Coordinates.XAxis == that.XAxis;
    }
}
