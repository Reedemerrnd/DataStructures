using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal sealed class AVlTreeNode<T> where T : IComparable
    {
        internal T Value;
        internal AVlTreeNode<T> Left;
        internal AVlTreeNode<T> Right;
        internal int BalanceFactor
        {
            get
            {
                if(Left == null && Right == null)
                {
                    return 0;
                }
                else
                {
                    return Math.Max(Left.BalanceFactor, Right.BalanceFactor);
                }
            }
        }

        internal AVlTreeNode(T value)
        {
            Value = value; 
        }
    }
}
