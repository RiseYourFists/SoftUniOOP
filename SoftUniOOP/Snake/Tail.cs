using Snake.Interfaces;

namespace Snake
{
    public class Tail : CollisionObject
    {
        public Tail(ICoordinates coordinates, ICycle gameState, char drawableToken) 
            : base(coordinates, gameState, drawableToken)
        {
        }
    }
}
