using SnakeGame.Collisions;
using SnakeGame.Contracts.Controller;
using SnakeGame.Contracts.Coordination;
using SnakeGame.Contracts.Renderer;

namespace SnakeGame.SnakeStructure
{
    public class Head : Collision, IDrawable, IMoveable
    {
        public Head(char drawableToken)
        {
            DrawableToken = drawableToken;
        }

        public char DrawableToken { get; private set; }

        public void Spawn(ICoordinates coords)
        {
            this.Coordinates = coords;
        }

        public void UpdatePos(IDirection.Direction direction)
        {
            switch (direction)
            {
                case IDirection.Direction.LEFT:
                    this.Coordinates.XAxis--;
                    break;
                case IDirection.Direction.RIGHT:
                    this.Coordinates.YAxis++;
                    break;
                case IDirection.Direction.UP:
                    this.Coordinates.YAxis--;
                    break;
                case IDirection.Direction.DOWN:
                    this.Coordinates.YAxis++;
                    break;

            }
        }
    }
}
