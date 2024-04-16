using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
    {
        private int index;
        private List<T> items;

        public ListyIterator(T[] data)
        {
            items = data.ToList();
        }
        public bool Move()
        {
            if (index < items.Count-1)
            {
                index++;
                return true;
            }
            return false;
        }

        public T Print()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            return items[index];
        }

        public bool HasNext()
        {
            if (index < items.Count-1)
            {
                return true;
            }
            return false;
        }
    }
}
