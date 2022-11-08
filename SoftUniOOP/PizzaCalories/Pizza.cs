using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                name = value;
            }
        }

        public int ToppingsCount
            => toppings.Count;

        public double TotalCalories
        {
            get
            {
                var calories = 0d;

                toppings.ForEach(x => calories += x.Calories);
                calories += Dough.Calories;

                return calories;
            }
        }

        public Dough Dough
        {
            get => dough;
            set => dough = value;
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count <= 10)
            {
                toppings.Add(topping);
                return;
            }

            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
    }
}
