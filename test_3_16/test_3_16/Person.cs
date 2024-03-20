using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_3_16
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }

        public void Eat() 
        {
            MessageBox.Show(Name+"在吃");
        }
        public void Run()
        {
            MessageBox.Show(Name + "在跑");
        }
    }
}
