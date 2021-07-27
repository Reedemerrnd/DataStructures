using System;
using System.Collections.Generic;

namespace Sorting
{
    public static class SortExtension
    {
        internal static IList<T> Swap<T>(this IList<T> coll, int first, int second)
        {
            var temp = coll[first];
            coll[first] = coll[second];
            coll[second] = temp;
            return coll;
        }

        public static IList<T> SortBy<T>(this IList<T> coll, ISorting<T> sortingType)
        {
            sortingType.Sort(ref coll);
            return coll;
        }
        public static void ShowList<T>(this IList<T> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
