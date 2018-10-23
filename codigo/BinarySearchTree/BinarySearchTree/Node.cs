using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    public class Node
    {
        private int number;
        private string repository;
        public Node rightLeaf;
        public Node leftLeaf;

        public Node(int value, string repos)
        {
            number = value;
            repository = repos;
            rightLeaf = null;
            leftLeaf = null;
        }

        public bool IsLeaf(ref Node node)
        {
            return (node.rightLeaf == null && node.leftLeaf == null);

        }

        public void InsertData(ref Node node, int data, string r)
        {
            if (node == null)
            {
                node = new Node(data, r);
            }
            else if (node.number < data)
            {
                InsertData(ref node.rightLeaf, data, r);
            }

            else if (node.number > data)
            {
                InsertData(ref node.leftLeaf, data, r);
            }
        }

        public string Search(Node node, int s)
        {
            if (node == null)
                return "Node not found";

            if (node.number == s)
            {
                return node.repository;
            }
            else if (node.number < s)
            {
                return Search(node.rightLeaf, s);
            }
            else if (node.number > s)
            {
                return Search(node.leftLeaf, s);
            }

            return "Nil";
        }

        public void Display(Node n)
        {
            if (n == null)
                return;

            Display(n.leftLeaf);
            Console.WriteLine(" " + n.number + " " + n.repository);
            Display(n.rightLeaf);
        }
    }
}
