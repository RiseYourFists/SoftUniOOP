using BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Rebel : IBuyable
    {
        public Rebel(string name, string age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get; set; }

        public string Age { get; set; }

        public string Group { get; set; }

        public int FoodSupply { get; set; }

        public void BuyFood()
        {
            FoodSupply += 5;
        }
    }
}
