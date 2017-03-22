using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication9
{
    class PriorityArrHeap
    {
        int[] arrNum;
        int last;

        public PriorityArrHeap()
        {
            arrNum = new int[100];
            last = -1;
        }

        public PriorityArrHeap(int length)
        {
            arrNum = new int[length];
            last = -1;
        }

        public void insert(int val)
        {
            arrNum[++last] = val;
            int tempNum = last;

            if (tempNum > 0)
            {
                while (true)
                {
                    if (arrNum[tempNum] > arrNum[tempNum / 2])
                    {
                        int temp = arrNum[tempNum];
                        arrNum[tempNum] = arrNum[tempNum / 2];
                        arrNum[tempNum / 2] = temp;

                        if (tempNum / 2 == 0)
                        {
                            break;
                        }

                        tempNum /= 2;
                    }
                    else if (tempNum>1&&arrNum[tempNum] > arrNum[(tempNum / 2 - 1)])
                    {
                        int temp = arrNum[tempNum];
                        arrNum[tempNum] = arrNum[(tempNum / 2 - 1)];
                        arrNum[(tempNum - 1) / 2] = tempNum;

                        if ((tempNum / 2 - 1) == 0)
                        {
                            break;
                        }

                        tempNum /= 2;
                        tempNum -= 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        
        public void print()
        {
            for(int i=0;i<=last;i++)
            {
                Console.WriteLine(arrNum[i]);
            }
        }
        
        public int returnVal()
        {
            int val = arrNum[0];
            int temp = arrNum[last];
            arrNum[last] = arrNum[0];
            arrNum[0] = temp;
            
            return val;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            PriorityArrHeap ph = new PriorityArrHeap();
            ph.insert(2);
            ph.insert(1);
            ph.insert(3);
            ph.insert(5);
            ph.insert(4);
            ph.print();
        }
    }
}
