using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class BinaryTreeNode<T> where T : IComparable
    {
        private T _value;
        private BinaryTreeNode<T> _left;
        private BinaryTreeNode<T> _right;

        public T Value => _value;
        public BinaryTreeNode<T> Left

        {
            get => _left;
            internal set => _left = value;
        }
        public BinaryTreeNode<T> Right
        {
            get => _right;
            internal set => _right = value;
        }

        public BinaryTreeNode(T value)
        {
            _value = value;
        }
    }
}
