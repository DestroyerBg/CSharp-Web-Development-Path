using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer;

internal class Car
{
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
    public string Make { get; set; }

    public string Model { get; set; }

    public int Year { get; set; }

    public double FuelQuantity { get; set; }

    public double FuelConsumption { get; set; }



    public void Drive(double distance)
    {
        if (distance * FuelConsumption <= FuelQuantity)
        {
            FuelQuantity -= FuelConsumption * distance;
        }
        else
        {
            Console.WriteLine($"Not enough fuel to perform this trip!");
        }
    }

    public string WhoAmI()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"Make: {this.Make}");
        result.AppendLine($"Model: {this.Model}");
        result.AppendLine($"Year: {this.Year}");
        result.AppendLine($"Fuel: {this.FuelQuantity:F2}");
        return result.ToString();
    }
}
