using Snake.Interfaces;

namespace Snake
{
    public class Tile : CollisionObject
    {
        public Tile(ICoordinates coordinates, ICycle gameState, char drawableToken) 
            : base(coordinates, gameState, drawableToken)
        {
        }

    }
}
