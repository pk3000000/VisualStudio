using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree
{
    /*
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
        }*/
}
enum Color
{
    Red,
    Black
}

class RB
{
    /// <summary>
    /// Object of type Node contains 4 properties
    /// Colour
    /// Left
    /// Right
    /// Parent
    /// Data
    /// </summary>
    public class Node
    {
        public Color colour;
        public Node left;
        public Node right;
        public Node parent;
        public int data;

        public Node(int data) { this.data = data; }
        public Node(Color colour) { this.colour = colour; }
        public Node(int data, Color colour) { this.data = data; this.colour = colour; }
    }
    /// <summary>
    /// Root node of the tree (both reference & pointer)
    /// </summary>
    private Node root;
    /// <summary>
    /// New instance of a Red-Black tree object
    /// </summary>
    public RB() { }
    /// <summary>
    /// Left Rotate
    /// </summary>
    /// <param name="X"></param>
    /// <returns>void</returns>
    private void LeftRotate(Node X)
    {
        Node Y = X.right; // set Y
        X.right = Y.left;//turn Y's left subtree into X's right subtree
        if (Y.left != null)
        {
            Y.left.parent = X;
        }
        if (Y != null)
        {
            Y.parent = X.parent;//link X's parent to Y
        }
        if (X.parent == null)
        {
            root = Y;
        }
        if (X == X.parent.left)
        {
            X.parent.left = Y;
        }
        else
        {
            X.parent.right = Y;
        }
        Y.left = X; //put X on Y's left
        if (X != null)
        {
            X.parent = Y;
        }

    }
    /// <summary>
    /// Rotate Right
    /// </summary>
    /// <param name="Y"></param>
    /// <returns>void</returns>
    private void RightRotate(Node Y)
    {
        // right rotate is simply mirror code from left rotate
        Node X = Y.left;
        Y.left = X.right;
        if (X.right != null)
        {
            X.right.parent = Y;
        }
        if (X != null)
        {
            X.parent = Y.parent;
        }
        if (Y.parent == null)
        {
            root = X;
        }
        if (Y == Y.parent.right)
        {
            Y.parent.right = X;
        }
        if (Y == Y.parent.left)
        {
            Y.parent.left = X;
        }

        X.right = Y;//put Y on X's right
        if (Y != null)
        {
            Y.parent = X;
        }
    }
    /// <summary>
    /// Display Tree
    /// </summary>
    public void DisplayTree()
    {
        if (root == null)
        {
            Console.WriteLine("Nothing in the tree!");
            return;
        }
        if (root != null)
        {
            InOrderDisplay(root);
        }
    }
    /// <summary>
    /// Find item in the tree
    /// </summary>
    /// <param name="key"></param>
    public Node Find(int key)
    {
        bool isFound = false;
        Node temp = root;
        Node item = null;
        while (!isFound)
        {
            if (temp == null)
            {
                break;
            }
            if (key < temp.data)
            {
                temp = temp.left;
            }
            if (key > temp.data)
            {
                temp = temp.right;
            }
            if (key == temp.data)
            {
                isFound = true;
                item = temp;
            }
        }
        if (isFound)
        {
            Console.WriteLine("{0} was found", key);
            return temp;
        }
        else
        {
            Console.WriteLine("{0} not found", key);
            return null;
        }
    }
    /// <summary>
    /// Insert a new object into the RB Tree
    /// </summary>
    /// <param name="item"></param>
    public void Insert(int item)
    {
        Node newItem = new Node(item);
        if (root == null)
        {
            root = newItem;
            root.colour = Color.Black;
            return;
        }
        Node Y = null;
        Node X = root;
        while (X != null)
        {
            Y = X;
            if (newItem.data < X.data)
            {
                X = X.left;
            }
            else
            {
                X = X.right;
            }
        }
        newItem.parent = Y;
        if (Y == null)
        {
            root = newItem;
        }
        else if (newItem.data < Y.data)
        {
            Y.left = newItem;
        }
        else
        {
            Y.right = newItem;
        }
        newItem.left = null;
        newItem.right = null;
        newItem.colour = Color.Red;//colour the new node red
        InsertFixUp(newItem);//call method to check for violations and fix
    }
    private void InOrderDisplay(Node current)
    {
        if (current != null)
        {
            InOrderDisplay(current.left);
            Console.Write("({0}) ", current.data);
            InOrderDisplay(current.right);
        }
    }
    private void InsertFixUp(Node item)
    {
        //Checks Red-Black Tree properties
        while (item != root && item.parent.colour == Color.Red)
        {
            /*We have a violation*/
            if (item.parent == item.parent.parent.left)
            {
                Node Y = item.parent.parent.right;
                if (Y != null && Y.colour == Color.Red)//Case 1: uncle is red
                {
                    item.parent.colour = Color.Black;
                    Y.colour = Color.Black;
                    item.parent.parent.colour = Color.Red;
                    item = item.parent.parent;
                }
                else //Case 2: uncle is black
                {
                    if (item == item.parent.right)
                    {
                        item = item.parent;
                        LeftRotate(item);
                    }
                    //Case 3: recolour & rotate
                    item.parent.colour = Color.Black;
                    item.parent.parent.colour = Color.Red;
                    RightRotate(item.parent.parent);
                }

            }
            else
            {
                //mirror image of code above
                Node X = null;

                X = item.parent.parent.left;
                if (X != null && X.colour == Color.Black)//Case 1
                {
                    item.parent.colour = Color.Red;
                    X.colour = Color.Red;
                    item.parent.parent.colour = Color.Black;
                    item = item.parent.parent;
                }
                else //Case 2
                {
                    if (item == item.parent.left)
                    {
                        item = item.parent;
                        RightRotate(item);
                    }
                    //Case 3: recolour & rotate
                    item.parent.colour = Color.Black;
                    item.parent.parent.colour = Color.Red;
                    LeftRotate(item.parent.parent);

                }

            }
            root.colour = Color.Black;//re-colour the root black as necessary
        }
    }
    /// <summary>
    /// Deletes a specified value from the tree
    /// </summary>
    /// <param name="item"></param>
    public void Delete(int key)
    {
        //first find the node in the tree to delete and assign to item pointer/reference
        Node item = Find(key);
        Node X = null;
        Node Y = null;

        if (item == null)
        {
            Console.WriteLine("Nothing to delete!");
            return;
        }
        if (item.left == null || item.right == null)
        {
            Y = item;
        }
        else
        {
            Y = TreeSuccessor(item);
        }
        if (Y.left != null)
        {
            X = Y.left;
        }
        else
        {
            X = Y.right;
        }
        if (X != null)
        {
            X.parent = Y;
        }
        if (Y.parent == null)
        {
            root = X;
        }
        else if (Y == Y.parent.left)
        {
            Y.parent.left = X;
        }
        else
        {
            Y.parent.left = X;
        }
        if (Y != item)
        {
            item.data = Y.data;
        }
        if (Y.colour == Color.Black)
        {
            DeleteFixUp(X);
        }

    }
    /// <summary>
    /// Checks the tree for any violations after deletion and performs a fix
    /// </summary>
    /// <param name="X"></param>
    private void DeleteFixUp(Node X)
    {

        while (X != null && X != root && X.colour == Color.Black)
        {
            if (X == X.parent.left)
            {
                Node W = X.parent.right;
                if (W.colour == Color.Red)
                {
                    W.colour = Color.Black; //case 1
                    X.parent.colour = Color.Red; //case 1
                    LeftRotate(X.parent); //case 1
                    W = X.parent.right; //case 1
                }
                if (W.left.colour == Color.Black && W.right.colour == Color.Black)
                {
                    W.colour = Color.Red; //case 2
                    X = X.parent; //case 2
                }
                else if (W.right.colour == Color.Black)
                {
                    W.left.colour = Color.Black; //case 3
                    W.colour = Color.Red; //case 3
                    RightRotate(W); //case 3
                    W = X.parent.right; //case 3
                }
                W.colour = X.parent.colour; //case 4
                X.parent.colour = Color.Black; //case 4
                W.right.colour = Color.Black; //case 4
                LeftRotate(X.parent); //case 4
                X = root; //case 4
            }
            else //mirror code from above with "right" & "left" exchanged
            {
                Node W = X.parent.left;
                if (W.colour == Color.Red)
                {
                    W.colour = Color.Black;
                    X.parent.colour = Color.Red;
                    RightRotate(X.parent);
                    W = X.parent.left;
                }
                if (W.right.colour == Color.Black && W.left.colour == Color.Black)
                {
                    W.colour = Color.Black;
                    X = X.parent;
                }
                else if (W.left.colour == Color.Black)
                {
                    W.right.colour = Color.Black;
                    W.colour = Color.Red;
                    LeftRotate(W);
                    W = X.parent.left;
                }
                W.colour = X.parent.colour;
                X.parent.colour = Color.Black;
                W.left.colour = Color.Black;
                RightRotate(X.parent);
                X = root;
            }
        }
        if (X != null)
            X.colour = Color.Black;
    }
    private Node Minimum(Node X)
    {
        while (X.left.left != null)
        {
            X = X.left;
        }
        if (X.left.right != null)
        {
            X = X.left.right;
        }
        return X;
    }
    private Node TreeSuccessor(Node X)
    {
        if (X.left != null)
        {
            return Minimum(X);
        }
        else
        {
            Node Y = X.parent;
            while (Y != null && X == Y.right)
            {
                X = Y;
                Y = Y.parent;
            }
            return Y;
        }
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
            RB tree = new RB();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(1);
            tree.Insert(9);
            tree.Insert(-1);
            tree.Insert(11);
            tree.Insert(6);
            tree.DisplayTree();
            tree.Delete(-1);
            tree.DisplayTree();
            tree.Delete(9);
            tree.DisplayTree();
            tree.Delete(5);
            tree.DisplayTree();
            Console.ReadLine();
        /*
            RBTree rbt = new RBTree();
           
            for (int i = 0; i < 3; i++)
            {
                rbt.insertNode(ref rbt.root, i+1);
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
            /*
            Derived dv = new Derived();
            dv.BaseMethod();
            */
        }
    
}
