using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Heap
{

    public class NumPair
    {
        public int n1;
        public int n2;
        public NumPair(int n1, int n2)
        {
            this.n1 = n1;
            this.n2 = n2;
        }
    }
    public class MaxScore
    {
        public void maxScore()
        {
            int[] nums1 = new int[] { 2, 1, 14, 12 };
            int[] nums2 = new int[] { 11, 7, 13, 6 };
            int k = 3;
            int n = nums1.Length;

            NumPair[] pairs = new NumPair[n];   
            for(int i = 0; i < n; i++) {
                pairs[i] = new NumPair(nums1[i], nums2[i]);
            }

            Array.Sort(pairs, (a, b) => { 
                return b.n2 - a.n2;
            });

            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            long res = 0, sum = 0;

            for (int i = 0; i < n; i++)
            {
                pq.Enqueue(pairs[i].n1, pairs[i].n1);
                sum += pairs[i].n1;

                if (pq.Count > k) sum -= pq.Dequeue();
                if (pq.Count == k) res = Math.Max(res, sum * pairs[i].n2);
            }


        }
    }
}
