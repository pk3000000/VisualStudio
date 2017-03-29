using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication13
{
    class BinaryTreeNode
    {
        public int val;
        public BinaryTreeNode left;
        public BinaryTreeNode right;
        public BinaryTreeNode parent;

        public BinaryTreeNode()
        {
            val = 0;
            left = null;
            right = null;
            parent = null;
        }

        public BinaryTreeNode(int _val)
        {
            val = _val;
            left = null;
            right = null;
            parent = null;
        }
    }

    class BinaryTree
    {
        BinaryTreeNode root;

        public void Insert(BinaryTreeNode parent, BinaryTreeNode left, BinaryTreeNode right)
        {
            parent.left = left;
            parent.right = right;

        }

        void TravelsByPre(BinaryTreeNode _root)
        {
            Console.Write(_root.val + " ");
            if (_root.left != null)
                TravelsByPre(_root.left);
            if (_root.right != null)
                TravelsByPre(_root.right);
        }

        public void TravelsByPre()
        {
            TravelsByPre(root);
        }

        protected void TravelsByIn(BinaryTreeNode _root)
        {
            if (_root.left != null)
                TravelsByIn(_root.left);

            Console.Write(_root.val + " ");

            if (_root.right != null)
                TravelsByIn(_root.right);
        }

        public void TravelsByIn()
        {
            TravelsByIn(root);
        }

        void TravelsByPost(BinaryTreeNode _root)
        {
            if (_root.left != null)
                TravelsByPost(_root.left);

            if (_root.right != null)
                TravelsByPost(_root.right);

            Console.Write(_root.val + " ");

        }


        public void TravelsByPost()
        {
            TravelsByPost(root);
        }

        public void SetRoot(BinaryTreeNode rootNode)
        {
            root = rootNode;
        }

    }

    class BSTNode : BinaryTreeNode
    {
        public new int val;
        public new BSTNode left;
        public new BSTNode right;
        public BSTNode parent;

        public BSTNode() :base()
        {
            val = 0;
            parent = null;
            left = null;
            right = null;
        }

        public BSTNode(int _val) : base(_val)
        {
            val = _val;
            parent = null;
            left = null;
            right = null;
        }

    }

    class BST : BinaryTree
    {
        BSTNode root;

        public BST()
        {
            root = null;
        }

        public void Insert(int val)
        {
            if (root == null)
                root = new BSTNode(val);
            else
            {
                BSTNode curNode = root;

                while (true)
                {
                    if (curNode.val > val)
                    {
                        if (curNode.left == null)
                        {
                            curNode.left = new BSTNode(val);
                            curNode.left.parent = curNode;
                            break;
                        }
                        else
                            curNode = curNode.left;
                    }
                    else if (curNode.val < val)
                    {
                        if (curNode.right == null)
                        {
                            curNode.right = new BSTNode(val);
                            curNode.right.parent = curNode;
                            break;
                        }
                        else
                            curNode = curNode.right;
                    }
                }

            }
        }

        public void Delete(int val)
        {
            BSTNode curNode = root;

            if (curNode == null)
                Console.WriteLine("BST is empty!!!");
            else
            {
                while (true)
                {
                    if (curNode.val == val)
                    {
                        if (curNode.left != null)
                        {
                            if (curNode.right != null)
                            {
                                BSTNode leftMaxNode = curNode.left;

                                while (leftMaxNode.right != null)
                                    leftMaxNode = leftMaxNode.right;

                                curNode.val = leftMaxNode.val;
                                if (leftMaxNode.left != null)
                                {
                                    leftMaxNode.left.parent = leftMaxNode.parent;
                                    leftMaxNode.parent.right = leftMaxNode.left;
                                }
                                else
                                    leftMaxNode.parent.right = null;

                            }
                            else
                            {
                                curNode.left.parent = curNode.parent;

                                if (curNode.parent.left == curNode)
                                    curNode.parent.left = curNode.left;
                                else
                                    curNode.parent.right = curNode.left;
                            }
                        }
                        else
                        {
                            if (curNode.right != null)
                            {
                                curNode.right.parent = curNode.parent;
                                if (curNode.parent.left == curNode)
                                    curNode.parent.left = curNode.right;
                                else
                                    curNode.parent.right = curNode.right;
                            }
                            else
                            {
                                if (curNode.parent.left == curNode)
                                    curNode.parent.left = null;
                                else
                                    curNode.parent.right = null;
                            }
                        }
                        break;
                    }
                    else if (curNode.val > val)
                    {
                        if (curNode.left == null)
                        {
                            Console.WriteLine(val + " is not BST!!!");
                            break;
                        }
                        else
                            curNode = curNode.left;
                    }
                    else
                    {
                        if (curNode.right == null)
                        {
                            Console.WriteLine(val + " is not BST!!!");
                            break;
                        }
                        else
                            curNode = curNode.right;

                    }

                }
            }
        }

        public bool Search(int val)
        {
            BSTNode curNode = root;

            if (curNode == null)
                return false;
            else
            {
                while (curNode != null)
                {
                    if (curNode.val == val)
                        return true;
                    else if (curNode.val > val)
                        curNode = curNode.left;
                    else
                        curNode = curNode.right;
                }

                return false;
            }
        }
        
        public new void TravelsByIn()
        {
            TravelsByIn(root);
            Console.WriteLine();
        }
    }

    class 

    class Program
    {
        static void Main(string[] args)
        {
            
            BST myBST = new BST();

            myBST.Insert(50);
            myBST.Insert(20);
            myBST.Insert(70);
            myBST.Insert(30);
            myBST.Insert(10);
            myBST.Insert(60);
            myBST.Insert(80);
            myBST.Insert(5);
            myBST.Insert(15);
            myBST.Insert(25);
            myBST.Insert(35);
            myBST.Insert(55);
            myBST.Insert(65);
            myBST.Insert(75);
            myBST.Insert(85);
            myBST.Insert(90);
            myBST.Insert(3);
            myBST.Insert(8);

            myBST.TravelsByIn();
            Console.WriteLine(myBST.Search(4));
            Console.WriteLine(myBST.Search(5));

            myBST.Delete(8);
            myBST.TravelsByIn();

            myBST.Delete(20);
            myBST.TravelsByIn();

            myBST.Delete(4);
            myBST.TravelsByIn();
            
            /*
            BinaryTreeNode tmpNode1 = new BinaryTreeNode(1);
            BinaryTreeNode tmpNode2 = new BinaryTreeNode(2);
            BinaryTreeNode tmpNode3 = new BinaryTreeNode(3);
            BinaryTreeNode tmpNode4 = new BinaryTreeNode(4);
            BinaryTreeNode tmpNode5 = new BinaryTreeNode(5);
            BinaryTreeNode tmpNode6 = new BinaryTreeNode(6);
            BinaryTreeNode tmpNode7 = new BinaryTreeNode(7);

            BinaryTree bTree = new BinaryTree();

            bTree.SetRoot(tmpNode1);
            bTree.Insert(tmpNode1, tmpNode2, tmpNode3);
            bTree.Insert(tmpNode2, tmpNode4, tmpNode5);
            bTree.Insert(tmpNode3, tmpNode6, tmpNode7);

            bTree.TravelsByPre();
            Console.WriteLine();

            bTree.TravelsByIn();
            Console.WriteLine();

            bTree.TravelsByPost();
            Console.WriteLine();*/
        }
    }
}
