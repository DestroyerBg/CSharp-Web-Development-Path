using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _06.FoodShortage.Models.Interfaces;

namespace _06.FoodShortage.Models
{
    public class Rebel :IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            FoodId = 0;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Group { get; private set; }

        public int FoodId { get; private set; }
        public void BuyFood()
        {
            FoodId += 5;
        }
    }
}
