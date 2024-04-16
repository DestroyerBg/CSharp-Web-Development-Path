using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = string.Empty;
            var animals = new List<Animal>();
            while ((input = Console.ReadLine()) != "Beast!")
            {
                string type = input;
                string[] data = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (type == "Cat")
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string gender = data[2];
                    var cat = new Cat(name, age, gender);
                    animals.Add(cat);
                }
                else if (type == "Dog")
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string gender = data[2];
                    var dog = new Dog(name, age, gender);
                    animals.Add(dog);
                }
                else if (type == "Frog")
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string gender = data[2];
                    var frog = new Frog(name, age, gender);
                    animals.Add(frog);
                }
                else if (type == "Tomcat")
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    var tomcat = new Tomcat(name, age);
                    animals.Add(tomcat);
                }
                else if (type == "Kitten")
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    var kitten = new Kitten(name, age);
                    animals.Add(kitten);
                }

            }

            foreach (var animal in animals)
            {
                Console.WriteLine($"{animal.GetType().Name}");
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine($"{animal.ProduceSound()}");
            }
        }
    }
}
