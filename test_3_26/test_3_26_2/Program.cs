namespace test_3_26_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //People people = new Teacher();
            //people.Say();

            double[] a = new double[] { 1.1, 1.2, 1.3, 1.4 };
            double[] b = new double[] { 1.1, 1.2, 1.3, 1.4, 1.5 };
            double[] c = Zip<double>(a, b);
            Console.WriteLine(string.Join(", ", c));

            Action<string> say=new Action<string>(Say);
            say.Invoke("a");

        }
        static T[] Zip<T>(T[] a, T[] b)
        {
            T[] zipped = new T[a.Length + b.Length];
            int ap = 0, bp = 0, cp = 0;
            while (cp<zipped.Length)
            {
                if (ap < a.Length) zipped[cp++] = a[ap++];
                if(bp < b.Length) zipped[cp++]= b[bp++];
            }
            return zipped;
        }
        static void Say(string str)
        {
            Console.WriteLine($"{str} hello.");
        }
    }
    class People
    {
        public virtual void Say()
        { Console.WriteLine("I'm person"); }
    }
    class Teacher : People
    {
        public override void Say()
        { Console.WriteLine("I'm teacher"); }
    }

}
