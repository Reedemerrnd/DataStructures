using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var Tree = new AvlTree<int>();
            Tree.Add(15);
            Tree.Add(8);
            Tree.Add(20);
            Tree.Add(18);
            Tree.Add(1);
            Tree.Add(30);
            Tree.Add(25);
            Tree.Add(14);
            Tree.Add(12);
            Tree.Add(10);
            Console.WriteLine();
            foreach (var item in Tree.ToListPreorder())
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            foreach (var item in Tree.ToListInorder())
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            //Console.WriteLine(Tree.Delete(15));
            Console.WriteLine(Tree.Delete(30));

            //foreach (var item in Tree.ToListPostorder())
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            foreach (var item in Tree.ToListPreorder())
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            foreach (var item in Tree)
            {
                Console.Write((item as AVLTreeNode<int>).BalanceFactor + " ");
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
