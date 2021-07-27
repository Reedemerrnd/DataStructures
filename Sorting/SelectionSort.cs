using System;
using System.Collections.Generic;

namespace Sorting
{
    class SelectionSort<T> : ISorting<T> where T : IComparable
    {
        public void Sort(ref IList<T> array)
        {
            for (int i = 0; i < array.Count; i++)
            {
                var min = i;
                for (int j = i + 1; j < array.Count; j++)
                {
                    if (array[min].CompareTo(array[j]) > 0)
                    {
                        min = j;
                    }
                }
                array.Swap(min, i);
            }
        }
    }
}
