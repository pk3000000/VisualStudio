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
    }

    class Box
    {
        public int val;
        public int index;
    }

    class MyStackInt
    {
        int idx;
        Box[]  arr;

        public MyStackInt()
        {
            arr = new Box[10];
            idx = -1;
        }

        public void Push(int val)
        {
            if (idx == arr.Length - 1)
            {
                Box[] temp = new Box[arr.Length * 2];
                
                for(int i=0;i<arr.Length;i++)
                {
                    temp[i] = arr[i];
                }

                arr = temp;
            }

            if (idx == -1)
            {
                idx++;
                arr[idx] = new Box();
                arr[idx].val = val;
                arr[idx].index = -1;
            }
            else 
            {
                arr[idx].index = ++idx;
                arr[idx] = new Box();
                arr[idx].val = val;
                arr[idx].index = -1;
            }
        }

        public int Pop()
        {
            int curValue = 0;

            if (idx == -1)
            {
                Console.WriteLine("비었습니다.");
                return int.MinValue;
            }
            else
            {
                curValue = arr[idx].val;
                idx--;
                if(idx != -1)
                {
                    arr[idx].index = -1;
                }
            }
            return curValue;
        }
    }

    class MyQueueInt
    {
        int head;
        int tail;
        Box[] arr;
        public MyQueueInt()
        {
            head = -1;
            tail = -1;
            arr = new Box[10];
        }

        public void enqueue(int val)
        {
            if (tail == arr.Length - 1)
            {
                Box[] temp = new Box[arr.Length * 2];

                int j = 0;

                for (int i = head; i <= tail; i++)
                {
                    temp[j++] = arr[i];
                }
                arr = temp;
            }
            if (head == -1 || head > tail)
            {
                if(head == -1)
                {
                    head++;
                }
                tail++;

                arr[tail] = new Box();
                arr[tail].val = val;
                arr[tail].index = -1;
            }
            else
            {
                arr[tail].index = tail++;
                arr[tail] = new Box();
                arr[tail].val = val;
                arr[tail].index = -1;
            }
        }

        public int dequeue()
        {
            int curValue = 0;
            
            if(head == -1 || head > tail)
            {
                Console.WriteLine("비었습니다.");
                return int.MinValue;
            }
            else
            {
                curValue = arr[head].val;
                head++;
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

    class LastK
    {
        Node head;

        public LastK()
        {
            head = null;
        }

        public void generate()
        {
            for(int i=1;i<11;i++)
            {
                insert(i);
            }
        }

        public void insert(int val)
        {
            if(head == null)
            {
                head = new Node();
                head.val = val;
                head.next = null;
            }
            else
            {
                Node temp = head;

                while(true)
                {
                    if(temp.next == null)
                    {
                        break;
                    }
                    temp = temp.next;
                }
                temp.next = new Node();
                temp.next.val = val;
                temp.next.next = null;
            }
        }

        public void print()
        {
            Node temp = head;

            if(temp != null)
            {
                while(true)
                {
                    if(temp == null)
                    {
                        break;
                    }
                    Console.WriteLine(temp.val);
                    temp = temp.next;
                }
            }
        }

        public int returnK(int k)
        {
            if(k <= 0)
            {
                Console.WriteLine("범위를 벗어난 값입니다.");
                return int.MinValue;
            }
            
            Node temp = head;
            Node ktemp = head;
            int count = 0;

            while(true)
            {
                if(temp == null)
                {
                    break;
                }
               
                temp = temp.next;

                count++;

                if (count > k)
                {
                    ktemp = ktemp.next;
                }
            }

            if(ktemp == head&& count < k)
            {
                Console.WriteLine("범위를 벗어난 값입니다.");
                return int.MinValue;
            }

            return ktemp.val;
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

            //MyStackInt si = new MyStackInt();
            /*
            MyQueueInt si = new MyQueueInt();

            for(int i=0;i<20;i++)
            {
                si.enqueue(i + 1);
            }

            for(int i=0;i<20;i++)
            {
                Console.WriteLine(si.dequeue());
            }

            for (int i = 0; i < 20; i++)
            {
                si.enqueue(i + 1);
            }

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(si.dequeue());
            }*/

            LastK L = new LastK();
            L.generate();
            Console.WriteLine(L.returnK(10));
        }
    }
}
