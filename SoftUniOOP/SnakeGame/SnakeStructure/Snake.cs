using SnakeGame.Contracts.Controller;
using SnakeGame.Contracts.Coordination;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame.SnakeStructure
{
    public class Snake : IMoveable
    {


        public Snake(Head head, Tail tail)
        {
            Head = head;

            Tail = tail;
        }

        Head Head { get; }

        Tail Tail { get; }

        public void UpdatePos(IDirection.Direction direction)
        {
            Tail.Remove();
            ICoordinates newCoords = Head.Coordinates;

            switch (direction)
            {
                case IDirection.Direction.UP:
                    newCoords.YAxis++;
                    break;
                case IDirection.Direction.DOWN:
                    newCoords.YAxis--;
                    break;
                case IDirection.Direction.LEFT:
                    newCoords.XAxis++;
                    break;
                case IDirection.Direction.RIGHT:
                    newCoords.XAxis--;
                    break;
            }
            Tail.Add(newCoords);
        }
    }
}
