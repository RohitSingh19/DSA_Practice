﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Heap
{
    public class MinHeap
    {

        // To store array of elements in heap
        public int[] heapArray { get; set; }

        // max size of the heap
        public int capacity { get; set; }

        // Current number of elements in the heap
        public int current_heap_size { get; set; }

        /*Constructor is responsible for creating the heap*/
        public MinHeap(int n)
        {
            capacity = n;
            heapArray = new int[capacity];
            current_heap_size = 0;
        }

        // Swapping using reference 
        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        // Get the Parent index for the given index
        public int Parent(int key)
        {
            return (key - 1) / 2;
        }

        // Get the Left Child index for the given index
        public int Left(int key)
        {
            return 2 * key + 1;
        }

        // Get the Right Child index for the given index
        public int Right(int key)
        {
            return 2 * key + 2;
        }

        // Inserts a new key
        public bool insertKey(int key)
        {
            if (current_heap_size == capacity)
            {

                // heap is full
                return false;
            }

            // First insert the new key at the end 
            int i = current_heap_size;
            heapArray[i] = key;
            current_heap_size++;

            // Fix the min heap property if it is violated 
            int parentEle = Parent(i);
            while (i != 0 && heapArray[i] < heapArray[parentEle])
            {
                Swap(ref heapArray[i], ref heapArray[parentEle]);
                i = parentEle;
            }
            return true;
        }

        // Decreases value of given key to new_val. 
        // It is assumed that new_val is smaller 
        // than heapArray[key]. 
        public void decreaseKey(int key, int new_val)
        {
            heapArray[key] = new_val;

            while (key != 0 && heapArray[key] <
                               heapArray[Parent(key)])
            {
                Swap(ref heapArray[key],
                     ref heapArray[Parent(key)]);
                key = Parent(key);
            }
        }

        // Returns the minimum key (key at
        // root) from min heap 
        public int getMin()
        {
            return heapArray[0];
        }

        // Method to remove minimum element 
        // (or root) from min heap 
        public int extractMin()
        {
            if (current_heap_size <= 0)
            {
                return int.MaxValue;
            }

            if (current_heap_size == 1)
            {
                current_heap_size--;
                return heapArray[0];
            }

            // Store the minimum value, 
            // and remove it from heap 
            int root = heapArray[0];

            heapArray[0] = heapArray[current_heap_size - 1];
            current_heap_size--;
            MinHeapify(0);

            return root;
        }

        // This function deletes key at the 
        // given index. It first reduced value 
        // to minus infinite, then calls extractMin()
        public void deleteKey(int key)
        {
            decreaseKey(key, int.MinValue);
            extractMin();
        }

        // A recursive method to heapify a subtree 
        // with the root at given index 
        // This method assumes that the subtrees
        // are already heapified
        public void MinHeapify(int key)
        {
            int l = Left(key);
            int r = Right(key);

            int smallest = key;
            if (l < current_heap_size &&
                heapArray[l] < heapArray[smallest])
            {
                smallest = l;
            }
            if (r < current_heap_size &&
                heapArray[r] < heapArray[smallest])
            {
                smallest = r;
            }

            if (smallest != key)
            {
                Swap(ref heapArray[key],
                     ref heapArray[smallest]);
                MinHeapify(smallest);
            }
        }

        // Increases value of given key to new_val.
        // It is assumed that new_val is greater 
        // than heapArray[key]. 
        // Heapify from the given key
        public void increaseKey(int key, int new_val)
        {
            heapArray[key] = new_val;
            MinHeapify(key);
        }

        // Changes value on a key
        public void changeValueOnAKey(int key, int new_val)
        {
            if (heapArray[key] == new_val)
            {
                return;
            }
            if (heapArray[key] < new_val)
            {
                increaseKey(key, new_val);
            }
            else
            {
                decreaseKey(key, new_val);
            }
        }
    }
    public class HeapTest
    {
        public void StartHeapTest()
        {
            MinHeap h = new MinHeap(11);

            h.insertKey(3);
            h.insertKey(2);

            h.deleteKey(1);

            h.insertKey(15);
            h.insertKey(5);
            h.insertKey(4);
            h.insertKey(45);

            Console.Write(h.extractMin() + " ");
            Console.Write(h.getMin() + " ");

            h.decreaseKey(2, 1);
            Console.Write(h.getMin());
        }

    }
}
