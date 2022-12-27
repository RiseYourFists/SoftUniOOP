using Snake.Interfaces;
using Snake.Collisions;
using System;

namespace Snake
{
    public class Food : CollisionObject
    {
        private readonly IChecker checker;

        public Food(ICoordinates coordinates, ICycle gameState, char drawableToken, IChecker colliChecker) 
            : base(coordinates, gameState, drawableToken)
        {
            this.checker = colliChecker;
            NewFruit = true;
        }

        public bool NewFruit { get; set; }

        public void Spawn(int XDimention, int YDimention, CollisionObject[][] colliders)
        {
            var xCoord = new Random().Next(0, XDimention);
            var yCoord = new Random().Next(0, YDimention);
            ICoordinates coords = new Coordinates(xCoord, yCoord);
            ModifyCoords(coords);

            if(checker.HasCollided(colliders, coords))
            {
                Spawn(XDimention, YDimention, colliders);
            }

            NewFruit = false;
        }

        public override void OnCollisionEvent()
        {
            GameState.AddPoints(100);
            Console.Beep();
            NewFruit = true;
        }
    }
}
