using System;

namespace DataStructures
{
    class AVLTreeNode<T> : BinaryTreeNode<T> where T : IComparable
    {
        internal AVLTreeNode<T> LeftAVL => base.Left as AVLTreeNode<T>;
        internal AVLTreeNode<T> RightAVL => base.Right as AVLTreeNode<T>;
        internal BinaryTreeNode<T> Parent { get; set; }

        internal int Height => FixHeight();

        internal int BalanceFactor => NodeHeigth(LeftAVL) - NodeHeigth(RightAVL);

        public AVLTreeNode(T value) : base(value)
        {
        }

        internal int FixHeight()
        {
            var left = NodeHeigth(LeftAVL);
            var right = NodeHeigth(RightAVL);
            return (left > right ? left : right) + 1;
        }
        private int NodeHeigth(AVLTreeNode<T> node) => node != null ? node.Height : 0;
    }
}
