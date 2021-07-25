using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BinaryTreeNode<T> where T : IComparable
    {
        public T Value;
        internal BinaryTreeNode<T> Left;
        internal BinaryTreeNode<T> Right;
        internal BinaryTreeNode(T value)
        {
            Value = value;
        }
    }
}
