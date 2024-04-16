using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.WildFarm.Models.Foods.Interfaces;

namespace _04.WildFarm.Factories.Interfaces
{
    public interface IFoodFactory
    {
        IFood CreateFood(string[] foodData);
    }
}
