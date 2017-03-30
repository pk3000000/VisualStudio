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

        public void insertNode(ref TreeNode tempNode, int val)      // insert
        {
            TreeNode newNode = new TreeNode(val);                   // Make new node

            newNode.parent = null;
            newNode.left = null;
            newNode.right = null;
            newNode.val = val;
            newNode.color = "BLACK";                                // new node setting

            insertNodeHelper(ref tempNode,ref newNode);             // binary tree insert

            newNode.color = "RED";
            newNode.left = Nil;
            newNode.right = Nil;                                    // new node "RED" color, left, right Nil setting
            

            rebuildAfterInsert(ref tempNode, ref newNode);          // balancing


        }

        public void insertNodeHelper(ref TreeNode tempNode, ref TreeNode newNode)
        {
            if(root == null)                                                            // 일반적인 Binay Tree insert 과정을 recurcive하게 만듦.
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

        public void rotateRight(TreeNode tempNode, TreeNode parent)
        {
            TreeNode leftChild = parent.left;

            parent.left = leftChild.right;

            if(leftChild.right != Nil)
            {
                leftChild.right.parent = parent;
            }


            leftChild.parent = parent.parent;

            if (parent.parent == null)
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

        public void rotateLeft(TreeNode tempNode, TreeNode parent)
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

        public void rebuildAfterInsert(ref TreeNode tempNode,ref TreeNode X)        // balancing
        {
            while(X != root && string.Equals(X.parent.color,"RED")) // 새로 들어온 인스턴스가 root라면 건너 뜀. 부모의 color가 "RED"라면
            {
                if(X.parent == X.parent.parent.left)        // X의 부모가 Grand Parent의 왼쪽 자식이라면
                {
                    TreeNode uncle = X.parent.parent.right; // 오른쪽은 삼촌이 된다.

                    if(string.Equals(uncle.color,"RED"))    // 삼촌이 "RED"라면
                    {
                        X.parent.color = "BLACK";           // 부모는 "BLACK"
                        uncle.color = "BLACK";              // 삼촌은 "BLACK"
                        X.parent.parent.color = "RED";      // Grand Parent는 "RED"

                        X = X.parent.parent;                // X는 Grand Parent
                    }
                    else
                    {                                       // 삼촌이 "BLACK" 이면
                        if(X == X.parent.right)             // X가 오른쪽 자식이면
                        {
                            X = X.parent;                   // X는 부모
                            rotateLeft(tempNode,X);         // 왼쪽회전
                        }

                        X.parent.color = "BLACK";    // 부모는 "BLACK"
                        X.parent.parent.color = "RED"; // Grand Parent는 "RED"

                        rotateRight(tempNode,X.parent.parent);  // 오른쪽 회전
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
                            rotateRight(tempNode, X);
                        }

                        X.parent.color = "BLACK";
                        X.parent.parent.color = "RED";

                        rotateLeft(tempNode, X.parent.parent);
                    }
                }
            }

            root.color = "BLACK";                                   // root는 무조건 "BLACK"
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
                        rotateLeft(tempNode,successor.parent);
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

                                rotateRight(tempNode, sibling);
                                sibling = successor.parent.right;
                            }

                            sibling.color = successor.parent.color;
                            successor.parent.color = "BLACK";
                            sibling.right.color = "BLACK";
                            rotateLeft(tempNode, successor.parent);
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
                        rotateRight(tempNode, successor.parent);
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

                                rotateLeft(tempNode, sibling);
                                sibling = successor.parent.left;
                            }

                            sibling.color = successor.parent.color;
                            successor.parent.color = "BLACK";
                            sibling.left.color = "BLACK";
                            rotateRight(tempNode, successor.parent);
                            successor = tempNode;
                        }
                    }
                }
            }
            successor.color = "BLACK";
        }

        public void printTree(TreeNode tempNode, int depth, int blackCount)
        {
            char c = 'X';
            int v = -1;
            string cnt = "";

            if(tempNode == null || tempNode == Nil)
            {
                return;
            }

            if(string.Equals(tempNode.color, "BLACK"))
            {
                blackCount++;
            }

            if(tempNode.parent != null)
            {
                v = tempNode.parent.val;

                if(tempNode.parent.left == tempNode)
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
                cnt += "------- " + blackCount;
            }
            else
            {
                cnt += "";
            }

            for(int i=0;i<depth;i++)
            {
                Console.Write("  ");
            }

            Console.WriteLine("{0} {1} [{2},{3}] {4}", tempNode.val, (string.Equals(tempNode.color, "RED") ? "RED" : "BLACK"), c, v, cnt);

            printTree(tempNode.left, depth + 1, blackCount);
            printTree(tempNode.right, depth + 1, blackCount);
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

            for (int i = 0; i < 10; i++)
            {
                rbt.insertNode(ref rbt.root, i + 1);
            }

            rbt.printTree(rbt.root,0,0);

            for (int i = 0; i < 10; i++)
            {
                rbt.removeNode(ref rbt.root, i + 1);
            }
            Console.WriteLine();

            //rbt.printTree(rbt.root,0,0);
            //Console.WriteLine();
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
