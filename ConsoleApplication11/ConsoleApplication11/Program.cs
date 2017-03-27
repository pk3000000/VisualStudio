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

            while (true)
            {
                if (tempNode == null)
                {
                    Console.WriteLine("{0} 못 찾았습니다.", val);
                    break;
                }
                if (tempNode != null && tempNode.val == val)
                {
                    if(tempNode.parent.right == tempNode)
                    {
                        if (tempNode.left == null && tempNode.right == null)
                        {
                            tempNode.parent.right = null;
                            tempNode.parent = null;
                            tempNode = null;
                        }
                        else if(tempNode.left==null||tempNode.right==null)
                        {
                            if(tempNode.left == null)
                            {
                                tempNode.parent.right = tempNode.right.right;
                                tempNode = null;
                                Console.WriteLine("{0} 지웠습니다.", val);
                                break;
                            }
                            else if(tempNode.right == null)
                            {
                                tempNode.parent.left = tempNode.left.left;
                                tempNode = null;
                                Console.WriteLine("{0} 지웠습니다.", val);
                                break;
                            }
                        }
                        else
                        {
                            TreeNode tNode = tempNode.left;

                            while(true)
                            {
                                if(tNode.right != null)
                                {
                                    tNode = tNode.right;
                                }
                                else
                                {
                                    tNode.parent.right = null;
                                    tNode.parent = tempNode.parent;
                                    tempNode.parent.left = tNode;
                                    tNode.right = tempNode.right;
                                    tempNode = null;
                                    Console.WriteLine("{0} 지웠습니다.", val);
                                    break;
                                }
                            }
                        }
                    }
                    else if(tempNode.parent.left == tempNode)
                    {
                        if (tempNode.left == null && tempNode.right == null)
                        {
                            tempNode.parent.left = null;
                            tempNode.parent = null;
                            tempNode = null;
                        }
                    }
                    
                    Console.WriteLine("{0} 지웠습니다.", val);
                    break;
                }
                if (tempNode != null)
                {
                    if (tempNode.val > val)
                    {
                        tempNode = tempNode.left;

                        if (tempNode == null || tempNode.val < val)
                        {
                            Console.WriteLine("못 찾았습니다.");
                            break;
                        }
                    }
                }
                if (tempNode != null)
                {
                    if (tempNode.val < val)
                    {
                        tempNode = tempNode.right;

                        if (tempNode == null || tempNode.val > val)
                        {
                            Console.WriteLine("못 찾았습니다.");
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
            bst.insert(17);
            bst.insert(14);
            bst.insert(18);
            bst.insert(19);
            bst.insert(12);
            bst.insert(11);

            bst.search(ref bst.root,18);
            bst.delete(18);
            bst.search(ref bst.root, 18);
        }
    }
}
