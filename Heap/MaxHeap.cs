using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Heap
{
    public class MaxHeap
    {
        private int[] arr;

        private int heapSize;

        private int maxHeapSize;
        public MaxHeap(int maxSize)
        {
            this.maxHeapSize = maxSize;
            arr = new int[maxHeapSize];
            heapSize = 0;
        }


        public int GetParent(int index)
        {
            return (index - 1) / 2;
        }

        public int GetLeftChild(int index)
        {
            return (2 * index + 1);
        }

        public int GetRightChild(int index)
        {
            return (2 * index + 2);
        }

        public int GetHeapCurrentSize()
        {
            return heapSize;
        }

        public int GetMax()
        {
            return arr[0];
        }
        public void Insert(int value)
        {
            if (heapSize > maxHeapSize)
            {
                Console.WriteLine("Overflow");
                return;
            }

            heapSize++;
            int i = heapSize - 1;
            arr[i] = value;

            while (i != 0 && arr[GetParent(i)] < arr[i])
            {
                int temp = arr[i];
                arr[i] = arr[GetParent(i)];
                arr[GetParent(i)] = temp;
                i = GetParent(i);
            }
        }

        public void Remove(int index)
        {
            IncreaseKey(index, int.MaxValue);
            RemoveMax();
        }

        private int RemoveMax()
        {
            if (heapSize <= 0) { return int.MinValue; }
            if (heapSize == 1)
            {
                heapSize--;
                return arr[0];
            }

            int root = arr[0];
            arr[0] = arr[heapSize - 1];
            heapSize--;
            MaxHeapify(0);
            return root;
        }

        private void MaxHeapify(int i)
        {
            int l = GetLeftChild(i);
            int r = GetRightChild(i);
            
            int largest = i;

            /*if the left child is greater than root*/
            if(l < heapSize && arr[l] > arr[i])
            {
                largest = l;
            }
            /*if the right child is greater than root*/
            if (r < heapSize && arr[r] > arr[largest])
            {
                largest = r;
            }
            /*if largest is not same as i means it has changed it so swap it with largest and do heapify again*/
            if(largest!=i)
            {
                int temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;
                MaxHeapify(largest);
            }
        }

        private void IncreaseKey(int index, int maxValue)
        {
            arr[index] = maxValue;
            while (index != 0 && arr[GetParent(index)] < arr[index])
            {
                int temp = arr[index];
                arr[index] = arr[GetParent(index)];
                arr[GetParent(index)] = temp;
                index = GetParent(index);
            }
        }

        public void MaxHeapRunner()
        {
            MaxHeap maxHeap = new MaxHeap(10);
            maxHeap.Insert(3);
            maxHeap.Insert(10);
            maxHeap.Insert(12);
            maxHeap.Insert(8);
            maxHeap.Insert(2);
            maxHeap.Insert(14);

            Console.WriteLine($"Heap size is.. {maxHeap.GetHeapCurrentSize()}");

            maxHeap.Remove(2);

            maxHeap.Insert(15);
            maxHeap.Insert(5);

            int j = maxHeap.GetMax();
            Console.Write(j);
        }
    }
}
