using DS.BinarySearch;
using DS.DP;
using DS.Greedy;
using DS.Heap;
using DS.LinkedList;
using DS.MergeSort;
using DS.Others;
using DS.QuickSort;
using DS.Recursion;
using DS.Tree;
using Microsoft.VisualBasic;
using System;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using QuickSort = DS.LinkedList.QuickSort;

class Program
{
    public static bool BackspaceCompare(string s, string t)
    {
        Console.WriteLine(helper(s));
        Console.WriteLine(helper(t));

        return (s == t);
    }


    private static string helper(string str)
    {
        StringBuilder sb = new();
        int len = str.Length - 1;
        while (len >= 0)
        {

            int backSpace = 0;
            int idx = len;
            while (idx >= 0 && str[idx] == '#')
            {
                backSpace++;
                idx--;
            }

            len = idx;
            while (backSpace > 0 && len > 0)
            {
                backSpace--;
                len--;
            }
            sb.Insert(0, str[len] + "");

            
            len--;
        }
        sb.Length--;
        return sb.ToString();
    }

    public static int TotalMoney(int n)
    {
        

        int q = n / 7;
        int rem = n % 7;
        int start = 1;
        int sum = 28;
        if (q == 0)
        {
            sum = 0;
        }
        int prevSum = sum;
        while (q > 0)
        {
            sum = prevSum + 7;
            prevSum = sum;
            q--;
            start++;
        }
        Console.WriteLine(sum);
        while (rem > 0)
        {
            sum += start++;
            rem--;
        }

        return sum;
    }

    public static IList<IList<int>> Generate(int numRows)
    {
        var result = new List<List<int>>();
        result.Add(new List<int>() { 1});
        int pointer = 1;
        while (pointer <= numRows)
        {

            List<int> prev = result[pointer - 1];
            int prevCount = prev.Count;
            Console.WriteLine(prev.Count);
            int start = 1;
            var list = new List<int>();
            while (start <= prevCount)
            {
                Console.WriteLine(start);

                if (start == 1 || start == prevCount)
                {
                    list.Add(1);
                } 
                else
                {
                    int curr = prev[start - 1] + prev[start - 2];
                    list.Add(curr);
                    start++;
                }
                
            }
            result.Add(list);
            pointer++;
        }
        return result.ToArray();
    }

    public int solution(int[] A, int[] B)
    {
        int n = A.Length;
        int m = B.Length;

        int[] prefixSumA = new int[n + 1];
        int[] prefixSumB = new int[m + 1];

        for (int i = 1; i <= n; i++)
            prefixSumA[i] = prefixSumA[i - 1] + A[i - 1];

        for (int i = 1; i <= m; i++)
            prefixSumB[i] = prefixSumB[i - 1] + B[i - 1];

        int count = 0;
        for (int k = 0; k < n; k++)
        {
            if (prefixSumA[k] == prefixSumA[n] - prefixSumA[k] &&
                prefixSumB[k] == prefixSumB[m] - prefixSumB[k])
            {
                count++;
            }
        }

        return 0;
    }

    private void PCL()
    {
        int[] A = new int[] { 0, 4, -1, 0, 3 };
        int[] B = new int[] { 0, -2, 5, 0, 3 };

        //int[] A = new int[] { 2,-2,-3,3};
        //int[] B = new int[] { 0,0,4,-4 };

        int ans = fairIndex(A, B);
    }

    public static int fairIndex(int []a, int []b)
    {
        int sumA = 0;
        int sumB = 0;

        for (int i = 0; i < a.Length; i++)
        {
            sumA += a[i];
            sumB += b[i];
        }
        int count = 0;
        int tempA = a[0];
        int tempB = b[0];

        for (int i = 1; i < a.Length; i++)
        {
            if (i != 1 && tempA == tempB && 2 * tempA == sumA && 2 * tempB == sumB)
            {
                count++;
            }
            tempA += a[i];
            tempB += b[i];
        }
        return count;
    }
    public int solution(int N, string S)
    {

        string[] reservedSeats = S.Split(' ');
        Dictionary<int, HashSet<int>> seats = new Dictionary<int, HashSet<int>>();

        foreach (string seat in reservedSeats)
        {
            int row = int.Parse(seat.Substring(0, seat.Length - 1));
            int col = seat[seat.Length - 1] - 'A';

            if (col >= 1 && col <= 4)
                seats[row] = new HashSet<int>(0);
            else if (col >= 5 && col <= 8)
                seats[row] = new HashSet<int>(1);
            else if (col >= 9 && col <= 10)
                seats[row] = new HashSet<int>(2);
        }

        int res = 2 * N;

        foreach (int row in seats.Keys)
        {
            if (seats[row].IsSubsetOf(new HashSet<int> { 1, 2, 3, 4 }) && seats[row].IsSubsetOf(new HashSet<int> { 5, 6, 7, 8 }))
                continue;
            else if (seats[row].IsSubsetOf(new HashSet<int> { 1, 2, 3 }) && seats[row].IsSubsetOf(new HashSet<int> { 7, 8, 9 }))
                res -= 1;
            else
                res -= 2;
        }

        return res;
    }

    public int FindLeastNumOfUniqueInts(int[] arr, int k)
    {
        var map = new Dictionary<int, int>();

        foreach (var num in arr)
        {
            if (map.ContainsKey(num))
            {
                map[num]++;
            }
            else
            {
                map[num] = 1;
            }
        }
        map = map.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        foreach (var pair in map)
        {

            while (map[pair.Key] > 0 && k > 0)
            {
                map[pair.Key]--;
                k--;
            }
            if (map[pair.Key] == 0)
                map.Remove(pair.Key);


        }

        return map.Count;
    }

    public long minTime(int[] arr, int n, int k)
    {

        int lo = arr.Max();
        int hi = arr.Sum();
        int result = -1;
        while (lo <= hi)
        {
            int mid = lo + (hi - lo) / 2;
            if (CanPaint(arr, mid, k))
            {
                result = mid;
                hi = mid - 1;
            }
            else
            {
                lo = mid + 1;
            }
        }
        return result;
    }
    private bool CanPaint(int[] arr, int walls, int limit)
    {
        int count = 1;
        int wallsPainted = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            wallsPainted += arr[i];

            if (wallsPainted > limit)
            {
                count++;
                wallsPainted = arr[i];
            }
        }

        return count <= limit;

    }

    public int median(List<List<int>> matrix, int R, int C)
    {
        int lo = int.MaxValue;
        int hi = int.MinValue;

        for (int i = 0; i < matrix.Count; i++)
        {
            for (int j = 0; j < matrix[i].Count; j++)
            {
                lo = Math.Min(matrix[i][j], lo);
                hi = Math.Max(matrix[i][j], hi);
            }
        }

        int requiredNum = (R * C) / 2;
        while (lo <= hi)
        {
            int mid = (lo + hi) / 2;
            int smallCount = countSmallEqual(matrix, R, mid);

            if (smallCount <= requiredNum)
                lo = mid + 1;
            else
                hi = mid - 1;
        }

        return lo;
    }

    private int countSmallEqual(List<List<int>> matrix, int R, int x)
    {
        int smallerCount = 0;

        for (int r = 0; r < R; r++)
        {
            smallerCount += UpperBound(matrix[r], x);
        }
        return smallerCount;
    }

    private int UpperBound(List<int> arr, int x)
    {
        int lo = 0;
        int hi = arr.Count - 1;
        int ans = hi;

        while (lo <= hi)
        {
            int mid = (lo + hi) / 2;
            if (mid > x)
            {
                ans = mid;
                hi = mid - 1;
            }
            else
            {
                lo = mid + 1;
            }
        }
        return ans;
    }

    public int TriangularSum(int[] nums)
    {
        List<int> list;
        List<int> prev = new List<int>(nums);
        while (prev.Count > 1)
        {
            list = new List<int>();
            for (int idx = 0; idx < prev.Count - 1; idx++)
            {
                int sum = (prev[idx] + prev[idx + 1]);
                list.Add(sum > 9 ? sum % 10 : sum);
            }
            prev = list;
        }

        return prev[0];
    }


    public string RemoveOuterParentheses(string s)
    {
        var sb = new StringBuilder();
        int openCount = 0; 
        foreach(var ch in s)
        {
            if (ch == '(')
            {
                if (openCount > 0)
                {
                    sb.Append(ch);
                }

                openCount++;
            }
            else 
            { 
                if(openCount > 1) { 
                    sb.Append(ch); 
                }
                openCount--;
            }
        }

        return sb.ToString();
    }
    public static void Main(string[] args)
    {
        //BinaryTree binaryTree = new BinaryTree();
        //binaryTree.BTMain();
        //Program program = new Program();
        //var arr = new string[] {"dadaabaa", "bdaaabcc" };
        //var result = program.CommonChars(arr);

        //Subset subset = new Subset();
        //int[] arr = new int[] { 1,2,3};
        //var s = subset.Subsets(arr);

        RecursionProgram program = new RecursionProgram();
        char[][] arr = new char[3][];
        arr[0] = new char[4] { 'Z', 'B', 'C', 'E' };
        arr[1] = new char[4] { 'S', 'F', 'C', 'S' };
        arr[2] = new char[4] { 'A', 'D', 'E', 'E' };
        
        var result = program.Exist(arr, "ABCCED");
        //var result = program.GenerateBinaryStrings(2);

    }

    public IList<string> CommonChars(string[] words)
    {
        var result = new List<string>();
        var dict = new Dictionary<char, int>();
        foreach (var character in words[0])
        {
            if (dict.ContainsKey(character))
            {
                dict[character]++;
            }
            else
            {
                dict[character] = 1;
            }
        }
        
        foreach (var pair in dict)
        {
            int min = pair.Value;
            for (int idx = 1; idx < words.Length; idx++)
            {
                int count = countOfCharInWord(words[idx], pair.Key);

                if (count == 0)
                    break;
                min = Math.Min(min, count);
                if (idx == words.Length - 1)
                {
                    int val = min;
                    while (val > 0)
                    {
                        result.Add(pair.Key + "");
                        val--;
                    }
                }
            }
        }
        return result.ToArray();
        /*
            b = 1
            e = 1
            l = 2
            a = 1
        */
    }

    private int countOfCharInWord(string word, char ch)
    {
        int count = 0;
        foreach (var character in word)
        {
            if (character == ch) count++;
        }

        return count;
    }

    public string MinWindow(string s, string t)
    {
        int[] map = new int[128];
        foreach (var ch in t)
            map[ch]++;

        int startIndex = -1;
        int minLen = int.MaxValue;
        int count = 0;
        for (int right = 0, left = 0; right < s.Length; right++)
        {
            //if the character is already present in the map array, which means it can be part of target
            if (map[s[right]] > 0)
            {
                count++;
                map[s[right]]--; // character taken
            }
            while (count == t.Length)
            {
                if (right - left + 1 < minLen)
                {
                    minLen = right - left + 1;
                    startIndex = left;
                }
                map[s[left]]--;
                left++;
                if (map[s[left]] > 0)
                    count--;

            }
        }
        return startIndex == -1 ? string.Empty : s.Substring(startIndex, minLen);
    }
    public int AtMostK(int[] A, int K)
    {
        int left = 0, res = 0, distinctCount = 0;
        Dictionary<int, int> count = new Dictionary<int, int>();
        for (int right = 0; right < A.Length; right++)
        {

            if (!count.ContainsKey(A[right]))
            {
                count[A[right]] = 1;
                distinctCount++;
                while (distinctCount > K)
                {
                    count[A[left]]--;
                    if (count[A[left]] == 0)
                    {
                        count.Remove(A[left]);
                        distinctCount--;
                    }
                    left++;
                }
            }
            else
            {
                count[A[right]]++;
            }

            res += right - left + 1;
        }
        return res;
    }
    public int NumSubarraysWithSum(int[] nums, int goal)
    {
        if (goal < 0) return 0;
        int res = 0, i = 0, n = nums.Length;
        
        for(int j = 0; j < n; j++)
        {
            goal -= nums[j];
            while(goal < 0)
            {
                goal += nums[i++];
            }
            res += j - i + 1;
        }

        return res;

    }
    public class Pair
    {
        public int index;
        public int count;

        public Pair(int index, int count)
        {
            this.index = index;
            this.count = count;
        }

    }
    public string CustomSortString(string order, string s)
    {
        Dictionary<char, Pair> dict = new();
        StringBuilder resultSb = new StringBuilder();
        StringBuilder extraSb = new StringBuilder();

        for (int idx = 0; idx < s.Length; idx++)
        {
            if (!dict.ContainsKey(s[idx]))
            {
                int index = order.IndexOf(s[idx]);
                if (index == -1)
                {
                    extraSb.Append(s[idx]);
                }
                else
                {
                    dict[s[idx]] = new Pair(index, 1);
                }
            }
            else 
            {
                dict[s[idx]].count++;
            }
        }

        dict = dict.OrderBy(x => x.Value.index).ToDictionary(x=> x.Key, x => x.Value);

        foreach(var item in dict)
        {
            int val = item.Value.count;
            while(val > 0)
            {
                resultSb.Append(item.Key);
                val--;
            }
        }



        //char[] arr = new char[order.Length];


        //foreach (var ch in s)
        //{
        //    if (dict.ContainsKey(ch))
        //    {
        //        var index = dict[ch];
        //        arr[index] = ch;
        //    }
        //    else
        //    {
        //        extraSb.Append(ch);
        //    }
        //}
        //var resultSb = new StringBuilder();
        //foreach (var ch in arr)
        //{
        //    if (char.IsLetter(ch))
        //        resultSb.Append(ch.ToString());
        //}
        resultSb.Append(extraSb.ToString());
        return resultSb.ToString();
        
    }
    public int MyAtoi(string a)
    {
        StringBuilder result = new StringBuilder();
        /*removing any trailing spaces*/
        string s = a.Trim();

        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsLetter(s[i]) || s[i] == '.') return 0;
            if (char.IsDigit(s[i]))
            {
                if (i > 1) return 0;
                if (i == 1) return MyFunc(i - 1, s);
                return MyFunc(i, s);
            }
        }
        return 0;
    }

    private int MyFunc(int index, string s)
    {
        StringBuilder res = new StringBuilder();
        if (s[index] == '-')
        {
            res.Append('-');
            index++;
        }
        else if (s[index] == '+') index++;

        for (int i = index; i < s.Length; i++)
        {
            if (!char.IsDigit(s[i]))
            {
                return CheckNumber(res.ToString());
            }
            res.Append(s[i]);
        }
        return CheckNumber(res.ToString());
    }

    private int CheckNumber(string numberString)
    {
        if (int.TryParse(numberString, out int number))
        {
            if (number > int.MaxValue)
            {
                return int.MaxValue;
            }
            else if (number < int.MinValue)
            {
                return int.MinValue;
            }
            else
            {
                return number;
            }
        }
        return (numberString[0] == '-') ? int.MinValue : int.MaxValue;
    }

    public int MaxFreq(string s, int maxLetters, int minSize, int maxSize)
    {
        if (s == null || s.Length == 0 || maxLetters == 0) return 0;

        var dict = new Dictionary<string, int>();
        int max = 0;
        for (int i = 0; i < s.Length - minSize + 1; i++)
        {
            string sub = s.Substring(i, i + minSize);
            if (isValid(sub, maxLetters))
            {
                if (dict.ContainsKey(sub))
                    dict[sub]++;
                else
                    dict[sub] = 1;

                max = Math.Max(dict[sub], max);
            }
        }
        return max;
    }

    private bool isValid(string str, int maxLetters)
    {
        var hashSet = new HashSet<char>();
        foreach (var ch in str)
        {
            hashSet.Add(ch);
        }
        return hashSet.Count <= maxLetters;
    }
    public long WonderfulSubstrings(string word)
    {
        int[] map;
        long result = 0;

        for (int idx = 0; idx < word.Length; idx++)
        {
            map = new int[10];
            Array.Fill(map, -1);
            for (int jdx = idx; jdx < word.Length; jdx++)
            {
                if (map[word[jdx] - 'a'] == -1)
                    map[word[jdx] - 'a'] = 1;
                else
                    map[word[jdx] - 'a']++;

                result += CountOdds(map) ? 1 : 0;
            }
        }
        return result;
    }
    private bool CountOdds(int[] map)
    {
        for (int idx = 0; idx < 10; idx++)
        {
            if (map[idx] == 0 || map[idx] == 1) return true;
        }
        return false;
    }
    public string LongestPalindrome(string s)
    {
        string res = string.Empty;
        int prev = 0;
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i; j < s.Length; j++)
            {
                bool flag = isPallindrome(s, i, j);
                if (flag && (j - i + 1) > prev)
                {
                    prev = (j - i + 1);
                    res = s.Substring(i, j);
                }
            }
        }
        return res;
    }

    private bool isPallindrome(string s, int l, int r)
    {
        while (l <= r && s[l] == s[r])
        {
            l++;
            r--;

            if (l > r) return true;
        }

        return false;
    }
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs.Length == 1) return strs[0];
        var sb = new StringBuilder();
        string str = strs[0];
        int idx = 0;
        while (idx < str.Length)
        {
            string S = idx == 0 ? str[idx].ToString() : sb.ToString();

            for (int i = 1; i < strs.Length; i++)
            {
                if (!strs[i].StartsWith(S))
                {
                    return sb.ToString();
                }
            }
            sb.Append(str[idx]);
            idx++;
        }
        return sb.Length > 0 ? sb.ToString() : "";
    }
    public static int Compress(char[] chars)
    {

        StringBuilder sb = new StringBuilder();
        int idx = 0;

        while (idx < chars.Length)
        {
            int next = idx + 1;
            int charCount = 1;
            while (next < chars.Length && chars[idx] == chars[next])
            {
                charCount++;
                next++;
            }
            if (charCount > 1)
            {
                sb.Append(chars[idx]);
                sb.Append(charCount);
            }
            else
            {
                sb.Append(chars[idx]);
            }
            idx = next;

        }
        string res = sb.ToString();

        return sb.ToString().Length;
    }

    public int fib(int n)
    {
        if (n <= 1) return n;

        int f1 = fib(n - 1);
        int f2 = fib(n - 2);
        return f1+f2;
    }

    public int MinDeletionSize(string[] strs)
    {
     
        
        int deleteCount = 0;
        //while (index <= end)
        //{
        //    int start = 0;

        //    while (start < end && index < end)
        //    {
        //        string string1 = strs[start];
        //        string string2 = strs[start + 1];

        //        if (!check(string1, string2, index))
        //        {
        //            deleteCount++;
        //            start++;
        //            continue;
        //        }
        //        start++;

        //    }
        //    index++;
        //}

        for (int i = 0, index = 0; i < strs.Length - 1; i++, index++)
        {
            if (!check(strs[i], strs[i + 1], index))
            {
                deleteCount++;
                continue;
            }
        }

        return deleteCount;
    }


    public bool check(string strA, string strB, int index)
    {
        char a = strA[index];
        char b = strB[index];

        int i = (int)a;
        int j = (int)b;

        return i <= j;
    }

    public IList<IList<int>> Subsets(int[] nums)
    {
        IList<IList<int>> result = new List<IList<int>>();

        result.Add(new List<int>());

        for (int i = 0; i < nums.Length; i++)
        {

            int previousCount = result.Count;

            for (int j = 0; j < previousCount; j++)
            {

                List<int> list = new List<int>(result[j]);
                list.Add(nums[i]);
                result.Add(list);
            }

        }
        return result;
    }
    public IList<IList<int>> SubSetRecursive(int [] str)
    {
        List<List<int>> result = new List<List<int>>();
        //solve(str, 0, new List<int>(), result);
        int res = SubsequenceSumOnlyCount(str, 0, new List<int>(), 0, 2);
        return result.ToArray();
    }

    public bool SubsequenceSumOnlyOne(int[] nums, int index, List<int> list, int sum, int k)
    {

        //base case
        if (index == nums.Length)
        {
            if (k == sum)
            {
                Console.WriteLine(String.Join(", ", list));
                return true;
            }
            return false;
        }

        list.Add(nums[index]);
        sum += nums[index];
        if(SubsequenceSumOnlyOne(nums, index + 1, list, sum, k))
            return true;

        sum -= nums[index];
        list.RemoveAt(list.Count - 1);

        if (SubsequenceSumOnlyOne(nums, index + 1, list, sum, k))
            return true;

        return false;
             
    }

    public int SubsequenceSumOnlyCount(int[] nums, int index, List<int> list, int sum, int k)
    {

        //base case
        if (index == nums.Length)
        {
            if (k == sum)
            {
                Console.WriteLine(String.Join(", ", list));
                return 1;
            }
            return 0;
        }

        list.Add(nums[index]);
        sum += nums[index];
        int l = SubsequenceSumOnlyCount(nums, index + 1, list, sum, k);
            

        sum -= nums[index];
        list.RemoveAt(list.Count - 1);

        int r = SubsequenceSumOnlyCount(nums, index + 1, list, sum, k);

        return  l + r;

    }

    public void SubsequenceSum(int[] nums, int index, List<int> list, int sum, int k)
    {

        //base case
        if (index == nums.Length)
        {
            if (k == sum)
            {
                Console.WriteLine(String.Join(", ", list));
            }
            return;
        }

        list.Add(nums[index]);
        sum += nums[index];
        SubsequenceSum(nums, index + 1, list, sum, k);

        sum -= nums[index];
        list.RemoveAt(list.Count - 1);
        
        SubsequenceSum(nums, index + 1, list, sum, k);
    }


    public void solve(int [] nums, int i, List<int> list, List<List<int>> result)
    {
        if (i == nums.Length)
        {
            result.Add(new List<int>(list));
            return;
        }

        //exclude
        solve(nums, i + 1, list, result);

        //include
        int d = nums[i];
        list.Add(d);
        solve(nums, i + 1, list, result);
        list.RemoveAt(list.Count() - 1);
    }


    public List<List<int>> permute(int[] nums)
    {
        List<List<int>> list = new List<List<int>>();
        recurPermute(0, nums, list);
        return list;
    }

    private void recurForPermute(List<List<int>> list, List<int> tempList, int[] nums)
    {
        if (tempList.Count == nums.Length)
        {
            list.Add(tempList);
        }
        else
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (tempList.Contains(nums[i])) continue;
                tempList.Add(nums[i]);
                recurForPermute(list, tempList, nums);
                tempList.RemoveAt(tempList.Count - 1);
            }

        }
    }

    private void swap(int[] arr, int i, int j)
    {
        int t = arr[i];
        arr[i] = arr[j];
        arr[j] = t;
    }
    private void recurPermute(int index, int[] nums, List<List<int>> list) {
        if (index == nums.Length) {
            List<int> l = new List<int>();
            for (int i = 0; i < nums.Length; i++) {
                l.Add(nums[i]);
            }
            list.Add(l);
            return;
        }

        for (int i = index; i < nums.Length; i++) 
        { 
            swap(nums, i, index);
            recurPermute(index + 1, nums, list);
            swap(nums, i, index);
        }
    }


    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {

        List<List<int>> result = new List<List<int>>();
        solveDup(nums, 0, new List<int>(), result);
        var hash = new HashSet<List<int>>();

        foreach (var list in result)
        {
            if (!hash.Contains(list))
            {
                hash.Add(list);
            }
        }
        List<List<int>> ans = new List<List<int>>();
        foreach (var iter in hash)
        {
            ans.Add(new List<int>(iter));
        }
        return ans.ToArray();
    }
    public void solveDup(int[] nums, int i, List<int> list, List<List<int>> result)
    {
        if (i == nums.Length)
        {
            result.Add(new List<int>(list));
            return;
        }

        //pick
        solveDup(nums, i + 1, list, result);

        //not pick
        int d = nums[i];
        list.Add(d);
        solveDup(nums, i + 1, list, result);
        list.RemoveAt(list.Count() - 1);
    }
}

