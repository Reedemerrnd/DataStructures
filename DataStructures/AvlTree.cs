using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class AvlTree<T> : BinaryTree<T> where T : IComparable
    {
        protected override BinaryTreeNode<T> CreateNode(T val)
        {
            return new AVLTreeNode<T>(val);
        }
        protected override BinaryTreeNode<T> AddNode(BinaryTreeNode<T> node, BinaryTreeNode<T> newNode)
        {
            var result = base.AddNode(node, newNode);
            return BalanceTree(ref result);
        }
        protected override BinaryTreeNode<T> RecursiveDelete(BinaryTreeNode<T> node, T key)
        {
            var result = base.RecursiveDelete(node, key);
            return BalanceTree(ref result);
        }
        private BinaryTreeNode<T> BalanceTree(ref BinaryTreeNode<T> node)
        {
            var Avl = node as AVLTreeNode<T>;
            if (Avl.BalanceFactor > 1)
            {
                if (Avl.LeftAVL.BalanceFactor < 0)
                {
                    node.Right = RotateLeft(ref node.Right);
                }
                node = RotateRight(ref node);
            }
            if(Avl.BalanceFactor < -1)
            {
                if(Avl.RightAVL.BalanceFactor > 0)
                {
                    node.Left = RotateRight(ref node.Left);
                }
                node = RotateLeft(ref node);
            }
            return node;
        }
        private BinaryTreeNode<T> RotateRight (ref BinaryTreeNode<T> node)
        {
            var temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;
            return temp;
        }
        private BinaryTreeNode<T> RotateLeft(ref BinaryTreeNode<T> node)
        {
            var temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;
            return temp;
        }
    }
}
