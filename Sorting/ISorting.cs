using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public interface ISorting<T> 
    {
        void Sort(ref IList<T> array);
    }
}
