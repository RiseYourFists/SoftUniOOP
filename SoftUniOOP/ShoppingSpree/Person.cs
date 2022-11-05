using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (value.Length == 0)
                    throw new ArgumentException("Name cannot be empty");
                name = value;
            }
        }

        public double Money 
        {
            get => money;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Money cannot be negative");
                money = value;
            }
        }

        private List<Product> BagOfProducts { get; set; }

        public void BuyProduct(Product product)
        {
            if (money - product.Cost >= 0)
            {
                BagOfProducts.Add(product);
                Console.WriteLine($"{name} bought {product.Name}");
                money -= product.Cost;
                return;
            }
            Console.WriteLine($"{name} can't afford {product.Name}");
        }

        public void ShowBasket()
        {
            var list = (BagOfProducts.Count > 0) ? GetProducts() : "Nothing bought";

            Console.WriteLine($"{name} - {list}");
        }

        private string GetProducts()
        {
            var products = new List<string>();
            BagOfProducts.ForEach(x => products.Add(x.Name));
            return string.Join(", ", products);
        }
    }
}
