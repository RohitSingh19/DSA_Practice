using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.DP
{
    public class UniquePathDP
    {
        public UniquePathDP()
        {
            //int ans = RecusrionMethod(2, 3);
            //Console.WriteLine(ans);

            //int[][] grid = new int[3][];
            //grid[0] = new int[3] { 0, 0, 0 };
            //grid[1] = new int[3] { 0, 1, 0 };
            //grid[2] = new int[3] { 0, 0, 0 };

            int[][] grid = new int[2][];
            grid[0] = new int[2] {0,1};
            grid[1] = new int[2] {0,0};

            int[,] matrix = new int[2,2];
            matrix[0, 0] = 0;
            matrix[0, 1] = 1;
            matrix[1, 0] = 0;
            matrix[1, 0] = 0;

            var ans = Recur(grid, grid.Length - 1, grid[0].Length - 1);
        }


        private int Recur(int[,] obstacleGrid, int i, int j)
        {
            if (i == 0 && j == 0)
                return 1;

            if (i < 0 || j < 0)
                return 0;

            if (i > 0 && j > 0 && obstacleGrid[i,j] == 1)
                return 0;

            int up = Recur(obstacleGrid, i - 1, j);
            int left = Recur(obstacleGrid, i, j - 1);

            return up + left;

        }

        private int Recur(int[][] obstacleGrid, int i, int j)
        {
            if (i == 0 && j == 0)
                return 1;

            if (i < 0 || j < 0)
                return 0;

            if (i >= 0 && j >= 0 && obstacleGrid[i][j] == 1)
                return 0;

            int up = Recur(obstacleGrid, i - 1, j);
            int left = Recur(obstacleGrid, i, j - 1);

            return up + left;

        }

        private int RecusrionMethod(int m, int n)
        {
            if (m == 0 && n == 0)
                return 1;
            if (m < 0 || n < 0)
                return 0;

            int up = RecusrionMethod(m - 1, n);
            int left = RecusrionMethod(m, n - 1);

            return up + left;
        }

    }
}
