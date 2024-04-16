using System.Xml.Schema;

namespace Vehicle_Catalogue
{
    
    class Vehicle
    {

        public Vehicle(string typeOfVehicle, string model, string color, double hp)
        {
            TypeOfVehicle = typeOfVehicle;
            Model = model;
            Color = color;
            Hp = hp;

        }

        public string TypeOfVehicle { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double Hp { get; set; }
        public override string ToString()
        {
            return $"Type: {TypeOfVehicle}\n" +
                   $"Model: {Model}\n" +
                   $"Color: {Color}\n" +
                   $"Horsepower: {Hp}";

        }
        
        
    }

    

    internal class Program
    {
        static void Main(string[] args)
        {
            string input=string.Empty;
            List<Vehicle> allVehicles = new List<Vehicle>();
            while ((input = Console.ReadLine()) != "End")
            {
                string[] vehicleInfo= input
                    .Split(" ")
                    .ToArray();
                string typeOfVehicle = vehicleInfo[0];
                typeOfVehicle = char.ToUpper(typeOfVehicle[0]) + typeOfVehicle.Substring(1);
                string model = vehicleInfo[1];
                string color = vehicleInfo[2];
                double hp = double.Parse(vehicleInfo[3]);
                Vehicle newVehicle= new Vehicle(typeOfVehicle,model,color,hp);
                allVehicles.Add(newVehicle);
             
            }

            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                List<Vehicle> searchVehicle = allVehicles.Where(x => x.Model == input).ToList();
                searchVehicle.ForEach(x=> Console.WriteLine($"{x.ToString()}"));
            }

            double carCount = 0;
            double truckCount = 0;
            double carHpSum = 0;
            double truckHpSum = 0;
            double averageHpCars = 0;
            double averageHpTrucks = 0;
            foreach (Vehicle vehicle in allVehicles)
            {
                if (vehicle.TypeOfVehicle=="Car")
                {
                    carCount++;
                    carHpSum += vehicle.Hp;
                    averageHpCars = carHpSum / carCount;
                }

                if (vehicle.TypeOfVehicle=="Truck")
                {
                    truckCount++;
                    truckHpSum += vehicle.Hp;
                    averageHpTrucks= truckHpSum / truckCount;
                }
                
            }

            Console.WriteLine($"Cars have average horsepower of: {averageHpCars:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageHpTrucks:f2}.");

        }
    }
}