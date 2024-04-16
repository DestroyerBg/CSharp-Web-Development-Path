namespace Raw_Data
{
    class Engine
    {
        public Engine(int engineSpeed, int enginePower)
        {
            Speed = engineSpeed;
            Power = enginePower;
        }

        public int Speed { get; set; }
        public int Power { get; set; }
    }

    class Cargo
    {
        public Cargo(int weight, string type)
        {
            Type = type;
            Weight = weight;
        }

        public int Weight { get; set; }
        public string Type { get; set; }
    }

    class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            Engine = engine;
            Cargo = cargo;
            Model = model;
        }

        public string Model { get; set; }
        public Cargo Cargo { get; set; }
        public Engine Engine { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> carsList = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string carModel = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Car car = new Car(carModel, engine, cargo);
                carsList.Add(car);
            }
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<Car> filteredList = carsList.FindAll(x => x.Cargo.Type == "fragile" && x.Cargo.Weight < 1000).ToList();
                foreach (var car in filteredList)
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
            else if (command == "flamable")
            {
                var filteredList = carsList.FindAll(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250);
                foreach (var car in filteredList)
                {
                    Console.WriteLine($"{car.Model}");
                }
            }

        }
    }
}