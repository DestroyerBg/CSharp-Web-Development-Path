namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            var allTires = new List<List<Tire>>();
            var allEngines = new List<Engine>();
            var allCars = new List<Car>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] data = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var currComplectTires = new List<Tire>();
                for (int i = 0; i < data.Length; i+=2)
                {
                    int year = int.Parse(data[i]);
                    double pressure = double.Parse(data[i+1]);
                    Tire tire = new Tire(year, pressure);
                    currComplectTires.Add(tire);
                }
                allTires.Add(currComplectTires);
            }

            
            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] data = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                int horsePower = int.Parse(data[0]);
                double cubics = double.Parse(data[1]);
                Engine engine = new Engine(horsePower, cubics);
                allEngines.Add(engine);
            }


            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] data = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string make = data[0];
                string model = data[1];
                int year = int.Parse(data[2]);
                double fuelQuantity = double.Parse(data[3]);
                double fuelConsumption = double.Parse(data[4]);
                int engineIndex = int.Parse(data[5]);
                int tireIndex = int.Parse(data[6]);
                Car car = new Car(make, model, year, fuelQuantity, 
                    fuelConsumption, allEngines[engineIndex], allTires[tireIndex].ToArray());
                allCars.Add(car);
            }

            var specialCars = allCars
                .FindAll(x => x.Engine.HorsePower > 330 &&
                              x.Year>=2017 &&
                              x.Tires.Select(t => t.Pressure).Sum() >= 9 &&
                              x.Tires.Select(t => t.Pressure).Sum() <= 10).ToList();
            if (specialCars.Any())
            {
                foreach (var car in specialCars)
                {
                    car.Drive(20);
                    Console.WriteLine(car);
                }

            }
        }
    }
}