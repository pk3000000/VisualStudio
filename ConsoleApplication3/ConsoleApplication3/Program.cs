using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.
            int price = 5000;

            Console.WriteLine("1. 세일된 가격 : {0}", Sale(price));

            // 2.
            int a = 10;
            int b = 20;
            int c = 30;


            Console.WriteLine("2. 두번째 숫자 : {0}", SecondBigNumber(c, a, b));

            // 3. 1 ~ 10000 자연수 중, 3 or 5 배수들의 합.
            Console.WriteLine("3. 1~10000 자연수 중, 3 또는 5의 배수들의 합 : {0}", ThreeOrFive());

            //4. 정수 배열의 평균 보다 작은 값들의 백분율
            int[] arr = new int[10] { 100, 99, 88, 70, 60, 93, 92, 90, 87, 88 };
            Console.WriteLine("4. 정수 배열의 평균보다 작은 값들의 백분율 : {0}%", UnderAvgPercentage(ref arr));

            //5.
            int[] score = new int[3] { 40, 80, 60 };
            Console.WriteLine("5. 새로운 평균 : {0}", NewAverage(ref score));

            //6.
            string sentence = "the Curious Case of Benjamin Button";
            char[] senC = sentence.ToCharArray();

            Console.WriteLine("6. 단어 수 : {0}", Word(ref senC));

            //7.
            Console.WriteLine("7. Grade : {0}", HakJum(100));

            //8.
            //DayOfTheWeek();

            //9.
            //IntArrayOutput();

            //10.
            //Gugudan();

            //11.
            //Candy();

            //12.
            //Console.WriteLine(Iphone());

            //13.
            //Sugar();

            //14.
            //Page();

            //15.
            //Console.WriteLine(Fel());

            //16.
            int[] numArr = new int[10] { 2, 1, 3, 5, 4, 6, 8, 7, 10, 9 };
            Console.WriteLine(NumberAndSort(numArr, 7));

            //17.
            //FoundAndMissing();

            //18.
            //Console.WriteLine("{0}번 다이아몬드",Mine());

            //19.
            //Console.WriteLine("{0} ",Square());
        }

        // 1.
        public static int Sale(int price)
        {
            return price - (int)(price * 0.2f);
        }

        // 2.
        public static int SecondBigNumber(int num1, int num2, int num3)
        {
            int secondNum = 0;

            if(num1 > num2)
            {
                if(num2 > num3)
                {
                    secondNum = num2;
                }
                else
                {
                    secondNum = num3;
                }
            }
            else
            {
                if(num1 > num3)
                {
                    secondNum = num1;
                }
                else
                {
                    secondNum = num3;
                }
            }

            return secondNum;
        }

        //3.
        public static int ThreeOrFive()
        {
            int sum = 0;

            for(int i=1;i<10001;i++)
            {
                if(i%3==0||i%5==0)
                {
                    sum += i;
                }
            }

            return sum;
        }

        //4.
        public static float UnderAvgPercentage(ref int[] arr)
        {
            float percentage = 0f;
            int sum = 0;
            float avg = 0f;
            int count = 0;

            for(int i=0;i<arr.Length;i++)
            {
                sum += arr[i];
            }

            avg = (float)sum / arr.Length;

            for(int i=0;i<arr.Length;i++)
            {
                if(avg > arr[i])
                {
                    count++;
                }
            }

            percentage = (float)count / arr.Length * 100;

            return percentage;
        }

        //5.
        public static float NewAverage(ref int[] score)
        {
            float sum = 0;
            float newAvg = 0;
            int max = score[0];

            for(int i=1;i<score.Length;i++)
            {
                if(max < score[i])
                {
                    max = score[i];
                }
            }

            for(int i=0;i<score.Length;i++)
            {
                sum += (float)score[i] / max * 100;
            }

            newAvg = sum / score.Length;

            return newAvg;
        }

        //6.
        public static int Word(ref char[] sentence)
        {
            int count = 0;

            for(int i=0;i<sentence.Length;i++)
            {
                if(sentence[i] == ' ')
                {
                    count++;
                }
            }

            return count + 1;
        }

        //7.
        public static char HakJum(int score)
        {
            switch(score/10)
            {
                case 10:
                case 9:
                    return 'A';
                case 8:
                    return 'B';
                case 7:
                    return 'C';
                case 6:
                    return 'D';
                default:
                    return 'F';
            }
        }

        enum week { MON=0,TUE,WED,THU,FRI,SAT,SUN};

        //8.
        public static void DayOfTheWeek()
        {
            string str = "";
            int[] days = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            week vweek = week.MON;
            int sum = 0;
            int x = 0;
            int y = 0;

            Console.Write("월 일을입력하세요:");

            str = Console.ReadLine();

            string[] strArr = str.Split(' ');

            x = Convert.ToInt32(strArr[0]);
            y = Convert.ToInt32(strArr[1]);

            for (int i=0;i<x-1;i++)
            {
                sum += days[i];
            }

            sum += y-1;

            vweek = (week)(sum % 7);

            switch(vweek)
            {
                case week.MON:
                    Console.WriteLine("월요일");
                    break;
                case week.TUE:
                    Console.WriteLine("화요일");
                    break;
                case week.WED:
                    Console.WriteLine("수요일");
                    break;
                case week.THU:
                    Console.WriteLine("목요일");
                    break;
                case week.FRI:
                    Console.WriteLine("금요일");
                    break;
                case week.SAT:
                    Console.WriteLine("토요일");
                    break;
                case week.SUN:
                    Console.WriteLine("일요일");
                    break;
            }
        }

        //9.
        public static void IntArrayOutput()
        {
            Console.Write("숫자를 입력하세요 : ");
            string str = Console.ReadLine();
            string[] strArr = str.Split(' ');
            int[] arr = new int[strArr.Length];
            
            for(int i=0;i<arr.Length;i++)
            {
                arr[i] = Convert.ToInt32(strArr[i]);
            }

            for(int i=0;i<arr.Length;i++)
            {
                Console.Write("{0} ", arr[i]);
                if(i%10==9&&i!=0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }

        //10.
        public static void Gugudan()
        {
            Console.Write("몇단 ? : ");
            string str = Console.ReadLine();
            int dan = Convert.ToInt32(str);

            for(int i=1;i<10;i++)
            {
                Console.WriteLine("{0} * {1} = {2}", dan, i, dan * i);
            }
        }

        //11.
        public static void Candy()
        {
            Console.Write("캔디수와 형제 수 입력 : ");
            string str = Console.ReadLine();
            string[] strArr = str.Split(' ');
            int candy = Convert.ToInt32(strArr[0]);
            int bros = Convert.ToInt32(strArr[1]);

            Console.WriteLine("형제 한명 당 몫 : {0}", candy / bros);
            Console.WriteLine("아부지 몫 : {0}", candy % bros);
        }

        //12.
        public static float Iphone()
        {
            Console.Write("다섯명의 점수를 입력하세요:");
            string str = Console.ReadLine();
            string[] strArr = str.Split(' ');
            int score = 0;
            int sum = 0;
            
            for(int i=0;i<5;i++)
            {
                score = Convert.ToInt32(strArr[i]);

                if(score < 40)
                {
                    score = 40;
                }
                sum += score;
            }

            return (float)sum / 5;
        }

        //13.
        public static void Sugar()
        {
            Console.Write("몇 kg 설탕 필요 : ");
            string str = Console.ReadLine();
            int kg = Convert.ToInt32(str);
            int count = 0;

            count += kg / 5;
            count += (kg % 5) / 3;

            Console.WriteLine("총 {0}포대",count);
        }

        //14.
        public static void Page()
        {
            Console.Write("몇쪽짜리 : ");
            string str = Console.ReadLine();
            string numStr = "";

            int[] numArr = new int[10];
            int page = Convert.ToInt32(str);
           
            for (int i=1;i<=page;i++)
            {
                numStr += String.Format("{0} ", i);
            }

            string[] numStrArr = numStr.Split(' ');
            
            
            for (int i=0;i<numStrArr.Length-1;i++)
            {
                for(int j=0;j<numStrArr[i].Length;j++)
                {
                    numArr[Convert.ToInt32(numStrArr[i][j]+"")]++;
                }
            }

            for(int i=0;i<10;i++)
            {
                Console.Write("{0} ", numArr[i]);
            }
            Console.WriteLine();
            
        }

        //15.
        public static bool Fel()
        {
            Console.Write("앞뒤가 똑같은지 : ");
            string str = Console.ReadLine();

            str = str.ToLower();

            int length = str.Length;
            int half = str.Length / 2;
            bool ok = true;

            for(int i=0;i<half;i++)
            {
                if(str[i] != str[length-1-i])
                {
                    ok = false;
                    break;
                }
            }

            return ok;
        }

        //16.

        public static int NumberAndSort(int[] arr, int k)
        {
            int count = 0;
            
            for (int i=0;i<arr.Length;i++)
            {
                count = 0;

                for(int j=0;j<arr.Length;j++)
                {
                    
                    if(arr[i] >= arr[j])
                    {
                        count++;
                    }
                }
                if (count == k)             // 끝까지 돈 뒤, 몇번째 수인지 확인하여 리턴해 줌.
                {
                    return arr[i];
                }
            }

            return 0;
        }

        //17.
        public static void FoundAndMissing()
        {
            string nemo = "nemo";

            Console.WriteLine("문장 입력 : ");

            string str = Console.ReadLine();
            bool found = false;
            
            for(int i=0;i<str.Length;i++)
            {
                if(str[i]=='n')
                {
                    int k = i;

                    if(str.Length - 1 - k < 4)
                    {
                        break;
                    }

                    int j = 0;

                    while(true)
                    {
                        if(str[k] == nemo[j])
                        {
                            k++;
                            j++;

                            if(j==4)
                            {
                                found = true;
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            if(found)
            {
                Console.WriteLine("found!");
            }
            else
            {
                Console.WriteLine("missing");
            }
        }

        //18.
        public static int Mine()
        {
            Console.Write("R,C : ");
            string str = Console.ReadLine();
            string[] strArr = str.Split(' ');

            int r = Convert.ToInt32(strArr[0]);
            int c = Convert.ToInt32(strArr[1]);

            int[,] mine = new int[r, c];

            Console.Write("광산 입력 : ");

            string[] mineStr = new string[r];

            for(int i=0;i<r;i++)
            {
                mineStr[i] = Console.ReadLine();
            }
            for(int i=0;i<r;i++)
            {
                for(int j=0;j<c;j++)
                {
                    mine[i, j] = Convert.ToInt32(mineStr[i][j]+"");
                }
            }

            // 3

            int count = 0;

            if(r*c >= 9)
            {
                for (int i = 1; i < r-1; i++)
                {
                    
                    for (int j = 1; j < c-1; j++)
                    {
                        count = 0;
                        if (mine[i - 1,j - 1] == 1)
                        {
                            count++;
                        }
                        if (mine[i - 1, j] == 1)
                        {
                            count++;
                        }
                        if (mine[i - 1, j + 1] == 1)
                        {
                            count++;
                        }
                        if (mine[i, j - 1] == 1)
                        {
                            count++;
                        }
                        if (mine[i, j + 1] == 1)
                        {
                            count++;
                        }
                        if (mine[i + 1, j - 1] == 1)
                        {
                            count++;
                        }
                        if (mine[i + 1, j] == 1)
                        {
                            count++;
                        }
                        if (mine[i + 1, j + 1] == 1)
                        {
                            count++;
                        }
                        if(count == 8)
                        {
                            return 3;
                        }
                    }
                }
            }


            // 2
            count = 0;

            if(r * c >= 4)
            {
                for (int i = 0; i < r - 1; i++)
                {
                    
                    for (int j = 0; j < c - 1; j++)
                    {
                        count = 0;
                        if (mine[i, j] == 1)
                        {
                            count++;
                        }
                        if (mine[i, j + 1] == 1)
                        {
                            count++;
                        }
                        if (mine[i + 1, j] == 1)
                        {
                            count++;
                        }
                        if (mine[i + 1, j + 1] == 1)
                        {
                            count++;
                        }
                        if (count == 4)
                        {
                            return 2;
                        }
                    }
                }
            }

            // 1
            count = 0;

            for(int i=0;i<r;i++)
            {
               
                for(int j=0;j<c;j++)
                {
                    count = 0;
                    if (mine[i,j]==1)
                    {
                        return 1;
                    }
                }
            }

            return 0;
        }

        //19.
        public static int Square()
        {
            Console.Write("M,N 입력 : ");
            string str = Console.ReadLine();            // M, N 한줄에 입력. M - row, N - column
            int m = Convert.ToInt32(str[0]+"");
            int n = Convert.ToInt32(str[2]+"");
            int[,] square = new int[m, n];              // 입력 받을 사각형
            int[] s1, s2, s3, s4;

            int size = 0;

            if(m > n)           // 체크할 모서리 길이의 최댓값
            {
                size = n;
            }
            else
            {
                size = m;
            }

            int sero = size - 1;    // check할 모서리의 길이
            int garo = size - 1;    // 정사각형이라 같게.

            s1 = new int[2] { 0, 0 };           // check할 꼭지점의 index
            s2 = new int[2] { 0, garo };
            s3 = new int[2] { sero, 0 };
            s4 = new int[2] { sero, garo };

            Console.WriteLine("광산 입력 : ");

            string[] squareStr = new string[m];

            for (int i = 0; i < m; i++)         // 행 단위로 입력
            {
                squareStr[i] = Console.ReadLine();
            }
            for (int i = 0; i < m; i++)         // int형으로 변환(다루기 쉽게)
            {
                for (int j = 0; j < n; j++)
                {
                    square[i, j] = Convert.ToInt32(squareStr[i][j] + "");
                }
            }

            while(true)
            {
                if(square[s1[0], s1[1]] > 0 && square[s1[0],s1[1]] == square[s2[0], s2[1]] && square[s2[0], s2[1]] == square[s3[0], s3[1]] 
                    && square[s3[0], s3[1]] == square[s4[0], s4[1]])  // 네 모서리 숫자가 같은지 확인.
                {
                    return (garo+1) * (sero+1); // 같으면 넓이를 리턴
                }

                //

                if (s4[0] == m - 1 && s4[1] == n - 1)   // check할 사각형이 맵의 오른쪽 모서리에 도착하면
                {                                       // 가로 세로를 줄이고 맨 왼쪽 상단으로 이동.
                    s1[0] = 0;
                    s1[1] = 0;
                    s2[0] = 0;
                    s2[1] = --garo;
                    s3[0] = --sero;
                    s3[1] = 0;
                    s4[0] = sero;
                    s4[1] = garo;
                }
                else if (s2[1] == n-1)              // 맨 우측에 도달하면 한칸 내리고 맨왼쪽으로 이동.
                {
                    s1[0] += 1;
                    s1[1] = 0;
                    s2[0] += 1;
                    s2[1] += 1;
                    s3[0] += 1;
                    s3[1] = 0;
                    s4[0] += 1;
                    s4[1] = garo;
                }

                if(garo == 0)                       // 길이가 0이면 break;
                {
                    break;
                }
                
                s1[1] += 1;             // 일반적으로는 가로로만 이동.
                s2[1] += 1;
                s3[1] += 1;
                s4[1] += 1;
            }

            return 0;
        }
    }
}
