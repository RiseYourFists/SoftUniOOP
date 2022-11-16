using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double tankCapacity, double fuelQuantity, double fuelConsumption)
            : base(tankCapacity, fuelQuantity, fuelConsumption) { }

        public override double FuelConsumption
            => base.FuelConsumption + 1.6;

        public override void Refuel(double amount)
        {
            if (!IsValidCapacity(amount, TankCapacity))
            {
                WriteError(amount);
                return;
            }

            base.Refuel(amount * 0.95);
        }
    }
}
