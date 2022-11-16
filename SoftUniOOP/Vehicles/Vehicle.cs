using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; set; }

        public virtual double FuelConsumption { get; set; }

        public bool Drive(double distance)
        {
            var fuelAfterDrive = FuelQuantity - distance * FuelConsumption;

            if(fuelAfterDrive < 0)
                return false;
                
            FuelQuantity = fuelAfterDrive;
            return true;
        }

        public virtual void Refuel(double amount)
            => FuelQuantity += amount;
    }
}
