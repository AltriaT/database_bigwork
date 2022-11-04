using System;
using System.Collections.Generic;
using System.Data;
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
        /// <summary>
        /// 判断是否存在该人物
        /// </summary>
        /// <param name="Ono"></param>
        /// <returns>存在返回true</returns>
        public bool IsHave(string Ono)
        {
            Customer customer = new Customer();
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            int flag = 0;
            try
            {
                cmd.CommandText = "exec IsHaveOrder @isHave out,@Ono;";
                //设置参数值@isHave
                cmd.Parameters.Add("@isHave", SqlDbType.Int);
                cmd.Parameters["@isHave"].Value = flag;
                //设置参数为输出参数
                cmd.Parameters["@isHave"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Ono", SqlDbType.VarChar);
                //设置参数值@Ono
                cmd.Parameters["@Ono"].Value = Ono;
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
        /// 根据Ono获得一个订单
        /// </summary>
        /// <param name="Ono"></param>
        /// <returns>返回一个order类</returns>
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
        /// <summary>
        /// 根据Sno获得所有的订单
        /// </summary>
        /// <param name="sno"></param>
        /// <returns>字典key=Ono value=Order</returns>
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
        /// <summary>
        /// 插入一个订单
        /// </summary>
        /// <param name="order"></param>
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
        /// <summary>
        /// 更新一个订单
        /// </summary>
        /// <param name="order"></param>
        public void UpdateOneOrder(Order order)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandText= "Update Orders set Dno='"+order.GetDno()+"',Ostate='"+order.GetOstate()+"',Otip='"+order.GetOtip()+"' where Ono ='"+order.GetOno()+"';";
            Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        /// <summary>
        /// 删除一个订单
        /// </summary>
        /// <param name="order"></param>
        public void DeleteOneOrder(Order order)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandText = "Delete Orders where Ono='"+order.GetOno()+"';";
            cmd.ExecuteNonQuery();
            Console.WriteLine(cmd.CommandText);
        }
        //购买操作
        /// <summary>
        /// 获得购物车中的所有商品和商品数量
        /// </summary>
        /// <param name="order"></param>
        /// <returns>字典 key=商品，value=数量</returns>
        public Dictionary<Goods,int> GetPurchase(Order order)
        {
            Dictionary<Goods,int> result = new Dictionary<Goods,int>();
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = new SqlCommand("select * from purchase where Ono='"+order.GetOno()+"';", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Goodsfa goodsfa = new GoodsSqlOp();
                Goods goods=goodsfa.GetOneGoods(reader.GetString(1));
                result.Add(goods, reader.GetInt32(2));
            }
            return result;
        }
        /// <summary>
        /// 将购买的物品插入到购买表里
        /// </summary>
        /// <param name="order"></param>
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
        /// <summary>
        /// 将购买表里的物品更新
        /// </summary>
        /// <param name="order"></param>
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
        //public static void Main()
        //{
        //    Customer customer = new Customer("13930251346", "altria", "123", "13930251346", "M", "baoding", 100);
        //    Customerfa customerfa = new CustomerSqlOp();
        //    customerfa.InsertOneCustomer(customer);
        //    if (customerfa.IsHave(customer.GetPno()))
        //    {
        //        customer = customerfa.GetOneCustomer("13930251346");
        //        Console.WriteLine(customer.toString());
        //    }
        //    Order order = new Order("1", null, customer.GetPno(), "001", "订单完成");
        //    Orderfa orderfa = new OrderSqlOp();
        //    Goodsfa goodsfa = new GoodsSqlOp();
        //    orderfa.InsertOneOrder(order);
        //    order.Purchase.Add(goodsfa.GetOneGoods("001"), 5);
        //    order.Purchase.Add(goodsfa.GetOneGoods("002"), 2);
        //    Console.WriteLine(orderfa.IsHave("001"));
        //    orderfa.InsertGoodsIntoPurchase(order);
        //    Dictionary<Goods, int> purchase = orderfa.GetPurchase(order);
        //    foreach (Goods goods in purchase.Keys)
        //    {
        //        Console.WriteLine(goods.GetGname());
        //    }
        //    customerfa.DeleteOneCustomer(customer);
        //}
    }
}
