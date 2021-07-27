using System;
using System.Collections.Generic;

namespace Sorting
{
    class InsertSort<T> : ISorting<T> where T : IComparable
    {
        public void Sort(ref IList<T> array)
        {
            for (int i = 0; i < array.Count - 1; i++)
            {
                var j = i + 1;
                while (j > 0 && array[j].CompareTo(array[j - 1]) < 0)
                {
                    array.Swap(j, j - 1);
                    j--;
                }
            }
        }
    }
}
