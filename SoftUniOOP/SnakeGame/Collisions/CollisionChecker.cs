using SnakeGame.Contracts.Coordination;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame.Collisions
{
    public class CollisionChecker: Collision
    {
        public Collision CollidedObj { get; private set; }

        public bool HasCollided(Collision[] colliders, ICoordinates comparer)
        {
            foreach (var collidable in colliders)
            {
                if (collidable.Compare(comparer))
                {
                    CollidedObj = collidable;
                    return true;
                }

            }

            return false;
        }
    }
}
