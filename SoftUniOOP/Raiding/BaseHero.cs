using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero
    {
        protected BaseHero(string name)
        {
            Name = name;
            Power = 0;
        }

        public string Name { get; set; }

        public int Power { get; set; }

        public abstract string CastAbility();
    }
}
