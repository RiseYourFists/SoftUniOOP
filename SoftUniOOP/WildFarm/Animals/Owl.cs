using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            WeightGain = 0.25;
        }

        public override string MakeSound()
            => "Hoot Hoot";
    }
}
