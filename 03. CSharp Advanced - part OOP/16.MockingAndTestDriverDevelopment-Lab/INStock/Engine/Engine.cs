using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INStock.Contracts;
using INStock.Engine.Contracts;
using INStock.Models;

namespace INStock.Engine
{
    public class Engine : IEngine
    {
        public void Run()
        {
            IProduct product = new Product("beneve", 350, 2);
            IProduct product1 = new Product("Mercedes", 350, 1);
            Console.WriteLine(product1.CompareTo(product));

        }
    }
}
