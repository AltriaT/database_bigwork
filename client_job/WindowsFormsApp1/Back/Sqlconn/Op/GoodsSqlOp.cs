using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Back.ObjClass;

namespace Back.SqlConn.Op
{
    public class GoodsSqlOp:Goodsfa
    {
        ///<summary>
        ///获得某一个物品
        ///</summary>
        ///<param name="gno"></param>
        public Goods GetOneGoods(string gno)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandText = "select * from goods where Gno='" + gno + "';";
            SqlDataReader reader = cmd.ExecuteReader();
            Goods goods = new Goods(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(3), reader.GetInt32(4));
            conn.Close();
            return goods;
        }
        ///<summary>
        ///获得所有物品
        ///</summary>
        public Dictionary<string, Goods> GetAllGoods()
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandText = "select * from goods;";
            Dictionary<string, Goods> goodses = new Dictionary<string, Goods>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Goods goods = new Goods(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(3), reader.GetInt32(4));
                goodses.Add(goods.GetGno(), goods);
            }
            conn.Close();
            return goodses;
        }
        ///<summary>
        ///更新某一个物品
        ///</summary>
        ///<param name="goods"></param>
        public void UpdateOneStore(Goods goods)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("", conn);
            //update Goods set Gname='金丝虾球',Gprice=10.00,Gstock='5' where Gno='001'and Sno='001';
            cmd.CommandText = "update Goods set " + "Gname='" + goods.GetGname() + "',Gprice=" + goods.GetGprice() + ",Gstock='" + goods.GetGstock() + "' where Gno='" + goods.GetGno() + "'and Sno='" + goods.GetSno() + "';";
            Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        ///<summary>
        ///插入某一个物品
        ///</summary>
        ///<param name="goods"></param>
        public void InsertOneGoods(Goods goods)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandText = "insert into goods values('" + goods.GetGno() + "','" + goods.GetSno() + "','" + goods.GetGname() + "'," + goods.GetGprice() + "," + goods.GetGstock() + ");";
            Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        ///<summary>
        ///删除某一个物品
        ///</summary>
        ///<param name="goods"></param>
        public void DeleteOneGoods(Goods goods)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("", conn);
            //delete from goods where Gno='002';
            cmd.CommandText = "delete from goods where Gno='" + goods.GetGno() + "';";
            Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        ///<summary>
        ///更新所有物品
        ///</summary>
        ///<param name="goodses"></param>
        public void UpdateAllStore(List<Goods> goodses)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("", conn);
            foreach (Goods goods in goodses)
            {
                //update Goods set Gname='金丝虾球',Gprice=10.00,Gstock='5' where Gno='001'and Sno='001';
                cmd.CommandText = "update Goods set " + "Gname='" + goods.GetGname() + "',Gprice=" + goods.GetGprice() + ",Gstock='" + goods.GetGstock() + "' where Gno='" + goods.GetGno() + "'and Sno='" + goods.GetSno() + "';";
                Console.WriteLine(cmd.CommandText);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        ///<summary>
        ///插入所有物品
        ///</summary>
        ///<param name="goodses"></param>
        public void InsertAllGoods(List<Goods> goodses)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("", conn);
            foreach (Goods goods in goodses)
            {
                cmd.CommandText = "insert into goods values('" + goods.GetGno() + "','" + goods.GetSno() + "','" + goods.GetGname() + "'," + goods.GetGprice() + "," + goods.GetGstock() + ");";
                Console.WriteLine(cmd.CommandText);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        ///<summary>
        ///更新所有物品
        ///</summary>
        /// <param name="goodses"></param>
        public void DeleteAllGoods(List<Goods> goodses)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("", conn);
            foreach (Goods goods in goodses)
            {
                //delete from goods where Gno='002';
                cmd.CommandText = "delete from goods where Gno='" + goods.GetGno() + "';";
                Console.WriteLine(cmd.CommandText);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        /// <summary>
        /// 将字典转为列表
        /// </summary>
        /// <param name="Goodses"></param>
        /// <returns>List<Goods></returns>
        public List<Goods> PutInList(Dictionary<string, Goods> Goodses)
        {
            List<Goods> list = new List<Goods>();
            foreach (Goods goods in Goodses.Values)
            {
                list.Add(goods);
            }
            return list;
        }
        //private static void Main()
        //{
        //    GoodsSqlOp op = new GoodsSqlOp();
        //    Goods goods = new Goods("003", "001", "甜甜鸡", 15, 5);
        //    op.InsertOneGoods(goods);
        //    op.DeleteOneGoods(goods);
        //    Dictionary<string, Goods> goodses = op.GetAllGoods();

        //}
    }
}
