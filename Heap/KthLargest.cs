using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Heap
{
    public class KthLargest
    {


        public int[] TopKFrequent(int[] nums, int k)
        {

            var minHeap = new PriorityQueue<int, int>();

            foreach (var num in nums)
                minHeap.Enqueue(num, num);

            var result = new List<int>();

            var dict = new Dictionary<int, int>();

            while (minHeap.Count > 0)
            {
                int n = minHeap.Dequeue();

                if (!dict.ContainsKey(n))
                {
                    dict[n] = 1;
                }
                else
                {
                    dict[n]++;
                    int val = dict[n];
                    if (val >= k)
                    {
                        result.Add(n);
                        dict.Remove(n);
                    }
                }

            }

            return result.ToArray();
        }

        public void findKthLargestNumber()
        {
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
            var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));

            int[] arr = new int[] { 3, 2, 1, 5, 6, 4 };
            int k = 2;
            for(int i = 0; i < arr.Length; i++)
            {
                minHeap.Enqueue(arr[i], arr[i]);
                maxHeap.Enqueue(arr[i], arr[i]);    
                //if(minHeap.Count > k)
                //{
                //    minHeap.Dequeue();
                //}
            }

            int result = minHeap.Peek();
            Console.WriteLine(result);
        }

        public void test()
        {
            int[] arr = new int[] { 10,3,8,9,4 };
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
            var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));

            for (int i = 0; i < arr.Length; i++)
            {
                maxHeap.Enqueue(i, arr[i]);
            }
            //var pair = minHeap.Dequeue();
        }

    }

    public class Pair
    {
        public int index;
        Pair(int x, int y) 
        {
        
        }
    }
}
