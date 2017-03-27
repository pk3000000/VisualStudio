using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 4, 6, 7, 8, 9, 10 };
            int num = 7;

            Console.WriteLine(findMid(ref arr, 0, arr.Length, num));
        }


      
        /*
        static void findMid(ref int [] arr, int first, int last, int num)
        {
            int mid = (first + last) / 2;

            if (first > last)
            {
                Console.WriteLine("못 찾았습니다.");
                return;
            }
            
            if(arr[mid] > num)
            {
                findMid(ref arr, first, mid - 1, num);
            }
            else if(arr[mid] < num)
            {
                findMid(ref arr, mid + 1, last, num);
            }
            else if(arr[mid] == num)
            {
                Console.WriteLine("index = {0}", mid);
                return;
            }
        }*/

         
        static int findMid(ref int[] arr, int first, int last, int num)
        {
            int mid = (first + last) / 2;

            if (first > last)
            {
                Console.WriteLine("못 찾았습니다.");
                return int.MinValue;
            }
            else
            {
                if (arr[mid] > num)
                {
                    mid = findMid(ref arr, first, mid - 1, num);
                }
                else if (arr[mid] < num)
                {
                    mid = findMid(ref arr, mid + 1, last, num);
                }
                else if (arr[mid] == num)
                {
                    return mid;
                }
            }
            
            return mid;
        }
        
        static int numIndex(ref int[] arr, int num)
        {
            int first=0, last=arr.Length-1, mid = arr.Length / 2 - 1;

            while(true)
            {
                if(arr[mid]==num)
                {
                    return mid;
                }
                else if(arr[mid] > num)
                {
                    last = mid - 1;
                }
                else if(arr[mid] < num)
                {
                    first = mid + 1;
                }
                
                if(first >= last)
                {
                    break;
                }

                mid = (first + last) / 2;
            }

            Console.WriteLine("못 찾았습니다.");

            return int.MinValue;
        }
    }
}
