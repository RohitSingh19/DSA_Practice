using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Recursion
{
    public class RecursionProgram
    {
        public bool Exist(char[][] board, string word)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (DFS(board, i, j, 0, word)) return true;
                }
            }
            return false;
        }

        private bool DFS(char[][] board, int i, int j, int wordIndex, string word)
        {
            if (wordIndex == word.Length)
                return true;

            if (i < 0 || i >= board.Length || j < 0 || j >= board[i].Length || word[wordIndex] != board[i][j])
                return false;

            char ch = board[i][j];
            board[i][j] = '~'; //marking it empty
            bool result = DFS(board, i + 1, j, wordIndex + 1, word) ||
                          DFS(board, i - 1, j, wordIndex + 1, word) ||
                          DFS(board, i, j + 1, wordIndex + 1, word) ||
                          DFS(board, i, j - 1, wordIndex + 1, word);

            board[i][j] = ch;
            return result;
        }
        public List<string> GenerateBinaryStrings(int n)
        {
            if (n == 0)            
                return new List<string>() { "" };
            

            if (n == 1)
                return new List<string>() { "0", "1" };
            

            var listFromRecusrion = GenerateBinaryStrings(n - 1);
            var result = new List<string>();
            
            foreach (string s in listFromRecusrion)
            {
                result.Add(s + "0");
                if (s[s.Length - 1] != '1')
                {
                    result.Add(s + "1");
                }
            }

            return result;
        }

        public IList<string> LetterCombinations(string digits)
        {
            Dictionary<char, string> phone = new Dictionary<char, string> {
            {'2', "abc"}, {'3', "def"}, {'4', "ghi"}, {'5', "jkl"},
            {'6', "mno"}, {'7', "pqrs"}, {'8', "tuv"}, {'9', "wxyz"}
        };

            List<string> result = new List<string>();
            if (digits.Length == 0) return result;
            Search("", digits, 0, phone, result);
            return result;
        }

        private void Search(string combination, string digits, int index, Dictionary<char, string> phone, List<string> result)
        {
            if (index == digits.Length)
            {
                result.Add(combination);
                return;
            }
            string letters = phone[digits[index]];
            foreach (char letter in letters)
            {
                Search(combination + letter, digits, index + 1, phone, result);
            }
        }

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
