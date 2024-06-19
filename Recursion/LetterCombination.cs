using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Recursion
{
    public class LetterCombination
    {
        private string[] codes = new string[] { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
        public IList<string> LetterCombinations(string digits)
        {
            IList<string> result = new List<string>();
            if (string.IsNullOrEmpty(digits)) return result;

            return result = getCombinations(digits);
        }

        private IList<string> getCombinations(string digits)
        {
            //base case
            if (digits.Length == 0)
            {
                IList<string> baseCaseResult = new List<string>();
                baseCaseResult.Add("");
                return baseCaseResult;
            }

            char currChar = digits[0];
            string remDigits = digits.Substring(1);
            IList<string> recusrsionResult = getCombinations(remDigits);
            IList<string> resultList = new List<string>();
            string charForCode = codes[currChar - '0'];
            foreach (char code in charForCode)
            {
                foreach (string result in recusrsionResult)
                {
                    resultList.Add(code + result);
                }
            }
            return resultList;
        }
    }

}
