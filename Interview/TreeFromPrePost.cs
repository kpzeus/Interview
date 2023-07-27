using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    internal class TreeFromPrePost
    {
        static int p = 0;
        static int i = 0;

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            p = 0;
            i = 0;
            return BuildTree2(preorder, inorder, int.MinValue);
        }

        private TreeNode BuildTree2(int[] preorder, int[] inorder, int stop)
        {
            if (p >= preorder.Length)
                return null;

            if (inorder[i] == stop)
            {
                i++;
                return null;
            }

            TreeNode root = new TreeNode(preorder[p]);
            p++;
            root.left = BuildTree2(preorder, inorder, root.val);
            root.right = BuildTree2(preorder, inorder, stop);

            return root;
        }
    }
}
