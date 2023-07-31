using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Recursion
{
    internal class PrintBackward
    {
        public void print(int n)
        {
            if (n == 0) return;
            else {
                Console.WriteLine(n);
                print(n - 1);
            }
        }
    }
}
