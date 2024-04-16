using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.RawData
{
    public class Cargo
    {
        public Cargo(string cargoType, int weight)
        {
            CargoType = cargoType;
            Weight = weight;
        }
        public string CargoType { get; set; }
        public int Weight { get; set; }
    }
}
