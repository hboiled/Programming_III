using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySort
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Random rand = new Random();
            
            int SIZE = 100_000;
            int[] BISalary = new int[SIZE];
            Stopwatch stopwatch = new Stopwatch();

            

            Console.WriteLine("Comparison of three sorts:");
            /*
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    BISalary[j] = rand.Next(10_000, 10_000_000);
                }

                // array copies            
                int[] InsertionSalary = (int[])BISalary.Clone();
                int[] MergeSalary = (int[])BISalary.Clone();

                InsertionSorter.InsertSortTime(stopwatch, InsertionSalary);
                stopwatch.Reset();
                Mergesorter.MergeSortTime(stopwatch, MergeSalary);
                stopwatch.Reset();
                BuiltInSort.BISortTime(stopwatch, BISalary);
                stopwatch.Reset();
                
            }
            */
            Demo();
        }

        static void Demo()
        {
            int[] demo = { 5, 90, 234, 55, 81, 238, 679, 1248, 23, 90, 11 };
            int[] demo2 = (int[]) demo.Clone();

            Console.WriteLine("Insertion");
            foreach (int i in demo)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            InsertionSorter.InsertSort(demo);            
            foreach (int i in demo)
            {
                Console.Write(i + " ");
            }            
            Console.WriteLine();

            Console.WriteLine("Merge");
            foreach (int i in demo2)
            {
                Console.Write(i + " ");
            }
            Mergesorter.MergeSort(demo2, new int[demo.Length], 0, demo.Length -1);
            Console.WriteLine();
            foreach (int i in demo2)
            {
                Console.Write(i + " ");
            }
        }
    }
}
