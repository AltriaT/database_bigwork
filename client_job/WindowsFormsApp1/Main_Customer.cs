using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Main_Customer : Form
    {


        public Boolean flag_Login = false;
        public Main_Customer()
        {
            InitializeComponent();
        }

        public void Main_Exit()

        {
            this.Close();
        }
        
        private void Control_Add(Form form)
        {
            
            panel2.Controls.Clear();    //移除所有控件
            form.TopLevel = false;      //设置为非顶级窗体
           // Console.WriteLine("buy  panel");

            
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //设置窗体为非边框样式
            
            form.Dock = System.Windows.Forms.DockStyle.Fill;                  //设置样式是否填充整个panel
            Console.WriteLine("buy  panel");
            panel2.Controls.Add(form);        //添加窗体
            
            form.Show();                      //窗体运行
        }

        

        Form_Resize form_Resize = new Form_Resize();
        private void Main_Load(object sender, EventArgs e)
        {
            timer1.Start();

            
            //form_Resize.X = this.Width;
            //form_Resize.Y = this.Height;
            //form_Resize.setTag(this);
            
        }
        public void Form1_Resize(object sender, EventArgs e)
        {
        //    float newx = (this.Width) / form_Resize.X;
        //    float newy = this.Height / form_Resize.Y;
        //    form_Resize.setControls(newx, newy, this);
            //this.Text = this.Width.ToString() + " " + this.Height.ToString();

        }





        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = System.DateTime.Now;
            label1.Text = dt.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Set set = new Set();
            Control_Add(set);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            Buy buy = new Buy();
            Control_Add(buy);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Trolley trolley = new Trolley();
            Control_Add(trolley);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出吗？", "退出提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            Control_Add(order);
        }

       
    }
}
