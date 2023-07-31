using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Recursion
{
    public class PallindromePartioning
    {
        public IList<IList<string>> Partition(string s)
        {
            var result = new List<IList<string>>();
            var list = new List<string>();
            solve(result, list, s);
            return result;
        }

        private void solve(List<IList<string>> result, List<string> list, string s)
        {
            //base case
            if (s.Length == 0)
            {
                result.Add(new List<string>(list));
                return;
            }

            for (int i = 0; i < s.Length; i++)
            {
                string current = s.Substring(0, i + 1);
                string rest = s.Substring(i + 1);
                if (isPallindrome(current))
                {
                    list.Add(current);
                    solve(result, list, rest);
                    list.RemoveAt(list.Count - 1);
                }
            }
        }

        private bool isPallindrome(string s)
        {
            int i = 0;
            int j = s.Length - 1;
            while (i <= j)
            {
                if (s[i++] != s[j--]) return false;
            }
            return true;
        }
    }
}
