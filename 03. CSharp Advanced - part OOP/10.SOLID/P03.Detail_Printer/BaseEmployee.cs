using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Detail_Printer
{
    public abstract class BaseEmployee
    {
        protected BaseEmployee(string name)
        {
            Name = name;
        }
        public string Name { get;}
        public abstract void PrintDetails();
    }
}
