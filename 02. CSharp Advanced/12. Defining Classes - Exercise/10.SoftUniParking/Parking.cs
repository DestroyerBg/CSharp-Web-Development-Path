using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new List<Car>();
        }

        public int Count
        {
            get
            {
                return cars.Count;
            }

        }
        public string AddCar(Car Car)
        {
            if (cars.Any(r => r.RegistrationNumber == Car.RegistrationNumber))
            {
                return $"Car with that registration number, already exists!";
            }
            if (cars.Count == capacity)
            {
                return $"Parking is full!";
            }
            cars.Add(Car);
            return ($"Successfully added new car {Car.Make} {Car.RegistrationNumber}");
        }

        public string RemoveCar(string RegistationNumber)
        {
            if (!cars.Any(c => c.RegistrationNumber == RegistationNumber))
            {
                return $"Car with that registration number, doesn't exist!";
            }

            Car car = cars.First(r => r.RegistrationNumber == RegistationNumber);
            cars.Remove(car);
            return $"Successfully removed {RegistationNumber}";
        }

        public Car GetCar(string RegistationNumber)
        {
            Car car = cars.First(r => r.RegistrationNumber == RegistationNumber);
            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var registrationNumber in RegistrationNumbers)
            {
                cars.RemoveAll(r => r.RegistrationNumber == registrationNumber);
            }
        }
    }
}
