using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles.Models.Interfaces
{
    public interface IDrivable
    {
        public double FuelQuantity { get;}
        public double FuelConsumption { get;}
        public double TankCapacity { get;}
        public string Drive(double distance);
        public void Refuel(double liters);

    }
}
