using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using Back.ObjClass;
using Back.SqlConn.Op;
using Back.SqlConn;
namespace WindowsFormsApp1
{
    public partial class Register : Form
    {

        string phone;
        string password;
        

        public Register()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            Customerfa customerfa = new CustomerSqlOp();
            Dictionary<string, Customer> customers = customerfa.GetAllCustomer();
            
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || (checkBox1.Checked == false && checkBox2.Checked == false))
                MessageBox.Show("请填写完整信息!", "提示信息");
            else if(customers.ContainsKey(textBox1.Text))
            {
                MessageBox.Show("该手机号已被注册!", "提示信息");
            }    
            else if(textBox3.Text!=textBox4.Text)
            {
                MessageBox.Show("两次密码输入不匹配，请重新输入!", "提示信息");
            }
            else
            {
                if (checkBox1.Checked == true && checkBox2.Checked == true)
                    MessageBox.Show("两个性别不能选择!", "提示信息");
                else if (checkBox1.Checked == true)
                {
                    
                    Customer customer = new Customer(textBox1.Text, textBox2.Text, textBox3.Text, textBox1.Text, "M", textBox5.Text);//男
                    customerfa.InsertOneCustomer(customer);
                    if (MessageBox.Show("注册成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        this.Hide();
                        Login login = new Login();
                        login.Show();
                    }
                }
                else
                {
                    Customer customer = new Customer(textBox1.Text, textBox2.Text, textBox3.Text, textBox1.Text, "F", textBox5.Text);//女
                    customerfa.InsertOneCustomer(customer);
                    if (MessageBox.Show("注册成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        this.Hide();
                        Login login = new Login();
                        login.Show();
                    }
                }

            }
            

        }

        private Boolean flag = false;


        private void skinButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login mid_form = new Login();
            mid_form.Show();
        }

        Form_Resize form_Resize = new Form_Resize();
        private void Register_Load(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
