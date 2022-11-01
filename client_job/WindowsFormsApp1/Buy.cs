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
using Back.SqlConn;
using Back.SqlConn.Op;
namespace WindowsFormsApp1
{
    public partial class Buy : Form
    {

        

        Form_Resize form_Resize = new Form_Resize();
        public Buy()
        {
            this.Load += new EventHandler(this.Buy_Load);
            InitializeComponent();

        }



        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void 商店一ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 商店二ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        Boolean textboxHasText = false;//判断输入框是否有文本

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "在商品中搜索";
                textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                textboxHasText = false;
            }
            else
                textboxHasText = true;

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textboxHasText == false)
                textBox1.Text = "";

            textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

       

        public void Buy_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“takeOutDataSet.goods”中。您可以根据需要移动或移除它。

            //System.Threading.Thread.Sleep(1000);
            //form_Resize.X=this.Width;
            //form_Resize.Y=this.Height;
            //form_Resize.setTag(this);
            
            int xx = 1;
            int yy = 0;
            foreach (Goods good in mid.Values)
            {
                Label FoodName = new Label();
                Label FoodPrice = new Label();
                PictureBox picture = new PictureBox();
                Button button = new Button();//创建控件
                FoodName.Name = "FoodName_" + good.GetGname();
                FoodPrice.Name = "FoodPrice_" + good.GetGprice();


                /////////////////////////////////////////picture.Name = "picture_" + g;



                button.Name = good.GetGno().ToString();//加入购物车按钮命名为菜品表的FoodID


                FoodName.Text = good.GetGname().ToString();
                FoodPrice.Text = "¥" + good.GetGprice().ToString() + "/份";//控件text属性赋值
                button.Text = "加入购物车";
                FoodName.AutoSize = true;
                FoodPrice.AutoSize = true;
                button.AutoSize = true;
                FoodName.Font = new Font("微软雅黑", 11);
                FoodPrice.Font = new Font("微软雅黑", 11);
                button.Font = new Font("微软雅黑", 6);
                button.BackColor = Color.Gray;
                button.ForeColor = Color.Transparent;
                button.FlatStyle = FlatStyle.Flat;
                button.Size = new Size(60, 10);
                picture.Location = new Point(100 * xx, 20 + yy);
                FoodName.Location = new Point(100 * xx, 100 + yy);
                FoodPrice.Location = new Point(100 * xx, 120 + yy);
                button.Location = new Point(100 * xx, 140 + yy);//控件定位


                /////////////picture.Image = Image.FromFile(Application.StartupPath + @"\FoodPhoto\" + ds.Tables[0].Rows[i]["PhotoName"].ToString());//显示图片，路径为可执行文件所在文件夹的FoodPhoto文件夹内的图片

                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                picture.Size = new Size(150, 80);
                picture.BorderStyle = BorderStyle.FixedSingle;
                button.Cursor = Cursors.Hand;


                button.Click += new EventHandler(this.Button_Click);


                panel1.Controls.Add(FoodName);
                panel1.Controls.Add(FoodPrice);
                panel1.Controls.Add(picture);
                panel1.Controls.Add(button);//把控件绑定到panel中
                xx++;
                if (xx++ >= 5)
                {
                    xx = 1;
                    yy += 180;
                }
            }
        }




        Back.ObjClass.Order order = new Back.ObjClass.Order("002", null, "001", "001", "订单完成");
        static Goodsfa goodsfa = new GoodsSqlOp();

        public Dictionary<string, Goods> mid = goodsfa.GetAllGoods();

        Orderfa orderfa =new OrderSqlOp();
        int i = 0;
        public void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string gno = button.Name;
            Console.WriteLine(gno);
            Console.WriteLine("添加了" + i);
            i++;
           
            order.Purchase.Add(mid[gno], 1);

            orderfa.InsertGoodsIntoPurchase(order);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_Fill()
        {

        }


    }
}
