using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.DP
{
    public class CoinChange
    {

        public CoinChange()
        {
            int[] arr = new int[] { 1, 2, 5 };
            int amt = 5;
            var ans = TabulationSolution(arr, amt);
        }


        private int TabulationSolution(int[] arr, int amount)
        {
            int n = arr.Length;
            int[][] dp = new int[n][];
            /*Created and intialize dp array*/
            for (int i = 0; i < dp.Length; i++) dp[i] = new int[amount + 1];

            /*covering the base case of all possible amounts for index 0*/
            for (int amt = 0; amt <= amount; amt++)
                dp[0][amt] = (amt % arr[0] == 0) ? 1 : 0;

            for (int idx = 1; idx < n; idx++)
            {
                for (int amt = 0; amt <= amount; amt++)
                {

                    int notTake = dp[idx - 1][amt];
                    int take = 0;
                    if (amt >= arr[idx])
                        take = dp[idx][amt - arr[idx]];

                    dp[idx][amt] = notTake + take;
                }

            }
            return dp[n - 1][amount];
        }



        public int CoinChangeProblem(int[] coins, int amount)
        {
            int[][] dp = new int[coins.Length][];

            for (int i = 0; i < coins.Length; i++)
            {
                dp[i] = new int[amount + 1]; // Initialize inner array with size (amount + 1)
            }
            //base case
            for (int amt = 0; amt <= amount; amt++)
            {
                if (amt % coins[0] == 0)
                    dp[0][amt] = amt / coins[0];
                else
                    dp[0][amt] = (int)Math.Pow(10, 9);

            }


            for (int idx = 1; idx < coins.Length; idx++)
            {
                for (int t = 1; t <= amount; t++)
                {
                    int notTake = 0 + dp[idx - 1][t];
                    int take = (int)Math.Pow(10, 9);

                    if (coins[idx] <= t)
                        take = 1 + dp[idx][t - coins[idx]]; ;

                    dp[idx][t] = Math.Min(take, notTake);
                }
            }


            int ans = dp[coins.Length - 1][amount];

            if (ans >= (int)Math.Pow(10, 9)) return -1;

            return ans;
        }


        public int Change(int amount, int[] coins)
        {
            int n = coins.Length - 1;
            int[,] dp = new int[n, amount + 1];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < amount; j++)
                {
                    dp[i, j] = -1;
                }
            }

            return Recur(coins, amount, n, dp);
        }

        private int Recur(int[] arr, int amt, int idx, int[,] dp)
        {
            if (idx == 0)
                return (amt % arr[idx] == 0) ? 1 : 0;

            if (dp[idx, amt] != -1)
                return dp[idx, amt];

            int notTake = Recur(arr, amt, idx - 1, dp);
            int take = 0;
            if (amt >= arr[idx])
                take = Recur(arr, amt - arr[idx], idx, dp);

            return dp[idx, amt] = notTake + take;
        }
    }
}
