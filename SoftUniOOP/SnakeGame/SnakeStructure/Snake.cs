using SnakeGame.Collisions;
using SnakeGame.Contracts.Controller;
using SnakeGame.Contracts.Coordination;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame.SnakeStructure
{
    public class Snake : IMoveable
    {
        private readonly Tail tail;
        private readonly Queue<Tail> snakeTail;
        public Snake(Head head, Tail tail)
        {
            Head = head;
            this.tail = tail;
            snakeTail = new Queue<Tail>();
        }

        Head Head { get; }

        public Tail[] SnakeTail => snakeTail.ToArray();

        private void Add(ICoordinates coordinates)
        {
            var segment = tail;
            segment.Coordinates = coordinates;
            snakeTail.Enqueue(tail);
        }

        public void AddNewSegment(IDirection.Direction direction)
        {
            foreach (var segment in snakeTail)
            {
                MoveByDirection(direction, segment.Coordinates);  
            }
        }

        public void Remove()
        {
            snakeTail.Dequeue();
        }

        public void UpdatePos(IDirection.Direction direction)
        {
            this.Remove();
            ICoordinates newCoords = Head.Coordinates;

            MoveByDirection(direction, newCoords);
            this.Add(newCoords);
        }

        private static void MoveByDirection(IDirection.Direction direction, ICoordinates coords)
        {
            switch (direction)
            {
                case IDirection.Direction.UP:
                    coords.YAxis++;
                    break;
                case IDirection.Direction.DOWN:
                    coords.YAxis--;
                    break;
                case IDirection.Direction.LEFT:
                    coords.XAxis++;
                    break;
                case IDirection.Direction.RIGHT:
                    coords.XAxis--;
                    break;
            }
        }
    }
}
