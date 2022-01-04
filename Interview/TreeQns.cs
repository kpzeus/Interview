using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class TreeQns
    {
        public static bool IsTreePossible(string[] strArr)
        {
            TreeNode root = null;

            if (strArr == null)
                return false;

            foreach(var pair in strArr)
            {
                var val = pair.Replace("(", "").Replace(")", "");
                var node1 = Convert.ToInt32(val.Split(',')[0]);
                var node2 = Convert.ToInt32(val.Split(',')[1]);

                if(root == null)
                {
                    root = new TreeNode(node1);
                }

                var n = Find(root, node1);

                if (n == null)
                    return false;

                if (n == root)
                {
                    var newRoot = new TreeNode(node2);

                    if (node1 < node2)
                        newRoot.left = root;
                    else
                        newRoot.right = root;

                    root = newRoot;
                }
            }

            return true;
        }

        public static TreeNode Find(TreeNode root, int val)
        {
            if (root == null)
                return null;

            if(root.val == val)
            {
                return root;
            }

            var l = Find(root.left, val);
            if (l != null)
                return l;

            var r = Find(root.left, val);
            if (r != null)
                return r;

            return null;
        }

        public static void LevelOrder(Node root)
        {
            if (root == null)
                return;

            Queue<Node> q1 = new Queue<Node>();
            Queue<Node> q2 = new Queue<Node>();
            q1.Enqueue(root);

            while (q1.Count > 0)
            {
                var x = q1.Dequeue();
                Console.Write(x.val + " ");
                if (x.left != null)
                    q2.Enqueue(x.left);
                if (x.right != null)
                    q2.Enqueue(x.right);

                if(q1.Count == 0)
                {
                    var t = q1;
                    q1 = q2;
                    q2 = t;
                    Console.WriteLine();
                }
            }
        }

        public static Node Connect(Node root)
        {
            if (root == null)
                return root;

            Queue<Tuple<Node, int>> queue = new Queue<Tuple<Node, int>>();
            queue.Enqueue(new Tuple<Node, int>(root, 0));

            Dictionary<int, Node> lRef = new Dictionary<int, Node>();

            while (queue.Count != 0)
            {
                Tuple<Node, int> tempNode = queue.Dequeue();
                Console.Write(tempNode.Item1.val + " ");
                int l = tempNode.Item2;

                /*Enqueue left child */
                if (tempNode.Item1.left != null)
                {
                    queue.Enqueue(new Tuple<Node, int>(tempNode.Item1.left, l + 1));
                    if (!lRef.ContainsKey(l + 1))
                    {
                        lRef.Add(l + 1, tempNode.Item1.left);
                    }
                    else
                    {
                        lRef[l + 1].next = tempNode.Item1.left;
                        lRef[l + 1] = tempNode.Item1.left;
                    }
                }

                /*Enqueue right child */
                if (tempNode.Item1.right != null)
                {
                    queue.Enqueue(new Tuple<Node, int>(tempNode.Item1.right, l + 1));
                    if (!lRef.ContainsKey(l + 1))
                    {
                        lRef.Add(l + 1, tempNode.Item1.right);
                    }
                    else
                    {
                        lRef[l + 1].next = tempNode.Item1.right;
                        lRef[l + 1] = tempNode.Item1.right;
                    }
                }
            }

            return root;
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return root;

            if (root == p || root == q)
                return root;

            var l = LowestCommonAncestor(root.left, p, q);
            var r = LowestCommonAncestor(root.right, p, q);

            if (l != null && r != null)
            {
                return root;
            }

            if (l != null)
                return l;

            if (r != null)
                return r;

            return null;
        }

        public static bool isBST(TreeNode root)
        {
            return isBST(root, int.MinValue, int.MaxValue);
        }

        private static bool isBST(TreeNode root, int min, int max)
        {
            if (root == null)
                return true;

            if (root.val == int.MinValue && root.left != null)
                return false;

            if (root.val == int.MaxValue && root.right != null)
                return false;

            if (root.val < min || root.val > max)
                return false;

            return isBST(root.left, min, root.val - 1)
                && isBST(root.right, root.val + 1, max);
        }
    }
}
