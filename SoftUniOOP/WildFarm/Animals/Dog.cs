using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            WeightGain = 0.4;
        }

        public override string MakeSound()
            => "Woof!";
    }
}
