using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        private class ListNode
        {
            public int Value { get; set; }
            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }

            public ListNode(int value)
            {
                Value = value;
            }

        }
        private ListNode Head { get; set; }
        private ListNode Tail { get; set; }
        public int Count { get; private set; }

        public void AddFirst(int element)
        {
            if (Count == 0)
            {
                Tail = Head = new ListNode(element) ;
            }
            else
            {
                var newHead = new ListNode(element);
                newHead.NextNode = Head;
                Head.PreviousNode = newHead;
                Head = newHead;
            }

            Count++;
        }

        public void AddLast(int element)
        {
            if (Count == 0)
            {
                Tail = Head = new ListNode(element);
            }
            else
            {
                var newTail = new ListNode(element);
                newTail.PreviousNode = Tail;
                Tail.NextNode = newTail;
                Tail = newTail;
            }
            Count++;
        }

        public int RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            var firstElement = Head.Value;
            Head = Head.NextNode;
            if (Head != null)
            {
                Head.PreviousNode = null;
            }
            else
            {
                Tail = null;
            }

            Count--;
            return firstElement;
        }

        public int RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            var lastElement = Tail.Value;
            Tail = Tail.PreviousNode;
            if (Tail != null)
            {
                Tail.NextNode = null;
            }
            else
            {
                Head = null;
            }

            Count--;
            return lastElement;
        }

        public void ForEach(Action<int> action)
        {
            var currNode = Head;
            while (currNode!=null)
            {
                action(currNode.Value);
                currNode = currNode.NextNode;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];
            int counter = 0;
            var currNode = Head;
            while (currNode != null)
            {
                array[counter++] = currNode.Value;
                currNode = currNode.NextNode;
            }
            return array;
        }
    }
}
