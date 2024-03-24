using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_3_22_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            Controller controller=new Controller(form);
            form.ShowDialog();

        }
    }
    class Controller
    {
        private Form form;
        public Form Form
        {
            get ;
            set ;
        }
        public Controller(Form form) 
        {
            if (form != null)
            {
                this.Form = form;
                this.Form.Click += this.FormClick;
            }
        }

        private void FormClick(object sender, EventArgs e)
        {
            this.Form.Text = DateTime.Now.ToString();
        }
    }
    class MyForm : Form 
    {
        private TextBox textBox;
        private Button button;

        public MyForm() 
        {
            this.textBox = new TextBox();
            this.button = new Button();
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.button);
            this.button.Click += this.ButtonClicked;
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            this.textBox.Text = "HelloWorld";
        }
    }
}
