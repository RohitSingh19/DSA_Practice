using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.BinarySearch
{
    internal class SearchRotated
    {
        public void Test()
        {
            var arr = new int[] { 1,0,1,1,1,1};
            Search(arr, 0);
        }

        public bool Search(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length - 1;

            while (l <= r)
            {
                int m = l + (r - l) / 2;
                if (nums[m] == target) return true;

                if ((nums[l] == nums[m]) && (nums[r] == nums[m]))
                {
                    l++;
                    r--;
                    
                }

                else if (nums[l] <= nums[m])
                {

                    if (nums[l] <= target && target >= nums[m])
                    {
                        r = m - 1;
                    }
                    else
                    {
                        l = m + 1;
                    }
                }
                else
                {
                    if (nums[m] <= target && target >= nums[r])
                    {
                        l = m + 1;
                    }
                    else
                    {
                        r = m - 1;
                    }
                }
            }

            return false;
        }
    }
}
