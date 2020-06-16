using System;

namespace learnCSharp
{
    public class LinkedList
    {
        public ListNode first { get; }

        /* This is the constructor equivalent to def __init__(self, data) */
        public LinkedList(int data)
        {
            first = new ListNode(data, null);
        }

        public bool append(int data)
        {
            ListNode finalNode;

            finalNode = this.getLast();
            /* Set the pointer of the last list item to the new node */
            finalNode.next = new ListNode(data, finalNode);

            return true;
        }

        private ListNode getLast()
        {
            ListNode n;
            /* How do we return the final node? 
             * If you want to test in your program remember to make it public
             */

            /* 
             * Walk along the list, until the pointer next is null
             */
            n = this.first;

            while (n.next != null)
                n = n.next;
            return n;
        }

        public ListNode findItem(int data)
        {
            /* Return null if you can't find the item */

            var node = this.first;

            while (node.data != data)
            {
                if (node.next == null)
                {
                    return null;
                }
                node = node.next;
            }

            return node;
        }

        /// <summary>
        /// Errors if the data doesn't exist in the list.
        /// </summary>
        /// <param name="data">Value of item to delete</param>
        /// <throws>NullReferenceException</throws>
        public void deleteItem(int data)
        {
            ListNode n;

            n = this.findItem(data);

            if (n == null)
                throw new NullReferenceException();

            n.previous.next = n.next;
            n.next.previous = n.previous;

            /* n is now orphaned */
        }

        public void printAll()
        {
            /* do something */

            /* 
            tmp = l.first;
            Console.Out.WriteLine(tmp.data);
            while ((tmp = tmp.next) != null)
                Console.Out.WriteLine(tmp.data);
            */

        }

    }
}