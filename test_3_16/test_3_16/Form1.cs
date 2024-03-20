using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_3_16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Person p = new Person()
            {
                Name = "张三",
                Age = 10,
                Height = 20
            };
            //p.Name = "张三";
            p.Eat();
            p.Run();
        }
    }
}
