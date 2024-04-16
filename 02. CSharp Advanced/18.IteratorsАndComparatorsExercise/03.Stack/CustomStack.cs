using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CustomStack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private T[] items;
        private const int initialCapacity = 2;
        private int count;
        public CustomStack()
        {
            this.count = 0;
            items = new T[initialCapacity];
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Push(T item)
        {
            if (count == items.Length)
            {
                Resize();
            }
            items[count] = item;
            count++;
        }

        public T Pop()
        {
            if (count == 0)
            {
                Console.WriteLine($"No elements");
                return default;
            }
            T itemToBePopped = items[count-1];
            items[count-1] = default;
            count--;
            if (count <= items.Length / 4)
            {
                ShrinkArray();
            }
            return itemToBePopped;
        }

        public T Peek()
        {
            if (items.Length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            T itemToBePeeked = items[count-1];
            return itemToBePeeked;
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < count; i++)
            {
                action(items[i]);
            }
        }
        private void ShrinkArray()
        {
            var copy = new T[items.Length / 2];
            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }
        private void Resize()
        {
            var copy = new T[items.Length * 2];
            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count-1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
