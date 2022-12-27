using System;

namespace FacetedBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new CarFacade()
            .Info
                .WithType("Volvo")
                .WithColor("Red")
                .WithDoors(4)
            .Adress
                .WithCity("Sofia")
                .WithAdress("Center")
            .Build();

            Console.WriteLine(car);
        }
    }
}
