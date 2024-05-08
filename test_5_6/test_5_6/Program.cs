using System.Security.Cryptography;

namespace test_5_6
{
    class Point
    {
        public int x;
        public int y;

        public Point()
        { }
        public Point(int a, int b)
        {
            this.x = a;
            this.y = b;
        }
        public static Point operator +(Point p1, Point p2)  //因为是Point类型相加，至少有一个Point类型
        {
            Point p = new Point();
            p.x = p1.x + p2.x;
            p.y = p1.y + p2.y;
            return p;
        }
        public static Point operator +(Point p1, int p2)    //因为是Point类型相加，至少有一个Point类型
        {
            Point p = new Point();
            p.x = p1.x + p2;
            p.y = p1.y + p2;
            return p;
        }
        public static Point operator +(int p1, Point p2)    //因为是Point类型相加，至少有一个Point类型
        {
            Point p = new Point();
            p.x = p1 + p2.x;
            p.y = p1 + p2.y;
            return p;
        }
    }
    public partial class Student
    {
        public int id;
    }
    public partial class Student
    {
        public string name;
    }

    public class Teacher
    {
        public string name;
        public int number;
        public void SpeakName()
        {
            Console.WriteLine(this.name);
        }
    }
    public class TeachingTeacher : Teacher  //继承了Teacher里的字段和方法
    {
        public string subject;
        public void SpeakSubject()
        {
            Console.WriteLine(this.subject + "老师");
        }
    }
    public class ChineseTeacher : TeachingTeacher   //继承了TeachingTeacher和Teacher里的字段和方法
    {
        public string name;
        public void Skill()
        {
            Console.WriteLine("一行白鹭上青天");
        }
    }

    public class GameObject
    {
        public string name;
        public GameObject(string name)
        {
            this.name= name;    
        }
        //虚函数可以被子类重写
        public virtual void Atk()
        {
            Console.WriteLine("游戏对象进行攻击");
        }
    }
    //public class Player : GameObject
    //{
    //    public Player(string name) : base(name)
    //    { }
    //    public override void Atk()
    //    {
    //        base.Atk();     //base 的作用:代表父类，可以通过 base 来保留父类的行为
    //        Console.WriteLine("玩家攻击");
    //    }
    //}
    public class Monster : GameObject
    {
        public Monster(string name) : base(name)
        { }
        public override void Atk()
        {
            Console.WriteLine("怪物攻击");
        }
    }
    public class Boss : GameObject
    {
        public Boss(string name) : base(name)
        { }
        public override void Atk()
        {
            Console.WriteLine("Boss攻击");
        }
    }

    public class Father
    {
        public Father()
        { }
        public Father(int a)
        { 
            Console.WriteLine(a); 
        }
    }
    //子类实例化时默认自动调用的是父类的无参构造。所以如果父类无参构造函数被顶掉，会报错
    public class Son : Father 
    {
        public Son()
        { }
        public Son(int a):base(a){}
        public void Speak()
        { }
    }

    public abstract class Thing
    { }
    public class Water : Thing 
    { }

    public abstract class Fruits
    {
        public string name;
        //抽象方法，是一定不能有函数体的
        public abstract void Bad();
    }
    public class Apple : Fruits
    {
        public override void Bad()
        {
             
        }
    }
    //interface IFly
    //{
    //    void Fly();
    //    string Name    //属性里也是不能有语句块的
    //    {
    //        get;
    //        set;
    //    }
    //    int this[int index]
    //    {
    //        get;
    //        set;
    //    }
    //    event Action doSomething;
    //}
    //public class Animal
    //{ }
    //public class Person : Animal, IFly
    //{
    //    public int this[int index] 
    //    { 
    //        get 
    //        { 
    //            return 0; 
    //        } 
    //        set 
    //        { } 
    //    }

    //    public string Name
    //    { get; set; }

    //    public event Action doSomething;

    //    public void Fly()
    //    {

    //    }
    //}
    interface IFly
    {
        void Fly();
    }
    interface IWalk
    {
        void Walk();
    }

    interface IMove : IFly, IWalk
    { }

    //class Person : IMove
    //{
    //    public void Fly()
    //    { Console.WriteLine("不会飞"); }
    //    public void Walk()
    //    { Console.WriteLine("可以走"); }
    //}

    interface IAtk
    {
        void Atk(); 
    }
    interface ISuperAtk
    {
        void Atk();
    }

    public class Player : IAtk, ISuperAtk
    {
        void IAtk.Atk()
        {
            throw new NotImplementedException();
        }

        void ISuperAtk.Atk()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class Animal
    {
        public string name;
        public abstract void Eat();
        public virtual void Speak()
        { Console.WriteLine("叫"); }
    }
    public class Person : Animal
    {
        public sealed override void Eat()
        {
            ;
        }
        public override void Speak()
        {
            base.Speak();
        }
    }

    class Test
    {
        public int i = 1;
        public Test2 t2 = new Test2();

        public Test Clone()
        {
            return MemberwiseClone() as Test;
        }
    }
    class Test2
    { }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Point p1=new Point(1,1);
            //Point p2 = new Point(2,2);
            //Point p3 = p1 + p2;
            //Point p4 = p1 + 3;
            //GameObject player = new Player();
            //GameObject monster = new Monster();
            //GameObject bosss = new Boss();
            //GameObject[] objects = new GameObject[] { new Player(), new Monster(), new Boss() };

            ////引用类型
            //object o = new Son();
            ////用 is as 来判断和转换即可
            //if (o is Son)
            //{
            //    (o as Son).Speak();
            //}
            ////值类型
            //object o2 = 1f;
            ////用强转
            //float f1 = (float)o2;
            ////特殊的 string 类型
            //object str = "1234";
            //string str2=str as string;
            //string str3=str.ToString();
            //GameObject p = new Player("玩家1");
            //p.Atk();

            //Thing t = new Water();

            //IFly ifly = new Person();
            //ifly.Fly();
            //IMove im = new Person();
            //im.Fly();
            //im.Walk();
            //IWalk iw= new Person(); 
            //iw.Walk();

            //Test t = new Test();
            //Test t2=t.Clone();

            int str = 1;
            Console.WriteLine(str.Equals(1));
        }
    }
}
