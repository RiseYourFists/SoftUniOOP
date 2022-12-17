using Snake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Render
    {
        public void NewFrame()
        {
            Console.Clear();
        }

        public void Draw(CollisionObject gameObj)
        {
            ICoordinates coordinates = gameObj.Coordinates;
            Console.SetCursorPosition(coordinates.XAxis, coordinates.YAxis);
            Console.Write(gameObj.DrawableToken);
        }

        public void Draw(CollisionObject[] drawables)
        {
            foreach (var gameObj in drawables)
            {
                ICoordinates coordinates = gameObj.Coordinates;
                Console.SetCursorPosition(coordinates.XAxis, coordinates.YAxis);
                Console.Write(gameObj.DrawableToken);
            }
        }
    }
}
