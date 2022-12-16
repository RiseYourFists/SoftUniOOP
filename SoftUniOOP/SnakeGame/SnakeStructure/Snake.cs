using SnakeGame.Contracts.Controller;
using SnakeGame.Contracts.Coordination;
using System.Collections.Generic;

namespace SnakeGame.SnakeStructure
{
    public class Snake : IMoveable
    {
        private readonly Tail tail;

        public Snake(Head head, Tail tail)
        {
            Head = head;

            this.tail = tail;

            SnakeTail = new Queue<Tail>();
        }

        Head Head { get; }

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

        public void UpdatePos(IDirection.Direction direction)
        {
            this.Remove();
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
            this.Add(newCoords);
        }
    }
}
