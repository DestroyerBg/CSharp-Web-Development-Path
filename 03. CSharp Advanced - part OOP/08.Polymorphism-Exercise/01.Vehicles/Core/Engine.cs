using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.Vehicles.IO;
using _01.Vehicles.IO.Interfaces;
using _01.Vehicles.Models;
using _01.Vehicles.Models.Interfaces;

namespace _01.Vehicles.Core.Interfaces
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
        }
        public void Run()
        {
            string[] carData = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double fuelQuantity = double.Parse(carData[1]);
            double litersPerKm = double.Parse(carData[2]);
            IDrivable car = new Car(fuelQuantity, litersPerKm);
            string[] truckData = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            fuelQuantity = double.Parse(truckData[1]);
            litersPerKm = double.Parse(truckData[2]);
            IDrivable truck = new Truck(fuelQuantity, litersPerKm);
            int numberOfInputs = int.Parse(reader.ReadLine());
            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] data = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string instruction = data[0];
                if (instruction == "Drive")
                {
                    DriveVehicle(data, car, truck);
                }
                else if (instruction == "Refuel")
                {
                    RefuelVehicle(data, car, truck);
                }
            }
            writer.WriteLine(car.ToString());
            writer.WriteLine(truck.ToString());
        }


        private void DriveVehicle(string[] data, IDrivable car, IDrivable truck)
        {
            string vehicleType = data[1];
            if (vehicleType == "Car")
            {
                double distance = double.Parse(data[2]);
                writer.WriteLine(car.Drive(distance));
            }
            else if (vehicleType == "Truck")
            {
                double distance = double.Parse(data[2]);
                writer.WriteLine(truck.Drive(distance));
            }
        }
        private void RefuelVehicle(string[] data, IDrivable car, IDrivable truck)
        {
            string vehicleType = data[1];
            if (vehicleType == "Car")
            {
                double liters = double.Parse(data[2]);
                car.Refuel(liters);
            }
            else if (vehicleType == "Truck")
            {
                double liters = double.Parse(data[2]);
                truck.Refuel(liters);
            }
        }



    }
}
