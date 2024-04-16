using System.Threading.Channels;

namespace _07.RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int carNum = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            for (int i = 0; i < carNum; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string model = data[0];
                int engineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);
                int cargoWeight = int.Parse(data[3]);
                string cargoType = data[4];
                double tire1Pressure = double.Parse(data[5]);
                int tire1Age = int.Parse(data[6]);
                double tire2Pressure = double.Parse(data[7]);
                int tire2Age = int.Parse(data[8]);
                double tire3Pressure = double.Parse(data[9]);
                int tire3Age = int.Parse(data[10]);
                double tire4Pressure = double.Parse(data[11]);
                int tire4Age = int.Parse(data[12]);
                Car car = new Car(model,
                    engineSpeed, 
                    enginePower, 
                    cargoWeight, 
                    cargoType, 
                    tire1Pressure, 
                    tire1Age, 
                    tire2Pressure, 
                    tire2Age,
                    tire3Pressure, 
                    tire3Age, 
                    tire4Pressure, 
                    tire4Age);
                cars.Add(car);
            }
            string filter = Console.ReadLine();
            if (filter == "fragile")
            {
                var filterCars = cars.FindAll(c => c.Cargo.CargoType == filter 
                                                   && c.Tires.Any(t => t.Pressure < 1));
                filterCars.ForEach(x=>Console.WriteLine(x.Model));
            }
            else if (filter == "flammable")
            {
                var filterCars = cars.FindAll(c => c.Cargo.CargoType == filter
                                                   && c.Engine.Power > 250);
                filterCars.ForEach(x => Console.WriteLine(x.Model));
            }

            
        }
    }
}