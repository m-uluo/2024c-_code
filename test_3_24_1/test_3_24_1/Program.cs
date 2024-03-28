using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_3_24_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Type t= typeof(int);
            //Type t2= t.BaseType;
            //Type t3 = t2.BaseType;
            //Console.WriteLine(t3);
            Student student = new Student();
            student.Name = "ww";
            student.ShowName();
            int[] arr= new int[3] { 1,2,3};
        }
    }
    //class Student
    //{
    //    public int Id { get; set; } 
    //}
    class People
    {
        public string Name { get; set; }
        public People(int a) 
        {
            this.Name = "";
        }
    }
    class Student : People
    {
        public Student():base(1)
        { this.Name = "111"; }
        public Student(int a):base(a)
        { this.Name = "111"; }
        public void ShowName()
        { Console.WriteLine(base.Name); }
    }
}
