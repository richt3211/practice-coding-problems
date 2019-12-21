using System;

namespace same_tree_copy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TreeNode p = new TreeNode(1);
            p.left = null;
            p.right = new TreeNode(1);

            TreeNode q = new TreeNode(1);
            q.left = null;
            q.right = new TreeNode(1);


            Console.WriteLine(IsSameTree(p,q));
        }
        public class TreeNode 
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public static bool IsSameTree(TreeNode p, TreeNode q) 
        {
            if ( !IsSameStructure(p, q) ) 
            {
                Console.WriteLine("tree isn't same structure");
                return false;
            }
            if ( p == null && q == null) 
            {
                return true;
            }
            if ( (p.val != q.val) ) 
            {
                Console.WriteLine("Doesn't have same value");
                return false;
            }
            bool left, right;
            if (IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right)) 
            {
                Console.WriteLine("tree "); 
                return true;
            }
            else 
            {
                return false;
            }
        }
    
        public static bool IsSameStructure(TreeNode p, TreeNode q) 
        {
            bool left;
            bool right;
            if ( p == null && q == null) 
            {
                return true;
            }
            else if ( (p == null && q != null) || (p != null && q == null) ) 
            {
                return false;
            }
            if ( (p.left == null && q.left == null ) || (p.left != null && p.right != null) ) 
            {
                left = true;
            } 
            else 
            {
                left = false;
            }
            if ( (p.right == null && q.right == null ) || (p.left != null && p.right != null) ) 
            {
                right = true;
            }
            else 
            {
                right = false;
            }
            return left && right;
        }
    }
}
