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

        public TreeNode removeNode(ref TreeNode rTempNode, ref TreeNode tempNode, int data)
        {
            TreeNode removed = null;
            TreeNode successor = null;
            TreeNode target = searchNode(ref tempNode, data);

            if(target == null)
            {
                return null;
            }

            if(target.left==null || target.right == null)
            {
                removed = target;
            }
            else
            {
                removed = searchMinNode(ref target.right);
                target.val = removed.val;
            }

            if(removed.left != null)
            {
                successor = removed.left;
            }
            else
            {
                successor = removed.right;
            }

            successor.parent = removed.parent;

            if(removed.parent == null)
            {
                root = successor;
            }
            else
            {
                if(removed == removed.parent.left)
                {
                    removed.parent.left = successor;
                }
                else
                {
                    removed.parent.right = successor;
                }
            }

            if(string.Equals(removed.color,"BLACK"))
            {
                rebuildAfterRemove(ref successor);
            }

            return removed;
        }

        public void rebuildAfterRemove(ref TreeNode successor)
        {
            TreeNode sibling = null;

            while(successor.parent != null && string.Equals(successor.color,"BLACK"))
            {
                if (successor == successor.parent.left)
                {
                    sibling = successor.parent.right;

                    if(string.Equals(sibling.color,"RED"))
                    {
                        sibling.color = "BLACK";
                        successor.parent.color = "RED";
                        rotateLeft(ref successor.parent);
                    }
                    else
                    {
                        if(string.Equals(sibling.left.color,"BLACK")&&string.Equals(sibling.right.color,"BLACK"))
                        {
                            sibling.color = "RED";
                            successor = successor.parent;
                        }
                        else
                        {
                            if(string.Equals(sibling.left.color,"RED"))
                            {
                                sibling.left.color = "BLACK";
                                sibling.color = "RED";

                                rotateRight(ref sibling);
                                sibling = successor.parent.right;
                            }

                            sibling.color = successor.parent.color;
                            successor.parent.color = "BLACK";
                            sibling.right.color = "BLACK";
                            rotateLeft(ref successor.parent);
                            successor = root;
                        }
                    }
                }
                else
                {
                    sibling = successor.parent.left;

                    if(string.Equals(sibling.color,"RED"))
                    {
                        sibling.color = "BLACK";
                        successor.parent.color = "RED";
                        rotateRight(ref successor.parent);
                    }
                    else
                    {
                        if(string.Equals(sibling.right.color,"BLACK")&&string.Equals(sibling.left.color,"BLACK"))
                        {
                            sibling.color = "RED";
                            successor = successor.parent;
                        }
                        else
                        {
                            if(string.Equals(sibling.right.color,"RED"))
                            {
                                sibling.right.color = "BLACK";
                                sibling.color = "RED";

                                rotateLeft(ref sibling);
                                sibling = successor.parent.left;
                            }

                            sibling.color = successor.parent.color;
                            successor.parent.color = "BLACK";
                            sibling.left.color = "BLACK";
                            rotateRight(ref successor.parent);
                            successor = root;
                        }
                    }
                }
            }
            successor.color = "BLACK";
        }

        public void printTree(ref TreeNode tempNode, int depth, int blackCount)
        {
            int i = 0;
            char c = 'X';
            int v = -1;
            string  cnt = "";
          
            if(tempNode == null)
            {
                return;
            }

            if(string.Equals(tempNode.color,"BLACK"))
            {
                blackCount++;
            }

            if(tempNode.parent != null)
            {
                v = tempNode.parent.val;

                if (tempNode.parent.left == tempNode)
                {
                    c = 'L';
                }
                else
                {
                    c = 'R';
                }
            }

            if(tempNode.left == null && tempNode.right == null)
            {
                cnt = "---------- " + (blackCount + "");
            }
            else
            {
                cnt = "";
            }

            for(i=0;i<depth;i++)
            {
                Console.Write("  ");
            }

            Console.WriteLine("{0} {1} [{2},{3}] {4}", tempNode.val, (string.Equals(tempNode.color, "RED") ? "RED" : "BLACK"), c, v, cnt);

            printTree(ref tempNode.left, depth + 1, blackCount);
            printTree(ref tempNode.right, depth + 1, blackCount);
        }
    }

    class Program
    {
        class MyClass
        {
            public int MyField1;
            public int MyField2;
        }

        class Base
        {
            public void BaseMethod()
            {
                Console.WriteLine("BaseMethod");
            }
        }

        class Derived : Base
        {

        }

        static void Main(string[] args)
        {
            /*
            RBTree rbt = new RBTree();
            TreeNode tempNode = null;

            for (int i = 0; i < 100; i++)
            {
                tempNode = new TreeNode(i + 1);
                rbt.insertNode(ref rbt.root, ref tempNode);
            }

            rbt.printTree(ref rbt.root, 0, 0);
            */
            /*
            MyClass source = new MyClass();

            source.MyField1 = 10;
            source.MyField2 = 20;

            MyClass target = source;

            target.MyField2 = 30;

            Console.WriteLine("{0} {1}", source.MyField1, source.MyField2);
            Console.WriteLine("{0} {1}", target.MyField1, target.MyField2);*/

            Derived dv = new Derived();
            dv.BaseMethod();

        }
    }
}
