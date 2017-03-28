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
            this.color = "RED";
        }
    }

    public class RBTree
    {
        TreeNode root;

        public RBTree()
        {
            root = null;
        }
        

        public TreeNode createNode(int val)
        {
            TreeNode tempNode = new TreeNode(val);
            tempNode.left = null;
            tempNode.right = null;
            tempNode.parent = null;

            return tempNode;
        }

        public void leftRotate(ref TreeNode tNode)
        {
            TreeNode temp = tNode.right;
            tNode.right = temp.left;

            if(temp.left != null)
            {
                temp.left.parent = tNode;
            }

            temp.parent = tNode.parent;

            if(tNode.parent == null)
            {
                root = temp;
            }
            else if(tNode == tNode.parent.left)
            {
                tNode.parent.left = temp;
            }
            else
            {
                tNode.parent.right = temp;
            }

            temp.left = tNode;
            tNode.parent = temp;
        }

        public void rightRotate(ref TreeNode tNode)
        {
            TreeNode temp = tNode.left;
            tNode.left = temp.right;

            if (temp.right != null)
            {
                temp.right.parent = tNode;
            }

            temp.parent = tNode.parent;

            if (tNode.parent == null)
            {
                root = temp;
            }
            else if (tNode == tNode.parent.left)
            {
                tNode.parent.left = temp;
            }
            else
            {
                tNode.parent.right = temp;
            }

            temp.right = tNode;
            tNode.parent = temp;
        }

        public void insert(int val)
        {
            TreeNode newNode = createNode(val);
            TreeNode tempNode = root;

            if (tempNode == null)
            {
                root = newNode;
                root.color = "BLACK";
            }
            else
            {
                while(true)
                {
                    
                    if(tempNode.left != null || tempNode.right != null)
                    {

                    }
                    if(tempNode.val == val)
                    {
                        Console.WriteLine("중복된 값이 있습니다.");
                        break;
                    }
                    else if(tempNode.val > val)
                    {
                        if (tempNode.left != null)
                        {
                            tempNode = tempNode.left;
                        }
                        if (tempNode.left == null)
                        {
                            newNode.parent = tempNode;
                            tempNode.left = newNode;
                            break;
                        }
                    }
                    else if(tempNode.val < val)
                    {
                        if (tempNode.right != null)
                        {
                            tempNode = tempNode.right;
                        }
                        if (tempNode.right == null)
                        {
                            newNode.parent = tempNode;
                            tempNode.right = newNode;
                            break;
                        }
                    }
                }
            }

            insertFixup(ref root, ref newNode);
        }

        public void insertFixup(ref TreeNode tempNode, ref TreeNode tNode)
        {
            if(tNode != null && tNode.parent!= null && tNode.parent.parent!= null)
            {
                // 1. 부모 '빨강' , 삼촌 '빨강'
                if (tNode.parent == tNode.parent.parent.left)
                {
                    if (tNode.parent.parent.right != null && tNode.parent.color.Equals("RED") && tNode.parent.parent.right.color.Equals("RED"))
                    {
                        tNode.parent.color = "BLACK";
                        tNode.parent.parent.right.color = "BLACK";
                        tNode.parent.parent.color = "RED";
                    }
                }
                else if (tNode.parent == tNode.parent.parent.right)
                {
                    if (tNode.parent.parent.left != null && tNode.parent.color.Equals("RED") && tNode.parent.parent.left.color.Equals("RED"))
                    {
                        tNode.parent.color = "BLACK";
                        tNode.parent.parent.left.color = "BLACK";
                        tNode.parent.parent.color = "RED";
                    }
                }

                // 2. 부모 '빨강' , 삼촌 '검정', 현재노드 '우측 자식'
                if(tNode.parent == tNode.parent.parent.left)
                {
                    if (tNode.parent.parent.right!=null&&tNode.parent.color.Equals("RED") && tNode.parent.parent.right.color.Equals("BLACK")&&tNode.parent.right==tNode)
                    {
                        leftRotate(ref tNode);

                        tNode.parent.color = "BLACK";
                        tNode.parent.parent.color = "RED";

                        rightRotate(ref tNode.parent.parent);
                    }
                }
                else if(tNode.parent == tNode.parent.parent.right)
                {
                    if (tNode.parent.parent.left!=null&&tNode.parent.color.Equals("RED") && tNode.parent.parent.left.color.Equals("BLACK") && tNode.parent.right == tNode)
                    {
                        rightRotate(ref tNode);

                        tNode.parent.color = "BLACK";
                        tNode.parent.parent.color = "RED";

                        leftRotate(ref tNode.parent.parent);
                    }
                }
                root.color = "BLACK";
            }
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            RBTree rbt = new RBTree();
            
            for(int i=0;i<100;i++)
            {
                rbt.insert(i + 1);
            }
        }
    }
}
