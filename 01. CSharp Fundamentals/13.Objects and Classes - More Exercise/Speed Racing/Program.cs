namespace Speed_Racing
{
    class Car
    {
        public Car(string name, decimal fuelAmount, decimal fuelConsumption, decimal travelledDistance)
        {
            Name = name;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
            TravelledDistance = travelledDistance;
        }

        public string Name { get; set; }
        public decimal FuelAmount { get; set; }
        public decimal FuelConsumption { get; set;}
        public decimal TravelledDistance { get; set; }
        public override string ToString()
        {
            return $"{Name} {FuelAmount:f2} {TravelledDistance}";
        }
    }

    class Vehicles
    {
        public Vehicles(List<Car> cars)
        {
            Cars = cars;
        }

        public List<Car> Cars { get; set; }

        public List<Car> Drive(string name, decimal kilometres)
        {
            decimal usedFuel = kilometres * Cars.FirstOrDefault(x => x.Name == name).FuelConsumption;
            if (usedFuel <= Cars.FirstOrDefault(x => x.Name == name).FuelAmount)
            {
                Cars.FirstOrDefault(x => x.Name == name).FuelAmount-=usedFuel;
                Cars.FirstOrDefault(x => x.Name == name).TravelledDistance += kilometres;
                return Cars;
            }

            Console.WriteLine($"Insufficient fuel for the drive");
            return Cars;
        }


    }


    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            Vehicles vehicles= new Vehicles(new List<Car>());
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carData = Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = carData[0];
                decimal fuelAmount= decimal.Parse(carData[1]);
                decimal fuelConsumption= decimal.Parse(carData[2]);
                decimal travelledDistance = 0m;
                Car car = new Car(name, fuelAmount, fuelConsumption, travelledDistance);
                vehicles.Cars.Add(car);
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                
                string car = arguments[1];
                decimal kilometres= decimal.Parse(arguments[2]);
                vehicles.Drive(car,kilometres);
                
            }

            foreach (var car in vehicles.Cars)
            {
                Console.WriteLine($"{car.ToString()}");
            }
        }
    }
}