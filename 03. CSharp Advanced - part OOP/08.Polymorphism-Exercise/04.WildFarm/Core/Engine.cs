using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.Vehicles.IO;
using _01.Vehicles.IO.Interfaces;
using _04.WildFarm.Factories;
using _04.WildFarm.Factories.Interfaces;
using _04.WildFarm.Models.Animal.Interfaces;
using _04.WildFarm.Models.Animals.AnimalTypes;
using _04.WildFarm.Models.Foods.Interfaces;

namespace _01.Vehicles.Core.Interfaces
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IAnimalFactory animalFactory;
        private IFoodFactory foodFactory;

        public Engine()
        {
            reader = new Reader();
            writer = new Writer();
            animalFactory = new AnimalFactory();
            foodFactory = new FoodFactory();
        }

        public void Run()
        {
            var animals = new List<IAnimal>();
            string input = string.Empty;
            while ((input = reader.ReadLine()) != "End")
            {
                string[] animalData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    IAnimal animal = animalFactory.CreateAnimal(animalData);
                    writer.WriteLine(animal.ProduceSound());
                    animals.Add(animal);
                    string[] foodData = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    IFood food = foodFactory.CreateFood(foodData);
                    animal.Eat(food);
                }
                catch (ArgumentException error)
                {
                    writer.WriteLine(error.Message);
                }
            }

            foreach (var animal in animals)
            {
                writer.WriteLine(animal.ToString());
            }
        }
    }
}
