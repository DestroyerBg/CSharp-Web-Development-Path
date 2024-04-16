using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Models.Contracts;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private string licensePlateNumber;

        public Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            LicensePlateNumber = licensePlateNumber;
            MaxMileage = maxMileage;
            BatteryLevel = 100;
            IsDamaged = false;
        }
        public string Brand
        {
            get => brand;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Brand cannot be null or whitespace!");
                }
                brand = value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Model cannot be null or whitespace!");
                }
                model = value;
            }
        }
        public double MaxMileage { get; private set; }

        public string LicensePlateNumber
        {
            get => licensePlateNumber;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"License plate number is required!");
                }
                licensePlateNumber = value;
            }
        }

        public int BatteryLevel { get; private set; }
        
        public bool IsDamaged { get; private set; }
        public void Drive(double mileage)
        {
            double fallPercent = Math.Round((mileage / MaxMileage) * 100);
            BatteryLevel-= (int)fallPercent;
            if (this is CargoVan)
            {
                BatteryLevel -= 5;
            }
        }

        public void Recharge()
        {
            BatteryLevel = 100;
        }

        public void ChangeStatus()
        {
            if (IsDamaged == false)
            {
                IsDamaged = true;
            }
            else
            {
                IsDamaged = false;
            }
        }

        public override string ToString()
        {
            string status = string.Empty;
            if (IsDamaged == true)
            {
                status = "damaged";
            }
            else
            {
                status = "OK";
            }

            return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {status}";
        }
    }
}
