using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node parent;
        public int count;

        public Node()
        {
            count = 0;
            val = 0;
            left = null;
            right = null;
            parent = null;
        }

        public Node(int val)
        {
            count = 0;
            this.val = val;
            left = null;
            right = null;
            parent = null;
        }
    }
    class PriorityHeap
    {
        Node root;
        Node tail;
        int[] loute;
        static int num = 0;

        public PriorityHeap()
        {
            loute = new int[100];
            root = null;
            tail = null;
        }

        public void insert(int val)
        {
            Node temp = new Node(val);
            temp.count = ++PriorityHeap.num;

            Node tmp = root;


            if(root == null)
            {
                root = temp;
                tail = temp;
            }
            else
            {
                int tempNum = temp.count;

                for(int k = 0;k<loute.Length;k++)
                {
                    loute[k] = 0;
                }

                int i = 0;
                
                
                while (true)
                {
                    loute[i] = (tempNum /= 2);

                    i++;

                    if (tempNum == 1)
                    {
                        break;
                    }

                }
                
                for (int j = i - 2; j >= 0; j--)
                {
                    //   Console.WriteLine(loute[j]);

                    if (loute[j] % 2 == 0)
                    {
                        tmp = tmp.left;
                    }
                    else
                    {
                        tmp = tmp.right;
                    }
                }

                Node tempChange1;
                Node tempChange2;

                //  Console.WriteLine(temp.count);

                if (temp.count%2==0)
                {
                    tmp.left = temp;
                    temp.parent = tmp;
                }
                else if(temp.count%2==1)
                {
                    tmp.right = temp;
                    temp.parent = tmp;
                }
                
                
                while (true)
                {
                    if(temp.parent == null)
                    {
                        root = temp;
                        break;
                    }

                    if(temp.parent.val < temp.val)
                    {
                        if (temp.parent.left == temp)
                        {
                            temp.parent.left = temp.left;
                            temp.parent.right = temp.right;
                            temp.left = temp.parent;

                            tempChange1 = temp.parent.parent;
                            temp.left.parent = temp;
                            temp.parent = tempChange1;
                        }
                        else if (temp.parent.right == temp)
                        {
                            tempChange1 = temp.right;
                            tempChange2 = temp.left;
                            temp.right = temp.parent;
                            temp.left = temp.parent.left;
                            temp.parent.left = tempChange2;
                            temp.parent.right = tempChange1;

                            tempChange1 = temp.parent.parent;
                            temp.right.parent = temp;
                            temp.parent = tempChange1;

                            if (temp.parent == root)
                            {
                                root = temp;
                                temp.parent = null;
                            }
                        }
                    }
                    else if(temp.parent.val >= temp.val)
                    {
                        break;
                    }
                }
                
            }
        }


        public void PreTravView()
        {
           // Console.WriteLine(root.right.left.val);
            PreTrav(ref root);
        }

        public void PreTrav(ref Node temp)
        {
            
            if(temp == null)
            {
                return;
            }

            Console.WriteLine(temp.val);
            PreTrav(ref temp.left);
            PreTrav(ref temp.right);
         }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PriorityHeap ph = new PriorityHeap();
            ph.insert(2);
            ph.insert(5);
            ph.insert(7);
            ph.insert(8);
          //  ph.insert(9);
          //  ph.insert(1);
          //  ph.insert(11);

            ph.PreTravView();
        }
    }
}
