namespace NeedForSpeed
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SportCar : Car
    {

        public SportCar(int horsePower, double fuelConsumption)
            :base(horsePower, fuelConsumption)
        {

        }

        public override double FuelConsumption => 10;
    }
}
