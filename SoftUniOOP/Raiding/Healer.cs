using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class Healer : BaseHero
    {
        public Healer(string name) 
            : base(name)
        {
        }

        public override string CastAbility()
            => $"{GetType().Name} - {Name} healed for {Power}";
    }
}
