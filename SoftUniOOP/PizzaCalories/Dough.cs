using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{

    public class Dough
    {
        private string flowerType;
        private double flowerCalories;

        private string bakingTechnique;
        private double bakingCalories;

        private double grams;

        public Dough(string flowerType, string bakingTechnique, double grams)
        {
            FlowerType = flowerType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }

        public string FlowerType 
        { 
            get => flowerType;
            private set 
            {
                var ingredient = value.ToLower();

                flowerCalories = (ingredient == "white") 
                    ? 1.5 
                    : (ingredient == "wholegrain")
                    ? 1.0 
                    : throw new ArgumentException("Invalid type of dough.");

                flowerType = value;
            } 
        }

        public string BakingTechnique 
        { 
            get => bakingTechnique;
            private set
            {
                var technique = value.ToLower();

                bakingCalories = (technique == "crispy")
                         ? 0.9 
                         : (technique == "chewy")
                         ? 1.1 
                         : (technique == "homemade")
                         ? 1.0 
                         : throw new ArgumentException("Invalid type of dough.");

                bakingTechnique = value;
            }
        }

        public double Grams 
        {
            get => grams;
            private set
            {
                var isInRange = value >= 1 && value <= 200;

                if (!isInRange)
                    throw new ArgumentException("Dough weight should be in the range [1..200].");

                grams = value;
            }
        }

        public double Calories 
            => (2 * grams) * flowerCalories * bakingCalories;
    }
}
