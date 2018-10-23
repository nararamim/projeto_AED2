using System;

namespace BinarySearchTree
{
    class Program
    {
        public static void Main(string[] args)
        {
            BinaryTree b = new BinaryTree();

            b.Insert(1, "repos1.txt");
            b.Insert(6, "repos2.txt");
            b.Insert(2, "repos3.txt");
            b.Insert(4, "repos4.txt");
            b.Insert(5, "repos5.txt");
            b.Insert(3, "repos6.txt");
            b.Insert(798, "repos7.txt");
            b.Insert(998, "repos8.txt");
            b.Insert(0, "repos9.txt");
            b.Insert(75, "repos10.txt");
            b.Insert(56, "repos11.txt");
            b.Insert(98790, "repos12.txt");

            b.Display();

            Console.WriteLine("Insert requested element:");
            int element = int.Parse(Console.ReadLine());

            string result = b.Search(element);

            Console.WriteLine("The repository of the requeste element is:");
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
