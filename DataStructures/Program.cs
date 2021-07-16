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
            var Tree = new BinaryTree<int>();
            Tree.Add(15);
            Tree.Add(8);
            Tree.Add(20);
            Tree.Add(18);
            Tree.Add(1);
            Tree.Add(30);
            Tree.Add(25);
            Tree.Add(14);

            Console.WriteLine(Tree.Contains(25));
            Console.WriteLine(Tree.Contains(26));
            Console.WriteLine(Tree.Count);
            Console.WriteLine();
            foreach (var item in Tree.InfixTraverse())
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
