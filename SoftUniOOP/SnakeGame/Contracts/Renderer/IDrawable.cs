using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame.Contracts.Renderer
{
    public interface IDrawable
    {
        char DrawableToken { get; }
    }
}
