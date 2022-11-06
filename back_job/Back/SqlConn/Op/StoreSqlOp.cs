using Back.ObjClass;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.SqlConn.Op
{
    public class StoreSqlOp: Storefa
    {
        /// <summary>
        /// 判断是否存在该人物
        /// </summary>
        /// <param name="Sno"></param>
        /// <returns>返回bool变量</returns>
        public bool IsHave(string Sno)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            int flag = 0;
            try
            {
                cmd.CommandText = "exec IsHaveStore @isHave out,@Sno;";
                //设置参数值@isHave
                cmd.Parameters.Add("@isHave", SqlDbType.Int);
                cmd.Parameters["@isHave"].Value = flag;
                //设置参数为输出参数
                cmd.Parameters["@isHave"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Sno", SqlDbType.VarChar);
                //设置参数值@Pno
                cmd.Parameters["@Sno"].Value = Sno;
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
        ///通过Sno获得某一个商店信息，返回值为一个商店实体
        /// </summary>
        public Store GetOneStore(string sno)
        {
            Store store = new Store();
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("select * from Store where Sno='" + sno + "';", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            store.SetSon(reader.GetString(0));
            store.SetSpass(reader.GetString(1));
            store.SetSname(reader.GetString(2));
            store.SetSaddr(reader.GetString(3));
            store.SetStel(reader.GetString(4));
            store.SetSmoney(reader.GetDecimal(5));
            store.SetState(reader.GetString(6));
            //关闭
            conn.Close();
            return store;
        }
        /// <summary>
        ///获取所有的商店信息，返回值为Dictionary<string,Store>商店的字典，key是商店的Sno
        /// </summary>
        public Dictionary<string, Store> GetAllStore()
        {
            Dictionary<string, Store> stores = new Dictionary<string, Store>();
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("select * from Store", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            //将所有的数据一一存入Store里
            Store store = new Store();
            while (reader.Read())
            {
                store.SetSon(reader.GetString(0));
                store.SetSpass(reader.GetString(1));
                store.SetSname(reader.GetString(2));
                store.SetSaddr(reader.GetString(3));
                store.SetStel(reader.GetString(4));
                store.SetSmoney(reader.GetDecimal(5));
                store.SetState(reader.GetString(6));
                //将保存好的商店信息存入商店集合中
                stores.Add(store.GetSno(), store);
            }
            conn.Close();
            return stores;
        }
        /// <summary>
        ///更新List中所有商店的信息
        /// </summary>
        public void UpdateAllStore(List<Store> stores)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("", conn);
            foreach (Store store in stores)
            {
                //update Store set Spass = '123', Sname = '猎鹿人', Saddr = '蒙德', Stel = '114514', Smoney = 240.00, Sstate = '工作' where Sno = '001';
                cmd.CommandText = "update Store set Spass='" + store.GetSpass() + "',Sname='" + store.GetSname() + "',Saddr='" + store.GetSaddr() + "',Stel='" + store.GetStel() + "',Smoney=" + store.GetSmoney() + ",Sstate='" + store.GetState() + "' where Sno='" + store.GetSno() + "';";
                //Console.WriteLine("update Store set Spass='" + store.GetSpass() + "',Sname='" + store.GetSname() + "',Saddr='" + store.GetSaddr() + "',Stel='" + store.GetStel() + "',Smoney=" + store.GetSmoney() + ",Sstate='" + store.GetState() + "' where Sno='" + store.GetSno()+"';");
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        /// <summary>
        ///更新某一个有商店的信息
        /// </summary>
        public void UpdateOneStore(Store store)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("", conn);
            //update Store set Spass = '123', Sname = '猎鹿人', Saddr = '蒙德', Stel = '114514', Smoney = 240.00, Sstate = '工作' where Sno = '001';
            cmd.CommandText = "update Store set Spass='" + store.GetSpass() + "',Sname='" + store.GetSname() + "',Saddr='" + store.GetSaddr() + "',Stel='" + store.GetStel() + "',Smoney=" + store.GetSmoney() + ",Sstate='" + store.GetState() + "' where Sno='" + store.GetSno() + "';";
            //Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        /// <summary>
        ///插入某一商店
        /// </summary>
        public void InsertOneStore(Store store)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandText = "insert into Store values('" + store.GetSno() + "','" + store.GetSpass() + "','" + store.GetSname() + "','" + store.GetSaddr() + "','" + store.GetStel() + "'," + store.GetSmoney() + ",'" + store.GetState() + "');";
            //Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        /// <summary>
        ///插入List中所有商店
        /// </summary>
        public void InsertAllStore(List<Store> stores)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("", conn);
            foreach (Store store in stores)
            {
                cmd.CommandText = "insert into Store values('" + store.GetSno() + "','" + store.GetSpass() + "','" + store.GetSname() + "','" + store.GetSaddr() + "','" + store.GetStel() + "'," + store.GetSmoney() + ",'" + store.GetState() + "');";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        /// <summary>
        ///删除某一商店的信息
        /// </summary>
        public void DeleteOneStore(Store store)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("", conn);
            //delete from store where Sno='002';
            cmd.CommandText = "delete from Store where Sno='" + store.GetSno() + "';";
            //Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        /// <summary>
        ///删除List中所有商店的信息
        /// </summary>
        public void DeleteAllStore(List<Store> stores)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("", conn);
            foreach (Store store in stores)
            {
                cmd.CommandText = "delete from Store where Sno='" + store.GetSno() + "';";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        /// <summary>
        ///将字典转化为列表
        /// </summary>
        public List<Store> PutInList(Dictionary<string, Store> stores)
        {
            List<Store> list = new List<Store>();
            foreach (Store store in stores.Values)
            {
                list.Add(store);
            }
            return list;
        }
        //public static void Main()
        //{
        //    Storefa storefa = new StoreSqlOp();

        //    if (storefa.IsHave("002"))
        //    {
        //        Console.WriteLine("存在");
        //    }
        //    else
        //    {
        //        Console.WriteLine("不存在");
        //    }
        //}
    }
}
