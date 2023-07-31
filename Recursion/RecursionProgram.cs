using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Recursion
{
    public class RecursionProgram
    {


        public void printNameN_Times(string name, int n, int i)
        {
            if (i > n) return;
            Console.WriteLine($"{name} and {++i}");
            printNameN_Times(name,n,i);
        }

        public void printCounting(int i)
        {
            if (i >= 3) 
                   return;

            printCounting(i);
            Console.WriteLine(i);

        }


        public void SumOfFirstN(int i, int sum)
        {
            if (i < 1) {
                Console.WriteLine(sum);
                return;
            } 
            SumOfFirstN(i-1, sum+i);
        }

        public int SumOfFirstNFunctional(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            int sum = SumOfFirstNFunctional(n - 1);
            return n + sum;
        }

        public void RecursionProgramMain()
        {
            //printNameN_Times("Rohit Singh", 5, 1);
            //printCounting(0);
            //SumOfFirstN(5, 0);
            var ans = SumOfFirstNFunctional(5);
            Console.Write(ans);
        }


    }
}
