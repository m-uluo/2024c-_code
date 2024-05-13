using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Timers;


namespace test_5_8
{
    //class TestClass<T>
    //{
    //    public T value;
    //}

    //class TestClass1<T,K,M,LL>
    //{
    //    public T value;
    //    public K value1;
    //    public M value2;
    //    public LL value3;
    //}

    //interface ITest<T>
    //{
    //    T value { get; set; }
    //}
    //class Test : ITest<int>
    //{
    //    public int value { get; set; }
    //}

    //class Test2<T>
    //{
    //    public T value;
    //    public void TestFun(T t)
    //    { }
    //    public void TestFun1<K>(K k)
    //    { }
    //}

    //class Test<T> where T : struct
    //{
    //    public T value;
    //    public void TestFun<K>(K k) where K : struct
    //    {

    //    }
    //}

    //class Test<T> where T : class
    //{
    //    public T value;
    //    public void TestFun<K>(K k) where K : class
    //    {

    //    }
    //}

    //class Test<T,K> where T : class, new() where K : class
    //{
    //    public T value;
    //    //public void TestFun<K,V>(K k) where K : V
    //    //{

    //    //}
    //}
    //interface IFly
    //{ }
    //abstract class Test1 : IFly
    //{
    //}
    //class Test2:Test1
    //{
    //    public Test2(int x):base() { }
    //}
    //struct Test3
    //{
    //    public Test3(int x) { }
    //}

    ///// <summary>
    ///// 单向链表节点
    ///// </summary>
    ///// <typeparam name="T"></typeparam>
    //class LinkedNode<T>
    //{
    //    public T value;
    //    public LinkedNode<T> nextNode;

    //    public LinkedNode(T value)
    //    {
    //        this.value = value;
    //    }
    //}
    ///// <summary>
    ///// 单向链表类
    ///// </summary>
    ///// <typeparam name="T"></typeparam>
    //class LinkedList<T>
    //{
    //    public LinkedNode<T> head;
    //    public LinkedNode<T> tail;
    //    public void Add(T value)
    //    {
    //        LinkedNode<T> linkNode = new LinkedNode<T>(value);
    //        if (head == null)
    //        {
    //            head = linkNode;
    //            tail=linkNode;
    //        }
    //        else
    //        {
    //            tail.nextNode = linkNode;
    //            tail = linkNode;
    //        }
    //    }
    //    public void Remove(T value)
    //    {
    //        if (head == null)
    //        {
    //            return;
    //        }
    //        if (head.value.Equals(value))
    //        {
    //            head = head.nextNode;
    //            if (head == null)
    //            {
    //                tail = null;
    //            }
    //            return;
    //        }
    //        LinkedNode<T> node = head;
    //        while (node.nextNode != null)
    //        {
    //            if (node.nextNode.value.Equals(value))
    //            {
    //                //让当前找到的这个元素上的节点指向自己的下一个节点
    //                node.nextNode=node.nextNode.nextNode;
    //                break;
    //            }
    //            node = node.nextNode;
    //        }
    //    }
    //}

    //delegate void MyFun();
    //delegate int MyFun1(int a);

    //class Test
    //{
    //    public MyFun fun;
    //    public MyFun1 fun1;
    //    public void TestFun(MyFun fun, MyFun1 fun1)
    //    {
    //        //先处理一些别的逻辑 当这些逻辑处理完了 再执行传入的函数
    //    }
    //}
    //delegate void MyFun();

    //class Test
    //{
    //    //public Action myFun;
    //    //public event Action myEvent;
    //    //public Test() 
    //    //{
    //    //    myEvent = null;
    //    //}
    //    //public void Event()
    //    //{
    //    //    myEvent();
    //    //}
    //    private Action action;    //声明一个私有委托
    //    public event Action ActionEvent           //声明对应的公共事件，并进行封装
    //{
    //        add
    //    {
    //            this.action += value;
    //        }
    //        remove
    //    {
    //            this.action -= value;
    //        }
    //    }


    //public void Happened()                      //事件的触发
    //    {
    //        if (this.action != null)
    //        {
    //            this.action();
    //        }
    //    }
    //}

    //class Item //: IComparable<Item>
    //{
    //    public int money;
    //    public Item(int money)
    //    {
    //        this.money = money;
    //    }

    //    //public int CompareTo(Item? other)
    //    //{
    //    //    //返回值的含义
    //    //    //按照数轴排列 这里的传入对象是other
    //    //    //负数会放在传入对象的前面
    //    //    //0会保持当前位置不变
    //    //    //正数会放在传入对象的后面
    //    //    if (this.money > other.money)
    //    //    {
    //    //        return 1;       //大的放在右面就传入正数
    //    //    }
    //    //    else 
    //    //    {
    //    //        return -1; 
    //    //    }
    //    //}
    //}

    //delegate T TestOut<out T>();
    //delegate void TestIn<in T>(T t);
    //class Father
    //{ }
    //class Son : Father
    //{ }

    //class Test
    //{
    //    private int i = 1;
    //    public int j = 0;
    //    public string str = "123";
    //    public Test()
    //    { }
    //    public Test(int i)
    //    {
    //        this.i = i;
    //    }
    //    public Test(int i, string str) : this(i)
    //    {
    //        this.str = str;
    //    }
    //    public void Speak()
    //    {
    //        Console.WriteLine(i);
    //    }
    //}
    class CustomList : IEnumerable, IEnumerator
    {
        private int[] list;
        //从-1开始的光标 用于表示数据得到了哪个位置
        private int position = -1;
        public CustomList() 
        {
            list = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
        }

        public IEnumerator GetEnumerator()
        {
            Reset();
            return this;
        }


        public object Current
        {
            get { return list[position]; }
            set { }
        }

        public bool MoveNext()
        {
            ++position;
            return position<list.Length?true:false;
        }

        public void Reset()
        {
            this.position = -1;
        }
    }

    internal class Program
    {
        //static Action TestAction(int i, Action fun)
        //{
        //    return delegate () { };
        //}
        //public static void Fun()
        //{ Console.WriteLine("Fun"); }
        //public static void Fun1()
        //{ Console.WriteLine("Fun1"); }
        //public static void Fun2()
        //{ Console.WriteLine("Fun2"); }


        //public static void Fun()
        //{
        //    Console.WriteLine("委托方法");
        //}
        //public static int Fun(int a)
        //{
        //    return 1;
        //}

        //public void TestFun<T>(T value)
        //{
        //    Console.WriteLine(value);
        //}
        //public void TestFun<T>()
        //{
        //    T value = default(T);
        //}
        //public T TestFun<T>(string str)
        //{
        //    return default(T);
        //}
        //public void TestFun<T, K, M>(T value, K value1, M value2)
        //{
        //    Console.WriteLine(value);
        //}
        //static bool IsRunning = true;
        //static void NewThreadLogic()
        //{
        //    while (IsRunning)
        //    {
        //        Console.WriteLine("新开线程代码逻辑");
        //    }
        //}
        static void Main(string[] args)
        {
            #region 注释
            //ArrayList array = new ArrayList();
            //#region ArrayList增删查改
            ////增
            //array.Add(1);
            //array.Add("123");
            //array.Add(true);

            //ArrayList array2 = new ArrayList() { 1, 2, 3, "123" };
            //array.AddRange(array2);     //范围增加，把另一个 list 容器里面的内容加到后面
            //array.Insert(0, 123);       //在指定位置插入元素

            ////删
            //array.Remove(1);    //移除指定元素，从头找，删掉第一个1
            //array.RemoveAt(1);  //移除指定位置的元素
            //array.Clear();      //清空

            ////查
            //object o = array[0];    //获取指定位置的元素
            //if (array.Contains("123"))  //查看元素是否存在
            //{ }
            //int i = array.IndexOf("123"); //正向查找元素位置，找到返回位置，找不到返回-1
            //i = array.LastIndexOf("123"); //反向查找元素位置，找到返回位置，找不到返回-1

            ////改
            //array[0] = 999;

            ////长度
            //int len = array.Count;
            ////容量
            //int cap = array.Capacity;
            //#endregion

            //Stack stack = new Stack();
            //#region Stack增删查改
            ////增（压栈）
            //stack.Push(1);
            //stack.Push("123");
            //stack.Push(true);
            //stack.Push(new object());

            ////取（弹栈）
            //object v = stack.Pop();

            ////查
            ////栈无法查看指定位置的元素，只能查看栈顶位置元素，且只会查看，不会弹出
            //object p = stack.Peek();
            ////查看元素是否存在于栈中
            //if (stack.Contains("123"))
            //{ }

            ////改
            ////栈无法改变其中的元素，只能压栈弹栈，或者清空
            //stack.Clear();

            ////长度
            //len = stack.Count;

            ////不能用for遍历，要通过foreach遍历，而且遍历出来的顺序也是从栈顶到栈底
            //foreach (object item in stack)
            //{

            //}

            ////还有一种遍历方式，将栈转换为 object 数组，遍历出来的顺序也是从栈顶到栈底
            //object[] array1 = stack.ToArray();
            //for (int i1 = 0; i1 < array1.Length; i1++)
            //{ }

            ////循环弹栈
            //while (stack.Count > 0)
            //{
            //    object o1 = stack.Pop();
            //    Console.WriteLine(o1);
            //}
            //#endregion

            //Queue queue = new Queue();
            //#region Queue增删查改
            ////增
            //queue.Enqueue(1);
            //queue.Enqueue("123");
            //queue.Enqueue(new object());

            ////取
            ////队列中不存在删除的概念，只有取的概念。取出先加入的对象
            //o = queue.Dequeue();

            ////查
            ////队列无法查看指定位置的元素，只能查看队列头部元素，且只会查看，不会出列
            //p = queue.Peek();
            ////查看元素是否存在于队列中
            //if (queue.Contains("123"))
            //{ }

            ////改
            ////队列无法改变其中的元素，只能进出队列，或者清空
            //queue.Clear();

            ////长度
            //len = queue.Count;

            ////不能用for遍历，要通过foreach遍历，而且遍历出来的顺序也是从队头到队尾
            //foreach (object item in queue)
            //{

            //}

            ////还有一种遍历方式，将队列转换为 object 数组，遍历出来的顺序也是从队头到队尾
            //array1 = queue.ToArray();
            //for (int i1 = 0; i1 < array1.Length; i1++)
            //{ }

            ////循环出队
            //while (queue.Count > 0)
            //{
            //    object o1 = queue.Dequeue();
            //    Console.WriteLine(o1);
            //}
            //#endregion

            //Hashtable hashtable = new Hashtable();
            //#region Hashtable增删查改
            ////增
            ////注意不能出现相同键
            //hashtable.Add(1, 1);
            //hashtable.Add("12", "123");
            //hashtable.Add(new Hashtable(), new object());

            ////删
            ////直接填写要删除的键
            ////删除不存在的键没反应
            //hashtable.Remove(1);
            //hashtable.Remove(6);
            ////清空
            //hashtable.Clear();

            ////查
            ////找不到会返回空
            //p = hashtable[1];
            //p = hashtable["123"];
            ////查看是否存在
            ////根据键检测
            //if (hashtable.Contains("123"))
            //{ }
            ////根据值检测
            //if (hashtable.ContainsValue("123"))
            //{ }

            ////改
            //hashtable[1] = 0;

            ////长度
            //len = hashtable.Count;

            ////遍历所有键（顺序不一定）
            //foreach (object item in hashtable.Keys)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine(hashtable[item]);
            //}

            ////遍历所有值（顺序不一定）
            //foreach (object item in hashtable.Values)
            //{
            //    Console.WriteLine(item);
            //}

            ////键值对一起遍历
            //foreach (DictionaryEntry item in hashtable)
            //{
            //    Console.WriteLine("键：" + item.Key + "值：" + item.Value);
            //}

            ////迭代器遍历法
            //IDictionaryEnumerator myEnumerator = hashtable.GetEnumerator();
            //bool flag = myEnumerator.MoveNext();
            //while (flag)
            //{
            //    Console.WriteLine("键：" + myEnumerator.Key + "值：" + myEnumerator.Value);
            //    flag = myEnumerator.MoveNext();
            //}

            //#endregion

            //TestClass<int> t=new TestClass<int>();
            //t.value = 1;

            //Console.WriteLine(default(bool));

            //Test<Random> test = new Test<Random>();
            //test.value = new Random();
            //test.TestFun<Random>(new Random());

            //Test<Test1> text1 = new Test<Test1>();
            //Test<Test2> text2 = new Test<Test2>();
            //Test<Test3> text3 = new Test<Test3>();

            //Test<IFly> test1 = new Test<IFly>();
            //Test<Test1,IFly> test = new Test<Test1, IFly>();


            //List<int> list=new List<int>();
            ////增
            //list.Add(1);
            //list.Add(2);
            //list.Add(3);

            //List<int> list2 = new List<int>{ 1, 2, 3 };
            //list.AddRange(list2);     //范围增加，把另一个 list 容器里面的内容加到后面
            //list.Insert(0, 123);       //在指定位置插入元素

            ////删
            //list.Remove(1);    //移除指定元素，从头找，删掉第一个1
            //list.RemoveAt(1);  //移除指定位置的元素
            //list.Clear();      //清空

            ////查
            //int i = list[0];    //获取指定位置的元素
            //if (list.Contains(1))  //查看元素是否存在
            //{ }
            //int i1 = list.IndexOf(2); //正向查找元素位置，找到返回位置，找不到返回-1
            //i1 = list.LastIndexOf(2); //反向查找元素位置，找到返回位置，找不到返回-1

            ////改
            //list[0] = 999;

            ////长度
            //int len = list.Count;
            ////容量
            //int cap = list.Capacity;

            //Dictionary<int, string> dictionary = new Dictionary<int, string>();

            ////增
            ////注意不能出现相同键
            //dictionary.Add(1, "123");

            ////删
            ////直接填写要删除的键
            ////删除不存在的键没反应
            //dictionary.Remove(1);
            //dictionary.Remove(6);
            ////清空
            //dictionary.Clear();

            ////查
            ////找不到会返回空
            //string p = dictionary[1];
            ////查看是否存在
            ////根据键检测
            //if (dictionary.ContainsKey(1))
            //{ }
            ////根据值检测
            //if (dictionary.ContainsValue("123"))
            //{ }

            ////改
            //dictionary[1] = "12";

            ////长度
            //int len = dictionary.Count;

            ////遍历所有键（顺序不一定）
            //foreach (int item in dictionary.Keys)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine(dictionary[item]);
            //}

            ////遍历所有值（顺序不一定）
            //foreach (string item in dictionary.Values)
            //{
            //    Console.WriteLine(item);
            //}

            ////键值对一起遍历
            //foreach (KeyValuePair<int, string> item in dictionary)
            //{
            //    Console.WriteLine("键：" + item.Key + "值：" + item.Value);
            //}

            //LinkedList<int> link= new LinkedList<int>();
            //link.Add(1);
            //link.Add(2);
            //link.Add(3);
            //LinkedNode<int> node = link.head;
            //while (node != null)
            //{
            //    Console.WriteLine(node.value);
            //    node = node.nextNode;
            //}
            //LinkedList<int> linkList = new LinkedList<int>();

            ////增
            ////在链表尾部添加元素
            //linkList.AddLast(10);
            ////在链表头部添加元素
            //linkList.AddFirst(20);
            ////在某一个节点之后添加一个节点
            //LinkedListNode<int> n = linkList.Find(20);
            //linkList.AddAfter(n, 15);
            ////在某一个节点之前添加一个节点
            //linkList.AddBefore(n, 13);

            ////删
            ////删除头节点
            //linkList.RemoveFirst();
            ////删除尾节点
            //linkList.RemoveLast();
            ////移除指定值节点(输入节点的值)
            //linkList.Remove(20);
            ////清空
            //linkList.Clear();

            ////查
            ////头节点
            //LinkedListNode<int> first = linkList.First;
            ////尾节点
            //LinkedListNode<int> last = linkList.Last;
            ////找到指定值的节点，无法通过下标获取中间元素，只有遍历查找指定位置元素
            //LinkedListNode<int> node = linkList.Find(20);
            ////判断是否存在
            //if (linkList.Contains(20))
            //{ }

            ////改
            //linkList.First.Value = 17;

            ////foreach遍历
            //foreach (int i in linkList) 
            //{ }
            ////通过节点遍历
            ////从头到尾
            //LinkedListNode<int> nowNode = linkList.First;
            //while (nowNode != null)
            //{
            //    Console.WriteLine(nowNode.Value);
            //    nowNode = nowNode.Next;
            //}

            ////从尾到头
            //nowNode = linkList.Last;
            //while (nowNode != null)
            //{
            //    Console.WriteLine(nowNode.Value);
            //    nowNode = nowNode.Previous;
            //}
            //MyFun f = new MyFun(Fun);
            //f.Invoke();

            //MyFun f1 = Fun;
            //f1();

            //MyFun1 f2 = Fun;                //由于Fun方法重载，调用的是返回值和参数都为 int 的方法
            //f2(1);


            //Test t= new Test();
            //t.TestFun(Fun, Fun);
            //t.TestFun(f1, f2);

            //MyFun myFun = Fun;
            //myFun += Fun1;

            //myFun();
            //System.Timers.Timer timer = new System.Timers.Timer();
            //timer.Interval = 1000;
            //timer.Elapsed += null;

            //Test test = new Test();
            //test.ActionEvent += delegate ()
            //{
            //    Console.WriteLine("diaoyong");
            //};

            //TestAction(1, delegate () { });
            //Action<string, int> b = (str,i)=>
            //{
            //    Console.WriteLine(str + i);
            //};

            //b();
            //List<Item> list = new List<Item>();
            //list.Add(new Item(10));
            //list.Add(new Item(8));
            //list.Add(new Item(9));
            //list.Add(new Item(2));


            //list.Sort((a, b)=>
            //{
            //    if (a.money > b.money)
            //    {
            //        return 1;
            //    }
            //    else
            //    {
            //        return -1;
            //    }
            //});
            ////协变 父类总是能被子类替换
            ////看起来就是son装入father
            //TestOut<Son> outS = () => { return new Son(); };
            //TestOut<Father> outF = outS;        //最终的返回的是Son，但是被装在Father中

            //Father f = outF();

            ////逆变 父类总是能被子类替换
            ////看起来像是father装入son
            //TestIn<Father> inF = delegate (Father value) { };
            //TestIn<Son> inS = inF;

            //inS(new Son());     //实际上调用的是iF
            //Thread t = new Thread(NewThreadLogic);
            //t.Start();
            //t.IsBackground = true;

            ////IsRunning = false;
            //Console.ReadKey();
            #endregion
            //Type type = typeof(Test);
            //ConstructorInfo info = type.GetConstructor(new Type[0]);
            //Test obj = info.Invoke(new object[] { 1 }) as Test;
            CustomList list = new CustomList();

            //foreach的本质
            //1. 先获取 in 后面这个对象的IEnumerator
            //会调用这个对象其中的GetEnumerator方法 同时里面有Reset复原光标的方法
            //2. 执行得到这个IEnumerator对象中的 MoveNext 方法
            //3. 只要MoveNext方法的返回值是true就会去得到Current
            //然后复制给item
            //4. 因为会先执行MoveNext方法，所以光标位置先从-1开始
            foreach (int item in list) 
            {
                Console.WriteLine(item);
            }
            int[] array = new int[] { 1, 2, 3, 4 };
            List<int> array1 = new List<int>(){ 1, 2, 3, 4, 5 };
            object obj = null;
            if (obj==null)Console.WriteLine("null");
        }


    }

}
