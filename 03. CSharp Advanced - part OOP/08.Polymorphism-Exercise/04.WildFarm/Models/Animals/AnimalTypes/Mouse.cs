using _04.WildFarm.Models.Foods.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals.AnimalTypes
{
    public class Mouse : Mammal
    {
        private const string sound = "Squeak";

        private List<string> requiredFoods = new List<string>()
        {
            {"Vegetable"},
            {"Fruit"}
        };

        private const double weightMultiplayer = 0.10;
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
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
            if (requiredFoods.Any(f => f == foodType))
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * weightMultiplayer;
                return;
            }
            throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
