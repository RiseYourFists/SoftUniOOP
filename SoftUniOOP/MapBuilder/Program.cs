using System;

namespace MapBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rows = 25;
            var cols = 50;
            var OutPutPath = @"../../../Maps/";
            var OutPutFile = "../../../Maps/map.txt";
            var builder = new SnakeMapBuilder();

            bool isDone = (builder.GenerateNewMap(rows, cols, '#', OutPutFile));

            if (isDone)
            {
                Console.WriteLine("New map has been created.");
            }
        }
    }
}
