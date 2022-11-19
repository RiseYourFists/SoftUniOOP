using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            WeightGain = 0.10;
        }

        public override string MakeSound()
            => "Squeak";
    }
}
