using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Back.ObjClass;
using Back.SqlConn.Op;
using Back.SqlConn;

namespace WindowsFormsApp1
{
    public partial class Set : Form
    {
        //public Boolean flag_Login=false;
        public Set()
        {
            InitializeComponent();
        }

        private void Control_Add(Form form)
        {
            panel1.Controls.Clear();    //移除所有控件
            form.TopLevel = false;      //设置为非顶级窗体
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //设置窗体为非边框样式
            form.Dock = System.Windows.Forms.DockStyle.Fill;                  //设置样式是否填充整个panel
            panel1.Controls.Add(form);        //添加窗体
            form.Show();                      //窗体运行
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("确定要退出登录吗？", "退出登录提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();



                // this.
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("确定要退出吗？", "退出提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (MessageBox.Show("确定要退出吗？", "退出提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要注销账号吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Customerfa customerfa = new CustomerSqlOp();
                Customer customer = customerfa.GetOneCustomer(Login.username);
                customerfa.DeleteOneCustomer(customer);
                Application.Restart();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }



        private void button5_Click(object sender, EventArgs e)
        {
            PersonInfo personInfo = new PersonInfo();
            Control_Add(personInfo);
        }
        Form_Resize form_Resize = new Form_Resize();
        private void Set_Load(object sender, EventArgs e)
        {
            //form_Resize.X = this.Width;
            //form_Resize.Y = this.Height;
            //form_Resize.setTag(this);
        }
        public void Form1_Resize(object sender, EventArgs e)
        {
            //float newx = (this.Width) / form_Resize.X;
            //float newy = this.Height / form_Resize.Y;
            //form_Resize.setControls(newx, newy, this);
            //this.Text = this.Width.ToString() + " " + this.Height.ToString();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Password password=new Password();
            Control_Add(password);
        }
    }
}
