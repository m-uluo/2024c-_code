using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("abc");
            Form form = new Form();
            long x = 3L;
            short y = 2;
            var x1 = 3.0;
            Console.WriteLine( x1.GetType().Name );
            float a = 20F;
            a = 5F;
            int b = 0;

            int ret = Program.Add(0, out b);
        }
        public static int Add(int x, out int y)
        {
            y = 1;
            return x + y;
        }
    }
}
