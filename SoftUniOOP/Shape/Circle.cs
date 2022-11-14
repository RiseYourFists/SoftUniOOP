namespace Shapes
{
    using System;

    public class Circle : Shapes
    {
        private double radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get => radius; set => radius = value; }


        public override double CalculatePerimeter()
            => 2 * Math.PI * radius;

        public override double CalculateArea()
            => Math.PI * radius * radius;

        public override string Draw()
            => "This is a circle";
    }
}