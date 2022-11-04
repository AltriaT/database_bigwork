using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Back.ObjClass;

namespace Back.SqlConn.Op
{
    public class DelivererSqlOp:Delivererfa
    {
        /// <summary>
        /// 判断是否存在该人物
        /// </summary>
        /// <param name="Cno"></param>
        /// <returns>返回bool变量</returns>
        public bool IsHave(string Dno)
        {
            Customer customer = new Customer();
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            int flag = 0;
            try
            {
                cmd.CommandText = "exec IsHaveDeliverer @isHave out,@Pno;";
                //设置参数值@isHave
                cmd.Parameters.Add("@isHave", SqlDbType.Int);
                cmd.Parameters["@isHave"].Value = flag;
                //设置参数为输出参数
                cmd.Parameters["@isHave"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Pno", SqlDbType.VarChar);
                //设置参数值@Pno
                cmd.Parameters["@Pno"].Value = Dno;
                //执行
                cmd.ExecuteNonQuery();
                //接受参数
                flag = int.Parse(cmd.Parameters["@isHave"].Value.ToString());
                //Console.WriteLine(cmd.Parameters["@isHave"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            if (flag == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获得一个人的基本信息
        /// </summary>
        /// <param name="Dno"></param>
        /// <returns>返回快递员类</returns>
        public Deliverer GetOneDeliverer(string Dno)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from deliverer where Dno='" + Dno + "';";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Deliverer deliverer = new Deliverer(reader.GetString(0),reader.GetString(2),reader.GetString(1),reader.GetString(4),reader.GetString(3),reader.GetString(6),reader.GetDecimal(5));
            conn.Close();
            return deliverer;
        }
        /// <summary>
        /// 获得所有的快递员的信息
        /// </summary>
        /// <returns>字典 key=Dno,value=快递员类</returns>
        public Dictionary<string, Deliverer> GetAllDeliverer()
        {
            Dictionary<string, Deliverer> deliverers = new Dictionary<string, Deliverer>();
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from deliverer;";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Deliverer deliverer = new Deliverer(reader.GetString(0), reader.GetString(2), reader.GetString(1), reader.GetString(4), reader.GetString(3), reader.GetString(6), reader.GetDecimal(5));
                deliverers.Add(reader.GetString(0), deliverer);
            }
            conn.Close();
            return deliverers;
        }
        /// <summary>
        /// 插入一个快递员
        /// </summary>
        /// <param name="deliverer"></param>
        public void InsertOneDeliverer(Deliverer deliverer)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText="insert into deliverer values('"+deliverer.GetPno()+"','"+ deliverer.GetPassword()+"','"+deliverer.GetName() + "','" + deliverer.GetSex() + "','" + deliverer.GetPhoneNumber() + "'," + deliverer.GetMoney() + ",'" + deliverer.GetState() + "');";
            Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        /// <summary>
        /// 更新一个快递员信息
        /// </summary>
        /// <param name="deliverer"></param>
        public void UpdateOneDeliverer(Deliverer deliverer)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "update deliverer set Dpass = '" + deliverer.GetPassword() + "',Dname = '" + deliverer.GetName() + "',Dsex='" + deliverer.GetSex()+"',Dstate='"+deliverer.GetState() + "',Dtel='" + deliverer.GetPhoneNumber() + "',Dmoney=" + deliverer.GetMoney().ToString() + " where Dno='"+deliverer.GetPno()+"';";
            Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        /// <summary>
        /// 删除一个快递员
        /// </summary>
        /// <param name="deliverer"></param>
        public void DeleteOneDeliverer(Deliverer deliverer)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Delete from deliverer where Dno='" + deliverer.GetPno() + "';";
            Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //public static void Main()
        //{
        //    Delivererfa delivererfa = new DelivererSqlOp();
        //    Deliverer deliverer = new Deliverer("003", "玛琪玛", "123", "65431", "F", "正在配送", 0);
        //    delivererfa.InsertOneDeliverer(deliverer);
        //    //Deliverer deliverer = delivererfa.GetOneDeliverer("003");
        //    if (delivererfa.IsHave(deliverer.GetPno()))
        //    {
        //        Console.WriteLine("存在");
        //        delivererfa.DeleteOneDeliverer(deliverer);
        //    }
        //    else
        //    {
        //        Console.WriteLine("不存在");
        //    }
        //        //delivererfa.InsertOneDeliverer(deliverer);
        //        Dictionary<string, Deliverer> deliverers = delivererfa.GetAllDeliverer();
        //    foreach (Deliverer deliverer1 in deliverers.Values)
        //    {
        //        Console.WriteLine(deliverer1.toString());
        //    }
        //}
    }
}