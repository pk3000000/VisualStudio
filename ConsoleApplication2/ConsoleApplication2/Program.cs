using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            float line1_start = 3;
            float line1_end = 1;
            float line2_start = 2;
            float line2_end = 5;

            float temp = 0;

            if(line1_start > line1_end)
            {
                temp = line1_start;
                line1_start = line1_end;
                line1_end = temp;
            }

            if ((line1_end < line2_start) && (line1_end < line2_end))
            {
                Console.WriteLine("안겹친다");
            }
            else if ((line1_start > line2_start) && (line1_start > line2_end))
            {
                Console.WriteLine("안겹친다");
            }
            else
            {
                Console.WriteLine("겹친다");
            }*/
            /*
            for (int i = 0; i < 5; i++)
            {
            
                for (int j = 0; j < i+1; j++)
                {
                    Console.Write("*");
                }
                for(int j = 0; j < 5-i-1;j++)
                {
                    Console.Write(" ");
                }
                for(int j = 0; j < 5 - i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            
            for (int i = 0; i < 5; i++)
            {
                for(int j=0;j<5-i;j++)
                {
                    Console.Write(" ");
                }
                for(int j=0;j<i+1;j++)
                {
                    Console.Write("*");
                }
                for(int j=0;j<i;j++)
                {
                    Console.Write(" ");
                }
                for(int j=5-i;j>0;j--)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            */
            /*
            int num = 0;
            int fnum = 1;
            int snum = 1;
            int sum = 1;

            Console.Write("몇번째? : ");
            num = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i < num-2; i++)
            {
                sum = fnum + snum;
                fnum = snum;
                snum = sum;
            }

            Console.WriteLine("{0}번째 피보나치 수는 : {1}",num, sum);
            */
            /*
            int fnum = 1;
            int snum = 1;
            int result = 1;
            int num = 20;

            for(int i=0;i<num-2;i++)
            {
                result = fnum + snum;
                fnum = snum;
                snum = result;
            }

            Console.WriteLine(result);
            */
            /*
            int[] oddNum = new int[50];
            int j = 0;

            for(int i=1;i<100;i++)
            {
                if(i%2==1)
                {
                    oddNum[j++] = i;
                }
            }

            for(int i=0;i<50;i++)
            {
                Console.Write("{0} ", oddNum[i]);
            }
            Console.WriteLine();
            */

            //int[] score = new int[20] { 80, 74, 81, 90, 34, 84, 76, 95, 45, 66, 74, 82, 76, 57, 51, 88, 73, 98, 51, 60 };

            //int bigNum = score[0];
            //int smallNum = 0;
            //int smallIdx = 0;
            //int temp = 0;

            /*
            for(int i=1;i<20;i++)
            {
                if(bigNum < score[i])
                {
                    bigNum = score[i];
                }
            }

            for(int i=1;i<20;i++)
            {
                if(smallNum > score[i])
                {
                    smallNum = score[i];
                }
            }

            Console.WriteLine("최대값 : {0}",bigNum);
            Console.WriteLine("최소값 : {0}", smallNum);
            */

            // selection sort
            /*
            for (int i=0;i<20;i++)
            {
                smallNum = score[i];
                smallIdx = i;

                for (int j = i; j < 20; j++)
                {
                    if(smallNum > score[j])
                    {
                        smallNum = score[j];
                        smallIdx = j;
                    }
                }
                temp = score[i];
                score[i] = score[smallIdx];
                score[smallIdx] = temp;
            }
            */

            // bubble sort
            /*
            for(int i=score.Length-1;i>=0;i--)
            {
                for(int j=0;j<i;j++)
                {
                    if(score[j] > score[j+1])
                    {
                        temp = score[j];
                        score[j] = score[j+1];
                        score[j + 1] = temp;
                    }
                }
            }

            for(int i=0;i<20;i++)
            {
                Console.Write("{0} ", score[i]);
            }
            Console.WriteLine();
            */
            // merge sort
            
            int[] arr1 = new int[] { 3, 4, 7, 10, 15, 19, 23, 25, 26, 27 };
            int[] arr2 = new int[] { 1, 2, 5, 20, 28, 30, 31, 32, 33, 43 };
            int[] arr3 = new int[20] { 3, 4, 7, 10, 15, 19, 23, 25, 26, 27, 1, 2, 5, 20, 28, 30, 31, 32, 33, 43 };

            MergeSort(ref arr3, 0,arr3.Length/2, arr3.Length);

            for(int i=0;i<arr3.Length;i++)
            {
                Console.Write("{0} ", arr3[i]);
            }
            Console.WriteLine();

            /*
            int idx1 = 0;
            int idx2 = 0;
            
            for(int i=0;i<arr3.Length;i++)
            {
                if(idx1 != arr1.Length && idx2 != arr2.Length)
                {
                    if (arr1[idx1] < arr2[idx2])
                    {
                        arr3[i] = arr1[idx1++];
                    }
                    else
                    {
                        arr3[i] = arr2[idx2++];
                    }
                }
                else
                {
                    if (idx1 < arr1.Length)
                    {
                        arr3[i] = arr1[idx1++];
                    }
                    else
                    {
                        arr3[i] = arr2[idx2++];
                    }
                }
            }

            for (int i = 0; i < 20; i++)
            {
                Console.Write("{0} ", arr3[i]);
            }
            Console.WriteLine();
            */
            /*
            int x = 3;
            int y = 4;
            
            Console.WriteLine("{0},{1}", x, y);
            Swap(ref x, ref y);
            Console.WriteLine("{0},{1}", x, y);*/

            // int[] score = new int[20] { 80, 74, 81, 90, 34, 84, 76, 95, 45, 66, 74, 82, 76, 57, 51, 88, 73, 98, 51, 60 };

            // Merge(ref score);

            //reverse(ref score);

            /*
            for (int i=0;i<score.Length;i++)
            {
                Console.Write("{0} ",score[i]);
            }
            Console.WriteLine();
            */

            //Hanoi(3, 'A', 'B', 'C');

            //Console.WriteLine(plus(1.2f,1.3f));
        }

        public static int plus(int a, int b)
        {
            return a + b;
        }
        public static long plus(long a, long b)
        {
            return a + b;
        }
        public static float plus(float a, float b)
        {
            return a + b;
        }
        public static double plus(double a, double b)
        {
            return a + b;
        }

        public static void Swap(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }

        public static void reverse(ref int[] arr)
        {
            int front = 0;
            int rear = arr.Length - 1;

            while(true)
            {
                Swap(ref arr[front++], ref arr[rear--]);

                if(front >= rear)
                {
                    break;
                }
            }
        }

        public static int fibo(int num)
        {
            if(num == 0)
            {
                return 0;
            }
            else if(num == 1)
            {
                return 1;
            }
            else if(num == 2)
            {
                return 1;
            }

            return fibo(num - 1) + fibo(num - 2);
        }

        /*
        public static void Merge(ref int[] arr)
        {
            if(arr.Length < 2)
            {
                return;
            }

            int[] first = new int[arr.Length / 2];
            Array.Copy(arr, 0, first, 0, arr.Length / 2);

            int[] last = new int[arr.Length-arr.Length / 2];
            Array.Copy(arr, arr.Length/2, last, 0,arr.Length-arr.Length / 2);

            Merge(ref first);
            Merge(ref last);
            MergeSort(ref first,ref last, ref arr);
        }
        */

        public static void Merge(ref int[] arr)
        {

        }

        /*
        public static void Merge(ref int[] arr)
        {
            int count = 0;
            int arrNum = arr.Length;

            while(true)
            {
                arrNum /= 2;

                count++;

                if (arrNum < 2)
                {
                    count--;
                    break;
                }
            }

            int i = 0;
            int[][] tempArr1;
            int[][] tempArr2;
            int zegob = 2;
            bool bTemp = false;

            tempArr1 = new int[1][];

            tempArr1[0] = new int[arr.Length];

            Array.Copy(arr, tempArr1[0], arr.Length);

            while (true)
            {
                tempArr2 = new int[zegob][];

                for(int j=0;j<zegob;j+=2)
                {
                    tempArr2[j] = new int[tempArr1[j/2].Length / 2];
                    Array.Copy(tempArr1[j / 2], 0, tempArr2[j], 0, tempArr1[j/2].Length / 2);

                    if(tempArr2[j].Length == 2)
                    {
                        SelectionSort(tempArr2[j]);
                    }

                    tempArr2[j + 1] = new int[tempArr1[j/2].Length - tempArr1[j/2].Length / 2];
                    Array.Copy(tempArr1[j / 2], tempArr1[j/2].Length / 2, tempArr2[j + 1], 0, tempArr1[j / 2].Length - tempArr1[j / 2].Length / 2);

                    if (tempArr2[j].Length == 2)
                    {
                        SelectionSort(tempArr2[j+1]);
                    }

                }

                zegob *= 2;
                i++;

                if(i == count)
                {
                    bTemp = true;
                    break;
                }

                tempArr1 = new int[zegob][];

                for (int j = 0; j < zegob; j += 2)
                {
                    tempArr1[j] = new int[tempArr2[j/2].Length / 2];
                    Array.Copy(tempArr2[j/2], 0, tempArr1[j], 0, tempArr2[j/2].Length / 2);

                    if (tempArr1[j].Length == 2)
                    {
                        SelectionSort(tempArr1[j]);
                    }

                    tempArr1[j + 1] = new int[tempArr2[j/2].Length - tempArr2[j/2].Length / 2];
                    Array.Copy(tempArr2[j/2], tempArr2[j / 2].Length / 2, tempArr1[j + 1], 0, tempArr2[j/2].Length - tempArr2[j/2].Length / 2);

                    if (tempArr1[j].Length == 2)
                    {
                        SelectionSort(tempArr1[j + 1]);
                    }
                }

                zegob *= 2;
                i++;

                if (i == count)
                {
                    break;
                }
            }
            
            bTemp = false;
            zegob /= 2;

            if (bTemp)
            {
                while (true)
                {
                    zegob /= 2;

                    tempArr2 = new int[zegob][];

                    for (int j = 0; j < zegob; j++)
                    {
                        tempArr2[j] = new int[(tempArr1[j*2].Length + tempArr1[(j*2) + 1].Length) / 2];
                        MergeSort(ref tempArr1[j*2], ref tempArr1[(j*2) + 1], ref tempArr2[j]);
                    }

                    if (zegob == 1)
                    {
                        break;
                    }

                    zegob /= 2;
                    
                    tempArr1 = new int[zegob][];

                    for (int j = 0; j < zegob; j++)
                    {
                        tempArr1[j] = new int[(tempArr2[j*2].Length + tempArr2[(j*2) + 1].Length) / 2];
                        MergeSort(ref tempArr2[j*2], ref tempArr2[(j*2) + 1], ref tempArr1[j]);
                    }

                    if (zegob == 1)
                    {
                        bTemp = true;
                        break;
                    }
                }
            }
            else // check
            {
                while (true)
                {
                    zegob /= 2;
                    
                    tempArr1 = new int[zegob][];

                    for (int j = 0; j < zegob; j++)
                    {
                        tempArr1[j] = new int[tempArr2[(j*2)].Length + tempArr2[(j*2) + 1].Length];
                        MergeSort(ref tempArr2[(j*2)], ref tempArr2[(j*2) + 1], ref tempArr1[j]);
                    }

                    if (zegob == 1)
                    {
                        bTemp = true;
                        break;
                    }

                    zegob /= 2;
                    
                    tempArr2 = new int[zegob][];

                    for (int j = 0; j < zegob; j++)
                    {
                        tempArr2[j] = new int[tempArr1[(j*2)].Length + tempArr1[(j*2) + 1].Length];
                        MergeSort(ref tempArr1[j*2], ref tempArr1[(j*2) + 1], ref tempArr2[j]);
                    }

                    if (zegob == 1)
                    {
                        break;
                    }
                }
            }
            
            if(bTemp)
            {
                Array.Copy(tempArr1[0], arr, arr.Length);
            }
            else
            {
                Array.Copy(tempArr2[0], arr, arr.Length);
            }
        }
        */
        /*
        public static void MergeSort(ref int[] arr1, ref int[] arr2, ref int[] arr)
        {
            int idx1 = 0;
            int idx2 = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (idx1 != arr1.Length && idx2 != arr2.Length)
                {
                    if (arr1[idx1] < arr2[idx2])
                    {
                        arr[i] = arr1[idx1++];
                    }
                    else
                    {
                        arr[i] = arr2[idx2++];
                    }
                }
                else
                {
                    if (idx1 < arr1.Length)
                    {
                        arr[i] = arr1[idx1++];
                    }
                    else
                    {
                        arr[i] = arr2[idx2++];
                    }
                }
            }
        }
        */

        public static void MergeSort(ref int[] arr, int left, int mid, int right)
        {
            int idx1 = 0;
            int idx2 = 0;

            int[] arr1 = new int[mid];
            int[] arr2 = new int[right-mid];

            Array.Copy(arr, 0, arr1, 0, mid);
            Array.Copy(arr, mid, arr2, 0, right-mid);

            for (int i = 0; i < arr.Length; i++)
            {
                if (idx1 != mid && idx2 != right-mid)
                {
                    if (arr1[idx1] < arr2[idx2])
                    {
                        arr[i] = arr1[idx1++];
                    }
                    else
                    {
                        arr[i] = arr2[idx2++];
                    }
                }
                else
                {
                    if (idx1 < mid)
                    {
                        arr[i] = arr1[idx1++];
                    }
                    else
                    {
                        arr[i] = arr2[idx2++];
                    }
                }
            }
        }
        public static void SelectionSort(int[] arr)
        {
            int smallNum = 0;
            int smallIdx = 0;
            int temp = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                smallNum = arr[i];
                smallIdx = i;

                for (int j = i; j < arr.Length; j++)
                {
                    if (smallNum > arr[j])
                    {
                        smallNum = arr[j];
                        smallIdx = j;
                    }
                }
                temp = arr[i];
                arr[i] = arr[smallIdx];
                arr[smallIdx] = temp;
            }
        }
        
        public static void Hanoi(int num, char left, char mid, char right)
        {
            if(num == 1)
            {
                Console.WriteLine("1번을 {0}에서 {1}로 옮긴다",left,right);
                return;
            }
            else
            {
                Hanoi(num - 1, left, right, mid);
                Console.WriteLine("{0}을 {1}에서 {2}로 옮긴다", num, left, right);
                Hanoi(num - 1, mid, left, right);
            }
        }
    }
}
