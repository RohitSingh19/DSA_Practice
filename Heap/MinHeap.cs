using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Heap
{
    public class MinHeap
    {
        int[] arr;
        private int maxSize;
        private int heapSize;
        public MinHeap()
        {
            arr = new int[10];
            heapSize = 0;
            maxSize = 10;
        }

        public int GetHeapSize()
        { return heapSize; }

        public void InsertKey(int key)
        {
            if(heapSize == maxSize)
            {
                Console.WriteLine("Heap overflow");
                return;
            }

            
            int i = heapSize;
            arr[i] = key;
            heapSize++;
            while (i != 0 && arr[GetParent(i)] > arr[i]) 
            {
                int temp = arr[i];
                arr[i] = arr[GetParent(i)];
                arr[GetParent(i)] = temp;
                i = GetParent(i);
            }
        }

        private void DecreaseKey(int key, int value) 
        {
            arr[key] = value;
            while (key != 0 && arr[GetParent(key)] > arr[key])
            {
                int temp = arr[key];
                arr[key] = arr[GetParent(key)];
                arr[GetParent(key)] = temp;
                key = GetParent(key);
            }
        }

        private int ExtractMin()
        {
            if (heapSize == 0) return int.MinValue;

            if (heapSize == 1) {
                heapSize--;
                return arr[0];
            }

            int value = arr[0];
            arr[0] = arr[heapSize-1];
            MinHeapify(0);
            return value;
            
        }

        private void MinHeapify(int idx)
        {
            int l = Left(idx);
            int r = Right(idx);
            int smallest = idx;

            if(l < heapSize && arr[l] < arr[smallest])
                smallest = l;
            if(r < heapSize && arr[r] < arr[smallest])
                smallest = r;

            if(smallest!=idx)
            {
                int temp = arr[smallest];
                arr[smallest] = arr[idx];
                arr[idx] = temp;
                MinHeapify(smallest);
            }
        }


        private void Deletekey(int key)
        {
            DecreaseKey(key, int.MinValue);
            ExtractMin();
        }
        public int GetParent(int index)
        { 
            return (index - 1 / 2);
        }

        public void RunMinHeap()
        { 
            MinHeap minHeap = new MinHeap();
            minHeap.InsertKey(3);
            minHeap.InsertKey(2);
            minHeap.Deletekey(1);
            //minHeap.InsertKey(15);
            //minHeap.InsertKey(5);
            //minHeap.InsertKey(4);
            //minHeap.InsertKey(45);

            Console.WriteLine($"Min Element in heap is: {minHeap.ExtractMin()}");
            Console.WriteLine($"Min Element in heap is: {minHeap.GetMin()}");


            minHeap.DecreaseKey(2, 1);
        }

        private int GetMin()
        {
            return arr[0];
        }

        private int Left(int i)
        {
            return (i * 2) + 1;
        }

        private int Right(int i)
        {
            return (i * 2) + 2;
        }
    }
}
