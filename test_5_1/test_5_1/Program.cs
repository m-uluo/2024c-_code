namespace test_5_1
{
    //enum E_Type
    //{
    //    Boss,
    //    Other
    //}
    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Hello, World!");

    //        long l = 1;
    //        int i = 1;
    //        short s = 1;
    //        sbyte b = 1;

    //        //隐式转换
    //        l = i;

    //       string str = "123";
    //        //int i = (int)str;

    //        //必备部分
    //        try
    //        {
    //            //希望进行异常捕获的代码块
    //            //放到 try 中
    //            //如果 try 中的代码报错了，不会让程序卡死
    //        }
    //        catch
    //        {
    //            //如果出错了，会进入执行 catch 中的代码来捕获异常
    //            //catch(Exception e)具体报错跟踪，通过 e 得到具体的错误信息
    //        }
    //        //可选部分
    //        finally
    //        {
    //            //最后执行的代码，不管有没有出错，都会执行其中的代码
    //        }

    //        string str1 = "123";
    //        str1 += 1;
    //        Console.WriteLine(str1);
    //        Console.WriteLine($"{str1}+11");

    //        int i2=(int)E_Type.Other;
    //        Console.WriteLine(i2);

    //        int[] arr = new int[5] { 1, 2 ,3,4,5};
    //    }

    //}
    struct Student
    {
        public int age;
        public string name;

        public Student(int age, string name)
        {
            this.name = name;
            this.age = age;
        }

        public void Speak()
        {
            Console.WriteLine($"我是{this.name}，我{this.age}岁了");
        }
    }

    class Person
    {
        //string name = "zhangsan";
        //private int age;
        //public int Age
        //{
        //    get { return age; }
        //    set { }
        //}
        //Person girlFriend;
        //Person[] friends;

        //public Person()
        //{

        //}
        //public Person(string name)
        //{ this.name = name; }
        //public Person(int age1, string name1) : this(name1)
        //{ }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }



    }
    static class StaticClass
    {
        static public int testInt = 100;
        static public int testInt2 = 100;
        static StaticClass()
        {
            Console.WriteLine("静态构造函数");
        }
    }
    class Test
    {
        static public int testInt = 100;
        
        static Test()
        {
            Console.WriteLine("静态构造");
        }
        public Test() 
        {
            Console.WriteLine("普通构造");
        }
    }

    static class Tool
    {
        //为int拓展了一个成员方法
        //成员方法 是需要 实例化对象后才能使用的
        //value 代表使用该方法的 实例化对象
        public static void SpeakValue(this int value)
        {
            Console.WriteLine("拓展的方法" + value);
        }
        public static void SpeakStringInfo(this string value,int num,string str)
        {
            Console.WriteLine("字符串" + value + "与" + num + str + "拼写");
        }
        public static void test1Fun(this Test1 t)
        {
            Console.WriteLine("拓展方法");
        }

    }
    class Test1
    { 
    }

    internal class Program
    {
        static void ArraySort(int[] array)
        {
            int temp = 0;
            int index = 0;
            //比较i轮
            for (int i = 0; i < array.Length - 1; i++)
            {
                //每轮比较Length  - i次
                for (int j = 0; j < array.Length - i; j++)
                {
                    //依次比较找出最大值
                    if (array[j] > array[index])
                    {
                        index = j;
                    }
                }
                //如果最大值就是当前位置，就不用交换
                if (index != array.Length - 1 - i)
                {
                    temp = array[index];
                    array[index] = array[array.Length - 1 - i];
                    array[array.Length - 1 - i] = temp;
                }
            }
        }
        static void Main(string[] args)
        {
            //Student s;
            //s.age = 10;
            //s.name = "zhangsan";
            ////s.Speak();

            //int[] array = new int[10] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            //Array.Sort(array);
            //for (int i = 0; i < array.Length; i++) { Console.WriteLine(array[i]); }
            //int i2=StaticClass.testInt;
            //int a = 9;
            //a.SpeakValue();

            string str1 = "qger14tw";
            int num = 1;
            string str = "123";
            str1.SpeakStringInfo(num, str);
        }
        

    }

    
}
