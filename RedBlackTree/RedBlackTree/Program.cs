using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode parent;

        public TreeNode(int val)
        {
            this.left = null;
            this.right = null;
            this.parent = null;
            this.val = val;
        }
    }

    public class RBTree
    {
        TreeNode root;
        TreeNode nil;

        public RBTree()
        {
            root = null;
            nil = new TreeNode(int.MinValue);
        }

        public void leftRotate(ref TreeNode tempNode, ref TreeNode tNode)
        {
            TreeNode temp = tNode.right;
            tNode.right = temp.left;

            if(temp.left != nil)
            {
                temp.left.parent = tNode;
            }

            temp.parent = tNode.parent;

            if(tNode.parent == )
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
