using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class MyQueueInt
    {
        protected int[] arr;
        protected int front;
        protected int rear;
        
        public MyQueueInt(int size)
        {
            arr = new int[size];
            front = -1;
            rear = -1;
        }

        protected MyQueueInt(int size, int front, int rear)
        {
            arr = new int[size];
            this.front = front;
            this.rear = rear;
        }

        public void enqueue(int val)
        {
            if(rear == arr.Length-1)
            {
                Console.WriteLine("꽉 찼습니다.");
            }
            else
            {
                arr[++rear] = val;
            }
        }

        public int dequeue()
        {
            if((rear + 1) % arr.Length == front)
            {
                Console.WriteLine("비었습니다.");
                return int.MinValue;
            }
            else
            {
                return arr[++front];
            }
        }
    }

    class MyCircularQueue : MyQueueInt
    {
        public MyCircularQueue(int size) : base(size)
        {
            arr = new int[size+1];
            front = 0;
            rear = 0;
        }

        public bool isFull()
        {
            if((rear + 1)%arr.Length==0)
            {
                return true;
            }
            return false;
        }

        public bool isEmpty()
        {
            if(rear == front)
            {
                return true;
            }
            return false;
        }

        public new void enqueue(int val)
        {
            if ((rear + 1)%arr.Length==0)
            {
                Console.WriteLine("꽉 찼습니다.");
            }
            else
            {
                rear++;

                if (rear == arr.Length)
                {
                    rear = 0;
                }

                arr[rear] = val;
                
            }
        }
        public new int dequeue()
        {
            if (rear == front)
            {
                Console.WriteLine("비었습니다.");
                return int.MinValue;
            }
            else
            {
                front++;

                if (front == arr.Length)
                {
                    front = 0;
                }

                return arr[front];
            }
        }
        public int nineCount(ref int[] bigArr)
        {
            int count = 0;
            
            int total = 0;
            int index = 0;
            int k = 0;

            for (int i = 0; i < 10; i++)
            {
                enqueue(bigArr[i]);
            }

            k = 10;

            while (true)
            {
                
                if(total == 9)
                {
                    count++;
                    index = 0;

                    if(!isEmpty())
                    {
                        total = dequeue();
                    }
                    else
                    {
                        break;
                    }
                    if(!isFull())
                    {
                        enqueue(bigArr[k++]);
                    }
                }
                else if(total > 9)
                {
                    index = 0; if (!isEmpty())
                    {
                        total = dequeue();
                    }
                    else
                    {
                        break;
                    }
                    if (!isFull())
                    {
                        enqueue(bigArr[k++]);
                    }
                }
                else
                {
                    total += arr[++index];
                }
            }
           
            return count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // MyQueueInt que = new MyQueueInt(3);

            MyCircularQueue cque = new MyCircularQueue(10);
            int[] bigArr = new int[100];
            Random rand = new Random();
            for (int i = 0; i < bigArr.Length; i++)
            {
                bigArr[i] = rand.Next() % 10;
            }

            Console.WriteLine("{0} ",cque.nineCount(ref bigArr));

        }
        
        static bool bracketCheck(string str)
        {
            Stack<char> bstack = new Stack<char>();
            int i = 0;
            char bracket = '\0';

            while(true)
            {
                if(str[i]=='[' || str[i]=='{' || str[i] == '(')
                {
                    bstack.Push(str[i]);
                }
                else if(str[i] == ']')
                {
                    if(bstack.Count == 0)
                    {
                         return false;
                    }
                    else
                    {
                        bracket = bstack.Pop();

                        if(bracket != '[')
                        {
                           return false;
                        }
                    }
                }
                else if(str[i] == '}')
                {
                    if (bstack.Count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        bracket = bstack.Pop();

                        if (bracket != '{')
                        {
                            return false;
                        }
                    }
                }
                else if(str[i] == ')')
                {
                    if (bstack.Count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        bracket = bstack.Pop();

                        if (bracket != '(')
                        {
                            return false;
                        }
                    }
                }
                i++;
                
                if(i==str.Length)
                {
                    break;
                }
            }

            if(bstack.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}
