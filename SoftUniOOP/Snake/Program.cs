using Snake.Interfaces;
using System;

namespace Snake
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.CursorVisible = false;
            IEngine engine = new Engine();
            engine.Run();

        }
    }
}
