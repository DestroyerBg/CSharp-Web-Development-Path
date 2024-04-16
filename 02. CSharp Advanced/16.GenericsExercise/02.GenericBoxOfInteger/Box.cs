using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.GenericBoxOfInteger
{
    public class Box<T>
    {
        private List<T> items;

        public Box()
        {
            items = new List<T>();
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (T item in items)
            {
                result.AppendLine($"{typeof(T)}: {item}");
            }
            return result.ToString().TrimEnd();
        }
    }
}
