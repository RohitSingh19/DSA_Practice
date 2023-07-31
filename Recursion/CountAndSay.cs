using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Recursion
{
    public class CountAndSay
    {
        public void RunCountAndSay()
        {
            Console.WriteLine(CountAndSayFunc(4));
        }
        public string CountAndSayFunc(int n)
        {
            if (n == 1) return "1";
            string s = CountAndSayFunc(n - 1);

            string res = "";

            

            for (int i = 0; i < s.Length; i++) {
                
                int counter = 1;

                while (i < s.Length - 1 && s[i] == s[i + 1]) {
                    i++;
                    counter++;
                }

                res = res + counter.ToString() + s[i].ToString();
            }
            return res;

            
        }
    }
}
