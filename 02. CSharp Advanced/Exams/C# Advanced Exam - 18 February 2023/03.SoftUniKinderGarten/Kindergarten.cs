using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get; set; }

        public bool AddChild(Child child)
        {
            if (Registry.Count < Capacity)
            {
                Registry.Add(child);
                return true;
            }

            return false;
        }

        public bool RemoveChild(string childFullName)
        {
            string[] data = childFullName.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string firstName = data[0];
            string lastName = data[1];
            var removeChild = Registry.Find(c => c.FirstName == firstName && c.LastName == lastName);
            return Registry.Remove(removeChild);
        }
        public int ChildrenCount => Registry.Count;

        public Child GetChild(string childFullName)
        {
            string[] data = childFullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string firstName = data[0];
            string lastName = data[1];
            var returnChild = Registry.Find(c => c.FirstName == firstName && c.LastName == lastName);
            return returnChild;
        }

        public string RegistryReport()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Registered children in {Name}:");
            foreach (var child in Registry.OrderByDescending(c=>c.Age).ThenBy(c=>c.LastName).ThenBy(c=>c.FirstName))
            {
                result.AppendLine(child.ToString());
            }
            return result.ToString().TrimEnd();
        }

    }
}
