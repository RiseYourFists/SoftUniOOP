namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height { get => height; set => height = value; }
        public double Width { get => width; set => width = value; }


        public override double CalculateArea()
            => height * width;

        public override double CalculatePerimeter()
            => 2 * (height + width);

        public override string Draw()
            => base.Draw() + GetType().Name;
    }
}
