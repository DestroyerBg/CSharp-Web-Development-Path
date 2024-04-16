using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Models
{
    public class Seat : ICar
    {
        public Seat(string name, string color)
        {
            Name = name;
            Color = color;
        }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Start() => $"Engine start";


        public string Stop() => $"Breaaak!";
        

        public override string ToString()
        { return $"{Color} Seat {Name}{Environment.NewLine}" +
                 $"{Start()}{Environment.NewLine}"+
                 $"{Stop()}";
        }
    }
}
