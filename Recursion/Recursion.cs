using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Recursion
{
    public class Recursion
    {
        public int CalculateFactorial(int n)
        {
            
            if (n == 0) return 1;
            
            int fact = CalculateFactorial(n - 1);
            int result = n * fact;
            return result;
        }

        public int CountStairs(int n) 
        {
            if (n == 0) { return 1; }
            if (n < 0) { return 0; }
            int ways = CountStairs(n - 1) + CountStairs (n-2);
            return ways;
        }


        public void ReverseStack(Stack<int> stack)
        {
            if (stack.Count == 0)
                return;

            int val = stack.Pop();
            ReverseStack(stack);
            stack.Push(val);
        }
    }
}
