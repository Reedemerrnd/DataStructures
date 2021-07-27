using System.Collections.Generic;

namespace Sorting
{
    public interface ISorting<T>
    {
        void Sort(ref IList<T> array);
    }
}
