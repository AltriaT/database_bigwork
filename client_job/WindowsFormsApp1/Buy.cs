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
            this.Load+=new EventHandler(this.Buy_Load);
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

        Goodsfa goodsfa = new GoodsSqlOp();
       
        public void Buy_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“takeOutDataSet.goods”中。您可以根据需要移动或移除它。
            this.goodsTableAdapter.Fill(goodsfa.GetAllGoods());
            //System.Threading.Thread.Sleep(1000);
            //form_Resize.X=this.Width;
            //form_Resize.Y=this.Height;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.goodsTableAdapter.FillBy(this.takeOutDataSet.goods);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
