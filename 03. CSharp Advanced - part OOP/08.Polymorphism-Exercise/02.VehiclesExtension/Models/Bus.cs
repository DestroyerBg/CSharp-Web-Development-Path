using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.Vehicles.IO;
using _01.Vehicles.IO.Interfaces;
using _01.Vehicles.Models.Interfaces;

namespace _02.VehiclesExtension.Models
{
    public class Bus : IDrivable
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
        }
        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; private set; }
        public double TankCapacity { get; private set; }
        public string Drive(double distance)
        {
            double requiredFuel = distance * (FuelConsumption + 1.4);
            if (FuelQuantity >= requiredFuel)
            {
                FuelQuantity -= requiredFuel;
                return $"{GetType().Name} travelled {distance} km";
            }

            return $"{GetType().Name} needs refueling";
        }

        public string DriveEmpty(double distance)
        {
            double requiredFuel = distance * FuelConsumption;
            if (FuelQuantity >= requiredFuel)
            {
                FuelQuantity -= requiredFuel;
                return $"{GetType().Name} travelled {distance} km";
            }

            return $"{GetType().Name} needs refueling";
        }

        public void Refuel(double liters)
        {
            IWriter writer = new Writer();
            if (liters <= 0)
            {
                writer.WriteLine($"Fuel must be a positive number");
                return;
            }
            if (FuelQuantity + liters > TankCapacity)
            {
                writer.WriteLine($"Cannot fit {liters} fuel in the tank");
                return;
            }

            FuelQuantity += liters;

        }

        public override string ToString()
        {
            return $"Bus: {FuelQuantity:f2}";
        }
    }
}

