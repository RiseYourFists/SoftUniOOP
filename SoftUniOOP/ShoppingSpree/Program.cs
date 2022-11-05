using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            var people = new Dictionary<string, Person>();
            var shop = new Dictionary<string, Product>();

            try
            {
                var peopleTokens = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (var person in peopleTokens)
                {
                    var tokens = person.Split('=');
                    var newPerson = new Person(tokens[0], double.Parse(tokens[1]));
                    if (!people.ContainsKey(tokens[0]))
                        people.Add(tokens[0], newPerson);
                }

                var products = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (var product in products)
                {
                    var tokens = product.Split('=');
                    var newProduct = new Product(tokens[0], double.Parse(tokens[1]));
                    if (!shop.ContainsKey(tokens[0]))
                        shop.Add(tokens[0], newProduct);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                var tokens = command.Split(' ');
                people[tokens[0]].BuyProduct(shop[tokens[1]]);
            }

            foreach (var person in people)
            {
                person.Value.ShowBasket();
            }
        }
    }
}
