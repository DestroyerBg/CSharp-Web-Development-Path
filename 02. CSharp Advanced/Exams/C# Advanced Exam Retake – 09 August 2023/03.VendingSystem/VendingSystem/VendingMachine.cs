using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingSystem
{
    public class VendingMachine
    {
        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;
            Drinks = new List<Drink>();
        }
        public int ButtonCapacity { get; set; }
        public List<Drink> Drinks { get; private set; }
        public int GetCount => Drinks.Count;

        public void AddDrink(Drink drink)
        {
            if (Drinks.Count < ButtonCapacity)
            {
                Drinks.Add(drink);
            }
        }

        public bool RemoveDrink(string name)
        {
            if (Drinks.Any(n=>n.Name==name))
            {
                Drinks.Remove(Drinks.Find(n => n.Name == name));
                return true;
            }

            return false;
        }

        public Drink GetLongest()
        {
            Drink longest = Drinks.MaxBy(n=>n.Volume);
            return longest;
        }

        public Drink GetCheapest()
        {
            Drink cheapest = Drinks.MinBy(n => n.Price);
            return cheapest;
        }

        public string BuyDrink(string name)
        {
            return $"{Drinks.Find(d => d.Name == name).ToString()}";
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Drinks available:");
            foreach (var drink in Drinks)
            {
                result.AppendLine(drink.ToString());
            }
            return result.ToString().TrimEnd();
        }
    }
}
