using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class Fighter : BaseHero
    {
        public Fighter(string name) : base(name)
        {
        }

        public override string CastAbility()
            => $"{GetType().Name} - {Name} hit for {Power} damage";
    }
}
