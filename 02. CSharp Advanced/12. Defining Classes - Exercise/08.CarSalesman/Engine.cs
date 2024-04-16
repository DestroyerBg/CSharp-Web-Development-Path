using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CarSalesman
{
    public class Engine
    {
        public Engine()
        {
            Displacement = default;
            Efficency = default;
        }

        public Engine(string model, int power) : this()
        {
            Model = model;
            Power = power;
        }

        public Engine(string model, int power, int displacement) : this()
        {
            Model = model;
            Power = power;
            Displacement = displacement;
        }
        public Engine(string model, int power, string efficency) :this()
        {
            Model = model;
            Power = power;
            Efficency = efficency;
        }


        public Engine(string model, int power, int displacement, string efficency)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficency = efficency;
        }
        
        public string Model { get; set; }
        public int Power { get; set; }
        public int  Displacement { get; set; }
        public string Efficency { get; set; }

        
    }
}
