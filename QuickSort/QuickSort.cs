using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.QuickSort
{
    public class QuickSort
    {
        public void quickSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int pi = partition(arr, l, r);
                quickSort(arr, l, pi);
                quickSort(arr, pi+1, r);
            }
        }

        //private int Partition(int[] arr, int l, int r)
        //{
        //    int pivot = arr[l];
        //    int i = l - 1;
        //    for (int j = l; j <= r - 1; j++)
        //    {
        //        if (arr[j] > pivot)
        //        {
        //            i++;
        //            swap(arr, i, j);
        //        }
        //    }
        //    swap(arr, i + 1, r);
        //    return i + 1;
        //}

        //private int Partition(int []arr, int low, int high)
        //{

        //    // First element as pivot
        //    int pivot = arr[low];
        //    int k = high;
        //    for (int i = high; i > low; i--)
        //    {
        //        if (arr[i] > pivot)
        //        {
        //            swap(arr, i, k);
        //            k--;
        //        }

        //    }
        //    swap(arr, low, k);
        //    // As we got pivot element index is end
        //    // now pivot element is at its sorted position
        //    // return pivot element index (end)
        //    return k;
        //}


        private int partition(int[] arr, int low, int high)
        {
            int pivot = arr[low];
            int i = low - 1, j = high + 1;

            while (true)
            {
                // Find leftmost element greater
                // than or equal to pivot
                do
                {
                    i++;
                } while (arr[i] < pivot);

                // Find rightmost element smaller
                // than or equal to pivot
                do
                {
                    j--;
                } while (arr[j] > pivot);

                // If two pointers met.
                if (i >= j)
                    return j;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                // swap(arr[i], arr[j]);
            }
        }

        private void swap(int[] arr, int i, int j)
        {
            int t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }
    }
}
