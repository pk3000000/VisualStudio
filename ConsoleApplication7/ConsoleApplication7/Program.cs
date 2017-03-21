using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class Node
    {
        public int val;
        public Node left;
        public Node right;
    }

    class Node2
    {
        public char val;
        public Node2 left;
        public Node2 right;

        public Node2()
        {
            left = null;
            right = null;
        }

    }

    class BinaryTree
    {
        public Node root;
        public Node2 root2;
        
        public BinaryTree()
        {
            root = null;
            root2 = null;
        }


        public void generate()
        {
            for(int i=0;i<7;i++)
            {
                makeTree(i+1);
            }
        }

        public void generate2()
        {
            Node tmp1 = new Node();
            tmp1.val = 1;
            Node tmp2 = new Node();
            tmp2.val = 2;
            Node tmp3 = new Node();
            tmp3.val = 3;
            Node tmp4 = new Node();
            tmp4.val = 4;
            Node tmp5 = new Node();
            tmp5.val = 5;
            Node tmp6 = new Node();
            tmp6.val = 6;
            Node tmp7 = new Node();
            tmp7.val = 7;

            root = tmp1;
            tmp1.left = tmp2;
            tmp1.right = tmp3;
            tmp2.left = tmp4;
            tmp2.right = tmp5;
            tmp4.left = null;
            tmp4.right = null;
            tmp5.left = null;
            tmp5.right = null;
            tmp3.left = tmp6;
            tmp3.right = tmp7;
            tmp6.left = null;
            tmp6.right = null;
            tmp7.left = null;
            tmp7.right = null;
        }

        public void makeTree(int num)
        {
            if(root == null)
            {
                root = new Node();
                root.val = num;
            }
            else
            {
                makeTree(ref root, num);
            }
        }

        public void makeTree(ref Node temp,int num)
        {
           
           if(temp.val == num / 2)
           {
                if (temp.left == null)
                {
                    temp.left = new Node();
                    temp.left.val = num;
                }
                else
                {
                    makeTree(ref temp.left, num);
                }
            }
            else
            {
                if (temp.right == null)
                {
                    temp.right = new Node();
                    temp.right.val = num;
                }
                else
                {
                    makeTree(ref temp.right, num);
                }
            }
        }

        void preOrder(ref Node temp)
        {
            if(temp == null)
            {
                return;
            }

            Console.Write("{0} ", temp.val);
            preOrder(ref temp.left);
            preOrder(ref temp.right);
        }

        public void preOrderView()
        {
            preOrder(ref root);
        }

        void InOrder(ref Node temp)
        {
            if (temp == null)
            {
                return;
            }
            
            InOrder(ref temp.left);
            Console.Write("{0} ", temp.val);
            InOrder(ref temp.right);
        }

        public void InOrderView()
        {
            InOrder(ref root);
        }

        void PostOrder(ref Node2 temp)
        {
            if (temp == null)
            {
                return;
            }
            
            PostOrder(ref temp.left);
            PostOrder(ref temp.right);
            Console.Write("{0} ", temp.val);
        }

        public void  PostOrder2(ref Node2 temp, ref Node2 insert)
        {

            Node2 tmp = PostOrderTrav(ref temp);

            if(temp.left == null)
            {
                temp.left = insert;
            }
            else if(temp.right == null)
            {
                temp.right = insert;
            }

        }

        public Node2 PostOrderTrav(ref Node2 temp)
        {
            if (temp == null)
            {
                return null;
            }
            if (temp.left == null && temp.right == null)
            {
                return temp;
            }
            else 
            {
                PostOrderTrav(ref temp.left);
                PostOrderTrav(ref temp.right);
                return temp;
            }
           
        }
        
        public int PostOrder3(ref Node2 temp)
        {
            if (temp == null)
            {
                return 0;
            }
            if(temp.left == null && temp.right == null)
            {
                return temp.val-48;
            }
            else
            {
                int op1 = PostOrder3(ref temp.left);
                int op2 = PostOrder3(ref temp.right);

                switch(temp.val)
                {
                    case '+':
                        return op1 + op2;
                    case '-':
                        return op1 - op2;
                    case '*':
                        return op1 * op2;
                    case '/':
                        return op1 / op2;
                }
            }
            return 0;
        }

        public void PostOrderView()
        {
            PostOrder(ref root2);
        }

        public int CalcString(ref Node2 temp)
        {
            return 0;
        }
        
        public void makeCalcTree(string str)
        {
            Node2 [] temp = new Node2[str.Length / 2 + 1];
            Node2 [] tempRoot = new Node2[str.Length / 2];

            for(int i=0;i<temp.Length;i++)
            {
                temp[i] = new Node2();
                temp[i].val = str[i * 2];
            }
            for (int i = 0; i < tempRoot.Length; i++)
            {
                tempRoot[i] = new Node2();
                tempRoot[i].val = str[i * 2 + 1];
            }

           
           
            for (int i = 0; i < tempRoot.Length; i++)
            {
                if(i == 0 && (tempRoot[i].val == '*' || tempRoot[i].val == '/'))
                {
                    tempRoot[i + 1].left = tempRoot[i];
                }
                else if ((tempRoot[i].val=='*'||tempRoot[i].val=='/'))
                {
                    
                    tempRoot[i - 1].right = tempRoot[i];
                    
                }
                else if(i==0 && (tempRoot[i].val == '+'||tempRoot[i].val == '-'))
                {

                }
                else if((tempRoot[i].val == '+' || tempRoot[i].val == '-'))
                {

                }
            }

            root2 = tempRoot[tempRoot.Length-1];


            PostOrder(ref root2);


            for (int i=0;i<temp.Length;i++)
            {
                //Console.WriteLine(temp[i].val);
                PostOrder2(ref root2, ref temp[i]);
            }
                
            
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree bt = new BinaryTree();
            //bt.generate();
            bt.makeCalcTree("2+3*4-6+1");
            bt.PostOrderView();
            Console.WriteLine(bt.PostOrder3(ref bt.root2));
        }
    }
}
