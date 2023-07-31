using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Recursion
{
    public class NonDecreasingSeq
    {

        List<string> hash = new List<string>();

        public IList<IList<int>> FindSubsequences(int[] nums)
        {
            List<List<int>> result = new List<List<int>>();
            solve(nums, 0, new List<int>(), result);
            return result.ToArray();
        }

        public void solve(int[] nums, int i, List<int> list, List<List<int>> result)
        {
            if (i == nums.Length)
            {

                if (list.Count > 1 && !hash.Contains(string.Join(",", list)))
                {
                    result.Add(new List<int>(list));
                    hash.Add(string.Join(",", list));
                }
                return;
            }

            //pick
            solve(nums, i + 1, list, result);

            //not pick
            int currEle = nums[i];
            int lastEle = list.Count > 0 ? list.ElementAt(list.Count - 1) : int.MinValue;
            if (currEle >= lastEle)
                list.Add(currEle);

            solve(nums, i + 1, list, result);

            if (list.Count > 0)
                list.RemoveAt(list.Count() - 1);
        }
    }
}
