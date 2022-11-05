using System;

namespace ShoppingSpree
{
    public class Product
    {
        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name { get; private set; }

        public double Cost { get; private set; }
    }
}