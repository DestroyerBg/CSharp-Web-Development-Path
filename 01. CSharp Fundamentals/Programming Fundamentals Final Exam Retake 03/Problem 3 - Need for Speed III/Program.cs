using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Problem_3___Need_for_Speed_III
{
    class Car
    {
        public Car(string carModel, int distance, int fuel)
        {
            Model = carModel;
            Distance = distance;
            Fuel = fuel;
        }

        public string Model { get; set; }
        public int Distance { get; set; }
        public int Fuel { get; set; }
        public override string ToString()
        {
            return $"{Model} -> Mileage: {Distance} kms, Fuel in the tank: {Fuel} lt.";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carsInfo = Console
                    .ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string carModel = carsInfo[0];
                int distance = int.Parse(carsInfo[1]);
                int fuel = int.Parse(carsInfo[2]);
                Car car = new Car(carModel, distance, fuel);
                cars.Add(car);
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] arguments = input
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string instruction = arguments[0];
                if (instruction == "Drive")
                {
                    string carModel = arguments[1];
                    int distance = int.Parse(arguments[2]);
                    int fuel = int.Parse(arguments[3]);
                    Drive(carModel, distance, fuel, cars);
                }
                else if (instruction == "Refuel")
                {
                    string carModel = arguments[1];
                    int fuel = int.Parse(arguments[2]);
                    Refuel(carModel, fuel, cars);
                }
                else if (instruction == "Revert")
                {
                    string carModel = arguments[1];
                    int distance = int.Parse(arguments[2]);
                    RevertKilometres(carModel, distance, cars);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.ToString()}");
            }
        }

        public static List<Car> RevertKilometres(string carModel, int distance, List<Car> cars)
        {
            cars.FirstOrDefault(x=>x.Model==carModel).Distance-=distance;
            int carsMileage = cars.FirstOrDefault(x => x.Model == carModel).Distance;
            if (carsMileage<10000)
            {
                cars.FirstOrDefault(x => x.Model == carModel).Distance = 10000;
                return cars;
            }

            Console.WriteLine($"{carModel} mileage decreased by {distance} kilometers");
            return cars;
        }

        public static List<Car> Refuel(string carModel, int fuel, List<Car> cars)
        {
            if (cars.FirstOrDefault(x => x.Model == carModel).Fuel+fuel>75)
            {
                int currFuel = cars.FirstOrDefault(x => x.Model == carModel).Fuel;
                int litersToFill = 75 - currFuel;
                cars.FirstOrDefault(x => x.Model == carModel).Fuel += litersToFill;
                Console.WriteLine($"{carModel} refueled with {litersToFill} liters");
                return cars;
            }

            cars.FirstOrDefault(x => x.Model == carModel).Fuel += fuel;
            Console.WriteLine($"{carModel} refueled with {fuel} liters");
            return cars;
        }

        public static List<Car> Drive(string carModel, int distance, int fuel, List<Car> cars)
        {
            if (cars.FirstOrDefault(x=>x.Model==carModel).Fuel<fuel)
            {
                Console.WriteLine($"Not enough fuel to make that ride");
                return cars;
            }
            cars.FirstOrDefault(x => x.Model == carModel).Fuel-=fuel;
            cars.FirstOrDefault(x => x.Model == carModel).Distance += distance;
            Console.WriteLine($"{carModel} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
            if (cars.FirstOrDefault(x => x.Model == carModel).Distance>=100000)
            {
                int index = cars.FindIndex(x => x.Model==carModel);
                Console.WriteLine($"Time to sell the {carModel}!");
                cars.RemoveAt(index);
                return cars;
            }
            return cars;
        }
    }
}