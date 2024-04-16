using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.Vehicles.IO.Interfaces;

namespace _01.Vehicles.IO
{
    public class Writer : IWriter
    {
        private string outputfilePath = @"../../../output.txt";

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
