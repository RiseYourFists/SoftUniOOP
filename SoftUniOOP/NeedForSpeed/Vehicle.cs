namespace NeedForSpeed
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Vehicle
    {
        public const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
            
        }
        public virtual double FuelConsumption
            => DefaultFuelConsumption;

        public double Fuel{ get; set; }

        public int HorsePower { get; set; }

        public virtual void Drive(double distance)
        {
            if (Fuel - distance * FuelConsumption >= 0)
            {
                Fuel -= distance * FuelConsumption;
            }
        }
    }
}
