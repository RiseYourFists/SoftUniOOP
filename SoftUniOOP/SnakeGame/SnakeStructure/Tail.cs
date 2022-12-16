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
        

        public Tail(char drawableToken)
        {
            DrawableToken = drawableToken;
        }

        public char DrawableToken { get; set; }

        
    }
}
