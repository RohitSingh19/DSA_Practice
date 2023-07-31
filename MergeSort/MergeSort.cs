using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DS.MergeSort
{
    public class MergeSort
    {
        public int mergeSort(int[] arr, int low, int high)
        {
            int inv = 0;
            if (low >= high) 
                return 0;

            int mid = (low + high) / 2;
            inv += mergeSort(arr, low, mid);  // left half
            inv += mergeSort(arr, mid + 1, high); // right half
            inv += merge(arr, low, mid, high);  // merging sorted halves

            return inv;
        }
        public void Run()
        {
            int[] arr = new int[] {2,4,1,3,5};
            int inversionCount = mergeSort(arr, 0, arr.Length-1);
        }
        private int merge(int[] arr, int low, int mid, int high)
        {
            int[] temp = new int[high-low+1]; // temporary array
            int left = low;      // starting index of left half of arr
            int right = mid + 1;   // starting index of right half of arr
            int inv = 0;
            //storing elements in the temporary array in a sorted manner//
            int idx = 0;

            while (left <= mid && right <= high)
            {
                if (arr[left] <= arr[right])
                {
                    temp[idx] = arr[left];
                    left++;
                }
                else
                {
                    temp[idx] = arr[right];
                    right++;
                    inv += mid - left + 1;
                }
                idx++;
            }

            // if elements on the left half are still left //

            while (left <= mid)
            {
                temp[idx] = (arr[left]);
                left++;
                idx++;
            }

            //  if elements on the right half are still left //
            while (right <= high)
            {
                temp[idx] = (arr[right]);
                right++;
                idx++;
            }
            
            // transfering all elements from temporary to arr //
            for (int i = low; i <= high; i++)
            {
                arr[i] = temp[i-low];
            }

            return inv;
        }

    }
}