using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle, IPassinger
    {
        public Bus(double tankCapacity, double fuelQuantity, double fuelConsumption)
            : base(tankCapacity, fuelQuantity, fuelConsumption) { }

        public override double FuelConsumption
            => base.FuelConsumption + 1.4;

        public bool DriveEmpty(double distance)
        {
            var fuelAfterDrive = fuelQuantity - distance * (FuelConsumption - 1.4);

            if (fuelAfterDrive < 0)
                return false;

            fuelQuantity = fuelAfterDrive;
            return true;
        }
    }
}
