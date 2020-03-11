using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySort
{
    class InsertionSorter
    {
        public static void InsertSortTime(Stopwatch st, int[] arr)
        {
            Console.WriteLine("\nTimer start for insertion sort method:");
            st.Start();
            InsertSort(arr);
            st.Stop();
            int timeInMS = st.Elapsed.Milliseconds;
            Console.WriteLine("Time in milliseconds: " + timeInMS);
            RecordData(timeInMS);
        }

        private static void RecordData(int ms)
        {
            using (StreamWriter sw = new StreamWriter("ISdata.txt", true))
            {
                sw.WriteLine(ms);
            }
        }

        public static void InsertSort(int[] arr)
        {
            if (arr.Length < 2)
            {
                return;
            }
            for (int i = 1; i < arr.Length; i++)
            {
                int counter = i - 1;
                int currentVal = arr[i];

                while (counter >= 0 && currentVal < arr[counter])
                {
                    arr[counter + 1] = arr[counter];
                    counter--;
                }
                arr[counter + 1] = currentVal;
            }
        }
    }
}
