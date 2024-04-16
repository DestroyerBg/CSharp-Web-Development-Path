using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.GenericSwapMethodInteger
{
    public class GenericSwap<T>
    {
        private List<T> items;

        public GenericSwap()
        {
            items = new List<T>();
        }

        public void Add(T item)
        {
            items.Add(item);
        }
        public void Swap(int index1, int index2)
        {
            if (index1 < 0 && index1 < items.Count
                         && index2 < 0 && index2 < items.Count)
            {
                return;
            }
            T temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;
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
