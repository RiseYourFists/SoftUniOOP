using Snake.Interfaces;

namespace Snake
{
    public class Head : CollisionObject
    {
        public Head(ICoordinates coordinates, ICycle gameState, char drawableToken) 
            : base(coordinates, gameState, drawableToken)
        {
        }
    }
}
