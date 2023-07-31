using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Recursion
{
    internal class Recursion
    {
        public int CalculateFactorial(int n)
        {
            
            if (n == 0) return 1;
            
            int fact = CalculateFactorial(n - 1);
            int result = n * fact;
            return result;
        }
    }
}
