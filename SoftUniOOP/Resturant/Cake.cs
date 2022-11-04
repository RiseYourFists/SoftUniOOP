namespace Resturant
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Cake : Dessert
    {
        public static double cakeGrams = 250;
        public static double cakeCalories = 1000;
        public static decimal cakePrice = 5;


        public Cake(string name) 
            : base(name, cakePrice, cakeGrams, cakeCalories)
        {
            
        }
         
    }
}
