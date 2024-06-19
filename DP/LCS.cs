using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.DP
{
    public class LCS_DP
    {
        private void InitializeDP(int n2, int[][] dp)
        {
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[n2 + 1];
            }
        }

        public int Tabulation()
        {
            string text1 = "abcde";
            string text2 = "ace";
            int n1 = text1.Length;
            int n2 = text2.Length;
            int[][] dp = new int[n1 + 1][];
            InitializeDP(n2 + 1, dp);

            /*These 2 for loops basically covers the base cases of if(i==0 || j==0) return 0*/

            for (int j = 0; j <= n2; j++)
                dp[0][j] = 0;

            for (int i = 0; i <= n1; i++)
                dp[i][0] = 0;

            for (int i = 1; i <= n1; i++)
            {
                for (int j = 1; j <= n2; j++)
                {
                    if (text1[i - 1] == text2[j - 1])
                    {
                        dp[i][j] = 1 + dp[i - 1][j - 1];
                    }
                    else
                    {
                        dp[i][j] = Math.Max(dp[i - 1][j], dp[i][j - 1]);
                    }
                }
            }


            return dp[n1][n2];
        }

        public int LongestCommonSubsequence(string text1, string text2)
        {
            return LCS(text1, text2, text1.Length - 1, text2.Length - 1);
        }

        private int LCS(string s1, string s2, int i, int j)
        {
            if (i < 0 || j < 0)
                return 0;

            if (s1[i] == s2[j])
                return 1 + LCS(s1, s2, i - 1, j - 1);

            return Math.Max(LCS(s1, s2, i - 1, j), LCS(s1, s2, i, j - 1));
        }
    }
}
