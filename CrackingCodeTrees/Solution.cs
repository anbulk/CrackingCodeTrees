using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;

namespace CrackingCodeTrees
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int data)
        {
            this.data = data;
        }

    }

    public class Solution
    {
        #region Problem No. 1 
        //Check if a binary tree is balanced
        //height difference between the left and right subtree is not more than 1.

        public int GetHeightOfTree(Node node)
        {
            if (node == null)
                return 0;

            return Math.Max(GetHeightOfTree(node.left), GetHeightOfTree(node.right)) + 1;

        }

        //O(n log n )
        public bool IsBalanced(Node node)
        {
            if (node == null)
                return true;

            var diff = Math.Abs(GetHeightOfTree(node.left) - GetHeightOfTree(node.right));

            if (diff > 1)
                return false;
            else
            {
                return IsBalanced(node.left) && IsBalanced(node.right);
            }
        }

        //Optimized

        //-1 means not balanced else balanced. O(n) - n is the hright of the tree
        public int CheckHeight(Node node)
        {

            if (node == null)
                return 0;


            int lheight = CheckHeight(node.left);

            if (lheight == -1)
                return -1;

            int rheight = CheckHeight(node.right);

            if (rheight == -1)
                return -1;


            int diff = Math.Abs(lheight - rheight);

            if (diff > 1)
                return -1;
            else
                return Math.Max(lheight, rheight) + 1;
        }


        #endregion


        #region Problem 3
        //sorted array increasing order
        //create a BST minimal height 


        public Node MakeTree(int[] arr, int start, int end)
        {
            if (start > end)
                return null;

            int mid = (start + end) / 2;

            Node n = new Node(arr[mid]);

            n.left = MakeTree(arr, start, mid - 1);
            n.right = MakeTree(arr, mid + 1, end);

            return n;
        }

        #endregion


        #region Problem 4
        //Create linked lists for all depths of a tree

        List<LinkedList<Node>> list = new List<LinkedList<Node>>();

        public void CreateList(Node node,int level)
        {
            if (node == null)
                return;

            var lnode = list[level];
            if (lnode == null)
            {
                var root = new LinkedList<Node>();
                root.AddLast(node);
                list.Add(root);
            }
            else
                list[level].AddLast(node);


            CreateList(node.left, level + 1);
            CreateList(node.right, level + 1);
        }
        #endregion


    }
}
