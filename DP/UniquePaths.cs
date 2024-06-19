using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.DP
{
    public class UniquePathsMinSum
    {

        public UniquePathsMinSum()
        {
            int[][] grid = new int[2][];
            grid[0] = new int[3] { 1,2,3};
            grid[1] = new int[3] { 4,5,6};
            
            int ans = MinPathSumSpaceOptimized(grid);
        }

        public int MinPathSum(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            return Recursion(grid, m - 1, n - 1);
        }

        private int Recursion(int[][] grid, int i, int j)
        {
            if (i == 0 && j == 0) return grid[i][j];

            if (i < 0 || j < 0) return int.MaxValue - 1000;

            int up = grid[i][j] + Recursion(grid, i - 1, j);
            int left = grid[i][j] + Recursion(grid, i, j - 1);


            return Math.Min(left, up);
        }

        public int MinPathSumSpaceOptimized(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            int[] prevRow = new int[m];

            for (int i = 0; i < m; i++)
            {
                int[] currRow = new int[n];
                for (int j = 0; j < n; j++)
                {

                    if (i == 0 && j == 0)
                    {
                        currRow[j] = grid[0][0];
                    }
                    else
                    {
                        int up = grid[i][j];

                        if (i > 0) up += prevRow[j];
                        else up += int.MaxValue - 1000;

                        int left = grid[i][j];

                        if (j > 0)
                            left += currRow[j - 1];
                        else
                            left += int.MaxValue - 1000;

                        currRow[j] = Math.Min(up, left);
                    }
                }
                prevRow = currRow;
            }
            return prevRow[m - 1];
        }

        public int MinPathSumTabulation(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            int[,] dp = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[i, j] = grid[i][j];
                    }
                    else
                    {
                        //adding the current value of position form grid
                        int up = grid[i][j];
                        if (i > 0)
                        {
                            //this line is equivalent to the recusrive call, whcih was being performed as recusrive call
                            up += dp[i - 1, j];
                        }
                        else
                        {
                            //this will be one of the base case from recusrion in which the index goes out of boundry
                            up = int.MaxValue - 1000;
                        }

                        int left = grid[i][j];

                        if (j > 0)
                            left += dp[i, j - 1];
                        else
                            left = int.MaxValue - 1000;

                        dp[i, j] = Math.Min(up, left);
                    }
                }
            }
            return dp[m - 1, n - 1];
        }
    }
}
