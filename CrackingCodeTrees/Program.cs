using System;
using System.ComponentModel.DataAnnotations;

namespace CrackingCodeTrees
{
    class Program
    {
        // A utility function to get 
        // maximum of two integers  
        public static int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        public static Node LeftRotate(Node x)
        {
            Node y = x.right;
            Node T2 = y.left;

            // Perform rotation  
            y.left = x;
            x.right = T2;

            // Update heights  
            x.height = Max(Height(x.left),
                        Height(x.right)) + 1;
            y.height = Max(Height(y.left),
                        Height(y.right)) + 1;

            // Return new root  
            return y;
        }

        public static int Height(Node node)
        {
            if (node == null)
                return 0;

            return node.height;
        }

        public static int Balance(Node node)
        {
            if (node == null)
                return 0;

            return Height(node.left) - Height(node.right);
        }

        public static Node RightRotate(Node y)
        {
            Node x = y.left;
            Node T2 = x.right;

            // Perform rotation  
            x.right = y;
            y.left = T2;

            // Update heights  
            y.height = Max(Height(y.left),
                        Height(y.right)) + 1;
            x.height = Max(Height(x.left),
                        Height(x.right)) + 1;

            // Return new root  
            return x;
        }

        public static Node CreateAVLTree(Node node,int key)
        {
            /* 1. Perform the normal BST insertion */
            if (node == null)
                return (new Node(key));

            if (key < node.data)
                node.left = CreateAVLTree(node.left, key);
            else if (key > node.data)
                node.right = CreateAVLTree(node.right, key);
            else // Duplicate keys not allowed  
                return node;

            /* 2. Update height of this ancestor node */
            node.height = 1 + Max(Height(node.left),
                                Height(node.right));

            /* 3. Get the balance factor of this ancestor  
                node to check whether this node became  
                unbalanced */
            int balance = Balance(node);

            // If this node becomes unbalanced, then there  
            // are 4 cases Left Left Case  
            if (balance > 1 && key < node.left.data)
                return RightRotate(node);

            // Right Right Case  
            if (balance < -1 && key > node.right.data)
                return LeftRotate(node);

            // Left Right Case  
            if (balance > 1 && key > node.left.data)
            {
                node.left = LeftRotate(node.left);
                return RightRotate(node);
            }

            // Right Left Case  
            if (balance < -1 && key < node.right.data)
            {
                node.right = RightRotate(node.right);
                return LeftRotate(node);
            }

            /* return the (unchanged) node pointer */
            return node;
        }


        public static Node SearchBST(Node root,int key)
        {
            if (root == null)
                return null;

            if (key < root.data)
                SearchBST(root.left,key);

            else if (key > root.data)
                SearchBST(root.right,key);

            if (key == root.data)
                return root;

            return null;

        }

        public static Node CreateBST(Node node, int key)
        {

            if (node == null)
                return new Node(key);

            if (node.data > key)
            {

                node.left = CreateBST(node.left, key);

            }
            else if (node.data  < key)
            {
                node.right =  CreateBST(node.right, key);

            }

            return node;
        }

        public class Node
        {
            public Node left;
            public Node right;
            public int data;

            public int height;

            public Node(int data)
            {
                this.data = data;
                this.height = 1;
            }


        }

        public static void InOrder(Node node)
        {
            if (node == null)
                return;

            InOrder(node.left);

            Console.WriteLine(node.data);

            InOrder(node.right);


        }

        public static void PreOrder(Node node)
        {
            if (node == null)
                return;

            Console.WriteLine(node.data);
            PreOrder(node.left);
            PreOrder(node.right);


        }

        public static void PostOrder(Node node)
        {
            if (node == null)
                return;

            PostOrder(node.left);
            PostOrder(node.right);
            Console.WriteLine(node.data);

        }

        static void Main(string[] args)
        {

            //Node root = new Node(1);

            //root.left = new Node(2);
            //root.right = new Node(3);
            //root.left.left = new Node(4);
            //root.left.right = new Node(5);
            //Console.WriteLine("--Inorder--");
            //InOrder(root);
            //Console.WriteLine("--Preorder--");
            //PreOrder(root);
            //Console.WriteLine("--Postorder--");
            //PostOrder(root);

            //Node root = null;
            //root = CreateBST(root,50);
            //CreateBST(root, 30);
            //CreateBST(root, 20);
            //CreateBST(root, 40);
            //CreateBST(root, 70);
            //CreateBST(root, 60);
            //CreateBST(root, 80);
            //InOrder(root);


            Node tree = null;

            /* Constructing tree given in the above figure */
            tree = CreateAVLTree(tree, 10);
            tree = CreateAVLTree(tree, 20);
            tree = CreateAVLTree(tree, 30);
            tree = CreateAVLTree(tree, 40);
            tree = CreateAVLTree(tree, 50);
            tree = CreateAVLTree(tree, 25);

            PreOrder(tree);

        }
    }
}
