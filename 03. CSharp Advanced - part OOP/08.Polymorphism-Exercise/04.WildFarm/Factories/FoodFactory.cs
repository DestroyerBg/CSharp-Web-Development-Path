using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.WildFarm.Models.Foods;
using _04.WildFarm.Models.Foods.Interfaces;

namespace _04.WildFarm.Factories.Interfaces
{
    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string[] foodData)
        {
            string foodType = foodData[0];
            IFood food = null;
            if (foodType == "Vegetable")
            {
                int quantity = int.Parse(foodData[1]);
                food = new Vegetable(quantity);
            }
            else if (foodType == "Fruit")
            {
                int quantity = int.Parse(foodData[1]);
                food = new Fruit(quantity);
            }
            else if (foodType == "Meat")
            {
                int quantity = int.Parse(foodData[1]);
                food = new Meat(quantity);
            }
            else if (foodType == "Seeds")
            {
                int quantity = int.Parse(foodData[1]);
                food = new Seeds(quantity);
            }

            return food;
        }
    }
}
