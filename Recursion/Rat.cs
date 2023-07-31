using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Recursion
{
    public class Rat
    {
        public void RatInAMazeMainFunc()
        {
            int n = 4;
            int[,] a = { { 1, 0, 0, 0 }, { 1, 1, 0, 1 }, { 1, 1, 0, 0 }, { 0, 1, 1, 1 } };
            var res = findPath(a, n);
        }

        private List<string> findPath(int[,] a, int n)
        {
            int[,] visited = new int[n,n];

            //for (int i = 0; i < n; i++) {
            //    for (int j = 0; j < n; j++) {
            //        visited[i, j] = 0;
            //    }
            //}

            var result = new List<string>();
            if (a[0, 0] == 1)
                Solve(result, visited, a, n, 0, 0, "");

            return result;
        }

        private void Solve(List<string> result, int[,] visited, int[,] a, int n, int i, int j, string track)
        {
            if (i == n - 1 && j == n - 1) {
                result.Add(track);
                return;
            }

            //Down
            if (i + 1 < n && visited[i + 1, j] == 0 && a[i + 1, j] == 1)
            {
                visited[i, j] = 1;
                Solve(result, visited, a, n, i + 1, j, track + "D");
                visited[i, j] = 0; //backtrack or marking un visited
            }

            //Left

            if (j - 1 >= 0 && visited[i, j - 1] == 0 && a[i, j - 1] == 1)
            {
                visited[i, j] = 1;
                Solve(result, visited, a, n, i, j-1, track + "L");
                visited[i, j] = 0; //backtrack or marking un visited
            }

            //Right

            if (j + 1 < n && visited[i, j + 1] == 0 && a[i, j + 1] == 1) 
            {
                visited[i, j] = 1;
                Solve(result, visited, a, n, i, j + 1, track + "R");
                visited[i, j] = 0; //backtrack or marking un visited
            }

            //Up

            if (i - 1 >= 0 && visited[i-1, j] == 0 && a[i-1,j] == 1)
            {
                visited[i, j] = 1;
                Solve(result, visited, a, n, i-1, j, track + "U");
                visited[i, j] = 0; //backtrack or marking un visited
            }
        }
    }

   
}
