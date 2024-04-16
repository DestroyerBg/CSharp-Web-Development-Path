using System.Drawing;

namespace _08.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfEngines = int.Parse(Console.ReadLine());
            var engines = new List<Engine>();
            var cars = new List<Car>();
            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (data.Length == 4)
                {
                    string model = data[0];
                    int power = int.Parse(data[1]);
                    int displacement = int.Parse(data[2]);
                    string efficency = data[3];
                    Engine engine = new Engine(model,power, displacement,efficency);
                    engines.Add(engine);
                }
                else if (data.Length == 3)
                {
                    string model = data[0];
                    int power = int.Parse(data[1]);
                    if (int.TryParse(data[2],out int result))
                    {
                        int displacement = result;
                        Engine engine = new Engine(model, power, displacement);
                        engines.Add(engine);
                    }
                    else
                    {
                        string efficency = data[2];
                        Engine engine = new Engine(model, power, efficency);
                        engines.Add(engine);
                    }
                }
                else if (data.Length == 2)
                {
                    string model = data[0];
                    int power = int.Parse(data[1]);
                    Engine engine = new Engine(model, power);
                    engines.Add(engine);
                }
            }
            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (data.Length == 4)
                {
                    string model = data[0];
                    Engine engine = engines.Find(x => x.Model == data[1]);
                    int weight = int.Parse(data[2]);
                    string color = data[3];
                    Car car = new Car(model, engine, color, weight);
                    cars.Add(car);
                }
                else if (data.Length == 3)
                {
                    string model = data[0];
                    Engine engine = engines.Find(x => x.Model == data[1]);
                    if (int.TryParse(data[2],out int result))
                    {
                        int weight = result;
                        Car car = new Car(model, engine, weight);
                        cars.Add(car);
                    }
                    else 
                    {
                        string color = data[2];
                        Car car = new Car(model, engine, color);
                        cars.Add(car);
                    }
                }
                else if (data.Length == 2)
                {
                    string model = data[0];
                    Engine engine = engines.Find(x => x.Model == data[1]);
                    Car car = new Car(model, engine);
                    cars.Add(car);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}

