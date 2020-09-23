using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.InteropServices;

namespace Mirror_Of_a_BInary_Tree
{
    class Program
    {
        class Node
        {
            public int value;
            public Node left, right;
            public Node(int value)
            {
                this.value = value;
                left = right = null;
            }
        }

        static void Main(string[] args)
        {
            Node root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(5);
            root.right.left = new Node(6);
            root.right.right = new Node(7);
            //Mirror(root);
            Mirror_Impl_Queue(root);
            Print(root);
        }

        /// <summary>
        /// recursive Implementation
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        static Node Mirror(Node root)
        {
            if (root == null) return root;

            Node left = Mirror(root.left);
            Node right = Mirror(root.right);

            root.left = right;
            root.right = left;
            return root;
        }

        static void Mirror_Impl_Queue(Node root)
        {
            if (root == null) return;

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while(q.Count > 0)
            {
                Node node = q.Dequeue();
                // SWAP left and right and then push inside Queue
                Node temp = node.left;
                node.left = node.right;
                node.right = temp;

                if (node.left != null) q.Enqueue(node.left);
                if (node.right != null) q.Enqueue(node.right);
            }
        }

        /// <summary>
        /// Print nodes in Inorder.
        /// </summary>
        /// <param name="root"></param>
        static void Print(Node root)
        {
            if (root == null) return;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                Node node = queue.Dequeue();
                Console.WriteLine(node?.value);
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
        }
    }
}
