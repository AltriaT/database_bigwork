using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Form_Resize

    {


        public float X;

        public float Y;


        public void setTag(Control cons)
        {
            Console.Write(cons.ToString()+"\n");
            Control.ControlCollection controlCollection = cons.Controls;
            foreach (Control con in controlCollection)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                Console.Write(con.Name+"        "+con.Tag.ToString()+"\n");
                if (con.Controls!=null)
                    setTag(con);

            }
        }
        private void GetControls2(Control fatherControl)
        {
            //反射
            System.Reflection.FieldInfo[] fieldInfo = this.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            for (int i = 0; i < fieldInfo.Length; i++)
            {
                // listBox1.Items.Add(fieldInfo[i].Name);
            }
        }
        public void setControls(float newx, float newy, Control cons)
        {
            Control.ControlCollection consCollection = cons.Controls;
            foreach (Control con in consCollection)
            {
                Console.Write(con.Name+"     次数\n");
                string[] mytag = con.Tag.ToString().Split(':');
                float a = Convert.ToSingle(mytag[0]) * newx;
                con.Width = (int)a;
                a = Convert.ToSingle(mytag[1]) * newy;
                con.Height = (int)(a);
                a = Convert.ToSingle(mytag[2]) * newx;
                con.Left = (int)(a);
                a = Convert.ToSingle(mytag[3]) * newy;
                con.Top = (int)(a);
                Single currentSize = Convert.ToSingle(mytag[4]) * Math.Min(newx, newy);
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);
                }
            }

        }




    }

    /*在Form_Load里面添加:  

    this.Resize += new EventHandler(Form1_Resize);

        //X = this.Width;    
        //Y = this.Height;    


        setTag(this);
        Form_Resize(new object (),new EventArgs());//x,y可在实例化时赋值,最后这句是新加的，在MDI时有用*/




}
