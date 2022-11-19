using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue : Fighter
    {
        public Rogue(string name) 
            : base(name)
        {
            Power = 80;
        }
    }
}
