using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Console.WriteLine(intTostr(-1099));
            //            Console.WriteLine(strToint("-9009"));
            string str = "5*6-3*2";
            Calc cal = new Calc(str);

            Console.WriteLine(cal.getResult());
        }


        static int ten(int zari)
        {
            int num = 1;

            for(int i=0;i<zari;i++)
            {
                num *= 10;
            }

            return num;
        }

        static string intTostr(int num)
        {
            string str = "";
            int zari = 0;
            int temp = 0;
            int n = 0;

            temp = num;

            if(num < 0)
            {
                str += "-";
                num = -num;
            }

            while(true)
            {
                temp /= 10;

                if (temp==0)
                {
                    break;
                }

                zari++;
            }
            
            int[] arr = new int[zari+1];

            temp = num;

            for(int i=0;i<arr.Length;i++)
            {
                if(i==arr.Length-1)
                {
                    arr[i] = temp;
                    break;
                }

                n = ten(zari--);

                arr[i] = temp / n;

                temp %= n;
            }

            for(int i=0;i<arr.Length;i++)
            {
                str += arr[i] + "";
            }

            return str;
        }

        static int strToint(string str)
        {
            int num = 0;
            bool bminus = false;
            string resultStr = "";

            if(str[0]=='-')
            {
                bminus = true;

                for(int i=1;i<str.Length;i++)
                {
                    resultStr += str[i] + "";
                }
            }
            else
            {
                resultStr = str;
            }

            for(int i=0;i<resultStr.Length;i++)
            {
                num += (resultStr[i] - 48) * ten(resultStr.Length - i - 1);
            }

            if(bminus)
            {
                num = -num;
            }

            return num;
        }

        class MyStackInt
        {
            int[] intArr;
            int top;

            public MyStackInt(int size)
            {
                intArr = new int[size];
                top = 0;
            }

            public void Push(int val)
            {
                if(top < intArr.Length)
                {
                    intArr[top++] = val;
                }
                else
                {
                    Console.WriteLine("스택이 꽉 찼습니다.");
                }
            }

            public int Pop()
            {
                if(top > 0)
                {
                    return intArr[--top];
                }
                else
                {
                    Console.WriteLine("스택이 비었습니다.");
                    return int.MinValue;
                }
            }
        }

        class Calc
        {
            int result;

            string resultStr;
            MyStackInt stack;
            
            public Calc(string str)
            {
                result = 0;
                resultStr = str;
                resultStr = infixToPostfix(str);
                stack = new MyStackInt(resultStr.Length);
            }

            string infixToPostfix(string infix)
            {
                char fnum;
                char snum;

                string postfix = "";
                Stack<char> nstack = new Stack<char>();
                Stack<char> cstack = new Stack<char>();

                for (int i = 0; i < infix.Length; i++)
                {
                    if (infix[i] >= '0' && infix[i] <= '9')
                    {
                        nstack.Push(infix[i]);
                    }
                    else if(infix[i]=='*'||infix[i]=='/')
                    {
                        cstack.Push(infix[i]);
                    }
                    else
                    {
                        snum = nstack.Pop();
                        fnum = nstack.Pop();

                        postfix += fnum + "";
                        postfix += snum + "";

                        if (cstack.Count > 0)
                        {
                            while(true)
                            {
                                postfix += cstack.Pop();

                                if(cstack.Count == 0)
                                {
                                    break;
                                }
                            }
                        }

                        cstack.Push(infix[i]);
                        
                    }
                }

                if (nstack.Count > 0)
                {
                    while (true)
                    {
                        postfix += nstack.Pop();

                        if (nstack.Count == 0)
                        {
                            break;
                        }
                    }
                }

                if (cstack.Count > 0)
                {
                    while(true)
                    {
                        postfix += cstack.Pop();

                        if (cstack.Count == 0)
                        {
                            break;
                        }
                    }
                }

                Console.WriteLine(postfix);

                return postfix;
            }

            int calcPostfix()
            {
                int fnum = 0;
                int snum = 0;
                int i = 0;

                while (true)
                {
                    if (resultStr[i] >= '0' && resultStr[i] <= '9')
                    {
                        stack.Push(Convert.ToInt32(resultStr[i++] + ""));
                    }
                    else
                    {
                        snum = stack.Pop();
                        fnum = stack.Pop();

                        switch (resultStr[i++])
                        {
                            case '+':
                                stack.Push(fnum + snum);
                                break;
                            case '-':
                                stack.Push(fnum - snum);
                                break;
                            case '*':
                                stack.Push(fnum * snum);
                                break;
                            case '/':
                                stack.Push(fnum / snum);
                                break;
                        }
                    }
                    if (i == resultStr.Length)
                    {
                        break;
                    }
                }

                return stack.Pop();
            }

            public int getResult()
            {
                result = calcPostfix();
                return result;
            }
        }

        
    }
}
