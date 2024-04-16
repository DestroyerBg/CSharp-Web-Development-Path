using _04.WildFarm.Models.Foods.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals.AnimalTypes
{
    public class Hen : Bird
    {
        private const string sound = "Cluck";
        private const double weightMultiplayer = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }
        public override double Weight { get; set; }
        public override int FoodEaten { get; set; }
        public override string ProduceSound()
        {
            return sound;
        }

        public override void Eat(IFood food)
        {
            FoodEaten += food.Quantity;
            Weight += food.Quantity * weightMultiplayer;
        }
        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }

    }
}
