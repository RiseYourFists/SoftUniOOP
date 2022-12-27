using Snake.Enumerators;
using Snake.Interfaces;
using System;

namespace Snake
{
    public class Controller
    {
        public Controller()
        {
            Dir = Direction.Stop;
        }

        public Direction Dir { get; private set; }

        public void Read()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.A:
                            if (Dir == Direction.Right)
                                return;
                            Dir = Direction.Left;
                            break;
                        case ConsoleKey.D:
                            if (Dir == Direction.Left)
                                return;
                            Dir = Direction.Right;
                            break;
                        case ConsoleKey.W:
                            if (Dir == Direction.Down)
                                return;
                            Dir = Direction.Up;
                            break;
                        case ConsoleKey.S:
                            if (Dir == Direction.Up)
                                return;
                            Dir = Direction.Down;
                            break;
                        default:
                            break;
                    }
                }
                break;
            }
        }

        public void Move(IMoveable[] moveables)
        {

            foreach (var moveableObj in moveables)
            {
                if (Dir == Direction.Stop) break;
                moveableObj.UpdatePos(Dir);
            }
        }

        public void Move(IMoveable moveable)
        {
            if (Dir == Direction.Stop) return;
            moveable.UpdatePos(Dir);
        }
    }
}
