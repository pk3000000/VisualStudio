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
        public TreeNode Nil;

        public RBTree()
        {
            root = null;
            Nil = new TreeNode(int.MinValue);
            Nil.left = null;
            Nil.right = null;
            Nil.parent = null;
            Nil.color = "BLACK";
        }

        public  TreeNode searchNode(ref TreeNode tempNode, int val)
        { 

            if(root == Nil)
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
            if(tempNode == Nil)
            {
                return Nil;
            }

            if(tempNode.left == Nil)
            {
                return tempNode;
            }
            else
            {
                return searchMinNode(ref tempNode.left);
            }
        }

        public void insertNode(ref TreeNode tempNode, int val)
        {
            TreeNode newNode = new TreeNode(val);

            newNode.parent = null;
            newNode.left = null;
            newNode.right = null;
            newNode.val = val;
            newNode.color = "BLACK";

            insertNodeHelper(ref tempNode,ref newNode);

            newNode.color = "RED";
            newNode.left = Nil;
            newNode.right = Nil;

            rebuildAfterInsert(ref tempNode, ref newNode);

        }

        public void insertNodeHelper(ref TreeNode tempNode, ref TreeNode newNode)
        {
            if(root == null)
            {
                root = newNode;
            }

            if(tempNode.val < newNode.val)
            {
                if(tempNode.right == Nil)
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
                if (tempNode.left == Nil)
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

        public void rotateRight(ref TreeNode tempNode, ref TreeNode parent)
        {
            TreeNode leftChild = parent.left;

            parent.left = leftChild.right;

            if(leftChild.right != Nil)
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

        public void rotateLeft(ref TreeNode tempNode, ref TreeNode parent)
        {
            TreeNode rightChild = parent.right;

            parent.right = rightChild.left;

            if (rightChild.left != Nil)
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

        public void rebuildAfterInsert(ref TreeNode tempNode,ref TreeNode X)
        {
            while(X != root && string.Equals(X.parent.color,"RED"))
            {
                if(X.parent == X.parent.parent.left)
                {
                    TreeNode uncle = X.parent.parent.right;

                    if(string.Equals(uncle.color,"RED"))
                    {
                        X.parent.color = "BLACK";
                        uncle.color = "BLACK";
                        X.parent.parent.color = "RED";

                        X = X.parent.parent;
                    }
                    else
                    {
                        if(X == X.parent.right)
                        {
                            X = X.parent;
                            rotateLeft(ref tempNode,ref X);
                        }

                        tempNode.parent.color = "BLACK";
                        tempNode.parent.parent.color = "RED";

                        rotateRight(ref tempNode,ref X);
                    }
                }
                else
                {
                    TreeNode uncle = X.parent.parent.left;

                    if(string.Equals(uncle.color,"RED"))
                    {
                        X.parent.color = "BLACK";
                        uncle.color = "BLACK";
                        X.parent.parent.color = "RED";

                        X = X.parent.parent;
                    }
                    else
                    {
                        if(X == X.parent.left)
                        {
                            X = X.parent;
                            rotateRight(ref tempNode, ref X);
                        }

                        X.parent.color = "BLACK";
                        X.parent.parent.color = "RED";

                        rotateLeft(ref tempNode, ref X.parent.parent);
                    }
                }
            }

            root.color = "BLACK";
        }

        public TreeNode removeNode(ref TreeNode tempNode, int data)
        {
            TreeNode removed = null;
            TreeNode successor = null;
            TreeNode target = searchNode(ref tempNode, data);

            if(target == null)
            {
                return null;
            }

            if(target.left==Nil || target.right == Nil)
            {
                removed = target;
            }
            else
            {
                removed = searchMinNode(ref target.right);
                target.val = removed.val;
            }

            if(removed.left != Nil)
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
                rebuildAfterRemove(ref tempNode, ref successor);
            }

            return removed;
        }

        public void rebuildAfterRemove(ref TreeNode tempNode, ref TreeNode successor)
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
                        rotateLeft(ref tempNode,ref successor.parent);
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

                                rotateRight(ref tempNode, ref sibling);
                                sibling = successor.parent.right;
                            }

                            sibling.color = successor.parent.color;
                            successor.parent.color = "BLACK";
                            sibling.right.color = "BLACK";
                            rotateLeft(ref tempNode, ref successor.parent);
                            successor = tempNode;
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
                        rotateRight(ref tempNode, ref successor.parent);
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

                                rotateLeft(ref tempNode, ref sibling);
                                sibling = successor.parent.left;
                            }

                            sibling.color = successor.parent.color;
                            successor.parent.color = "BLACK";
                            sibling.left.color = "BLACK";
                            rotateRight(ref tempNode, ref successor.parent);
                            successor = tempNode;
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
          
            if(tempNode == null||tempNode==Nil)
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

            if(tempNode.left == Nil && tempNode.right == Nil)
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
            
            RBTree rbt = new RBTree();
           
            for (int i = 0; i < 3; i++)
            {
                rbt.insertNode(ref rbt.root, i+1);
            }

            rbt.printTree(ref rbt.root, 0, 0);
            
            /*
            MyClass source = new MyClass();

            source.MyField1 = 10;
            source.MyField2 = 20;

            MyClass target = source;

            target.MyField2 = 30;

            Console.WriteLine("{0} {1}", source.MyField1, source.MyField2);
            Console.WriteLine("{0} {1}", target.MyField1, target.MyField2);*/
            /*
            Derived dv = new Derived();
            dv.BaseMethod();
            */
        }
    }
}
