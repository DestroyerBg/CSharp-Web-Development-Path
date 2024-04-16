using System.Diagnostics;
using System.Reflection;

namespace Vehicle_Catalogue
{
    class Car
    {
        public Car(string brand, string model, string hp)
        {
            Brand = brand;
            Model = model;
            HorsePower = hp;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public string HorsePower { get; set; }
        public override string ToString()
        {
            string result = $"{Brand}: {Model} - {HorsePower}hp";
            return result ;


        }
    }
    class Truck
    {
        public Truck(string brand, string model, string kG)
        {
            Brand = brand;
            Model = model;
            Kilogramm = kG;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public string Kilogramm { get; set; }
        public override string ToString()
        {
            string result = $"{Brand}: {Model} - {Kilogramm}kg";
            return result;


        }

    }

    




    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<Car> carCollection = new List<Car>();
            List<Truck> truckCollection = new List<Truck>();
            while ((input = Console.ReadLine()) != "end")
            {
                List<string> carInfo = input
                    .Split("/")
                    .ToList();
                string type = carInfo[0];
                string brand = carInfo[1];
                string model = carInfo[2];
                string hp = carInfo[3];
                string kG = carInfo[3];

                if (type == "Car")
                {
                    Car car = new Car(brand, model, hp);
                    carCollection.Add(car);


                }
                else if (type == "Truck")
                {
                    Truck truck = new Truck(brand, model, kG);
                    truckCollection.Add(truck);

                }
            }

            List<Car> sortedCarList = carCollection.OrderBy(car =>car.Brand).ToList();
            List<Truck> sortedTruckList = truckCollection.OrderBy(truck => truck.Brand).ToList();
            if (sortedCarList.Count>0)
            {
                Console.WriteLine("Cars:");
                foreach (Car car in sortedCarList)
                {
                    Console.WriteLine($"{car.ToString()}");
                }
            }

            if (sortedTruckList.Count>0)
            {
                Console.WriteLine($"Trucks:");
                foreach (Truck truck in sortedTruckList)
                {
                    Console.WriteLine($"{truck.ToString()}");
                }
            }
           
            

        }
    }

}