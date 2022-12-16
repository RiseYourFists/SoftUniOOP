using SnakeGame.Collisions;
using SnakeGame.Contracts.Coordination;
using SnakeGame.Contracts.Renderer;

namespace SnakeGame.MapInterpreter
{
    public class Tile : Collision, IDrawable
    {
        

        public Tile(char drawableToken, ICoordinates coordinates)
        {
            DrawableToken = drawableToken;
            Coordinates = coordinates;
        }

        public char DrawableToken { get; set; }
    }
}
