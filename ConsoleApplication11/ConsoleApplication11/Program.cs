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
                    if (tempTree.val > val)
                    {
                        if (tempTree.left == null)
                        {
                            insertTree.parent = tempTree;
                            tempTree.left = insertTree;
                            return;
                        }
                        else
                        {
                            tempTree = tempTree.left;
                        }
                    }
                    else if (tempTree.val <= val)
                    {
                        if (tempTree.right == null)
                        {
                            insertTree.parent = tempTree;
                            tempTree.right = insertTree;
                            return;
                        }
                        else
                        {
                            tempTree = tempTree.right;
                           
                        }
                    }
                }
                
            }
        }

        public void delete(int val)
        {
            TreeNode tempNode = root;

            if (root.left == null && root.right == null)
            {
                if (root.val == val)
                {
                    root = null;
                    return;
                }
            }
            else
            {
                while(true)
                {
                    if(tempNode == null)
                    {
                        break;
                    }
                    else
                    {
                        if (tempNode.val == val && tempNode.left == null && tempNode.right == null)
                        {
                            tempNode = null;
                            break;
                        }
                        else if (tempNode.left != null && tempNode.right != null)
                        {
                            TreeNode tNode = tempNode.parent;
                            tempNode = tempNode.left;

                            while (true)
                            {
                                if (tempNode.right != null)
                                {
                                    tempNode = tempNode.right;
                                }
                                else
                                {
                                    if (tempNode.left == null)
                                    {
                                        tNode.left = tempNode;
                                        tempNode.parent = tNode;
                                        break;
                                    }
                                    else
                                    {
                                        tempNode.left.parent = tempNode.parent;
                                        tempNode.parent.right = tempNode.left;
                                        tNode.left = tempNode;
                                        tempNode.parent = tNode;
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                        else if (tempNode.left == null)
                        {
                            if (tempNode.parent != null && tempNode.right != null)
                            {
                                tempNode.parent.right = tempNode.right;
                                tempNode.right.parent = tempNode.parent;
                            }
                            else
                            {

                            }
                            tempNode = null;
                            break;
                        }
                        else if (tempNode.right == null)
                        {
                            if (tempNode.parent != null && tempNode.left != null)
                            {
                                tempNode.parent.left = tempNode.left;
                                tempNode.left.parent = tempNode.parent;
                            }
                            else
                            {

                            }
                            tempNode = null;
                            break;
                        }
                    }
                }
                    
            }
            
        }

        public void search(ref TreeNode tempNode, int val)
        {
            while(true)
            {
                if(tempNode == null)
                {
                    break;
                }
                if (tempNode != null && tempNode.val == val)
                {
                    Console.WriteLine("{0} 찾았습니다.", val);
                    break;
                }
                if (tempNode != null)
                {
                    if(tempNode.val > val)
                    {
                        tempNode = tempNode.left;

                        if(tempNode==null||tempNode.val < val)
                        {
                            break;
                        }
                    }
                }
                if (tempNode != null)
                {
                    if(tempNode.val < val)
                    {
                        tempNode = tempNode.right;

                        if (tempNode == null || tempNode.val > val)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BSTree bst = new BSTree();

            bst.insert(16);
            bst.insert(15);
         //   bst.insert(17);
         //   bst.insert(14);
         //   bst.insert(18);
         //   bst.insert(19);
         //   bst.insert(12);
          //  bst.insert(11);

            bst.search(ref bst.root,16);
            bst.delete(16);
            bst.search(ref bst.root, 16);
        }
    }
}
