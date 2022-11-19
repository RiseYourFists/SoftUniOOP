using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Paladin : Healer
    {
        public Paladin(string name) 
            : base(name)
        {
            Power = 100;
        }
    }
}
