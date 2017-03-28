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
        public string color;
        public TreeNode left;
        public TreeNode right;
        public TreeNode parent;

        public TreeNode(int val)
        {
            this.left = null;
            this.right = null;
            this.parent = null;
            this.val = val;
            this.color = "BLACK";
        }
        
    }

    public class RBTree
    {
        public TreeNode root;

        public RBTree()
        {
            root = null;
        }

        public  TreeNode searchNode(ref TreeNode tempNode, int val)
        { 

            if(root == null)
            {
                return null;
            }

            if(tempNode.val > val)
            {
                return searchNode(ref tempNode.left, val);
            }
            else if(tempNode.val < val)
            {
                return searchNode(ref tempNode.right, val);
            }
            else
            {
                return tempNode;
            }
        }

        public TreeNode searchMinNode(ref TreeNode tempNode)
        {
            if(tempNode == null)
            {
                return null;
            }

            if(tempNode.left == null)
            {
                return tempNode;
            }
            else
            {
                return searchMinNode(ref tempNode.left);
            }
        }

        public void insertNode(ref TreeNode tempNode, ref TreeNode newNode)
        {
            insertNodeHelper(ref tempNode,ref newNode);

            newNode.color = "RED";
            newNode.left = null;
            newNode.right = null;

            rebuildAfterInsert(ref newNode);

        }

        public void insertNodeHelper(ref TreeNode tempNode, ref TreeNode newNode)
        {
            if(root == null)
            {
                root = newNode;
            }

            if(tempNode.val < newNode.val)
            {
                if(tempNode.right == null)
                {
                    tempNode.right = newNode;
                    newNode.parent = tempNode;
                }
                else
                {
                    insertNodeHelper(ref tempNode.right, ref newNode);
                }
            }
            else if(tempNode.val > newNode.val)
            {
                if (tempNode.left == null)
                {
                    tempNode.left = newNode;
                    newNode.parent = tempNode;
                }
                else
                {
                    insertNodeHelper(ref tempNode.left, ref newNode);
                }
            }
        }

        public void rotateRight(ref TreeNode parent)
        {
            TreeNode leftChild = parent.left;

            parent.left = leftChild.right;

            if(leftChild.right != null)
            {
                leftChild.right.parent = parent;
            }

            leftChild.parent = parent.parent;

            if(parent.parent == null)
            {
                root = leftChild;
            }
            else
            {
                if(parent == parent.parent.left)
                {
                    parent.parent.left = leftChild;
                }
                else
                {
                    parent.parent.right = leftChild;
                }
            }

            leftChild.right = parent;
            parent.parent = leftChild;
        }

        public void rotateLeft(ref TreeNode parent)
        {
            TreeNode rightChild = parent.right;

            parent.right = rightChild.left;

            if (rightChild.left != null)
            {
                rightChild.left.parent = parent;
            }

            rightChild.parent = parent.parent;

            if (parent.parent == null)
            {
                root = rightChild;
            }
            else
            {
                if (parent == parent.parent.left)
                {
                    parent.parent.left = rightChild;
                }
                else
                {
                    parent.parent.right = rightChild;
                }
            }

            rightChild.left = parent;
            parent.parent = rightChild;
        }

        public void rebuildAfterInsert(ref TreeNode tempNode)
        {
            while(tempNode != root && string.Equals(tempNode.parent.color,"RED"))
            {
                if(tempNode.parent == tempNode.parent.parent.left)
                {
                    TreeNode uncle = tempNode.parent.parent.right;

                    if(string.Equals(uncle.color,"RED"))
                    {
                        tempNode.color = "BLACK";
                        uncle.color = "BLACK";
                        tempNode.parent.parent.color = "RED";

                        tempNode = tempNode.parent.parent;
                    }
                    else
                    {
                        if(tempNode == tempNode.parent.right)
                        {
                            tempNode = tempNode.parent;
                            rotateLeft(ref tempNode);
                        }

                        tempNode.parent.color = "BLACK";
                        tempNode.parent.parent.color = "RED";

                        rotateRight(ref tempNode.parent.parent);
                    }
                }
                else
                {
                    TreeNode uncle = tempNode.parent.parent.left;

                    if(string.Equals(uncle.color,"RED"))
                    {
                        tempNode.parent.color = "BLACK";
                        uncle.color = "BLACK";
                        tempNode.parent.parent.color = "RED";

                        tempNode = tempNode.parent.parent;
                    }
                    else
                    {
                        if(tempNode == tempNode.parent.left)
                        {
                            tempNode = tempNode.parent;
                            rotateRight(ref tempNode);
                        }

                        tempNode.parent.color = "BLACK";
                        tempNode.parent.parent.color = "RED";
                        rotateLeft(ref tempNode.parent.parent);
                    }
                }
            }

            root.color = "BLACK";
        }

        public void search(ref TreeNode tempNode, int val)
        {
            if (tempNode == null)
            {
                return;
            }

            if (tempNode.val > val)
            {
                search(ref tempNode.left, val);
            }

            if (tempNode.val == val)
            {
                Console.WriteLine("{0} found", val);
                Console.WriteLine("{0} ", tempNode.color);
                return;
            }

            if (tempNode.val < val)
            {
                search(ref tempNode.right, val);
            }


        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            RBTree rbt = new RBTree();

            for (int i = 0; i < 100; i++)
            {
               // rbt.insert(i+1);
            }

            rbt.search(ref rbt.root, 3);
            
        }
    }
}
