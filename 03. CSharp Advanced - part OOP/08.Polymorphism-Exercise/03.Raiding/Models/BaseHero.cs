using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.Raiding.Models.Interfaces;

namespace _03.Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        protected BaseHero(string name,int power)
        {
            Name = name;
            Power = power;
        }
        public string Name { get; }
        public int Power { get; }
        public abstract string CastAbility();
    }
}
