using System;
public class KthSmallest
{

    public class MinHeap
    {
        int[] harr; 
        int heap_size; 

        int parent(int i) { return (i - 1) / 2; }
        int left(int i) { return ((2 * i) + 1); }
        int right(int i) { return ((2 * i) + 2); }
        public int getMin()
        {
            return harr[0];
        } 

        public void replaceMax(int x)
        {
            this.harr[0] = x;
            minHeapify(0);
        }

        public MinHeap(int[] a, int size)
        {
            heap_size = size;
            harr = a; // store address of array
            int i = (heap_size - 1) / 2;
            while (i >= 0)
            {
                minHeapify(i);
                i--;
            }
        }

        public int extractMin()
        {
            if (heap_size == 0)
                return Int32.MaxValue;

            // Store the maximum value.
            int root = harr[0];

            // If there are more than 1 items, move the last
            // item to root and call heapify.
            if (heap_size > 1)
            {
                harr[0] = harr[heap_size - 1];
                minHeapify(0);
            }
            heap_size--;
            return root;
        }

        public void minHeapify(int i)
        {
            int l = left(i);
            int r = right(i);
            int smallest = i;
            if (l < heap_size && harr[l] < harr[i])
                smallest = l;
            if (r < heap_size && harr[r] < harr[smallest])
                smallest = r;
            if (smallest != i)
            {
                int t = harr[i];
                harr[i] = harr[smallest];
                harr[smallest] = t;
                minHeapify(smallest);
            }
        }


    };

    // Function to return k'th largest element in a given
    // array
    int kthSmallest(int[] arr, int N, int K)
    {

        // Build a heap of first k elements: O(k) time
        MinHeap mh = new MinHeap(arr, N);

        // Process remaining n-k elements. If current
        // element is smaller than root, replace root with
        // current element
        for (int i = 0; i < K - 1; i++)
            mh.extractMin();

        // Return root
        return mh.getMin();
    }

    // Driver's code
    public void KthSmallestMain()
    {
        int[] arr = { 12, 3, 5, 7, 19 };
        int N = arr.Length, K = 2;
        KthSmallest kth = new KthSmallest();

        // Function call
        Console.Write("K'th smallest element is "
                    + kth.kthSmallest(arr, N, K));
    }
}


