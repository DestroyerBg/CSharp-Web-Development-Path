using System;
using _06.SpeedRacing;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string model = data[0];
                double fuelAmount = double.Parse(data[1]);
                double fuelConsumption = double.Parse(data[2]);
                Car car = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(car);
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string model = data[1];
                double distance = double.Parse(data[2]);
                cars.FirstOrDefault(c=>c.Model==model).Drive(model,distance);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}