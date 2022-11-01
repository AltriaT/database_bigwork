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
    public partial class Password : Form
    {

        public Password()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customerfa customerfa = new CustomerSqlOp();
            

            if(this.textBox1.Text.Length==0||this.textBox2.Text.Length==0||this.textBox3.Text.Length==0)
            {
                MessageBox.Show("请输入完整信息!", "提示信息");

            }

            else if(this.textBox1.Text!=Login.password)
            {
                MessageBox.Show("旧密码输入有误!", "提示信息");
                    
            }
            else if (this.textBox2.Text != this.textBox3.Text)
            {
                MessageBox.Show("两次密码输入不一致!", "提示信息");
            }
            else if(this.textBox2.Text==this.textBox1.Text)
            {
                MessageBox.Show("修改前后的密码相同!", "提示信息");
            }
            else 
            {
                Customer customer = customerfa.GetOneCustomer(Login.username);
                customer.SetPassword(this.textBox2.Text);
                customerfa.UpdateOneCustomer(customer);
                if(MessageBox.Show("修改密码成功,请重新登录", "提示信息")==DialogResult.OK)
                {
                    Application.Restart();
                }
            }
        }
    }
}
