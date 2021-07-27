using System;
using System.Collections.Generic;

namespace Sorting
{
    class Program
    {
        static void Main()
        {
            var arr1 = new int[] { 2, 5, 7, 3, 9, 4, 1 };
            var arr2 = new List<double>() { 1.2, 1.6, 1.1, 1.9, 1.5 };
            arr1.SortBy(new ShellSort<int>());
            arr2.SortBy(new ShellSort<double>());
            arr1.ShowList();
            arr2.ShowList();

            Console.ReadLine();
        }
    }
}
