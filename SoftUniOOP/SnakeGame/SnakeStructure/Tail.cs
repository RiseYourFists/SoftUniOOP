using SnakeGame.Collisions;
using SnakeGame.Contracts.Controller;
using SnakeGame.Contracts.Coordination;
using SnakeGame.Contracts.Renderer;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame.SnakeStructure
{
    public class Tail : Collision, IDrawable
    {
        private readonly Tail tail;

        public Tail(char drawableToken, int initialLength)
        {
            DrawableToken = drawableToken;
            SnakeTail = new Queue<Tail>();
        }

        public char DrawableToken { get; set; }

        Queue<Tail> SnakeTail { get; }

        public void Add(ICoordinates coordinates)
        {
            var segment = tail;
            segment.Coordinates = coordinates;
            SnakeTail.Enqueue(tail);
        }

        public void Remove()
        {
            SnakeTail.Dequeue();
        }
    }
}
