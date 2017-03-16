using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Node
    {
        public int val;
        public Node next;
        public Node prev;
    }

    class MyStackInt
    {
        Node head;
        Node  top;

        public MyStackInt()
        {
            head = null;
            top = null;
        }

        public void Push(int val)
        {
            if (head == null)
            {
                head = new Node();
                head.val = val;
                head.next = null;
                head.prev = null;
                top = head;
            }
            else
            {
                top.next = new Node();
                top.next.prev = top;
                top = top.next;
                top.val = val;
                top.next = null;
            }
        }

        public int Pop()
        {
            int curValue = 0;

            if (head == null)
            {
                Console.WriteLine("비었습니다.");
                return int.MinValue;
            }
            else
            {
                curValue = top.val;

                if (top.prev != null)
                {
                    top = top.prev;
                }
                else
                {
                    head = null;
                    top = null;
                }
            }
            return curValue;
        }
    }

    class MyQueueInt
    {
        Node head;
        Node tail;

        public MyQueueInt()
        {
            head = null;
            tail = null;
        }
        
        public void enqueue(int val)
        {
            if (head == null)
            {
                head = new Node();
                tail = head;
                tail.val = val;
            }
            else
            {
                tail.next = new Node();
                tail = tail.next;
                tail.val = val;
            }
        }

        public int dequeue()
        {
            int curValue = 0;
            Node tmp;

            if(head == null)
            {
                Console.WriteLine("비었습니다.");
                return int.MinValue;
            }
            else
            {
                tmp = head;
                head = head.next;
                curValue = tmp.val;
                tmp.next = null;
            }

            return curValue;
        }
    }

    class InsertionSort
    {
        Node head;

        public InsertionSort()
        {
            head = null;
        }

        public void print()
        {
            if(head != null)
            {
                Node temp = head;

                for(;temp!=null;)
                {
                    Console.Write("{0} ", temp.val);
                    temp = temp.next;
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("비었습니다.");
            }
        }

        public void sort(ref int[] arr)
        {
            Node temp = null;
            
            for(int i=0;i<arr.Length;i++)
            {
                if(head == null)
                {
                    head = new Node();
                    head.val = arr[i];
                    head.next = null;
                }
                else
                {
                    temp = head;
                    Node newNode = new Node();
                    newNode.val = arr[i];
                    newNode.next = null;
      
                    if(head.next == null)
                    {
                        if(head.val > newNode.val)
                        {
                            newNode.next = head;
                            head = newNode;
                        }
                        else
                        {
                            head.next = newNode;
                        }
                        print();
                    }
                    else
                    {
                        if(head.val >= newNode.val)
                        {
                            newNode.next = head;
                            head = newNode;
                        }
                        else
                        {
                            for (; temp != null;)
                            {
                                if(temp.next == null)
                                {
                                    temp.next = newNode;
                                    break;
                                }
                                else
                                {
                                    if (temp.val <= newNode.val && temp.next.val >= newNode.val)
                                    {
                                        newNode.next = temp.next;
                                        temp.next = newNode;
                                        break;
                                    }
                                    else if (temp.next.val < newNode.val)
                                    {
                                        temp = temp.next;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // int[] arr = new int[10] { 2, 1, 3, 5, 4, 9, 8, 7, 6, 10 };
            // InsertionSort si = new InsertionSort();
            // si.sort(ref arr);
            // si.print();

            MyStackInt si = new MyStackInt();
            //MyQueueInt si = new MyQueueInt();

            for(int i=0;i<10;i++)
            {
                si.Push(i + 1);
            }

            for(int i=0;i<10;i++)
            {
                Console.WriteLine(si.Pop());
            }
        }
    }
}
