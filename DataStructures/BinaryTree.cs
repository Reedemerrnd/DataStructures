using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable
    { 
        private int _count;
        private BinaryTreeNode<T> _root;

        public int Count => _count;
        public T Min => Minimum(_root).Value;
        public T Max => Maximum(_root).Value;

        public bool Add(T node)
        {
            if (Contains(node))
            {
                return false;
            }
            if (_root == null)
            {
                _root = new BinaryTreeNode<T>(node);
            }
            else
            {
                AddNode(_root, node);
            }
            _count++;
            return true;
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
        private BinaryTreeNode<T> Minimum(BinaryTreeNode<T> node) => node.Left == null ? node : Minimum(node.Left);
        private BinaryTreeNode<T> Maximum(BinaryTreeNode<T> node) => node.Right == null ? node : Maximum(node.Right);
        public void Clear()
        {
            _root = null;
            _count = 0;
        }
        public List<T> ToListInorder()
        {
            List<T> result = new List<T>(Count);
            InorderTraverse(_root, ref result);
            return result;
        }
        private void InorderTraverse(BinaryTreeNode<T> node,ref List<T> list)
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
            List<T> result = new List<T>(Count);
            PostorderTraverse(_root, ref result);
            return result;
        }
        private void PostorderTraverse(BinaryTreeNode<T> node, ref List<T> list)
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
            List<T> result = new List<T>(Count);
            PreorderTraverse(_root, ref result);
            return result;
        }
        private void PreorderTraverse(BinaryTreeNode<T> node, ref List<T> list)
        {
            if (node != null)
            {
                list.Add(node.Value);
                PreorderTraverse(node.Left, ref list);
                PreorderTraverse(node.Right, ref list);
            }
        }

        private void AddNode(BinaryTreeNode<T> node, T value)
        {
            if (node.Value.CompareTo(value) > 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddNode(node.Left, value);
                }
            }
            if (node.Value.CompareTo(value) < 0)
            {
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddNode(node.Right, value);
                }
            }
        }

        public bool Delete(T key) =>  RecursiveDelete(_root, key) != null ? true : false;

        private BinaryTreeNode<T> RecursiveDelete(BinaryTreeNode<T> node, T key)
        {
            if (node == null)
            {
                return node;
            }
            var compareKey = node.Value.CompareTo(key);
            if(compareKey > 0)
            {
                node.Left = RecursiveDelete(node.Left, key);
            }
            else if (compareKey < 0)
            {
                node.Right = RecursiveDelete(node.Right,  key);
            }
            else
            {
                if(node.Left != null && node.Right != null)
                {
                    var replacement = Minimum(node.Right);
                    node.Value = replacement.Value;
                    RecursiveDelete(node.Right, replacement.Value);
                }
                else if(node.Left != null)
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
        private bool DeleteNode(T value)
        {
            BinaryTreeNode<T> parent;
            var node = Search(value, out parent);
            var compareResult = parent.Value.CompareTo(node.Value);
            if (node != null)
            {

                if (node.Left == null && node.Right == null)
                {
                    if(compareResult > 0)
                    {
                        parent.Left = null;
                    }
                    else
                    {
                        parent.Right = null;
                    }
                }
                else if (node.Left != null && node.Right == null)
                {
                    if(compareResult > 0)
                    {
                        parent.Left = node.Left;
                    }
                    else
                    {
                        parent.Right = node.Left;
                    }
                }
                else if (node.Left == null && node.Right != null)
                {
                    if (compareResult > 0)
                    {
                        parent.Left = node.Right;
                    }
                    else
                    {
                        parent.Right = node.Right;
                    }
                }
                else
                {
                    var replacement = Minimum(node.Right);
                    DeleteNode(replacement.Value);
                    replacement.Left = node.Left;
                    replacement.Right = node.Right;
                    if (compareResult > 0)
                    {
                        parent.Left = replacement;
                    }
                    else
                    {
                        parent.Right = replacement;
                    }
                }
                _count--;
                return true;
            }
            return false;
        }

        private BinaryTreeNode<T> Search(T value)
        {
            var current = _root;
            while (current != null)
            {
                var comparer = current.Value.CompareTo(value);
                if (comparer == 0)
                {
                    return current;
                }
                if(comparer > 0)
                {
                    current = current.Left;
                }
                if(comparer < 0)
                {
                    current = current.Right;
                }
            }
            return null;
        }
        private BinaryTreeNode<T> Search(T value, out BinaryTreeNode<T> parent)
        {
            parent = null;
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
                    parent = current;
                    current = current.Left;
                }
                if (comparer < 0)
                {
                    parent = current;
                    current = current.Right;
                }
            }
            return null;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<T> GetEnumerator()
        {
            return InorderEnumerator();
        }
        private IEnumerator<T> InorderEnumerator()
        {
            if (_root != null)
            {
                Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
                bool goLeft = true;

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

                    yield return current.Value;
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
