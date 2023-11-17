using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Raiding
{
    internal class Paladin : BaseHero
    {
        internal Paladin(string name) : base(name, 100)
        {

        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
