using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.DP
{
    public class SubsetSum
    {
        public static bool helper(int[] arr, int i, int target, int[][] dp)
        {
            if (target == 0) return true;
            if (i == 0) return (arr[0] == target);

            if (dp[i][target] != -1) 
                return dp[i][target] == 0 ? false: true;   

            bool notIncluded = helper(arr, i - 1, target, dp);
            bool included = false;

            if (target >= arr[i])
                included = helper(arr, i - 1, target - arr[i], dp);

            dp[i][target] = (included || notIncluded) ? 1 : 0;

            return (included || notIncluded);
        }

        public void subsetSumToK()
        {
            int[] arr = new int[] { 1, 2, 3, 4 };
            int k = 4;
            int[][] dp = new int[arr.Length][];

            for (int i = 0; i < dp.Length; i++) 
            {
                int [] inner = new int[k+1];
                for(int j = 0; j < inner.Length; j++)
                {
                    inner[j] = -1;
                }
                dp[i] = inner;  
            }
            //var result = helper(arr, arr.Length - 1, k, dp);
            var result = subsetSumToK(arr.Length, k, arr);
        }


        public static bool subsetSumToK(int n, int k, int [] arr)
        {
         
            bool[][] dp = new bool[n][];

            for (int i = 0; i < dp.Length; i++)
            {
                bool[] inner = new bool[k + 1];
                for (int j = 0; j < inner.Length; j++)
                {
                    inner[j] = false;
                }
                dp[i] = inner;
            }

            //base case 1
            for (int i = 0; i < n; i++)
            {
                dp[i][0] = true;
            }

            //base case 2
            if (arr[0] <= k)
                dp[0][arr[0]] = true;

            for (int idx = 1; idx < n; idx++)
            {
                for (int target = 1; target <= k; target++)
                {
                    bool notTake = dp[idx - 1][target];
                    bool take = false;
                    if (target >= arr[idx])
                        take = dp[idx - 1][target - arr[idx]];

                    dp[idx][target] = notTake || take;
                }
            }

            return dp[n - 1][k];
        }
    }
}
