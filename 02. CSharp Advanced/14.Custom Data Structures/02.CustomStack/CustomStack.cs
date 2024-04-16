using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CustomStack
{
    public class CustomStack : IEnumerable<int>
    {
        private int[] items;
        private const int initialCapacity = 2;
        private int count;
        public CustomStack()
        {
            this.count = 0;
            items = new int[initialCapacity];
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Push(int item)
        {
            if (count == items.Length)
            {
                Resize();
            }
            items[count] = item;
            count++;
        }

        public int Pop()
        {
            if (items.Length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            int numToBePopped = items[count-1];
            items[count-1] = 0;
            count--;
            if (count <= items.Length / 4)
            {
                ShrinkArray();
            }
            return numToBePopped;
        }

        public int Peek()
        {
            if (items.Length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            int numToBePeeked = items[count-1];
            return numToBePeeked;
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
            int[] copy = new int[items.Length / 2];
            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }
        private void Resize()
        {
            int[] copy = new int[items.Length * 2];
            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
