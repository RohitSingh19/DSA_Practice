using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.DP
{
    public class Stocks
    {
        public Stocks() 
        {
            int[] arr = new int[] { 7, 1, 5, 3, 6, 4 };
            int ans = BuySellAndStockTwo(arr);
        }

        public int BuySellAndStockTwo(int[] arr)
        {
            return Recur(arr, arr.Length, 0, true);
        }
        private int Recur(int[] prices, int n, int i, bool canBuy)
        {
            if (n == i) return 0;

            int profit = 0;

            if (canBuy)
            {
                profit = Math.Max(-prices[i] + Recur(prices, n, i + 1, false),  //canBuy Or Take
                                  0 + Recur(prices, n, i + 1, true)); //canNotBuy Or NotTake
            }
            else
            {
                profit = Math.Max(prices[i] + Recur(prices, n, i + 1, true),
                                  0 + Recur(prices, n, i + 1, false));
            }

            return profit;
        }
    }
}
