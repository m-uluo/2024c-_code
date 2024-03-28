namespace test_3_26_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a=new WarmKiller();
            a.Love();
            IKiller b = a;
            b.Kill();
        }
    }
    interface IGentleman
    { void Love(); }
    interface IKiller
    { void Kill(); }
    class WarmKiller : IGentleman, IKiller
    {
        public void Love()
        {
            Console.WriteLine("love") ;
        }

        void IKiller.Kill()
        {
            Console.WriteLine("kill");
        }
    }
}
