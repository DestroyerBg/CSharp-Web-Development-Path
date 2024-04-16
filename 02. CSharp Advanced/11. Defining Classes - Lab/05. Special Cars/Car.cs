using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;

        }
        public Car(string make, string model, int year) : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption
            ,Engine engine, Tire[] tires) :this(make,model,year,fuelQuantity,fuelConsumption)
        {
            Tires = tires;
            Engine = engine;
        }
        

        public void Drive(double distance)
        {
            if ((distance / 100)*FuelConsumption<=FuelQuantity)
            {
                FuelQuantity -= (distance / 100) * FuelConsumption;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Make: {Make}");
            result.AppendLine($"Model: {Model}");
            result.AppendLine($"Year: {Year}");
            result.AppendLine($"HorsePowers: {Engine.HorsePower}");
            result.AppendLine($"FuelQuantity: {FuelQuantity}");
            return result.ToString();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Make: {Make}");
            result.AppendLine($"Model: {Model}");
            result.AppendLine($"Year: {Year}");
            result.AppendLine($"HorsePowers: {Engine.HorsePower}");
            result.AppendLine($"FuelQuantity: {FuelQuantity}");
            return result.ToString().TrimEnd();
        }
    }
}
