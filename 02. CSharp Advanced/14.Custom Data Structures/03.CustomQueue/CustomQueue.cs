using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CustomQueue
{
    public class CustomQueue : IEnumerable<int>
    {
        private int[] items;
        private const int initialCapacity = 4;
        private const int firstElementIndex = 0;
        private int count;

        public CustomQueue() 
        {
            count = 0;
            items = new int[initialCapacity];
        }

        public int Count => count;

        public void Enqueue(int Element)
        {
            if (count == items.Length)
            {
                Resize();
            }
            items[count] = Element;
            count++;
        }

        public int Dequeue()
        {
            if (count == 0)
            {
                throw new ArgumentException();
            }
            int itemToDeque = items[0];
            items[0] = 0;
            ShiftElementsToLeft(0);
            count--;
            if (count<= items.Length/4)
            {
                ShrinkArray();
            }
            return itemToDeque;
        }
        public int Peek()
        {
            if (count == 0)
            {
                throw new ArgumentException();
            }
            int itemToPeek = items[0];
            return itemToPeek;
        }

        public void Clear()
        {
            if (count == 0)
            {
                throw new ArgumentException();
            }
            items = new int[initialCapacity];
        }
        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < count; i++)
            {
                action(items[i]);
            }
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
        private void ShrinkArray()
        {
            int[] copy = new int[items.Length / 2];
            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }
        private void ShiftElementsToLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
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
