using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14._Create_Custom_Data_Structures
{
    public class CustomList : IEnumerable<int>
    {
        private int[] items;
        private const int Capacity = 2;
        public CustomList()
        {
            items = new int[Capacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index>=Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return items[index];
            }
            set
            {
                if (index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                items[index] = value;
            }
        }

        public void Add(int element)
        {
            if (Count == items.Length)
            {
                Resize();
            }
            items[Count] = element;
            Count++;
        }

        public int RemoveAt(int index)
        {
            if (index<0 || index>=Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            int itemToReturn = items[index];
            items[index] = 0;
            ShiftElementsToLeft(index);
            Count--;
            if (Count <= items.Length/4)
            {
                ShrinkArray();
            }
            return itemToReturn;
        }


        public void Insert(int index, int element)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Count == items.Length)
            {
                Resize();
            }
            ShiftElementsToRight(index);
            if (index == Count)
            {
                if (Count == items.Length)
                {
                    Resize();
                }
            }
            items[index] = element;
            Count++;
        }

        public bool Constains(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == element)
                {
                    return true;
                }
            }
            return false;
        }

        public void Reverse()
        {
            int[] reversed = new int[Count];
            int index = 0;
            for (int i = Count-1; i >= 0; i--)
            {
                reversed[index++] = items[i];
            }
            items  = reversed;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex> Count 
                               || secondIndex < 0 || secondIndex > Count)
            {
                throw new IndexOutOfRangeException();
            }
            int temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }
        private void ShiftElementsToRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                items[i] = items[i-1];
            }
        }

        private void ShrinkArray()
        {
            int[] copy = new int[items.Length/2];
            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }

        private void ShiftElementsToLeft(int index)
        {
            for (int i = index; i < Count-1; i++)
            {
                items[i] = items[i+1];
            }
        }


        private void Resize()
        {
            int[] copy = new int[items.Length*2];
            for (int i = 0; i < items.Length; i++)
            {
                copy[i]= items[i];
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
