using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySort
{
    class BuiltInSort
    {
        public static void BISortTime(Stopwatch st, int[] arr)
        {
            Console.WriteLine("\nTimer start for Built in sort method:");
            st.Start();
            Array.Sort(arr);
            st.Stop();
            int timeInMS = st.Elapsed.Milliseconds;
            Console.WriteLine("Time in milliseconds: " + timeInMS);
            RecordData(timeInMS);
        }

        private static void RecordData(int ms)
        {
            using (StreamWriter sw = new StreamWriter("BISdata.txt", true))
            {
                sw.WriteLine(ms);
            }
        }
    }
}
