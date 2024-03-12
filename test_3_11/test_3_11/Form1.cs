using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_3_11
{
    /// <summary>
    /// 窗体1
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int x = 0;
            MessageBox.Show(x.ToString());
        }

        /// <summary>
        /// 踢足球的方法
        /// </summary>
        public void PlayFootball()
        {
            //decimal m = 1.0m;
            string st = "0";
            MessageBox.Show(st);
        }
    }
}
