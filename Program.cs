using DS.BinarySearch;
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
using System.Text;
using QuickSort = DS.LinkedList.QuickSort;

class Program
{

    public static void Main(string[] args)
    {
        //LinkedListProgram linkedListProgram = new LinkedListProgram();
        //linkedListProgram.CallMainForLinkedList();
        //Others others = new Others();
        //var ans = others.NthRoot(3, 27);
        //Console.WriteLine(ans);

        //int[] ar1 = { 1, 2, 3, 6 };
        //int[] ar2 = { 4, 6, 8, 10 };
        //int[] ar1 = { 1, 12, 15, 36, 38 };
        //int[] ar2 = { 2, 13, 17, 30, 45 };
        //int n1 = ar1.Length;
        //int n2 = ar2.Length;
        //Console.WriteLine("Median is " +
        //               findMedian(ar1, ar2, 0, 0,
        //                         ar1.Length - 1,
        //                         ar2.Length - 1));

        //PrintBackward print = new PrintBackward();
        //print.print(5);
        //Recursion recursion = new Recursion();
        //recursion.CalculateFactorial(4);
        //Sum sum = new Sum();
        //sum.calculate();

        //SearchRotated  searchRotated = new SearchRotated();
        //searchRotated.Test();

        //CountAndSay count = new CountAndSay();
        //count.RunCountAndSay();

        //string str = "abc";
        //var result = program.SubSetRecursive(str);
        //var result = program.permute(arr);

        ////heapTest.StartHeapTest();
        //heapTest.FindKthLargest();


        //QuickSort qc = new QuickSort();
        //int[] arr = new int[] {1,8,3,9,4,5,7};
        //qc.quickSort(arr, 0, arr.Length - 1);
        //Console.WriteLine(arr);

        //int[] arr1 = new int[] { 3, 4, 5, 1, 2 };
        //int[] arr2 = new int[] { 2, 1, 3, 4};

        //Others o = new Others();
        //var ans1 = o.Check(arr1);
        //var ans2 = o.Check(arr1);

        //var result1 = o.CheckString("aaabbb");
        //var result2 = o.CheckString("abab");


        //var ans = o.AreNumbersAscending("1 b 3 b 4 r 6 g 12 l");


        //int[] arr = { 4,10,3,5,1 };
        //int N = arr.Length;

        //// Function call
        //HeapSort ob = new HeapSort();
        //ob.sort(arr);

        //Console.WriteLine("Sorted array is");
        //ob.printArray(arr);

        //LinkedListProgram listProgram = new LinkedListProgram();
        //listProgram.CallMainForLinkedList();

        //DoublyLinkedList doubly = new DoublyLinkedList();
        //doubly.MainDoubly();
        //QuickSort quickSort = new DS.LinkedList.QuickSort();
        //quickSort.MainLLQuick();

        //FlattenList list = new FlattenList();
        //list.FlattenMain();


        //RecursionProgram recursionProgram = new RecursionProgram();
        //recursionProgram.RecursionProgramMain();
        //Program program = new Program();
        //string[] input = new string[] { "a","b", "c"};
        //int result = program.MinDeletionSize(input);
        //int result = program.fib(6);
        //int result = 13 % 3;
        //Console.Write(result);

        //Program program = new Program();
        //int[] arr = new int[] { 1, 2, 3 };
        ////var result = program.SubSetRecursive(arr);
        //var result = program.permute(arr);

        //Queen q = new Queen();
        //var ans = q.SolveNQueens(4);

        //PallindromePartioning pallindromePartioning = new PallindromePartioning();
        //var ans = pallindromePartioning.Partition("aabb");

        //Rat ratInAMaze = new Rat();
        //ratInAMaze.RatInAMazeMainFunc();

        //NonDecreasingSeq seq = new NonDecreasingSeq();
        //int[] nums = new int[] { 4, 4, 3, 2, 1 };
        //var res = seq.FindSubsequences(nums);

        //BinaryTree binaryTree = new BinaryTree();
        //binaryTree.BTMain();
        //string str = "aabbccc";
        //var result = Compress(str.ToCharArray());

        //int[][] jagged_arr = new int[3][];
        //jagged_arr[0] = new int[] { 1, 2, 3 };
        //jagged_arr[1] = new int[] { 4, 5, 6 };
        //jagged_arr[2] = new int[] { 7, 8, 9 };
        //var result = new Others().DiagonalSum(jagged_arr);
        //var result = new Others().ReverseWords("  hello world  ");
        //var arr = new int[] { 1, 5, 0, 4, 1, 3 };
        //var result = new Others().CanPlaceFlowers(arr, 2);
        //var result = new Others().IncreasingTriplet(arr);
        //var result = new Others().IsSubsequence("abc", "ahbgdc");
        //var result = new Others().FindMaxAverage(arr, 4);
        //var start = new int[] { 0,3,1,5,8,5};
        //var end = new int[] { 6,4,2,7,9,9};
        //var res = new MeetingRoom().maxMeetings(start, end, 6);
        //Console.WriteLine(res);
        //MyHashSet myHashSet = new MyHashSet();
        //myHashSet.Add(1);
        //myHashSet.Add(2);
        //var r1 = myHashSet.Contains(1);
        //var r2 = myHashSet.Contains(3);
        //myHashSet.Add(2);
        //var r3 = myHashSet.Contains(2);
        //myHashSet.Remove(2);
        //var r4 = myHashSet.Contains(2);
        ////Others o = new Others();
        //// var start = new int[] { 1, 79, 80, 1, 1, 1, 200, 1 };
        ////var res = o.MaxScore(start, 3);
        ////var ans = o.characterReplacement("AABABBA", 1);

        var arr = new int[4][] { new int[] { 1,2,3,4 },
                                 new int[] { 5, 0 ,7, 8},
                                 new int[] { 0, 11, 11, 12 },
                                 new int[] { 13,14,15,0} };
        ////var arr = new int[2][] { new int[] { 4,3},
        ////                         new int[] { 3,2}
        ////};
        ////var uttar  = o.CountNegatives(arr);
        //var arr1 = new int[] { 1,2,3,4,5};
        //var arr2 = new int[] { 1,2,3};
        //var uttar = o.rowWithMax1s(arr, 4, 4);
        //o.SetZeroes(arr);
        //var res = o.Generate(5);
        //var u = o.RemoveDigit("1231", '1');
        //MergeSort mergeSort = new MergeSort();

        //mergeSort.Run();

        //Program p = new Program();
        //var a = new string[4] { "a","abcf","aa","a"};

        //var result = p.LongestCommonPrefix(a);
        
        Others o2 = new Others();
        var arr1 = new int[3] { 15, 17, 2 };
        o2.findPages(arr1, 2);
    }

    public string LongestCommonPrefix(string[] strs)
    {
        string str = strs[0];
        if (strs.Length == 1) return str;
        var sb = new StringBuilder();
        var result = new StringBuilder();
        foreach (var ch in str)
        {
            sb.Append(ch.ToString());
            string s = sb.ToString();
            for (int i = 1; i < strs.Length; i++)
            {
                if (!strs[i].StartsWith(s))
                    return result.ToString();
            }
            result.Append(ch.ToString());
        }
        return "";
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

