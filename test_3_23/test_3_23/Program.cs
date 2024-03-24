using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test_3_23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.Order += waiter.Action;                //事件订阅
            customer.Action();
        }
    }

    public class OrderEventArgs : EventArgs             //3.声明委托传递的信息
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }

    public delegate void OrderEventHandler(Customer customer, OrderEventArgs e);    //2.声明委托类型，缺少传递的信息类型
    //public class Customer                                   //事件拥有者
    //{
    //    private OrderEventHandler orderEventHandler;        //1.委托类型字段，同时对事件开辟空间进行存储，缺少委托类型
    //    public event OrderEventHandler Order                //委托事件
    //    {
    //        add { this.orderEventHandler += value; }        //事件处理器的添加器
    //        remove { this.orderEventHandler -= value; }     //事件处理器的移除器
    //    }
    //    public double Bill { get; set; }
    //    public void PayTheBill()
    //    {
    //        Console.WriteLine("I will pay ${0}",this.Bill);
    //    }

    //    public void WalkIn()
    //    { Console.WriteLine( "Walk into the restaurant"); }
    //    public void Think()
    //    {
    //        for (int i = 0; i < 5; i++)
    //        {
    //            Console.WriteLine(  "think");
    //            Thread.Sleep(1000);
    //        }
    //        if (this.orderEventHandler != null)
    //        {
    //            OrderEventArgs e = new OrderEventArgs();
    //            e.DishName = "Chicken";
    //            e.Size = "small";
    //            this.orderEventHandler(this, e);
    //        }
    //    }
    //    public void Action()
    //    {
    //        this.WalkIn();
    //        this.Think();
    //        this.PayTheBill();
    //    }
    //}

    public class Customer                                   //事件拥有者
    {
        public event OrderEventHandler Order;        //1.委托类型事件，缺少委托类型
        public double Bill { get; set; }
        public void PayTheBill()
        {
            Console.WriteLine("I will pay ${0}", this.Bill);
        }

        public void WalkIn()
        { Console.WriteLine("Walk into the restaurant"); }
        public void Think()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("think");
                Thread.Sleep(1000);
            }
            if (this.Order != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = "Chicken";
                e.Size = "small";
                this.Order(this, e);
            }
        }
        public void Action()
        {
            this.WalkIn();
            this.Think();
            this.PayTheBill();
        }
    }
    public class Waiter                                     //事件响应者
    {
        public void Action(Customer customer, OrderEventArgs e)   //事件处理器
        {
            Console.WriteLine("I will serve you the dish{0}.",e.DishName) ;
            double price = 10;
            switch (e.Size)
            {
                case "small":
                    price *=0.5; break;
                case "large":
                    price *=1.5;break;
                default:
                    break;
            }
            customer.Bill += price;
        }
    }
}
