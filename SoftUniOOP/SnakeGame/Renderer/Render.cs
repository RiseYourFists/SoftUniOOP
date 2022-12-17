using SnakeGame.Collisions;
using SnakeGame.Contracts.Renderer;
using System;

namespace SnakeGame.Renderer
{
    public class Render
    {
        public void Draw(IDrawable[] drawables)
        {
            foreach ( var drawableObj in drawables)
            {
                Collision Obj = drawableObj as Collision;
                Console.SetCursorPosition(Obj.Coordinates.XAxis, Obj.Coordinates.YAxis);
                Console.Write(drawableObj.DrawableToken);
            }
        }

        public void Draw(IDrawable drawable)
        {
            Collision Obj = drawable as Collision;
            Console.SetCursorPosition(Obj.Coordinates.XAxis, Obj.Coordinates.YAxis);
            Console.Write(drawable.DrawableToken);
        }
    }
}
