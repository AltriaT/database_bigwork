using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Back.ObjClass;
using static System.Formats.Asn1.AsnWriter;

namespace Back.SqlConn.Op
{
    public class OrderSqlOp:Orderfa
    {
        public Order GetOneOrder(string Ono)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from orders where Ono='" + Ono + "';";
            Console.WriteLine(cmd.CommandText);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Order order = new Order(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetDecimal(6), reader.GetDecimal(7));
            conn.Close();
            return order;
        }
        public Dictionary<string, Order> GetAllOrder(string sno)
        {
            Dictionary<string, Order> orders = new Dictionary<string, Order>();
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from orders where Sno='" + sno + "';";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Order order = new Order(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetDecimal(6), reader.GetDecimal(7));
                orders.Add(order.GetOno(), order);
            }
            conn.Close();
            return orders;
        }
        public void InsertOneOrder(Order order)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("", conn);
            string? Dno = null;
            if (order.GetDno() is null) Dno = "null";
            else Dno = "'"+order.GetDno()+"'";
            cmd.CommandText = "insert into orders values('" + order.GetOno() + "'," + Dno + ",'" + order.GetCno() + "','" + order.GetSno() + "','" + order.GetOstate() + "','" + order.GetOtip() + "'," + order.GetOdelfee() + "," + order.GetOmoney() + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
            Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateOneOrder(Order order)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandText= "Update Orders set Dno='"+order.GetDno()+"',Ostate='"+order.GetOstate()+"',Otip='"+order.GetOtip()+"' where Ono ='"+order.GetOno()+"';";
            Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteOneOrder(Order order)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandText = "Delete Orders where Ono='"+order.GetOno()+"';";
            cmd.ExecuteNonQuery();
            Console.WriteLine(cmd.CommandText);
        }
        //购买操作
        public Dictionary<Goods,int> GetPurchase(Order order)
        {
            Dictionary<Goods,int> result = new Dictionary<Goods,int>();
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("select pamount from purchase where Ono='"+order.GetOno()+"';", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Goodsfa goodsfa = new GoodsSqlOp();
                Goods goods=goodsfa.GetOneGoods(reader.GetString(1));
                result.Add(goods, reader.GetInt32(2));
            }
            return result;
        }
        public void InsertGoodsIntoPurchase(Order order)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("", conn);
            foreach (Goods goods in order.Purchase.Keys)
            {
                string Ono = order.GetOno(), Gno = goods.GetGno();
                int pamount = order.Purchase[goods];
                cmd.CommandText = "insert into purchase values('" + Ono + "','" + Gno + "'," + pamount + ")";
                cmd.ExecuteNonQuery();
                Console.WriteLine(cmd.CommandText);
            }
            conn.Close();
        }
        public void UpdateGoodsIntoPurchase(Order order)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("", conn);
            foreach (Goods goods in order.Purchase.Keys)
            {
                string Ono = order.GetOno(), Gno = goods.GetGno();
                int pamount = order.Purchase[goods];
                cmd.CommandText = "update purchase set pamount="+pamount.ToString()+" where Ono='"+Ono+" and Gno='"+Gno+"';";
                Console.WriteLine(cmd.CommandText);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
