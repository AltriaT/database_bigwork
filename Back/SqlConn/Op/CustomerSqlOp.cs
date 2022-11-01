using Back.ObjClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Back.SqlConn.Op
{
    public class CustomerSqlOp:Customerfa
    {
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
                customers.Add(reader.GetString(0), customer);
            }
            conn.Close();
            return customers;
        }
        public void InsertOneCustomer(Customer customer)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "insert into customer values('" + customer.GetPno() + "','" + customer.GetPassword() + "','" + customer.GetName() + "','" + customer.GetSex() + "','" + customer.GetAddress()+"','"+ customer.GetPhoneNumber() + "'," + customer.GetMoney() + ");";
            Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateOneCustomer(Customer customer)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText="update customer set Cpass = '"+customer.GetPassword()+"',Cname = '"+customer.GetName()+"',Csex='"+customer.GetSex()+"',Cadd='"+customer.GetAddress()+"',Ctel='"+customer.GetPhoneNumber()+"',Cmoney="+customer.GetMoney().ToString()+" where Cno='"+customer.GetPno()+"';";
            Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteOneCustomer(Customer customer)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Delete from customer where Cno='"+customer.GetPno()+"';";
            Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
