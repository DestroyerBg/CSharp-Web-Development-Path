using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals
{
    public abstract class Felines : Mammal
    {
        protected Felines(string name, double weight, string livingRegion,string breed) : base(name, weight, livingRegion)
        {
            Breed = breed;
        }
        public string Breed { get; private set; }
    }
}
