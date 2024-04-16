using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int index;
        private List<T> items;

        public ListyIterator(T[] data)
        {
            items = data.ToList();
        }
        public bool Move()
        {
            if (index < items.Count - 1)
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
            if (index < items.Count - 1)
            {
                return true;
            }
            return false;
        }

        public void PrintAll()
        {
            GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation");
            }

            for (int i = 0; i < items.Count; i++)
            {
                yield return items[i];
            }
        }


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
