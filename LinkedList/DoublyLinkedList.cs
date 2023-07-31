using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.LinkedList
{
    // C# program to find a
    // pair with given sum x.
    using System;

    public class DoublyLinkedList
    {

        // structure of node of
        // doubly linked list
        public class Node
        {
            public int data;
            public Node next, prev;
        };

        // Function to find pair whose
        // sum equal to given value x.
        public void pairSum(Node head, int x)
        {
            // Set two pointers, first
            // to the beginning of DLL
            // and second to the end of DLL.
            Node first = head;
            Node second = head;
            while (second.next != null)
                second = second.next;

            // To track if we find a pair or not
            bool found = false;

            // The loop terminates when
            // they cross each other (second.next
            // == first), or they become same
            // (first == second)
            while (first != second && second.next != first)
            {
                // pair found
                if ((first.data + second.data) == x)
                {
                    found = true;
                    Console.WriteLine("(" + first.data +
                                        ", " + second.data + ")");

                    // move first in forward direction
                    first = first.next;

                    // move second in backward direction
                    second = second.prev;
                }
                else
                {
                    if ((first.data + second.data) < x)
                        first = first.next;
                    else
                        second = second.prev;
                }
            }

            // if pair is not present
            if (found == false)
                Console.WriteLine("No pair found");
        }

        // A utility function to insert
        // a new node at the beginning
        // of doubly linked list
        public Node insert(Node head, int data)
        {
            Node temp = new Node();
            temp.data = data;
            temp.next = temp.prev = null;
            if (head == null)
                (head) = temp;
            else
            {
                temp.next = head;
                (head).prev = temp;
                (head) = temp;
            }
            return temp;
        }

        // Driver Code
        public void MainDoubly()
        {
            Node head = null;
            head = insert(head, 7);
            head = insert(head, 6);
            head = insert(head, 5);
            head = insert(head, 4);
            head = insert(head, 3);
            head = insert(head, 2);
            head = insert(head, 1);
            int x = 2;
            Rotate(head, x);
            //SumInPair(head, x);
        }

        public Node Rotate(Node head, int k)
        {
            int i = 1;
            Node start = head;
            while (i < k)
            {
                start = start.next;
                i++;
            }

            Node Right = start.next;
            start.next = null;
            Node left = Right.prev;
            Right.prev = null;

            return null;
        }

        public void SumInPair(Node start,Node end, int x)
        {

            //Node start = head;
            //Node end = head;

            //while (end.next != null) { 
            //    end = end.next;
            //}


            //while (start != end && end.next != start)
            //{
            //    if (start.data + end.data == x)
            //    {
            //        Console.WriteLine(start.data +" & "+end.data);
            //        start = start.next;
            //        end = end.prev;

            //    }
            //    else if ((start.data + end.data) > x)
            //    {
            //        end = end.prev;
            //    }
            //    else
            //    {
            //        start = start.next;
            //    }
            //}
            
        }

        public void countTriplet(Node node, int sum)
        {
            int count = 0;
            
        }
    }

    

}
