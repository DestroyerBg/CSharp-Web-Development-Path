using P03.Detail_Printer;
using System;

namespace P03.DetailPrinter
{
    public class Employee : BaseEmployee
    {
        public Employee(string name) : base(name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
        public override void PrintDetails()
        {
            Console.WriteLine(Name);
        }
    }
}
