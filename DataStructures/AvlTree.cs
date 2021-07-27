using System;

namespace DataStructures
{
    class AvlTree<T> : BinaryTree<T> where T : IComparable
    {
        protected override BinaryTreeNode<T> CreateNode(T val) => new AVLTreeNode<T>(val);
        protected override BinaryTreeNode<T> AddNode(BinaryTreeNode<T> node, BinaryTreeNode<T> newNode)
        {
            (newNode as AVLTreeNode<T>).Parent = node;
            var result = base.AddNode(node, newNode);
            return ChangeRoot(result, BalanceTree(result));
        }
        protected override BinaryTreeNode<T> RecursiveDelete(BinaryTreeNode<T> node, T key)
        {
            var result = base.RecursiveDelete(node, key) as AVLTreeNode<T>;
            UpdateChilds(result);
            return ChangeRoot(result, BalanceTree(result));
        }
        private BinaryTreeNode<T> BalanceTree(BinaryTreeNode<T> node)
        {
            var Avl = node as AVLTreeNode<T>;
            if (Avl.BalanceFactor > 1)
            {
                if (Avl.LeftAVL.BalanceFactor < 0)
                {
                    node.Right = RotateLeft(node.Right);
                }
                node = RotateRight(node);
            }
            if (Avl.BalanceFactor < -1)
            {
                if (Avl.RightAVL.BalanceFactor > 0)
                {
                    node.Left = RotateRight(node.Left);
                }
                node = RotateLeft(node);
            }

            return node;
        }
        private BinaryTreeNode<T> RotateRight(BinaryTreeNode<T> node)
        {
            var temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;
            (node as AVLTreeNode<T>).Parent = temp;
            (temp.Right as AVLTreeNode<T>).Parent = node;
            return temp;
        }
        private BinaryTreeNode<T> RotateLeft(BinaryTreeNode<T> node)
        {
            var temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;
            (node as AVLTreeNode<T>).Parent = temp;
            (temp.Left as AVLTreeNode<T>).Parent = node;
            return temp;
        }

        private BinaryTreeNode<T> ChangeRoot(BinaryTreeNode<T> node, BinaryTreeNode<T> newNode)
        {
            var avlnode = node as AVLTreeNode<T>;
            if (avlnode.Parent == null)
            {
                _root = node;
            }
            else
            {
                if (avlnode.Parent.Left == node)
                {
                    avlnode.Parent.Left = newNode;
                }
                else if (avlnode.Parent.Right == node)
                {
                    avlnode.Parent.Right = newNode;
                }
            }
            UpdateChilds(avlnode);
            return newNode;
        }
        private void UpdateChilds(BinaryTreeNode<T> node)
        {
            if (node is AVLTreeNode<T> parent)
            {
                if (parent.LeftAVL != null)
                {
                    parent.LeftAVL.Parent = parent;
                }
                if (parent.RightAVL != null)
                {
                    parent.RightAVL.Parent = parent;
                }
            }
        }
    }
}
