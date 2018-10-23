using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    public class BinaryTree
    {
        private Node root;
        private int count;

        public BinaryTree()
        {
            root = null;
            count = 0;
        }
        public bool IsEmpty()
        {
            return root == null;
        }

        public void Insert(int d, string r)
        {
            if (IsEmpty())
            {
                root = new Node(d, r);
            }
            else
            {
                root.InsertData(ref root, d, r);
            }

            count++;
        }

        public string Search(int s)
        {
            return root.Search(root, s);
        }

        public bool IsLeaf()
        {
            if (!IsEmpty())
                return root.IsLeaf(ref root);

            return true;
        }

        public void Display()
        {
            if (!IsEmpty())
                root.Display(root);
        }

        public int Count()
        {
            return count;
        }
    }
}
