using System;
using System.Collections.Generic;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            var carTokens = Console.ReadLine().Split();
            var car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]));

            var truckTokens = Console.ReadLine().Split();
            var truck = new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]));

            var vehicles = new Dictionary<string, Vehicle>();
            vehicles.Add(carTokens[0], car);
            vehicles.Add(truckTokens[0], truck);

            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var command = Console.ReadLine().Split();

                var action = command[0];
                var vehicle = command[1];
                var param = double.Parse(command[2]);

                if ( action == "Drive")
                {
                    if (vehicles.ContainsKey(vehicle))
                    {
                        var hasTraveled = 
                            vehicles[vehicle].Drive(param)
                            ? $"{vehicle} travelled {param} km"
                            : $"{vehicle} needs refueling";

                        Console.WriteLine(hasTraveled);
                    }
                }
                if (action == "Refuel")
                {
                    if(vehicles.ContainsKey(vehicle))
                        vehicles[vehicle].Refuel(param);
                }

            }

            Func<double, double> round = x => Math.Round(x, 2);

            Console.WriteLine($"Car: {round(car.FuelQuantity):f2}\nTruck: {round(truck.FuelQuantity):f2}");

        }
    }
}
