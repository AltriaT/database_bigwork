using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Back.ObjClass;
using Back.SqlConn.Op;
using Back.SqlConn;
namespace WindowsFormsApp1
{
    
    

    public partial class Login : Form
    {
        public Boolean exist=false;

        public static String username;
        public static String password;
        public static Dictionary<string, Customer> dic = new Dictionary<string, Customer>();
        Customer customer=null;
        Customerfa customerfa=new CustomerSqlOp();
        String pno = "001";

        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      
        Boolean textboxHasText = false;//判断输入框是否有文本

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "输入手机号";
                textBox1.ForeColor = Color.Black;
                textboxHasText = false;
            }
            else
                textboxHasText = true;

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textboxHasText == false)
                textBox1.Text = "";

            textBox1.ForeColor = Color.Black;

        }


        Boolean flag=false;


        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "输入密码";
                textBox2.ForeColor = Color.Black;
                flag = false;
            }
            else
                flag = true;

        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (flag==false)
                textBox2.Text = "";
            textBox2.ForeColor = Color.Black;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            password = textBox2.Text;

            if ((username == "输入手机号" || username.Length == 0)&&( password == "输入密码" || password.Length == 0))
            {
                MessageBox.Show("请输入信息", "登录提示");
                return;
            }

            else  if (username =="输入手机号"||username.Length==0)
            {
                MessageBox.Show("请输入手机号", "登录提示");
                return;
            }

            else if(password =="输入密码"||password.Length==0)
            {
                MessageBox.Show("请输入密码", "登录提示");
            }
            else                                           //都填了数据，开始正式登录
            {
                
                dic = customerfa.GetAllCustomer();
                if(dic.Count==0)
                {
                    MessageBox.Show("该号码尚未注册，请前往注册", "注册提醒");
                }
                else                         //顾客表不为空 
                {
                    if (dic.ContainsKey(textBox1.Text))         //表中存在该手机号
                    {
                        dic.TryGetValue(textBox1.Text, out customer);
                        if (customer.GetPassword()==password)
                        {
                            username = textBox1.Text;
                            
                            Main_Customer main_Customer = new Main_Customer();
                            main_Customer.Show();
                            exist = true;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("密码错误!", "登录提醒");
                        }
                    }
                    else
                    {
                        MessageBox.Show("该号码尚未注册，请前往注册", "注册提醒");
                    }
                }
            }
        }


        private void ChangeImage(Image img, int millisecondsTimeOut)
        {
            this.Invoke(new Action(() =>
            {
                pictureBox1.Image = img;
                pictureBox1.SizeMode=PictureBoxSizeMode.StretchImage;
            })
                );
            Thread.Sleep(millisecondsTimeOut);
        }

        Thread th;
        private void Form1_Load(object sender, EventArgs e)
        {

            th = new Thread
            (
                    delegate ()
                    {
                        //3就是要循环轮数了
                        for (int i = 0; i < 10; i++)
                        {
                            //调用方法
                            //设置图片的位置和显示时间（1000 为1秒）
                            ChangeImage(Image.FromFile(@"D:\Vs work\WindowsFormsApp1\Picture\1.jpg"), 3000);
                            ChangeImage(Image.FromFile(@"D:\Vs work\WindowsFormsApp1\Picture\2.jpg"), 3000);
                            ChangeImage(Image.FromFile(@"D:\Vs work\WindowsFormsApp1\Picture\3.jpg"), 3000);
                            ChangeImage(Image.FromFile(@"D:\Vs work\WindowsFormsApp1\Picture\4.jpg"), 3000);

                        }
                    }
                );
            th.IsBackground = true;
            th.Start();


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            th.Abort();//结束线程
        }

       

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            Main_Customer main_Customer = new Main_Customer();
            main_Customer.Show();
            exist = true;
            this.Close();

        }

        

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Register logform = new Register();
            logform.Show();
            this.Hide();
        }


        Form_Resize form_Resize=new Form_Resize();
        private void Login_Load(object sender, EventArgs e)
        {

            //form_Resize.X = this.Width;
            //form_Resize.Y = this.Height;
            ////Console.WriteLine(this.Width + this.Height);
            //form_Resize.setTag(this);
        }
        public void Form1_Resize(object sender, EventArgs e)
        {
        //    float newx = (this.Width) / form_Resize.X;
        //    float newy = this.Height / form_Resize.Y;
        //    form_Resize.setControls(newx, newy, this);
            //this.Text = this.Width.ToString() + " " + this.Height.ToString();

        }
    }
}
