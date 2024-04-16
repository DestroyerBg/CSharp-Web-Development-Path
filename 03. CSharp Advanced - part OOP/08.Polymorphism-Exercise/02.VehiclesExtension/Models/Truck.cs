using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.Vehicles.IO;
using _01.Vehicles.IO.Interfaces;
using _01.Vehicles.Models.Interfaces;

namespace _01.Vehicles.Models
{
    public class Truck : IDrivable
    {
        private const double FuelIncrease = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
        }
        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; private set; }
        public double TankCapacity { get; private set; }
        private double AirConditionerFuelConsumptionIncrease => FuelIncrease;
        public string Drive(double distance)
        {
            double totalConsumptioPerKm = FuelConsumption + AirConditionerFuelConsumptionIncrease;
            double requiredFuel = distance * totalConsumptioPerKm;
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

            FuelQuantity += liters * 0.95;
        }

        public override string ToString()
        {
            return $"Truck: {FuelQuantity:F2}";
        }
    }
}
