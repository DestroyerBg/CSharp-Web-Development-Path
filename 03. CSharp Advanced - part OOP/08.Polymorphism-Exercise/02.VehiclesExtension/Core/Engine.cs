using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.Vehicles.IO;
using _01.Vehicles.IO.Interfaces;
using _01.Vehicles.Models;
using _01.Vehicles.Models.Interfaces;
using _02.VehiclesExtension.Models;

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
            IDrivable car = CreateCar(carData);
            string[] truckData = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            IDrivable truck = CreateTruck(truckData);
            string[] busData = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Bus bus = CreateBus(busData);
            int numberOfInputs = int.Parse(reader.ReadLine());
            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] data = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string instruction = data[0];
                if (instruction.Contains("Drive"))
                {
                    DriveVehicle(data, car, truck,bus);
                }
                else if (instruction == "Refuel")
                {
                    RefuelVehicle(data, car, truck, bus);
                }
            }
            writer.WriteLine(car.ToString());
            writer.WriteLine(truck.ToString());
            writer.WriteLine(bus.ToString());
        }

        private Bus CreateBus(string[] busData)
        {
            double fuelQuantity = double.Parse(busData[1]);
            double litersPerKm = double.Parse(busData[2]);
            double tankCapacity = double.Parse(busData[3]);
            if (fuelQuantity > tankCapacity)
            {
                fuelQuantity = 0;
            }
            Bus bus = new Bus(fuelQuantity, litersPerKm, tankCapacity);
            return bus;
        }

        private IDrivable CreateTruck(string[] truckData)
        {
            double fuelQuantity = double.Parse(truckData[1]);
            double litersPerKm = double.Parse(truckData[2]);
            double tankCapacity = double.Parse(truckData[3]);
            if (fuelQuantity > tankCapacity)
            {
                fuelQuantity = 0;
            }
            IDrivable truck = new Truck(fuelQuantity, litersPerKm, tankCapacity);
            return truck;
        }

        private IDrivable CreateCar(string[] carData)
        {
            double fuelQuantity = double.Parse(carData[1]);
            double litersPerKm = double.Parse(carData[2]);
            double tankCapacity = double.Parse(carData[3]);
            if (fuelQuantity > tankCapacity)
            {
                fuelQuantity = 0;
            }
            IDrivable car = new Car(fuelQuantity, litersPerKm, tankCapacity);
            return car;
        }


        private void DriveVehicle(string[] data, IDrivable car, IDrivable truck, Bus bus)
        {
            string vehicleType = data[1];
            double distance = double.Parse(data[2]);
            if (vehicleType == "Car")
            {
                writer.WriteLine(car.Drive(distance));
            }
            else if (vehicleType == "Truck")
            {
                writer.WriteLine(truck.Drive(distance));
            }
            else if (vehicleType == "Bus")
            {
                if (data[0] == "DriveEmpty")
                {
                    writer.WriteLine(bus.DriveEmpty(distance));
                }
                else if (data[0] == "Drive")
                {
                    writer.WriteLine(bus.Drive(distance));
                }
            }
            
        }
        private void RefuelVehicle(string[] data, IDrivable car, IDrivable truck, IDrivable bus)
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
            else if (vehicleType == "Bus")
            {
                double liters = double.Parse(data[2]);
                bus.Refuel(liters);
            }

        }



    }
}
