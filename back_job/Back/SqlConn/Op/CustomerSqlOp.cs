using Back.ObjClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
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
        /// <summary>
        /// 判断是否存在该人物
        /// </summary>
        /// <param name="Cno"></param>
        /// <returns>返回bool变量</returns>
        public bool IsHave(string Cno)
        {
            Customer customer = new Customer();
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            int flag=0;
            try
            {
                cmd.CommandText = "exec IsHaveCustomer @isHave out,@Pno;";
                //设置参数值@isHave
                cmd.Parameters.Add("@isHave", SqlDbType.Int);
                cmd.Parameters["@isHave"].Value = flag;
                //设置参数为输出参数
                cmd.Parameters["@isHave"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Pno", SqlDbType.VarChar);
                //设置参数值@Pno
                cmd.Parameters["@Pno"].Value = Cno;
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
        /// 查找一个顾客
        /// </summary>
        /// <param name="Cno"></param>
        /// <returns>若找到返回顾客若没找到，在返回一个空的顾客</returns>
        public Customer GetOneCustomer(string Cno)
        {
            Customer customer = new Customer();
            SqlConnection conn = new ConnectSQL().Connect();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from Customer where Cno='" + Cno + "';";
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                    customer = new Customer(reader.GetString(0), reader.GetString(2), reader.GetString(1), reader.GetString(5), reader.GetString(3), reader.GetString(4), reader.GetDecimal(6));
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Number);
            }
            finally
            {
                conn.Close();
            }
            return customer;
        }
        /// <summary>
        /// 查找所有顾客的信息
        /// </summary>
        /// <returns>所有顾客信息，若为空则字典容量为0</returns>
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

        //public static void Main()
        //{
        //    Customer customer = new Customer("001", "庄颜", "1002", "12354", "女", "地球");
        //    Customerfa customerfa = new CustomerSqlOp();
        //    //Dictionary<string, Customer> customers;
        //    //customers = customerfa.GetAllCustomer();
        //    Console.WriteLine(customerfa.IsHave("18812017120"));
        //    //customerfa.DeleteOneCustomer(customer);
        //    //int st = customerfa.UpdateOneCustomer(customer);
        //    //Console.WriteLine(st);
        //}
    }
}
