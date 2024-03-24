using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_3_23_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Action action = new Action(calculator.Report);
            action.Invoke();

            Func<int,int,int> func = new Func<int, int, int>(calculator.Add);
            int b=func(2, 4);
            Console.WriteLine(  $"{b}");

            Type t = typeof(Func<>);
            Console.WriteLine(  t.IsClass);

            del d = new del(calculator.Add);
            int e = d(2, 3);
            Console.WriteLine( e );

            Factory factory = new Factory();
            WrapFactory wrapFactory = new WrapFactory();
            Func<Product> func1 = new Func<Product>(factory.PizzaMake);
            Func<Product> func2 = new Func<Product>(factory.ToyCarMake);

            Logger log = new Logger();
            Action<Product> action1 = new Action<Product>(log.Log);


            Box boxPizza = wrapFactory.WrapProduct(func1, action1);
            Box boxToyCar = wrapFactory.WrapProduct(func2, action1);
            Console.WriteLine($"{boxPizza.Product.Name},{boxToyCar.Product.Name}");

        }
    }
    public delegate int del(int a, int b);
    public class Calculator
    {
        public void Report()
        {
            Console.WriteLine("I have 3 methods.");
        }
        public int Add(int a,int b)
        {
            return a + b;
        }
        public int Sub(int a, int b)
        {
            return a - b;
        }
    }
}
