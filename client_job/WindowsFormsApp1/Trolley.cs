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
    public partial class Trolley : Form
    {
        public Trolley()
        {
            InitializeComponent();
        }

        Form_Resize form_Resize=new Form_Resize();
        private void Trolley_Load(object sender, EventArgs e)
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
