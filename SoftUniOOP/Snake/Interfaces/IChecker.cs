using Snake.Interfaces;

namespace Snake.Collisions
{
    public interface IChecker
    {
        bool HasCollided(CollisionObject[][] collisionObjects, ICoordinates comparer);
    }
}