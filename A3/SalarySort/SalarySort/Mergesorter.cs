using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySort
{
    class Mergesorter
    {
        public static void MergeSortTime(Stopwatch st, int[] arr)
        {
            Console.WriteLine("\nTimer start for merge sort method:");
            st.Start();
            MergeSort(arr, new int[arr.Length], 0, arr.Length - 1);
            st.Stop();
            int timeInMS = st.Elapsed.Milliseconds;
            Console.WriteLine("Time in milliseconds: " + timeInMS);
            RecordData(timeInMS);
        }

        private static void RecordData(int ms)
        {
            using (StreamWriter sw = new StreamWriter("MSdata.txt", true))
            {
                sw.WriteLine(ms);
            }
        }

        public static void MergeSort(int[] arr, int[] temp, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int mid = (left + right) / 2;
            // recursive call on both sides
            MergeSort(arr, temp, left, mid);
            MergeSort(arr, temp, mid + 1, right);
            // merge halves
            Merge(arr, temp, mid, left, right);
        }

        private static void Merge(int[] arr, int[] temp, int mid, int start, int end)
        {
            int len = end - start + 1;

            int lIndex = start;
            int rIndex = mid + 1;
            int cIndex = start;

            while (lIndex <= mid && rIndex <= end)
            {
                if (arr[lIndex] < arr[rIndex])
                {
                    temp[cIndex] = arr[lIndex];                    
                    lIndex++;
                }
                else
                {
                    temp[cIndex] = arr[rIndex];
                    rIndex++;
                }
                cIndex++;
            }

            Array.Copy(arr, lIndex, temp, cIndex, mid - lIndex + 1);
            Array.Copy(arr, rIndex, temp, cIndex, end - rIndex + 1);
            Array.Copy(temp, start, arr, start, len);
        }
        
    }
}
