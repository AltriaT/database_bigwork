using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Back.SqlConn
{
    public class ConnectSQL
    {
        string ConnectStr = "Server=(local);database=TakeOut;password=123;user id=sa;";
        public SqlConnection Connect()
        {
            SqlConnection conn=new SqlConnection(ConnectStr);
            try
            {
                conn.Open();
                Console.WriteLine("成功连接数据库");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return conn;
        }
        //public static void Main()
        //{
        //    SqlConnection connectSQL = new ConnectSQL().Connect();
        //    SqlCommand command = new SqlCommand("select * from Course;", connectSQL);
        //    SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Console.WriteLine(String.Format("{0}, {1}",
        //                reader[0], reader[1]));
        //        }
        //}
    }
}
