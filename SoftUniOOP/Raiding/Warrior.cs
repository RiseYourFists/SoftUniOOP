using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : Fighter
    {
        public Warrior(string name) 
            : base(name)
        {
            Power = 100;
        }
    }
}
