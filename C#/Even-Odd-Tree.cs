/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution
{
    /*public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }*/

    public bool IsEvenOddTree(TreeNode root)
    {
        List<TreeNode> q = new List<TreeNode> { root };
        bool isOdd = false;

        while (q.Count > 0)
        {
            List<TreeNode> newQ = new List<TreeNode>();
            TreeNode prev = null;

            foreach (var node in q)
            {
                if (isOdd)
                {
                    if (node.val % 2 != 0 || (prev != null && prev.val <= node.val))
                    {
                        return false;
                    }
                }
                else
                {
                    if (node.val % 2 == 0 || (prev != null && prev.val >= node.val))
                    {
                        return false;
                    }
                }

                if (node.left != null)
                {
                    newQ.Add(node.left);
                }

                if (node.right != null)
                {
                    newQ.Add(node.right);
                }

                prev = node;
            }

            q = newQ;
            isOdd = !isOdd;
        }

        return true;
    }
}
