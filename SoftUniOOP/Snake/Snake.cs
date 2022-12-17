using System.Collections.Generic;

namespace Snake
{
    public class Snake
    {
        private Queue<CollisionObject> tail;
        private Tail tailSegment;

        public Snake(Head head, Tail tailSegment)
        {
            Head = head;
            tail = new Queue<CollisionObject>();
            this.tailSegment = tailSegment;
            tail.Enqueue(tailSegment);
        }

        public CollisionObject Head { get; private set; }
        public CollisionObject[] Tail => tail.ToArray();
    }
}
