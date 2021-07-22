﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class BubbleSort<T> : ISorting<T> where T : IComparable
    {
        public void Sort(ref IList<T> array)
        {
            bool swapped = true;
            int i = 0;
            while (swapped)
            {
                swapped = false;
                for (int j = 0; j < array.Count - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j+1]) > 0)
                    {
                        array.Swap(j, j + 1);
                        swapped = true;
                    }
                }
                i++;
            }
        }
    }
}