using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Others
{
    public class Others
    {
        public int findPages(int[] A,int M)
        {
            
            int low = A.Max();
            int high = A.Sum();
            while (low <= high)
            {
                int mid = (low + high) / 2;
                int students = countStudents(A, mid);
                if (students > M)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return low;
        }

        public int countStudents(int[] arr, int pages)
        {
            int n = arr.Length; // size of array
            int students = 1;
            long pagesStudent = 0;
            for (int i = 0; i < n; i++)
            {
                if (pagesStudent + arr[i] <= pages)
                {
                    // add pages to current student
                    pagesStudent += arr[i];
                }
                else
                {
                    // add pages to next student
                    students++;
                    pagesStudent = arr[i];
                }
            }
            return students;
        }
        public int NthRoot(int n, int m)
        {
            int ans = -1;

            int lo = 1;
            int hi = m;

            while (lo <= hi)
            {
                int mid = lo - (hi - lo) / 2;
                int prod = (int)helper(mid, n);
                if (prod < m)
                {
                    lo = mid + 1;
                }
                else
                {
                    ans = (int)mid;
                    hi = mid - 1;
                }
            }
            return ans;

        }


        public static long helper(int num, int times)
        {
            long prod = 1;
            while (times > 0)
            {
                prod *= num;
                times--;
            }

            return prod;
        }


        public string RemoveDigit(string number, char digit)
        {
            int max = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == digit)
                {
                    string temp = number;
                    string temp1 = temp.Remove(i, 1);
                    max = Math.Max(int.Parse(temp1), max);
                }
            }
            return max.ToString();
        }

        public IList<IList<int>> Generate(int numRows)
        {
            var result = new List<List<int>>();

            result.Add(new List<int>() {1});

            for (int i = 1; i < numRows; i++)
            {
                List<int> prev = result[i - 1].ToList();
                List<int> inner = new List<int>();
                for (int j = 0; j <= prev.Count; j++)
                {
                    if (j == 0 || j == prev.Count)
                    {
                        inner.Add(1);
                    }
                    else
                    {
                        int sum = prev[j] + prev[j - 1];
                        inner.Add(sum);
                    }
                }
                result.Add(inner);
            }

            return result.ToArray();
        }

        public int rowWithMax1s(int[][]arr, int n, int m)
        {
            int ansRow = -1;

            int col = m - 1;
            int maxOnes = 0;

            for (int row = 0; row < n; row++)
            {
                if (arr[row][col] == 0)
                    continue;

                int l = 0;
                int r = col;

                while (l < r)
                {
                    int mid = l + (r - l) / 2;
                    if (arr[row][mid] > 0)
                    {
                        r = mid - 1;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }

                if (col - l > maxOnes)
                {
                    maxOnes = col - l;
                    ansRow = row;
                }

                col = m - 1;
            }
            return ansRow;
        }

        public List<int> findUnion(int[] arr1, int[] arr2, int n, int m)
        {
            var list = new List<int>();


            int j = 0;

            int max1 = arr1[n - 1];
            int max2 = arr2[m - 1];

            int[] temp;
            if (max1 > max2)
            {
                temp = new int[max1];
            }
            else
            {
                temp = new int[max2];
            }

            ++temp[arr1[0]];
            list.Add(arr1[0]);

            int i = 1;

            while (i < n)
            {
                if (arr1[i] != arr1[i - 1])
                {
                    list.Add(arr1[i]);
                    ++temp[arr1[i]];
                }
                i++;
            }

            while (j < m)
            {
                if (temp[arr2[j]] == 0)
                {
                    list.Add(arr2[j]);
                    ++temp[arr2[j]];
                }
                j++;
            }

            return list;
        }
        public int SingleNumber(int[] nums)
        {
            /*intilializing result with 0*/
            int result = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                result ^= nums[i];
            }
            return result;
        }
        public IList<string> SummaryRanges(int[] nums)
        {
            int idx = 0;
            var list = new List<string>();
            while (idx < nums.Length)
            {

                int start = nums[idx];
                int end = nums[idx];
                while (idx < nums.Length - 1 && nums[idx + 1] - nums[idx] == 1)
                {
                    end = nums[idx + 1];
                    idx++;
                }

                list.Add(start + "->" + end);
                idx++;
            }
            return list;
        }
        public int CountNegatives(int[][] grid)
        {
            int rows = grid.Length;
            int n = grid[0].Length;
            int count = 0;
            for (int row = 0; row < rows; row++)
            {
                int index = binarySearch(grid, row, 0, n - 1);
                count += (n - index);
            }
            return count;
        }

        private int binarySearch(int[][] grid, int row, int r, int c)
        {
            if (grid[row][c] > 0) return c;

            while (r <= c)
            {
                int m = (r + c) / 2;
                if (grid[row][m] < 0)
                {

                    if (m == 0 || (m > 0 && grid[row][m - 1] > 0))
                        return m;

                    c = m - 1;
                }
                else if (grid[row][m] > 0)
                {
                    r = m + 1;
                }
            }
            return -1;
        }
        public int characterReplacement(String s, int k)
        {
            int len = s.Length;
            int[] count = new int[26];
            int start = 0, maxCount = 0, maxLength = 0;
            for (int end = 0; end < len; end++)
            {
                int idx = s[end] - 'A';
                maxCount = Math.Max(maxCount, ++count[idx]);
                while (end - start + 1 - maxCount > k)
                {
                    count[s[start] - 'A']--;
                    start++;
                }
                maxLength = Math.Max(maxLength, end - start + 1);
            }
            return maxLength;
        }

        public double FindMaxAverage(int[] nums, int k)
        {
            double sum = 0;
            double maxAvg = 0;

            int start = 0;

            while (start < k)
                sum += nums[start++];

            int end = k;

            while (end < nums.Length)
            {
                double avg = Math.Round(sum / k, 5);
                sum += nums[end] - nums[end - start];
                maxAvg = Math.Max(avg, maxAvg);
                end++;
            }
            return maxAvg;
        }

        public bool IsSubsequence(string s, string t)
        {
            int subIndex = 0;
            int counter = 0;
            while (subIndex < s.Length)
            {
                int mainIndex = subIndex;
                bool isCharFound = false;
                while (mainIndex < t.Length)
                {

                    if (s[subIndex] == t[mainIndex])
                    {
                        counter++;
                        subIndex++;
                        mainIndex++;
                        isCharFound = true;
                        break;
                    }
                    mainIndex++;
                }
                if (!isCharFound) return false;
                subIndex++;
            }

            return s.Length == counter;
        }

        public bool IncreasingTriplet(int[] nums)
        {

            int first = Int32.MaxValue;
            int second = Int32.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= first)
                {
                    first = nums[i];
                }
                else if (nums[i] <= second)
                {
                    second = nums[i];
                }
                else
                {
                    return true;
                } 
            }

            return false;

        }
        public string ReverseWords(string s)
        {
            var arr = s.Split(" ").ToList();

            int start = 0;
            int end = arr.Count - 1;

            while (start < end)
            {
                while (start < end && arr[start] == string.Empty)
                {
                    arr.RemoveAt(start);
                }
                    

                while (start < end && arr[end] == string.Empty)
                {
                    arr.RemoveAt(end);
                }
                    
                swap(arr, start++, end--);
            }
            
            return String.Join(" ", arr);
        }
        private void swap(List<string> arr, int i, int j)
        {
            string temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            int startIndex = 0;

            if (flowerbed[0] == 1) startIndex = 2;

            while (startIndex < flowerbed.Length && n > 0 && flowerbed[startIndex] == 0)
            {
                flowerbed[startIndex] = 1;

                if (startIndex < flowerbed.Length - 1 && flowerbed[startIndex] == flowerbed[startIndex + 1]) return false;
                if (startIndex > 0 && flowerbed[startIndex] == flowerbed[startIndex - 1]) return false;

                startIndex = startIndex + 2;
                n--;
            }

            return (n == 0);
        }

        //public int DiagonalSum(int[][] mat)
        //{
        //    int sum = 0;
        //    for (int i = 0; i < mat.Length; i++)
        //    {
        //        for (int j = 0; j < mat.Length; j++)
        //        {
        //            if (i == j)
        //            {
        //                sum += mat[i][j];
        //                continue;
        //            }
        //            if (i + j == mat.Length - 1)
        //            {
        //                sum += mat[i][j];
        //            }
        //        }
        //    }
        //    return sum;
        //}


        public int AddDigits(int num)
        {

            int sumDigit = 0;

            while (num > 0)
            {
                sumDigit += num % 10;
                num = num / 10;
            }

            if (sumDigit.ToString().Length > 1)
                return AddDigits(sumDigit);

            return sumDigit;
        }
        public bool Check(int[] nums)
        {
            int ignore = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int next = (i + 1) % nums.Length;
                if (nums[i] > nums[next])
                    ignore++;


                if (ignore > 1) return false;
            }
            return true;
        }

        public bool CheckString(string s)
        {

            int mismtachCount = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int next = (i + 1) % s.Length;
                if (s[i] != s[next])
                    mismtachCount++;

                if (mismtachCount > 1) return false;

            }

            return true;
        }

        public bool AreNumbersAscending(string s)
        {
            string[] input = s.Split(' ');
            int lastNum = -1;
            for (int i = 0; i < input.Length; i++)
            {
                int currNum;
                bool isNumeric = int.TryParse(input[i], out currNum);

                if (!isNumeric)
                {
                    continue;
                }
                else
                {   
                    if (lastNum >= currNum)
                        return false;
                    else
                        lastNum = currNum;
                }
            }

            return true;
        }

        public void SetZeroes(int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            var hash = new HashSet<string>();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row][col] == 0 && !hash.Contains(row + "" + col))
                    {
                        MoveUp(matrix, row - 1, col, hash);
                        MoveDown(matrix, row + 1, col, hash);
                        MoveLeft(matrix, row, col - 1, hash);
                        MoveRight(matrix, row, col + 1, hash);
                    }
                }
            }
        }

        private void MoveUp(int[][] matrix, int row, int col, HashSet<string> hash)
        {
            while (row >= 0 && !hash.Contains(row + "" + col))
            {
                if (matrix[row][col] != 0)
                    hash.Add(row + "" + col);

                matrix[row][col] = 0;
                row--;
            }

        }

        private void MoveDown(int[][] matrix, int row, int col, HashSet<string> hash)
        {
            while (row < matrix.Length && !hash.Contains(row + "" + col))
            {
                if (matrix[row][col] != 0)
                    hash.Add(row + "" + col);

                matrix[row][col] = 0;
                row++;
            }
        }

        private void MoveLeft(int[][] matrix, int row, int col, HashSet<string> hash)
        {
            Console.WriteLine("MoveLeft");
            Console.WriteLine(row + "" + col);
            while (col >= 0 && !hash.Contains(row + "" + col))
            {
                if (matrix[row][col] != 0)
                    hash.Add(row + "" + col);

                matrix[row][col] = 0;
                col--;
            }
        }

        private void MoveRight(int[][] matrix, int row, int col, HashSet<string> hash)
        {
            while (col < matrix[0].Length && !hash.Contains(row + "" + col))
            {
                if (matrix[row][col] != 0)
                    hash.Add(row + "" + col);

                matrix[row][col] = 0;
                col++;
            }
        }
    }
}
