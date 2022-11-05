using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        enum IPropertyError
        {
            Length,
            Width,
            Height,
        }

        private readonly Func<double, bool> IsLessOrEqualToZero = x => x <= 0;

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;
            private set
            {
                if (IsLessOrEqualToZero(value))
                    SendError(IPropertyError.Length);
                length = value;
            }
        }

        public double Width
        {
            get => width;
            private set
            {
                if (IsLessOrEqualToZero(value))
                    SendError(IPropertyError.Width);
                width = value;
            }
        }

        public double Height 
        { 
            get => height;
            private set
            {
                if (IsLessOrEqualToZero(value))
                    SendError(IPropertyError.Height);
                height = value;
            }
        }

        private void SendError(IPropertyError type)
            => throw new ArgumentException($"{type} cannot be zero or negative.");

        public double SurfaceArea()
            => 2 * ((length * width) + (length * height) + (width * height));

        public double LiteralSurfaceArea()
            => 2 * ((length * height) + (width * height));

        public double Volume()
            => length * width * height;

    }
}
