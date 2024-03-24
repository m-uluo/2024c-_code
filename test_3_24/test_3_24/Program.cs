
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_3_24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.OrderEventHandler += waiter.Action;        //委托协议签订由外部触发
            customer.WalkIn();
            customer.Think();
            customer.PayTheBill();
        }
    }
    public class OrderEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string Size { get; set; }
    }
    public delegate void OrderEventHandler(Customer customer, OrderEventArgs e);
    public class Customer
    {
        private OrderEventHandler orderEventHandler;
        public event OrderEventHandler OrderEventHandler         //事件成员
        {
            add { this.orderEventHandler += value; }
            remove { this.orderEventHandler -= value; }
        }
        public double Bill { get; set; }
        public void PayTheBill()
        {
            Console.WriteLine($"I will Pay {this.Bill}");
        }
        public void WalkIn()
        { Console.WriteLine("WalkIn"); }
        public void Think()
        {
            Console.WriteLine("Think...");
            this.Order("jiding", "large");
        }
        protected void Order(string name, string size)
        {
            if (this.orderEventHandler != null)
            {
                OrderEventArgs e = new OrderEventArgs();    //内部创建信息实例
                e.Name = name;
                e.Size = size;
                this.orderEventHandler.Invoke(this, e);     //委托的触发只能由发出者内部触发，参数为发出者（this）和事件信息
            }
        }
    }
    public class Waiter
    {
        internal void Action(Customer customer, OrderEventArgs e)
        {
            double price = 100;
            switch (e.Size)
            {
                case "large":
                    price *= 1.5;
                    break;
                case "small":
                    price *= 0.5;
                    break;
                default:
                    break;
            }
            Console.WriteLine($"dianle{e.Name},${price}");
            customer.Bill = price;
        }
    }
}
