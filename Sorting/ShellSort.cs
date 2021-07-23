using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class ShellSort<T> : ISorting<T> where T : IComparable
    {
        public void Sort(ref IList<T> array)
        {
            for (int step = array.Count / 2; step > 0; step /= 2)
            {
                for (int i = 0; i < array.Count; i += step)
                {
                    var min = i;
                    for (int j = i+=step; j < array.Count; j += step)
                    {
                        if (array[i].CompareTo(array[j]) > 0)
                        {
                            min = j;
                        }
                    }
                    array.Swap(i, min);
                }
            }
        }
    }
}