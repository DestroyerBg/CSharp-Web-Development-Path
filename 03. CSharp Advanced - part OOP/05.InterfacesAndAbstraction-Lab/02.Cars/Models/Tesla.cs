using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Models
{
    public class Tesla : ICar, IElectricCar
    {
        public Tesla(string name, string color, int battery)
        {
            Name = name;
            Color = color;
            Battery = battery;
        }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Battery { get; set; }
        public string Start() => "Engine start";
        public string Stop() => $"Breaaak!";

        public override string ToString()
        {
            return $"{Color} Tesla {Name} with {Battery} Batteries{Environment.NewLine}" +
                   $"{Start()}{Environment.NewLine}" +
                   $"{Stop()}";
        }
    }
}
