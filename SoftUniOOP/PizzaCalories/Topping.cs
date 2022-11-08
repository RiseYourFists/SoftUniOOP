using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string modifier;
        private double calories;
        private double grams;

        public Topping(string modifier, double grams)
        {
            Modifier = modifier;
            Grams = grams;
        }

        public string Modifier 
        { 
            get => modifier;
            private set
            {
                var ingredient = value.ToLower();

                calories = (ingredient == "meat")
                    ? 1.2
                    : (ingredient == "veggies")
                    ? 0.8
                    : (ingredient == "cheese")
                    ? 1.1
                    : (ingredient == "sauce")
                    ? 0.9
                    : throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                modifier = value;
            }
        }

        public double Grams 
        {
            get => grams;
            private set
            {
                if (!(value >= 1 && value <= 50))
                    throw new ArgumentException($"{modifier} weight should be in the range [1..50].");
                grams = value;
            }
        }

        public double Calories 
            => 2 * (grams * calories);
    }
}
