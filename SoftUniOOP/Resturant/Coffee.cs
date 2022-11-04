namespace Resturant
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Coffee : HotBeverage
    {
        public const double coffeeMilliliters = 50;
        public const decimal coffeePrice = 3.50m;

        public Coffee(string name, double caffeine) 
            : base(name, coffeePrice, coffeeMilliliters)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
