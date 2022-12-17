
using Snake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public abstract class CollisionObject : IDrawable
    {
        public CollisionObject(ICoordinates coordinates, ICycle gameState, char drawableToken)
        {
            Coordinates = coordinates;
            GameState = gameState;
            DrawableToken = drawableToken;
        }

        public ICycle GameState { get; private set; }

        public ICoordinates Coordinates { get; private set; }

        public char DrawableToken { get; private set; }

        public virtual void OnCollisionEvent()
        {
            GameState.GameOver();
        }

        bool Compare(ICoordinates other)
            => this.Coordinates.YAxis == other.YAxis
            && this.Coordinates.XAxis == other.XAxis;
    }
}
