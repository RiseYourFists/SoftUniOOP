using System;
using System.Collections.Generic;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {

            var vehicles = new Dictionary<string, Vehicle>();

            var carTokens = Console.ReadLine().Split();
            var car = new Car(double.Parse(carTokens[3]), double.Parse(carTokens[1]), double.Parse(carTokens[2]));

            var truckTokens = Console.ReadLine().Split();
            var truck = new Truck(double.Parse(truckTokens[3]), double.Parse(truckTokens[1]), double.Parse(truckTokens[2]));

            var busTokens = Console.ReadLine().Split();
            var bus = new Bus(double.Parse(busTokens[3]), double.Parse(busTokens[1]), double.Parse(busTokens[2]));

            vehicles.Add(carTokens[0], car);
            vehicles.Add(truckTokens[0], truck);
            vehicles.Add(busTokens[0], bus);


            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var command = Console.ReadLine().Split();

                var action = command[0];
                var vehicle = command[1];
                var value = double.Parse(command[2]);

                if (action == "Drive")
                {
                    Drive(vehicles[vehicle].Drive(value), vehicle, value);
                    continue;
                }

                if (action == "Refuel")
                {
                    vehicles[vehicle].Refuel(value);
                    continue;
                }

                if (action == "DriveEmpty")
                {
                    var passingerVehicle = vehicles[vehicle] as IPassinger;
                    if (passingerVehicle != null)
                        Drive(passingerVehicle.DriveEmpty(value), vehicle, value);
                    continue;
                }

            }


            Func<double, double> round = x => Math.Round(x, 2);

            Console.WriteLine($"Car: {round(car.FuelQuantity):f2}\n" +
                              $"Truck: {round(truck.FuelQuantity):f2}\n" +
                              $"Bus: {round(bus.FuelQuantity):f2}\n");

        }

        private static void Drive(bool canDrive, string vehicle, double param)
        {
            var hasTraveled = canDrive
                ? $"{vehicle} travelled {param} km"
                : $"{vehicle} needs refueling";

            Console.WriteLine(hasTraveled);
        }
    }
}
