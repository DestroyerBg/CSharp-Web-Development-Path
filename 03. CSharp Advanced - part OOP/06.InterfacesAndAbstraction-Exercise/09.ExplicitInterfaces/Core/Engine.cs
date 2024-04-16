using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08.CollectionHierarchy.IO;
using _08.CollectionHierarchy.IO.Interfaces;
using _09.ExplicitInterfaces.Models;
using _09.ExplicitInterfaces.Models.Interfaces;

namespace _08.CollectionHierarchy.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine()
        {
            reader = new Reader();
            writer = new Writer();
        }
        public void Run()
        {
            string input = string.Empty;
            while ((input = reader.ReadLine()) != "End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                string country = data[1];
                int age = int.Parse(data[2]);
                var citizen = new Citizen(name, age, country);
                IResident resident = new Citizen(name, age, country);
                IPerson person = new Citizen(name, age, country);
                writer.WriteLine(person.GetName());
                writer.WriteLine(resident.GetName());
            }
        }

    }
}
