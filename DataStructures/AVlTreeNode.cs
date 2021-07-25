using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class AVLTreeNode<T> : BinaryTreeNode<T> where T : IComparable
    {
        internal AVLTreeNode<T> LeftAVL => base.Left as AVLTreeNode<T>;

        internal AVLTreeNode<T> RightAVL => base.Right as AVLTreeNode<T>;

        internal int Height => FixHeight();

        private int _height;
        internal int BalanceFactor => NodeHeigth(LeftAVL) - NodeHeigth(RightAVL);

        public AVLTreeNode(T value) : base(value)
        {
            _height = 1;
        }

        internal int FixHeight()
        {
            var left = NodeHeigth(LeftAVL);
            var right = NodeHeigth(RightAVL);
            return (left > right ? left : right) + 1;
        }
        private int NodeHeigth(AVLTreeNode<T> node)
        {
            return node != null ? node.Height : 0;
        }
    }
}
