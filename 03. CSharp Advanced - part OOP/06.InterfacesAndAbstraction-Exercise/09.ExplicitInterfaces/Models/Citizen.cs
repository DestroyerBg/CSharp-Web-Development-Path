using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _09.ExplicitInterfaces.Models.Interfaces;

namespace _09.ExplicitInterfaces.Models
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }
        public string Name { get; }
        public int Age { get; }
        public string Country { get; }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs " + $"{Name}";
        }

        string IPerson.GetName()
        {
            return Name;
        }

    }
}
