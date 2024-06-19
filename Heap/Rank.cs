using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Heap
{
    internal class Rank
    {
        public int[] ArrayRankTransform(int[] arr)
        {

            var minHeap = new PriorityQueue<Pair, int>();

            for (int idx = 0; idx < arr.Length; idx++)
            {
                minHeap.Enqueue(new Pair(arr[idx], idx), arr[idx]);
            }

            int rank = 1;
            int prev = int.MaxValue;
            while (minHeap.Count > 0)
            {
                Pair pair = minHeap.Dequeue();
                arr[pair.index] = (prev == pair.val) ? rank : rank++;
                prev = pair.val;
            }


            return arr;
        }
        public class Pair
        {
            public int val;
            public int index;

            public Pair(int val, int index)
            {
                this.val = val;
                this.index = index;
            }

        }
    }
}
