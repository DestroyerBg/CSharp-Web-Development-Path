using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.WildFarm.Models.Foods.Interfaces;

namespace _04.WildFarm.Models.Animals.AnimalTypes
{
    public class Owl : Bird
    {
        private const string sound = "Hoot Hoot";
        private List<string> requiredFoods = new List<string>()
        {
            {"Meat"}
        };

        private const double weightMultiplayer = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
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
            string foodType = food.GetType().Name;
            if (requiredFoods.Any(f=>f == foodType))
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * weightMultiplayer;
                return;
            }
            throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
