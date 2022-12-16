using SnakeGame.Contracts.Coordination;
using SnakeGame.EngineHolder;

namespace SnakeGame.Collisions
{
    public abstract class Collision : Engine, ICoordinateComparator
    {
        public ICoordinates Coordinates { get; set; }

        public virtual void OnCollisionEvent()
        {
            IsOver = !IsOver;
        }

        public bool Compare(ICoordinates that)
            => Coordinates.YAxis == that.YAxis 
            && Coordinates.XAxis == that.XAxis;
    }
}
