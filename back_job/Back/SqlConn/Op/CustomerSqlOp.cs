using Back.ObjClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Back.SqlConn.Op
{
    public class CustomerSqlOp:Customerfa
    {
        /*
         * 面向数据库的代码
         */
        public Customer GetOneCustomer(string Cno)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from Customer where Cno='" + Cno + "';";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Customer customer = new Customer(reader.GetString(0), reader.GetString(2), reader.GetString(1), reader.GetString(5), reader.GetString(3), reader.GetString(4), reader.GetDecimal(6));
            conn.Close();
            return customer;
        }
        public Dictionary<string, Customer> GetAllCustomer()
        {
            Dictionary<string, Customer> customers = new Dictionary<string, Customer>();
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from customer;";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Customer customer = new Customer(reader.GetString(0), reader.GetString(2), reader.GetString(1), reader.GetString(5), reader.GetString(3), reader.GetString(4), reader.GetDecimal(6));
                customers.Add(customer.GetPhoneNumber(), customer);
            }
            conn.Close();
            return customers;
        }

        /// <summary>
        /// 用实体类customer创建一个顾客
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>状态码1(SUCCESS),2627(插入重复键)，547(约束冲突)</returns>
        public int InsertOneCustomer(Customer customer)
        {
            int st = 1;
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            try
            {
                cmd.CommandText = "insert into customer values('" + customer.GetPno() + "','" + customer.GetPassword() + "','" + customer.GetName() + "','" + customer.GetSex() + "','" + customer.GetAddress() + "','" + customer.GetPhoneNumber() + "'," + customer.GetMoney() + ");";
                Console.WriteLine(cmd.CommandText);
                cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                st = ex.Number;
            }
            finally
            {
                conn.Close();
            }
            return st;
        }
        /// <summary>
        /// 更改一个用户的信息
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>状态码1(SUCCESS),2627(插入重复键)，547(约束冲突)</returns>
        public int UpdateOneCustomer(Customer customer)
        {
            int st = 1;
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            try
            {
                cmd.CommandText = "update customer set Cpass = '" + customer.GetPassword() + "',Cname = '" + customer.GetName() + "',Csex='" + customer.GetSex() + "',Cadd='" + customer.GetAddress() + "',Ctel='" + customer.GetPhoneNumber() + "',Cmoney=" + customer.GetMoney().ToString() + " where Cno='" + customer.GetPno() + "';";
                Console.WriteLine(cmd.CommandText);
                cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                st = ex.Number;
            }
            finally
            {
                conn.Close();
            }
            return st;
        }
        /// <summary>
        /// 删除一个用户
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>状态码1(SUCCESS),2627(插入重复键)，547(约束冲突)</returns>
        public int DeleteOneCustomer(Customer customer)
        {
            int st = 1;
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            try
            {
                cmd.CommandText = "Delete from customer where Cno='" + customer.GetPno() + "';";
                Console.WriteLine(cmd.CommandText);
                cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                st=ex.Number;
            }
            finally
            {
                conn.Close();
            }
            return st;
        }
        /*
         * 面向前端的代码
         */

        public bool Registration_Information_SendTo_SQL(string Pno,string password,string name,string sex)
        {
            
            return true;
        }
        //public static void Main()
        //{
        //    Customer customer = new Customer("001", "庄颜", "1002", "12354", "女", "地球");
        //    Customerfa customerfa = new CustomerSqlOp();
        //    //customerfa.DeleteOneCustomer(customer);
        //    int st = customerfa.UpdateOneCustomer(customer);
        //    Console.WriteLine(st);
        //}
    }
}
