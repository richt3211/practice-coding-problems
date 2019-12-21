using System;

namespace largest_bst_branch
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTest(new long[]{3,6,2,9,-1,10});
            RunTest(new long[]{1,4,100,5});
            RunTest(new long[]{1,10,5,1,0,69});
            RunTest(new long[]{1});

        }

        static void RunTest(long[] arr)
        {
            Console.WriteLine("Running test: " + arr.ToString());
            string result = Solution(arr);
            Console.WriteLine(result);
        }
        
        static string Solution(long[] arr)
        {
            if (arr.Length == 0)
            {
                return "";
            }
            BinaryTree bt = new BinaryTree(arr[0]);
            for (int i = 1; i < arr.Length; i++)
            {
                bt.AddNode(arr[i]);
            }
            long sumLeft = bt.SumLeft();
            long sumRight = bt.SumRight();
            if (sumLeft == sumRight)
                return "";
            else if (sumLeft > sumRight)
                return "Left";
            else 
                return "Right";

        }
    }

    class BinaryTree
    {
        Node root;
        public BinaryTree(long value)
        {
            root = new Node(null, null, value);
            // AddNode(root, value);
        }

        public void AddNode(long value)
        {
            AddNode(root, value);
        }

        public void AddNode(Node node, long value)
        {
            if (node.value == -1)
                return;
            if (node.Left == null)
            {
                node.Left = new Node(null, null, value);
            }
            else if (node.Right == null)
            {
                node.Right = new Node(null, null, value);
            }
            else 
            {
                if (node.Left.Left == null || node.Left.Right == null)
                {
                    AddNode(node.Left, value);
                }
                else if (node.Right.Left == null || node.Right.Right == null)
                {
                    AddNode(node.Right, value);
                }
                else 
                {
                    AddNode(node.Left, value);
                }
            }
        }

        public long SumLeft()
        {
            if (root.Left != null)
            {
                return Sum(root.Left);
            }
            else return 0;
        }
        
        public long SumRight()
        {
            if (root.Right != null)
            {
                return Sum(root.Right);
            }
            else return 0;
        }

        public long Sum(Node node)
        {
            if (node.value == -1)
                return 0;
            long sum = node.value;
            if (node.Left != null)
            {
                sum += Sum(node.Left);
            }
            if (node.Right != null)
            {
                sum += Sum(node.Right);
            }
            return sum;
        }

    }

    class Node
    {
        public Node(Node left, Node right, long _value)
        {
            Left = left;
            Right = right;
            value = _value;
        }
        public Node Left;
        public Node Right;
        public long value;
    }
}
