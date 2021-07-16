using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BinaryTree<T> where T : IComparable
    { 
        private int _count;
        private BinaryTreeNode<T> _root;

        public int Count => _count;

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
        public void Clear()
        {
            _root = null;
            _count = 0;
        }
        private void AddNode(BinaryTreeNode<T> node, T value)
        {
            if (node.Value.CompareTo(value) > 0)
            {
                if(node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddNode(node.Left, value);
                }
            }
            if(node.Value.CompareTo(value) < 0)
            {
                if(node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddNode(node.Right, value);
                }
            }
        }
        public List<T> InfixTraverse()
        {
            List<T> result = new List<T>(Count);
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
                        if (current.Left == null)
                        {
                            goLeft = false;
                        }
                        else
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }
                    else
                    {
                        result.Add(current.Value);
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
            return result;
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
    }
}
