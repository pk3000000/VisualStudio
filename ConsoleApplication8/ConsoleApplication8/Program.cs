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
                
                if(tempNum/2!=1)
                {
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

                }

                //  Console.WriteLine(temp.count);

                if (temp.count%2==0)
                {
                    tmp.left = temp;
                    temp.parent = tmp;
                }
                else if(temp.count%2==1)
                {
                    tmp.right = temp;
                    tmp.parent = tmp;
                }

                Node tempChange;


                while (true)
                {
                    if(temp.parent == null)
                    {
                        break;
                    }

                    if(temp.parent.val < temp.val)
                    {
                        if(temp.parent.left == temp)
                        {
                            tempChange = temp.parent;
                            tempChange.left = temp.left;
                            temp.left = tempChange;
                            temp.parent = tempChange.parent;
                        }
                        else
                        {
                            tempChange = temp.parent;
                            tempChange.right = temp.right;
                            temp.right = tempChange;
                            temp.parent = tempChange.parent;
                        }
                    }
                    else
                    {
                        if(temp.left == root||temp.right == root)
                        {
                            root = temp;
                        }
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
        //    ph.insert(7);
       //     ph.insert(8);
      //      ph.insert(9);
      //      ph.insert(1);
     //       ph.insert(11);

            ph.PreTravView();
        }
    }
}
