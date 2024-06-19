using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Recursion
{
    public class Subset
    {
      
        public IList<IList<int>> Subsets(int[] nums)
        {
            List<List<int>> result = new List<List<int>>();
            solve(nums, 0, new List<int>(), result);
            return result.ToArray();
        }

        public void solve(int[] nums, int i, List<int> list, List<List<int>> result)
        {
            if (nums.Length == i)
            {
                result.Add(new List<int>(list));
                return;
            }

            list.Add(nums[i]);
            solve(nums, i + 1, list, result); //pick
            list.RemoveAt(list.Count - 1); //backtracking
            solve(nums, i + 1, list, result); //not pick
        }

        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            var ans = new List<List<int>>();
            var ds = new List<int>();
            Array.Sort(nums);
            recur(nums ,0, ans, ds, false);
            return ans.ToArray();
        }

        private void recur(int[] nums, int idx, List<List<int>> result, List<int> list, bool alreadyPicked)
        {
            /*base case*/
            if (idx == nums.Length)
            {
                result.Add(new List<int>(list));
                return;
            }

            recur(nums, idx + 1, result, list, false);
            /*the logic that will check that whether the element has already been picked or not*/
            if (idx > 0 && nums[idx] == nums[idx - 1] && !alreadyPicked) return;

            list.Add(nums[idx]);
            recur(nums, idx + 1, result, list, true);
            list.RemoveAt(list.Count - 1);

        }
    }
}
