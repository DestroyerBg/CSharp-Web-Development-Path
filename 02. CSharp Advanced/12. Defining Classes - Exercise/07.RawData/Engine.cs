using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.RawData
{
    public class Engine
    {
        public Engine(int engineSpeed, int power)
        {
            EngineSpeed = engineSpeed;
            Power = power;
        }
        public int EngineSpeed { get; set; }
        public int Power { get; set; }
    }
}
