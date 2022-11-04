namespace NeedForSpeed
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car : Vehicle
    {
        

        public Car(int horsePower, double fuelConsumption)
            : base(horsePower, fuelConsumption)
        {
        }

        public override double FuelConsumption => 3;
    }
}
