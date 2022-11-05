using System;

namespace ClassBoxData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            try
            {
                var box = new Box(length, width, height);
                
                Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}\nLateral Surface Area - {box.LiteralSurfaceArea():F2}\nVolume - {box.Volume():F2}");
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }

        }
    }
}
