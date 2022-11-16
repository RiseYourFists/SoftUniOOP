using System;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected readonly Func<double, double, bool> IsValidCapacity =
            (amount, capacity) => amount <= capacity;

        protected double fuelQuantity;

        protected Vehicle(double tankCapacity, double fuelQuantity, double fuelConsumption)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            protected set
            {

                if (IsValidCapacity(value, TankCapacity))
                {
                    fuelQuantity = value;
                    return;
                }

                fuelQuantity = 0;
            }
        }

        public virtual double FuelConsumption { get; protected set; }

        public double TankCapacity { get; private set; }

        public bool Drive(double distance)
        {
            var fuelAfterDrive = fuelQuantity - distance * FuelConsumption;

            if (fuelAfterDrive < 0)
            {
                return false;
            }

            fuelQuantity = fuelAfterDrive;
            return true;
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }

            if (!IsValidCapacity(amount, TankCapacity))
            {
                WriteError(amount);
                return;
            }

            fuelQuantity += amount;
        }

        protected void WriteError(double value)
        {
            Console.WriteLine($"Cannot fit {value} fuel in the tank");
        }
    }
}
