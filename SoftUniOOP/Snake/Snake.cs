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

            var newSegmentCoords = new Coordinates(Head.Coordinates);
            
            tailSegment.ModifyCoords(newSegmentCoords);
            var newSegment = new Tail(tailSegment);
            tail.Enqueue(newSegment);
        }

        public void UpdatePos(Direction direction)
        {
            if(tail.Count == 0) return;
            tail.Dequeue();
            var newCoords = new Coordinates(Head.Coordinates);

            tailSegment.ModifyCoords(newCoords);
            var newSegment = new Tail(tailSegment);
            tail.Enqueue(newSegment);
        }
    }
}
