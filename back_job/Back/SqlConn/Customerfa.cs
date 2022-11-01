using Back.ObjClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.SqlConn
{
    public interface Customerfa
    {
        public Customer GetOneCustomer(string Cno);
        public Dictionary<string, Customer> GetAllCustomer();
        public void InsertOneCustomer(Customer customer);
        public void UpdateOneCustomer(Customer customer);
        public void DeleteOneCustomer(Customer customer);
    }
}
