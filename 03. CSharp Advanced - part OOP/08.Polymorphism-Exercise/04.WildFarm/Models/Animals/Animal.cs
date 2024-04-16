using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.WildFarm.Models.Animal.Interfaces;
using _04.WildFarm.Models.Foods.Interfaces;

namespace _04.WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
        public string Name { get; private set; }
        public abstract double Weight { get; set; }
        public abstract int FoodEaten { get; set; }
        public abstract string ProduceSound();
        public abstract void Eat(IFood food);

    }
}
