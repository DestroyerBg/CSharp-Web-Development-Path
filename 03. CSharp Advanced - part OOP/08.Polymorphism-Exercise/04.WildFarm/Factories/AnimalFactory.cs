using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using _04.WildFarm.Factories.Interfaces;
using _04.WildFarm.Models.Animal.Interfaces;
using _04.WildFarm.Models.Animals.AnimalTypes;

namespace _04.WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] animalData)
        {
            IAnimal animal = null;
            string animalType = animalData[0];
            if (animalType == "Owl")
            {
                string name = animalData[1];
                double weight = double.Parse(animalData[2]);
                double wingSize = double.Parse(animalData[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (animalType == "Hen")
            {
                string name = animalData[1];
                double weight = double.Parse(animalData[2]);
                double wingSize = double.Parse(animalData[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else if (animalType == "Mouse")
            {
                string name = animalData[1];
                double weight = double.Parse(animalData[2]);
                string livingRegion = animalData[3];
                animal = new Mouse(name, weight, livingRegion);
            }
            else if (animalType == "Dog")
            {
                string name = animalData[1];
                double weight = double.Parse(animalData[2]);
                string livingRegion = animalData[3];
                animal = new Dog(name, weight, livingRegion);
            }
            else if (animalType == "Cat")
            {
                string name = animalData[1];
                double weight = double.Parse(animalData[2]);
                string livingRegion = animalData[3];
                string breed = animalData[4];
                animal = new Cat(name,weight,livingRegion,breed);
            }
            else if (animalType == "Tiger")
            {
                string name = animalData[1];
                double weight = double.Parse(animalData[2]);
                string livingRegion = animalData[3];
                string breed = animalData[4];
                animal = new Tiger(name, weight, livingRegion, breed);
            }

            return animal;
        }
    }
}
