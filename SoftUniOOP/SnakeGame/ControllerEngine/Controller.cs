using SnakeGame.Contracts.Controller;
using System;

namespace SnakeGame.ControllerEngine
{
    public class Controller : IDirection
    {
        public Controller()
        {
            Dir = IDirection.Direction.STOP;
        }

        public IDirection.Direction Dir { get; private set; }
        public IDirection.Direction Prev { get; private set; }

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
                            Dir = IDirection.Direction.LEFT;
                            break;
                        case ConsoleKey.D:
                            Dir = IDirection.Direction.RIGHT;
                            break;
                        case ConsoleKey.W:
                            Dir = IDirection.Direction.UP;
                            break;
                        case ConsoleKey.S:
                            Dir = IDirection.Direction.DOWN;
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
                if (Prev == IDirection.Direction.STOP) break;
                moveableObj.UpdatePos(Prev);
            }

            switch (Dir)
            {
                case IDirection.Direction.RIGHT:
                    if (Prev == IDirection.Direction.LEFT)
                        return;
                    break;

                case IDirection.Direction.LEFT:
                    if (Prev == IDirection.Direction.RIGHT)
                        return;
                    break;

                case IDirection.Direction.UP:
                    if (Prev == IDirection.Direction.DOWN)
                        return;
                    break;
                case IDirection.Direction.DOWN:
                    if (Prev == IDirection.Direction.UP)
                        return;
                    break;
            }

            Prev = Dir;
        }
    }
}