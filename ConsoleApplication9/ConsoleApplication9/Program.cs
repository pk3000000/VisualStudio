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

        public PriorityArrHeap(ref int [] arr)
        {
            arrNum = new int[arr.Length+1];
            last = -1;
        }

        public void sortArr(ref int [] arr)
        {
            for(int i=0;i<arr.Length;i++)
            {
                insert(arr[i]);
            }
            for(int i=0;i<arr.Length;i++)
            {
                arr[i] = returnVal();
            }
        }

        public void insert(int val)
        {
            arrNum[++last] = val;
            int tempNum = last;

            if (tempNum > 0)
            {
                while (true)
                {
                    if (arrNum[tempNum] < arrNum[tempNum / 2])
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
                    else if (tempNum>1&&arrNum[tempNum] < arrNum[(tempNum / 2 - 1)])
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

            int tempIdx = 0;

            arrNum[last] = arrNum[0];
            arrNum[0] = temp;
            last--;

            if(last >= -1)
            {
                while (true)
                {
                    if ((last >= tempIdx * 2 + 1) && (arrNum[tempIdx] > arrNum[tempIdx * 2 + 1]))
                    {
                        temp = arrNum[tempIdx];
                        arrNum[tempIdx] = arrNum[tempIdx * 2 + 1];
                        arrNum[tempIdx * 2 + 1] = temp;

                        if ((last >= tempIdx * 2 + 2) && (arrNum[tempIdx * 2 + 1] > arrNum[tempIdx * 2 + 2]))
                        {
                            temp = arrNum[tempIdx * 2 + 1];
                            arrNum[tempIdx * 2 + 1] = arrNum[tempIdx * 2 + 2];
                            arrNum[tempIdx * 2 + 2] = temp;
                        }

                        tempIdx = tempIdx * 2 + 1;
                    }
                    else if ((last >= tempIdx * 2 + 2) && (arrNum[tempIdx] > arrNum[tempIdx * 2 + 2]))
                    {
                        temp = arrNum[tempIdx];
                        arrNum[tempIdx] = arrNum[tempIdx * 2 + 2];
                        arrNum[tempIdx * 2 + 2] = temp;

                        if ((last >= tempIdx * 2 + 2) && (arrNum[tempIdx * 2 + 1] > arrNum[tempIdx * 2 + 2]))
                        {
                            temp = arrNum[tempIdx * 2 + 1];
                            arrNum[tempIdx * 2 + 1] = arrNum[tempIdx * 2 + 2];
                            arrNum[tempIdx * 2 + 2] = temp;
                        }

                        tempIdx = tempIdx * 2 + 2;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            
            return val;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 22,43,51,16,37, 11,1,6};
            PriorityArrHeap ph = new PriorityArrHeap(ref arr);

            ph.sortArr(ref arr);

            
            for(int i=0;i<arr.Length;i++)
            {
                Console.Write("{0} ", arr[i]);
            }
            Console.WriteLine();
            
           // ph.print();
            

            //for(int i=0;i<5;i++)
            //{
            //    Console.WriteLine(ph.returnVal());
            //}
            //ph.print();
        }
    }
}
