using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.LinkedList
{
    // C# program for Quick Sort on
    // Singly Linked List
    using System;

    /*Sort a linked list using quick sort*/
    class QuickSort
    {
        public class Node
        {
            public int data;
            public Node next;

            public Node(int d)
            {
                this.data = d;
                this.next = null;
            }
        }

        Node head;

        void addNode(int data)
        {
            if (head == null)
            {
                head = new Node(data);
                return;
            }

            Node curr = head;
            while (curr.next != null)
                curr = curr.next;

            Node newNode = new Node(data);
            curr.next = newNode;
        }

        void printList(Node n)
        {
            while (n != null)
            {
                Console.Write(n.data);
                Console.Write(" ");
                n = n.next;
            }
        }

        // takes first and last node,
        // but do not break any links in
        // the whole linked list
        Node partitionLast(Node start, Node end)
        {
            if (start == end || start == null || end == null)
                return start;

            Node pivot_prev = start;
            Node curr = start;
            int pivot = end.data;

            // iterate till one before the end,
            // no need to iterate till the end
            // because end is pivot
            int temp;
            while (start != end)
            {

                if (start.data < pivot)
                {
                    // keep tracks of last modified item
                    pivot_prev = curr;
                    temp = curr.data;
                    curr.data = start.data;
                    start.data = temp;
                    curr = curr.next;
                }
                start = start.next;
            }

            // swap the position of curr i.e.
            // next suitable index and pivot
            temp = curr.data;
            curr.data = pivot;
            end.data = temp;

            // return one previous to current
            // because current is now pointing to pivot
            return pivot_prev;
        }

        void sort(Node start, Node end)
        {
            if (start == end)
                return;

            // split list and partition recurse
            Node pivot_prev = partitionLast(start, end);
            sort(start, pivot_prev);

            // if pivot is picked and moved to the start,
            // that means start and pivot is same
            // so pick from next of pivot
            if (pivot_prev != null && pivot_prev == start)
                sort(pivot_prev.next, end);

            // if pivot is in between of the list,
            // start from next of pivot,
            // since we have pivot_prev, so we move two nodes
            else if (pivot_prev != null
                    && pivot_prev.next != null)
                sort(pivot_prev.next.next, end);
        }

        // Driver Code
        public void MainLLQuick()
        {
            QuickSort list = new QuickSort();
            list.addNode(30);
            list.addNode(3);
            list.addNode(4);
            list.addNode(20);
            list.addNode(5);

            Node N = list.head;
            while (N.next != null)
                N = N.next;

            Console.WriteLine("Linked List before sorting");
            list.printList(list.head);

            // Function call
            list.sort(list.head, N);

            Console.WriteLine("\nLinked List after sorting");
            list.printList(list.head);
        }
    }

    // This code is contributed by 29AjayKumar

}
