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
namespace WindowsFormsApp1
{
    public partial class Register : Form
    {
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
            if (MessageBox.Show("注册成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                this.Hide();
                Login login = new Login();
                login.Show();
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
    }
}
