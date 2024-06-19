using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.DP
{
    public class FrogJump
    {
        public void CalculateMinimumFrogJump()
        {
            int[] jumps = new int[] { 30, 10, 60, 10, 60, 50 };
            int n = jumps.Length;

            
        }

        public int Run(int i, int[] arr)
        { 
            if(i == 0) return 0;
            
            int left = Run(i-1, arr) + Math.Abs(arr[i] - arr[i-1]);
            int Right = int.MaxValue;
            if(i > 1)
                Right = Run(i-2, arr) +Math.Abs(arr[i] - arr[i - 2]);

            return Math.Min(left, Right);
        }

    }
}
