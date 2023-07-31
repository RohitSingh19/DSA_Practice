using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Recursion
{
    public class Sum
    {
        int sum = 0;
        public void calculate()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5 };
            int result = getSum(arr, 0, 5);
            Console.Write(result);
        }

       public int getSum(int[] arr, int i, int n)
        {
            if (i >= n)
                return sum;

            sum += arr[i];
            return getSum(arr, ++i, n);
        }
    }


}
