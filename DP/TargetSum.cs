using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.DP
{
    public class TargetSum
    {

        public TargetSum() 
        {
            int[] arr = new int[] { 1,1,1,1,1};
            int ans = FindTargetSumWays(arr, 3);
        }

        public int FindTargetSumWays(int[] nums, int target)
        {
            int[][] dp = new int[nums.Length][];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[target + 1000];
                Array.Fill(dp[i], -1);
            }
            return Memoization(nums, target, 0, 0, dp);
        }

        private int Memoization(int[] arr, int sum, int S, int idx, int[][] dp)
        {
            if (idx == arr.Length)
            {
                if (S == sum) return 1;
                return 0;
            }

            if (dp[idx][S] != -1)
                return dp[idx][S];

            int positives = Memoization(arr, sum, S + arr[idx], idx + 1, dp);
            int negatives = Memoization(arr, sum, S - arr[idx], idx + 1, dp);
            
            return dp[idx][S] = positives + negatives;
        }
    }
}
