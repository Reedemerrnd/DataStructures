using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class BinaryTree<T> : IEnumerable<BinaryTreeNode<T>> where T : IComparable
    {
        protected int _count;
        private protected BinaryTreeNode<T> _root;

        public int Count => _count;
        public T Min => Minimum(_root).Value;
        public T Max => Maximum(_root).Value;

        public bool Add(T value)
        {
            if (Contains(value))
            {
                return false;
            }

            var node = CreateNode(value);
            if (_root == null)
            {
                _root = node;
            }
            else
            {
                AddNode(_root, node);
            }
            _count++;
            return true;
        }
        protected virtual BinaryTreeNode<T> CreateNode(T val) => new BinaryTreeNode<T>(val);
        protected virtual BinaryTreeNode<T> AddNode(BinaryTreeNode<T> node, BinaryTreeNode<T> newNode)
        {
            if (node.Value.CompareTo(newNode.Value) > 0)
            {
                if (node.Left == null)
                {
                    node.Left = newNode;
                }
                else
                {
                    AddNode(node.Left, newNode);
                }
            }
            if (node.Value.CompareTo(newNode.Value) < 0)
            {
                if (node.Right == null)
                {
                    node.Right = newNode;
                }
                else
                {
                    AddNode(node.Right, newNode);
                }
            }
            return node;
        }

        public bool Contains(T value)
        {
            if (Search(value) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected BinaryTreeNode<T> Minimum(BinaryTreeNode<T> node) => node.Left == null ? node : Minimum(node.Left);
        protected BinaryTreeNode<T> Maximum(BinaryTreeNode<T> node) => node.Right == null ? node : Maximum(node.Right);
        public void Clear()
        {
            _root = null;
            _count = 0;
        }
        public List<T> ToListInorder()
        {
            var result = new List<T>(Count);
            InorderTraverse(_root, ref result);
            return result;
        }
        protected void InorderTraverse(BinaryTreeNode<T> node, ref List<T> list)
        {
            if (node != null)
            {
                InorderTraverse(node.Left, ref list);
                list.Add(node.Value);
                InorderTraverse(node.Right, ref list);
            }
        }

        public List<T> ToListPostorder()
        {
            var result = new List<T>(Count);
            PostorderTraverse(_root, ref result);
            return result;
        }
        protected void PostorderTraverse(BinaryTreeNode<T> node, ref List<T> list)
        {
            if (node != null)
            {
                PostorderTraverse(node.Left, ref list);
                PostorderTraverse(node.Right, ref list);
                list.Add(node.Value);
            }
        }

        public List<T> ToListPreorder()
        {
            var result = new List<T>(Count);
            PreorderTraverse(_root, ref result);
            return result;
        }
        protected void PreorderTraverse(BinaryTreeNode<T> node, ref List<T> list)
        {
            if (node != null)
            {
                list.Add(node.Value);
                PreorderTraverse(node.Left, ref list);
                PreorderTraverse(node.Right, ref list);
            }
        }

        public bool Delete(T key) => RecursiveDelete(_root, key) != null;
        protected virtual BinaryTreeNode<T> RecursiveDelete(BinaryTreeNode<T> node, T key)
        {
            if (node == null)
            {
                return node;
            }
            var compareKey = node.Value.CompareTo(key);
            if (compareKey > 0)
            {
                node.Left = RecursiveDelete(node.Left, key);
            }
            else if (compareKey < 0)
            {
                node.Right = RecursiveDelete(node.Right, key);
            }
            else
            {
                if (node.Left != null && node.Right != null)
                {
                    var replacement = Minimum(node.Right);
                    node.Value = replacement.Value;
                    RecursiveDelete(node.Right, replacement.Value);
                }
                else if (node.Left != null)
                {
                    node = node.Left;
                }
                else if (node.Right != null)
                {
                    node = node.Right;
                }
                else
                {
                    node = null;
                }
            }
            return node;
        }

        private protected BinaryTreeNode<T> Search(T value)
        {
            var current = _root;
            while (current != null)
            {
                var comparer = current.Value.CompareTo(value);
                if (comparer == 0)
                {
                    return current;
                }

                if (comparer > 0)
                {
                    current = current.Left;
                }

                if (comparer < 0)
                {
                    current = current.Right;
                }
            }
            return null;
        }
        private protected BinaryTreeNode<T> Search(T value, out BinaryTreeNode<T> parent)
        {
            parent = null;
            var current = _root;
            while (current != null)
            {
                var comparer = current.Value.CompareTo(value);
                if (comparer != 0)
                {
                    if (comparer > 0)
                    {
                        parent = current;
                        current = current.Left;
                    }
                    if (comparer < 0)
                    {
                        parent = current;
                        current = current.Right;
                    }
                }
                else
                {
                    return current;
                }
            }
            return null;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<BinaryTreeNode<T>> GetEnumerator() => InorderEnumerator();
        private protected IEnumerator<BinaryTreeNode<T>> InorderEnumerator()
        {
            if (_root != null)
            {
                var stack = new Stack<BinaryTreeNode<T>>();
                var goLeft = true;

                stack.Push(_root);
                var current = stack.Peek();
                while (stack.Count > 0)
                {

                    if (goLeft)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }
                    goLeft = false;

                    yield return current;
                    if (current.Right != null)
                    {
                        current = current.Right;
                        goLeft = true;
                    }
                    else
                    {
                        current = stack.Pop();

                    }

                }
            }
        }
    }
}
