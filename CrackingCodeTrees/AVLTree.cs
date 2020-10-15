using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CrackingCodeTrees.Tree
{
    class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }

        public int Data { get; set; }
        public int Height { get; set; }

        public void PreOrder(Node node)
        {
            if (node == null)
                return;

            Console.WriteLine(node.Data);
            PreOrder(node.Left);
            PreOrder(node.Right);


        }


        public Node(int data)
        {
            Data = data;
            Height = 1;

        }

        private int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        private int GetHeight(Node node)
        {
            if (node == null)
                return 0;

            return node.Height;
        }

        public int Balance(Node node)
        {
            if (node == null)
                return 0;

            return GetHeight(node.Left) - GetHeight(node.Right);
        }

        public Node RotateLeft(Node node)
        {

            var n1 = node.Right;
            var n2 = n1.Left;


            n1.Left = node;
            node.Right = n2;

            node.Height = Max(GetHeight(node.Left),
                        GetHeight(node.Right)) + 1;

            n1.Height = Max(GetHeight(n1.Left),
                        GetHeight(n1.Right)) + 1;

            return n1;

        }

        public Node RotateRight(Node node)
        {

            var n1 = node.Left;
            var n2 = n1.Right;

            n1.Right = node;
            node.Left = n2;
  

            node.Height = Max(GetHeight(node.Left),
                       GetHeight(node.Right)) + 1;
            n1.Height = Max(GetHeight(n1.Left),
                  GetHeight(n1.Right)) + 1;

            return n1;

        }


        public Node Insert(Node node, int key)
        {
            if (node == null)
                return new Node(key);

            if (key < node.Data)
                node.Left = Insert(node.Left, key);
            else if (key > node.Data)
                node.Right = Insert(node.Right, key);
            else
                return node;

            node.Height = 1 + Max(GetHeight(node.Right), GetHeight(node.Left));

            int bal = Balance(node);

            //Left Left Case
            if (bal > 1 && key < node.Left.Data)
            {
                return RotateRight(node);
            }

            //right right case
            if (bal < -1 && key > node.Right.Data)
            {
                return RotateLeft(node);
            }

            //Left Right Case
            if (bal > 1 && key > node.Left.Data)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);

            }

            //Right left case
            if (bal < -1 && key < node.Right.Data)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);

            }
            return node;
        }

    }

}
