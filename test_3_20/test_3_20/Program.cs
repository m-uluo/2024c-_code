namespace test_3_20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //hello: Console.WriteLine("Hello World.");
            //goto hello;
            Action acton = new Action(Calculator.Report);
            acton.Invoke();
            Func<int> function = new Func<int>(Calculator.Report2);
        }

    }
    public class Calculator
    {
        public static void Report()
        {
            Console.WriteLine( "I have 3 methods." );
        }
        public static int Report2()
        {
            Console.WriteLine("I have 3 methods.");
            return 1;
        }
    }

}
