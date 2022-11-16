namespace Shapes
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape circle = new Circle(2.2);
            Shape rectangle = new Rectangle(4.1, 3.1);

            Console.WriteLine($"{circle.Draw()}:\n" +
                              $"Perimeter: {circle.CalculatePerimeter():f2}" +
                              $"\nArea: {circle.CalculateArea():f2}");

            Console.WriteLine($"{rectangle.Draw()}:\n" +
                              $"Perimeter: {rectangle.CalculatePerimeter():f2}" +
                              $"\nArea: {rectangle.CalculateArea():f2}");
        }
    }
}
