using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_3_13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //int[] a = new int[6];
            //int[] b = new int[] { 1, 2, 3, 4, 5, 6 };
            //string[] c = new string[5] { "H","e","l","l","o" };

            ////声明初始化有元素的数组
            //int[] arr = new int[6];
            ////获取数组中第一个元素
            //int i1 = arr[0];
            ////给数组内的元素赋值
            //arr[0] = 1;
            //for (int i = 0; i < 5; i++)
            //{
            //    MessageBox.Show("这是第" + (i+1)+"此时i为"+i);
            //}
            double price = 1.9;
            int count = 6;
            double discount = 0.75;
            double totalPrice = price * count;
            totalPrice = totalPrice > 10 ? totalPrice * discount : totalPrice;
            MessageBox.Show(totalPrice.ToString());

            string a = "zhangsan";
            string b = "lisi";
            string c = "wangwu";
            string[] sum = new string[3] { a, b, c };
            int n = sum.Length;
            for (int i = 0; i < n; i++) 
            {
                if (sum[i] == "wangwu")
                {
                    MessageBox.Show("找到了" + sum[i]);
                    break;
                }
            }
        }

        /// <summary>
        /// 加法方法
        /// </summary>
        /// <param name="x">数字1</param>
        /// <param name="y">数字2</param>
        /// <returns>返回的和</returns>
        public int Add(int x, int y)   //public表示方法的调用权限是公开的，int表示方法的返回值是int类型
        {
            return x + y;
        }
    }
}
