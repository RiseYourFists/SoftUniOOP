using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;


        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");
                name = value;
            }
        }

        public decimal Money 
        {
            get => money;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Money cannot be negative");
                money = value;
            }
        }


        public void BuyProduct(Product product)
        {
            if (money - product.Cost >= 0)
            {
                bagOfProducts.Add(product);
                Console.WriteLine($"{name} bought {product.Name}");
                money -= product.Cost;
                return;
            }
            Console.WriteLine($"{name} can't afford {product.Name}");
        }

        public void ShowBasket()
        {
            var list = (bagOfProducts.Count > 0) ? GetProducts() : "Nothing bought";

            Console.WriteLine($"{name} - {list}");
        }

        private string GetProducts()
        {
            var products = new List<string>();
            bagOfProducts.ForEach(x => products.Add(x.Name));
            return string.Join(", ", products);
        }
    }
}
