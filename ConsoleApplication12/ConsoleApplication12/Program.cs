using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication12
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 5, 8, 11, 7, 6, 1, 4, 3,9 };
            quickSort(ref arr, 0, arr.Length-1);

            for(int i=0;i<arr.Length;i++)
            {
                Console.Write("{0} ", arr[i]);
            }
            Console.WriteLine();
        }

        static void quickSort(ref int[] arr,int start, int end)
        {

            if (start < end)
            {
                int left = start;
                int right = end;

                int pivot = (start + end) / 2-1;

                while (left < right)
                {
                    while (arr[right] > arr[pivot])
                    {
                        right--;
                    }
                    while (left < right && arr[left] <= arr[pivot])
                    {
                        left++;
                    }

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }

                int temp1 = arr[pivot];
                arr[pivot] = arr[left];
                arr[left] = temp1;
               
                quickSort(ref arr, start, left-1);
                quickSort(ref arr, left + 1, end);
            }
        }
    }
}
