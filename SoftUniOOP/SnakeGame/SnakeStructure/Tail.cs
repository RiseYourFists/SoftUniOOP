using SnakeGame.Collisions;
using SnakeGame.Contracts.Renderer;

namespace SnakeGame.SnakeStructure
{
    public class Tail : Collision, IDrawable
    {
        

        public Tail(char drawableToken)
        {
            DrawableToken = drawableToken;
        }

        public char DrawableToken { get; set; }

        
    }
}
