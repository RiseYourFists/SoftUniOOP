namespace NeedForSpeed
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuelConsumption)
            : base(horsePower, fuelConsumption)
        {

        }

        public override double FuelConsumption => 8;
    }
}
