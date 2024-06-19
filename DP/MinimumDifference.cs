using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.DP
{
    public class MinimumDifference
    {
        public MinimumDifference()
        {
            var arr = new int[] { 2, -1, 0, 4, -2, -9 };
            var ans = MinimumDifferenceDp(arr);
        }
        public int MinimumDifferenceDp(int[] nums)
        {

            /*calculating the total sum, and this will become my target sum*/
            int totalSum = 0;
            int n = nums.Length;
            for (int i = 0; i < n; i++) totalSum += nums[i];

            bool[,] dp = new bool[n, totalSum + 1];

            for (int i = 0; i < n; i++)
            {
                dp[i, 0] = true;
            }

            if (nums[0] <= totalSum)
                dp[0, totalSum] = true;

            for (int i = 1; i < n; i++)
            {
                for (int t = 1; t <= totalSum; t++)
                {
                    bool notTake = dp[i - 1, t];
                    bool take = false;

                    if (nums[i] <= t)
                        take = dp[i - 1, t - nums[i]];

                    dp[i, t] = take || notTake;
                }
            }
            /*  once I have target (totalSum) sum with me, I can check for every possible sum with the subset is by just 
                iterating over the last row of dp array, because the row will only be able to tell me that which will be 
                sum of that particular subset
            */
            int mini = (int)Math.Pow(10, 5);
            for (int r = 0; r <= totalSum; r++)
            {
                if (dp[n - 1, r] == true)
                {
                    int diff = Math.Abs(r - (totalSum - r));
                    mini = Math.Min(mini, diff);
                }
            }

            return 0;

        }
    }
}
