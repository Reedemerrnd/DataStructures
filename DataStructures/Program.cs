using System;

namespace DataStructures
{
    class Program
    {
        static void Main()
        {
            var Tree = new AvlTree<int>
            {
                15,
                8,
                20,
                18,
                1,
                30,
                25,
                14,
                12,
                10
            };
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
