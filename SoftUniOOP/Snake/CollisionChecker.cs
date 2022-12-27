using Snake.Collisions;
using Snake.Interfaces;

namespace Snake
{
    public class CollisionChecker : IChecker
    {
        public CollisionObject CollidedObj { get; set; }


        public bool HasCollided(CollisionObject[][] collisionObjects, ICoordinates comparer)
        {
            foreach (var collisionCollection in collisionObjects)
            {
                foreach (var collisionObject in collisionCollection)
                {
                    if (collisionObject.Compare(comparer))
                    {
                        CollidedObj = collisionObject;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
