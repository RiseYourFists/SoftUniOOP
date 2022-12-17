using Snake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
