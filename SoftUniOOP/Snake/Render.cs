using Snake.Interfaces;
using System;

namespace Snake
{
    public class Render
    {
        public Render(ICycle gameState)
        {
            this.gameState = gameState;
        }

        ICycle gameState;
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

        public void WriteStats()
        {
            Console.WriteLine($"\nScore: {gameState.Points}");
        }

        public void WriteAt(int XPos, int YPos, string text)
        {
            Console.SetCursorPosition(XPos, YPos);
            Console.Write(text);
        }
    }
}
