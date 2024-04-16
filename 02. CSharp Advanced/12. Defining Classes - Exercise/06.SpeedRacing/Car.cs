using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SpeedRacing
{
    public class Car
    {
        public Car(string model,double fuelAmount,double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumption;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(string model, double distance)
        {
            if ((distance * FuelConsumptionPerKilometer)<= FuelAmount)
            {
                TravelledDistance += distance;
                FuelAmount -= distance * FuelConsumptionPerKilometer;
                return;
            }

            Console.WriteLine($"Insufficient fuel for the drive");
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {TravelledDistance}";
        }
    }
}
