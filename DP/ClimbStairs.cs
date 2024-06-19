using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.DP
{
    public class ClimbStairs
    {

        public void RecusriveSolution()
        {
            int[] arr = new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 }; //{ 10,15,20};
            int n = arr.Length;
            int jump1  = Climb(arr, n-1);
            int jump2 = Climb(arr, n-2);
            Console.WriteLine(Math.Min(jump1, jump2));
        }

        private int Climb(int[] arr, int i)
        {
            if (i < 0) return 0;
            
            if(i==0 || i == 1)
                return arr[i];

            int pick = arr[i] + Climb(arr, i-1);
            int notPick = arr[i] + Climb(arr, i-2);

            return Math.Min(pick, notPick);
        }
    }
}
