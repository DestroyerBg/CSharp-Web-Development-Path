using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private const int MinNameSymbols = 1;
        private const int MaxNameSymbols = 15;
        private List<Topping> toppings;
        private string name;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public Dough Dough { get; set; }
        

        public string Name
        {
            get => name;
            private set
            {
                if (value.Length < MinNameSymbols || value.Length > MaxNameSymbols)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public void AddToping(Topping topping)
        {
            if (toppings.Count < 10)
            {
                toppings.Add(topping);
            }
            else
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
        }
        private double CalculatePizzaCalories()
        {
            double topingCalories = 0;
            foreach (var toping in toppings)
            {
                topingCalories += toping.CalculateCalories();
            }

            double doughtCalories = Dough.Calories;
            double pizzaCalories = topingCalories + doughtCalories;
            return pizzaCalories;
        }

        public override string ToString()
        {
            return $"{Name} - {CalculatePizzaCalories():f2} Calories.";
        }
    }
}
