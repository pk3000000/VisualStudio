using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication11
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode parent;

        public TreeNode()
        {
            val = 0;
            left = null;
            right = null;
            parent = null;
        }

        public TreeNode(int val, TreeNode left, TreeNode right, TreeNode parent)
        {
            this.val = val;
            this.left = left;
            this.right = right;
            this.parent = parent;
        }

    }


    public class BSTree
    {
        public TreeNode root;

        public BSTree()
        {
            root = null;
        } 

        public void insert(int val)
        {
           TreeNode tempTree = root;
           TreeNode insertTree = new TreeNode(val, null, null, null);

            if (root == null)
            {
                root = insertTree;
            }
            else
            {
                while(true)
                {
                    if(tempTree.val > val)
                    {
                        if(tempTree.left == null)
                        {
                            tempTree.left = insertTree;
                            insertTree.parent = tempTree;
                            break;
                        }
                        tempTree = tempTree.left;
                        
                    }
                    else if(tempTree.val <= val)
                    {
                        if (tempTree.right == null)
                        {
                            tempTree.right = insertTree;
                            insertTree.parent = tempTree;
                            break;
                        }
                        tempTree = tempTree.right;
                    }
                }
            }

        }

        public TreeNode delete(ref TreeNode tempNode, int val)
        {
            if(tempNode == null)
            {
                return null;
            }
            else if(tempNode.val < val)
            {
                tempNode.right = delete(ref tempNode.right, val);
            }
            else if(tempNode. val > val)
            {
                tempNode.left = delete(ref tempNode.left, val);
            }
            else
            {
                if(tempNode.left != null || tempNode.right != null)
                {
                    TreeNode tNode = null;

                    if(tempNode.left != null)
                    {
                        tNode = findMax(ref tempNode.left);
                        tempNode.val = tNode.val;

                        if(tNode.left != null)
                        {
                            tNode.parent.left = tNode.left;
                            tNode.left.parent = tNode.parent;
                            tempNode.left = delete(ref tempNode.left, tNode.val);
                        }
                        else
                        {
                            tempNode.left = delete(ref tempNode.left, val);
                        }
                        
                    }
                    else
                    {
                        tNode = findMin(ref tempNode.right);
                        tempNode.val = tNode.val;

                        if (tNode.right != null)
                        {
                            tNode.parent.right = tNode.right;
                            tNode.right.parent = tNode.parent;
                            tempNode.right = delete(ref tempNode.right, tNode.val);
                        }
                        else
                        {
                            tempNode.right = delete(ref tempNode.right, val);
                        }
                        
                    }
                }
                else
                {
                    if(tempNode.parent.left == tempNode)
                    {
                        tempNode.parent.left = null;
                    }
                    else if(tempNode.parent.right == tempNode)
                    {
                        tempNode.parent.right = null;
                    }
                    return null;
                }
            }
            return tempNode;
        }

        public TreeNode findMax(ref TreeNode tempNode)
        {
            if(tempNode.right!=null)
            {
                return findMax(ref tempNode.right);
            }
            else
            {
                return tempNode;
            }
        }

        public TreeNode findMin(ref TreeNode tempNode)
        {
            if (tempNode.left != null)
            {
                return findMin(ref tempNode.left);
            }
            else
            {
                return tempNode;
            }
        }

        public void search(ref TreeNode tempNode, int val)
        {
            if(tempNode == null)
            {
                return;
            }

            if(tempNode.val > val)
            {
                search(ref tempNode.left, val);
            }

            if(tempNode.val == val)
            {
                Console.WriteLine("{0} found", val);
                return;
            }

            if(tempNode.val < val)
            {
                search(ref tempNode.right, val);
            }
                
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BSTree bst = new BSTree();

            for(int i=1;i<100;i++)
            {
                bst.insert(i);
            }

            bst.search(ref bst.root,3);
            bst.delete(ref bst.root,3);
            bst.search(ref bst.root, 3);
            bst.search(ref bst.root, 1);
            bst.delete(ref bst.root, 1);
            bst.search(ref bst.root, 1);
        }
    }
}
