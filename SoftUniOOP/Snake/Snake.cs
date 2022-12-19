using Snake.Enumerators;
using Snake.Interfaces;
using System.Collections.Generic;

namespace Snake
{
    public class Snake : IMoveable
    {
        private Queue<CollisionObject> tail;
        private Tail tailSegment;

        public Snake(Head head, Tail tailSegment)
        {
            Head = head;
            tail = new Queue<CollisionObject>();
            this.tailSegment = tailSegment;
        }

        public CollisionObject Head { get; private set; }
        public CollisionObject[] Tail
        {
            get
            {
                CollisionObject[] data = new Tail[tail.Count];
                var count = 0;
                foreach (var item in tail)
                {
                    data[count] = item;
                    count++;
                }

                return data;
            }
        }

        public void Add(Direction direction)
        {
            if (direction == Direction.Stop) return;

            foreach (var segment in tail)
            {
                var newCoords = new Coordinates(segment.Coordinates);

                newCoords = CreateNewCoords(direction, newCoords);

                segment.ModifyCoords(newCoords);
            }

            var newSegmentCoords = new Coordinates(Head.Coordinates);
            newSegmentCoords = CreateNewCoords(direction, newSegmentCoords);
            tailSegment.ModifyCoords(newSegmentCoords);
            var newSegment = new Tail(tailSegment);
            tail.Enqueue(newSegment);
            System.Console.Beep();
        }

        public void UpdatePos(Direction direction)
        {
            if(tail.Count == 0) return;
            tail.Dequeue();
            var newCoords = new Coordinates(Head.Coordinates);

            newCoords = CreateNewCoords(direction, newCoords);

            tailSegment.ModifyCoords(newCoords);
            var newSegment = new Tail(tailSegment);
            tail.Enqueue(newSegment);
        }

        private static Coordinates CreateNewCoords(Direction direction, Coordinates newCoords)
        {
            var coords = new Coordinates(newCoords);
            switch (direction)
            {
                case Direction.Up:
                    coords.YAxis++;
                    break;
                case Direction.Down:
                    coords.YAxis--;
                    break;
                case Direction.Left:
                    coords.XAxis++;
                    break;
                case Direction.Right:
                    coords.XAxis--;
                    break;
            }

            return coords;
        }
    }
}
