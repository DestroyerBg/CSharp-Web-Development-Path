using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> items;

        public Box()
        {
            items = new Stack<T>();
        }
        public int Count => items.Count;

        public void Add(T element)
        {
            items.Push(element);
        }

        public T Remove()
        {
            return items.Pop();
        }
    }
}
