using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private const double BaseCaloriesPerGram = 2;
        private const int MinGrams = 1;
        private const int MaxGrams = 50;
        private Dictionary<string, double> typesOfToppingCalories;
        private string type;
        private double weight;
        

        public Topping(string type, double weight)
        {
            typesOfToppingCalories = new Dictionary<string, double>()
            {
                {"meat",1.2},
                {"veggies",0.8},
                {"cheese",1.1},
                {"sauce", 0.9}

            };
            Type = type;
            Weight = weight;
        }

        public string Type
        {
            get => type;
            set
            {
                if (!typesOfToppingCalories.ContainsKey(value.ToLower()))
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }

        public double Weight
        {
            get => weight;
            set
            {
                if (value < MinGrams || value > MaxGrams)
                {
                    throw new Exception($"{Type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public double CalculateCalories()
        {
            double toppingCalories = typesOfToppingCalories.FirstOrDefault(p=>p.Key == Type.ToLower()).Value;
            double calculate = BaseCaloriesPerGram * toppingCalories * Weight;
            return calculate;
        }
    }
}
