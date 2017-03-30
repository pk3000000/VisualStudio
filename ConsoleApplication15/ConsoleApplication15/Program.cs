using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication15
{
    class Vector2
    {
        public static int count = 0;
        float x;
        float y;

        public Vector2()
        {
            x = 0.0f;
            y = 0.0f;
            count++;
        }

        public Vector2(float _x, float _y)
        {
            x = _x;
            y = _y;
            count++;
        }

        public Vector2(Vector2 _vec):this(_vec.x,_vec.y)
        {
        }

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }
        
        public static Vector2 operator + (Vector2 _vec1, Vector2 _vec2)
        {
            return new Vector2(_vec1.x + _vec2.x, _vec1.y + _vec2.y);
        }

        public static Vector2 operator - (Vector2 _vec1, Vector2 _vec2)
        {
            return new Vector2(_vec1.x - _vec2.x, _vec1.y - _vec2.y);
        }

        public static Vector2 operator * (Vector2 _vec1, Vector2 _vec2)
        {
            return new Vector2(_vec1.x * _vec2.x, _vec1.y * _vec2.y);
        }

        public static Vector2 operator / (Vector2 _vec1, Vector2 _vec2)
        {
            return new Vector2(_vec1.x / _vec2.x, _vec1.y / _vec2.y);
        }

        public static bool operator == (Vector2 _vec1, Vector2 _vec2)
        {
            return (_vec1.x == _vec2.x && _vec1.y == _vec2.y);
        }
        
        public static bool operator != (Vector2 _vec1, Vector2 _vec2)
        {
            return (_vec1.x != _vec2.x || _vec1.y != _vec2.y);
        }

        public static float Dot(Vector2 _vec1, Vector2 _vec2)
        {
            return _vec1.x * _vec2.x + _vec1.y * _vec2.y;
        }

        public void printVector()
        {
            Console.WriteLine("x = {0:f1}, y = {1:f1}", x, y);
        }
    }

    class A
    {
        int[] arr;

        public A()
        {
            arr = new int[100];
        }

        public int this[int index]
        {
            get {
                if (index >= 0 && index < arr.Length)
                {
                    return arr[index];
                }
                else
                {
                    Console.WriteLine("index가 범위를 벗어났습니다.");
                    return 0;
                }
            }
            set {
                if (index >= 0 && index < arr.Length)
                {
                    arr[index] = value;
                }
                else
                {
                    Console.WriteLine("index가 범위를 벗어났습니다.");
                }
            }
        }
    }

    class Student
    {
        int number;
        string name;
        int isu;
        float average;

        public Student()
        {
        }

        public Student(int _num, string _name, int _isu, float _avg)
        {
            number = _num;
            name = _name;
            isu = _isu;
            average = _avg;
        }

        public int Num
        {
            get { return number; }
        }
        public string Name
        {
            get { return name; }
        }
        public int Isu
        {
            get { return isu; }
        }
        public float Avg
        {
            get { return average; }
        }

        public void print()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("학번 : {0}", number);
            Console.WriteLine("이름 : {0}", name);
            Console.WriteLine("이수 : {0}", isu);
            Console.WriteLine("평점 : {0:f1}", average);
            Console.WriteLine("-----------------------------");
        }
    }
    
    class Program
    {

        public delegate bool Compare<T>(T temp1, T temp2);

        static void Main(string[] args)
        {
            

            Student[] students = new Student[5];
            
            students[0] = new Student(1711111, "bbc", 140, 89.7f);
            students[1] = new Student(1712111, "dbc", 140, 79.7f);
            students[2] = new Student(1713311, "fbc", 130, 99.7f);
            students[3] = new Student(1714141, "cbc", 120, 69.7f);
            students[4] = new Student(1715115, "abc", 110, 99.7f);

           
            Sort(ref students, new Compare<int>(biggerNum));
            /*
                  for(int i=0;i<students.Length;i++)
                  {
                      students[i].print();
                  }
            */
            Sort(ref students, new Compare<string>(smallString));

            for (int i = 0; i < students.Length; i++)
            {
                students[i].print();
            }
            /*
            sort = new StuSort(isuSort);

            sort(ref students);

            //     for (int i = 0; i < students.Length; i++)
            //     {
            //         students[i].print();
            //     }

            sort = new StuSort(avgSort);

            sort(ref students);

            for (int i = 0; i < students.Length; i++)
            {
                students[i].print();
            }*/
        }

        static void Sort(ref Student[] stu, Compare<int> comp )
        {
            Student temp = null;

            for(int i=stu.Length-1;i>=0;i--)
            {
                for(int j=0;j<i;j++)
                {
                    if(comp(stu[i].Num, stu[j].Num))
                    {
                        temp = stu[i];
                        stu[i] = stu[j];
                        stu[j] = temp;
                    }
                }
            }
        }

        static void Sort(ref Student[] stu, Compare<string> comp)
        {
            Student temp = null;
            comp = new Compare<string>(biggerString);

            for (int i = stu.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (comp(stu[i].Name, stu[j].Name))
                    {
                        temp = stu[i];
                        stu[i] = stu[j];
                        stu[j] = temp;
                    }
                }
            }
        }

        static bool biggerNum(int num1, int num2)
        {
            return num1 > num2;
        }

        static bool smallNum(int num1, int num2)
        {
            return num1 > num2;
        }

        static bool biggerString(string str1, string str2)
        {
            if(string.Compare(str1,str2)==1)
            {
                return true;
            }

            return false;
        }

        static bool smallString(string str1, string str2)
        {
            if (string.Compare(str1, str2) == -1)
            {
                return true;
            }

            return false;
        }
    }

    
}
