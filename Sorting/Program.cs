using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = new int[] { 2, 5, 7, 3, 9, 4, 1 };
            List<double> arr2 = new List<double>() { 1.2, 1.6, 1.1, 1.9, 1.5 };
            arr1.SortBy(new BubbleSort<int>());
            arr2.SortBy(new BubbleSort<double>());
            arr1.ShowList();
            arr2.ShowList();

            Console.ReadLine();
        }
    }
}
