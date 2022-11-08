using System;

namespace PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            try
            {
                var orderTokens = command.Split();
                var pizzaName = orderTokens[1];

                command = Console.ReadLine();
                orderTokens = command.Split();

                var dough = new Dough(orderTokens[1], orderTokens[2], double.Parse(orderTokens[3]));
                var pizza = new Pizza(pizzaName, dough);

                while ((command = Console.ReadLine()) != "END")
                {
                    orderTokens = command.Split();
                    var modifier = orderTokens[1];
                    var grams = double.Parse(orderTokens[2]);

                    pizza.AddTopping(new Topping(modifier, grams));
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }
    }
}
