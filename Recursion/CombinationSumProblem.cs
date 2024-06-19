using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Recursion
{
    internal class CombinationSumProblem
    {
        //public IList<IList<int>> CombinationSum(int[] candidates, int target)
        //{
        //    List<List<int>> result = new List<List<int>>();
        //    helper(0, candidates, result, new List<int>(), target, 0);
        //    return result.ToArray();
        //}

        //public void helper(int i, int[] arr, List<List<int>> res, List<int> list, int target, int sum)
        //{
        //    if (sum > target) return;

        //    if (target == sum)
        //    {
        //        res.Add(new List<int>(list));
        //        return;
        //    }

        //    while (i < arr.Length)
        //    {
        //        list.Add(arr[i]);
        //        sum += arr[i];
        //        helper(i, arr, res, list, target, sum);
        //        sum -= arr[i];
        //        list.RemoveAt(list.Count - 1);
        //        i++;
        //    }
        //}


        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            List<List<int>> result = new List<List<int>>();
            Array.Sort(candidates);
            helper(0, candidates, target, result, new List<int>());
            return result.ToArray();
        }

        public void helper(int index, int[] arr, int target, List<List<int>> result, List<int> ds)
        {
            if (target == 0)
            {
                result.Add(new List<int>(ds));
                return;
            }

            for (int i = index; i < arr.Length; i++)
            {
                if (i > index && arr[i] == arr[i - 1]) continue;
                if (arr[i] > target) return;

                ds.Add(arr[i]);
                helper(i + 1, arr, target - arr[i], result, ds);
                ds.RemoveAt(ds.Count - 1);
            }
        }
    }
}
