using Snake.Enumerators;
using Snake.Interfaces;

namespace Snake
{
    public class Head : CollisionObject, IMoveable
    {
        public Head(ICoordinates coordinates, ICycle gameState, char drawableToken) 
            : base(coordinates, gameState, drawableToken)
        {
        }

        public void UpdatePos(Direction direction)
        {
            var newCoords = new Coordinates(Coordinates);

            switch (direction)
            {
                case Direction.Up:
                    newCoords.YAxis--;
                    break;
                case Direction.Down:
                    newCoords.YAxis++;
                    break;
                case Direction.Left:
                    newCoords.XAxis--;
                    break;
                case Direction.Right:
                    newCoords.XAxis++;
                    break;
            }

            ModifyCoords(newCoords);
        }
    }
}
