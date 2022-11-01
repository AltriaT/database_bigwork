using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Text;
using System.IO;
using Back.ObjClass;
using Back.SqlConn.Op;
using Back.SqlConn;

namespace WindowsFormsApp1
{

  
    public static class Program
    {

       // static Goodsfa Goodsfa = new GoodsSqlOp();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        public static void Main()
        {
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //foreach(Goods goods in Goodsfa.GetAllGoods().Values)
            //{
            //    Console.WriteLine(goods.ToString());
            //}
           

            Login login = new Login();

           
                Application.Run(login);
            
            
            //Boolean flag_login_main=false;
            if(login.exist==true)
            {
               
                Main_Customer main_Customer = new Main_Customer();
                Application.Run(main_Customer);
                
                //flag_login_main = main_Customer.flag_Login 
            }
        
            
        }
    }
}
