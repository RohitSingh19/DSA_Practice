using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Recursion
{
    public class Queen
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            if (n == 1) return new List<IList<string>> { new List<string> { "Q" } };

            var result = new List<IList<string>>();
            var board = new List<IList<string>>();
            var queensList = new List<(int i, int j)>();

            for (int i = 0; i < n; i++)
            {
                board.Add(Enumerable.Repeat(".", n).ToList());
            }
            Solve(board, n, 0, queensList, result);
            return result;
        }

        private void Solve(List<IList<string>> board, int n, int row, List<(int i, int j)> queensList, List<IList<string>> result)
        {
            if (queensList.Count == n)
            {
                var current = board.Select(row => string.Join("", row)).ToList();
                result.Add(current);
                return;
            }

            for (int j = 0; j < n; j++)
            {
                if (!IsValidPosition(queensList, row, j)) continue;
                queensList.Add((row, j));
                board[row][j] = "Q";
                Solve(board, n, row + 1, queensList, result);
                queensList.RemoveAt(queensList.Count - 1);
                board[row][j] = ".";
            }
        }

        private bool IsValidPosition(List<(int i, int j)> queensList, int i, int j)
        {
            foreach (var queen in queensList)
            {
                if (queen.i == i) return false; //checking for rows
                if (queen.j == j) return false; //checing for cols
                if (Math.Abs(queen.i - i) == Math.Abs(queen.j - j)) return false; //checking diagonally
            }
            return true;
        }
    }
}
