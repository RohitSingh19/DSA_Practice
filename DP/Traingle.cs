using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.DP
{
    internal class Traingle
    {

        public Traingle()
        {
            List<List<int>> listOfLists = new List<List<int>>(4);

            // Create and add inner lists
            List<int> list1 = new List<int>() { 2 };
            List<int> list2 = new List<int>() { 3, 4 };
            List<int> list3 = new List<int>() { 6, 5, 7 };
            List<int> list4 = new List<int>() { 4, 1, 8, 3 };

            listOfLists.Add(list1);
            listOfLists.Add(list2);
            listOfLists.Add(list3);
            listOfLists.Add(list4);
            
            int n = listOfLists.Count;

            List<int[]> dp = new List<int[]>(n);
            int m = listOfLists[n - 1].Count;

            for (int i = 0; i < listOfLists.Count; i++)
            {
                int [] arr = new int[listOfLists[i].Count];
                dp.Add(arr);
            }

            for (int i = 0; i < m; i++)
            {
                dp[n - 1][i] = (listOfLists[n - 1][i]);
            }


            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = i; j >= 0; j--)
                {
                    int down = listOfLists[i][j] + dp[i + 1][j];
                    int diagonal = listOfLists[i][j] + dp[i + 1][j + 1];

                    dp[i][j] = Math.Min(down, diagonal);
                }
            }

            
        }


        private void createDPList(IList<IList<int>> triangle, List<List<int>> dp)
        {
            for (int i = 0; i < triangle.Count; i++)
            {
                List<int> innerList = new List<int>();
                dp.Add(innerList);
            }
        }
        public int MinimumTotal(IList<List<int>> triangle)
        {
            return Recur(triangle, 0, 0);
        }

        private int Recur(IList<List<int>> arr, int i, int j)
        {
            if (i == arr.Count)
                return arr[i][j];

            int down = arr[i][j] + Recur(arr, i + 1, j);
            int diagonal = arr[i][j] + Recur(arr, i + 1, j + 1);

            return Math.Min(down, diagonal);
        }
    }
}
