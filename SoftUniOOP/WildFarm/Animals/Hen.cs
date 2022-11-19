using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            WeightGain = 0.35;
        }

        public override string MakeSound()
            => "Cluck";
    }
}
