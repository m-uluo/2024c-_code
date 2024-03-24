using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_3_23_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Form form=new Form();
            //Controller control=new Controller(form);        //引用类型传入不创建新对象，形参实参为同一对象
            //form.ShowDialog();
            //Console.ReadLine();

            MyForm myForm = new MyForm();
            myForm.ShowDialog();
            Console.ReadLine(  );
        }
    }
    class Controller
    {
        private Form form;

        public Controller(Form form)
        {
            if (form != null)
            {
                this.form = form;
                this.form.Click += this.Action;
            }
        }

        private void Action(object sender, EventArgs e)
        {
            this.form.Text="Click Me";
        }
    }
    class MyForm : Form 
    {
        private TextBox myTextBox;
        private Button button;
        public MyForm() 
        {
            this.myTextBox = new TextBox();
            this.button = new Button();
            this.Controls.Add(this.button);
            this.Controls.Add(this.myTextBox);
            //this.button.Click += this.myTextBox.Action;
            this.button.Click += this.Action;
            this.button.Text = "Say Hello";
            this.button.Top = 70;
        }

        private void Action(object sender, EventArgs e)
        {
            this.myTextBox.Text="Click Me!!!!!!!!!!!!!!!!!!";
        }
    }
    //class MyTextBox : TextBox
    //{
        
    //    internal void Action(object sender, EventArgs e)
    //    {
    //        this.Text = "Click Me!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
    //    }
    //}
}
