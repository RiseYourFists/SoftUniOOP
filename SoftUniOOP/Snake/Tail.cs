using Snake.Interfaces;

namespace Snake
{
    public class Tail : CollisionObject
    {
        public Tail(ICoordinates coordinates, ICycle gameState, char drawableToken) 
            : base(coordinates, gameState, drawableToken)
        {
        }

        public Tail(Tail collisionObject)
            : base(collisionObject.Coordinates, collisionObject.GameState, collisionObject.DrawableToken)
        { 
        }

    }
}
