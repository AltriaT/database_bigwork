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
    public partial class PersonInfo : Form
    {
        Customerfa customerfa = new CustomerSqlOp();
        
        public PersonInfo()
        {
            InitializeComponent();
        }
        Form_Resize form_Resize = new Form_Resize();
        private void PersonInfo_Load(object sender, EventArgs e)
        {
            //form_Resize.X = this.Width;
            //form_Resize.Y = this.Height;
            //form_Resize.setTag(this);

            Customer customer= customerfa.GetOneCustomer(Login.username);
            this.textBox1.Text=Login.username;
            this.textBox2.Text = customer.GetName();
            this.textBox3.Text = customer.GetSex();
            this.textBox4.Text = customer.GetAddress();

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

        private void button1_Click(object sender, EventArgs e)
        {
            Customer customer = customerfa.GetOneCustomer(Login.username);
            customer.SetName(textBox2.Text);
            customer.SetSex(textBox3.Text);
            customer.SetAddress(textBox4.Text);
            customerfa.UpdateOneCustomer(customer);
            MessageBox.Show("修改成功!", "提示信息");
        }
    }
}
