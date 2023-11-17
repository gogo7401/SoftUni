using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Raiding
{
    public abstract class BaseHero
    {
        protected BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public string Name { get; }

        public int Power { get; }
        public abstract string CastAbility();
    }
}
